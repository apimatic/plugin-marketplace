using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using UpvestInvestmentApi.Models.AnyOf;
using UpvestInvestmentApi.Models.Enums;

namespace UpvestInvestmentApi.Models;

/// <summary>
/// Request body for placing a new order. Either <c>cash_amount</c> or <c>quantity</c> must be provided, not both. <c>account_id</c>, <c>side</c>, <c>instrument_id</c>, and <c>instrument_id_type</c> are always required.
/// </summary>
public record OrderPlaceRequest
{
    /// <summary>
    /// The ID of the user. Either user ID or business ID must be specified.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("user_id")]
    public Guid? UserId { get; init; }

    /// <summary>
    /// The ID of the business. Either user ID or business ID must be specified.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("business_id")]
    public Guid? BusinessId { get; init; }

    /// <summary>
    /// The ID of the account that owns the order
    /// </summary>
    [JsonPropertyName("account_id")]
    public required Guid AccountId { get; init; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("cash_amount")]
    [RegularExpression("^[0-9]{1,9}(\\.[0-9]{2})?$")]
    public string? CashAmount { get; init; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("currency")]
    public Currency29? Currency { get; init; }

    /// <summary>
    /// Side of the order.
    /// * BUY — purchases the specified instrument.
    /// * SELL — disposes of the specified instrument.
    /// </summary>
    [JsonPropertyName("side")]
    public required Side Side { get; init; }

    /// <summary>
    /// International securities identification number defined by <see href="https://en.wikipedia.org/wiki/International_Securities_Identification_Number">ISO 6166</see>.
    /// </summary>
    [JsonPropertyName("instrument_id")]
    [RegularExpression("^[A-Z]{2}[A-Z0-9]{9}[0-9]$")]
    public required string InstrumentId { get; init; }

    /// <summary>
    /// The type of the ID used in the request.
    /// * ISIN -
    /// </summary>
    [JsonPropertyName("instrument_id_type")]
    public string InstrumentIdType { get; } = "ISIN";

    /// <summary>
    /// Type of the order.
    /// * MARKET — executes immediately at the best available market price.
    /// * LIMIT — executes only at or better than the specified <c>limit_price</c>.
    /// * STOP — triggers when the market price reaches <c>stop_price</c>, then executes at the prevailing market price.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("order_type")]
    public OrderType? OrderType { get; init; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("quantity")]
    [RegularExpression("^[0-9]{0,63}(\\.[0-9]{1,27})?$")]
    public string? Quantity { get; init; }

    /// <summary>
    /// Only applicable if the user has failed the instrument fit check for the instrument type being ordered. True if the user has acknowledged their willingness to trade.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("user_instrument_fit_acknowledgement")]
    public bool? UserInstrumentFitAcknowledgement { get; init; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("limit_price")]
    [RegularExpression("^[0-9]{0,63}(\\.[0-9]{1,27})?$")]
    public string? LimitPrice { get; init; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("stop_price")]
    [RegularExpression("^[0-9]{0,63}(\\.[0-9]{1,27})?$")]
    public string? StopPrice { get; init; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("expiry_date")]
    [RegularExpression("^[0-9]{4}-[0-9]{2}-[0-9]{2}$")]
    public string? ExpiryDate { get; init; }

    /// <summary>
    /// Immutable reference to the API flow that initiated the order. For client initiated API flows, this is a client provided ID. For internal initiations, it is set to the ID of the related object.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("client_reference")]
    [MaxLength(100)]
    public string? ClientReference { get; init; }

    /// <summary>
    /// Execution flow for order processing. Defaults to <c>STRAIGHT_THROUGH</c> if not specified.
    /// * STRAIGHT_THROUGH — the order is routed and executed directly without manual intervention.
    /// * BLOCK — the order is bundled with other orders for block execution.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("execution_flow")]
    public ExecutionFlow? ExecutionFlow { get; init; }

    /// <summary>
    /// fee configuration
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("fee_configuration")]
    public IReadOnlyList<Fee>? FeeConfiguration { get; init; }

    /// <summary>
    /// ID of the user behind the decision to place the order, e.g. a guardian placing an order on a child account. Required only when the decision maker is not the <c>user_id</c> of the order, and must differ from it. The order is rejected if the decision maker holds no active role on the account that allows it.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("decision_maker_id")]
    public string? DecisionMakerId { get; init; }
}
