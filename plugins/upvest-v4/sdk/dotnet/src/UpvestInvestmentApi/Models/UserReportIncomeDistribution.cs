using System;
using System.Text.Json.Serialization;
using UpvestInvestmentApi.Core.Models;

namespace UpvestInvestmentApi.Models;

/// <summary>
/// An income distribution report generated for an end user.
/// </summary>
public record UserReportIncomeDistribution
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
    /// * INCOME_DISTRIBUTION - Income distribution report
    /// </summary>
    [JsonPropertyName("type")]
    public string Type { get; } = "INCOME_DISTRIBUTION";

    /// <summary>
    /// The unique identifier of the report that this report replaces, as a UUID. Populated when a mistrade causes a corrected report to be issued; <c>null</c> otherwise.
    /// </summary>
    [JsonPropertyName("substituted_report_id")]
    public required Guid? SubstitutedReportId { get; init; }

    /// <summary>
    /// The contents of an income distribution report, including the account and instrument it relates to.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("data")]
    public ReportDataIncomeDistribution? Data { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
