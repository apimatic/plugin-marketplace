using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using UpvestInvestmentApi.Core.Models;
using UpvestInvestmentApi.Models.Enums;

namespace UpvestInvestmentApi.Models;

/// <summary>
/// Savings Plan Order details.
/// </summary>
public record ExAnteCostSavingsPlanOrder
{
    /// <summary>
    /// The unique identifier of the end user placing the order, as a UUID.
    /// </summary>
    [JsonPropertyName("user_id")]
    public required Guid UserId { get; init; }

    /// <summary>
    /// Account ID owning the order.
    /// </summary>
    [JsonPropertyName("account_id")]
    public required Guid AccountId { get; init; }

    /// <summary>
    /// The cash amount the planned order would invest, as a decimal string.
    /// </summary>
    [JsonPropertyName("cash_amount")]
    [RegularExpression("^[0-9]{1,9}(\\.[0-9]{2})?$")]
    public required string CashAmount { get; init; }

    /// <summary>
    /// The currency of the planned order, as an <see href="https://www.iso.org/iso-4217-currency-codes.html">ISO 4217</see> three-letter code.
    /// </summary>
    [JsonPropertyName("currency")]
    public required Currency Currency { get; init; }

    /// <summary>
    /// Whether the planned order buys or sells the instrument.
    /// * BUY — The order buys the instrument.
    /// * SELL — The order sells the instrument.
    /// </summary>
    [JsonPropertyName("side")]
    public required Side10 Side { get; init; }

    /// <summary>
    /// International securities identification number defined by <see href="https://en.wikipedia.org/wiki/International_Securities_Identification_Number">ISO 6166</see>.
    /// </summary>
    [JsonPropertyName("instrument_id")]
    [RegularExpression("^[A-Z]{2}[A-Z0-9]{9}[0-9]$")]
    public required string InstrumentId { get; init; }

    /// <summary>
    /// The kind of identifier given in <c>instrument_id</c>.
    /// * ISIN — International Securities Identification Number.
    /// </summary>
    [JsonPropertyName("instrument_id_type")]
    public string InstrumentIdType { get; } = "ISIN";

    /// <summary>
    /// How the planned order is priced.
    /// * MARKET — Executes at the best price available.
    /// * LIMIT — Executes only at the <c>limit_price</c> or better.
    /// * STOP — Becomes a market order once the <c>stop_price</c> is reached.
    /// </summary>
    [JsonPropertyName("order_type")]
    public required OrderType6 OrderType { get; init; }

    /// <summary>
    /// The unit of the savings plan interval.
    /// * WEEK — The interval is counted in weeks.
    /// * MONTH — The interval is counted in months.
    /// * YEAR — The interval is counted in years.
    /// </summary>
    [JsonPropertyName("period")]
    public required Period Period { get; init; }

    /// <summary>
    /// A whole number of units, as a string of digits.
    /// </summary>
    [JsonPropertyName("interval")]
    [RegularExpression("^[0-9]{1,63}$")]
    public required string Interval { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
