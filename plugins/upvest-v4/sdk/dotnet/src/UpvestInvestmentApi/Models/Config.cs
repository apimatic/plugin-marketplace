using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using UpvestInvestmentApi.Core.Models;
using UpvestInvestmentApi.Core.Validation.Attributes;

namespace UpvestInvestmentApi.Models;

/// <summary>
/// Configuration of webhook packages collection.
/// </summary>
public record Config
{
    /// <summary>
    /// Maximum time of package collection (1s-30s).
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("delay")]
    [RegularExpression("^([1-9]|[12][0-9]|30)s$")]
    public string? Delay { get; init; }

    /// <summary>
    /// Maximum package size (bytes)
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("max_package_size")]
    [Minimum(100)]
    [Maximum(1048576)]
    public int? MaxPackageSize { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
