using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using UpvestInvestmentApi.Models.Enums;

namespace UpvestInvestmentApi.Models;

/// <summary>
/// The total value of the instruments held in an account at a specific point in time, calculated from the positions and instrument prices applicable at that time.
/// </summary>
public record AccountValuation
{
    /// <summary>
    /// Account valuation unique identifier.
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
    /// Universally Unique Identifier (UUID) of the account.
    /// </summary>
    [JsonPropertyName("account_id")]
    public required Guid AccountId { get; init; }

    /// <summary>
    /// Entity representing the monetary value by amount and currency.
    /// </summary>
    [JsonPropertyName("total_security_value")]
    public required TotalSecurityValue TotalSecurityValue { get; init; }

    /// <summary>
    /// The requested price quality.
    /// * EOD - End of day prices
    /// * HIGHEST_AVAILABLE - The most recent available prices
    /// </summary>
    [JsonPropertyName("price_quality")]
    public required PriceQuality4 PriceQuality { get; init; }

    /// <summary>
    /// Positions associated with this account valuation.
    /// </summary>
    [JsonPropertyName("security_positions")]
    public required IReadOnlyList<AccountValuationSecurityPosition> SecurityPositions { get; init; }

    /// <summary>
    /// Date and time as of which the value was calculated. <see href="https://datatracker.ietf.org/doc/html/rfc3339#section-5.6">RFC 3339-5</see>, <see href="https://www.iso.org/iso-8601-date-and-time-format.html">ISO8601 UTC</see>
    /// </summary>
    [JsonPropertyName("valuation_time")]
    public required DateTimeOffset ValuationTime { get; init; }
}
