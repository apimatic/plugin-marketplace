using System.Text.Json.Serialization;

namespace UpvestInvestmentApi.Models;

/// <summary>
/// Owner of the virtual bank account
/// </summary>
public record Owner
{
    /// <summary>
    /// Name of the owner of the virtual bank account
    /// </summary>
    [JsonPropertyName("name")]
    public required string Name { get; init; }
}
