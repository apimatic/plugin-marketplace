using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using UpvestInvestmentApi.Core.Models;

namespace UpvestInvestmentApi.Models;

/// <summary>
/// Entity representing the security transaction delta.
/// </summary>
public record SecurityTransactionDelta
{
    [JsonPropertyName("amount")]
    [RegularExpression("^-?[0-9]{0,63}(\\.[0-9]{1,27})?$")]
    public required string Amount { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
