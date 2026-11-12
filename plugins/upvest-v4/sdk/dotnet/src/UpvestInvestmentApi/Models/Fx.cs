using System.Text.Json.Serialization;
using UpvestInvestmentApi.Models.Enums;

namespace UpvestInvestmentApi.Models;

/// <summary>
/// Entity representing the applied FX rate for a cash transaction. Present only for corporate action cash transactions where the distribution currency differs from the source/income currency. Omitted for every other transaction type, and also for domestic transactions where those currencies match (no conversion occurred).
/// </summary>
public record Fx
{
    /// <summary>
    /// The distribution currency.
    /// </summary>
    [JsonPropertyName("base_currency")]
    public required BaseCurrency BaseCurrency { get; init; }

    /// <summary>
    /// The source/income currency.
    /// </summary>
    [JsonPropertyName("quote_currency")]
    public required QuoteCurrency QuoteCurrency { get; init; }

    /// <summary>
    /// Entity representing the applied FX rate for a currency conversion.
    /// </summary>
    [JsonPropertyName("rate")]
    public required FxRate Rate { get; init; }
}
