using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using UpvestInvestmentApi.Models.Enums;

namespace UpvestInvestmentApi.Models;

/// <summary>
/// Represents an account liquidation — a request to sell all investment positions in an account and convert the proceeds to cash. Contains references to each individual sell order.
/// </summary>
public record AccountLiquidation
{
    /// <summary>
    /// Universally Unique Identifier (UUID) of an account liquidation.
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
    /// ID of the user who owns the account. Exactly one of user_id or business_id will be set; the other will be null.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("user_id")]
    public Guid? UserId { get; init; }

    /// <summary>
    /// ID of the business that owns the account. Exactly one of user_id or business_id will be set; the other will be null.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("business_id")]
    public Guid? BusinessId { get; init; }

    /// <summary>
    /// Universally Unique Identifier (UUID) of the account.
    /// </summary>
    [JsonPropertyName("account_id")]
    public required Guid AccountId { get; init; }

    /// <summary>
    /// A positive decimal amount, as a string.
    /// </summary>
    [JsonPropertyName("cash_amount")]
    [RegularExpression("^[0-9]{0,63}(\\.[0-9]{1,27})?$")]
    public required string CashAmount { get; init; }

    /// <summary>
    /// Alphabetic three-letter <see href="https://www.iso.org/iso-4217-currency-codes.html">ISO 4217</see> currency code.
    /// * <c>EUR</c> — Euro.
    /// * <c>GBP</c> — Pound sterling.
    /// </summary>
    [JsonPropertyName("currency")]
    public required Currency185 Currency { get; init; }

    /// <summary>
    /// Execution status of the account liquidation.
    /// * <c>NEW</c> — The liquidation has been created and awaits processing.
    /// * <c>PROCESSING</c> — The liquidation orders are being executed.
    /// * <c>FILLED</c> — All liquidation orders have been fully executed.
    /// * <c>CANCELLED</c> — The liquidation was cancelled before completion.
    /// * <c>SETTLED</c> — The liquidation proceeds have settled as cash.
    /// </summary>
    [JsonPropertyName("status")]
    public required Status72 Status { get; init; }

    /// <summary>
    /// The individual position sell orders that make up this account liquidation.
    /// </summary>
    [JsonPropertyName("orders")]
    public required IReadOnlyList<AccountLiquidation1> Orders { get; init; }

    /// <summary>
    /// Identifier of the fee collection associated with this liquidation. Null when no fee applies. See the Fees API to retrieve fee details.
    /// </summary>
    [JsonPropertyName("fee_collection_id")]
    public required Guid? FeeCollectionId { get; init; }
}
