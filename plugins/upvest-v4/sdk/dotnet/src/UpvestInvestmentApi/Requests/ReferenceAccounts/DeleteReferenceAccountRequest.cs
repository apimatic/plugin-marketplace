using System;
using UpvestInvestmentApi.Models.Enums;

namespace UpvestInvestmentApi.Requests.ReferenceAccounts;

/// <summary>
/// The inputs of the DeleteReferenceAccount operation.
/// </summary>
public sealed record DeleteReferenceAccountRequest
{
    /// <summary>
    /// The unique identifier of the reference (external bank) account. Universally Unique Identifier (UUID).
    /// </summary>
    public required Guid ReferenceAccountId { get; init; }

    /// <summary>
    /// Upvest API version (Note: Do not include quotation marks)
    /// </summary>
    public UpvestApiVersion UpvestApiVersion { get; init; } = UpvestApiVersion._1;
}
