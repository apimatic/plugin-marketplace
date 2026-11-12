using System;
using System.Text.Json.Serialization;
using UpvestInvestmentApi.Core.Models;

namespace UpvestInvestmentApi.Models;

/// <summary>
/// Terms &amp; Conditions will be needed for all users unless they are a child user or only a user on a business.
/// </summary>
public record TermsAndConditions
{
    /// <summary>
    /// Consent unique identifier.
    /// </summary>
    [JsonPropertyName("consent_document_id")]
    public required Guid ConsentDocumentId { get; init; }

    /// <summary>
    /// Timestamp at which the user consented to the terms &amp; conditions. <see href="https://datatracker.ietf.org/doc/html/rfc3339#section-5.6">RFC 3339-5</see>, <see href="https://www.iso.org/iso-8601-date-and-time-format.html">ISO8601 UTC</see>
    /// </summary>
    [JsonPropertyName("confirmed_at")]
    public required DateTimeOffset ConfirmedAt { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
