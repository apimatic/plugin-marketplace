using System;
using System.Text.Json.Serialization;
using UpvestInvestmentApi.Core.Models;
using UpvestInvestmentApi.Models.Enums;

namespace UpvestInvestmentApi.Models;

/// <summary>
/// An account group owned by a business. Aggregates its accounts for tax calculation and regulatory reporting, holds positions in the form of cash, and carries the official securities account number.
/// </summary>
public record BusinessAccountGroup
{
    /// <summary>
    /// Universally Unique Identifier (UUID) of the account group.
    /// </summary>
    [JsonPropertyName("id")]
    public required Guid Id { get; init; }

    /// <summary>
    /// Date and time when the resource was created. <see href="https://datatracker.ietf.org/doc/html/rfc3339#section-5.6">RFC 3339-5</see>, <see href="https://www.iso.org/iso-8601-date-and-time-format.html">ISO8601 UTC</see>
    /// </summary>
    [JsonPropertyName("created_at")]
    public required DateTimeOffset CreatedAt { get; init; }

    /// <summary>
    /// Date and time when the resource was last updated. <see href="https://datatracker.ietf.org/doc/html/rfc3339#section-5.6">RFC 3339-5</see>, <see href="https://www.iso.org/iso-8601-date-and-time-format.html">ISO8601 UTC</see>
    /// </summary>
    [JsonPropertyName("updated_at")]
    public required DateTimeOffset UpdatedAt { get; init; }

    /// <summary>
    /// Unique identifier for the business.
    /// </summary>
    [JsonPropertyName("business_id")]
    public required Guid BusinessId { get; init; }

    /// <summary>
    /// Status of the account group.
    /// * <c>PENDING_APPROVAL</c> — Account group approval is pending — the account group is visible through our API but cannot be acted on.
    /// * <c>ACTIVE</c> — Account group is active — full functionality of the Investment API is accessible.
    /// * <c>CLOSING</c> — Account group is closing.
    /// * <c>CLOSED</c> — Account group is closed.
    /// * <c>LOCKED</c> — Account group is locked for all actions.
    /// </summary>
    [JsonPropertyName("status")]
    public required Status18 Status { get; init; }

    /// <summary>
    /// Account group type.
    /// * BUSINESS - Account group of a business holding assets.
    /// </summary>
    [JsonPropertyName("type")]
    public string Type { get; } = "BUSINESS";

    /// <summary>
    /// Official securities account number, assigned at account group level. A string of 7 to 12 digits.
    /// </summary>
    [JsonPropertyName("securities_account_number")]
    public required string SecuritiesAccountNumber { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
