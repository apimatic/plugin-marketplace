using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using UpvestInvestmentApi.Models.Enums;

namespace UpvestInvestmentApi.Models;

/// <summary>
/// Request body for initiating a SEPA Direct Debit. Requires a valid <c>mandate_id</c> and the <c>account_group_id</c> of the account group to receive the funds.
/// </summary>
public record PaymentsDirectDebitCreateRequest
{
    /// <summary>
    /// The ID of the user. This field is optional and will be removed in a future version.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("user_id")]
    public Guid? UserId { get; init; }

    /// <summary>
    /// Universally Unique Identifier (UUID) of the account group.
    /// </summary>
    [JsonPropertyName("account_group_id")]
    public required Guid AccountGroupId { get; init; }

    /// <summary>
    /// Direct Debit Mandate unique identifier.
    /// </summary>
    [JsonPropertyName("mandate_id")]
    public required Guid MandateId { get; init; }

    [JsonPropertyName("cash_amount")]
    [RegularExpression("^-?[0-9]{1,9}(\\.[0-9]{2})?$")]
    public required string CashAmount { get; init; }

    /// <summary>
    /// Alphabetic three-letter <see href="https://www.iso.org/iso-4217-currency-codes.html">ISO 4217</see> currency code.
    /// * EUR — Euro.
    /// * GBP — Pound Sterling.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("currency")]
    public Currency? Currency { get; init; }

    /// <summary>
    /// Payment reference the end user will see in their bank statement for the corresponding direct debit booking (“Verwendungszweck”). We recommend that you keep this info concise and avoid special characters or non-standardised formatting (<see href="/documentation/guides/payments/direct_debit/direct_debit_submitting">see more</see>).
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("remittance_information")]
    [MaxLength(140)]
    [RegularExpression("^[0-9A-Za-z+?/\\-:()\\.,';_ ]{0,140}$")]
    public string? RemittanceInformation { get; init; }

    /// <summary>
    /// Purpose of the payment based on *ExternalPurpose1Code* from <see href="https://www.iso20022.org/catalogue-messages/additional-content-messages/external-code-sets">ISO 20022</see>.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("purpose_code")]
    [MaxLength(4)]
    public string? PurposeCode { get; init; }
}
