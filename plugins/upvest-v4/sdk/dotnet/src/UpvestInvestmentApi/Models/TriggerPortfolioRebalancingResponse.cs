using System;
using System.Text.Json.Serialization;

namespace UpvestInvestmentApi.Models;

/// <summary>
/// Response returned after triggering a portfolio rebalancing, containing the <c>id</c> of the rebalancing execution created.
/// </summary>
public record TriggerPortfolioRebalancingResponse
{
    /// <summary>
    /// Universally Unique Identifier (UUID) of a portfolio rebalancing execution.
    /// </summary>
    [JsonPropertyName("id")]
    public required Guid Id { get; init; }
}
