using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using UpvestInvestmentApi.Models.Enums;

namespace UpvestInvestmentApi.Models;

/// <summary>
/// The value of this instrument position, or <c>null</c> if no price was available at the requested price quality.
/// </summary>
public record Value
{
    /// <summary>
    /// A decimal-string monetary amount used in account valuation calculations.
    /// </summary>
    [JsonPropertyName("amount")]
    [RegularExpression("^[0-9]{0,63}(\\.[0-9]{1,2})?$")]
    public required string Amount { get; init; }

    /// <summary>
    /// Alphabetic three-letter <see href="https://www.iso.org/iso-4217-currency-codes.html">ISO 4217</see> currency code.
    /// * EUR — Euro.
    /// * GBP — Pound Sterling.
    /// </summary>
    [JsonPropertyName("currency")]
    public required Currency Currency { get; init; }

    /// <summary>
    /// The date and time of the price used for the calculation. <see href="https://datatracker.ietf.org/doc/html/rfc3339#section-5.6">RFC 3339-5</see>, <see href="https://www.iso.org/iso-8601-date-and-time-format.html">ISO8601 UTC</see>
    /// </summary>
    [JsonPropertyName("price_time")]
    public required DateTimeOffset PriceTime { get; init; }
}
