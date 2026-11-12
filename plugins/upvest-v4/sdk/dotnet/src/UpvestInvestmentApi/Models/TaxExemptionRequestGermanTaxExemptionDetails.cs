using System.Text.Json.Serialization;
using UpvestInvestmentApi.Models.Enums;

namespace UpvestInvestmentApi.Models;

/// <summary>
/// The German tax exemption details supplied when creating or updating a tax exemption order.
/// </summary>
public record TaxExemptionRequestGermanTaxExemptionDetails
{
    /// <summary>
    /// Tax exemption type
    /// * SINGLE - Tax exemption for Individual.
    /// * MARRIED - Tax exemption for married couples.
    /// * CIVIL_PARTNERSHIP - Tax exemption for registered civil partnerships.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("tax_exemption_type")]
    public TaxExemptionType? TaxExemptionType { get; init; }

    /// <summary>
    /// A monetary amount relating to a tax exemption order, with its <see href="https://www.iso.org/iso-4217-currency-codes.html">ISO 4217</see> currency.
    /// </summary>
    [JsonPropertyName("tax_exemption_amount")]
    public required TaxExemptionCreateRequestTaxExemptionDetailsAmount TaxExemptionAmount { get; init; }
}
