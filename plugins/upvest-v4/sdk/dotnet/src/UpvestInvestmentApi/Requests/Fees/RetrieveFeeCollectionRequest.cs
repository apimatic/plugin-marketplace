using System;
using UpvestInvestmentApi.Models.Enums;

namespace UpvestInvestmentApi.Requests.Fees;

/// <summary>
/// The inputs of the RetrieveFeeCollection operation.
/// </summary>
public sealed record RetrieveFeeCollectionRequest
{
    /// <summary>
    /// The unique identifier of the fee collection. Universally Unique Identifier (UUID).
    /// </summary>
    public required Guid FeeCollectionId { get; init; }

    /// <summary>
    /// Upvest API version (Note: Do not include quotation marks)
    /// </summary>
    public UpvestApiVersion UpvestApiVersion { get; init; } = UpvestApiVersion._1;
}
