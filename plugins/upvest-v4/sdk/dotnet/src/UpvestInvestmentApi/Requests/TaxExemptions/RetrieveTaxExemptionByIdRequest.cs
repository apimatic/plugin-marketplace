using System;
using UpvestInvestmentApi.Models.Enums;

namespace UpvestInvestmentApi.Requests.TaxExemptions;

/// <summary>
/// The inputs of the RetrieveTaxExemptionById operation.
/// </summary>
public sealed record RetrieveTaxExemptionByIdRequest
{
    /// <summary>
    /// The unique identifier of the tax exemption. Universally Unique Identifier (UUID).
    /// </summary>
    public required Guid TaxExemptionId { get; init; }

    /// <summary>
    /// Upvest API version (Note: Do not include quotation marks)
    /// </summary>
    public UpvestApiVersion UpvestApiVersion { get; init; } = UpvestApiVersion._1;
}
