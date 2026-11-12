using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using UpvestInvestmentApi.Models.Enums;

namespace UpvestInvestmentApi.Models;

/// <summary>
/// Entity representing the transaction tax.
/// </summary>
public record TransactionTax1
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
    /// The kind of tax this component represents.
    /// * CAPITAL_GAINS — Capital gains tax.
    /// * CHURCH_TAX — German church tax (Kirchensteuer).
    /// * SOLIDARITY_SURCHARGE — German solidarity surcharge (Solidaritätszuschlag).
    /// * FINANCIAL_TRANSACTION_TAX — Financial transaction tax.
    /// * STAMP_DUTY — Stamp duty.
    /// * INTERNATIONAL_WITHHOLDING_TAX — Withholding tax levied in another jurisdiction.
    /// </summary>
    [JsonPropertyName("type")]
    public required Type49 Type { get; init; }

    /// <summary>
    /// Country code. <see href="https://en.wikipedia.org/wiki/ISO_3166-1_alpha-2">ISO 3166 alpha-2 Codes</see>.
    /// </summary>
    [JsonPropertyName("taxing_jurisdiction")]
    [RegularExpression("^[A-Z]{2}$")]
    public required string TaxingJurisdiction { get; init; }
}
