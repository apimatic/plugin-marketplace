using System;
using UpvestInvestmentApi.Models.Enums;

namespace UpvestInvestmentApi.Requests.UserChecks;

/// <summary>
/// The inputs of the RetrieveUserCheck operation.
/// </summary>
public sealed record RetrieveUserCheckRequest
{
    /// <summary>
    /// The unique identifier of the user. Universally Unique Identifier (UUID).
    /// </summary>
    public required Guid UserId { get; init; }

    /// <summary>
    /// The unique identifier of the user check. Universally Unique Identifier (UUID).
    /// </summary>
    public required Guid CheckId { get; init; }

    /// <summary>
    /// Upvest API version (Note: Do not include quotation marks)
    /// </summary>
    public UpvestApiVersion UpvestApiVersion { get; init; } = UpvestApiVersion._1;
}
