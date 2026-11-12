using System.Collections.Generic;
using System.Text.Json.Serialization;
using UpvestInvestmentApi.Models.Enums;

namespace UpvestInvestmentApi.Models;

/// <summary>
/// The latest available price data for an instrument at a venue, comprising the current bids, asks, and last trade.
/// </summary>
public record InstrumentsVenuesPricesLatestResponse
{
    /// <summary>
    /// The quality of the price data returned.
    /// * REALTIME — Priced in real time.
    /// * DELAYED — Priced with a delay set by the data owner.
    /// </summary>
    [JsonPropertyName("price_quality")]
    public required PriceQuality2 PriceQuality { get; init; }

    /// <summary>
    /// Alphabetic three-letter <see href="https://www.iso.org/iso-4217-currency-codes.html">ISO 4217</see> currency code.
    /// * EUR — Euro.
    /// * GBP — Pound Sterling.
    /// * USD — The United States dollar.
    /// </summary>
    [JsonPropertyName("currency")]
    public required Currency1 Currency { get; init; }

    /// <summary>
    /// Bids for the instrument.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("bids")]
    public IReadOnlyList<Bid>? Bids { get; init; }

    /// <summary>
    /// Asks for the instrument.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("asks")]
    public IReadOnlyList<Ask>? Asks { get; init; }

    /// <summary>
    /// A single trade in an instrument, with the price and size at which it executed.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("last_trade")]
    public LastTrade? LastTrade { get; init; }
}
