using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace UpvestInvestmentApi.Models;

/// <summary>
/// Schema for an access token response.
/// </summary>
public record AuthAccessToken
{
    /// <summary>
    /// The generated access token.
    /// </summary>
    [JsonPropertyName("access_token")]
    [MaxLength(1000)]
    public required string AccessToken { get; init; }

    /// <summary>
    /// How many seconds the access token is valid for.
    /// </summary>
    [JsonPropertyName("expires_in")]
    public required int ExpiresIn { get; init; }

    /// <summary>
    /// This is always 'bearer'.
    /// </summary>
    [JsonPropertyName("token_type")]
    public string TokenType { get; init; } = "bearer";

    /// <summary>
    /// List of space delimited scopes requested for this access token.
    /// </summary>
    [JsonPropertyName("scope")]
    [MaxLength(1000)]
    public required string Scope { get; init; }
}
