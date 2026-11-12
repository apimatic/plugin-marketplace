using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace UpvestInvestmentApi.Models;

/// <summary>
/// Paginated list of the transaction fee configurations assigned to an account group. Contains a <c>data</c> array of transaction fee account group configuration objects and a <c>meta</c> object with offset/limit pagination metadata.
/// </summary>
public record TransactionFeeAccountGroupConfigurationsListResponse
{
    /// <summary>
    /// Offset/limit pagination metadata for a list response. Contains the <c>offset</c> and <c>limit</c> applied to the request, the <c>count</c> of resources returned in this page, and the <c>total_count</c> of matching resources.
    /// </summary>
    [JsonPropertyName("meta")]
    public required Meta Meta { get; init; }

    /// <summary>
    /// List of transaction fee configurations assigned to the account group, at most one per transaction category.
    /// </summary>
    [JsonPropertyName("data")]
    public required IReadOnlyList<TransactionFeeAccountGroupConfiguration> Data { get; init; }
}
