using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace UpvestInvestmentApi.Models;

/// <summary>
/// Request body for creating a portfolio configuration for an account. Links the account to a target allocation and optional rebalancing strategies.
/// </summary>
public record PortfoliosConfigurationCreateRequest
{
    /// <summary>
    /// Universally Unique Identifier (UUID) of the account.
    /// </summary>
    [JsonPropertyName("account_id")]
    public required Guid AccountId { get; init; }

    /// <summary>
    /// Universally Unique Identifier (UUID) of a portfolio allocation.
    /// </summary>
    [JsonPropertyName("allocation_id")]
    public required Guid AllocationId { get; init; }

    /// <summary>
    /// List of rebalancing strategy ids
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("rebalancing_strategy_ids")]
    public IReadOnlyList<Guid>? RebalancingStrategyIds { get; init; }
}
