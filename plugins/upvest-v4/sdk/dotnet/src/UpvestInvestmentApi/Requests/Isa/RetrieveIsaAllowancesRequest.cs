using System;
using System.ComponentModel.DataAnnotations;
using UpvestInvestmentApi.Core.Validation.Attributes;
using UpvestInvestmentApi.Models.Enums;

namespace UpvestInvestmentApi.Requests.Isa;

/// <summary>
/// The inputs of the RetrieveIsaAllowances operation.
/// </summary>
public sealed record RetrieveIsaAllowancesRequest
{
    /// <summary>
    /// The unique identifier of the tax wrapper. Universally Unique Identifier (UUID).
    /// </summary>
    public required Guid TaxWrapperId { get; init; }

    /// <summary>
    /// Filter allowances by tax_year YYYY/YYYY
    /// </summary>
    [RegularExpression("^[0-9]{4}\\/[0-9]{4}$")]
    public string? TaxYear { get; init; }

    /// <summary>
    /// Sort the result by <c>created_at</c> or <c>valid_from</c>
    /// </summary>
    public Sort21 Sort { get; init; } = Sort21.CreatedAt;

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
