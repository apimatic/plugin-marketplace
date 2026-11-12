using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using UpvestInvestmentApi.Models.Enums;

namespace UpvestInvestmentApi.Models;

/// <summary>
/// A financial instrument available on the Upvest platform.
/// </summary>
public record Datum7
{
    /// <summary>
    /// Instrument unique identifier.
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
    /// International securities identification number defined by <see href="https://en.wikipedia.org/wiki/International_Securities_Identification_Number">ISO 6166</see>.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("isin")]
    [RegularExpression("^[A-Z]{2}[A-Z0-9]{9}[0-9]$")]
    public string? Isin { get; init; }

    /// <summary>
    /// German securities identification code known as <see href="https://en.wikipedia.org/wiki/Wertpapierkennnummer">Wertpapierkennnummer</see>.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("wkn")]
    [RegularExpression("^[A-HJ-NP-Z0-9]{6}$")]
    public string? Wkn { get; init; }

    /// <summary>
    /// The name of the instrument.
    /// </summary>
    [JsonPropertyName("name")]
    [MaxLength(100)]
    public required string Name { get; init; }

    /// <summary>
    /// Determines whether the platform can handle fractional investments within this instrument.
    /// </summary>
    [JsonPropertyName("fractional_trading")]
    public required bool FractionalTrading { get; init; }

    /// <summary>
    /// Instrument trading status
    /// * ACTIVE - The instrument can currently be traded on the Upvest platform.
    /// * INACTIVE - The instrument cannot currently be traded on the Upvest platform.
    /// </summary>
    [JsonPropertyName("trading_status")]
    public required InstrumentTradingStatus TradingStatus { get; init; }

    /// <summary>
    /// Additional descriptive detail about an instrument, including where it may be distributed.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("details")]
    public Details? Details { get; init; }
}
