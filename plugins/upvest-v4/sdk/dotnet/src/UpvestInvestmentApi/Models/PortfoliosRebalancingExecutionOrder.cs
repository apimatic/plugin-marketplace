using System;
using System.Text.Json.Serialization;
using UpvestInvestmentApi.Models.Enums;

namespace UpvestInvestmentApi.Models;

/// <summary>
/// An individual account-level order within a rebalancing execution. Each entry corresponds to a single account being rebalanced and has its own status lifecycle.
/// </summary>
public record PortfoliosRebalancingExecutionOrder
{
    /// <summary>
    /// Universally Unique Identifier (UUID) of a rebalancing execution order.
    /// </summary>
    [JsonPropertyName("id")]
    public required Guid Id { get; init; }

    /// <summary>
    /// Universally Unique Identifier (UUID) of a portfolio rebalancing execution.
    /// </summary>
    [JsonPropertyName("execution_id")]
    public required Guid ExecutionId { get; init; }

    /// <summary>
    /// Universally Unique Identifier (UUID) of the account.
    /// </summary>
    [JsonPropertyName("account_id")]
    public required Guid AccountId { get; init; }

    [JsonPropertyName("portfolio_order_id")]
    public required Guid? PortfolioOrderId { get; init; }

    /// <summary>
    /// Status of the Rebalancing Execution Order.
    /// * NEW -
    /// * PROCESSING -
    /// * FILLED -
    /// * CANCELLED -
    /// </summary>
    [JsonPropertyName("status")]
    public required Status71 Status { get; init; }

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
    /// Reason for Rebalancing Execution Order Cancellation. The field is present in case the Order has a status of CANCELLED.
    /// * ACCOUNT_IS_EMPTY -
    /// * ACCOUNT_NOT_FOUND -
    /// * CANCELLED_BY_CLIENT -
    /// * CANCELLED_BY_UPVEST -
    /// * CONFIGURATION_IS_MISSING -
    /// * INVALID_ACCOUNT_TYPE -
    /// * PORTFOLIO_IS_BALANCED -
    /// * UNKNOWN -
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("cancellation_reason")]
    public CancellationReason3? CancellationReason { get; init; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("cancellation_details")]
    public string? CancellationDetails { get; init; }
}
