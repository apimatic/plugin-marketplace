using System;
using System.Text.Json.Serialization;
using UpvestInvestmentApi.Models.Enums;

namespace UpvestInvestmentApi.Models;

/// <summary>
/// An individual sell order within an account liquidation, corresponding to the sale of a single position held in the account.
/// </summary>
public record AccountLiquidation1
{
    /// <summary>
    /// Universally Unique Identifier (UUID) of an account liquidation order.
    /// </summary>
    [JsonPropertyName("id")]
    public required Guid Id { get; init; }

    /// <summary>
    /// Side of the order. Liquidation orders are always <c>SELL</c>.
    /// </summary>
    [JsonPropertyName("side")]
    public string Side { get; init; } = "SELL";

    /// <summary>
    /// Execution status of the account liquidation order.
    /// * <c>NEW</c> — The order has been created and awaits processing.
    /// * <c>PROCESSING</c> — The order is being executed.
    /// * <c>FILLED</c> — The order has been fully executed.
    /// * <c>CANCELLED</c> — The order was cancelled before completion.
    /// </summary>
    [JsonPropertyName("status")]
    public required Status73 Status { get; init; }
}
