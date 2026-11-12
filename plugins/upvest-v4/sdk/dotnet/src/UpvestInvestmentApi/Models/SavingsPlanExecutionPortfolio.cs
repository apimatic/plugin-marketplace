using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using UpvestInvestmentApi.Core.Models;
using UpvestInvestmentApi.Models.AnyOf;
using UpvestInvestmentApi.Models.Enums;

namespace UpvestInvestmentApi.Models;

/// <summary>
/// Represents a single execution of a <c>PORTFOLIO</c>-type savings plan, recording the portfolio order placed, the execution date, and the resulting status.
/// </summary>
public record SavingsPlanExecutionPortfolio
{
    /// <summary>
    /// Universally Unique Identifier (UUID) of a savings plan execution.
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
    [JsonPropertyName("user_id")]
    public required Guid UserId { get; init; }

    /// <summary>
    /// Universally Unique Identifier (UUID) of the account.
    /// </summary>
    [JsonPropertyName("account_id")]
    public required Guid AccountId { get; init; }

    /// <summary>
    /// Universally Unique Identifier (UUID) of a savings plan.
    /// </summary>
    [JsonPropertyName("savings_plan_id")]
    public required Guid SavingsPlanId { get; init; }

    /// <summary>
    /// Order unique identifier (Portfolio order or Instrument order)
    /// </summary>
    [JsonPropertyName("order_id")]
    public required OrderUniqueIdentifierPortfolioOrderOrInstrumentOrder? OrderId { get; init; }

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
    /// Status of a Savings Plan Execution.
    /// * NEW -
    /// * PROCESSING -
    /// * FILLED -
    /// * SETTLED -
    /// * CANCELLED -
    /// </summary>
    [JsonPropertyName("status")]
    public required Status90 Status { get; init; }

    /// <summary>
    /// The type of savings plan must be "PORTFOLIO".
    /// </summary>
    [JsonPropertyName("type")]
    public string Type { get; init; } = "PORTFOLIO";

    /// <summary>
    /// Date of a savings plan execution in YYYY-MM-DD format.
    /// </summary>
    [JsonPropertyName("execution_date")]
    [RegularExpression("^[12]\\d{3}-(0[1-9]|1[0-2])-(0[1-9]|[12]\\d|3[01])$")]
    public required string ExecutionDate { get; init; }

    /// <summary>
    /// Instrument unique identifier.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("instrument_id")]
    public InstrumentUniqueIdentifier5? InstrumentId { get; init; }

    /// <summary>
    /// The type of the ID used in the request.
    /// * ISIN - International Securities Identification Number
    /// * WKN - German securities identification code
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("instrument_id_type")]
    public InstrumentIdType10? InstrumentIdType { get; init; } = InstrumentIdType10.Isin;

    /// <summary>
    /// Funding of this execution. <c>null</c> if the execution is not funded.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("funding")]
    public SavingsPlanExecutionFunding? Funding { get; init; }

    /// <summary>
    /// Explains the reason why the savings plan execution was cancelled .
    /// * CANCELLED_BY_CLIENT: The savings plan execution was cancelled by the client.
    /// * CANCELLED_BY_UPVEST: The savings plan execution was cancelled by Upvest.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("cancellation_reason")]
    public CancellationReasonCodeForSavingsPlanExecution? CancellationReason { get; init; }

    /// <summary>
    /// Human-readable description providing additional context about why the savings plan execution was cancelled.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("cancellation_details")]
    public string? CancellationDetails { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
