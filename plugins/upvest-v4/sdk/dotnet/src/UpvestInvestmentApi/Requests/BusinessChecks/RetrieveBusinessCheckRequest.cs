using System;
using UpvestInvestmentApi.Models.Enums;

namespace UpvestInvestmentApi.Requests.BusinessChecks;

/// <summary>
/// The inputs of the RetrieveBusinessCheck operation.
/// </summary>
public sealed record RetrieveBusinessCheckRequest
{
    /// <summary>
    /// The unique identifier of the business. Universally Unique Identifier (UUID).
    /// </summary>
    public required Guid BusinessId { get; init; }

    /// <summary>
    /// The unique identifier of the user check. Universally Unique Identifier (UUID).
    /// </summary>
    public required Guid CheckId { get; init; }

    /// <summary>
    /// Upvest API version (Note: Do not include quotation marks)
    /// </summary>
    public UpvestApiVersion UpvestApiVersion { get; init; } = UpvestApiVersion._1;
}
