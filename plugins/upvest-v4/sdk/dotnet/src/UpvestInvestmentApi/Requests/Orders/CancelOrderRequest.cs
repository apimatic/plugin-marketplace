using System;
using UpvestInvestmentApi.Models.Enums;

namespace UpvestInvestmentApi.Requests.Orders;

/// <summary>
/// The inputs of the CancelOrder operation.
/// </summary>
public sealed record CancelOrderRequest
{
    /// <summary>
    /// The unique identifier of the order. Universally Unique Identifier (UUID).
    /// </summary>
    public required Guid OrderId { get; init; }

    /// <summary>
    /// Upvest API version (Note: Do not include quotation marks)
    /// </summary>
    public UpvestApiVersion UpvestApiVersion { get; init; } = UpvestApiVersion._1;
}
