using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using UpvestInvestmentApi.Models.Enums;

namespace UpvestInvestmentApi.Models;

/// <summary>
/// The effect of the estimated costs on the investment return for one year of the holding period, given both as a cash amount and as a percentage of the amount invested.
/// </summary>
public record ReturnImpactCost
{
    /// <summary>
    /// A positive cash amount, as a decimal string with up to two decimal places.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("cash_amount")]
    [RegularExpression("^[0-9]{1,9}(\\.[0-9]{2})?$")]
    public string? CashAmount { get; init; }

    /// <summary>
    /// Alphabetic three-letter <see href="https://www.iso.org/iso-4217-currency-codes.html">ISO 4217</see> currency code.
    /// * EUR — Euro.
    /// * GBP — Pound Sterling.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("currency")]
    public Currency? Currency { get; init; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("as_percentage")]
    [RegularExpression("^-?[0-9]{0,63}(\\.[0-9]{1,27})?$")]
    public string? AsPercentage { get; init; }

    /// <summary>
    /// Breakdown of the figure into entry, ongoing and exit costs, one item per category.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("details")]
    public IReadOnlyList<CostDetail>? Details { get; init; }
}
