using System;
using System.Text.Json.Serialization;
using UpvestInvestmentApi.Core.Models;
using UpvestInvestmentApi.Core.Validation;
using UpvestInvestmentApi.Core.Validation.Attributes;
using UpvestInvestmentApi.Models.Enums;

namespace UpvestInvestmentApi.Models;

/// <summary>
/// A Know Your Business (KYB) check for a business, recording confirmation timestamps and a link to the submitted documents.
/// </summary>
public record BusinessCheckKyb
{
    /// <summary>
    /// Business Check unique identifier.
    /// </summary>
    [JsonPropertyName("id")]
    public required Guid Id { get; init; }

    /// <summary>
    /// Unique identifier for the business.
    /// </summary>
    [JsonPropertyName("business_id")]
    public required Guid BusinessId { get; init; }

    /// <summary>
    /// The type of check must be “KYB”.
    /// </summary>
    [JsonPropertyName("type")]
    public string Type { get; init; } = "KYB";

    /// <summary>
    /// The date and time when the check was first confirmed. When the check has only been confirmed once, this value is the same as check_confirmed_at. When renewing KYB check, this value remains the same as when the check was first confirmed.
    /// </summary>
    [JsonPropertyName("originally_confirmed_at")]
    public required DateTimeOffset OriginallyConfirmedAt { get; init; }

    /// <summary>
    /// The date and time when the check was latest confirmed
    /// </summary>
    [JsonPropertyName("check_confirmed_at")]
    public required DateTimeOffset CheckConfirmedAt { get; init; }

    /// <summary>
    /// Final status of the business check.
    /// * IN_PROGRESS - Check is in progress
    /// * PASSED - Check passed
    /// * FAILED - Check failed
    /// </summary>
    [JsonPropertyName("status")]
    public required Status106 Status { get; init; }

    /// <summary>
    /// Link to download the document bundle submitted for the KYB check
    /// </summary>
    [JsonPropertyName("data_download_link")]
    [Format(FormatKind.Uri)]
    public required string DataDownloadLink { get; init; }

    /// <summary>
    /// Type of the document bundle. Always <c>KYB_DOCUMENTS</c>
    /// </summary>
    [JsonPropertyName("document_type")]
    public string DocumentType { get; init; } = "KYB_DOCUMENTS";

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
