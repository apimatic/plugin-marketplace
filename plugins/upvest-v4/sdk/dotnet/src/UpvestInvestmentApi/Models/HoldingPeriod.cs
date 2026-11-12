using System.Text.Json.Serialization;
using UpvestInvestmentApi.Core.Models;
using UpvestInvestmentApi.Models.Enums;

namespace UpvestInvestmentApi.Models;

/// <summary>
/// The holding period assumed when estimating the costs in this report. Costs are projected on the basis that the instrument is held for this period before being sold.
/// </summary>
public record HoldingPeriod
{
    /// <summary>
    /// The unit in which the holding period is counted.
    /// * YEAR — The holding period is counted in years.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("unit")]
    public Unit? Unit { get; init; } = Unit.Year;

    /// <summary>
    /// The number of holding period units assumed, for example 3 for a three-year holding period.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("quantity")]
    public int? Quantity { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
