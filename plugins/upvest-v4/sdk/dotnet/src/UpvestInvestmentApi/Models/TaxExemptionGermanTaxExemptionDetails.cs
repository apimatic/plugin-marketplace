using System.Text.Json.Serialization;
using UpvestInvestmentApi.Models.Enums;

namespace UpvestInvestmentApi.Models;

/// <summary>
/// The German tax exemption details returned for a tax exemption order, including the allowance granted and the amounts used and remaining for the tax year.
/// </summary>
public record TaxExemptionGermanTaxExemptionDetails
{
    /// <summary>
    /// Tax exemption type
    /// * SINGLE - Tax exemption for Individual.
    /// * MARRIED - Tax exemption for married couples.
    /// * CIVIL_PARTNERSHIP - Tax exemption for registered civil partnerships.
    /// </summary>
    [JsonPropertyName("tax_exemption_type")]
    public required TaxExemptionType TaxExemptionType { get; init; }

    /// <summary>
    /// A monetary amount relating to a tax exemption order, with its <see href="https://www.iso.org/iso-4217-currency-codes.html">ISO 4217</see> currency.
    /// </summary>
    [JsonPropertyName("tax_exemption_amount")]
    public required TaxExemptionCreateRequestTaxExemptionDetailsAmount TaxExemptionAmount { get; init; }

    /// <summary>
    /// A monetary amount relating to a tax exemption order, with its <see href="https://www.iso.org/iso-4217-currency-codes.html">ISO 4217</see> currency.
    /// </summary>
    [JsonPropertyName("utilized_amount")]
    public required TaxExemptionCreateRequestTaxExemptionDetailsAmount UtilizedAmount { get; init; }

    /// <summary>
    /// A monetary amount relating to a tax exemption order, with its <see href="https://www.iso.org/iso-4217-currency-codes.html">ISO 4217</see> currency.
    /// </summary>
    [JsonPropertyName("remaining_amount")]
    public required TaxExemptionCreateRequestTaxExemptionDetailsAmount RemainingAmount { get; init; }
}
