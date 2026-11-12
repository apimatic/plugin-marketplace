using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using UpvestInvestmentApi.Core.Models;
using UpvestInvestmentApi.Models.Enums;

namespace UpvestInvestmentApi.Models;

/// <summary>
/// The PoR (Proof of residency) check is completed by the client sharing a valid PoR document, if not fulfilled by the KYC check.
/// </summary>
public record UserCheckProofOfResidencyCreateRequest
{
    /// <summary>
    /// The type of check must be POR.
    /// </summary>
    [JsonPropertyName("type")]
    public string Type { get; init; } = "POR";

    /// <summary>
    /// Completion date and time of the PoR check.
    /// </summary>
    [JsonPropertyName("check_confirmed_at")]
    public required DateTimeOffset CheckConfirmedAt { get; init; }

    /// <summary>
    /// Issuance date in YYYY-MM-DD format.
    /// </summary>
    [JsonPropertyName("issuance_date")]
    [JsonConverter(typeof(UpvestInvestmentApi.Core.Converters.DateOnlyDateTimeOffsetConverter))]
    public required DateTimeOffset IssuanceDate { get; init; }

    /// <summary>
    /// Download URL for the PoR evidence file. The file size must not exceed 250 MB.
    /// </summary>
    [JsonPropertyName("data_download_link")]
    [MaxLength(1000)]
    public required string DataDownloadLink { get; init; }

    /// <summary>
    /// The type of document used in the PoR process. Maximum age of the document is 12 months (stated on the document) applicable for: Utility bills (water, gas, electricity), Telephone bills (only landline), Internet bills, Bank account statements. Documents that need to be still valid - Registration certificate (must be valid and issued within the past 5 years), Residence permit e.g. Blue Card (as long as valid and contains the registration address), ID Card that contains the registration address.
    /// * UTILITY_BILL -
    /// * TELEPHONE_BILL -
    /// * INTERNET_BILL -
    /// * BANK_STATEMENT -
    /// * REGISTRATION_CERT -
    /// * RESIDENCE_PERMIT -
    /// * ID_CARD -
    /// </summary>
    [JsonPropertyName("document_type")]
    public required DocumentType7 DocumentType { get; init; }

    /// <summary>
    /// Address. Must not be a P.O. box or c/o address.
    /// </summary>
    [JsonPropertyName("confirmed_address")]
    public required Address2 ConfirmedAddress { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
