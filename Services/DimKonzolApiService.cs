using System.Net.Http;
using System.Net.Http.Json;
using System.Net.Http.Headers;
using System.Text.Json;

namespace Dim.WPF.Shared.Library.Services;

/// <summary>
/// DimKonzol API service – kezeli a license, auth, Cégjelző proxy
/// és OpenAI proxy hívásokat a https://konzol.dimenzzio-kft.hu szerveren.
///
/// Használat:
///   1. Példányosítás (DI Singleton-ként javasolt)
///   2. LoginAsync() – JWT token megszerzése
///   3. License vagy proxy metódusok hívása
///
/// Token kezelés:
///   - Az access token lejáratakor automatikusan megújul a refresh tokennel.
///   - A refresh token perszisteálásához lásd: <see cref="GetRefreshToken"/> és
///     <see cref="LoadRefreshToken"/>.
/// </summary>
public class DimKonzolApiService
{
    private enum ApiAuthenticationMode
    {
        None,
        Bearer,
        DeviceToken,
        TenantContext
    }

    private static readonly JsonSerializerOptions JsonOptions = new()
    {
        PropertyNameCaseInsensitive = true
    };

    private readonly HttpClient _httpClient;
    private readonly HttpClient _aiHttpClient;
    private readonly int _tokenRefreshBufferSeconds;
    private readonly SemaphoreSlim _refreshLock = new(1, 1);

    private string? _accessToken;
    private string? _refreshToken;
    private string? _deviceToken;
    private DateTime _accessTokenExpiry = DateTime.MinValue;

    // ============================================================
    // Publikus állapot
    // ============================================================

    /// <summary>
    /// Minden sikeres ChatAsync hívás után elsüt, tartalmazza a felhasznált
    /// tokenek és az aktuális kvóta adatait. A <see cref="TokenUsageBanner"/>
    /// erre az eseményre feliratkozva automatikusan frissül.
    /// </summary>
    public event EventHandler<ChatCompletedEventArgs>? ChatCompleted;

    /// <summary>
    /// Akkor fut le, amikor a refresh token megváltozik vagy törlődik.
    /// A hívó ezt felhasználhatja a perzisztens tároló frissítésére.
    /// </summary>
    public event EventHandler<AuthTokensChangedEventArgs>? AuthTokensChanged;

    /// <summary>
    /// Igaz, ha az access token érvényes (bejelentkezve és nem járt le).
    /// </summary>
    public bool IsAuthenticated =>
        !string.IsNullOrEmpty(_accessToken) && DateTime.UtcNow < _accessTokenExpiry;

    /// <summary>
    /// Igaz, ha van tárolt refresh token (auto-refresh lehetséges).
    /// </summary>
    public bool HasRefreshToken => !string.IsNullOrEmpty(_refreshToken);

    /// <summary>
    /// Igaz, ha van tárolt device token (seat alapú desktop authentikáció).
    /// </summary>
    public bool HasDeviceToken => !string.IsNullOrEmpty(_deviceToken);

    /// <summary>
    /// Az aktuálisan bejelentkezett felhasználó adatai (login után töltődik fel).
    /// </summary>
    public AuthUserInfo? CurrentUser { get; private set; }

    // ============================================================
    // Konstruktor
    // ============================================================

    public DimKonzolApiService(DimKonzolApiOptions options)
    {
        _tokenRefreshBufferSeconds = options.TokenRefreshBufferSeconds;
        _httpClient = new HttpClient
        {
            BaseAddress = new Uri(options.BaseUrl),
            Timeout = TimeSpan.FromSeconds(options.TimeoutSeconds)
        };
        _httpClient.DefaultRequestHeaders.Add("X-API-Key", options.AppApiKey);
        _httpClient.DefaultRequestHeaders.Add("Accept", "application/json");

        _aiHttpClient = new HttpClient
        {
            BaseAddress = new Uri(options.BaseUrl),
            Timeout = TimeSpan.FromSeconds(options.AiTimeoutSeconds)
        };
        _aiHttpClient.DefaultRequestHeaders.Add("X-API-Key", options.AppApiKey);
        _aiHttpClient.DefaultRequestHeaders.Add("Accept", "application/json");
    }

    // ============================================================
    // Token perszisteálás (hívó oldal kezeli a tárolást)
    // ============================================================

    /// <summary>
    /// Visszaadja a jelenlegi refresh tokent, hogy a hívó el tudja menteni
    /// (pl. UserSettings-be) az alkalmazás újraindítása előtt.
    /// </summary>
    public string? GetRefreshToken() => _refreshToken;

    /// <summary>
    /// Visszaadja a jelenlegi device tokent, hogy a hívó el tudja menteni.
    /// </summary>
    public string? GetDeviceToken() => _deviceToken;

    /// <summary>
    /// Refresh token visszatöltése (pl. UserSettings-ből induláskor).
    /// Az access token auto-refresh az első védett híváskor indul meg.
    /// </summary>
    public void LoadRefreshToken(string refreshToken, AuthUserInfo? user = null)
    {
        _refreshToken = refreshToken;
        CurrentUser = user;
    }

    /// <summary>
    /// Device token visszatöltése (seat alapú login nélküli desktop authentikációhoz).
    /// </summary>
    public void LoadDeviceToken(string deviceToken)
    {
        _deviceToken = deviceToken;
    }

    // ============================================================
    // Authentikáció
    // ============================================================

    /// <summary>
    /// Felhasználó bejelentkeztetése email + jelszóval.
    /// Sikeres bejelentkezés után az access és refresh tokenek automatikusan tárolódnak.
    /// </summary>
    public async Task<DimKonzolApiResponse<AuthLoginData>?> LoginAsync(
        string email, string password)
    {
        var body = new { email, password };
        var response = await PostAsync<AuthLoginData>("api/v1/auth/login", body);

        if (response?.Success == true && response.Data != null)
        {
            StoreTokens(response.Data.AccessToken, response.Data.RefreshToken, response.Data.ExpiresIn);
            CurrentUser = response.Data.User;
        }

        return response;
    }

    /// <summary>
    /// Új felhasználói fiók regisztrálása.
    /// Sikeres regisztráció után email-megerősítés szükséges a bejelentkezéshez.
    /// </summary>
    public async Task<DimKonzolApiResponse<AuthRegisterData>?> RegisterAsync(
        string email,
        string password,
        string fullName,
        string? companyName = null,
        string? taxNumber = null,
        string? zipCode = null,
        string? city = null,
        string? street = null,
        string? houseNumber = null)
    {
        var body = new
        {
            email,
            password,
            full_name = fullName,
            company_name = companyName,
            tax_number = taxNumber,
            zip_code = zipCode,
            city,
            street,
            house_number = houseNumber
        };

        return await PostAsync<AuthRegisterData>("api/v1/auth/register", body);
    }

    /// <summary>
    /// Access token megújítása a tárolt refresh tokennel.
    /// Normál esetben ezt automatikusan kezeli a service; manuálisan ritkán szükséges.
    /// </summary>
    public async Task<DimKonzolApiResponse<AuthRefreshData>?> RefreshTokenAsync()
    {
        if (string.IsNullOrEmpty(_refreshToken))
            return null;

        var body = new { refresh_token = _refreshToken };
        var response = await PostAsync<AuthRefreshData>("api/v1/auth/refresh", body);

        if (response?.Success == true && response.Data != null)
            StoreTokens(response.Data.AccessToken, response.Data.RefreshToken, response.Data.ExpiresIn);

        return response;
    }

    /// <summary>
    /// Kijelentkezés – a refresh token visszavonása a szerveren.
    /// Az access token a TTL lejártáig érvényes marad (szerver oldali korlát).
    /// </summary>
    public async Task<DimKonzolApiResponse<object>?> LogoutAsync()
    {
        if (string.IsNullOrEmpty(_refreshToken))
            return null;

        var body = new { refresh_token = _refreshToken };
        var response = await PostAsync<object>("api/v1/auth/logout", body);
        ClearTokens();
        return response;
    }

    /// <summary>
    /// Seat aktiváló kód beváltása és device token igénylése.
    /// Sikeres hívás után a device token automatikusan eltárolódik a service-ben.
    /// </summary>
    public async Task<DimKonzolApiResponse<DeviceActivationClaimData>?> ClaimDeviceActivationAsync(
        string activationCode, string hardwareId, string? deviceName = null)
    {
        var body = new
        {
            activation_code = activationCode,
            hardware_id = hardwareId,
            device_name = deviceName
        };

        var response = await PostAsync<DeviceActivationClaimData>("api/v1/activation/claim", body);
        if (response?.Success == true && !string.IsNullOrWhiteSpace(response.Data?.DeviceToken))
            _deviceToken = response.Data.DeviceToken;

        return response;
    }

    /// <summary>
    /// A korábban kiadott device token ellenőrzése és a seat/licenc állapot lekérdezése.
    /// </summary>
    public async Task<DimKonzolApiResponse<DeviceValidationData>?> ValidateDeviceAsync(string hardwareId)
    {
        await EnsureDeviceTokenAsync();
        var body = new { hardware_id = hardwareId };
        return await PostAsync<DeviceValidationData>("api/v1/activation/validate-device", body, ApiAuthenticationMode.DeviceToken);
    }

    // ============================================================
    // License API
    // ============================================================

    /// <summary>
    /// Trial license kulcs kérése. Ha már létezik aktív trial, azt adja vissza.
    /// Lejárt vagy admin által deaktivált trial esetén 403-as hiba érkezik.
    /// </summary>
    public async Task<DimKonzolApiResponse<TrialRequestData>?> RequestTrialAsync(
        string email,
        string fullName,
        string? companyName = null,
        string? taxNumber = null)
    {
        var body = new
        {
            email,
            full_name = fullName,
            company_name = companyName,
            tax_number = taxNumber
        };

        return await PostAsync<TrialRequestData>("api/v1/trial/request", body);
    }

    /// <summary>
    /// License kulcs érvényességének ellenőrzése az adott hardveren.
    /// JWT ownership ellenőrzés: a token `sub` mezőjének egyeznie kell a license tulajdonosával.
    /// </summary>
    public async Task<DimKonzolApiResponse<LicenseValidateData>?> ValidateLicenseAsync(
        string licenseKey, string hardwareId)
    {
        await EnsureTenantContextAsync();
        var body = new { license_key = licenseKey, hardware_id = hardwareId };
        return await PostAsync<LicenseValidateData>("api/v1/license/validate", body, ApiAuthenticationMode.Bearer);
    }

    /// <summary>
    /// Gép aktiválása license kulccsal. Ha a gép már aktiválva van,
    /// csak frissíti a last_check_at időpontot.
    /// JWT ownership ellenőrzés: a token `sub` mezőjének egyeznie kell a license tulajdonosával.
    /// </summary>
    public async Task<DimKonzolApiResponse<LicenseActivateData>?> ActivateLicenseAsync(
        string licenseKey, string hardwareId, string? deviceName = null)
    {
        await EnsureValidTokenAsync();
        var body = new { license_key = licenseKey, hardware_id = hardwareId, device_name = deviceName };
        return await PostAsync<LicenseActivateData>("api/v1/license/activate", body, ApiAuthenticationMode.Bearer);
    }

    /// <summary>
    /// Gép deaktiválása és slot felszabadítása.
    /// Havi limit: 3 alkalom/hónap/license (admin által megkerülhető).
    /// JWT ownership ellenőrzés: a token `sub` mezőjének egyeznie kell a license tulajdonosával.
    /// </summary>
    public async Task<DimKonzolApiResponse<LicenseDeactivateData>?> DeactivateLicenseAsync(
        string licenseKey, string hardwareId)
    {
        await EnsureValidTokenAsync();
        var body = new { license_key = licenseKey, hardware_id = hardwareId };
        return await PostAsync<LicenseDeactivateData>("api/v1/license/deactivate", body, ApiAuthenticationMode.Bearer);
    }

    /// <summary>
    /// License-hez tartozó összes aktivált gép listázása.
    /// JWT ownership ellenőrzés: a token `sub` mezőjének egyeznie kell a license tulajdonosával.
    /// </summary>
    public async Task<DimKonzolApiResponse<DevicesData>?> GetDevicesAsync(string licenseKey)
    {
        await EnsureValidTokenAsync();
        return await GetAsync<DevicesData>(
            $"api/v1/license/{Uri.EscapeDataString(licenseKey)}/devices", ApiAuthenticationMode.Bearer);
    }

    // ============================================================
    // Cégjelző Proxy (JWT vagy X-Device-Token)
    // ============================================================

    /// <summary>
    /// Cég nevének / adószámának autocomplete-je a DimKonzol proxyn keresztül.
    /// Kvóta: 1 / cache miss, 0 / cache hit.
    /// </summary>
    /// <param name="search">Keresési kifejezés (min. 3 karakter)</param>
    public async Task<DimKonzolApiResponse<CegjelzoProxyAutocompleteData>?> CegjelzoAutocompleteAsync(
        string search,
        string? type = null,
        int? limit = null,
        int? page = null,
        bool? onlyActive = null)
    {
        await EnsureValidTokenAsync();

        var query = BuildQueryString(
            ("search", search),
            ("type", type),
            ("limit", limit?.ToString()),
            ("page", page?.ToString()),
            ("only-active", onlyActive.HasValue ? onlyActive.Value.ToString().ToLower() : null));

        return await GetAsync<CegjelzoProxyAutocompleteData>(
            $"api/v1/cegjelzo/autocomplete{query}", ApiAuthenticationMode.TenantContext);
    }

    /// <summary>
    /// Részletes cégkeresés (céginformáció + pénzügyi adatok) a DimKonzol proxyn keresztül.
    /// Kvóta: 1 / cache miss, 0 / cache hit.
    /// </summary>
    /// <param name="value">Keresési kifejezés – adószám, cégnév (min. 3 karakter)</param>
    /// <param name="forceRefresh">true = cache megkerülése, friss adat lekérése</param>
    public async Task<DimKonzolApiResponse<CegjelzoProxySearchData>?> CegjelzoSearchAsync(
        string value,
        string? type = null,
        int? limit = null,
        int? page = null,
        bool forceRefresh = false)
    {
        await EnsureTenantContextAsync();

        var query = BuildQueryString(
            ("value", value),
            ("type", type),
            ("limit", limit?.ToString()),
            ("page", page?.ToString()),
            ("force_refresh", forceRefresh ? "1" : null));

        return await GetAsync<CegjelzoProxySearchData>(
            $"api/v1/cegjelzo/search{query}", ApiAuthenticationMode.TenantContext);
    }

    /// <summary>
    /// A bejelentkezett felhasználó Cégjelző kvóta-felhasználásának lekérdezése.
    /// </summary>
    public async Task<DimKonzolApiResponse<CegjelzoUsageData>?> GetCegjelzoUsageAsync()
    {
        await EnsureTenantContextAsync();
        return await GetAsync<CegjelzoUsageData>("api/v1/cegjelzo/usage", ApiAuthenticationMode.TenantContext);
    }

    // ============================================================
    // OpenAI Proxy (JWT vagy X-Device-Token, kivéve ahol külön jelezve)
    // ============================================================

    /// <summary>
    /// Chat üzenet küldése az OpenAI felé a DimKonzol proxyn keresztül.
    /// A modell automatikusan a felhasználó beállítása alapján kerül kiválasztásra,
    /// de kérésenként felülbírálható.
    /// <b>Csak aktív OpenAI előfizetéssel használható.</b>
    /// A válasz tartalmazza a felhasznált tokenek részleteit (<c>data.usage</c>).
    /// </summary>
    /// <param name="messages">Üzenetek listája (role: "user" | "assistant")</param>
    /// <param name="systemPrompt">Opcionális rendszer utasítás</param>
    /// <param name="model">Opcionális modell felülírás csak az adott kérésre</param>
    public async Task<DimKonzolApiResponse<OpenAiChatData>?> ChatAsync(
        IEnumerable<DimKonzolChatMessage> messages,
        string? systemPrompt = null,
        string? model = null)
    {
        await EnsureTenantContextAsync();

        var body = new
        {
            messages,
            system_prompt = systemPrompt,
            model
        };

        using var request = new HttpRequestMessage(HttpMethod.Post, "api/v1/openai/chat")
        {
            Content = JsonContent.Create(body)
        };
        SetAuthenticationHeader(request, ApiAuthenticationMode.TenantContext);

        var httpResponse = await _aiHttpClient.SendAsync(request);
        var response = await DeserializeResponseAsync<OpenAiChatData>(httpResponse);

        RaiseChatCompleted(response?.Data?.Usage, response?.Data?.Quota);

        return response;
    }

    /// <summary>
    /// Chat üzenet küldése az OpenAI felé fájlcsatolmányokkal a DimKonzol proxyn keresztül.
    /// A fájlok multipart/form-data formában kerülnek továbbításra.
    /// </summary>
    public async Task<DimKonzolApiResponse<OpenAiChatWithFilesData>?> ChatWithFilesAsync(
        IEnumerable<DimKonzolChatMessage> messages,
        IEnumerable<DimKonzolFileAttachment> files,
        string? systemPrompt = null,
        string? model = null)
    {
        await EnsureTenantContextAsync();

        ArgumentNullException.ThrowIfNull(messages);
        ArgumentNullException.ThrowIfNull(files);

        var attachmentList = files.Where(file => file is not null).ToList();
        if (attachmentList.Count == 0)
            throw new ArgumentException("Legalább egy fájl csatolása kötelező.", nameof(files));

        using var multipart = new MultipartFormDataContent();
        multipart.Add(new StringContent(JsonSerializer.Serialize(messages, JsonOptions)), "messages");

        if (!string.IsNullOrWhiteSpace(systemPrompt))
            multipart.Add(new StringContent(systemPrompt), "system_prompt");

        if (!string.IsNullOrWhiteSpace(model))
            multipart.Add(new StringContent(model), "model");

        foreach (var file in attachmentList)
        {
            if (string.IsNullOrWhiteSpace(file.FileName))
                throw new ArgumentException("A csatolt fájl neve kötelező.", nameof(files));

            var content = new ByteArrayContent(file.Content ?? []);
            if (!string.IsNullOrWhiteSpace(file.MediaType))
                content.Headers.ContentType = MediaTypeHeaderValue.Parse(file.MediaType);

            multipart.Add(content, "files[]", file.FileName);
        }

        using var request = new HttpRequestMessage(HttpMethod.Post, "api/v1/openai/chat-with-files")
        {
            Content = multipart
        };
        SetAuthenticationHeader(request, ApiAuthenticationMode.TenantContext);

        var httpResponse = await _aiHttpClient.SendAsync(request);
        var response = await DeserializeResponseAsync<OpenAiChatWithFilesData>(httpResponse);

        RaiseChatCompleted(response?.Data?.Usage, response?.Data?.Quota);

        return response;
    }

    /// <summary>
    /// LiveCharts-kompatibilis grafikon specifikáció generálása OpenAI Structured Outputs használatával.
    /// </summary>
    public async Task<DimKonzolApiResponse<OpenAiGenerateChartSpecData>?> GenerateChartSpecAsync(
        string prompt,
        object? data = null,
        string? chartTypeHint = null,
        string? systemPrompt = null,
        string? model = null)
    {
        await EnsureTenantContextAsync();

        var body = new
        {
            prompt,
            data,
            chart_type_hint = chartTypeHint,
            system_prompt = systemPrompt,
            model
        };

        using var request = new HttpRequestMessage(HttpMethod.Post, "api/v1/openai/generate-chart-spec")
        {
            Content = JsonContent.Create(body)
        };
        SetAuthenticationHeader(request, ApiAuthenticationMode.TenantContext);

        var httpResponse = await _aiHttpClient.SendAsync(request);
        var response = await DeserializeResponseAsync<OpenAiGenerateChartSpecData>(httpResponse);

        RaiseChatCompleted(response?.Data?.Usage, response?.Data?.Quota);

        return response;
    }

    /// <summary>
    /// Egyetlen számlafájl strukturált feldolgozása fix JSON sémára.
    /// Opcionálisan OCR segédszöveg és kérésenkénti modell felülírás is küldhető.
    /// </summary>
    public async Task<DimKonzolApiResponse<OpenAiProcessInvoiceData>?> ProcessInvoiceAsync(
        DimKonzolFileAttachment file,
        string? ocrText = null,
        string? model = null)
    {
        await EnsureTenantContextAsync();

        ArgumentNullException.ThrowIfNull(file);
        if (string.IsNullOrWhiteSpace(file.FileName))
            throw new ArgumentException("A számlafájl neve kötelező.", nameof(file));

        using var multipart = new MultipartFormDataContent();

        var fileContent = new ByteArrayContent(file.Content ?? []);
        if (!string.IsNullOrWhiteSpace(file.MediaType))
            fileContent.Headers.ContentType = MediaTypeHeaderValue.Parse(file.MediaType);

        multipart.Add(fileContent, "file", file.FileName);

        if (!string.IsNullOrWhiteSpace(ocrText))
            multipart.Add(new StringContent(ocrText), "ocr_text");

        if (!string.IsNullOrWhiteSpace(model))
            multipart.Add(new StringContent(model), "model");

        using var request = new HttpRequestMessage(HttpMethod.Post, "api/v1/openai/process-invoice")
        {
            Content = multipart
        };
        SetAuthenticationHeader(request, ApiAuthenticationMode.TenantContext);

        var httpResponse = await _aiHttpClient.SendAsync(request);
        var response = await DeserializeResponseAsync<OpenAiProcessInvoiceData>(httpResponse);

        RaiseChatCompleted(response?.Data?.Usage, response?.Data?.Quota);

        return response;
    }

    /// <summary>
    /// Egyetlen dokumentum könyvelési osztályozása fix JSON sémára.
    /// </summary>
    public async Task<DimKonzolApiResponse<OpenAiClassifyAccountingDocumentData>?> ClassifyAccountingDocumentAsync(
        DimKonzolFileAttachment file,
        string? ocrText = null,
        string? context = null,
        string? ownCompanyName = null,
        string? ownCompanyTaxNumber = null,
        string? ownCompanyRegistrationNumber = null,
        string? model = null)
    {
        await EnsureTenantContextAsync();

        ArgumentNullException.ThrowIfNull(file);
        if (string.IsNullOrWhiteSpace(file.FileName))
            throw new ArgumentException("A dokumentumfájl neve kötelező.", nameof(file));

        using var multipart = new MultipartFormDataContent();

        var fileContent = new ByteArrayContent(file.Content ?? []);
        if (!string.IsNullOrWhiteSpace(file.MediaType))
            fileContent.Headers.ContentType = MediaTypeHeaderValue.Parse(file.MediaType);

        multipart.Add(fileContent, "file", file.FileName);

        if (!string.IsNullOrWhiteSpace(ocrText))
            multipart.Add(new StringContent(ocrText), "ocr_text");

        if (!string.IsNullOrWhiteSpace(context))
            multipart.Add(new StringContent(context), "context");

        if (!string.IsNullOrWhiteSpace(ownCompanyName))
            multipart.Add(new StringContent(ownCompanyName), "own_company_name");

        if (!string.IsNullOrWhiteSpace(ownCompanyTaxNumber))
            multipart.Add(new StringContent(ownCompanyTaxNumber), "own_company_tax_number");

        if (!string.IsNullOrWhiteSpace(ownCompanyRegistrationNumber))
            multipart.Add(new StringContent(ownCompanyRegistrationNumber), "own_company_registration_number");

        if (!string.IsNullOrWhiteSpace(model))
            multipart.Add(new StringContent(model), "model");

        using var request = new HttpRequestMessage(HttpMethod.Post, "api/v1/openai/classify-accounting-document")
        {
            Content = multipart
        };
        SetAuthenticationHeader(request, ApiAuthenticationMode.TenantContext);

        var httpResponse = await _aiHttpClient.SendAsync(request);
        var response = await DeserializeResponseAsync<OpenAiClassifyAccountingDocumentData>(httpResponse);

        RaiseChatCompleted(response?.Data?.Usage, response?.Data?.Quota);

        return response;
    }

    /// <summary>
    /// Bankszámlakivonat strukturált feldolgozása fix JSON sémára.
    /// </summary>
    public async Task<DimKonzolApiResponse<OpenAiProcessBankStatementData>?> ProcessBankStatementAsync(
        DimKonzolFileAttachment file,
        string? ocrText = null,
        string? ownCompanyName = null,
        string? ownCompanyTaxNumber = null,
        string? model = null)
    {
        await EnsureTenantContextAsync();

        ArgumentNullException.ThrowIfNull(file);
        if (string.IsNullOrWhiteSpace(file.FileName))
            throw new ArgumentException("A bankszámlakivonat fájlneve kötelező.", nameof(file));

        using var multipart = new MultipartFormDataContent();

        var fileContent = new ByteArrayContent(file.Content ?? []);
        if (!string.IsNullOrWhiteSpace(file.MediaType))
            fileContent.Headers.ContentType = MediaTypeHeaderValue.Parse(file.MediaType);

        multipart.Add(fileContent, "file", file.FileName);

        if (!string.IsNullOrWhiteSpace(ocrText))
            multipart.Add(new StringContent(ocrText), "ocr_text");

        if (!string.IsNullOrWhiteSpace(ownCompanyName))
            multipart.Add(new StringContent(ownCompanyName), "own_company_name");

        if (!string.IsNullOrWhiteSpace(ownCompanyTaxNumber))
            multipart.Add(new StringContent(ownCompanyTaxNumber), "own_company_tax_number");

        if (!string.IsNullOrWhiteSpace(model))
            multipart.Add(new StringContent(model), "model");

        using var request = new HttpRequestMessage(HttpMethod.Post, "api/v1/openai/process-bank-statement")
        {
            Content = multipart
        };
        SetAuthenticationHeader(request, ApiAuthenticationMode.TenantContext);

        var httpResponse = await _aiHttpClient.SendAsync(request);
        var response = await DeserializeResponseAsync<OpenAiProcessBankStatementData>(httpResponse);

        RaiseChatCompleted(response?.Data?.Usage, response?.Data?.Quota);

        return response;
    }

    /// <summary>
    /// Az aktuálisan érvényes OpenAI modell beállítás lekérdezése.
    /// </summary>
    public async Task<DimKonzolApiResponse<OpenAiSettingsData>?> GetOpenAiSettingsAsync()
    {
        await EnsureTenantContextAsync();
        return await GetAsync<OpenAiSettingsData>("api/v1/openai/settings", ApiAuthenticationMode.TenantContext);
    }

    /// <summary>
    /// OpenAI modell beállítása. <c>null</c> értékkel visszaáll a szerver alapértelmezettjére.
    /// </summary>
    public async Task<DimKonzolApiResponse<OpenAiSettingsData>?> UpdateOpenAiSettingsAsync(string? model)
    {
        await EnsureValidTokenAsync();
        var body = new { model };
        return await PutAsync<OpenAiSettingsData>("api/v1/openai/settings", body, ApiAuthenticationMode.Bearer);
    }

    /// <summary>
    /// A bejelentkezett felhasználó összesített OpenAI token-felhasználásának lekérdezése.
    /// <b>Csak aktív OpenAI előfizetéssel használható.</b>
    /// Visszaadja az összes kérés számát, a felhasznált tokeneket és modellenként bontva a statisztikákat.
    /// </summary>
    public async Task<DimKonzolApiResponse<OpenAiUsageData>?> GetOpenAiUsageAsync()
    {
        await EnsureTenantContextAsync();
        return await GetAsync<OpenAiUsageData>("api/v1/openai/usage", ApiAuthenticationMode.TenantContext);
    }

    // ============================================================
    // Privát segédmetódusok
    // ============================================================

    /// <summary>
    /// Biztosítja, hogy érvényes access token álljon rendelkezésre.
    /// Automatikusan megújítja a refresh tokennel, ha lejárt.
    /// </summary>
    private async Task EnsureValidTokenAsync()
    {
        if (IsAuthenticated) return;

        if (!HasRefreshToken)
            throw new InvalidOperationException(
                "Nincs bejelentkezve. A DimKonzol proxy használatához először be kell jelentkezni.");

        await _refreshLock.WaitAsync();
        try
        {
            if (IsAuthenticated) return;

            var result = await RefreshTokenAsync();
            if (result?.Success != true)
                throw new InvalidOperationException(
                    "A munkamenet lejárt. Kérjük, jelentkezzen be újra.");
        }
        finally
        {
            _refreshLock.Release();
        }
    }

    private async Task EnsureTenantContextAsync()
    {
        if (HasDeviceToken)
            return;

        await EnsureValidTokenAsync();
    }

    private Task EnsureDeviceTokenAsync()
    {
        if (HasDeviceToken)
            return Task.CompletedTask;

        throw new InvalidOperationException(
            "Nincs device token betöltve. Seat alapú hívások előtt aktiválni kell az eszközt vagy vissza kell tölteni a tárolt device tokent.");
    }

    private async Task<DimKonzolApiResponse<T>?> GetAsync<T>(
        string url, ApiAuthenticationMode authenticationMode = ApiAuthenticationMode.None)
    {
        using var request = new HttpRequestMessage(HttpMethod.Get, url);
        SetAuthenticationHeader(request, authenticationMode);

        var httpResponse = await _httpClient.SendAsync(request);
        return await DeserializeResponseAsync<T>(httpResponse);
    }

    private async Task<DimKonzolApiResponse<T>?> PostAsync<T>(
        string url, object body, ApiAuthenticationMode authenticationMode = ApiAuthenticationMode.None)
    {
        using var request = new HttpRequestMessage(HttpMethod.Post, url)
        {
            Content = JsonContent.Create(body)
        };
        SetAuthenticationHeader(request, authenticationMode);

        var httpResponse = await _httpClient.SendAsync(request);
        return await DeserializeResponseAsync<T>(httpResponse);
    }

    private async Task<DimKonzolApiResponse<T>?> PutAsync<T>(
        string url, object body, ApiAuthenticationMode authenticationMode = ApiAuthenticationMode.None)
    {
        using var request = new HttpRequestMessage(HttpMethod.Put, url)
        {
            Content = JsonContent.Create(body)
        };
        SetAuthenticationHeader(request, authenticationMode);

        var httpResponse = await _httpClient.SendAsync(request);
        return await DeserializeResponseAsync<T>(httpResponse);
    }

    private void SetAuthenticationHeader(HttpRequestMessage request, ApiAuthenticationMode authenticationMode)
    {
        switch (authenticationMode)
        {
            case ApiAuthenticationMode.None:
                return;

            case ApiAuthenticationMode.Bearer:
                if (string.IsNullOrEmpty(_accessToken))
                    throw new InvalidOperationException("Nincs érvényes access token a kéréshez.");

                request.Headers.Authorization =
                    new AuthenticationHeaderValue("Bearer", _accessToken);
                return;

            case ApiAuthenticationMode.DeviceToken:
                if (string.IsNullOrEmpty(_deviceToken))
                    throw new InvalidOperationException("Nincs device token a kéréshez.");

                request.Headers.Add("X-Device-Token", _deviceToken);
                return;

            case ApiAuthenticationMode.TenantContext:
                if (!string.IsNullOrEmpty(_accessToken))
                {
                    request.Headers.Authorization =
                        new AuthenticationHeaderValue("Bearer", _accessToken);
                    return;
                }

                if (!string.IsNullOrEmpty(_deviceToken))
                {
                    request.Headers.Add("X-Device-Token", _deviceToken);
                    return;
                }

                throw new InvalidOperationException("Nincs elérhető tenant kontextus a kéréshez.");

            default:
                throw new ArgumentOutOfRangeException(nameof(authenticationMode), authenticationMode, null);
        }
    }

    private static async Task<DimKonzolApiResponse<T>?> DeserializeResponseAsync<T>(
        HttpResponseMessage httpResponse)
    {
        var content = await httpResponse.Content.ReadAsStringAsync();
        if (string.IsNullOrWhiteSpace(content)) return null;

        return JsonSerializer.Deserialize<DimKonzolApiResponse<T>>(content, JsonOptions);
    }

    /// <summary>
    /// Query string összeállítása, null értékű paraméterek kihagyásával.
    /// </summary>
    private static string BuildQueryString(params (string key, string? value)[] parameters)
    {
        var parts = parameters
            .Where(p => p.value != null)
            .Select(p => $"{p.key}={Uri.EscapeDataString(p.value!)}");

        var qs = string.Join("&", parts);
        return qs.Length > 0 ? "?" + qs : string.Empty;
    }

    private void RaiseChatCompleted(OpenAiUsageInfo? usage, OpenAiQuotaInfo? quota)
    {
        if (usage is null && quota is null)
            return;

        ChatCompleted?.Invoke(this, new ChatCompletedEventArgs
        {
            Usage = usage,
            Quota = quota
        });
    }

    private void StoreTokens(string accessToken, string refreshToken, int expiresInSeconds)
    {
        _accessToken = accessToken;
        _refreshToken = refreshToken;
        _accessTokenExpiry = DateTime.UtcNow.AddSeconds(expiresInSeconds - _tokenRefreshBufferSeconds);
        AuthTokensChanged?.Invoke(this, new AuthTokensChangedEventArgs
        {
            RefreshToken = _refreshToken,
            UserEmail = CurrentUser?.Email
        });
    }

    private void ClearTokens()
    {
        _accessToken = null;
        _refreshToken = null;
        _accessTokenExpiry = DateTime.MinValue;
        CurrentUser = null;
        AuthTokensChanged?.Invoke(this, new AuthTokensChangedEventArgs());
    }
}
