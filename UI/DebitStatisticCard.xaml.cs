using System.Windows;
using System.Windows.Controls;

namespace Dim.WPF.Shared.Library.UI;

public partial class DebitStatisticCard : UserControl
{
    public DebitStatisticCard()
    {
        InitializeComponent();
    }

    public static readonly DependencyProperty ValueProperty =
        DependencyProperty.Register(
            nameof(Value),
            typeof(string),
            typeof(DebitStatisticCard),
            new PropertyMetadata("0"));

    public string Value
    {
        get => (string)GetValue(ValueProperty);
        set => SetValue(ValueProperty, value);
    }

    public static readonly DependencyProperty LabelFontSizeProperty =
        DependencyProperty.Register(
            nameof(LabelFontSize),
            typeof(double),
            typeof(DebitStatisticCard),
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
            typeof(DebitStatisticCard),
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
            typeof(DebitStatisticCard),
            new PropertyMetadata(new Thickness(16, 12, 16, 12)));

    public new Thickness Padding
    {
        get => (Thickness)GetValue(PaddingProperty);
        set => SetValue(PaddingProperty, value);
    }
}
