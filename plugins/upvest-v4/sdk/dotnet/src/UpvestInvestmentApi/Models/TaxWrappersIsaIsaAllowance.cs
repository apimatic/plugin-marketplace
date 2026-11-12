using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using UpvestInvestmentApi.Models.Enums;

namespace UpvestInvestmentApi.Models;

/// <summary>
/// The subscription allowance of an ISA tax wrapper for one tax year, tracking how much of the regulatory limit has been used and how much remains.
/// </summary>
public record TaxWrappersIsaIsaAllowance
{
    /// <summary>
    /// Allowance unique identifier.
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
    /// Tax wrapper unique identifier.
    /// </summary>
    [JsonPropertyName("tax_wrapper_id")]
    public required Guid TaxWrapperId { get; init; }

    /// <summary>
    /// The UK tax year the allowance applies to, in <c>yyyy/yyyy</c> form. The UK tax year runs from 6 April to 5 April.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("tax_year")]
    [RegularExpression("^[0-9]{4}/[0-9]{4}$")]
    public string? TaxYear { get; init; }

    /// <summary>
    /// Type of the allowance:
    /// * ANNUAL - Allowance valid for a tax year.
    /// </summary>
    [JsonPropertyName("type")]
    public string Type { get; } = "ANNUAL";

    /// <summary>
    /// Status of the allowance:
    /// * ACTIVE - Current allowance.
    /// * EXPIRED - Allowance from previous years.
    /// </summary>
    [JsonPropertyName("status")]
    public required Status57 Status { get; init; }

    /// <summary>
    /// Alphabetic three-letter <see href="https://www.iso.org/iso-4217-currency-codes.html">ISO 4217</see> currency code.
    /// * GBP — Pound Sterling.
    /// </summary>
    [JsonPropertyName("currency")]
    public string Currency { get; } = "GBP";

    [JsonPropertyName("used_amount")]
    [RegularExpression("^-?[0-9]{1,9}(\\.[0-9]{2})?$")]
    public required string UsedAmount { get; init; }

    [JsonPropertyName("remaining_amount")]
    [RegularExpression("^-?[0-9]{1,9}(\\.[0-9]{2})?$")]
    public required string RemainingAmount { get; init; }

    /// <summary>
    /// The date from which the allowance is valid.
    /// </summary>
    [JsonPropertyName("valid_from")]
    public required DateTimeOffset ValidFrom { get; init; }

    /// <summary>
    /// The date and time at which the allowance expires. Expired allowances do not roll over; a new allowance is created for the next tax year. Applies to allowances of type <c>ANNUAL</c>.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("valid_to")]
    public DateTimeOffset? ValidTo { get; init; }

    /// <summary>
    /// The date and time of the first qualifying cash subscription against this allowance. Used for HMRC reporting.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("first_subscription_at")]
    public DateTimeOffset? FirstSubscriptionAt { get; init; }
}
