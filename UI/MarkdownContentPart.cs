using System.Data;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Media;

namespace Dim.WPF.Shared.Library.UI;

public enum MarkdownContentPartType
{
    Text,
    Table
}

public class MarkdownContentPart
{
    private static readonly Regex HeaderRegex = new(@"^(#{1,6})\s+(.+)$", RegexOptions.Compiled);
    private static readonly Regex UnorderedListRegex = new(@"^[-*+]\s+(.+)$", RegexOptions.Compiled);
    private static readonly Regex OrderedListRegex = new(@"^\d+\.\s+(.+)$", RegexOptions.Compiled);
    private static readonly Regex BlockquoteRegex = new(@"^>\s?(.*)$", RegexOptions.Compiled);
    private static readonly Regex HrRegex = new(@"^[-*_]{3,}$", RegexOptions.Compiled);

    // Bold (**...**  or  __...__), inline code (`...`), link ([text](url)), italic (*...*)
    private static readonly Regex InlineRegex = new(
        @"\*\*(.+?)\*\*|__(.+?)__|`(.+?)`|\[(.+?)\]\((.+?)\)|(?<!\*)\*(?!\*)(.+?)(?<!\*)\*(?!\*)",
        RegexOptions.Compiled | RegexOptions.Singleline);

    public MarkdownContentPartType Type { get; init; }
    public string? TextContent { get; init; }
    public DataTable? TableData { get; init; }

    private FlowDocument? _formattedDocument;
    public FlowDocument FormattedDocument => _formattedDocument ??= BuildDocument();

    private FlowDocument BuildDocument()
    {
        var doc = new FlowDocument { PagePadding = new Thickness(0) };
        if (string.IsNullOrEmpty(TextContent))
            return doc;

        var lines = TextContent.Split('\n');
        bool inCodeBlock = false;
        var codeLines = new List<string>();
        var listItems = new List<ListItem>();
        bool isOrderedList = false;

        void FlushList()
        {
            if (listItems.Count == 0) return;
            var list = new List
            {
                MarkerStyle = isOrderedList ? TextMarkerStyle.Decimal : TextMarkerStyle.Disc,
                Padding = new Thickness(20, 0, 0, 0)
            };
            foreach (var li in listItems)
                list.ListItems.Add(li);
            doc.Blocks.Add(list);
            listItems.Clear();
        }

        void FlushCodeBlock()
        {
            if (codeLines.Count == 0) return;
            var para = new Paragraph
            {
                Background = new SolidColorBrush(Color.FromRgb(246, 248, 250)),
                FontFamily = new FontFamily("Consolas,Courier New"),
                Padding = new Thickness(8, 6, 8, 6),
                Margin = new Thickness(0, 4, 0, 8)
            };
            para.Inlines.Add(new Run(string.Join("\n", codeLines)));
            doc.Blocks.Add(para);
            codeLines.Clear();
        }

        foreach (var rawLine in lines)
        {
            var line = rawLine.TrimEnd();

            if (line.StartsWith("```"))
            {
                if (inCodeBlock)
                {
                    inCodeBlock = false;
                    FlushCodeBlock();
                }
                else
                {
                    FlushList();
                    inCodeBlock = true;
                }
                continue;
            }

            if (inCodeBlock)
            {
                codeLines.Add(line);
                continue;
            }

            if (HrRegex.IsMatch(line.Trim()))
            {
                FlushList();
                doc.Blocks.Add(new BlockUIContainer(new System.Windows.Controls.Separator()));
                continue;
            }

            var headerMatch = HeaderRegex.Match(line);
            if (headerMatch.Success)
            {
                FlushList();
                int level = headerMatch.Groups[1].Length;
                double fontSize = level switch { 1 => 22, 2 => 18, 3 => 16, 4 => 14, _ => 13 };
                var para = new Paragraph
                {
                    FontSize = fontSize,
                    FontWeight = FontWeights.Bold,
                    Margin = new Thickness(0, level <= 2 ? 12 : 8, 0, 4)
                };
                AddInlines(para.Inlines, headerMatch.Groups[2].Value);
                doc.Blocks.Add(para);
                continue;
            }

            var bqMatch = BlockquoteRegex.Match(line);
            if (bqMatch.Success)
            {
                FlushList();
                var para = new Paragraph
                {
                    Margin = new Thickness(0, 2, 0, 2),
                    Padding = new Thickness(10, 2, 0, 2),
                    BorderBrush = new SolidColorBrush(Color.FromRgb(200, 200, 200)),
                    BorderThickness = new Thickness(3, 0, 0, 0),
                    Foreground = new SolidColorBrush(Color.FromRgb(90, 90, 90))
                };
                AddInlines(para.Inlines, bqMatch.Groups[1].Value);
                doc.Blocks.Add(para);
                continue;
            }

            var ulMatch = UnorderedListRegex.Match(line);
            if (ulMatch.Success)
            {
                if (listItems.Count > 0 && isOrderedList) FlushList();
                isOrderedList = false;
                var para = new Paragraph { Margin = new Thickness(0) };
                AddInlines(para.Inlines, ulMatch.Groups[1].Value);
                listItems.Add(new ListItem(para));
                continue;
            }

            var olMatch = OrderedListRegex.Match(line);
            if (olMatch.Success)
            {
                if (listItems.Count > 0 && !isOrderedList) FlushList();
                isOrderedList = true;
                var para = new Paragraph { Margin = new Thickness(0) };
                AddInlines(para.Inlines, olMatch.Groups[1].Value);
                listItems.Add(new ListItem(para));
                continue;
            }

            FlushList();

            if (string.IsNullOrWhiteSpace(line))
                continue;

            var paragraph = new Paragraph { Margin = new Thickness(0, 2, 0, 2) };
            AddInlines(paragraph.Inlines, line);
            doc.Blocks.Add(paragraph);
        }

        FlushList();
        if (inCodeBlock) FlushCodeBlock();

        return doc;
    }

    private static void AddInlines(InlineCollection inlines, string text)
    {
        int pos = 0;
        foreach (Match m in InlineRegex.Matches(text))
        {
            if (m.Index > pos)
                inlines.Add(new Run(text[pos..m.Index]));

            if (m.Groups[1].Success)       // **bold**
                inlines.Add(new Bold(new Run(m.Groups[1].Value)));
            else if (m.Groups[2].Success)  // __bold__
                inlines.Add(new Bold(new Run(m.Groups[2].Value)));
            else if (m.Groups[3].Success)  // `code`
                inlines.Add(new Run(m.Groups[3].Value)
                {
                    FontFamily = new FontFamily("Consolas,Courier New"),
                    Background = new SolidColorBrush(Color.FromRgb(240, 240, 240))
                });
            else if (m.Groups[4].Success)  // [text](url)
            {
                var link = new Hyperlink(new Run(m.Groups[4].Value));
                if (Uri.TryCreate(m.Groups[5].Value, UriKind.Absolute, out var uri))
                    link.NavigateUri = uri;
                inlines.Add(link);
            }
            else if (m.Groups[6].Success)  // *italic*
                inlines.Add(new Italic(new Run(m.Groups[6].Value)));

            pos = m.Index + m.Length;
        }

        if (pos < text.Length)
            inlines.Add(new Run(text[pos..]));

        if (inlines.Count == 0)
            inlines.Add(new Run(string.Empty));
    }
}
