using System;
using System.ComponentModel.DataAnnotations;
using UpvestInvestmentApi.Models.AnyOf;
using UpvestInvestmentApi.Models.Enums;

namespace UpvestInvestmentApi.Requests.PriceData;

/// <summary>
/// The inputs of the RetrieveInstrumentPricesOhlc operation.
/// </summary>
public sealed record RetrieveInstrumentPricesOhlcRequest
{
    /// <summary>
    /// The unique identifier of the instrument, provided as either an <c>isin:</c> URN or a <c>uuid:</c> URN.
    /// </summary>
    public required InstrumentUniqueIdentifier InstrumentId { get; init; }

    /// <summary>
    /// The unique identifier of the trading venue. Universally Unique Identifier (UUID).
    /// </summary>
    public required Guid VenueId { get; init; }

    /// <summary>
    /// Returns OHLC prices from and including this datetime (UTC). If not specified, OHLC prices are returned from 30 days before the specified <c>end_date</c>. Time part of the timestamp is optional.
    /// </summary>
    public DateTimeOffset? StartDate { get; init; }

    /// <summary>
    /// Returns OHLC prices from and including this datetime (UTC). If not specified, OHLC prices are returned up to yesterday. Time part of the timestamp is optional.
    /// </summary>
    public DateTimeOffset? EndDate { get; init; }

    /// <summary>
    /// Indication of the desired data adjustment. Prices are adjusted for corporate actions such as cash dividends and stock splits. Does not apply if intraday prices are being requested.
    /// </summary>
    public AdjustedFor AdjustedFor { get; init; } = AdjustedFor.All;

    /// <summary>
    /// Indicates the maximum length of the interval each OHLC price tuple covers. If a price did not change subsequent price tuples are omitted. Allowed values are <c>1d</c> for daily prices or any positive integer followed by <c>h</c> or <c>m</c> for hour or minute, respectively. Requests are limited to a maximum of 1000 data points.
    /// </summary>
    [RegularExpression("^1d|[1-9][0-9]*[hm]$")]
    public string Interval { get; init; } = "1d";

    /// <summary>
    /// Upvest API version (Note: Do not include quotation marks)
    /// </summary>
    public UpvestApiVersion UpvestApiVersion { get; init; } = UpvestApiVersion._1;
}
