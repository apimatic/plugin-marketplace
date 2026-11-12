using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using UpvestInvestmentApi.Core.Models;
using UpvestInvestmentApi.Models.Enums;

namespace UpvestInvestmentApi.Models;

/// <summary>
/// Ex Ante Order details for a business.
/// </summary>
public record ExAnteCostBusinessOrder
{
    /// <summary>
    /// The unique identifier of the business placing the order, as a UUID.
    /// </summary>
    [JsonPropertyName("business_id")]
    public required Guid BusinessId { get; init; }

    /// <summary>
    /// Account ID owning the order.
    /// </summary>
    [JsonPropertyName("account_id")]
    public required Guid AccountId { get; init; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("cash_amount")]
    [RegularExpression("^[0-9]{1,9}(\\.[0-9]{2})?$")]
    public string? CashAmount { get; init; }

    [JsonPropertyName("currency")]
    public required Currency Currency { get; init; }

    /// <summary>
    /// Whether the order buys or sells the instrument.
    /// * BUY — The order buys the instrument.
    /// * SELL — The order sells the instrument.
    /// </summary>
    [JsonPropertyName("side")]
    public required Side8 Side { get; init; }

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
    /// How the order is priced.
    /// * MARKET — Executes at the best price available.
    /// * LIMIT — Executes only at the <c>limit_price</c> or better.
    /// * STOP — Becomes a market order once the <c>stop_price</c> is reached.
    /// </summary>
    [JsonPropertyName("order_type")]
    public required OrderType4 OrderType { get; init; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("quantity")]
    [RegularExpression("^[0-9]{0,63}(\\.[0-9]{1,27})?$")]
    public string? Quantity { get; init; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("limit_price")]
    [RegularExpression("^[0-9]{0,63}(\\.[0-9]{1,27})?$")]
    public string? LimitPrice { get; init; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("stop_price")]
    [RegularExpression("^[0-9]{0,63}(\\.[0-9]{1,27})?$")]
    public string? StopPrice { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
