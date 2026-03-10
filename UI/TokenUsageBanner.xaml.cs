using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using Dim.WPF.Shared.Library.Services;

namespace Dim.WPF.Shared.Library.UI;

/// <summary>
/// Belső ViewModel a <see cref="TokenUsageBanner"/> számára.
/// </summary>
public class TokenUsageBannerViewModel : INotifyPropertyChanged
{
    public event PropertyChangedEventHandler? PropertyChanged;

    private void Notify([CallerMemberName] string? name = null)
        => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));

    private int _quotaTotal;
    public int QuotaTotal
    {
        get => _quotaTotal;
        set
        {
            _quotaTotal = value;
            Notify();
            Notify(nameof(HasQuotaData));
            Notify(nameof(QuotaRemainingPercent));
        }
    }

    private int _quotaUsed;
    public int QuotaUsed
    {
        get => _quotaUsed;
        set { _quotaUsed = value; Notify(); Notify(nameof(QuotaRemainingPercent)); }
    }

    private int _quotaRemaining;
    public int QuotaRemaining
    {
        get => _quotaRemaining;
        set { _quotaRemaining = value; Notify(); Notify(nameof(QuotaRemainingPercent)); }
    }

    private bool _hasNoSubscription;
    public bool HasNoSubscription
    {
        get => _hasNoSubscription;
        set { _hasNoSubscription = value; Notify(); }
    }

    private bool _isLoading;
    public bool IsLoading
    {
        get => _isLoading;
        set { _isLoading = value; Notify(); }
    }

    public bool HasQuotaData => QuotaTotal > 0;
    public double QuotaRemainingPercent => QuotaTotal > 0 ? (double)QuotaRemaining / QuotaTotal * 100.0 : 0;

    internal void Apply(OpenAiQuotaInfo quota)
    {
        QuotaTotal = quota.Total ?? 0;
        QuotaUsed = quota.Used ?? 0;
        QuotaRemaining = quota.Remaining ?? 0;
        HasNoSubscription = false;
    }
}

/// <summary>
/// Újrafelhasználható OpenAI token kvóta banner.
/// Elhelyezhető bármely ablak fejlécében, amely DimKonzol AI funkciókat használ.
///
/// Használat XAML-ben:
/// <code>
///   &lt;ui:TokenUsageBanner ApiService="{Binding ApiService}" /&gt;
/// </code>
///
/// Az <see cref="ApiService"/> beállítása után a banner:
///   1. Automatikusan betölti a kvóta adatokat.
///   2. Minden ChatAsync hívás után automatikusan frissíti a megjelenített adatokat.
/// </summary>
public partial class TokenUsageBanner : UserControl
{
    public TokenUsageBannerViewModel ViewModel { get; } = new();

    public TokenUsageBanner()
    {
        InitializeComponent();
        RootPanel.DataContext = ViewModel;

        if (DesignerProperties.GetIsInDesignMode(this))
        {
            ViewModel.QuotaTotal = 100_000;
            ViewModel.QuotaUsed = 34_200;
            ViewModel.QuotaRemaining = 65_800;
        }
    }

    // ── ApiService DependencyProperty ─────────────────────────────────────

    public static readonly DependencyProperty ApiServiceProperty =
        DependencyProperty.Register(
            nameof(ApiService),
            typeof(DimKonzolApiService),
            typeof(TokenUsageBanner),
            new PropertyMetadata(null, OnApiServiceChanged));

    public DimKonzolApiService? ApiService
    {
        get => (DimKonzolApiService?)GetValue(ApiServiceProperty);
        set => SetValue(ApiServiceProperty, value);
    }

    private static void OnApiServiceChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
        var banner = (TokenUsageBanner)d;

        if (e.OldValue is DimKonzolApiService old)
            old.ChatCompleted -= banner.OnChatCompleted;

        if (e.NewValue is DimKonzolApiService service)
        {
            service.ChatCompleted += banner.OnChatCompleted;
            _ = banner.LoadUsageAsync(service);
        }
    }

    // ── Chat event handler ─────────────────────────────────────────────────

    private void OnChatCompleted(object? sender, ChatCompletedEventArgs e)
    {
        if (e.Quota == null) return;
        Dispatcher.Invoke(() => ViewModel.Apply(e.Quota));
    }

    // ── Kvóta betöltés ─────────────────────────────────────────────────────

    private async Task LoadUsageAsync(DimKonzolApiService service)
    {
        ViewModel.IsLoading = true;
        try
        {
            var response = await service.GetOpenAiUsageAsync();
            if (response?.Success == true && response.Data != null)
            {
                var data = response.Data;
                if (data.Quota?.NoSubscription == true)
                {
                    ViewModel.HasNoSubscription = true;
                    return;
                }
                if (data.Quota != null)
                    ViewModel.Apply(data.Quota);
            }
            else if (response != null && !response.Success)
            {
                ViewModel.HasNoSubscription = true;
            }
        }
        catch { }
        finally
        {
            ViewModel.IsLoading = false;
        }
    }
}
