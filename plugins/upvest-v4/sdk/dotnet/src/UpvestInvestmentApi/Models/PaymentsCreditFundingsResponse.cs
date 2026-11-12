using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using UpvestInvestmentApi.Models.Enums;

namespace UpvestInvestmentApi.Models;

/// <summary>
/// Represents an incoming SEPA Credit Transfer received by Upvest and credited to an account group. Contains counterparty identification and remittance details from the sender's bank.
/// </summary>
public record PaymentsCreditFundingsResponse
{
    /// <summary>
    /// Credit Funding request unique identifier
    /// </summary>
    [JsonPropertyName("id")]
    public required Guid Id { get; init; }

    /// <summary>
    /// Date and time when the resource was created. <see href="https://datatracker.ietf.org/doc/html/rfc3339#section-5.6">RFC 3339-5</see>, <see href="https://www.iso.org/iso-8601-date-and-time-format.html">ISO8601 UTC</see>
    /// </summary>
    [JsonPropertyName("created_at")]
    public required DateTimeOffset CreatedAt { get; init; }

    /// <summary>
    /// Universally Unique Identifier (UUID) of the account group.
    /// </summary>
    [JsonPropertyName("account_group_id")]
    public required Guid AccountGroupId { get; init; }

    /// <summary>
    /// A positive cash amount, as a decimal string with up to two decimal places.
    /// </summary>
    [JsonPropertyName("cash_amount")]
    [RegularExpression("^[0-9]{1,9}(\\.[0-9]{2})?$")]
    public required string CashAmount { get; init; }

    /// <summary>
    /// Alphabetic three-letter <see href="https://www.iso.org/iso-4217-currency-codes.html">ISO 4217</see> currency code.
    /// * EUR — Euro.
    /// * GBP — Pound Sterling.
    /// </summary>
    [JsonPropertyName("currency")]
    public required Currency Currency { get; init; }

    /// <summary>
    /// Status of the credit funding
    /// * CONFIRMED - Credit Funding was confirmed.
    /// * CANCELLED - Credit Funding was cancelled.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("status")]
    public Status32? Status { get; init; }

    /// <summary>
    /// Payment reference the one that was used by the end user for the corresponding SEPA Credit Transfer
    /// </summary>
    [JsonPropertyName("remittance_information")]
    public required string RemittanceInformation { get; init; }

    [JsonPropertyName("counterparty")]
    public required Counterparty Counterparty { get; init; }

    /// <summary>
    /// Virtual bank account request unique identifier.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("virtual_bank_account_id")]
    public Guid? VirtualBankAccountId { get; init; }

    /// <summary>
    /// Purpose of the payment based on *ExternalPurpose1Code* from <see href="https://www.iso20022.org/catalogue-messages/additional-content-messages/external-code-sets">ISO 20022</see>.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("purpose_code")]
    [MaxLength(4)]
    public string? PurposeCode { get; init; }
}
