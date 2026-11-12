using System;
using System.Text.Json.Serialization;
using UpvestInvestmentApi.Core.Models;

namespace UpvestInvestmentApi.Models;

/// <summary>
/// Data privacy and sharing agreement.
/// </summary>
public record DataPrivacyAndSharingAgreement5
{
    /// <summary>
    /// UUID of the data privacy and sharing agreement document.
    /// </summary>
    [JsonPropertyName("consent_document_id")]
    public required Guid ConsentDocumentId { get; init; }

    /// <summary>
    /// Timestamp when the data privacy and sharing agreement was confirmed.
    /// </summary>
    [JsonPropertyName("confirmed_at")]
    public required DateTimeOffset ConfirmedAt { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
