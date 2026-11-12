using System.Collections.Generic;
using System.Text.Json.Serialization;
using UpvestInvestmentApi.Models.AnyOf;

namespace UpvestInvestmentApi.Models;

/// <summary>
/// Paginated list of savings plan executions for a savings plan, including cursor-based pagination metadata.
/// </summary>
public record SavingsPlanExecutionListResponse
{
    /// <summary>
    /// Offset/limit pagination metadata for a list response. Contains the <c>offset</c> and <c>limit</c> applied to the request, the <c>count</c> of resources returned in this page, and the <c>total_count</c> of matching resources.
    /// </summary>
    [JsonPropertyName("meta")]
    public required Meta Meta { get; init; }

    [JsonPropertyName("data")]
    public required IReadOnlyList<SavingsPlanExecution> Data { get; init; }
}
