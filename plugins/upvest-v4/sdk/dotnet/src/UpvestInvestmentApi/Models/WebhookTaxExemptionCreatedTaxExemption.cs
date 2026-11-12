using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using UpvestInvestmentApi.Models.Enums;

namespace UpvestInvestmentApi.Models;

/// <summary>
/// A tax exemption order under German tax law. Records the allowance granted, the amounts used and remaining for the tax year, and the period for which the exemption is valid.
/// </summary>
public record WebhookTaxExemptionCreatedTaxExemption
{
    /// <summary>
    /// The unique identifier of the tax exemption order, as a UUID.
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
    /// Tax exemption status
    /// * NEW - The tax exemption request is created.
    /// * ACTIVE - The tax exemption is valid and active for the current year.
    /// * EXPIRED - The tax exemption is no longer <c>ACTIVE</c> and the <c>valid_to_date</c> already lies in the past. An update is not possible.
    /// * CANCELLED - The tax exemption could not be created or was cancelled.
    /// </summary>
    [JsonPropertyName("status")]
    public required TaxExemptionStatus Status { get; init; }

    /// <summary>
    /// Ids of the users for whom the tax exemption was created.
    /// </summary>
    [JsonPropertyName("user_ids")]
    public required IReadOnlyList<Guid> UserIds { get; init; }

    /// <summary>
    /// Country code. <see href="https://en.wikipedia.org/wiki/ISO_3166-1_alpha-2">ISO 3166 alpha-2 Codes</see>.
    /// </summary>
    [JsonPropertyName("country")]
    [RegularExpression("^[A-Z]{2}$")]
    public required string Country { get; init; }

    /// <summary>
    /// Date from which the tax exemption is valid. <see href="https://json-schema.org/draft/2020-12/json-schema-validation.html#RFC3339">RFC 3339, section 5.6</see>
    /// </summary>
    [JsonPropertyName("valid_from_date")]
    [JsonConverter(typeof(UpvestInvestmentApi.Core.Converters.DateOnlyDateTimeOffsetConverter))]
    public required DateTimeOffset ValidFromDate { get; init; }

    /// <summary>
    /// Date until which the tax exemption is valid. If it is unlimited, it is omitted. For Germany it is always the last day of the year (YYYY-12-31). <see href="https://json-schema.org/draft/2020-12/json-schema-validation.html#RFC3339">RFC 3339, section 5.6</see>
    /// </summary>
    [JsonPropertyName("valid_to_date")]
    [JsonConverter(typeof(UpvestInvestmentApi.Core.Converters.DateOnlyDateTimeOffsetConverter))]
    public required DateTimeOffset? ValidToDate { get; init; }

    /// <summary>
    /// The German tax exemption details returned for a tax exemption order, including the allowance granted and the amounts used and remaining for the tax year.
    /// </summary>
    [JsonPropertyName("tax_exemption_details")]
    public required TaxExemptionGermanTaxExemptionDetails TaxExemptionDetails { get; init; }
}
