using System;
using UpvestInvestmentApi.Models.Enums;

namespace UpvestInvestmentApi.Requests.AccountsApi;

/// <summary>
/// The inputs of the AccountClosure operation.
/// </summary>
public sealed record AccountClosureRequest
{
    /// <summary>
    /// The unique identifier of the account. Universally Unique Identifier (UUID).
    /// </summary>
    public required Guid AccountId { get; init; }

    /// <summary>
    /// Upvest API version (Note: Do not include quotation marks)
    /// </summary>
    public UpvestApiVersion UpvestApiVersion { get; init; } = UpvestApiVersion._1;
}
