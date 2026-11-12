using System;
using UpvestInvestmentApi.Models;
using UpvestInvestmentApi.Models.Enums;

namespace UpvestInvestmentApi.Requests.SavingsPlans;

/// <summary>
/// The inputs of the UpdateSavingsPlan operation.
/// </summary>
public sealed record UpdateSavingsPlanRequest
{
    /// <summary>
    /// The unique identifier of the savings plan. Universally Unique Identifier (UUID).
    /// </summary>
    public required Guid SavingsPlanId { get; init; }

    /// <summary>
    /// Upvest API version (Note: Do not include quotation marks)
    /// </summary>
    public UpvestApiVersion UpvestApiVersion { get; init; } = UpvestApiVersion._1;

    public SavingsPlanUpdateRequest? Body { get; init; }
}
