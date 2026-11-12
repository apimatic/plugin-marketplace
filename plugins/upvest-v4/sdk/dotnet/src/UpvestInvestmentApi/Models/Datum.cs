using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using UpvestInvestmentApi.Models.Enums;

namespace UpvestInvestmentApi.Models;

/// <summary>
/// The account group's cash balance for a single currency, broken down into the total amount and how much of it is locked for trading, pending settlement, available for withdrawal, or available for trading.
/// </summary>
public record Datum
{
    /// <summary>
    /// Universally Unique Identifier (UUID) of the account group.
    /// </summary>
    [JsonPropertyName("account_group_id")]
    public required Guid AccountGroupId { get; init; }

    /// <summary>
    /// Alphabetic three-letter <see href="https://www.iso.org/iso-4217-currency-codes.html">ISO 4217</see> currency code.
    /// * EUR — Euro.
    /// * GBP — Pound Sterling.
    /// * USD — The United States dollar.
    /// </summary>
    [JsonPropertyName("currency")]
    public required Currency1 Currency { get; init; }

    [JsonPropertyName("balance")]
    [RegularExpression("^-?[0-9]{0,63}(\\.[0-9]{1,27})?$")]
    public required string Balance { get; init; }

    /// <summary>
    /// A positive decimal amount, as a string.
    /// </summary>
    [JsonPropertyName("locked_for_trading")]
    [RegularExpression("^[0-9]{0,63}(\\.[0-9]{1,27})?$")]
    public required string LockedForTrading { get; init; }

    /// <summary>
    /// A positive decimal amount, as a string.
    /// </summary>
    [JsonPropertyName("pending_settlement")]
    [RegularExpression("^[0-9]{0,63}(\\.[0-9]{1,27})?$")]
    public required string PendingSettlement { get; init; }

    [JsonPropertyName("available_for_withdrawal")]
    [RegularExpression("^-?[0-9]{0,63}(\\.[0-9]{1,27})?$")]
    public required string AvailableForWithdrawal { get; init; }

    [JsonPropertyName("available_for_trading")]
    [RegularExpression("^-?[0-9]{0,63}(\\.[0-9]{1,27})?$")]
    public required string AvailableForTrading { get; init; }
}
