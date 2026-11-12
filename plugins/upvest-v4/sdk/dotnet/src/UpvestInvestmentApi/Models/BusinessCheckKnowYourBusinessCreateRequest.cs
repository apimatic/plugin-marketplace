using System;
using System.Text.Json.Serialization;
using UpvestInvestmentApi.Core.Models;
using UpvestInvestmentApi.Core.Validation;
using UpvestInvestmentApi.Core.Validation.Attributes;

namespace UpvestInvestmentApi.Models;

/// <summary>
/// The KYB (Know Your Business) check is completed by the client sharing the valid and relevant KYB data for the business.
/// </summary>
public record BusinessCheckKnowYourBusinessCreateRequest
{
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
    /// Link to download the document bundle submitted for the KYB check
    /// </summary>
    [JsonPropertyName("data_download_link")]
    [Format(FormatKind.Uri)]
    public required string DataDownloadLink { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
