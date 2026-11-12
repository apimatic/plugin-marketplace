using System;
using System.Text.Json.Serialization;

namespace UpvestInvestmentApi.Models;

public record TransactionFeeAccountGroupConfigurationUpdateRequest
{
    /// <summary>
    /// Universally Unique Identifier (UUID) of the transaction fee model.
    /// </summary>
    [JsonPropertyName("fee_model_id")]
    public required Guid FeeModelId { get; init; }
}
