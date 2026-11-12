using System.Text.Json.Serialization;
using UpvestInvestmentApi.Core.Models;
using UpvestInvestmentApi.Core.Validation;
using UpvestInvestmentApi.Core.Validation.Attributes;

namespace UpvestInvestmentApi.Models;

/// <summary>
/// Schema for business company information.
/// </summary>
public record BusinessSoleTraderCreateRequest
{
    /// <summary>
    /// Contact email address of the business.
    /// </summary>
    [JsonPropertyName("contact_email")]
    [Format(FormatKind.Email)]
    public required string ContactEmail { get; init; }

    /// <summary>
    /// Address. Must not be a P.O. box or c/o address.
    /// </summary>
    [JsonPropertyName("registered_address")]
    public required Address2 RegisteredAddress { get; init; }

    /// <summary>
    /// Registration number of the business.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("registration_number")]
    public string? RegistrationNumber { get; init; }

    /// <summary>
    /// Tax information of the business.
    /// </summary>
    [JsonPropertyName("tax_information")]
    public required TaxInformation TaxInformation { get; init; }

    /// <summary>
    /// Type of the business. Always <c>SOLE_TRADER</c> for sole trader businesses.
    /// </summary>
    [JsonPropertyName("business_type")]
    public string BusinessType { get; init; } = "SOLE_TRADER";

    /// <summary>
    /// Identification information of the sole trader business.
    /// </summary>
    [JsonPropertyName("identification")]
    public required Identification9 Identification { get; init; }

    /// <summary>
    /// Terms and conditions agreement.
    /// </summary>
    [JsonPropertyName("terms_and_conditions")]
    public required TermsAndConditions5 TermsAndConditions { get; init; }

    /// <summary>
    /// Data privacy and sharing agreement.
    /// </summary>
    [JsonPropertyName("data_privacy_and_sharing_agreement")]
    public required DataPrivacyAndSharingAgreement5 DataPrivacyAndSharingAgreement { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
