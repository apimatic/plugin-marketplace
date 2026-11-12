using System;
using UpvestInvestmentApi.Models.AnyOf;
using UpvestInvestmentApi.Models.Enums;

namespace UpvestInvestmentApi.Requests.PriceData;

/// <summary>
/// The inputs of the RetrieveInstrumentLatestPrice operation.
/// </summary>
public sealed record RetrieveInstrumentLatestPriceRequest
{
    /// <summary>
    /// The unique identifier of the instrument, provided as either an <c>isin:</c> URN or a <c>uuid:</c> URN.
    /// </summary>
    public required InstrumentUniqueIdentifier InstrumentId { get; init; }

    /// <summary>
    /// The unique identifier of the trading venue. Universally Unique Identifier (UUID).
    /// </summary>
    public required Guid VenueId { get; init; }

    public PriceQuality1 PriceQuality { get; init; } = PriceQuality1.HighestAvailable;

    /// <summary>
    /// Upvest API version (Note: Do not include quotation marks)
    /// </summary>
    public UpvestApiVersion UpvestApiVersion { get; init; } = UpvestApiVersion._1;
}
