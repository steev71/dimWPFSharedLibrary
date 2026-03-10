using System.Collections.ObjectModel;
using System.Data;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Dim.WPF.Shared.Library.UI;

public partial class MarkdownViewer : UserControl
{
    public MarkdownViewer()
    {
        InitializeComponent();
    }

    // ── MarkdownText ──────────────────────────────────────────────────────

    public static readonly DependencyProperty MarkdownTextProperty =
        DependencyProperty.Register(
            nameof(MarkdownText),
            typeof(string),
            typeof(MarkdownViewer),
            new PropertyMetadata(string.Empty, OnMarkdownTextChanged));

    public string MarkdownText
    {
        get => (string)GetValue(MarkdownTextProperty);
        set => SetValue(MarkdownTextProperty, value);
    }

    private static void OnMarkdownTextChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        => ((MarkdownViewer)d).RebuildContentParts();

    // ── IsStreaming ───────────────────────────────────────────────────────

    public static readonly DependencyProperty IsStreamingProperty =
        DependencyProperty.Register(
            nameof(IsStreaming),
            typeof(bool),
            typeof(MarkdownViewer),
            new PropertyMetadata(false));

    public bool IsStreaming
    {
        get => (bool)GetValue(IsStreamingProperty);
        set => SetValue(IsStreamingProperty, value);
    }

    // ── ExportTableCommand ────────────────────────────────────────────────

    public static readonly DependencyProperty ExportTableCommandProperty =
        DependencyProperty.Register(
            nameof(ExportTableCommand),
            typeof(ICommand),
            typeof(MarkdownViewer),
            new PropertyMetadata(null, OnExportTableCommandChanged));

    public ICommand? ExportTableCommand
    {
        get => (ICommand?)GetValue(ExportTableCommandProperty);
        set => SetValue(ExportTableCommandProperty, value);
    }

    private static void OnExportTableCommandChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        => ((MarkdownViewer)d).ShowExportButton = e.NewValue is not null;

    // ── ShowExportButton (computed, updated by ExportTableCommand change) ─

    public static readonly DependencyProperty ShowExportButtonProperty =
        DependencyProperty.Register(
            nameof(ShowExportButton),
            typeof(bool),
            typeof(MarkdownViewer),
            new PropertyMetadata(false));

    public bool ShowExportButton
    {
        get => (bool)GetValue(ShowExportButtonProperty);
        private set => SetValue(ShowExportButtonProperty, value);
    }

    // ── ContentParts (internal observable collection) ─────────────────────

    public ObservableCollection<MarkdownContentPart> ContentParts { get; } = [];

    private void RebuildContentParts()
    {
        ContentParts.Clear();
        foreach (var part in MarkdownParser.Parse(MarkdownText))
            ContentParts.Add(part);
    }

    // ── Mouse wheel bubbling (RichTextBox/DataGrid elnyeli az eseményt) ──────

    private void ItemsControl_PreviewMouseWheel(object sender, MouseWheelEventArgs e)
    {
        if (!e.Handled)
        {
            e.Handled = true;
            RaiseEvent(new MouseWheelEventArgs(e.MouseDevice, e.Timestamp, e.Delta)
            {
                RoutedEvent = MouseWheelEvent,
                Source = this
            });
        }
    }

    // ── DataGrid AutoGeneratingColumn ─────────────────────────────────────

    private void DataGrid_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
    {
        if ((e.PropertyName.Contains('.') || e.PropertyName.Contains('/'))
            && e.Column is DataGridBoundColumn boundColumn)
        {
            boundColumn.Binding = new System.Windows.Data.Binding($"[{e.PropertyName}]");
        }

        e.Column.Visibility = Visibility.Visible;
    }
}
