using System;
using System.Text.Json.Serialization;
using UpvestInvestmentApi.Core.Models;
using UpvestInvestmentApi.Models.Enums;

namespace UpvestInvestmentApi.Models;

/// <summary>
/// Instrument fit check is completed by the client providing the user's answers to the instrument appropriateness or suitability questionnaire.
/// </summary>
public record UserCheckInstrumentFit
{
    /// <summary>
    /// User Check unique identifier.
    /// </summary>
    [JsonPropertyName("id")]
    public required Guid Id { get; init; }

    /// <summary>
    /// Unique identifier of the user, as a UUID.
    /// </summary>
    [JsonPropertyName("user_id")]
    public required Guid UserId { get; init; }

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
    /// Final status of the instrument fit check.
    /// * IN_PROGRESS - Instrument fit check is in progress
    /// * PASSED - Instrument fit check passed
    /// * FAILED - Instrument fit check failed
    /// </summary>
    [JsonPropertyName("status")]
    public required Status8 Status { get; init; }

    /// <summary>
    /// Outcome of the user's instrument suitability assessment.
    /// </summary>
    [JsonPropertyName("instrument_suitability")]
    public required InstrumentSuitability InstrumentSuitability { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
