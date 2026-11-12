using System;
using System.Text.Json.Serialization;

namespace UpvestInvestmentApi.Models;

/// <summary>
/// Response returned when an order cancellation request is accepted. Contains the <c>id</c> of the order for which cancellation was requested.
/// </summary>
public record OrderCancelResponse
{
    /// <summary>
    /// Unique identifier for an order. Universally Unique Identifier (UUID).
    /// </summary>
    [JsonPropertyName("id")]
    public required Guid Id { get; init; }
}
