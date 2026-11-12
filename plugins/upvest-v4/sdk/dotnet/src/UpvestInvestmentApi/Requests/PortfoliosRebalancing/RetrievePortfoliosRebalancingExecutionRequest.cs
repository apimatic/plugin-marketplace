using System;
using UpvestInvestmentApi.Models.Enums;

namespace UpvestInvestmentApi.Requests.PortfoliosRebalancing;

/// <summary>
/// The inputs of the RetrievePortfoliosRebalancingExecution operation.
/// </summary>
public sealed record RetrievePortfoliosRebalancingExecutionRequest
{
    /// <summary>
    /// The unique identifier of the order execution. Universally Unique Identifier (UUID).
    /// </summary>
    public required Guid ExecutionId { get; init; }

    /// <summary>
    /// Upvest API version (Note: Do not include quotation marks)
    /// </summary>
    public UpvestApiVersion UpvestApiVersion { get; init; } = UpvestApiVersion._1;
}
