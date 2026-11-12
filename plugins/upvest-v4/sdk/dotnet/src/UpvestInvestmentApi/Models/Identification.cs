using System.Text.Json.Serialization;

namespace UpvestInvestmentApi.Models;

/// <summary>
/// Identification details
/// </summary>
public record Identification
{
    /// <summary>
    /// SWIFT details
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("swift")]
    public Swift? Swift { get; init; }
}
