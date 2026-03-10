using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Dim.WPF.Shared.Library.UI;

public partial class StatisticCard : UserControl
{
    public StatisticCard()
    {
        InitializeComponent();
    }

    public static readonly DependencyProperty LabelProperty =
        DependencyProperty.Register(
            nameof(Label),
            typeof(string),
            typeof(StatisticCard),
            new PropertyMetadata(string.Empty));

    public string Label
    {
        get => (string)GetValue(LabelProperty);
        set => SetValue(LabelProperty, value);
    }

    public static readonly DependencyProperty ValueProperty =
        DependencyProperty.Register(
            nameof(Value),
            typeof(string),
            typeof(StatisticCard),
            new PropertyMetadata("0"));

    public string Value
    {
        get => (string)GetValue(ValueProperty);
        set => SetValue(ValueProperty, value);
    }

    public static readonly DependencyProperty CardBackgroundProperty =
        DependencyProperty.Register(
            nameof(CardBackground),
            typeof(Brush),
            typeof(StatisticCard),
            new PropertyMetadata(Brushes.White));

    public Brush CardBackground
    {
        get => (Brush)GetValue(CardBackgroundProperty);
        set => SetValue(CardBackgroundProperty, value);
    }

    public static readonly DependencyProperty CardBorderBrushProperty =
        DependencyProperty.Register(
            nameof(CardBorderBrush),
            typeof(Brush),
            typeof(StatisticCard),
            new PropertyMetadata(Brushes.LightGray));

    public Brush CardBorderBrush
    {
        get => (Brush)GetValue(CardBorderBrushProperty);
        set => SetValue(CardBorderBrushProperty, value);
    }

    public static readonly DependencyProperty LabelForegroundProperty =
        DependencyProperty.Register(
            nameof(LabelForeground),
            typeof(Brush),
            typeof(StatisticCard),
            new PropertyMetadata(Brushes.Gray));

    public Brush LabelForeground
    {
        get => (Brush)GetValue(LabelForegroundProperty);
        set => SetValue(LabelForegroundProperty, value);
    }

    public static readonly DependencyProperty ValueForegroundProperty =
        DependencyProperty.Register(
            nameof(ValueForeground),
            typeof(Brush),
            typeof(StatisticCard),
            new PropertyMetadata(Brushes.Black));

    public Brush ValueForeground
    {
        get => (Brush)GetValue(ValueForegroundProperty);
        set => SetValue(ValueForegroundProperty, value);
    }

    public static readonly DependencyProperty LabelFontSizeProperty =
        DependencyProperty.Register(
            nameof(LabelFontSize),
            typeof(double),
            typeof(StatisticCard),
            new PropertyMetadata(12d));

    public double LabelFontSize
    {
        get => (double)GetValue(LabelFontSizeProperty);
        set => SetValue(LabelFontSizeProperty, value);
    }

    public static readonly DependencyProperty ValueFontSizeProperty =
        DependencyProperty.Register(
            nameof(ValueFontSize),
            typeof(double),
            typeof(StatisticCard),
            new PropertyMetadata(20d));

    public double ValueFontSize
    {
        get => (double)GetValue(ValueFontSizeProperty);
        set => SetValue(ValueFontSizeProperty, value);
    }

    public static new readonly DependencyProperty PaddingProperty =
        DependencyProperty.Register(
            nameof(Padding),
            typeof(Thickness),
            typeof(StatisticCard),
            new PropertyMetadata(new Thickness(16, 12, 16, 12)));

    public new Thickness Padding
    {
        get => (Thickness)GetValue(PaddingProperty);
        set => SetValue(PaddingProperty, value);
    }
}
