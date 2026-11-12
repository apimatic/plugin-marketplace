using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using UpvestInvestmentApi.Models.Enums;

namespace UpvestInvestmentApi.Models;

/// <summary>
/// Entity representing the transaction tax.
/// </summary>
public record TransactionTax
{
    [JsonPropertyName("amount")]
    [RegularExpression("^-?[0-9]{1,9}(\\.[0-9]{2})?$")]
    public required string Amount { get; init; }

    /// <summary>
    /// Alphabetic three-letter <see href="https://www.iso.org/iso-4217-currency-codes.html">ISO 4217</see> currency code.
    /// * EUR — Euro.
    /// * GBP — Pound Sterling.
    /// * USD — The United States dollar.
    /// </summary>
    [JsonPropertyName("currency")]
    public required Currency1 Currency { get; init; }

    /// <summary>
    /// What the tax figure covers.
    /// * TOTAL — Total taxes.
    /// </summary>
    [JsonPropertyName("type")]
    public string Type { get; } = "TOTAL";
}
