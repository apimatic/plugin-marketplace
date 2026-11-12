using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using UpvestInvestmentApi.Models.Enums;

namespace UpvestInvestmentApi.Models;

/// <summary>
/// Represents a portfolio order — a BUY or SELL instruction that invests or withdraws a cash amount distributed across all instruments in the account's current allocation.
/// </summary>
public record PortfoliosOrder
{
    /// <summary>
    /// Universally Unique Identifier (UUID) of a portfolio order.
    /// </summary>
    [JsonPropertyName("id")]
    public required Guid Id { get; init; }

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
    /// Unique identifier of the user, as a UUID.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("user_id")]
    public Guid? UserId { get; init; }

    /// <summary>
    /// Universally Unique Identifier (UUID) of the account.
    /// </summary>
    [JsonPropertyName("account_id")]
    public required Guid AccountId { get; init; }

    /// <summary>
    /// Universally Unique Identifier (UUID) of a portfolio allocation.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("allocation_id")]
    public Guid? AllocationId { get; init; }

    /// <summary>
    /// A positive decimal amount, as a string.
    /// </summary>
    [JsonPropertyName("cash_amount")]
    [RegularExpression("^[0-9]{0,63}(\\.[0-9]{1,27})?$")]
    public required string CashAmount { get; init; }

    /// <summary>
    /// Alphabetic three-letter <see href="https://www.iso.org/iso-4217-currency-codes.html">ISO 4217</see> currency code.
    /// * EUR — Euro.
    /// * GBP — Pound Sterling.
    /// </summary>
    [JsonPropertyName("currency")]
    public required Currency Currency { get; init; }

    /// <summary>
    /// Execution status of the Portfolio Order.
    /// * NEW -
    /// * PROCESSING -
    /// * FILLED -
    /// * SETTLED -
    /// * CANCELLED -
    /// </summary>
    [JsonPropertyName("status")]
    public required Status65 Status { get; init; }

    /// <summary>
    /// Type of the Portfolio Order.
    /// * BUY -
    /// * SELL -
    /// * REBALANCING -
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("type")]
    public Type46? Type { get; init; }

    /// <summary>
    /// Cash amount is post-tax value
    /// </summary>
    [JsonPropertyName("post_tax")]
    public bool PostTax { get; init; } = false;

    /// <summary>
    /// Orders associated with this portfolio order
    /// </summary>
    [JsonPropertyName("orders")]
    public required IReadOnlyList<PortfoliosOrder1> Orders { get; init; }

    /// <summary>
    /// A reference string provided by the client to correlate the portfolio order with a record in the client's own system.
    /// </summary>
    [JsonPropertyName("client_reference")]
    public required string ClientReference { get; init; }

    /// <summary>
    /// Identifies what triggered the portfolio order.
    /// * API — initiated directly via the client API.
    /// * SAVINGS_PLAN — initiated by a savings plan execution.
    /// * AUTO_INVESTMENT — initiated automatically by auto-investment to invest incoming cash.
    /// </summary>
    [JsonPropertyName("initiation_flow")]
    public required InitiationFlowUsedDuringOrderCreation InitiationFlow { get; init; }

    /// <summary>
    /// Explains the reason why the order was cancelled .
    /// * ACCOUNT_IS_EMPTY -
    /// * CANCELLED_BY_CLIENT -
    /// * CANCELLED_BY_UPVEST -
    /// * PORTFOLIO_IS_BALANCED -
    /// * SELL_LIMIT_EXCEEDED -
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("cancellation_reason")]
    public CancellationReasonCode? CancellationReason { get; init; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("cancellation_details")]
    public string? CancellationDetails { get; init; }
}
