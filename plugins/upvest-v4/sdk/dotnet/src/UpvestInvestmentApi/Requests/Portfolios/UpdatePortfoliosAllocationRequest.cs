using System;
using UpvestInvestmentApi.Models;
using UpvestInvestmentApi.Models.Enums;

namespace UpvestInvestmentApi.Requests.Portfolios;

/// <summary>
/// The inputs of the UpdatePortfoliosAllocation operation.
/// </summary>
public sealed record UpdatePortfoliosAllocationRequest
{
    /// <summary>
    /// The unique identifier of the portfolio allocation. Universally Unique Identifier (UUID).
    /// </summary>
    public required Guid AllocationId { get; init; }

    /// <summary>
    /// Upvest API version (Note: Do not include quotation marks)
    /// </summary>
    public UpvestApiVersion UpvestApiVersion { get; init; } = UpvestApiVersion._1;

    public PortfoliosAllocationUpdateRequest? Body { get; init; }
}
