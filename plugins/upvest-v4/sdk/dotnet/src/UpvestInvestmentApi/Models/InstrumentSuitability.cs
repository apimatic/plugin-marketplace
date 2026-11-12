using System.Text.Json.Serialization;
using UpvestInvestmentApi.Core.Models;

namespace UpvestInvestmentApi.Models;

/// <summary>
/// Outcome of the user's instrument suitability assessment.
/// </summary>
public record InstrumentSuitability
{
    /// <summary>
    /// Did the user go through a suitability assessment and the outcome indicated suitability.
    /// </summary>
    [JsonPropertyName("suitability")]
    public required bool Suitability { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
