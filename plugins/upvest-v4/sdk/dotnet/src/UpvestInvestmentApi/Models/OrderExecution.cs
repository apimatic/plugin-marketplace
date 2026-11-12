using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using UpvestInvestmentApi.Models.Enums;

namespace UpvestInvestmentApi.Models;

/// <summary>
/// Represents a single execution (trade fill) within an order. An order may have multiple executions if it is partially filled across several trades.
/// </summary>
public record OrderExecution
{
    [JsonPropertyName("id")]
    public required Guid Id { get; init; }

    /// <summary>
    /// A positive cash amount, as a decimal string with up to two decimal places.
    /// </summary>
    [JsonPropertyName("cash_amount")]
    [RegularExpression("^[0-9]{1,9}(\\.[0-9]{2})?$")]
    public required string CashAmount { get; init; }

    /// <summary>
    /// A positive decimal amount, as a string.
    /// </summary>
    [JsonPropertyName("share_quantity")]
    [RegularExpression("^[0-9]{0,63}(\\.[0-9]{1,27})?$")]
    public required string ShareQuantity { get; init; }

    /// <summary>
    /// Price of an instrument for a trade execution provided as a decimal string.
    /// </summary>
    [JsonPropertyName("price")]
    [RegularExpression("^[0-9]{0,63}(\\.[0-9]{1,4})?$")]
    public required string Price { get; init; }

    /// <summary>
    /// Timestamp of when the trade was executed at the market. <see href="https://datatracker.ietf.org/doc/html/rfc3339">RFC 3339</see> date-time format.
    /// </summary>
    [JsonPropertyName("transaction_time")]
    public required DateTimeOffset TransactionTime { get; init; }

    /// <summary>
    /// Taxes deducted as part of this execution.
    /// </summary>
    [JsonPropertyName("taxes")]
    public required IReadOnlyList<Tax3> Taxes { get; init; }

    /// <summary>
    /// Unique identifier for an order. Universally Unique Identifier (UUID).
    /// </summary>
    [JsonPropertyName("order_id")]
    public required Guid OrderId { get; init; }

    /// <summary>
    /// Status of the execution.
    /// * FILLED — the execution has been filled.
    /// * SETTLED — the execution has settled and securities and cash have been exchanged.
    /// * CANCELLED — the execution was cancelled before settlement.
    /// </summary>
    [JsonPropertyName("status")]
    public required Status52 Status { get; init; }

    /// <summary>
    /// Side of the execution.
    /// * BUY — a buy execution.
    /// * SELL — a sell execution.
    /// </summary>
    [JsonPropertyName("side")]
    public required Side1 Side { get; init; }

    /// <summary>
    /// Alphabetic three-letter <see href="https://www.iso.org/iso-4217-currency-codes.html">ISO 4217</see> currency code.
    /// * EUR - Euro
    /// * GBP - British Pound
    /// * USD - US Dollar
    /// </summary>
    [JsonPropertyName("currency")]
    public required Currency29 Currency { get; init; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("settlement_date")]
    [RegularExpression("^[0-9]{4}-[0-9]{2}-[0-9]{2}$")]
    public string? SettlementDate { get; init; }

    /// <summary>
    /// The ID of the venue
    /// </summary>
    [JsonPropertyName("venue_id")]
    public required Guid VenueId { get; init; }
}
