using System;
using UpvestInvestmentApi.Models.Enums;

namespace UpvestInvestmentApi.Requests.Mandates;

/// <summary>
/// The inputs of the DeleteMandate operation.
/// </summary>
public sealed record DeleteMandateRequest
{
    /// <summary>
    /// The unique identifier of the direct debit mandate. Universally Unique Identifier (UUID).
    /// </summary>
    public required Guid MandateId { get; init; }

    /// <summary>
    /// Upvest API version (Note: Do not include quotation marks)
    /// </summary>
    public UpvestApiVersion UpvestApiVersion { get; init; } = UpvestApiVersion._1;
}
