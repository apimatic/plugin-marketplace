using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using UpvestInvestmentApi.Models.AnyOf;
using UpvestInvestmentApi.Models.Enums;

namespace UpvestInvestmentApi.Models;

/// <summary>
/// Represents an investment order placed by an end user or on their behalf. An order transitions through states (<c>NEW</c> → <c>PROCESSING</c> → <c>FILLED</c> or <c>CANCELLED</c>) as it is routed and executed.
/// </summary>
public record Order39
{
    /// <summary>
    /// Unique identifier for an order. Universally Unique Identifier (UUID).
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

    [JsonPropertyName("cash_amount")]
    [RegularExpression("^[0-9]{1,9}(\\.[0-9]{2})?$")]
    public required string CashAmount { get; init; }

    [JsonPropertyName("currency")]
    public required Currency29 Currency { get; init; }

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
    [JsonPropertyName("order_type")]
    public required OrderType OrderType { get; init; }

    [JsonPropertyName("quantity")]
    [RegularExpression("^[0-9]{0,63}(\\.[0-9]{1,27})?$")]
    public required string Quantity { get; init; }

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
    /// The execution status of the order.
    /// * NEW — the order has been received and validated, awaiting routing.
    /// * PROCESSING — the order is being routed for execution.
    /// * FILLED — the order has been fully executed.
    /// * CANCELLED — the order was cancelled before being fully executed.
    /// </summary>
    [JsonPropertyName("status")]
    public required Status51 Status { get; init; }

    /// <summary>
    /// A positive decimal amount, as a string.
    /// </summary>
    [JsonPropertyName("fee")]
    [RegularExpression("^[0-9]{0,63}(\\.[0-9]{1,27})?$")]
    public required string Fee { get; init; }

    /// <summary>
    /// Reason for order cancellation. Present only when <c>status</c> is <c>CANCELLED</c>.
    /// * CANCELLED_BY_CLIENT — cancelled at the end user's or client's request via the API.
    /// * CANCELLED_BY_UPVEST_OPERATIONS — cancelled by Upvest operations.
    /// * CANCELLED_BY_TRADING_PARTNER — cancelled by the executing partner.
    /// * CANCELLED_BY_UPVEST_PLATFORM — cancelled automatically by the Upvest platform.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("cancellation_reason")]
    public CancellationReason? CancellationReason { get; init; }

    /// <summary>
    /// Identifies what triggered the order.
    /// * API — initiated directly via the client API.
    /// * PORTFOLIO — initiated by a portfolio order.
    /// * CASH_DIVIDEND_REINVESTMENT — initiated as part of dividend reinvestment.
    /// * PORTFOLIO_REBALANCING — initiated by an automated rebalancing.
    /// * SELL_TO_COVER_FEES — initiated automatically to cover outstanding fees.
    /// * SELL_TO_COVER_TAXES — initiated automatically to cover tax obligations.
    /// * ACCOUNT_LIQUIDATION — initiated as part of an account liquidation.
    /// * UPVEST_OPERATIONS — initiated by Upvest operations.
    /// * SAVINGS_PLAN — initiated by a savings plan execution.
    /// * CLIENT_OPERATIONS — initiated by client operations.
    /// * AUTO_INVESTMENT — initiated automatically by auto-investment to invest incoming cash, for example a cash dividend.
    /// * PORTFOLIO_SAVINGS_PLAN — initiated by a savings plan execution for a portfolio.
    /// * PORTFOLIO_AUTO_INVESTMENT — initiated by a portfolio order that auto-investment created to invest incoming cash, for example a cash dividend.
    /// </summary>
    [JsonPropertyName("initiation_flow")]
    public required InitiationFlow InitiationFlow { get; init; }

    /// <summary>
    /// Execution flow for order processing. Defaults to <c>STRAIGHT_THROUGH</c> if not specified.
    /// * STRAIGHT_THROUGH — the order is routed and executed directly without manual intervention.
    /// * BLOCK — the order is bundled with other orders for block execution.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("execution_flow")]
    public ExecutionFlow? ExecutionFlow { get; init; }

    /// <summary>
    /// Order executions associated with this order
    /// </summary>
    [JsonPropertyName("executions")]
    public required IReadOnlyList<OrderExecution> Executions { get; init; }

    /// <summary>
    /// Immutable reference to the API flow that initiated the order. For client initiated API flows, this is a client provided ID. For internal initiations, it is set to the ID of the related object.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("client_reference")]
    [MaxLength(100)]
    public string? ClientReference { get; init; }

    /// <summary>
    /// Fee configuration applied to this order. Determines how the order fee is calculated.
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
