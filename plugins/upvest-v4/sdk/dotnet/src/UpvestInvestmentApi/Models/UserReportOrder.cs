using System;
using System.Text.Json.Serialization;
using UpvestInvestmentApi.Core.Models;
using UpvestInvestmentApi.Models.Enums;

namespace UpvestInvestmentApi.Models;

/// <summary>
/// An order report generated for an end user.
/// </summary>
public record UserReportOrder
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
    /// * BUY_ORDER - Buy order
    /// * CANCELLED_ORDER - Cancelled buy or sell order (not yet executed, user cancels or trading venue cancelled)
    /// * REVOKED_ORDER - Revoked buy or sell order ("Storno")
    /// * SELL_ORDER - Sell order
    /// </summary>
    [JsonPropertyName("type")]
    public required ReportTypeOrder Type { get; init; }

    /// <summary>
    /// The unique identifier of the report that this report replaces, as a UUID. Populated when a mistrade causes a corrected report to be issued; <c>null</c> otherwise.
    /// </summary>
    [JsonPropertyName("substituted_report_id")]
    public required Guid? SubstitutedReportId { get; init; }

    /// <summary>
    /// The contents of an order report, including the account and instrument it relates to and references to the order.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("data")]
    public ReportDataOrder? Data { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
