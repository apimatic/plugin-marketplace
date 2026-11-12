using System;
using UpvestInvestmentApi.Models.AnyOf;
using UpvestInvestmentApi.Models.Enums;

namespace UpvestInvestmentApi.Requests.Users;

/// <summary>
/// The inputs of the UserDataChange operation.
/// </summary>
public sealed record UserDataChangeOperationRequest
{
    /// <summary>
    /// The unique identifier of the user. Universally Unique Identifier (UUID).
    /// </summary>
    public required Guid UserId { get; init; }

    /// <summary>
    /// Upvest API version (Note: Do not include quotation marks)
    /// </summary>
    public UpvestApiVersion UpvestApiVersion { get; init; } = UpvestApiVersion._1;

    public UserDataChangeRequest? Body { get; init; }
}
