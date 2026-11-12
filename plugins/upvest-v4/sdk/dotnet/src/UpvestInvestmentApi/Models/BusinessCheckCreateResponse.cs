using System;
using System.Text.Json.Serialization;

namespace UpvestInvestmentApi.Models;

/// <summary>
/// Response containing the unique identifier of the business check created.
/// </summary>
public record BusinessCheckCreateResponse
{
    /// <summary>
    /// Business Check unique identifier.
    /// </summary>
    [JsonPropertyName("id")]
    public required Guid Id { get; init; }
}
