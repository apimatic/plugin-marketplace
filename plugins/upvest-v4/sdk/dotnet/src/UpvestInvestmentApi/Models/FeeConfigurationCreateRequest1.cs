using System;
using System.Text.Json.Serialization;

namespace UpvestInvestmentApi.Models;

/// <summary>
/// Request body for assigning a fee model to an account.
/// </summary>
public record FeeConfigurationCreateRequest1
{
    /// <summary>
    /// Universally Unique Identifier (UUID) of the account.
    /// </summary>
    [JsonPropertyName("account_id")]
    public required Guid AccountId { get; init; }

    /// <summary>
    /// The unique identifier of the fee model, as a UUID. Upvest provides this value when a fee model is set up.
    /// </summary>
    [JsonPropertyName("fee_model_id")]
    public required Guid FeeModelId { get; init; }
}
