using System.Data;
using System.Text.RegularExpressions;

namespace Dim.WPF.Shared.Library.UI;

internal static class MarkdownParser
{
    private static readonly Regex StrictTableRegex = new(
        @"(\|[^\n]+\|\r?\n\|[-:\s]+\|(?:\r?\n|$)(?:\|[^\n]+\|(?:\r?\n|$))+)",
        RegexOptions.Multiline | RegexOptions.Compiled);

    private static readonly Regex AlternativeTableRegex = new(
        @"((?:\|[^\n]+\|(?:\r?\n|$)){3,})",
        RegexOptions.Multiline | RegexOptions.Compiled);

    public static IReadOnlyList<MarkdownContentPart> Parse(string? markdown)
    {
        if (string.IsNullOrWhiteSpace(markdown))
            return [];

        var strictMatches = StrictTableRegex.Matches(markdown);
        var alternativeMatches = AlternativeTableRegex.Matches(markdown);

        var allMatches = strictMatches.Cast<Match>()
            .Concat(alternativeMatches.Cast<Match>())
            .DistinctBy(m => m.Value)
            .OrderBy(m => m.Index)
            .ToList();

        if (allMatches.Count == 0)
            return [new MarkdownContentPart { Type = MarkdownContentPartType.Text, TextContent = markdown }];

        var parts = new List<MarkdownContentPart>();
        int lastIndex = 0;

        foreach (var match in allMatches)
        {
            if (match.Index > lastIndex)
            {
                string textBefore = markdown[lastIndex..match.Index];
                if (!string.IsNullOrWhiteSpace(textBefore))
                    parts.Add(new MarkdownContentPart { Type = MarkdownContentPartType.Text, TextContent = textBefore.Trim() });
            }

            var dataTable = ParseMarkdownTable(match.Value);
            if (dataTable?.Rows.Count > 0)
                parts.Add(new MarkdownContentPart { Type = MarkdownContentPartType.Table, TableData = dataTable });

            lastIndex = match.Index + match.Length;
        }

        if (lastIndex < markdown.Length)
        {
            string textAfter = markdown[lastIndex..];
            if (!string.IsNullOrWhiteSpace(textAfter))
                parts.Add(new MarkdownContentPart { Type = MarkdownContentPartType.Text, TextContent = textAfter.Trim() });
        }

        return parts;
    }

    private static DataTable? ParseMarkdownTable(string markdown)
    {
        try
        {
            var lines = markdown
                .Split(['\r', '\n'], StringSplitOptions.RemoveEmptyEntries)
                .Where(l => l.Trim().StartsWith("|") && l.Trim().EndsWith("|"))
                .ToArray();

            if (lines.Length < 2)
                return null;

            var headers = lines[0]
                .Split('|', StringSplitOptions.RemoveEmptyEntries)
                .Select(h => h.Trim())
                .ToArray();

            if (headers.Length == 0)
                return null;

            var dataTable = new DataTable();
            foreach (var h in headers)
                dataTable.Columns.Add(h);

            int dataStart = lines.Length > 1 && lines[1].Contains("---") ? 2 : 1;

            for (int i = dataStart; i < lines.Length; i++)
            {
                var cells = lines[i]
                    .Split('|', StringSplitOptions.RemoveEmptyEntries)
                    .Select(c => c.Trim())
                    .ToArray();

                var row = new string[headers.Length];
                for (int j = 0; j < headers.Length; j++)
                    row[j] = j < cells.Length ? cells[j] : string.Empty;

                dataTable.Rows.Add(row);
            }

            return dataTable.Rows.Count > 0 ? dataTable : null;
        }
        catch
        {
            return null;
        }
    }
}
