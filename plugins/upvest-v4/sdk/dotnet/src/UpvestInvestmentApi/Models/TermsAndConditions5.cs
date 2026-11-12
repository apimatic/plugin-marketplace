using System;
using System.Text.Json.Serialization;
using UpvestInvestmentApi.Core.Models;

namespace UpvestInvestmentApi.Models;

/// <summary>
/// Terms and conditions agreement.
/// </summary>
public record TermsAndConditions5
{
    /// <summary>
    /// UUID of the consent document.
    /// </summary>
    [JsonPropertyName("consent_document_id")]
    public required Guid ConsentDocumentId { get; init; }

    /// <summary>
    /// Timestamp when the terms and conditions were confirmed.
    /// </summary>
    [JsonPropertyName("confirmed_at")]
    public required DateTimeOffset ConfirmedAt { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
