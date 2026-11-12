using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using UpvestInvestmentApi.Core.Models;
using UpvestInvestmentApi.Models.Enums;

namespace UpvestInvestmentApi.Models;

/// <summary>
/// Tax deducted as part of a payment (e.g. a withdrawal). Contains the tax type and the deducted amount in the specified currency.
/// </summary>
public record Tax
{
    [JsonPropertyName("amount")]
    [RegularExpression("^-?[0-9]{0,63}(\\.[0-9]{1,27})?$")]
    public required string Amount { get; init; }

    /// <summary>
    /// Alphabetic three-letter <see href="https://www.iso.org/iso-4217-currency-codes.html">ISO 4217</see> currency code.
    /// * EUR — Euro.
    /// * GBP — Pound Sterling.
    /// </summary>
    [JsonPropertyName("currency")]
    public required Currency Currency { get; init; }

    /// <summary>
    /// Type of the tax.
    /// * TOTAL - Total taxes
    /// </summary>
    [JsonPropertyName("type")]
    public string Type { get; } = "TOTAL";

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
