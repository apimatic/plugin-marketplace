using UpvestInvestmentApi.Core.Validation.Attributes;
using UpvestInvestmentApi.Models.AnyOf;
using UpvestInvestmentApi.Models.Enums;

namespace UpvestInvestmentApi.Requests.SavingsPlans;

/// <summary>
/// The inputs of the ListSavingsPlans operation.
/// </summary>
public sealed record ListSavingsPlansRequest
{
    /// <summary>
    /// Filters savings plans by account ID
    /// </summary>
    public string? AccountId { get; init; }

    /// <summary>
    /// Filters savings plans by user ID
    /// </summary>
    public string? UserId { get; init; }

    /// <summary>
    /// Filters savings plans by instrument ID (ISIN)
    /// </summary>
    public InstrumentUniqueIdentifier5? InstrumentId { get; init; }

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
    /// Upvest API version (Note: Do not include quotation marks)
    /// </summary>
    public UpvestApiVersion UpvestApiVersion { get; init; } = UpvestApiVersion._1;
}
