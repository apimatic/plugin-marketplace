using System.Text.Json.Serialization;
using UpvestInvestmentApi.Core.Validation.Attributes;
using UpvestInvestmentApi.Models.Enums;

namespace UpvestInvestmentApi.Models;

/// <summary>
/// A monetary range defined by a lower bound and an optional upper bound.
/// </summary>
public record MonetaryRange
{
    /// <summary>
    /// Alphabetic three-letter <see href="https://www.iso.org/iso-4217-currency-codes.html">ISO 4217</see> currency code.
    /// * EUR — Euro.
    /// * GBP — Pound Sterling.
    /// </summary>
    [JsonPropertyName("currency")]
    public required Currency Currency { get; init; }

    /// <summary>
    /// The lower bound of the monetary range.
    /// </summary>
    [JsonPropertyName("lower_bound")]
    [Minimum(0.0)]
    public required double LowerBound { get; init; }

    /// <summary>
    /// The upper bound of the monetary range.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("upper_bound")]
    [Minimum(0.0)]
    public double? UpperBound { get; init; }
}
