using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using UpvestInvestmentApi.Core.Models;
using UpvestInvestmentApi.Core.Validation.Attributes;
using UpvestInvestmentApi.Models.AnyOf;
using UpvestInvestmentApi.Models.Enums;

namespace UpvestInvestmentApi.Models;

/// <summary>
/// Request body for creating an <c>INSTRUMENT</c>-type savings plan. Specifies the account, instrument, cash amount, currency, schedule, and optional fee configuration.
/// </summary>
public record SavingsPlanInstrument3
{
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
    /// The type of savings plan must be "INSTRUMENT".
    /// </summary>
    [JsonPropertyName("type")]
    public string Type { get; init; } = "INSTRUMENT";

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
    /// Alphabetic three-letter <see href="https://www.iso.org/iso-4217-currency-codes.html">ISO 4217</see> currency code.
    /// * EUR — Euro.
    /// * GBP — Pound Sterling.
    /// </summary>
    [JsonPropertyName("currency")]
    public required Currency Currency { get; init; }

    /// <summary>
    /// First date of the savings plan execution in YYYY-MM-DD format.
    /// </summary>
    [JsonPropertyName("start_date")]
    [RegularExpression("^[12]\\d{3}-(0[1-9]|1[0-2])-(0[1-9]|[12]\\d|3[01])$")]
    public required string StartDate { get; init; }

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
    /// Fee configuration for instrument-type savings plan executions. Specifies the transaction fee model to apply to each buy order placed on execution.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("fee_configuration")]
    public IReadOnlyList<SavingsPlanFeeConfigurationOnlyForInstrument>? FeeConfiguration { get; init; }

    /// <summary>
    /// Funding configuration. Omit or pass <c>null</c> for a plan without funding.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("funding")]
    public SavingsPlanFunding? Funding { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
