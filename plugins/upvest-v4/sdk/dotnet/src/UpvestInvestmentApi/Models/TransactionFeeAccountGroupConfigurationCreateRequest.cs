using System;
using System.Text.Json.Serialization;
using UpvestInvestmentApi.Models.Enums;

namespace UpvestInvestmentApi.Models;

public record TransactionFeeAccountGroupConfigurationCreateRequest
{
    /// <summary>
    /// Universally Unique Identifier (UUID) of the transaction fee model.
    /// </summary>
    [JsonPropertyName("fee_model_id")]
    public required Guid FeeModelId { get; init; }

    /// <summary>
    /// Universally Unique Identifier (UUID) of the account group.
    /// </summary>
    [JsonPropertyName("account_group_id")]
    public required Guid AccountGroupId { get; init; }

    /// <summary>
    /// The operation type a transaction fee model is assigned to.
    /// * PENSION_DE_CONTRIBUTION -
    /// * PENSION_DE_CONTRIBUTION_GOVERNMENT_BONUS -
    /// * PENSION_DE_INCOMING_TRANSFER -
    /// * PENSION_DE_OUTGOING_TRANSFER -
    /// </summary>
    [JsonPropertyName("transaction_category")]
    public required TransactionCategory TransactionCategory { get; init; }
}
