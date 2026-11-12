using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace UpvestInvestmentApi.Models;

/// <summary>
/// Request body for creating a tax exemption order for end users who are resident in Germany for tax purposes.
/// </summary>
public record TaxesTaxExemptionsCreateRequest
{
    /// <summary>
    /// Ids of the users for whom the tax exemption is to be created.
    /// </summary>
    [JsonPropertyName("user_ids")]
    public required IReadOnlyList<Guid> UserIds { get; init; }

    /// <summary>
    /// The German tax exemption details supplied when creating or updating a tax exemption order.
    /// </summary>
    [JsonPropertyName("tax_exemption_details")]
    public required TaxExemptionRequestGermanTaxExemptionDetails TaxExemptionDetails { get; init; }

    /// <summary>
    /// Country code. <see href="https://en.wikipedia.org/wiki/ISO_3166-1_alpha-2">ISO 3166 alpha-2 Codes</see>.
    /// </summary>
    [JsonPropertyName("country")]
    [RegularExpression("^[A-Z]{2}$")]
    public required string Country { get; init; }

    /// <summary>
    /// Date until which the tax exemption is valid. If it is unlimited, it is omitted. For Germany it is always the last day of the year (YYYY-12-31). <see href="https://json-schema.org/draft/2020-12/json-schema-validation.html#RFC3339">RFC 3339, section 5.6</see>
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("valid_to_date")]
    [JsonConverter(typeof(UpvestInvestmentApi.Core.Converters.DateOnlyDateTimeOffsetConverter))]
    public DateTimeOffset? ValidToDate { get; init; }
}
