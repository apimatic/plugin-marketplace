using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using UpvestInvestmentApi.Models.Enums;

namespace UpvestInvestmentApi.Models;

/// <summary>
/// Request body for recording an incoming bank transaction against a virtual bank account.
/// </summary>
public record PaymentsBankTransactionCreateRequest
{
    [JsonPropertyName("account")]
    public required Account29 Account { get; init; }

    /// <summary>
    /// A positive cash amount, as a decimal string with up to two decimal places.
    /// </summary>
    [JsonPropertyName("amount")]
    [RegularExpression("^[0-9]{1,9}(\\.[0-9]{2})?$")]
    public required string Amount { get; init; }

    /// <summary>
    /// Alphabetic three-letter <see href="https://www.iso.org/iso-4217-currency-codes.html">ISO 4217</see> currency code
    /// </summary>
    [JsonPropertyName("currency")]
    public required BankTransactionCurrency Currency { get; init; }

    /// <summary>
    /// Information supplied to enable the matching/reconciliation of an entry with the items that the payment is intended to settle, such as commercial invoices in an accounts' receivable system, in an unstructured form.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("remittance_information")]
    [MaxLength(140)]
    [RegularExpression("^[0-9A-Za-z+?/\\-:()\\.,'; ]{0,140}$")]
    public string? RemittanceInformation { get; init; }

    /// <summary>
    /// Immutable reference to the API flow that initiated the order. For client initiated API flows, this is a client provided ID. For internal initiations, it is set to the ID of the related object.
    /// </summary>
    [JsonPropertyName("client_reference")]
    [MaxLength(35)]
    [RegularExpression("^[0-9A-Za-z+?/\\-:()\\.,'; ]{0,35}$")]
    public required string ClientReference { get; init; }

    /// <summary>
    /// The counterparty account owner
    /// </summary>
    [JsonPropertyName("counterparty_name")]
    [MaxLength(140)]
    [RegularExpression("^[0-9A-Za-z+?/\\-:()\\.,'; ]{0,140}$")]
    public required string CounterpartyName { get; init; }

    [JsonPropertyName("counterparty_account")]
    public required CounterpartyAccount CounterpartyAccount { get; init; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("counterparty_agent")]
    public CounterpartyAgent? CounterpartyAgent { get; init; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("virtual_bank_account_id")]
    public Guid? VirtualBankAccountId { get; init; }

    /// <summary>
    /// An optional parameter, which describes the purpose of the payment based on *ExternalPurpose1Code* from <see href="https://www.iso20022.org/catalogue-messages/additional-content-messages/external-code-sets">ISO 20022</see>.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("purpose_code")]
    [MaxLength(4)]
    public string? PurposeCode { get; init; }
}
