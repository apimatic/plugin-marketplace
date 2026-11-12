using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace UpvestInvestmentApi.Models;

/// <summary>
/// Request body for updating a portfolio configuration. Updates the target allocation and/or associated rebalancing strategies.
/// </summary>
public record PortfoliosConfigurationUpdateRequest
{
    /// <summary>
    /// Universally Unique Identifier (UUID) of a portfolio allocation.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("allocation_id")]
    public Guid? AllocationId { get; init; }

    /// <summary>
    /// List of rebalancing strategy ids
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("rebalancing_strategy_ids")]
    public IReadOnlyList<Guid>? RebalancingStrategyIds { get; init; }
}
