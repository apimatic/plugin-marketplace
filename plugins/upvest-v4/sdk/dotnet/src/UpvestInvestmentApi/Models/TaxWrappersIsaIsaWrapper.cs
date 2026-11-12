using System;
using System.Text.Json.Serialization;
using UpvestInvestmentApi.Models.Enums;

namespace UpvestInvestmentApi.Models;

/// <summary>
/// An ISA tax wrapper, holding the business rules that apply to a tax-wrapped investment account group. The wrapper must be active before the ISA account group can become active.
/// </summary>
public record TaxWrappersIsaIsaWrapper
{
    /// <summary>
    /// Tax wrapper unique identifier.
    /// </summary>
    [JsonPropertyName("id")]
    public required Guid Id { get; init; }

    /// <summary>
    /// The date and time the tax wrapper was created.
    /// </summary>
    [JsonPropertyName("created_at")]
    public required DateTimeOffset CreatedAt { get; init; }

    /// <summary>
    /// The date and time the tax wrapper was last updated.
    /// </summary>
    [JsonPropertyName("updated_at")]
    public required DateTimeOffset UpdatedAt { get; init; }

    /// <summary>
    /// Account group unique identifier.
    /// </summary>
    [JsonPropertyName("account_group_id")]
    public required Guid AccountGroupId { get; init; }

    /// <summary>
    /// True if tax wrapper is flexible.
    /// </summary>
    [JsonPropertyName("is_flexible")]
    public required bool IsFlexible { get; init; }

    /// <summary>
    /// Status of the tax wrapper
    /// * NEW - The tax wrapper is newly created and not yet active due to pending checks.
    /// * ACTIVE - The tax wrapper is currently active and in use.
    /// * INACTIVE - The tax wrapper is not currently active. New subscriptions not allowed.
    /// * CLOSED - The tax wrapper has been closed and is no longer available.
    /// </summary>
    [JsonPropertyName("status")]
    public required Status56 Status { get; init; }

    /// <summary>
    /// The kind of ISA that the tax wrapper represents.
    /// * STOCKS_AND_SHARES_ISA — A Stocks and Shares ISA.
    /// </summary>
    [JsonPropertyName("type")]
    public string Type { get; } = "STOCKS_AND_SHARES_ISA";
}
