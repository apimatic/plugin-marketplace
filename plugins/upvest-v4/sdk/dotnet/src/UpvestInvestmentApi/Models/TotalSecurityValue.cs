using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using UpvestInvestmentApi.Models.Enums;

namespace UpvestInvestmentApi.Models;

/// <summary>
/// Entity representing the monetary value by amount and currency.
/// </summary>
public record TotalSecurityValue
{
    /// <summary>
    /// A decimal-string monetary amount used in account valuation calculations.
    /// </summary>
    [JsonPropertyName("amount")]
    [RegularExpression("^[0-9]{0,63}(\\.[0-9]{1,2})?$")]
    public required string Amount { get; init; }

    /// <summary>
    /// Alphabetic three-letter <see href="https://www.iso.org/iso-4217-currency-codes.html">ISO 4217</see> currency code.
    /// * EUR — Euro.
    /// * GBP — Pound Sterling.
    /// </summary>
    [JsonPropertyName("currency")]
    public required Currency Currency { get; init; }
}
