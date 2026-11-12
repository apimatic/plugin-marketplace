using System;
using System.Text.Json.Serialization;
using UpvestInvestmentApi.Core.Models;
using UpvestInvestmentApi.Models.Enums;

namespace UpvestInvestmentApi.Models;

/// <summary>
/// A securities transfer report generated for a business.
/// </summary>
public record BusinessReportSecuritiesTransfer
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
    /// Unique identifier for the business.
    /// </summary>
    [JsonPropertyName("business_id")]
    public required Guid BusinessId { get; init; }

    /// <summary>
    /// Report type
    /// * SECURITIES_TRANSFER_INCOMING - Securities are transferred in
    /// * SECURITIES_TRANSFER_OUTGOING - Securities are being transferred out
    /// </summary>
    [JsonPropertyName("type")]
    public required ReportTypeSecuritiesTransfer Type { get; init; }

    /// <summary>
    /// The unique identifier of the report that this report replaces, as a UUID. Populated when a mistrade causes a corrected report to be issued; <c>null</c> otherwise.
    /// </summary>
    [JsonPropertyName("substituted_report_id")]
    public required Guid? SubstitutedReportId { get; init; }

    /// <summary>
    /// The contents of a securities transfer report, including the account it relates to and the transferred instrument.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("data")]
    public ReportDataSecuritiesTransfer? Data { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
