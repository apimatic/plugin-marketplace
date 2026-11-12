using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using UpvestInvestmentApi.Core.Models;

namespace UpvestInvestmentApi.Models;

/// <summary>
/// A single tier of a transaction fee model with a fixed, absolute cash amount.
/// </summary>
public record AbsoluteTransactionFeeTier
{
    /// <summary>
    /// Unique identifier of the fee tier within the transaction fee model. A numeric string of up to 63 digits.
    /// </summary>
    [JsonPropertyName("tier_id")]
    [RegularExpression("^[0-9]{1,63}$")]
    public required string TierId { get; init; }

    /// <summary>
    /// A positive decimal amount, as a string.
    /// </summary>
    [JsonPropertyName("base_amount_from")]
    [RegularExpression("^[0-9]{0,63}(\\.[0-9]{1,27})?$")]
    public required string BaseAmountFrom { get; init; }

    /// <summary>
    /// A positive decimal amount, as a string.
    /// </summary>
    [JsonPropertyName("fee_amount")]
    [RegularExpression("^[0-9]{0,63}(\\.[0-9]{1,27})?$")]
    public required string FeeAmount { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
