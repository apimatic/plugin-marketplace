using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace UpvestInvestmentApi.Models;

/// <summary>
/// Request body for creating a portfolio allocation. Specifies the allocation name, instrument weights, and optional rebalancing strategy IDs.
/// </summary>
public record PortfoliosAllocationCreateRequest
{
    /// <summary>
    /// Allocation name
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("name")]
    public string? Name { get; init; }

    /// <summary>
    /// List of portfolios allocations
    /// </summary>
    [JsonPropertyName("allocation")]
    public required IReadOnlyList<Allocation> Allocation { get; init; }

    /// <summary>
    /// List of rebalancing strategy ids
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("rebalancing_strategy_ids")]
    public IReadOnlyList<Guid>? RebalancingStrategyIds { get; init; }
}
