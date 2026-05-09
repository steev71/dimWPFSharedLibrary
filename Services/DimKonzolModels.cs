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

    [JsonPropertyName("tenant_role")]
    public string? TenantRole { get; set; }

    [JsonPropertyName("user_type")]
    public string? UserType { get; set; }
}

public class DeviceActivationClaimData
{
    [JsonPropertyName("device_token")]
    public string DeviceToken { get; set; } = string.Empty;

    [JsonPropertyName("device_id")]
    public int DeviceId { get; set; }

    [JsonPropertyName("tenant_id")]
    public int TenantId { get; set; }

    [JsonPropertyName("seat_id")]
    public int SeatId { get; set; }

    [JsonPropertyName("license_id")]
    public int LicenseId { get; set; }

    [JsonPropertyName("license_key")]
    public string LicenseKey { get; set; } = string.Empty;

    [JsonPropertyName("valid_until")]
    public string? ValidUntil { get; set; }
}

public class DeviceValidationData
{
    [JsonPropertyName("active")]
    public bool Active { get; set; }

    [JsonPropertyName("entitlement_ok")]
    public bool EntitlementOk { get; set; }

    [JsonPropertyName("tenant_id")]
    public int TenantId { get; set; }

    [JsonPropertyName("tenant_name")]
    public string? TenantName { get; set; }

    [JsonPropertyName("tenant_active")]
    public bool TenantActive { get; set; }

    [JsonPropertyName("device_id")]
    public int DeviceId { get; set; }

    [JsonPropertyName("seat_id")]
    public int SeatId { get; set; }

    [JsonPropertyName("seat_status")]
    public string? SeatStatus { get; set; }

    [JsonPropertyName("license_id")]
    public int LicenseId { get; set; }

    [JsonPropertyName("license_key")]
    public string? LicenseKey { get; set; }

    [JsonPropertyName("license_type")]
    public string? LicenseType { get; set; }

    [JsonPropertyName("license_active")]
    public bool LicenseActive { get; set; }

    [JsonPropertyName("valid_from")]
    public string? ValidFrom { get; set; }

    [JsonPropertyName("valid_until")]
    public string? ValidUntil { get; set; }

    [JsonPropertyName("max_devices")]
    public int MaxDevices { get; set; }

    [JsonPropertyName("device_name")]
    public string? DeviceName { get; set; }

    [JsonPropertyName("hardware_id")]
    public string? HardwareId { get; set; }
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

    [JsonPropertyName("current_month")]
    public UsageMonthInfo? CurrentMonth { get; set; }
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
// Support API modellek
// ============================================================

public class DimKonzolSupportItemCreateRequest
{
    [JsonPropertyName("type")]
    public string Type { get; set; } = string.Empty;

    [JsonPropertyName("subject")]
    public string Subject { get; set; } = string.Empty;

    [JsonPropertyName("description")]
    public string Description { get; set; } = string.Empty;

    [JsonPropertyName("priority")]
    public string? Priority { get; set; }

    [JsonPropertyName("is_public")]
    public bool? IsPublic { get; set; }

    [JsonPropertyName("allow_public_comments")]
    public bool? AllowPublicComments { get; set; }

    [JsonPropertyName("contact_name")]
    public string? ContactName { get; set; }

    [JsonPropertyName("contact_email")]
    public string? ContactEmail { get; set; }

    [JsonPropertyName("client_version")]
    public string? ClientVersion { get; set; }

    [JsonPropertyName("operating_system")]
    public string? OperatingSystem { get; set; }

    [JsonPropertyName("metadata")]
    public object? Metadata { get; set; }
}

public class DimKonzolSupportMessageCreateRequest
{
    [JsonPropertyName("message")]
    public string? Message { get; set; }

    [JsonPropertyName("metadata")]
    public object? Metadata { get; set; }
}

public class DimKonzolSupportAttachmentDownloadResult
{
    public string? FileName { get; set; }

    public string? MediaType { get; set; }

    public byte[] Content { get; set; } = [];
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

public class OpenAiClassifyAccountingDocumentData
{
    [JsonPropertyName("classification")]
    public OpenAiAccountingDocumentClassification? Classification { get; set; }

    [JsonPropertyName("usage")]
    public OpenAiUsageInfo? Usage { get; set; }

    [JsonPropertyName("file")]
    public OpenAiAttachmentInfo? File { get; set; }

    [JsonPropertyName("quota")]
    public OpenAiQuotaInfo? Quota { get; set; }
}

public class OpenAiProcessBankStatementData
{
    [JsonPropertyName("statement")]
    public OpenAiBankStatementResult? Statement { get; set; }

    [JsonPropertyName("usage")]
    public OpenAiUsageInfo? Usage { get; set; }

    [JsonPropertyName("file")]
    public OpenAiAttachmentInfo? File { get; set; }

    [JsonPropertyName("quota")]
    public OpenAiQuotaInfo? Quota { get; set; }
}

public class OpenAiProcessInvoiceData
{
    [JsonPropertyName("invoice")]
    public OpenAiInvoiceExtraction? Invoice { get; set; }

    [JsonPropertyName("usage")]
    public OpenAiUsageInfo? Usage { get; set; }

    [JsonPropertyName("file")]
    public OpenAiAttachmentInfo? File { get; set; }

    [JsonPropertyName("quota")]
    public OpenAiQuotaInfo? Quota { get; set; }
}

public class OpenAiChatWithFilesData
{
    [JsonPropertyName("openai")]
    public OpenAiChatResult? OpenAi { get; set; }

    [JsonPropertyName("usage")]
    public OpenAiUsageInfo? Usage { get; set; }

    [JsonPropertyName("files")]
    public List<OpenAiAttachmentInfo> Files { get; set; } = [];

    [JsonPropertyName("quota")]
    public OpenAiQuotaInfo? Quota { get; set; }
}

public class OpenAiGenerateChartSpecData
{
    [JsonPropertyName("chart_spec")]
    public OpenAiChartSpec? ChartSpec { get; set; }

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

    [JsonPropertyName("response_id")]
    public string? ResponseId { get; set; }

    [JsonPropertyName("status")]
    public string? Status { get; set; }
}

public class OpenAiAttachmentInfo
{
    [JsonPropertyName("filename")]
    public string Filename { get; set; } = string.Empty;

    [JsonPropertyName("media_type")]
    public string MediaType { get; set; } = string.Empty;

    [JsonPropertyName("size")]
    public long Size { get; set; }
}

public class OpenAiChartSpec
{
    [JsonPropertyName("chart_type")]
    public string ChartType { get; set; } = string.Empty;

    [JsonPropertyName("title")]
    public string Title { get; set; } = string.Empty;

    [JsonPropertyName("subtitle")]
    public string? Subtitle { get; set; }

    [JsonPropertyName("summary")]
    public string? Summary { get; set; }

    [JsonPropertyName("categories")]
    public List<string> Categories { get; set; } = [];

    [JsonPropertyName("series")]
    public List<OpenAiChartSeries> Series { get; set; } = [];

    [JsonPropertyName("x_axis_title")]
    public string? XAxisTitle { get; set; }

    [JsonPropertyName("y_axis_title")]
    public string? YAxisTitle { get; set; }

    [JsonPropertyName("unit")]
    public string? Unit { get; set; }

    [JsonPropertyName("value_format")]
    public string? ValueFormat { get; set; }

    [JsonPropertyName("suggested_height")]
    public int? SuggestedHeight { get; set; }

    [JsonPropertyName("stacked")]
    public bool Stacked { get; set; }

    [JsonPropertyName("legend_position")]
    public string? LegendPosition { get; set; }

    [JsonPropertyName("warnings")]
    public List<string> Warnings { get; set; } = [];
}

public class OpenAiChartSeries
{
    [JsonPropertyName("name")]
    public string Name { get; set; } = string.Empty;

    [JsonPropertyName("values")]
    public List<double?> Values { get; set; } = [];
}

public class DimKonzolFileAttachment
{
    public string FileName { get; set; } = string.Empty;

    public byte[] Content { get; set; } = [];

    public string? MediaType { get; set; }
}

public class OpenAiInvoiceStringField
{
    [JsonPropertyName("value")]
    public string? Value { get; set; }

    [JsonPropertyName("confidence")]
    public double Confidence { get; set; }

    [JsonPropertyName("is_confident")]
    public bool IsConfident { get; set; }

    [JsonPropertyName("reason")]
    public string? Reason { get; set; }
}

public class OpenAiInvoiceNumberField
{
    [JsonPropertyName("value")]
    public decimal? Value { get; set; }

    [JsonPropertyName("confidence")]
    public double Confidence { get; set; }

    [JsonPropertyName("is_confident")]
    public bool IsConfident { get; set; }

    [JsonPropertyName("reason")]
    public string? Reason { get; set; }
}

public class OpenAiInvoiceExtraction
{
    [JsonPropertyName("supplier_name")]
    public OpenAiInvoiceStringField SupplierName { get; set; } = new();

    [JsonPropertyName("supplier_tax_number")]
    public OpenAiInvoiceStringField SupplierTaxNumber { get; set; } = new();

    [JsonPropertyName("customer_name")]
    public OpenAiInvoiceStringField CustomerName { get; set; } = new();

    [JsonPropertyName("customer_tax_number")]
    public OpenAiInvoiceStringField CustomerTaxNumber { get; set; } = new();

    [JsonPropertyName("invoice_number")]
    public OpenAiInvoiceStringField InvoiceNumber { get; set; } = new();

    [JsonPropertyName("invoice_date")]
    public OpenAiInvoiceStringField InvoiceDate { get; set; } = new();

    [JsonPropertyName("fulfillment_date")]
    public OpenAiInvoiceStringField FulfillmentDate { get; set; } = new();

    [JsonPropertyName("due_date")]
    public OpenAiInvoiceStringField DueDate { get; set; } = new();

    [JsonPropertyName("currency_code")]
    public OpenAiInvoiceStringField CurrencyCode { get; set; } = new();

    [JsonPropertyName("net_amount")]
    public OpenAiInvoiceNumberField NetAmount { get; set; } = new();

    [JsonPropertyName("vat_amount")]
    public OpenAiInvoiceNumberField VatAmount { get; set; } = new();

    [JsonPropertyName("gross_amount")]
    public OpenAiInvoiceNumberField GrossAmount { get; set; } = new();

    [JsonPropertyName("overall_confidence")]
    public double OverallConfidence { get; set; }

    [JsonPropertyName("needs_review")]
    public bool NeedsReview { get; set; }

    [JsonPropertyName("review_reason")]
    public string? ReviewReason { get; set; }

    [JsonPropertyName("ocr_quality_issue_detected")]
    public bool OcrQualityIssueDetected { get; set; }

    [JsonPropertyName("ocr_quality_issue_reason")]
    public string? OcrQualityIssueReason { get; set; }
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

    [JsonPropertyName("tenant_model")]
    public string? TenantModel { get; set; }

    [JsonPropertyName("default_model")]
    public string DefaultModel { get; set; } = string.Empty;

    [JsonPropertyName("allowed_models")]
    public List<string> AllowedModels { get; set; } = [];

    [JsonPropertyName("is_admin")]
    public bool IsAdmin { get; set; }
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

    [JsonPropertyName("estimated_cost_usd")]
    public decimal? EstimatedCostUsd { get; set; }

    [JsonPropertyName("avg_response_time_ms")]
    public double? AvgResponseTimeMs { get; set; }

    [JsonPropertyName("last_request_at")]
    public string? LastRequestAt { get; set; }

    [JsonPropertyName("by_model")]
    public List<OpenAiModelUsage> ByModel { get; set; } = [];

    [JsonPropertyName("current_month")]
    public OpenAiUsageMonthInfo? CurrentMonth { get; set; }
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

    [JsonPropertyName("estimated_cost_usd")]
    public decimal? EstimatedCostUsd { get; set; }
}

public class UsageMonthInfo
{
    [JsonPropertyName("year")]
    public int Year { get; set; }

    [JsonPropertyName("month")]
    public int Month { get; set; }

    [JsonPropertyName("total_requests")]
    public int TotalRequests { get; set; }

    [JsonPropertyName("cache_hit_requests")]
    public int CacheHitRequests { get; set; }

    [JsonPropertyName("api_requests")]
    public int ApiRequests { get; set; }
}

public class OpenAiUsageMonthInfo
{
    [JsonPropertyName("year")]
    public int Year { get; set; }

    [JsonPropertyName("month")]
    public int Month { get; set; }

    [JsonPropertyName("total_requests")]
    public int TotalRequests { get; set; }

    [JsonPropertyName("total_tokens")]
    public int TotalTokens { get; set; }

    [JsonPropertyName("prompt_tokens")]
    public int PromptTokens { get; set; }

    [JsonPropertyName("completion_tokens")]
    public int CompletionTokens { get; set; }
}

public class OpenAiAccountingDocumentClassification
{
    [JsonPropertyName("document_family")]
    public string? DocumentFamily { get; set; }

    [JsonPropertyName("document_type")]
    public string? DocumentType { get; set; }

    [JsonPropertyName("document_direction")]
    public string? DocumentDirection { get; set; }

    [JsonPropertyName("direction_reason")]
    public string? DirectionReason { get; set; }

    [JsonPropertyName("confidence")]
    public double Confidence { get; set; }

    [JsonPropertyName("is_confident")]
    public bool IsConfident { get; set; }

    [JsonPropertyName("needs_review")]
    public bool NeedsReview { get; set; }

    [JsonPropertyName("review_reason")]
    public string? ReviewReason { get; set; }

    [JsonPropertyName("ocr_quality_issue_detected")]
    public bool OcrQualityIssueDetected { get; set; }

    [JsonPropertyName("ocr_quality_issue_reason")]
    public string? OcrQualityIssueReason { get; set; }

    [JsonPropertyName("suggested_next_step")]
    public string? SuggestedNextStep { get; set; }

    [JsonPropertyName("reason")]
    public string? Reason { get; set; }

    [JsonPropertyName("secondary_candidates")]
    public List<OpenAiAccountingDocumentCandidate> SecondaryCandidates { get; set; } = [];
}

public class OpenAiAccountingDocumentCandidate
{
    [JsonPropertyName("document_family")]
    public string? DocumentFamily { get; set; }

    [JsonPropertyName("document_type")]
    public string? DocumentType { get; set; }

    [JsonPropertyName("confidence")]
    public double Confidence { get; set; }

    [JsonPropertyName("reason")]
    public string? Reason { get; set; }
}

public class OpenAiBankStatementResult
{
    [JsonPropertyName("metadata")]
    public OpenAiBankStatementMetadata? Metadata { get; set; }

    [JsonPropertyName("transactions")]
    public List<OpenAiBankStatementTransaction> Transactions { get; set; } = [];

    [JsonPropertyName("overall_confidence")]
    public double OverallConfidence { get; set; }

    [JsonPropertyName("needs_review")]
    public bool NeedsReview { get; set; }

    [JsonPropertyName("review_reason")]
    public string? ReviewReason { get; set; }

    [JsonPropertyName("parsing_source")]
    public string? ParsingSource { get; set; }

    [JsonPropertyName("parsing_notes")]
    public string? ParsingNotes { get; set; }
}

public class OpenAiBankStatementMetadata
{
    [JsonPropertyName("bank_name")]
    public string? BankName { get; set; }

    [JsonPropertyName("account_number")]
    public string? AccountNumber { get; set; }

    [JsonPropertyName("iban")]
    public string? Iban { get; set; }

    [JsonPropertyName("currency_code")]
    public string? CurrencyCode { get; set; }

    [JsonPropertyName("statement_period_start")]
    public string? StatementPeriodStart { get; set; }

    [JsonPropertyName("statement_period_end")]
    public string? StatementPeriodEnd { get; set; }

    [JsonPropertyName("opening_balance")]
    public decimal? OpeningBalance { get; set; }

    [JsonPropertyName("closing_balance")]
    public decimal? ClosingBalance { get; set; }

    [JsonPropertyName("statement_date")]
    public string? StatementDate { get; set; }

    [JsonPropertyName("transaction_count")]
    public int? TransactionCount { get; set; }

    [JsonPropertyName("account_holder_name")]
    public string? AccountHolderName { get; set; }
}

public class OpenAiBankStatementTransaction
{
    [JsonPropertyName("sequence")]
    public int? Sequence { get; set; }

    [JsonPropertyName("booking_date")]
    public string? BookingDate { get; set; }

    [JsonPropertyName("value_date")]
    public string? ValueDate { get; set; }

    [JsonPropertyName("amount")]
    public decimal? Amount { get; set; }

    [JsonPropertyName("currency_code")]
    public string? CurrencyCode { get; set; }

    [JsonPropertyName("direction")]
    public string? Direction { get; set; }

    [JsonPropertyName("balance_after_transaction")]
    public decimal? BalanceAfterTransaction { get; set; }

    [JsonPropertyName("counterparty_name")]
    public string? CounterpartyName { get; set; }

    [JsonPropertyName("counterparty_account_number")]
    public string? CounterpartyAccountNumber { get; set; }

    [JsonPropertyName("reference")]
    public string? Reference { get; set; }

    [JsonPropertyName("notice")]
    public string? Notice { get; set; }

    [JsonPropertyName("transaction_type")]
    public string? TransactionType { get; set; }

    [JsonPropertyName("confidence")]
    public double Confidence { get; set; }

    [JsonPropertyName("needs_review")]
    public bool NeedsReview { get; set; }

    [JsonPropertyName("review_reason")]
    public string? ReviewReason { get; set; }
}
