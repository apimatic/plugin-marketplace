using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using UpvestInvestmentApi.Models.Enums;

namespace UpvestInvestmentApi.Models;

/// <summary>
/// Represents a SEPA Direct Debit funding request for an account group. Debits are initiated via a mandate and transition through <c>NEW</c> → <c>PROCESSING</c> → <c>CONFIRMED</c> or <c>CANCELLED</c> as they are processed.
/// </summary>
public record Datum2
{
    /// <summary>
    /// Direct debit funding request unique identifier
    /// </summary>
    [JsonPropertyName("id")]
    public required Guid Id { get; init; }

    /// <summary>
    /// Date and time when the resource was created. <see href="https://datatracker.ietf.org/doc/html/rfc3339#section-5.6">RFC 3339-5</see>, <see href="https://www.iso.org/iso-8601-date-and-time-format.html">ISO8601 UTC</see>
    /// </summary>
    [JsonPropertyName("created_at")]
    public required DateTimeOffset CreatedAt { get; init; }

    /// <summary>
    /// The ID of the user. For business-initiated direct debits, this field will be absent.
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
    [JsonPropertyName("currency")]
    public required Currency Currency { get; init; }

    /// <summary>
    /// Payment reference the end user will see in their bank statement for the corresponding direct debit booking (“Verwendungszweck”). We recommend that you keep this info concise and avoid special characters or non-standardised formatting (<see href="/documentation/guides/payments/direct_debit/direct_debit_submitting">see more</see>).
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("remittance_information")]
    [MaxLength(140)]
    [RegularExpression("^[0-9A-Za-z+?/\\-:()\\.,';_ ]{0,140}$")]
    public string? RemittanceInformation { get; init; }

    /// <summary>
    /// Status of the direct debit
    /// * NEW - Direct debit is created but not started processing.
    /// * PROCESSING - Direct debit is in processing.
    /// * CONFIRMED - Direct debit was successfully processed.
    /// * CANCELLED - Direct debit was cancelled.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("status")]
    public Status26? Status { get; init; }

    /// <summary>
    /// Reason the direct debit was cancelled. The field is present in case the direct debit has a status of CANCELLED.
    /// * CANCELLED_BY_BANK - The payment was not completed by your bank. Please check your account details or contact support.
    /// * CANCELLED_BY_UPVEST - The payment was cancelled. Contact support for details.
    /// * CANCELLED_BY_CLIENT - The payment was cancelled at your request.
    /// * OTHER - Reason not available (applies to historical data only).
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("cancellation_reason")]
    public CancellationReasonCodeForDirectDebit? CancellationReason { get; init; }

    /// <summary>
    /// Purpose of the payment based on *ExternalPurpose1Code* from <see href="https://www.iso20022.org/catalogue-messages/additional-content-messages/external-code-sets">ISO 20022</see>.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("purpose_code")]
    [MaxLength(4)]
    public string? PurposeCode { get; init; }
}
