using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using UpvestInvestmentApi.Models.Enums;

namespace UpvestInvestmentApi.Models;

/// <summary>
/// Request body for creating a cash balance transfer between two account groups belonging to the same user and tenant.
/// </summary>
public record PaymentsCashBalanceTransferCreateRequest
{
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
}
