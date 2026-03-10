using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace Dim.WPF.Shared.Library.UI;

public partial class AuditCardControl : UserControl
{
    private int _clickHandlerCount;

    public static readonly RoutedEvent ClickEvent = EventManager.RegisterRoutedEvent(
        nameof(Click),
        RoutingStrategy.Bubble,
        typeof(RoutedEventHandler),
        typeof(AuditCardControl));

    public event RoutedEventHandler Click
    {
        add
        {
            AddHandler(ClickEvent, value);
            _clickHandlerCount++;
            UpdateShowArrow();
        }
        remove
        {
            RemoveHandler(ClickEvent, value);
            if (_clickHandlerCount > 0)
                _clickHandlerCount--;
            UpdateShowArrow();
        }
    }

    public AuditCardControl()
    {
        InitializeComponent();

        RootButton.Click += (_, _) => RaiseEvent(new RoutedEventArgs(ClickEvent, this));
        UpdateShowArrow();
    }

    public static readonly DependencyProperty CommandProperty =
        DependencyProperty.Register(
            nameof(Command),
            typeof(ICommand),
            typeof(AuditCardControl),
            new PropertyMetadata(null, OnInteractivityChanged));

    public ICommand? Command
    {
        get => (ICommand?)GetValue(CommandProperty);
        set => SetValue(CommandProperty, value);
    }

    public static readonly DependencyProperty CommandParameterProperty =
        DependencyProperty.Register(
            nameof(CommandParameter),
            typeof(object),
            typeof(AuditCardControl),
            new PropertyMetadata(null));

    public static readonly DependencyProperty ShowArrowProperty =
        DependencyProperty.Register(
            nameof(ShowArrow),
            typeof(bool),
            typeof(AuditCardControl),
            new PropertyMetadata(false));

    public bool ShowArrow
    {
        get => (bool)GetValue(ShowArrowProperty);
        private set => SetValue(ShowArrowProperty, value);
    }

    public object? CommandParameter
    {
        get => GetValue(CommandParameterProperty);
        set => SetValue(CommandParameterProperty, value);
    }

    public static readonly DependencyProperty IsClickableProperty =
        DependencyProperty.Register(
            nameof(IsClickable),
            typeof(bool),
            typeof(AuditCardControl),
            new PropertyMetadata(true, OnInteractivityChanged));

    public bool IsClickable
    {
        get => (bool)GetValue(IsClickableProperty);
        set => SetValue(IsClickableProperty, value);
    }

    private static void OnInteractivityChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
        if (d is AuditCardControl control)
            control.UpdateShowArrow();
    }

    private void UpdateShowArrow()
    {
        ShowArrow = IsClickable && (Command is not null || _clickHandlerCount > 0);
    }

    public static readonly DependencyProperty TitleIconProperty =
        DependencyProperty.Register(
            nameof(TitleIcon),
            typeof(ImageSource),
            typeof(AuditCardControl),
            new PropertyMetadata(null, OnTitleIconChanged));

    public ImageSource? TitleIcon
    {
        get => (ImageSource?)GetValue(TitleIconProperty);
        set => SetValue(TitleIconProperty, value);
    }

    public static readonly DependencyProperty TitleIconPathDataProperty =
        DependencyProperty.Register(
            nameof(TitleIconPathData),
            typeof(string),
            typeof(AuditCardControl),
            new PropertyMetadata(string.Empty, OnTitleIconChanged));

    public string TitleIconPathData
    {
        get => (string)GetValue(TitleIconPathDataProperty);
        set => SetValue(TitleIconPathDataProperty, value);
    }

    public static readonly DependencyProperty TitleIconForegroundProperty =
        DependencyProperty.Register(
            nameof(TitleIconForeground),
            typeof(Brush),
            typeof(AuditCardControl),
            new PropertyMetadata(Brushes.White));

    public Brush TitleIconForeground
    {
        get => (Brush)GetValue(TitleIconForegroundProperty);
        set => SetValue(TitleIconForegroundProperty, value);
    }

    public static readonly DependencyProperty TitleIconSizeProperty =
        DependencyProperty.Register(
            nameof(TitleIconSize),
            typeof(double),
            typeof(AuditCardControl),
            new PropertyMetadata(22d));

    public double TitleIconSize
    {
        get => (double)GetValue(TitleIconSizeProperty);
        set => SetValue(TitleIconSizeProperty, value);
    }

    public static readonly DependencyProperty IsTitleIconVisibleProperty =
        DependencyProperty.Register(
            nameof(IsTitleIconVisible),
            typeof(bool),
            typeof(AuditCardControl),
            new PropertyMetadata(false));

    public bool IsTitleIconVisible
    {
        get => (bool)GetValue(IsTitleIconVisibleProperty);
        private set => SetValue(IsTitleIconVisibleProperty, value);
    }

    public static readonly DependencyProperty IsTitleImageIconVisibleProperty =
        DependencyProperty.Register(
            nameof(IsTitleImageIconVisible),
            typeof(bool),
            typeof(AuditCardControl),
            new PropertyMetadata(false));

    public bool IsTitleImageIconVisible
    {
        get => (bool)GetValue(IsTitleImageIconVisibleProperty);
        private set => SetValue(IsTitleImageIconVisibleProperty, value);
    }

    public static readonly DependencyProperty IsTitlePathIconVisibleProperty =
        DependencyProperty.Register(
            nameof(IsTitlePathIconVisible),
            typeof(bool),
            typeof(AuditCardControl),
            new PropertyMetadata(false));

    public bool IsTitlePathIconVisible
    {
        get => (bool)GetValue(IsTitlePathIconVisibleProperty);
        private set => SetValue(IsTitlePathIconVisibleProperty, value);
    }

    private static void OnTitleIconChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
        if (d is not AuditCardControl control)
            return;

        var hasImage = control.TitleIcon is not null;
        var hasPath = !string.IsNullOrWhiteSpace(control.TitleIconPathData);

        control.IsTitleImageIconVisible = hasImage;
        control.IsTitlePathIconVisible = !hasImage && hasPath;
        control.IsTitleIconVisible = control.IsTitleImageIconVisible || control.IsTitlePathIconVisible;
    }

    public static readonly DependencyProperty TitleTextProperty =
        DependencyProperty.Register(
            nameof(TitleText),
            typeof(string),
            typeof(AuditCardControl),
            new PropertyMetadata(string.Empty));

    public string TitleText
    {
        get => (string)GetValue(TitleTextProperty);
        set => SetValue(TitleTextProperty, value);
    }

    public static readonly DependencyProperty TitleBackgroundProperty =
        DependencyProperty.Register(
            nameof(TitleBackground),
            typeof(Brush),
            typeof(AuditCardControl),
            new PropertyMetadata(Brushes.SteelBlue));

    public Brush TitleBackground
    {
        get => (Brush)GetValue(TitleBackgroundProperty);
        set => SetValue(TitleBackgroundProperty, value);
    }

    public static readonly DependencyProperty TitleColorProperty =
        DependencyProperty.Register(
            nameof(TitleColor),
            typeof(Brush),
            typeof(AuditCardControl),
            new PropertyMetadata(Brushes.White));

    public Brush TitleColor
    {
        get => (Brush)GetValue(TitleColorProperty);
        set => SetValue(TitleColorProperty, value);
    }

    public static new readonly DependencyProperty BackgroundProperty =
        Panel.BackgroundProperty.AddOwner(
            typeof(AuditCardControl),
            new FrameworkPropertyMetadata(Brushes.White));

    public new Brush Background
    {
        get => (Brush)GetValue(BackgroundProperty);
        set => SetValue(BackgroundProperty, value);
    }

    public static readonly DependencyProperty ContentTextProperty =
        DependencyProperty.Register(
            nameof(ContentText),
            typeof(string),
            typeof(AuditCardControl),
            new PropertyMetadata(string.Empty));

    public string ContentText
    {
        get => (string)GetValue(ContentTextProperty);
        set => SetValue(ContentTextProperty, value);
    }

    public static readonly DependencyProperty ContentColorProperty =
        DependencyProperty.Register(
            nameof(ContentColor),
            typeof(Brush),
            typeof(AuditCardControl),
            new PropertyMetadata(Brushes.Black));

    public Brush ContentColor
    {
        get => (Brush)GetValue(ContentColorProperty);
        set => SetValue(ContentColorProperty, value);
    }

    public static readonly DependencyProperty FooterTextProperty =
        DependencyProperty.Register(
            nameof(FooterText),
            typeof(string),
            typeof(AuditCardControl),
            new PropertyMetadata(string.Empty));

    public string FooterText
    {
        get => (string)GetValue(FooterTextProperty);
        set => SetValue(FooterTextProperty, value);
    }

    public static readonly DependencyProperty FooterColorProperty =
        DependencyProperty.Register(
            nameof(FooterColor),
            typeof(Brush),
            typeof(AuditCardControl),
            new PropertyMetadata(Brushes.Gray));

    public Brush FooterColor
    {
        get => (Brush)GetValue(FooterColorProperty);
        set => SetValue(FooterColorProperty, value);
    }
}
