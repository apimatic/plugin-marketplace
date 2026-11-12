using System.Collections.Generic;
using System.Text.Json.Serialization;
using UpvestInvestmentApi.Models.AnyOf;

namespace UpvestInvestmentApi.Models;

/// <summary>
/// Paginated list of account groups. Contains a <c>data</c> array of user or business account group objects and a <c>meta</c> object with offset/limit pagination metadata.
/// </summary>
public record AccountGroupsListResponse1
{
    /// <summary>
    /// Offset/limit pagination metadata for a list response. Contains the <c>offset</c> and <c>limit</c> applied to the request, the <c>count</c> of resources returned in this page, and the <c>total_count</c> of matching resources.
    /// </summary>
    [JsonPropertyName("meta")]
    public required Meta Meta { get; init; }

    /// <summary>
    /// List of account groups matching the query.
    /// </summary>
    [JsonPropertyName("data")]
    public required IReadOnlyList<Datum71> Data { get; init; }
}
