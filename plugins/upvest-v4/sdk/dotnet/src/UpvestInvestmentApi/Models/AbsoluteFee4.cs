using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using UpvestInvestmentApi.Core.Models;
using UpvestInvestmentApi.Models.Enums;

namespace UpvestInvestmentApi.Models;

/// <summary>
/// A fee charged as a fixed cash amount.
/// </summary>
public record AbsoluteFee4
{
    /// <summary>
    /// What the fee is charged for.
    /// * TRANSACTION_FEE_BUY — A fee charged on a buy order.
    /// * TRANSACTION_FEE_SELL — A fee charged on a sell order.
    /// * ANNUAL_AUM_BASED_FEE — An annual fee charged as a percentage of assets under management.
    /// </summary>
    [JsonPropertyName("type")]
    public required FeeType8 Type { get; init; }

    /// <summary>
    /// The type of fee value must be “ABSOLUTE”.
    /// </summary>
    [JsonPropertyName("value_type")]
    public string ValueType { get; init; } = "ABSOLUTE";

    /// <summary>
    /// A positive cash amount, as a decimal string with up to two decimal places.
    /// </summary>
    [JsonPropertyName("cash_amount")]
    [RegularExpression("^[0-9]{1,9}(\\.[0-9]{2})?$")]
    public required string CashAmount { get; init; }

    /// <summary>
    /// Alphabetic three-letter <see href="https://www.iso.org/iso-4217-currency-codes.html">ISO 4217</see> currency code.
    /// * EUR — Euro.
    /// * GBP — Pound Sterling.
    /// </summary>
    [JsonPropertyName("currency")]
    public required Currency Currency { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
