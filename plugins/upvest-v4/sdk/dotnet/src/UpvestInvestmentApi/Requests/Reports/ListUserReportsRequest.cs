using System;
using UpvestInvestmentApi.Core.Validation.Attributes;
using UpvestInvestmentApi.Models.AnyOf;
using UpvestInvestmentApi.Models.Enums;

namespace UpvestInvestmentApi.Requests.Reports;

/// <summary>
/// The inputs of the ListUserReports operation.
/// </summary>
public sealed record ListUserReportsRequest
{
    /// <summary>
    /// The unique identifier of the user. Universally Unique Identifier (UUID).
    /// </summary>
    public required Guid UserId { get; init; }

    /// <summary>
    /// Filters the list to only show reports of a certain type (e.g. only buy order confirmations)
    /// </summary>
    public ReportType? Type { get; init; }

    /// <summary>
    /// Filters the list to only include reports concerning specified instrument
    /// </summary>
    public Instrument2Model? Instrument { get; init; }

    public DateTimeOffset? StartDate { get; init; }

    public DateTimeOffset? EndDate { get; init; }

    /// <summary>
    /// Field of resource to sort by
    /// </summary>
    public Sort23 Sort { get; init; } = Sort23.CreatedAt;

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
