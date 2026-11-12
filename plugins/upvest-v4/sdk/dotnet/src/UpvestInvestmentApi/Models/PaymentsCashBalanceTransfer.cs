using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using UpvestInvestmentApi.Models.Enums;

namespace UpvestInvestmentApi.Models;

/// <summary>
/// Represents an internal cash balance transfer between two account groups belonging to the same user and tenant. Only settled cash in the same currency can be transferred.
/// </summary>
public record PaymentsCashBalanceTransfer
{
    /// <summary>
    /// Cash balance transfer unique identifier
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
    /// The account group the cash is transferred from. Must differ from <c>target_account_group_id</c> and belong to the same user and tenant. Allowed account group types are <c>PERSONAL</c>, <c>CHILD</c>, and <c>BUSINESS</c>, and the source and target account groups must be of the same type.
    /// </summary>
    [JsonPropertyName("source_account_group_id")]
    public required Guid SourceAccountGroupId { get; init; }

    /// <summary>
    /// The account group the cash is transferred to. Must differ from <c>source_account_group_id</c> and belong to the same user and tenant. Allowed account group types are <c>PERSONAL</c>, <c>CHILD</c>, and <c>BUSINESS</c>, and the source and target account groups must be of the same type.
    /// </summary>
    [JsonPropertyName("target_account_group_id")]
    public required Guid TargetAccountGroupId { get; init; }

    /// <summary>
    /// A positive cash amount, as a decimal string with up to two decimal places.
    /// </summary>
    [JsonPropertyName("amount")]
    [RegularExpression("^[0-9]{1,9}(\\.[0-9]{2})?$")]
    public required string Amount { get; init; }

    /// <summary>
    /// Alphabetic three-letter <see href="https://www.iso.org/iso-4217-currency-codes.html">ISO 4217</see> currency code.
    /// * EUR — Euro.
    /// * GBP — Pound Sterling.
    /// </summary>
    [JsonPropertyName("currency")]
    public required Currency Currency { get; init; }

    /// <summary>
    /// Status of the cash balance transfer.
    /// * ISSUED - Transfer has been created and the cash movement is in progress.
    /// * CONFIRMED - Cash was successfully moved from the source to the target account group.
    /// * CANCELLED - Transfer was cancelled and no cash was moved.
    /// </summary>
    [JsonPropertyName("status")]
    public required Status37 Status { get; init; }

    /// <summary>
    /// Reason the transfer was cancelled. Present only when <c>status</c> is <c>CANCELLED</c>, otherwise <c>null</c>.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("cancellation_reason")]
    public string? CancellationReason { get; init; }
}
