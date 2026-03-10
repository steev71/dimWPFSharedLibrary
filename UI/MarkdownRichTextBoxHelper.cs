using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;

namespace Dim.WPF.Shared.Library.UI;

public static class MarkdownRichTextBoxHelper
{
    public static readonly DependencyProperty DocumentProperty =
        DependencyProperty.RegisterAttached(
            "Document",
            typeof(FlowDocument),
            typeof(MarkdownRichTextBoxHelper),
            new FrameworkPropertyMetadata(null, OnDocumentChanged));

    public static void SetDocument(DependencyObject obj, FlowDocument value)
        => obj.SetValue(DocumentProperty, value);

    public static FlowDocument GetDocument(DependencyObject obj)
        => (FlowDocument)obj.GetValue(DocumentProperty);

    private static void OnDocumentChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
        if (d is RichTextBox richTextBox)
            richTextBox.Document = e.NewValue as FlowDocument ?? new FlowDocument();
    }
}
