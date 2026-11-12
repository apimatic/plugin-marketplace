using System;
using System.Text.Json.Serialization;
using UpvestInvestmentApi.Core.Models;

namespace UpvestInvestmentApi.Models;

/// <summary>
/// Instrument fit check is completed by the client providing the user's answers to the instrument appropriateness or suitability questionnaire.
/// </summary>
public record UserCheckInstrumentFitCreateRequest
{
    /// <summary>
    /// The type of check must be INSTRUMENT_FIT.
    /// </summary>
    [JsonPropertyName("type")]
    public string Type { get; init; } = "INSTRUMENT_FIT";

    /// <summary>
    /// Completion date and time of the instrument fit check.
    /// </summary>
    [JsonPropertyName("check_confirmed_at")]
    public required DateTimeOffset CheckConfirmedAt { get; init; }

    /// <summary>
    /// Outcome of the user's instrument suitability assessment.
    /// </summary>
    [JsonPropertyName("instrument_suitability")]
    public required InstrumentSuitability InstrumentSuitability { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
