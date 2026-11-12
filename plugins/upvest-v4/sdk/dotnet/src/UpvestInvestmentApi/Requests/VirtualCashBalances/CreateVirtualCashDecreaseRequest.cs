using System;
using UpvestInvestmentApi.Models;
using UpvestInvestmentApi.Models.Enums;

namespace UpvestInvestmentApi.Requests.VirtualCashBalances;

/// <summary>
/// The inputs of the CreateVirtualCashDecrease operation.
/// </summary>
public sealed record CreateVirtualCashDecreaseRequest
{
    /// <summary>
    /// A UUID to be used as an idempotency key.  This prevents a duplicate request from being replayed.
    /// https://docs.upvest.co/documentation/concepts/api_concepts/idempotency
    /// </summary>
    public required Guid IdempotencyKey { get; init; }

    /// <summary>
    /// Upvest API version (Note: Do not include quotation marks)
    /// </summary>
    public UpvestApiVersion UpvestApiVersion { get; init; } = UpvestApiVersion._1;

    public VirtualCashBalanceVirtualCashDecreaseCreateRequest? Body { get; init; }
}
