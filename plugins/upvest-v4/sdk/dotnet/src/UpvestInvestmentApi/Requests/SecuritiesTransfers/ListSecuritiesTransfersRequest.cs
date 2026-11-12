using System;
using UpvestInvestmentApi.Core.Validation.Attributes;
using UpvestInvestmentApi.Models.Enums;

namespace UpvestInvestmentApi.Requests.SecuritiesTransfers;

/// <summary>
/// The inputs of the ListSecuritiesTransfers operation.
/// </summary>
public sealed record ListSecuritiesTransfersRequest
{
    /// <summary>
    /// Filter the list by transfer direction.
    /// </summary>
    public required Direction Direction { get; init; }

    /// <summary>
    /// Sort the result by <c>created_at</c>, <c>updated_at</c>.
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
    /// Filters results by user ID. Universally Unique Identifier (UUID).
    /// </summary>
    public Guid? UserId { get; init; }

    /// <summary>
    /// Filters results by account ID. Universally Unique Identifier (UUID).
    /// </summary>
    public Guid? AccountId { get; init; }

    /// <summary>
    /// Filters results by account group ID. Universally Unique Identifier (UUID).
    /// </summary>
    public Guid? AccountGroupId { get; init; }

    /// <summary>
    /// Status of the securities transfer
    /// * NEW - Securities transfer is created but not started processing.
    /// * PROCESSING - Securities transfer is in processing.
    /// * SETTLED - Securities transfer was successfully settled.
    /// * CANCELLED - Securities transfer was cancelled.
    /// </summary>
    public Status78? Status { get; init; }

    /// <summary>
    /// Upvest API version (Note: Do not include quotation marks)
    /// </summary>
    public UpvestApiVersion UpvestApiVersion { get; init; } = UpvestApiVersion._1;
}
