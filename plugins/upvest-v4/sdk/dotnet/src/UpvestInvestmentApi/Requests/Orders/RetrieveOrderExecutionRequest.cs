using System;
using UpvestInvestmentApi.Models.Enums;

namespace UpvestInvestmentApi.Requests.Orders;

/// <summary>
/// The inputs of the RetrieveOrderExecution operation.
/// </summary>
public sealed record RetrieveOrderExecutionRequest
{
    /// <summary>
    /// The unique identifier of the order execution. Universally Unique Identifier (UUID).
    /// </summary>
    public required Guid ExecutionId { get; init; }

    /// <summary>
    /// The unique identifier of the order. Universally Unique Identifier (UUID).
    /// </summary>
    public required Guid OrderId { get; init; }

    /// <summary>
    /// Upvest API version (Note: Do not include quotation marks)
    /// </summary>
    public UpvestApiVersion UpvestApiVersion { get; init; } = UpvestApiVersion._1;
}
