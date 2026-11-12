using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using UpvestInvestmentApi.Core.Models;
using UpvestInvestmentApi.Models.Enums;

namespace UpvestInvestmentApi.Models;

/// <summary>
/// The planned order whose costs this report estimates.
/// </summary>
public record Order57
{
    /// <summary>
    /// The unique identifier of the business placing the order, as a UUID.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("business_id")]
    public Guid? BusinessId { get; init; }

    /// <summary>
    /// The ID of the account that owns the order.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("account_id")]
    public Guid? AccountId { get; init; }

    /// <summary>
    /// The cash amount the planned order would invest, as a decimal string.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("cash_amount")]
    [RegularExpression("^[0-9]{1,9}(\\.[0-9]{2})?$")]
    public string? CashAmount { get; init; }

    /// <summary>
    /// The currency of the planned order, as an <see href="https://www.iso.org/iso-4217-currency-codes.html">ISO 4217</see> three-letter code.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("currency")]
    public Currency? Currency { get; init; }

    /// <summary>
    /// Whether the planned order buys or sells the instrument.
    /// * BUY — The order buys the instrument.
    /// * SELL — The order sells the instrument.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("side")]
    public Side10? Side { get; init; }

    /// <summary>
    /// International securities identification number defined by <see href="https://en.wikipedia.org/wiki/International_Securities_Identification_Number">ISO 6166</see>.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("instrument_id")]
    [RegularExpression("^[A-Z]{2}[A-Z0-9]{9}[0-9]$")]
    public string? InstrumentId { get; init; }

    /// <summary>
    /// The kind of identifier given in <c>instrument_id</c>.
    /// * ISIN — International Securities Identification Number.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("instrument_id_type")]
    public InstrumentIdType? InstrumentIdType { get; init; } = InstrumentIdType.Isin;

    /// <summary>
    /// How the planned order is priced.
    /// * MARKET — Executes at the best price available.
    /// * LIMIT — Executes only at the <c>limit_price</c> or better.
    /// * STOP — Becomes a market order once the <c>stop_price</c> is reached.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("order_type")]
    public OrderType6? OrderType { get; init; }

    /// <summary>
    /// The number of units the planned order would buy or sell, as a decimal string.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("quantity")]
    [RegularExpression("^[0-9]{0,63}(\\.[0-9]{1,27})?$")]
    public string? Quantity { get; init; }

    /// <summary>
    /// The limit price of the planned order, as a decimal string. Applies to <c>LIMIT</c> orders.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("limit_price")]
    [RegularExpression("^[0-9]{0,63}(\\.[0-9]{1,27})?$")]
    public string? LimitPrice { get; init; }

    /// <summary>
    /// The stop price of the planned order, as a decimal string. Applies to <c>STOP</c> orders.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("stop_price")]
    [RegularExpression("^[0-9]{0,63}(\\.[0-9]{1,27})?$")]
    public string? StopPrice { get; init; }

    /// <summary>
    /// The price used to estimate the costs of the planned order, as a decimal string.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("price")]
    [RegularExpression("^[0-9]{0,63}(\\.[0-9]{1,27})?$")]
    public string? Price { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
