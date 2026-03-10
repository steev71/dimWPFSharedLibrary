using System.Windows;
using System.Windows.Media;

namespace Dim.WPF.Shared.Library.UI
{
    public static class ButtonAssist
    {
        public static readonly DependencyProperty CornerRadiusProperty =
            DependencyProperty.RegisterAttached(
                "CornerRadius",
                typeof(CornerRadius),
                typeof(ButtonAssist),
                new FrameworkPropertyMetadata(new CornerRadius(5), FrameworkPropertyMetadataOptions.Inherits));

        public static void SetCornerRadius(DependencyObject element, CornerRadius value)
            => element.SetValue(CornerRadiusProperty, value);

        public static CornerRadius GetCornerRadius(DependencyObject element)
            => (CornerRadius)element.GetValue(CornerRadiusProperty);


        public static readonly DependencyProperty HoverBackgroundProperty =
            DependencyProperty.RegisterAttached(
                "HoverBackground",
                typeof(Brush),
                typeof(ButtonAssist),
                new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.Inherits));

        public static void SetHoverBackground(DependencyObject element, Brush value)
            => element.SetValue(HoverBackgroundProperty, value);

        public static Brush GetHoverBackground(DependencyObject element)
            => (Brush)element.GetValue(HoverBackgroundProperty);


        public static readonly DependencyProperty PressedBackgroundProperty =
            DependencyProperty.RegisterAttached(
                "PressedBackground",
                typeof(Brush),
                typeof(ButtonAssist),
                new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.Inherits));

        public static void SetPressedBackground(DependencyObject element, Brush value)
            => element.SetValue(PressedBackgroundProperty, value);

        public static Brush GetPressedBackground(DependencyObject element)
            => (Brush)element.GetValue(PressedBackgroundProperty);
    }
}
