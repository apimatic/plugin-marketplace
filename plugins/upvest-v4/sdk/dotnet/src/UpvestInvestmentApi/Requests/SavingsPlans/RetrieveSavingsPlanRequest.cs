using System;
using UpvestInvestmentApi.Models.Enums;

namespace UpvestInvestmentApi.Requests.SavingsPlans;

/// <summary>
/// The inputs of the RetrieveSavingsPlan operation.
/// </summary>
public sealed record RetrieveSavingsPlanRequest
{
    /// <summary>
    /// The unique identifier of the savings plan. Universally Unique Identifier (UUID).
    /// </summary>
    public required Guid SavingsPlanId { get; init; }

    /// <summary>
    /// Upvest API version (Note: Do not include quotation marks)
    /// </summary>
    public UpvestApiVersion UpvestApiVersion { get; init; } = UpvestApiVersion._1;
}
