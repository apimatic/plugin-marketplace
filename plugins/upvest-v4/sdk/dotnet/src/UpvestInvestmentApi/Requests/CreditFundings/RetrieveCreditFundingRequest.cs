using System;
using UpvestInvestmentApi.Models.Enums;

namespace UpvestInvestmentApi.Requests.CreditFundings;

/// <summary>
/// The inputs of the RetrieveCreditFunding operation.
/// </summary>
public sealed record RetrieveCreditFundingRequest
{
    /// <summary>
    /// The unique identifier of the credit funding. Universally Unique Identifier (UUID).
    /// </summary>
    public required Guid CreditFundingId { get; init; }

    /// <summary>
    /// Upvest API version (Note: Do not include quotation marks)
    /// </summary>
    public UpvestApiVersion UpvestApiVersion { get; init; } = UpvestApiVersion._1;
}
