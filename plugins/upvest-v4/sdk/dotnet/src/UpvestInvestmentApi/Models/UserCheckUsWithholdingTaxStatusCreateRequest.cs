using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using UpvestInvestmentApi.Core.Models;
using UpvestInvestmentApi.Models.Enums;

namespace UpvestInvestmentApi.Models;

/// <summary>
/// The US Withholding Tax Status check is completed by the client providing the user's US tax person classification and supporting documentation used to determine US withholding obligations.
/// <para>
/// Only the following combinations of <c>person_type</c> and <c>documentation_type</c> are valid:
/// * NON_RESIDENT_ALIEN + KYC
/// * NON_RESIDENT_ALIEN + W8-BEN
/// * NON_RESIDENT_ALIEN + UNDOCUMENTED
/// * US_PERSON + W9
/// * US_PERSON + UNDOCUMENTED
/// </para>
/// <para>
/// For a non-resident alien, <c>KYC</c> is accepted for every operating model; whether <c>W8-BEN</c> and <c>UNDOCUMENTED</c> are also accepted depends on your operating model.
/// </para>
/// <para>
/// <c>data_download_link</c> is only required when <c>documentation_type</c> is "W8-BEN" or "W9", and only when your operating model requires supporting documents to be supplied to Upvest.
/// </para>
/// </summary>
public record UserCheckUsWithholdingTaxStatusCreateRequest
{
    /// <summary>
    /// The type of check must be "US_WITHHOLDING_TAX_STATUS".
    /// </summary>
    [JsonPropertyName("type")]
    public string Type { get; init; } = "US_WITHHOLDING_TAX_STATUS";

    /// <summary>
    /// The date and time when the US withholding tax status was confirmed.
    /// </summary>
    [JsonPropertyName("check_confirmed_at")]
    public required DateTimeOffset CheckConfirmedAt { get; init; }

    /// <summary>
    /// Download URL for the withholding status evidence file. Only required when <c>documentation_type</c> is "W8-BEN" or "W9", and only when your operating model requires supporting documents to be supplied to Upvest. The file size must not exceed 250 MB.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("data_download_link")]
    [MaxLength(1000)]
    public string? DataDownloadLink { get; init; }

    /// <summary>
    /// US tax person classification of the user.
    /// * US_PERSON - The user is a US person for tax purposes.
    /// * NON_RESIDENT_ALIEN - The user is a non-resident alien for US tax purposes.
    /// </summary>
    [JsonPropertyName("person_type")]
    public required UserPersonType PersonType { get; init; }

    /// <summary>
    /// Type of documentation supporting the US withholding tax status.
    /// * KYC - Withholding status derived from the existing KYC data (non-resident aliens only).
    /// * W8-BEN - IRS Form W-8BEN provided by the user (non-resident aliens only).
    /// * W9 - IRS Form W-9 provided by the user (US persons only).
    /// * UNDOCUMENTED - No documentation is available for the user.
    /// <para>
    /// For a non-resident alien, "KYC" is accepted for every operating model; whether "W8-BEN" and "UNDOCUMENTED" are also accepted depends on your operating model.
    /// </para>
    /// </summary>
    [JsonPropertyName("documentation_type")]
    public required UserDocumentationType DocumentationType { get; init; }

    /// <summary>
    /// The date from which the US withholding tax status is valid, in YYYY-MM-DD format.
    /// </summary>
    [JsonPropertyName("valid_from")]
    [JsonConverter(typeof(UpvestInvestmentApi.Core.Converters.DateOnlyDateTimeOffsetConverter))]
    public required DateTimeOffset ValidFrom { get; init; }

    /// <summary>
    /// The date until which the US withholding tax status is valid, in YYYY-MM-DD format. Null if the status has no defined end date.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("valid_to")]
    [JsonConverter(typeof(UpvestInvestmentApi.Core.Converters.DateOnlyDateTimeOffsetConverter))]
    public DateTimeOffset? ValidTo { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
