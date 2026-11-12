using System.Text.Json.Serialization;
using UpvestInvestmentApi.Core.Models;

namespace UpvestInvestmentApi.Models;

/// <summary>
/// Common reporting standards information.
/// </summary>
public record CommonReportingStandards
{
    /// <summary>
    /// Indicates if the company is a passive non-financial entity.
    /// </summary>
    [JsonPropertyName("is_passive_non_financial_entity")]
    public required bool IsPassiveNonFinancialEntity { get; init; }

    /// <summary>
    /// Indicates if the company is a financial institution.
    /// </summary>
    [JsonPropertyName("is_financial_institution")]
    public required bool IsFinancialInstitution { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
