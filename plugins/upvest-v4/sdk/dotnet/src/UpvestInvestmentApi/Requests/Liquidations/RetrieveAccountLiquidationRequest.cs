using System;
using UpvestInvestmentApi.Models.Enums;

namespace UpvestInvestmentApi.Requests.Liquidations;

/// <summary>
/// The inputs of the RetrieveAccountLiquidation operation.
/// </summary>
public sealed record RetrieveAccountLiquidationRequest
{
    /// <summary>
    /// The unique identifier of the account. Universally Unique Identifier (UUID).
    /// </summary>
    public required Guid AccountId { get; init; }

    /// <summary>
    /// The unique identifier of the account liquidation. Universally Unique Identifier (UUID).
    /// </summary>
    public required Guid AccountLiquidationId { get; init; }

    /// <summary>
    /// Upvest API version (Note: Do not include quotation marks)
    /// </summary>
    public UpvestApiVersion UpvestApiVersion { get; init; } = UpvestApiVersion._1;
}
