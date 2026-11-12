using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace UpvestInvestmentApi.Models;

/// <summary>
/// Paginated list of user account groups. Contains a <c>data</c> array of user account group objects and a <c>meta</c> object with offset/limit pagination metadata.
/// </summary>
public record AccountGroupsListResponse
{
    /// <summary>
    /// Offset/limit pagination metadata for a list response. Contains the <c>offset</c> and <c>limit</c> applied to the request, the <c>count</c> of resources returned in this page, and the <c>total_count</c> of matching resources.
    /// </summary>
    [JsonPropertyName("meta")]
    public required Meta Meta { get; init; }

    /// <summary>
    /// List of the user's account groups.
    /// </summary>
    [JsonPropertyName("data")]
    public required IReadOnlyList<AccountGroup> Data { get; init; }
}
