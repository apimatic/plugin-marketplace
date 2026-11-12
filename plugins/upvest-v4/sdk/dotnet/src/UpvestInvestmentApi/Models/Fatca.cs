using System;
using System.Text.Json.Serialization;
using UpvestInvestmentApi.Core.Models;

namespace UpvestInvestmentApi.Models;

/// <summary>
/// The user's FATCA status and when it was confirmed
/// </summary>
public record Fatca
{
    /// <summary>
    /// The user’s FATCA status is true if the user is subject to paying taxes in the US, otherwise it can be set to false.
    /// </summary>
    [JsonPropertyName("status")]
    public required bool Status { get; init; }

    /// <summary>
    /// Timestamp at which the user confirmed their FATCA status. <see href="https://datatracker.ietf.org/doc/html/rfc3339#section-5.6">RFC 3339-5</see>, <see href="https://www.iso.org/iso-8601-date-and-time-format.html">ISO8601 UTC</see>
    /// </summary>
    [JsonPropertyName("confirmed_at")]
    public required DateTimeOffset ConfirmedAt { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
