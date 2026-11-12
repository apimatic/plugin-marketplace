using System;
using UpvestInvestmentApi.Models.Enums;

namespace UpvestInvestmentApi.Requests.AccountGroups;

/// <summary>
/// The inputs of the AccountGroupClosure operation.
/// </summary>
public sealed record AccountGroupClosureRequest
{
    /// <summary>
    /// The unique identifier of the account group. Universally Unique Identifier (UUID).
    /// </summary>
    public required Guid AccountGroupId { get; init; }

    /// <summary>
    /// Records the reason for the account group closure.
    /// </summary>
    public ClosureReason? ClosureReason { get; init; }

    /// <summary>
    /// Indicates whether the request notifies of an intended future closing.
    /// </summary>
    public bool? NotificationOnly { get; init; }

    /// <summary>
    /// Upvest API version (Note: Do not include quotation marks)
    /// </summary>
    public UpvestApiVersion UpvestApiVersion { get; init; } = UpvestApiVersion._1;
}
