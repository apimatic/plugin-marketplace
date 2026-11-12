using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace UpvestInvestmentApi.Models;

/// <summary>
/// Paginated list of transaction fee models. Contains a <c>data</c> array of transaction fee model objects and a <c>meta</c> object with offset/limit pagination metadata.
/// </summary>
public record TransactionFeeModelsListResponse
{
    /// <summary>
    /// Offset/limit pagination metadata for a list response. Contains the <c>offset</c> and <c>limit</c> applied to the request, the <c>count</c> of resources returned in this page, and the <c>total_count</c> of matching resources.
    /// </summary>
    [JsonPropertyName("meta")]
    public required Meta Meta { get; init; }

    /// <summary>
    /// List of transaction fee models matching the query.
    /// </summary>
    [JsonPropertyName("data")]
    public required IReadOnlyList<FeeConfiguration> Data { get; init; }
}
