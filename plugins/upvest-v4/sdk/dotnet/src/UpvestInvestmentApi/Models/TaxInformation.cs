using System.Text.Json.Serialization;
using UpvestInvestmentApi.Core.Models;
using UpvestInvestmentApi.Models.Enums;

namespace UpvestInvestmentApi.Models;

/// <summary>
/// Tax information of the business.
/// </summary>
public record TaxInformation
{
    /// <summary>
    /// Accepted country code. <see href="https://en.wikipedia.org/wiki/ISO_3166-1_alpha-2">ISO 3166-1 alpha-2 codes</see>.
    /// </summary>
    [JsonPropertyName("tax_country_code")]
    public required TaxCountryCode TaxCountryCode { get; init; }

    /// <summary>
    /// Type of tax identification used by the business.
    /// </summary>
    [JsonPropertyName("tax_identification_type")]
    public required TaxIdentificationType TaxIdentificationType { get; init; }

    /// <summary>
    /// Tax identification number of the business.
    /// <para>
    /// When <c>tax_identification_type</c> is <c>STEUERNUMMER</c>, the value is 10 or 11 digits, provided either as bare digits or in a state-specific slash-grouped layout. Slashes are all-or-nothing and must appear at the grouping positions:
    /// </para>
    /// <para>
    /// | Format | Grouping | Example |
    /// | --- | --- | --- |
    /// | Bare digits | 10 or 11 digits | <c>1234567890</c>, <c>12345678901</c> |
    /// | North Rhine-Westphalia | 3/4/4 | <c>133/8150/8159</c> |
    /// | Bavaria | 3/3/5 | <c>181/815/08155</c> |
    /// | Standard 10-digit | 2/3/5 | <c>24/815/08151</c> |
    /// | Alternative 10-digit (Berlin, Bremen, Lower Saxony) | 3/3/4 | <c>181/815/0815</c> |
    /// </para>
    /// <para>
    /// When <c>tax_identification_type</c> is <c>WIRTSCHAFTSIDENTIFIKATIONSNUMMER</c>, the value is <c>DE</c> followed by 9 digits, with an optional 5-digit distinguishing feature (for example <c>DE123456789</c> or <c>DE123456789-00001</c>).
    /// </para>
    /// </summary>
    [JsonPropertyName("tax_identification_number")]
    public required string TaxIdentificationNumber { get; init; }

    /// <summary>
    /// Indicates if the business is resident in multiple tax jurisdictions.
    /// </summary>
    [JsonPropertyName("is_resident_in_multiple_tax_jurisdictions")]
    public required bool IsResidentInMultipleTaxJurisdictions { get; init; }

    /// <summary>
    /// Indicates if the business is subject to FATCA regulations.
    /// </summary>
    [JsonPropertyName("is_subject_to_fatca")]
    public required bool IsSubjectToFatca { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
