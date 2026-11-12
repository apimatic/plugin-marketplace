using System;
using UpvestInvestmentApi.Core.Validation.Attributes;
using UpvestInvestmentApi.Models.Enums;

namespace UpvestInvestmentApi.Requests.Portfolios;

/// <summary>
/// The inputs of the ListPortfoliosOrders operation.
/// </summary>
public sealed record ListPortfoliosOrdersRequest
{
    /// <summary>
    /// Sort the result by <c>id</c>.
    /// </summary>
    public Sort24 Sort { get; init; } = Sort24.Id;

    /// <summary>
    /// Sort order of the result list if the <c>sort</c> parameter is specified. By default, only ASC for ascending sort.
    /// </summary>
    public Order60 Order { get; init; } = Order60.Asc;

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
    /// Returns portfolio orders with dates starting from and including this date (UTC)
    /// </summary>
    public string? StartDate { get; init; }

    /// <summary>
    /// Returns portfolio orders with dates up until this date (UTC)
    /// </summary>
    public string? EndDate { get; init; }

    /// <summary>
    /// Filters portfolio orders containing the allocation id
    /// </summary>
    public Guid? AllocationId { get; init; }

    /// <summary>
    /// Filters portfolio orders containing the account id
    /// </summary>
    public Guid? AccountId { get; init; }

    /// <summary>
    /// Upvest API version (Note: Do not include quotation marks)
    /// </summary>
    public UpvestApiVersion UpvestApiVersion { get; init; } = UpvestApiVersion._1;
}
