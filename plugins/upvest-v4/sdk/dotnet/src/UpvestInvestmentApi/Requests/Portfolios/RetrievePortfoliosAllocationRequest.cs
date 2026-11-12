using System;
using UpvestInvestmentApi.Models.Enums;

namespace UpvestInvestmentApi.Requests.Portfolios;

/// <summary>
/// The inputs of the RetrievePortfoliosAllocation operation.
/// </summary>
public sealed record RetrievePortfoliosAllocationRequest
{
    /// <summary>
    /// The unique identifier of the portfolio allocation. Universally Unique Identifier (UUID).
    /// </summary>
    public required Guid AllocationId { get; init; }

    /// <summary>
    /// Upvest API version (Note: Do not include quotation marks)
    /// </summary>
    public UpvestApiVersion UpvestApiVersion { get; init; } = UpvestApiVersion._1;
}
