using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using UpvestInvestmentApi.Models.AnyOf;
using UpvestInvestmentApi.Models.Enums;

namespace UpvestInvestmentApi.Models;

/// <summary>
/// A set of tax residencies submitted for a user, with the processing status and timestamps. The record is <c>PENDING</c> until processed by Upvest, then <c>ACTIVE</c> when in use.
/// </summary>
public record TaxResidencyRecord
{
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
    /// Tax residencies contained in this record
    /// </summary>
    [JsonPropertyName("tax_residencies")]
    public required IReadOnlyList<TaxResidency> TaxResidencies { get; init; }

    /// <summary>
    /// Tax residency status
    /// * PENDING - It indicates that the tax residency records are not yet processed by Upvest.
    /// * ACTIVE - It indicates that tax residency records are processed, and the tax residency record is the one in use.
    /// </summary>
    [JsonPropertyName("status")]
    public required Status63 Status { get; init; }
}
