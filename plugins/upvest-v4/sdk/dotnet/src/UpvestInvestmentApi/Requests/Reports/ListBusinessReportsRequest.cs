using System;
using UpvestInvestmentApi.Core.Validation.Attributes;
using UpvestInvestmentApi.Models.AnyOf;
using UpvestInvestmentApi.Models.Enums;

namespace UpvestInvestmentApi.Requests.Reports;

/// <summary>
/// The inputs of the ListBusinessReports operation.
/// </summary>
public sealed record ListBusinessReportsRequest
{
    /// <summary>
    /// The unique identifier of the business. Universally Unique Identifier (UUID).
    /// </summary>
    public required Guid BusinessId { get; init; }

    /// <summary>
    /// Filters the list to only show reports of a certain type (e.g. only buy order confirmations)
    /// </summary>
    public ReportType? Type { get; init; }

    /// <summary>
    /// Filters the list to only include reports concerning specified instrument
    /// </summary>
    public Instrument2Model? Instrument { get; init; }

    /// <summary>
    /// Returns reports generated on or after this date, as an <see href="https://datatracker.ietf.org/doc/html/rfc3339">RFC 3339</see> date in <c>YYYY-MM-DD</c> format (UTC)
    /// </summary>
    public DateTimeOffset? StartDate { get; init; }

    /// <summary>
    /// Returns reports generated on or before this date, as an <see href="https://datatracker.ietf.org/doc/html/rfc3339">RFC 3339</see> date in <c>YYYY-MM-DD</c> format (UTC)
    /// </summary>
    public DateTimeOffset? EndDate { get; init; }

    /// <summary>
    /// Field to sort the result by. Accepts <c>id</c> or <c>created_at</c>
    /// </summary>
    public Sort4 Sort { get; init; } = Sort4.CreatedAt;

    /// <summary>
    /// Sort order of the result list if the <c>sort</c> parameter is specified. Use <c>ASC</c> for ascending or <c>DESC</c> for descending sort order.
    /// </summary>
    public Order Order { get; init; } = Order.Asc;

    /// <summary>
    /// Use the <c>limit</c> argument to specify the maximum number of items returned.
    /// </summary>
    [Minimum(1)]
    [Maximum(1000)]
    public int? Limit { get; init; } = 100;

    /// <summary>
    /// Use the <c>offset</c> argument to specify where in the list of results to start when returning items for a particular query.
    /// </summary>
    [Minimum(0)]
    public int? Offset { get; init; }

    /// <summary>
    /// Upvest API version (Note: Do not include quotation marks)
    /// </summary>
    public UpvestApiVersion UpvestApiVersion { get; init; } = UpvestApiVersion._1;
}
