using System;
using UpvestInvestmentApi.Models.Enums;

namespace UpvestInvestmentApi.Requests.Roles;

/// <summary>
/// The inputs of the RoleDeactivation operation.
/// </summary>
public sealed record RoleDeactivationRequest
{
    /// <summary>
    /// The unique identifier of the role. Universally Unique Identifier (UUID).
    /// </summary>
    public required Guid RoleId { get; init; }

    /// <summary>
    /// Upvest API version (Note: Do not include quotation marks)
    /// </summary>
    public UpvestApiVersion UpvestApiVersion { get; init; } = UpvestApiVersion._1;
}
