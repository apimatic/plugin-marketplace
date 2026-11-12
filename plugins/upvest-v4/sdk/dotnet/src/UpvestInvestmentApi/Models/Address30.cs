using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using UpvestInvestmentApi.Core.Models;

namespace UpvestInvestmentApi.Models;

/// <summary>
/// The residential address of the end user, as printed on the report.
/// </summary>
public record Address30
{
    /// <summary>
    /// First line of the address.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("address_line1")]
    [MaxLength(100)]
    public string? AddressLine1 { get; init; }

    /// <summary>
    /// Second line of the address.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("address_line2")]
    [MaxLength(100)]
    public string? AddressLine2 { get; init; }

    /// <summary>
    /// Postal code (postcode, PIN or ZIP code)
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("postcode")]
    [RegularExpression("^[a-zA-Z0-9][a-zA-Z0-9\\s\\-]{0,8}[a-zA-Z0-9]?$")]
    public string? Postcode { get; init; }

    /// <summary>
    /// Country code. <see href="https://en.wikipedia.org/wiki/ISO_3166-1_alpha-2">ISO 3166 alpha-2 Codes</see>.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("country")]
    [RegularExpression("^[A-Z]{2}$")]
    public string? Country { get; init; }

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
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("city")]
    [StringLength(85, MinimumLength = 1)]
    public string? City { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
