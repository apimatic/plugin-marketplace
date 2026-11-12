using System;
using UpvestInvestmentApi.Models.Enums;

namespace UpvestInvestmentApi.Requests.Portfolios;

/// <summary>
/// The inputs of the CancelPortfoliosOrder operation.
/// </summary>
public sealed record CancelPortfoliosOrderRequest
{
    /// <summary>
    /// The unique identifier of the portfolio order. Universally Unique Identifier (UUID).
    /// </summary>
    public required Guid PortfolioOrderId { get; init; }

    /// <summary>
    /// Upvest API version (Note: Do not include quotation marks)
    /// </summary>
    public UpvestApiVersion UpvestApiVersion { get; init; } = UpvestApiVersion._1;
}
