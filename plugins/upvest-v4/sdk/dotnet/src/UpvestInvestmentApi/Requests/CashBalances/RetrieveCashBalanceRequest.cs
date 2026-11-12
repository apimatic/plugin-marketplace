using System;
using UpvestInvestmentApi.Models.Enums;

namespace UpvestInvestmentApi.Requests.CashBalances;

/// <summary>
/// The inputs of the RetrieveCashBalance operation.
/// </summary>
public sealed record RetrieveCashBalanceRequest
{
    /// <summary>
    /// The unique identifier of the account group. Universally Unique Identifier (UUID).
    /// </summary>
    public required Guid AccountGroupId { get; init; }

    /// <summary>
    /// Upvest API version (Note: Do not include quotation marks)
    /// </summary>
    public UpvestApiVersion UpvestApiVersion { get; init; } = UpvestApiVersion._1;
}
