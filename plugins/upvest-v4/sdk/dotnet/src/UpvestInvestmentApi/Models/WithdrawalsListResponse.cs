using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace UpvestInvestmentApi.Models;

/// <summary>
/// Paginated list of cash withdrawals for an account group, including cursor-based pagination metadata.
/// </summary>
public record WithdrawalsListResponse
{
    /// <summary>
    /// Offset/limit pagination metadata for a list response. Contains the <c>offset</c> and <c>limit</c> applied to the request, the <c>count</c> of resources returned in this page, and the <c>total_count</c> of matching resources.
    /// </summary>
    [JsonPropertyName("meta")]
    public required Meta Meta { get; init; }

    [JsonPropertyName("data")]
    public required IReadOnlyList<PaymentsWithdrawal> Data { get; init; }
}
