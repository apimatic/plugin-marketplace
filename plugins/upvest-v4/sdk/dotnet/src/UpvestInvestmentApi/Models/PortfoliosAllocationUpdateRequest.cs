using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace UpvestInvestmentApi.Models;

/// <summary>
/// Request body for updating a portfolio allocation. Updates the name and/or instrument weights. Updated weights must still sum to 100.
/// </summary>
public record PortfoliosAllocationUpdateRequest
{
    /// <summary>
    /// Allocation name
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("name")]
    public string? Name { get; init; }

    /// <summary>
    /// List of portfolios allocations
    /// </summary>
    [JsonPropertyName("allocation")]
    public required IReadOnlyList<Allocation> Allocation { get; init; }
}
