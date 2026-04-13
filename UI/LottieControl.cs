using System;
using System.IO;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Threading;
using SkiaSharp;
using SkiaSharp.Skottie;
using SkiaSharp.Views.Desktop;
using SkiaSharp.Views.WPF;

namespace Dim.WPF.Shared.Library.UI
{
    public class LottieControl : FrameworkElement
    {
        private Animation? _animation;
        private readonly DispatcherTimer _timer;
        private DateTime _startTime;
        private WriteableBitmap? _bitmap;
        private bool _isLoaded;

        public static readonly DependencyProperty SourceProperty =
            DependencyProperty.Register(
                nameof(Source),
                typeof(string),
                typeof(LottieControl),
                new PropertyMetadata(null, OnSourceChanged));

        public static readonly DependencyProperty IsPlayingProperty =
            DependencyProperty.Register(
                nameof(IsPlaying),
                typeof(bool),
                typeof(LottieControl),
                new PropertyMetadata(true, OnIsPlayingChanged));

        public static readonly DependencyProperty RepeatCountProperty =
            DependencyProperty.Register(
                nameof(RepeatCount),
                typeof(int),
                typeof(LottieControl),
                new PropertyMetadata(-1));

        public static readonly DependencyProperty RepeatDelayMillisecondsProperty =
            DependencyProperty.Register(
                nameof(RepeatDelayMilliseconds),
                typeof(int),
                typeof(LottieControl),
                new PropertyMetadata(0));

        public string? Source
        {
            get => (string?)GetValue(SourceProperty);
            set => SetValue(SourceProperty, value);
        }

        public bool IsPlaying
        {
            get => (bool)GetValue(IsPlayingProperty);
            set => SetValue(IsPlayingProperty, value);
        }

        public int RepeatCount
        {
            get => (int)GetValue(RepeatCountProperty);
            set => SetValue(RepeatCountProperty, value);
        }

        public int RepeatDelayMilliseconds
        {
            get => (int)GetValue(RepeatDelayMillisecondsProperty);
            set => SetValue(RepeatDelayMillisecondsProperty, value);
        }

        public LottieControl()
        {
            _timer = new DispatcherTimer
            {
                Interval = TimeSpan.FromMilliseconds(1000.0 / 60.0) // 60 FPS
            };
            _timer.Tick += OnTimerTick;

            Loaded += OnLoaded;
            Unloaded += OnUnloaded;
        }

        private void OnLoaded(object sender, RoutedEventArgs e)
        {
            _isLoaded = true;
            LoadAnimation();
        }

        private void OnUnloaded(object sender, RoutedEventArgs e)
        {
            _isLoaded = false;
            _timer.Stop();
        }

        private static void OnSourceChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is LottieControl control)
            {
                control.LoadAnimation();
            }
        }

        private static void OnIsPlayingChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is LottieControl control)
            {
                if ((bool)e.NewValue)
                    control.Play();
                else
                    control.Pause();
            }
        }

        private void LoadAnimation()
        {
            if (!_isLoaded || string.IsNullOrEmpty(Source))
                return;

            try
            {
                string jsonPath = Source;
                if (Uri.TryCreate(jsonPath, UriKind.Absolute, out var absoluteUri) && absoluteUri.Scheme == "pack")
                {
                    var streamInfo = Application.GetResourceStream(absoluteUri);
                    if (streamInfo != null)
                    {
                        using var reader = new StreamReader(streamInfo.Stream);
                        var json = reader.ReadToEnd();
                        _animation = Animation.Parse(json);
                    }
                }
                else if (!Path.IsPathRooted(jsonPath))
                {
                    // Relatív útvonal kezelése
                    var uri = new Uri($"pack://application:,,,/{jsonPath}");
                    var streamInfo = Application.GetResourceStream(uri);
                    if (streamInfo != null)
                    {
                        using var reader = new StreamReader(streamInfo.Stream);
                        var json = reader.ReadToEnd();
                        _animation = Animation.Parse(json);
                    }
                }
                else
                {
                    // Abszolút útvonal
                    var json = File.ReadAllText(jsonPath);
                    _animation = Animation.Parse(json);
                }

                if (_animation != null && IsPlaying)
                {
                    Play();
                }

                InvalidateVisual();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Failed to load Lottie animation: {ex.Message}");
            }
        }

        public void Play()
        {
            if (_animation == null || !_isLoaded)
                return;

            _startTime = DateTime.Now;
            _timer.Start();
        }

        public void Pause()
        {
            _timer.Stop();
        }

        private void OnTimerTick(object? sender, EventArgs e)
        {
            InvalidateVisual();
        }

        protected override void OnRender(DrawingContext drawingContext)
        {
            base.OnRender(drawingContext);

            if (_animation == null || ActualWidth == 0 || ActualHeight == 0)
                return;

            var width = (int)ActualWidth;
            var height = (int)ActualHeight;

            if (_bitmap == null || _bitmap.PixelWidth != width || _bitmap.PixelHeight != height)
            {
                _bitmap = new WriteableBitmap(width, height, 96, 96, PixelFormats.Pbgra32, null);
            }

            _bitmap.Lock();

            try
            {
                var info = new SKImageInfo(width, height, SKColorType.Bgra8888, SKAlphaType.Premul);
                using var surface = SKSurface.Create(info, _bitmap.BackBuffer, _bitmap.BackBufferStride);
                var canvas = surface.Canvas;

                canvas.Clear(SKColors.Transparent);

                // Számítsuk ki az animáció progresszióját
                var elapsed = (DateTime.Now - _startTime).TotalSeconds;
                var duration = _animation.Duration.TotalSeconds;
                if (duration <= 0)
                    return;

                var repeatDelaySeconds = Math.Max(0, RepeatDelayMilliseconds) / 1000.0;
                var cycleDuration = duration + repeatDelaySeconds;
                var cyclePosition = cycleDuration > 0 ? elapsed % cycleDuration : 0;
                var progress = cyclePosition >= duration
                    ? 0
                    : cyclePosition / duration;

                // Rajzoljuk ki az animációt
                _animation.SeekFrameTime(progress * _animation.Duration.TotalSeconds);
                _animation.Render(canvas, new SKRect(0, 0, width, height));
            }
            finally
            {
                _bitmap.AddDirtyRect(new Int32Rect(0, 0, width, height));
                _bitmap.Unlock();
            }

            drawingContext.DrawImage(_bitmap, new Rect(0, 0, ActualWidth, ActualHeight));
        }
    }
}
