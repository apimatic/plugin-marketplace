using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace UpvestInvestmentApi.Models;

/// <summary>
/// Links an investment account to a portfolio allocation and optional rebalancing strategies. Determines which allocation the account follows and which strategies govern automatic rebalancing.
/// </summary>
public record PortfoliosConfiguration
{
    /// <summary>
    /// Date and time when the resource was created. <see href="https://datatracker.ietf.org/doc/html/rfc3339#section-5.6">RFC 3339-5</see>, <see href="https://www.iso.org/iso-8601-date-and-time-format.html">ISO8601 UTC</see>
    /// </summary>
    [JsonPropertyName("created_at")]
    public required DateTimeOffset CreatedAt { get; init; }

    /// <summary>
    /// Date and time when the resource was last updated. <see href="https://datatracker.ietf.org/doc/html/rfc3339#section-5.6">RFC 3339-5</see>, <see href="https://www.iso.org/iso-8601-date-and-time-format.html">ISO8601 UTC</see>
    /// </summary>
    [JsonPropertyName("updated_at")]
    public required DateTimeOffset UpdatedAt { get; init; }

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
