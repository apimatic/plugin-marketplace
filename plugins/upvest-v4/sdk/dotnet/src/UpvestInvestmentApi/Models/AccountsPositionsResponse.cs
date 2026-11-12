using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace UpvestInvestmentApi.Models;

/// <summary>
/// The account's holding of a specific instrument, including the total quantity and how much of it is locked for trading, pending settlement, available for trading, available for instruction, or settled.
/// </summary>
public record AccountsPositionsResponse
{
    /// <summary>
    /// Universally Unique Identifier (UUID) of the account.
    /// </summary>
    [JsonPropertyName("account_id")]
    public required Guid AccountId { get; init; }

    /// <summary>
    /// The instrument this position is held in, identified by its <c>uuid</c> and, if assigned, its <c>isin</c>.
    /// </summary>
    [JsonPropertyName("instrument")]
    public required Instrument Instrument { get; init; }

    [JsonPropertyName("quantity")]
    [RegularExpression("^-?[0-9]{0,63}(\\.[0-9]{1,27})?$")]
    public required string Quantity { get; init; }

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

    [JsonPropertyName("available_for_trading")]
    [RegularExpression("^-?[0-9]{0,63}(\\.[0-9]{1,27})?$")]
    public required string AvailableForTrading { get; init; }

    [JsonPropertyName("available_for_instruction")]
    [RegularExpression("^-?[0-9]{0,63}(\\.[0-9]{1,27})?$")]
    public required string AvailableForInstruction { get; init; }

    /// <summary>
    /// A positive decimal amount, as a string.
    /// </summary>
    [JsonPropertyName("settled_quantity")]
    [RegularExpression("^[0-9]{0,63}(\\.[0-9]{1,27})?$")]
    public required string SettledQuantity { get; init; }
}
