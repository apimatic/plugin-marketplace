using System.Collections.Generic;
using System.Text.Json.Serialization;
using UpvestInvestmentApi.Models.AnyOf;

namespace UpvestInvestmentApi.Models;

/// <summary>
/// Paginated list of roles. Contains a <c>data</c> array of role objects and a <c>meta</c> object with offset/limit pagination metadata.
/// </summary>
public record RolesListResponse
{
    /// <summary>
    /// Offset/limit pagination metadata for a list response. Contains the <c>offset</c> and <c>limit</c> applied to the request, the <c>count</c> of resources returned in this page, and the <c>total_count</c> of matching resources.
    /// </summary>
    [JsonPropertyName("meta")]
    public required Meta Meta { get; init; }

    /// <summary>
    /// List of roles matching the query.
    /// </summary>
    [JsonPropertyName("data")]
    public required IReadOnlyList<Role> Data { get; init; }
}
