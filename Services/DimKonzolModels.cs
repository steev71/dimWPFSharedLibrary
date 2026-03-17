using System.Text.Json;
using System.Text.Json.Serialization;

namespace Dim.WPF.Shared.Library.Services;

// ============================================================
// Generikus API burkoló
// ============================================================

public class DimKonzolApiResponse<T>
{
    [JsonPropertyName("success")]
    public bool Success { get; set; }

    [JsonPropertyName("message")]
    public string? Message { get; set; }

    [JsonPropertyName("data")]
    public T? Data { get; set; }

    [JsonPropertyName("error")]
    public DimKonzolApiError? Error { get; set; }
}

public class DimKonzolApiError
{
    [JsonPropertyName("type")]
    public string? Type { get; set; }

    [JsonPropertyName("code")]
    public int Code { get; set; }
}

// ============================================================
// License modellek
// ============================================================

public class TrialRequestData
{
    [JsonPropertyName("license_key")]
    public string LicenseKey { get; set; } = string.Empty;

    [JsonPropertyName("license_type")]
    public string LicenseType { get; set; } = string.Empty;

    [JsonPropertyName("valid_from")]
    public string ValidFrom { get; set; } = string.Empty;

    [JsonPropertyName("valid_until")]
    public string ValidUntil { get; set; } = string.Empty;

    [JsonPropertyName("trial_days")]
    public int TrialDays { get; set; }

    [JsonPropertyName("max_devices")]
    public int MaxDevices { get; set; }

    [JsonPropertyName("is_active")]
    public bool? IsActive { get; set; }
}

public class LicenseValidateData
{
    [JsonPropertyName("valid")]
    public bool Valid { get; set; }

    [JsonPropertyName("license")]
    public LicenseInfo? License { get; set; }

    [JsonPropertyName("device")]
    public DeviceStatus? Device { get; set; }

    [JsonPropertyName("user")]
    public LicenseUserInfo? User { get; set; }
}

public class LicenseInfo
{
    [JsonPropertyName("key")]
    public string Key { get; set; } = string.Empty;

    [JsonPropertyName("type")]
    public string Type { get; set; } = string.Empty;

    [JsonPropertyName("valid_from")]
    public string ValidFrom { get; set; } = string.Empty;

    [JsonPropertyName("valid_until")]
    public string ValidUntil { get; set; } = string.Empty;

    [JsonPropertyName("max_devices")]
    public int MaxDevices { get; set; }

    [JsonPropertyName("activated_devices_count")]
    public int ActivatedDevicesCount { get; set; }

    [JsonPropertyName("has_available_slot")]
    public bool? HasAvailableSlot { get; set; }
}

public class DeviceStatus
{
    [JsonPropertyName("is_activated")]
    public bool IsActivated { get; set; }

    [JsonPropertyName("requires_activation")]
    public bool RequiresActivation { get; set; }
}

public class LicenseUserInfo
{
    [JsonPropertyName("email_verified")]
    public bool EmailVerified { get; set; }
}

public class LicenseActivateData
{
    [JsonPropertyName("activated")]
    public bool Activated { get; set; }

    [JsonPropertyName("message")]
    public string? Message { get; set; }

    [JsonPropertyName("license")]
    public LicenseInfo? License { get; set; }
}

public class LicenseDeactivateData
{
    [JsonPropertyName("deactivated")]
    public bool Deactivated { get; set; }

    [JsonPropertyName("activated_devices_count")]
    public int ActivatedDevicesCount { get; set; }
}

public class DevicesData
{
    [JsonPropertyName("license_key")]
    public string LicenseKey { get; set; } = string.Empty;

    [JsonPropertyName("max_devices")]
    public int MaxDevices { get; set; }

    [JsonPropertyName("devices")]
    public List<ActivatedDeviceInfo> Devices { get; set; } = [];

    [JsonPropertyName("count")]
    public int Count { get; set; }
}

public class ActivatedDeviceInfo
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    [JsonPropertyName("hardware_id")]
    public string HardwareId { get; set; } = string.Empty;

    [JsonPropertyName("device_name")]
    public string? DeviceName { get; set; }

    [JsonPropertyName("activated_at")]
    public string ActivatedAt { get; set; } = string.Empty;

    [JsonPropertyName("last_check_at")]
    public string LastCheckAt { get; set; } = string.Empty;
}

// ============================================================
// Auth modellek
// ============================================================

public class AuthRegisterData
{
    [JsonPropertyName("user")]
    public AuthUserInfo? User { get; set; }
}

public class AuthLoginData
{
    [JsonPropertyName("access_token")]
    public string AccessToken { get; set; } = string.Empty;

    [JsonPropertyName("refresh_token")]
    public string RefreshToken { get; set; } = string.Empty;

    [JsonPropertyName("token_type")]
    public string TokenType { get; set; } = string.Empty;

    [JsonPropertyName("expires_in")]
    public int ExpiresIn { get; set; }

    [JsonPropertyName("user")]
    public AuthUserInfo? User { get; set; }
}

public class AuthRefreshData
{
    [JsonPropertyName("access_token")]
    public string AccessToken { get; set; } = string.Empty;

    [JsonPropertyName("refresh_token")]
    public string RefreshToken { get; set; } = string.Empty;

    [JsonPropertyName("token_type")]
    public string TokenType { get; set; } = string.Empty;

    [JsonPropertyName("expires_in")]
    public int ExpiresIn { get; set; }
}

public class AuthUserInfo
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    [JsonPropertyName("email")]
    public string Email { get; set; } = string.Empty;

    [JsonPropertyName("full_name")]
    public string FullName { get; set; } = string.Empty;

    [JsonPropertyName("user_type")]
    public string? UserType { get; set; }
}

// ============================================================
// Cégjelző proxy modellek
// ============================================================

/// <summary>
/// A company_data és financials_data mezők raw JSON-ként tárolódnak,
/// mivel a Cégjelző API válaszstruktúrája az Business Data Wizard döntésétől függ.
/// A <see cref="JsonElement"/> segítségével pl. <c>GetRawText()</c> vagy
/// további deszializálás végezhető.
/// </summary>
public class CegjelzoProxyAutocompleteData
{
    [JsonPropertyName("company_data")]
    public JsonElement CompanyData { get; set; }

    [JsonPropertyName("cache")]
    public CegjelzoCacheInfo? Cache { get; set; }
}

public class CegjelzoProxySearchData
{
    [JsonPropertyName("company_data")]
    public JsonElement CompanyData { get; set; }

    [JsonPropertyName("financials_data")]
    public JsonElement? FinancialsData { get; set; }

    [JsonPropertyName("ai_analysis")]
    public DimKonzolAiAnalysis? AiAnalysis { get; set; }

    [JsonPropertyName("data_changed")]
    public bool? DataChanged { get; set; }

    [JsonPropertyName("cache")]
    public CegjelzoCacheInfo? Cache { get; set; }
}

public class CegjelzoCacheInfo
{
    [JsonPropertyName("hit")]
    public bool Hit { get; set; }

    [JsonPropertyName("cached_at")]
    public string? CachedAt { get; set; }

    [JsonPropertyName("expires_at")]
    public string? ExpiresAt { get; set; }

    [JsonPropertyName("last_refreshed_at")]
    public string? LastRefreshedAt { get; set; }
}

public class DimKonzolAiAnalysis
{
    [JsonPropertyName("model")]
    public string Model { get; set; } = string.Empty;

    [JsonPropertyName("analysis")]
    public string Analysis { get; set; } = string.Empty;

    [JsonPropertyName("generated_at")]
    public string GeneratedAt { get; set; } = string.Empty;

    [JsonPropertyName("prompt_tokens")]
    public int PromptTokens { get; set; }

    [JsonPropertyName("completion_tokens")]
    public int CompletionTokens { get; set; }

    [JsonPropertyName("total_tokens")]
    public int TotalTokens { get; set; }
}

public class CegjelzoUsageData
{
    [JsonPropertyName("quota")]
    public CegjelzoQuotaInfo? Quota { get; set; }

    [JsonPropertyName("activity")]
    public CegjelzoActivityInfo? Activity { get; set; }
}

public class CegjelzoQuotaInfo
{
    [JsonPropertyName("no_subscription")]
    public bool NoSubscription { get; set; }

    [JsonPropertyName("total")]
    public int? Total { get; set; }

    [JsonPropertyName("used")]
    public int? Used { get; set; }

    [JsonPropertyName("remaining")]
    public int? Remaining { get; set; }

    [JsonPropertyName("allocations")]
    public List<CegjelzoQuotaAllocation> Allocations { get; set; } = [];
}

public class CegjelzoActivityInfo
{
    [JsonPropertyName("total_requests")]
    public int TotalRequests { get; set; }

    [JsonPropertyName("cache_hit_requests")]
    public int CacheHitRequests { get; set; }

    [JsonPropertyName("api_requests")]
    public int ApiRequests { get; set; }

    [JsonPropertyName("cache_hit_rate")]
    public double CacheHitRate { get; set; }

    [JsonPropertyName("avg_response_time_ms")]
    public double AvgResponseTimeMs { get; set; }

    [JsonPropertyName("last_request_at")]
    public string? LastRequestAt { get; set; }
}

public class CegjelzoQuotaAllocation
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    [JsonPropertyName("service_name")]
    public string ServiceName { get; set; } = string.Empty;

    [JsonPropertyName("billing_cycle")]
    public string BillingCycle { get; set; } = string.Empty;

    [JsonPropertyName("order_number")]
    public string? OrderNumber { get; set; }

    [JsonPropertyName("total")]
    public int Total { get; set; }

    [JsonPropertyName("used")]
    public int Used { get; set; }

    [JsonPropertyName("remaining")]
    public int Remaining { get; set; }

    [JsonPropertyName("expires_at")]
    public string? ExpiresAt { get; set; }

    [JsonPropertyName("next_reset_at")]
    public string? NextResetAt { get; set; }
}

public class CegjelzoRecentQuery
{
    [JsonPropertyName("endpoint")]
    public string Endpoint { get; set; } = string.Empty;

    [JsonPropertyName("query_params")]
    public string QueryParams { get; set; } = string.Empty;

    [JsonPropertyName("cache_hit")]
    public bool CacheHit { get; set; }

    [JsonPropertyName("http_status")]
    public int HttpStatus { get; set; }

    [JsonPropertyName("response_time_ms")]
    public int ResponseTimeMs { get; set; }

    [JsonPropertyName("created_at")]
    public string CreatedAt { get; set; } = string.Empty;
}

// ============================================================
// Events
// ============================================================

public class ChatCompletedEventArgs : EventArgs
{
    public OpenAiUsageInfo? Usage { get; init; }
    public OpenAiQuotaInfo? Quota { get; init; }
}

public class AuthTokensChangedEventArgs : EventArgs
{
    public string? RefreshToken { get; init; }
    public string? UserEmail { get; init; }
}

// ============================================================
// OpenAI proxy modellek
// ============================================================

public class DimKonzolChatMessage
{
    [JsonPropertyName("role")]
    public string Role { get; set; } = string.Empty;

    [JsonPropertyName("content")]
    public string Content { get; set; } = string.Empty;

    public static DimKonzolChatMessage User(string content) => new() { Role = "user", Content = content };
    public static DimKonzolChatMessage Assistant(string content) => new() { Role = "assistant", Content = content };
}

public class OpenAiChatData
{
    [JsonPropertyName("openai")]
    public OpenAiChatResult? OpenAi { get; set; }

    [JsonPropertyName("usage")]
    public OpenAiUsageInfo? Usage { get; set; }

    [JsonPropertyName("quota")]
    public OpenAiQuotaInfo? Quota { get; set; }
}

public class OpenAiChatResult
{
    [JsonPropertyName("message")]
    public string Message { get; set; } = string.Empty;

    [JsonPropertyName("finish_reason")]
    public string FinishReason { get; set; } = string.Empty;
}

public class OpenAiUsageInfo
{
    [JsonPropertyName("model")]
    public string Model { get; set; } = string.Empty;

    [JsonPropertyName("prompt_tokens")]
    public int PromptTokens { get; set; }

    [JsonPropertyName("completion_tokens")]
    public int CompletionTokens { get; set; }

    [JsonPropertyName("total_tokens")]
    public int TotalTokens { get; set; }
}

public class OpenAiSettingsData
{
    [JsonPropertyName("model")]
    public string Model { get; set; } = string.Empty;

    [JsonPropertyName("user_model")]
    public string? UserModel { get; set; }

    [JsonPropertyName("default_model")]
    public string DefaultModel { get; set; } = string.Empty;

    [JsonPropertyName("allowed_models")]
    public List<string> AllowedModels { get; set; } = [];
}

public class OpenAiUsageData
{
    [JsonPropertyName("quota")]
    public OpenAiQuotaInfo? Quota { get; set; }

    [JsonPropertyName("activity")]
    public OpenAiActivityInfo? Activity { get; set; }
}

public class OpenAiActivityInfo
{
    [JsonPropertyName("total_requests")]
    public int TotalRequests { get; set; }

    [JsonPropertyName("total_tokens")]
    public int TotalTokens { get; set; }

    [JsonPropertyName("prompt_tokens")]
    public int PromptTokens { get; set; }

    [JsonPropertyName("completion_tokens")]
    public int CompletionTokens { get; set; }

    [JsonPropertyName("by_model")]
    public List<OpenAiModelUsage> ByModel { get; set; } = [];
}

public class OpenAiQuotaInfo
{
    [JsonPropertyName("no_subscription")]
    public bool NoSubscription { get; set; }

    [JsonPropertyName("total")]
    public int? Total { get; set; }

    [JsonPropertyName("used")]
    public int? Used { get; set; }

    [JsonPropertyName("remaining")]
    public int? Remaining { get; set; }

    [JsonPropertyName("allocations")]
    public List<OpenAiQuotaAllocation> Allocations { get; set; } = [];
}

public class OpenAiQuotaAllocation
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    [JsonPropertyName("service_name")]
    public string ServiceName { get; set; } = string.Empty;

    [JsonPropertyName("quota_type")]
    public string? QuotaType { get; set; }

    [JsonPropertyName("billing_cycle")]
    public string BillingCycle { get; set; } = string.Empty;

    [JsonPropertyName("order_number")]
    public string? OrderNumber { get; set; }

    [JsonPropertyName("total")]
    public int Total { get; set; }

    [JsonPropertyName("used")]
    public int Used { get; set; }

    [JsonPropertyName("remaining")]
    public int Remaining { get; set; }

    [JsonPropertyName("expires_at")]
    public string? ExpiresAt { get; set; }

    [JsonPropertyName("next_reset_at")]
    public string? NextResetAt { get; set; }
}

public class OpenAiModelUsage
{
    [JsonPropertyName("model")]
    public string Model { get; set; } = string.Empty;

    [JsonPropertyName("requests")]
    public int Requests { get; set; }

    [JsonPropertyName("total_tokens")]
    public int TotalTokens { get; set; }

    [JsonPropertyName("prompt_tokens")]
    public int PromptTokens { get; set; }

    [JsonPropertyName("completion_tokens")]
    public int CompletionTokens { get; set; }
}
