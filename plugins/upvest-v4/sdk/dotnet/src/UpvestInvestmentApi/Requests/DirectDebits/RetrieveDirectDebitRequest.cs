using System;
using UpvestInvestmentApi.Models.Enums;

namespace UpvestInvestmentApi.Requests.DirectDebits;

/// <summary>
/// The inputs of the RetrieveDirectDebit operation.
/// </summary>
public sealed record RetrieveDirectDebitRequest
{
    /// <summary>
    /// The unique identifier of the direct debit. Universally Unique Identifier (UUID).
    /// </summary>
    public required Guid DirectDebitId { get; init; }

    /// <summary>
    /// Upvest API version (Note: Do not include quotation marks)
    /// </summary>
    public UpvestApiVersion UpvestApiVersion { get; init; } = UpvestApiVersion._1;
}
