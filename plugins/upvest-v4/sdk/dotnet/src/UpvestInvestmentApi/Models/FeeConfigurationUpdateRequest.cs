using System;
using System.Text.Json.Serialization;

namespace UpvestInvestmentApi.Models;

/// <summary>
/// Request body for changing the fee model assigned to an account.
/// </summary>
public record FeeConfigurationUpdateRequest
{
    /// <summary>
    /// The unique identifier of the fee model, as a UUID. Upvest provides this value when a fee model is set up.
    /// </summary>
    [JsonPropertyName("fee_model_id")]
    public required Guid FeeModelId { get; init; }
}
