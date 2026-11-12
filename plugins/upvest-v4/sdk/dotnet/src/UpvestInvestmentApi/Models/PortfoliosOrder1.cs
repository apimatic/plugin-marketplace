using System;
using System.Text.Json.Serialization;
using UpvestInvestmentApi.Models.Enums;

namespace UpvestInvestmentApi.Models;

/// <summary>
/// An individual instrument order within a portfolio order, representing the BUY or SELL of a single instrument.
/// </summary>
public record PortfoliosOrder1
{
    /// <summary>
    /// Unique identifier for an order. Universally Unique Identifier (UUID).
    /// </summary>
    [JsonPropertyName("id")]
    public required Guid Id { get; init; }

    /// <summary>
    /// Side of the portfolio order.
    /// * BUY -
    /// * SELL -
    /// </summary>
    [JsonPropertyName("side")]
    public required Side15 Side { get; init; }

    /// <summary>
    /// The execution status of the order.
    /// * NEW — the order has been received and validated, awaiting routing.
    /// * PROCESSING — the order is being routed for execution.
    /// * FILLED — the order has been fully executed.
    /// * CANCELLED — the order was cancelled before being fully executed.
    /// </summary>
    [JsonPropertyName("status")]
    public required Status51 Status { get; init; }
}
