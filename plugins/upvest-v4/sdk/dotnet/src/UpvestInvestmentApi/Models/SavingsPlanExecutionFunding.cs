using System;
using System.Text.Json.Serialization;
using UpvestInvestmentApi.Core.Models;

namespace UpvestInvestmentApi.Models;

/// <summary>
/// Funding of an individual savings plan execution. <c>method</c> determines which further properties apply; currently only <c>DIRECT_DEBIT</c> is supported, for which <c>mandate_id</c> and <c>direct_debit_id</c> apply.
/// </summary>
public record SavingsPlanExecutionFunding
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

    /// <summary>
    /// Direct debit funding request unique identifier
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("direct_debit_id")]
    public Guid? DirectDebitId { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
