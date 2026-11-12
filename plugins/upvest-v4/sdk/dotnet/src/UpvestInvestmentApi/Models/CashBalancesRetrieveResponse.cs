using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace UpvestInvestmentApi.Models;

/// <summary>
/// List of the account group's cash balances.
/// </summary>
public record CashBalancesRetrieveResponse
{
    /// <summary>
    /// Offset/limit pagination metadata for a list response. Contains the <c>offset</c> and <c>limit</c> applied to the request, the <c>count</c> of resources returned in this page, and the <c>total_count</c> of matching resources.
    /// </summary>
    [JsonPropertyName("meta")]
    public required Meta Meta { get; init; }

    /// <summary>
    /// The list of cash balance objects, one per currency the account group holds.
    /// </summary>
    [JsonPropertyName("data")]
    public required IReadOnlyList<Datum> Data { get; init; }
}
