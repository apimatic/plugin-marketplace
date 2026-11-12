using System.Text.Json.Serialization;
using UpvestInvestmentApi.Core.Models;
using UpvestInvestmentApi.Core.Validation;
using UpvestInvestmentApi.Core.Validation.Attributes;

namespace UpvestInvestmentApi.Models;

/// <summary>
/// Request payload for updating a company business. Currently only the contact email address can be changed.
/// </summary>
public record BusinessCompanyUpdateRequest
{
    /// <summary>
    /// Contact email address of the business.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("contact_email")]
    [Format(FormatKind.Email)]
    public string? ContactEmail { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
