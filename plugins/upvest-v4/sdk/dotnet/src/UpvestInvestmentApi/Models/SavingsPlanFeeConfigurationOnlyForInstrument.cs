using System;
using System.Text.Json.Serialization;

namespace UpvestInvestmentApi.Models;

public record SavingsPlanFeeConfigurationOnlyForInstrument
{
    /// <summary>
    /// Fee type
    /// * TRANSACTION_FEE_BUY -
    /// </summary>
    [JsonPropertyName("type")]
    public string Type { get; } = "TRANSACTION_FEE_BUY";

    /// <summary>
    /// Universally Unique Identifier (UUID) of the transaction fee model.
    /// </summary>
    [JsonPropertyName("transaction_fee_model_id")]
    public required Guid TransactionFeeModelId { get; init; }
}
