using System;
using System.Text.Json.Serialization;
using UpvestInvestmentApi.Models.Enums;

namespace UpvestInvestmentApi.Models;

/// <summary>
/// Entity representing security transaction reference.
/// </summary>
public record SecurityTransactionReference
{
    /// <summary>
    /// Unique identifier for a resource of given type.
    /// </summary>
    [JsonPropertyName("id")]
    public required Guid Id { get; init; }

    /// <summary>
    /// The kind of resource that this reference points to.
    /// * ORDER — Order.
    /// * ORDER_EXECUTION — Order execution.
    /// * CORPORATE_ACTION — Corporate action.
    /// * CORPORATE_ACTION_TRANSACTION_ID — Corporate action transaction ID.
    /// </summary>
    [JsonPropertyName("type")]
    public required Type51 Type { get; init; }
}
