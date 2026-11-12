using System;
using UpvestInvestmentApi.Models;
using UpvestInvestmentApi.Models.Enums;

namespace UpvestInvestmentApi.Requests.TaxExemptions;

/// <summary>
/// The inputs of the UpdateTaxExemption operation.
/// </summary>
public sealed record UpdateTaxExemptionRequest
{
    /// <summary>
    /// The unique identifier of the tax exemption. Universally Unique Identifier (UUID).
    /// </summary>
    public required Guid TaxExemptionId { get; init; }

    /// <summary>
    /// Upvest API version (Note: Do not include quotation marks)
    /// </summary>
    public UpvestApiVersion UpvestApiVersion { get; init; } = UpvestApiVersion._1;

    public TaxesTaxExemptionsUpdateRequest? Body { get; init; }
}
