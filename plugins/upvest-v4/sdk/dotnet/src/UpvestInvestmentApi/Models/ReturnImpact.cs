using System.Text.Json.Serialization;
using UpvestInvestmentApi.Core.Models;

namespace UpvestInvestmentApi.Models;

/// <summary>
/// The cumulative effect of the estimated costs on the investment return, shown for each year of the assumed holding period.
/// </summary>
public record ReturnImpact
{
    /// <summary>
    /// The effect of the estimated costs on the investment return for one year of the holding period, given both as a cash amount and as a percentage of the amount invested.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("year_one")]
    public ReturnImpactCost? YearOne { get; init; }

    /// <summary>
    /// The effect of the estimated costs on the investment return for one year of the holding period, given both as a cash amount and as a percentage of the amount invested.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("year_two")]
    public ReturnImpactCost? YearTwo { get; init; }

    /// <summary>
    /// The effect of the estimated costs on the investment return for one year of the holding period, given both as a cash amount and as a percentage of the amount invested.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("year_three")]
    public ReturnImpactCost? YearThree { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
