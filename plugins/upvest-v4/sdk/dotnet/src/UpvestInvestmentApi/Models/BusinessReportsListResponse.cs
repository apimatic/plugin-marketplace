using System.Collections.Generic;
using System.Text.Json.Serialization;
using UpvestInvestmentApi.Models.AnyOf;

namespace UpvestInvestmentApi.Models;

/// <summary>
/// Paginated response containing the reports generated for a business.
/// </summary>
public record BusinessReportsListResponse
{
    /// <summary>
    /// Offset/limit pagination metadata for a list response whose sort field and order are always returned.
    /// </summary>
    [JsonPropertyName("meta")]
    public required Meta28 Meta { get; init; }

    /// <summary>
    /// List of reports generated for the business
    /// </summary>
    [JsonPropertyName("data")]
    public required IReadOnlyList<Datum10> Data { get; init; }
}
