using System;
using UpvestInvestmentApi.Models.Enums;

namespace UpvestInvestmentApi.Requests.TopUps;

/// <summary>
/// The inputs of the CancelTopup operation.
/// </summary>
public sealed record CancelTopupRequest
{
    /// <summary>
    /// The unique identifier of the top-up. Universally Unique Identifier (UUID).
    /// </summary>
    public required Guid TopupId { get; init; }

    /// <summary>
    /// Upvest API version (Note: Do not include quotation marks)
    /// </summary>
    public UpvestApiVersion UpvestApiVersion { get; init; } = UpvestApiVersion._1;
}
