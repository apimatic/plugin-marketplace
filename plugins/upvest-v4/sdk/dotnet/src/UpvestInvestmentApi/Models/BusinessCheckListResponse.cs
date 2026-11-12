using System.Collections.Generic;
using System.Text.Json.Serialization;
using UpvestInvestmentApi.Models.AnyOf;

namespace UpvestInvestmentApi.Models;

/// <summary>
/// List of business checks.
/// </summary>
public record BusinessCheckListResponse
{
    /// <summary>
    /// List of checks conducted for the business
    /// </summary>
    [JsonPropertyName("data")]
    public required IReadOnlyList<BusinessCheck> Data { get; init; }
}
