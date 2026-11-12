using System;
using UpvestInvestmentApi.Models.Enums;

namespace UpvestInvestmentApi.Requests.AccountGroups;

/// <summary>
/// The inputs of the RetrieveAccountGroup operation.
/// </summary>
public sealed record RetrieveAccountGroupRequest
{
    /// <summary>
    /// The unique identifier of the account group. Universally Unique Identifier (UUID).
    /// </summary>
    public required Guid AccountGroupId { get; init; }

    /// <summary>
    /// Upvest API version (Note: Do not include quotation marks)
    /// </summary>
    public UpvestApiVersion UpvestApiVersion { get; init; } = UpvestApiVersion._1;
}
