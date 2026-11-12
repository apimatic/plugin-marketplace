using System;
using System.Text.Json.Serialization;
using UpvestInvestmentApi.Core.Models;
using UpvestInvestmentApi.Models.Enums;

namespace UpvestInvestmentApi.Models;

/// <summary>
/// A fee charged according to a transaction fee model configured with Upvest.
/// </summary>
public record TransactionFee
{
    /// <summary>
    /// What the transaction fee is charged for.
    /// * TRANSACTION_FEE_BUY — A fee charged on a buy order.
    /// * TRANSACTION_FEE_SELL — A fee charged on a sell order.
    /// </summary>
    [JsonPropertyName("type")]
    public required FeeType10 Type { get; init; }

    /// <summary>
    /// The ID of the transaction fee model.
    /// </summary>
    [JsonPropertyName("transaction_fee_model_id")]
    public required Guid TransactionFeeModelId { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
