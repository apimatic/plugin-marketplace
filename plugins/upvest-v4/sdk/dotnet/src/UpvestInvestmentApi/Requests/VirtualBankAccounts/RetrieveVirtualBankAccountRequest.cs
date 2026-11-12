using System;
using UpvestInvestmentApi.Models.Enums;

namespace UpvestInvestmentApi.Requests.VirtualBankAccounts;

/// <summary>
/// The inputs of the RetrieveVirtualBankAccount operation.
/// </summary>
public sealed record RetrieveVirtualBankAccountRequest
{
    /// <summary>
    /// The unique identifier of the virtual bank account. Universally Unique Identifier (UUID).
    /// </summary>
    public required Guid VirtualBankAccountId { get; init; }

    /// <summary>
    /// Upvest API version (Note: Do not include quotation marks)
    /// </summary>
    public UpvestApiVersion UpvestApiVersion { get; init; } = UpvestApiVersion._1;
}
