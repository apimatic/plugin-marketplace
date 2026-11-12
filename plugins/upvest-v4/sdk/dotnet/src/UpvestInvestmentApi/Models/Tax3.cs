using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using UpvestInvestmentApi.Core.Models;

namespace UpvestInvestmentApi.Models;

/// <summary>
/// Tax deducted as part of an order execution. Contains the tax type and the deducted amount.
/// </summary>
public record Tax3
{
    /// <summary>
    /// Tax type
    /// * TOTAL -
    /// </summary>
    [JsonPropertyName("type")]
    public string Type { get; } = "TOTAL";

    /// <summary>
    /// A positive decimal amount, as a string.
    /// </summary>
    [JsonPropertyName("amount")]
    [RegularExpression("^[0-9]{0,63}(\\.[0-9]{1,27})?$")]
    public required string Amount { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
