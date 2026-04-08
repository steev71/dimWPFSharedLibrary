using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Dim.WPF.Shared.Library.UI;

public partial class LoadingOverlay : UserControl
{
    public LoadingOverlay()
    {
        InitializeComponent();
    }

    public static readonly DependencyProperty IsLoadingProperty =
        DependencyProperty.Register(
            nameof(IsLoading),
            typeof(bool),
            typeof(LoadingOverlay),
            new PropertyMetadata(false));

    public bool IsLoading
    {
        get => (bool)GetValue(IsLoadingProperty);
        set => SetValue(IsLoadingProperty, value);
    }

    public static readonly DependencyProperty TitleProperty =
        DependencyProperty.Register(
            nameof(Title),
            typeof(string),
            typeof(LoadingOverlay),
            new PropertyMetadata("⏳ Betöltés folyamatban"));

    public string Title
    {
        get => (string)GetValue(TitleProperty);
        set => SetValue(TitleProperty, value);
    }

    public static readonly DependencyProperty DescriptionProperty =
        DependencyProperty.Register(
            nameof(Description),
            typeof(string),
            typeof(LoadingOverlay),
            new PropertyMetadata(string.Empty));

    public string Description
    {
        get => (string)GetValue(DescriptionProperty);
        set => SetValue(DescriptionProperty, value);
    }

    public static readonly DependencyProperty PanelMinWidthProperty =
        DependencyProperty.Register(
            nameof(PanelMinWidth),
            typeof(double),
            typeof(LoadingOverlay),
            new PropertyMetadata(340d));

    public double PanelMinWidth
    {
        get => (double)GetValue(PanelMinWidthProperty);
        set => SetValue(PanelMinWidthProperty, value);
    }

    public static readonly DependencyProperty OverlayBackgroundProperty =
        DependencyProperty.Register(
            nameof(OverlayBackground),
            typeof(Brush),
            typeof(LoadingOverlay),
            new PropertyMetadata(new SolidColorBrush((Color)ColorConverter.ConvertFromString("#CCFFFFFF"))));

    public Brush OverlayBackground
    {
        get => (Brush)GetValue(OverlayBackgroundProperty);
        set => SetValue(OverlayBackgroundProperty, value);
    }

    public static readonly DependencyProperty PanelBackgroundProperty =
        DependencyProperty.Register(
            nameof(PanelBackground),
            typeof(Brush),
            typeof(LoadingOverlay),
            new PropertyMetadata(Colors.WhiteBrush));

    public Brush PanelBackground
    {
        get => (Brush)GetValue(PanelBackgroundProperty);
        set => SetValue(PanelBackgroundProperty, value);
    }

    public static readonly DependencyProperty PanelBorderBrushProperty =
        DependencyProperty.Register(
            nameof(PanelBorderBrush),
            typeof(Brush),
            typeof(LoadingOverlay),
            new PropertyMetadata(Colors.Primary200Brush));

    public Brush PanelBorderBrush
    {
        get => (Brush)GetValue(PanelBorderBrushProperty);
        set => SetValue(PanelBorderBrushProperty, value);
    }
}
