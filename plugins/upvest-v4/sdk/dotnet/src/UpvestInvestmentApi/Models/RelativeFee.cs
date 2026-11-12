using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using UpvestInvestmentApi.Core.Models;
using UpvestInvestmentApi.Models.Enums;

namespace UpvestInvestmentApi.Models;

/// <summary>
/// A fee charged as a rate in basis points on the transaction amount.
/// </summary>
public record RelativeFee
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
    /// The type of fee value must be “RELATIVE”.
    /// </summary>
    [JsonPropertyName("value_type")]
    public string ValueType { get; init; } = "RELATIVE";

    [JsonPropertyName("bps")]
    [RegularExpression("^-?[0-9]{0,63}(\\.[0-9]{1,27})?$")]
    public required string Bps { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
