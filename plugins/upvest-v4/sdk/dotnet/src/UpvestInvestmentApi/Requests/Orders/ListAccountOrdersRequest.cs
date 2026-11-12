using System;
using UpvestInvestmentApi.Core.Validation.Attributes;
using UpvestInvestmentApi.Models.Enums;

namespace UpvestInvestmentApi.Requests.Orders;

/// <summary>
/// The inputs of the ListAccountOrders operation.
/// </summary>
public sealed record ListAccountOrdersRequest
{
    /// <summary>
    /// The unique identifier of the account. Universally Unique Identifier (UUID).
    /// </summary>
    public required Guid AccountId { get; init; }

    /// <summary>
    /// Sort order of the result list if the <c>sort</c> parameter is specified. Use <c>ASC</c> for ascending or <c>DESC</c> for descending sort order.
    /// </summary>
    public Order Order { get; init; } = Order.Asc;

    /// <summary>
    /// Filters results by account group ID. Universally Unique Identifier (UUID).
    /// </summary>
    public Guid? AccountGroupId { get; init; }

    /// <summary>
    /// Filters results by user ID. Universally Unique Identifier (UUID).
    /// </summary>
    public Guid? UserId { get; init; }

    /// <summary>
    /// The execution status of the order.
    /// * NEW -
    /// * PROCESSING -
    /// * FILLED -
    /// * CANCELLED -
    /// </summary>
    public Status50 Status { get; init; } = Status50.Filled;

    /// <summary>
    /// Filters results to those created at or after this timestamp. <see href="https://datatracker.ietf.org/doc/html/rfc3339">RFC 3339</see> date-time format (e.g. <c>2024-01-01</c>).
    /// </summary>
    public DateTimeOffset? DateCreatedFrom { get; init; }

    /// <summary>
    /// Filters results to those created at or before this timestamp. <see href="https://datatracker.ietf.org/doc/html/rfc3339">RFC 3339</see> date-time format (e.g. <c>2024-12-31T23:59:59Z</c>).
    /// </summary>
    public DateTimeOffset? DateCreatedTo { get; init; }

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
