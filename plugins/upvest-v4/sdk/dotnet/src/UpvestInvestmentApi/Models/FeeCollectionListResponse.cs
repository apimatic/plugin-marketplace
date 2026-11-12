using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace UpvestInvestmentApi.Models;

/// <summary>
/// Paginated list of fee collections. Contains a <c>data</c> array of fee collection objects and a <c>meta</c> object with offset/limit pagination metadata.
/// </summary>
public record FeeCollectionListResponse
{
    /// <summary>
    /// Offset/limit pagination metadata for a list response. Contains the <c>offset</c> and <c>limit</c> applied to the request, the <c>count</c> of resources returned in this page, and the <c>total_count</c> of matching resources.
    /// </summary>
    [JsonPropertyName("meta")]
    public required Meta Meta { get; init; }

    /// <summary>
    /// The fee collections in this page of results.
    /// </summary>
    [JsonPropertyName("data")]
    public required IReadOnlyList<FeeCollection> Data { get; init; }
}
