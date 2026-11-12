using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using UpvestInvestmentApi.Models.Enums;

namespace UpvestInvestmentApi.Models;

/// <summary>
/// A third-party payment received in connection with the investment service, disclosed as required by MiFID II.
/// </summary>
public record Inducement
{
    /// <summary>
    /// The type of inducement value must be “ABSOLUTE”.
    /// </summary>
    [JsonPropertyName("value_type")]
    public string ValueType { get; init; } = "ABSOLUTE";

    [JsonPropertyName("cash_amount")]
    [RegularExpression("^-?[0-9]{1,9}(\\.[0-9]{2})?$")]
    public required string CashAmount { get; init; }

    /// <summary>
    /// Alphabetic three-letter <see href="https://www.iso.org/iso-4217-currency-codes.html">ISO 4217</see> currency code.
    /// * EUR — Euro.
    /// * GBP — Pound Sterling.
    /// </summary>
    [JsonPropertyName("currency")]
    public required Currency Currency { get; init; }
}
