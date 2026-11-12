using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace UpvestInvestmentApi.Models;

/// <summary>
/// The trading venues at which price data is available for an instrument.
/// </summary>
public record InstrumentsVenuesResponse
{
    /// <summary>
    /// The trading venues available for the instrument.
    /// </summary>
    [JsonPropertyName("data")]
    public required IReadOnlyList<Venue> Data { get; init; }
}
