namespace Dim.WPF.Shared.Library.Services;

/// <summary>
/// Konfigurációs beállítások a <see cref="DimKonzolApiService"/> számára.
/// DI-n keresztül adandó át (pl. az alkalmazás AppConfig értékeiből töltve fel).
/// </summary>
public class DimKonzolApiOptions
{
    /// <summary>DimKonzol szerver alap URL-je.</summary>
    public string BaseUrl { get; set; } = string.Empty;

    /// <summary>Az alkalmazás API kulcsa a DimKonzol szerveren.</summary>
    public string AppApiKey { get; set; } = string.Empty;

    /// <summary>HTTP kérések timeout értéke másodpercekben.</summary>
    public int TimeoutSeconds { get; set; } = 30;

    /// <summary>AI (OpenAI proxy) kérések timeout értéke másodpercekben.</summary>
    public int AiTimeoutSeconds { get; set; } = 120;

    /// <summary>
    /// Access token korai megújításának határa: ennyi másodperccel a tényleges lejárat
    /// előtt tekintjük lejártnak, hogy elkerüljük az éles lejárat körüli race condition-t.
    /// </summary>
    public int TokenRefreshBufferSeconds { get; set; } = 60;
}
