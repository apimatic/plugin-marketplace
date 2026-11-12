using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using UpvestInvestmentApi.Core.Models;
using UpvestInvestmentApi.Models.Enums;

namespace UpvestInvestmentApi.Models;

public record WithTaxIdentifierNumber
{
    /// <summary>
    /// Accepted country code. <see href="https://en.wikipedia.org/wiki/ISO_3166-1_alpha-2">ISO 3166-1 alpha-2 codes</see>.
    /// </summary>
    [JsonPropertyName("country")]
    public required Country Country { get; init; }

    /// <summary>
    /// Tax identification number (TIN) issued to the user by the tax authorities of the given country
    /// </summary>
    [JsonPropertyName("tax_identifier_number")]
    [StringLength(20, MinimumLength = 1)]
    public required string TaxIdentifierNumber { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
