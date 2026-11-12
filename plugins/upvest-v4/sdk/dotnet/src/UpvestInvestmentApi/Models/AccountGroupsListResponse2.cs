using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace UpvestInvestmentApi.Models;

/// <summary>
/// Paginated response containing the account groups owned by a business.
/// </summary>
public record AccountGroupsListResponse2
{
    /// <summary>
    /// Offset/limit pagination metadata for a list response. Contains the <c>offset</c> and <c>limit</c> applied to the request, the <c>count</c> of resources returned in this page, and the <c>total_count</c> of matching resources.
    /// </summary>
    [JsonPropertyName("meta")]
    public required Meta Meta { get; init; }

    /// <summary>
    /// List of the business's account groups.
    /// </summary>
    [JsonPropertyName("data")]
    public required IReadOnlyList<BusinessAccountGroup> Data { get; init; }
}
