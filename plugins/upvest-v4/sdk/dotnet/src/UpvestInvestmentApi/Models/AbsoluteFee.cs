using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using UpvestInvestmentApi.Core.Models;
using UpvestInvestmentApi.Models.Enums;

namespace UpvestInvestmentApi.Models;

/// <summary>
/// A fixed cash fee applied to an order, specified as an absolute amount in a given currency.
/// </summary>
public record AbsoluteFee
{
    /// <summary>
    /// Fee type
    /// * TRANSACTION_FEE_BUY -
    /// * TRANSACTION_FEE_SELL -
    /// </summary>
    [JsonPropertyName("type")]
    public required FeeType Type { get; init; }

    /// <summary>
    /// The value type must be “ABSOLUTE”.
    /// </summary>
    [JsonPropertyName("value_type")]
    public string ValueType { get; init; } = "ABSOLUTE";

    /// <summary>
    /// Indicates whether the fee will be charged by client or by other methods.
    /// * CHARGED_BY_CLIENT -
    /// * COLLECTED_BY_UPVEST -
    /// </summary>
    [JsonPropertyName("charge_method")]
    public required FeeChargeMethod ChargeMethod { get; init; }

    /// <summary>
    /// A positive cash amount, as a decimal string with up to two decimal places.
    /// </summary>
    [JsonPropertyName("cash_amount")]
    [RegularExpression("^[0-9]{1,9}(\\.[0-9]{2})?$")]
    public required string CashAmount { get; init; }

    /// <summary>
    /// Alphabetic three-letter <see href="https://www.iso.org/iso-4217-currency-codes.html">ISO 4217</see> currency code.
    /// * EUR - Euro
    /// * GBP - British Pound
    /// * USD - US Dollar
    /// </summary>
    [JsonPropertyName("currency")]
    public required Currency29 Currency { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
