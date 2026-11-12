using System;
using System.Text.Json.Serialization;
using UpvestInvestmentApi.Core.Models;
using UpvestInvestmentApi.Models.Enums;

namespace UpvestInvestmentApi.Models;

/// <summary>
/// A fee configuration that references a predefined transaction fee model by its ID, rather than specifying a fee amount directly.
/// </summary>
public record TransactionFeeModel
{
    /// <summary>
    /// Fee type
    /// * TRANSACTION_FEE_BUY -
    /// * TRANSACTION_FEE_SELL -
    /// </summary>
    [JsonPropertyName("type")]
    public required FeeType Type { get; init; }

    /// <summary>
    /// The ID of the transaction fee model.
    /// </summary>
    [JsonPropertyName("transaction_fee_model_id")]
    public required Guid TransactionFeeModelId { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
