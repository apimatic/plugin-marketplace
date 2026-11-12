using System;
using UpvestInvestmentApi.Models.Enums;

namespace UpvestInvestmentApi.Requests.VirtualCashBalances;

/// <summary>
/// The inputs of the CancelVirtualCashDecrease operation.
/// </summary>
public sealed record CancelVirtualCashDecreaseRequest
{
    /// <summary>
    /// The unique identifier of the virtual cash decrease. Universally Unique Identifier (UUID).
    /// </summary>
    public required Guid VirtualCashDecreaseId { get; init; }

    /// <summary>
    /// Upvest API version (Note: Do not include quotation marks)
    /// </summary>
    public UpvestApiVersion UpvestApiVersion { get; init; } = UpvestApiVersion._1;
}
