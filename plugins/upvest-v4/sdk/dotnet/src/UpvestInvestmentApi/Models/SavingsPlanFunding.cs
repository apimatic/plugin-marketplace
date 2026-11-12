using System;
using System.Text.Json.Serialization;
using UpvestInvestmentApi.Core.Models;

namespace UpvestInvestmentApi.Models;

/// <summary>
/// Funding configuration for the savings plan. Specifies how each execution of the plan is to be funded.
/// </summary>
public record SavingsPlanFunding
{
    /// <summary>
    /// Funding method
    /// * DIRECT_DEBIT -
    /// </summary>
    [JsonPropertyName("method")]
    public string Method { get; } = "DIRECT_DEBIT";

    /// <summary>
    /// Direct Debit Mandate unique identifier.
    /// </summary>
    [JsonPropertyName("mandate_id")]
    public required Guid MandateId { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
