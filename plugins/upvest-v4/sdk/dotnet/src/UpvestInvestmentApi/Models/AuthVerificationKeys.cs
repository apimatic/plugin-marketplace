using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace UpvestInvestmentApi.Models;

/// <summary>
/// Webhooks verification keys.
/// </summary>
public record AuthVerificationKeys
{
    /// <summary>
    /// The public keys available for verifying webhook signatures.
    /// </summary>
    [JsonPropertyName("keys")]
    public required IReadOnlyList<Key> Keys { get; init; }
}
