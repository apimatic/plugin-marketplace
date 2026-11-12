using System.Collections.Generic;
using System.Text.Json.Serialization;
using UpvestInvestmentApi.Models.AnyOf;

namespace UpvestInvestmentApi.Models;

/// <summary>
/// Paginated list of reports for an end user. Contains a <c>data</c> array of report objects and a <c>meta</c> object with offset/limit pagination metadata.
/// </summary>
public record ReportsListResponse
{
    /// <summary>
    /// Offset/limit pagination metadata for a list response whose sort field and order are always returned.
    /// </summary>
    [JsonPropertyName("meta")]
    public required Meta28 Meta { get; init; }

    /// <summary>
    /// The reports in this page of results.
    /// </summary>
    [JsonPropertyName("data")]
    public required IReadOnlyList<Datum91> Data { get; init; }
}
