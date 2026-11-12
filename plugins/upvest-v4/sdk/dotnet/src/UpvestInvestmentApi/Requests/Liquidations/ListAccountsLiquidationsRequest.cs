using System;
using UpvestInvestmentApi.Core.Validation.Attributes;
using UpvestInvestmentApi.Models.Enums;

namespace UpvestInvestmentApi.Requests.Liquidations;

/// <summary>
/// The inputs of the ListAccountsLiquidations operation.
/// </summary>
public sealed record ListAccountsLiquidationsRequest
{
    /// <summary>
    /// The unique identifier of the account. Universally Unique Identifier (UUID).
    /// </summary>
    public required Guid AccountId { get; init; }

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
    /// Returns accounts liquidations created starting from and including this date (UTC)
    /// </summary>
    public string? StartDate { get; init; }

    /// <summary>
    /// Returns accounts liquidations created up until this date (UTC)
    /// </summary>
    public string? EndDate { get; init; }

    /// <summary>
    /// Upvest API version (Note: Do not include quotation marks)
    /// </summary>
    public UpvestApiVersion UpvestApiVersion { get; init; } = UpvestApiVersion._1;
}
