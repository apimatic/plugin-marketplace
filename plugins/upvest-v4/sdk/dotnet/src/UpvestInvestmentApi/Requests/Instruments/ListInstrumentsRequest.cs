using UpvestInvestmentApi.Core.Validation.Attributes;
using UpvestInvestmentApi.Models.Enums;

namespace UpvestInvestmentApi.Requests.Instruments;

/// <summary>
/// The inputs of the ListInstruments operation.
/// </summary>
public sealed record ListInstrumentsRequest
{
    /// <summary>
    /// Filters the list to only show instruments with a certain status (e.g. only instruments that can be currently traded).
    /// </summary>
    public InstrumentTradingStatus? TradingStatus { get; init; }

    /// <summary>
    /// Sort the result by <c>created_at</c> or <c>updated_at</c>.
    /// </summary>
    public Sort1 Sort { get; init; } = Sort1.CreatedAt;

    /// <summary>
    /// Sort order of the result list if the <c>sort</c> parameter is specified. Use <c>ASC</c> for ascending or <c>DESC</c> for descending sort order.
    /// </summary>
    public Order Order { get; init; } = Order.Asc;

    /// <summary>
    /// Use the <c>offset</c> argument to specify where in the list of results to start when returning items for a particular query.
    /// </summary>
    [Minimum(0)]
    public int? Offset { get; init; }

    /// <summary>
    /// Use the <c>limit</c> argument to specify the maximum number of items returned.
    /// </summary>
    [Minimum(1)]
    [Maximum(1000)]
    public int? Limit { get; init; } = 100;

    /// <summary>
    /// Upvest API version (Note: Do not include quotation marks)
    /// </summary>
    public UpvestApiVersion UpvestApiVersion { get; init; } = UpvestApiVersion._1;
}
