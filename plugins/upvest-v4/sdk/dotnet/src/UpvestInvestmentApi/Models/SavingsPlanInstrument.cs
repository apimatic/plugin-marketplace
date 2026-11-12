using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using UpvestInvestmentApi.Core.Validation.Attributes;
using UpvestInvestmentApi.Models.AnyOf;
using UpvestInvestmentApi.Models.Enums;

namespace UpvestInvestmentApi.Models;

/// <summary>
/// Represents an <c>INSTRUMENT</c>-type savings plan — a recurring investment that automatically buys a fixed cash amount of a specified instrument on a defined schedule.
/// </summary>
public record SavingsPlanInstrument
{
    /// <summary>
    /// Universally Unique Identifier (UUID) of a savings plan.
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
    /// Savings plan name
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("name")]
    public string? Name { get; init; }

    /// <summary>
    /// Type of the Savings plan.
    /// * PORTFOLIO -
    /// * INSTRUMENT -
    /// </summary>
    [JsonPropertyName("type")]
    public required Type67 Type { get; init; }

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
    /// A positive decimal amount, as a string.
    /// </summary>
    [JsonPropertyName("cash_amount")]
    [RegularExpression("^[0-9]{0,63}(\\.[0-9]{1,27})?$")]
    public required string CashAmount { get; init; }

    /// <summary>
    /// First date of the savings plan execution in YYYY-MM-DD format.
    /// </summary>
    [JsonPropertyName("start_date")]
    [RegularExpression("^[12]\\d{3}-(0[1-9]|1[0-2])-(0[1-9]|[12]\\d|3[01])$")]
    public required string StartDate { get; init; }

    /// <summary>
    /// Alphabetic three-letter <see href="https://www.iso.org/iso-4217-currency-codes.html">ISO 4217</see> currency code.
    /// * EUR — Euro.
    /// * GBP — Pound Sterling.
    /// </summary>
    [JsonPropertyName("currency")]
    public required Currency Currency { get; init; }

    /// <summary>
    /// Unit of time.
    /// * WEEK -
    /// * MONTH -
    /// * YEAR -
    /// </summary>
    [JsonPropertyName("period")]
    public required Period1 Period { get; init; }

    /// <summary>
    /// Number of periods between executions
    /// </summary>
    [JsonPropertyName("interval")]
    [Minimum(1)]
    [Maximum(1000)]
    public int Interval { get; init; } = 1;

    /// <summary>
    /// Status of a Savings Plan.
    /// * ACTIVE -
    /// * CANCELLED -
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("status")]
    public Status84? Status { get; init; }

    /// <summary>
    /// Fee configuration for instrument-type savings plan executions. Specifies the transaction fee model to apply to each buy order placed on execution.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("fee_configuration")]
    public IReadOnlyList<SavingsPlanFeeConfigurationOnlyForInstrument>? FeeConfiguration { get; init; }

    /// <summary>
    /// Funding configuration. <c>null</c> if the plan has no funding.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("funding")]
    public SavingsPlanFunding? Funding { get; init; }

    /// <summary>
    /// Explains the reason why the savings plan was cancelled .
    /// * CANCELLED_BY_CLIENT: The savings plan was cancelled by the client.
    /// * CANCELLED_BY_UPVEST: The savings plan was cancelled by Upvest.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("cancellation_reason")]
    public CancellationReasonCodeForSavingsPlan? CancellationReason { get; init; }

    /// <summary>
    /// Additional details about the cancellation
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("cancellation_details")]
    public string? CancellationDetails { get; init; }
}
