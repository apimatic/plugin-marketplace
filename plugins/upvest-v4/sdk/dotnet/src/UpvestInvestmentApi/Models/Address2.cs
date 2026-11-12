using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using UpvestInvestmentApi.Core.Models;
using UpvestInvestmentApi.Models.Enums;

namespace UpvestInvestmentApi.Models;

/// <summary>
/// Address. Must not be a P.O. box or c/o address.
/// </summary>
public record Address2
{
    /// <summary>
    /// First address line of the address.
    /// </summary>
    [JsonPropertyName("address_line1")]
    [MaxLength(100)]
    public required string AddressLine1 { get; init; }

    /// <summary>
    /// Second address line of the address.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("address_line2")]
    [MaxLength(100)]
    public string? AddressLine2 { get; init; }

    /// <summary>
    /// Postal code (postcode, PIN or ZIP code)
    /// </summary>
    [JsonPropertyName("postcode")]
    [RegularExpression("^[a-zA-Z0-9][a-zA-Z0-9\\s\\-]{0,8}[a-zA-Z0-9]?$")]
    public required string Postcode { get; init; }

    /// <summary>
    /// Accepted country code. <see href="https://en.wikipedia.org/wiki/ISO_3166-1_alpha-2">ISO 3166-1 alpha-2 codes</see>.
    /// </summary>
    [JsonPropertyName("country")]
    public required Country Country { get; init; }

    /// <summary>
    /// State, province, county. <see href="https://en.wikipedia.org/wiki/ISO_3166-1_alpha-2">ISO 3166 alpha-2 Codes</see>.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("state")]
    [MaxLength(50)]
    public string? State { get; init; }

    /// <summary>
    /// The name of a city, as it appears in a postal address.
    /// </summary>
    [JsonPropertyName("city")]
    [StringLength(85, MinimumLength = 1)]
    public required string City { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
