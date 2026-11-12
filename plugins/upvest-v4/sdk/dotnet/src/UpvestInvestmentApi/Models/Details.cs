using System.Collections.Generic;
using System.Text.Json.Serialization;
using UpvestInvestmentApi.Core.Models;

namespace UpvestInvestmentApi.Models;

/// <summary>
/// Additional descriptive detail about an instrument, including where it may be distributed.
/// </summary>
public record Details
{
    /// <summary>
    /// The countries in which an instrument may be distributed, as ISO 3166-1 alpha-2 codes.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("distribution_countries")]
    public IReadOnlyList<string>? DistributionCountries { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
