using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace UpvestInvestmentApi.Models;

/// <summary>
/// Paginated list of end-of-day prices. Contains a <c>data</c> array of end-of-day price objects and a <c>meta</c> object with offset/limit pagination metadata.
/// </summary>
public record InstrumentsVenuesPricesOhlcResponse
{
    /// <summary>
    /// The end-of-day prices in this page of results.
    /// </summary>
    [JsonPropertyName("data")]
    public required IReadOnlyList<Datum8> Data { get; init; }

    /// <summary>
    /// Offset/limit pagination metadata for this page of results.
    /// </summary>
    [JsonPropertyName("meta")]
    public required Meta27 Meta { get; init; }
}
