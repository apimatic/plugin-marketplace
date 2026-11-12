using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using UpvestInvestmentApi.Models.Enums;

namespace UpvestInvestmentApi.Models;

/// <summary>
/// Entity representing the transaction fee.
/// </summary>
public record TransactionFee2
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
    /// What the fee figure covers.
    /// * TOTAL — Total fees.
    /// </summary>
    [JsonPropertyName("type")]
    public string Type { get; } = "TOTAL";

    /// <summary>
    /// How the fee was charged.
    /// * CHARGED_BY_CLIENT — Charged by client.
    /// * COLLECTED_BY_UPVEST — Charged by client and collected by Upvest.
    /// * CHARGED_BY_CLIENT_NET — Charged and collected by client; the fee is deducted from the transaction amount.
    /// </summary>
    [JsonPropertyName("charge_method")]
    public required ChargeMethod ChargeMethod { get; init; }
}
