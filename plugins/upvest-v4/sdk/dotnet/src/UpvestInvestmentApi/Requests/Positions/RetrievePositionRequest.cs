using System;
using UpvestInvestmentApi.Models.AnyOf;
using UpvestInvestmentApi.Models.Enums;

namespace UpvestInvestmentApi.Requests.Positions;

/// <summary>
/// The inputs of the RetrievePosition operation.
/// </summary>
public sealed record RetrievePositionRequest
{
    /// <summary>
    /// The unique identifier of the instrument, provided as either an <c>isin:</c> URN or a <c>uuid:</c> URN.
    /// </summary>
    public required InstrumentUniqueIdentifier InstrumentId { get; init; }

    /// <summary>
    /// The unique identifier of the account. Universally Unique Identifier (UUID).
    /// </summary>
    public required Guid AccountId { get; init; }

    /// <summary>
    /// Upvest API version (Note: Do not include quotation marks)
    /// </summary>
    public UpvestApiVersion UpvestApiVersion { get; init; } = UpvestApiVersion._1;
}
