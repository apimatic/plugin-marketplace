using System;
using UpvestInvestmentApi.Models.Enums;

namespace UpvestInvestmentApi.Requests.UserIdentifiers;

/// <summary>
/// The inputs of the RetrieveIdentifier operation.
/// </summary>
public sealed record RetrieveIdentifierRequest
{
    /// <summary>
    /// The unique identifier of the user. Universally Unique Identifier (UUID).
    /// </summary>
    public required Guid UserId { get; init; }

    /// <summary>
    /// The unique identifier of the user identifier document. Universally Unique Identifier (UUID).
    /// </summary>
    public required Guid IdentifierId { get; init; }

    /// <summary>
    /// Upvest API version (Note: Do not include quotation marks)
    /// </summary>
    public UpvestApiVersion UpvestApiVersion { get; init; } = UpvestApiVersion._1;
}
