using System;
using System.Text.Json.Serialization;

namespace UpvestInvestmentApi.Models;

/// <summary>
/// The account's time-weighted return (TWR) as of a specific date, expressed as daily and cumulative percentages.
/// </summary>
public record AccountReturns
{
    /// <summary>
    /// Universally Unique Identifier (UUID) of the account.
    /// </summary>
    [JsonPropertyName("account_id")]
    public required Guid AccountId { get; init; }

    /// <summary>
    /// Date when returns were calculated. <see href="https://datatracker.ietf.org/doc/html/rfc3339#section-5.6">RFC 3339-5</see>, <see href="https://www.iso.org/iso-8601-date-and-time-format.html">ISO8601 UTC</see>
    /// </summary>
    [JsonPropertyName("date")]
    public required DateTimeOffset Date { get; init; }

    /// <summary>
    /// The account's time-weighted return (TWR), which measures investment performance independently of deposits, withdrawals, and other external cash flows.
    /// </summary>
    [JsonPropertyName("twr")]
    public required Twr Twr { get; init; }
}
