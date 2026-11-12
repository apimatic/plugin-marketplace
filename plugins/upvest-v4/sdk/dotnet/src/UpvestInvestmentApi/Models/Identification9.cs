using System.Text.Json.Serialization;
using UpvestInvestmentApi.Core.Models;
using UpvestInvestmentApi.Models.Enums;

namespace UpvestInvestmentApi.Models;

/// <summary>
/// Identification information of the sole trader business.
/// </summary>
public record Identification9
{
    /// <summary>
    /// Name of the sole trader business.
    /// </summary>
    [JsonPropertyName("company_name")]
    public required string CompanyName { get; init; }

    /// <summary>
    /// Incorporation date of the business in YYYY-MM-DD format. <see href="https://json-schema.org/draft/2020-12/json-schema-validation.html#RFC3339">RFC 3339, section 5.6</see>
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("incorporation_date")]
    public string? IncorporationDate { get; init; }

    /// <summary>
    /// Country specific legal designation of the sole trader business.
    /// </summary>
    [JsonPropertyName("legal_designation")]
    public required LegalDesignation1 LegalDesignation { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
