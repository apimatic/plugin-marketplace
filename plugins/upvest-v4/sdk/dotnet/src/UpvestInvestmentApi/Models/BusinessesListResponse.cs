using System.Collections.Generic;
using System.Text.Json.Serialization;
using UpvestInvestmentApi.Models.AnyOf;

namespace UpvestInvestmentApi.Models;

/// <summary>
/// Response for listing businesses.
/// </summary>
public record BusinessesListResponse
{
    /// <summary>
    /// Offset/limit pagination metadata for a list response. Contains the <c>offset</c> and <c>limit</c> applied to the request, the <c>count</c> of resources returned in this page, and the <c>total_count</c> of matching resources.
    /// </summary>
    [JsonPropertyName("meta")]
    public required Meta Meta { get; init; }

    /// <summary>
    /// List of businesses
    /// </summary>
    [JsonPropertyName("data")]
    public required IReadOnlyList<Business22> Data { get; init; }
}
