using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using UpvestInvestmentApi.Models.AnyOf;
using UpvestInvestmentApi.Models.Enums;

namespace UpvestInvestmentApi.Models;

public record Allocation
{
    [JsonPropertyName("instrument_id")]
    public required InstrumentId InstrumentId { get; init; }

    /// <summary>
    /// The type of the ID used in the request.
    /// * ISIN - International Securities Identification Number
    /// * UPVEST - UPVEST's unique instrument identifier
    /// </summary>
    [JsonPropertyName("instrument_id_type")]
    public InstrumentIdType4 InstrumentIdType { get; init; } = InstrumentIdType4.Isin;

    /// <summary>
    /// Instrument allocation weight
    /// </summary>
    [JsonPropertyName("weight")]
    [RegularExpression("^(100|[0-9]{1,2}(\\.[0-9]{1,5})?)$")]
    public required string Weight { get; init; }
}
