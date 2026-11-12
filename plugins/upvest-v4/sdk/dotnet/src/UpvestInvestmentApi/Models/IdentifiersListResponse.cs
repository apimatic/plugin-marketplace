using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace UpvestInvestmentApi.Models;

/// <summary>
/// Response containing the list of all identifiers held by a user.
/// </summary>
public record IdentifiersListResponse
{
    /// <summary>
    /// List of identifiers held by the user
    /// </summary>
    [JsonPropertyName("data")]
    public required IReadOnlyList<Identifier> Data { get; init; }
}
