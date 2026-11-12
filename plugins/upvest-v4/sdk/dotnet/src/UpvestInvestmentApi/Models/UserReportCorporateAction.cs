using System;
using System.Text.Json.Serialization;
using UpvestInvestmentApi.Core.Models;
using UpvestInvestmentApi.Models.Enums;

namespace UpvestInvestmentApi.Models;

/// <summary>
/// A corporate action cash or security transaction report generated for an end user.
/// </summary>
public record UserReportCorporateAction
{
    /// <summary>
    /// The unique identifier of the report, as a UUID.
    /// </summary>
    [JsonPropertyName("id")]
    public required Guid Id { get; init; }

    /// <summary>
    /// Date and time when the resource was created. <see href="https://datatracker.ietf.org/doc/html/rfc3339#section-5.6">RFC 3339-5</see>, <see href="https://www.iso.org/iso-8601-date-and-time-format.html">ISO8601 UTC</see>
    /// </summary>
    [JsonPropertyName("created_at")]
    public required DateTimeOffset CreatedAt { get; init; }

    /// <summary>
    /// Unique identifier of the user, as a UUID.
    /// </summary>
    [JsonPropertyName("user_id")]
    public required Guid UserId { get; init; }

    /// <summary>
    /// Report type
    /// * CORPORATE_ACTION_CASH_TRANSACTION - cash transaction document (after corporate action)
    /// * CORPORATE_ACTION_SECURITY_TRANSACTION - security transaction document (after corporate action)
    /// </summary>
    [JsonPropertyName("type")]
    public required ReportTypeCorporateAction Type { get; init; }

    /// <summary>
    /// The unique identifier of the report that this report replaces, as a UUID. Populated when a mistrade causes a corrected report to be issued; <c>null</c> otherwise.
    /// </summary>
    [JsonPropertyName("substituted_report_id")]
    public required Guid? SubstitutedReportId { get; init; }

    /// <summary>
    /// The contents of a corporate action cash or security transaction report, including the instrument it relates to and a reference to the corporate action transaction.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("data")]
    public ReportDataCorporateAction? Data { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
