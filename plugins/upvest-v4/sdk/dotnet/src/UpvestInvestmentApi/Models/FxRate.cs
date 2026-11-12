using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace UpvestInvestmentApi.Models;

/// <summary>
/// Entity representing the applied FX rate for a currency conversion.
/// </summary>
public record FxRate
{
    /// <summary>
    /// The all-in rate applied to the conversion, including any markup.
    /// </summary>
    [JsonPropertyName("all_in_rate")]
    [RegularExpression("^[0-9]{0,63}(\\.[0-9]{1,27})?$")]
    public required string AllInRate { get; init; }

    /// <summary>
    /// The base rate applied to the conversion, excluding markup.
    /// </summary>
    [JsonPropertyName("base_rate")]
    [RegularExpression("^[0-9]{0,63}(\\.[0-9]{1,27})?$")]
    public required string BaseRate { get; init; }

    /// <summary>
    /// The markup applied on top of the base rate.
    /// </summary>
    [JsonPropertyName("markup_rate")]
    [RegularExpression("^[0-9]{0,63}(\\.[0-9]{1,27})?$")]
    public required string MarkupRate { get; init; }
}
