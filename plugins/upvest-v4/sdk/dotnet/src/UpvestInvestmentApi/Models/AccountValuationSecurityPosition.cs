using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using UpvestInvestmentApi.Models.Enums;

namespace UpvestInvestmentApi.Models;

/// <summary>
/// The value contributed by a single instrument position to an account valuation, including its quantity, value, and weight in the account.
/// </summary>
public record AccountValuationSecurityPosition
{
    /// <summary>
    /// Entity representing the financial instrument.
    /// </summary>
    [JsonPropertyName("instrument")]
    public required Instrument6 Instrument { get; init; }

    [JsonPropertyName("quantity")]
    [RegularExpression("^-?[0-9]{0,63}(\\.[0-9]{1,10})?$")]
    public required string Quantity { get; init; }

    /// <summary>
    /// The value of this instrument position, or <c>null</c> if no price was available at the requested price quality.
    /// </summary>
    [JsonPropertyName("value")]
    public required Value? Value { get; init; }

    /// <summary>
    /// Total weight of the instrument (10 decimal places).
    /// </summary>
    [JsonPropertyName("weight")]
    [RegularExpression("^-?[0-9]{0,63}(\\.[0-9]{1,10})?$")]
    public required string? Weight { get; init; }

    /// <summary>
    /// The price quality used to calculate the value of this position.
    /// * EOD - End of day price
    /// * REALTIME - Real-time price
    /// * DELAYED - Delayed price
    /// * NA - No price was available.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("price_quality")]
    public PriceQuality5? PriceQuality { get; init; }
}
