using System.Collections.Generic;
using System.Text.Json.Serialization;
using UpvestInvestmentApi.Models.AnyOf;

namespace UpvestInvestmentApi.Models;

/// <summary>
/// Response containing the list of all checks conducted for a user.
/// </summary>
public record UserCheckListResponse
{
    /// <summary>
    /// List of checks conducted for the user
    /// </summary>
    [JsonPropertyName("data")]
    public required IReadOnlyList<UserCheck> Data { get; init; }
}
