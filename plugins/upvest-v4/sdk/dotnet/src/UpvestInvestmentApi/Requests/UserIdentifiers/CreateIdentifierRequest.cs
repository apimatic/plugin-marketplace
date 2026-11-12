using System;
using UpvestInvestmentApi.Models;
using UpvestInvestmentApi.Models.Enums;

namespace UpvestInvestmentApi.Requests.UserIdentifiers;

/// <summary>
/// The inputs of the CreateIdentifier operation.
/// </summary>
public sealed record CreateIdentifierRequest
{
    /// <summary>
    /// The unique identifier of the user. Universally Unique Identifier (UUID).
    /// </summary>
    public required Guid UserId { get; init; }

    /// <summary>
    /// Upvest API version (Note: Do not include quotation marks)
    /// </summary>
    public UpvestApiVersion UpvestApiVersion { get; init; } = UpvestApiVersion._1;

    public IdentifierCreateRequest? Body { get; init; }
}
