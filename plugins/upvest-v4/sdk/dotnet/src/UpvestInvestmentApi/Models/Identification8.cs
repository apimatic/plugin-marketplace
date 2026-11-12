using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using UpvestInvestmentApi.Core.Models;
using UpvestInvestmentApi.Models.Enums;

namespace UpvestInvestmentApi.Models;

/// <summary>
/// Identification information of the business.
/// </summary>
public record Identification8
{
    /// <summary>
    /// Name of the company.
    /// </summary>
    [JsonPropertyName("company_name")]
    public required string CompanyName { get; init; }

    /// <summary>
    /// Incorporation date of the business in YYYY-MM-DD format. <see href="https://json-schema.org/draft/2020-12/json-schema-validation.html#RFC3339">RFC 3339, section 5.6</see>
    /// </summary>
    [JsonPropertyName("incorporation_date")]
    public required string IncorporationDate { get; init; }

    /// <summary>
    /// District court where the company is registered.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("district_court")]
    [StringLength(40, MinimumLength = 1)]
    public string? DistrictCourt { get; init; }

    /// <summary>
    /// Country specific legal designation of the company.
    /// </summary>
    [JsonPropertyName("legal_designation")]
    public required LegalDesignation LegalDesignation { get; init; }

    /// <summary>
    /// Legal Entity Identifier (LEI) of the company. A 20-character alphanumeric code as defined by <see href="https://en.wikipedia.org/wiki/Legal_Entity_Identifier">ISO 17442</see>.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("legal_entity_identifier")]
    [RegularExpression("^[A-Z0-9]{18}[0-9]{2}$")]
    public string? LegalEntityIdentifier { get; init; }

    /// <summary>
    /// Common reporting standards information.
    /// </summary>
    [JsonPropertyName("common_reporting_standards")]
    public required CommonReportingStandards CommonReportingStandards { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
