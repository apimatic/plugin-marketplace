using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace UpvestInvestmentApi.Models;

/// <summary>
/// The subscription details of an internal ISA transfer, used to apportion the transfer against the current tax year's allowance.
/// </summary>
public record CurrentYearSubscription
{
    /// <summary>
    /// Current tax year in the format 'YYYY/YYYY'.
    /// </summary>
    [JsonPropertyName("tax_year")]
    [RegularExpression("^[0-9]{4}/[0-9]{4}$")]
    public required string TaxYear { get; init; }

    /// <summary>
    /// A positive cash amount, as a decimal string with up to two decimal places.
    /// </summary>
    [JsonPropertyName("cash_amount")]
    [RegularExpression("^[0-9]{1,9}(\\.[0-9]{2})?$")]
    public required string CashAmount { get; init; }

    /// <summary>
    /// The date of the first subscription made to the ISA in the current tax year. <see href="https://datatracker.ietf.org/doc/html/rfc3339#section-5.6">RFC 3339-5</see>, <see href="https://www.iso.org/iso-8601-date-and-time-format.html">ISO8601 UTC</see>.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("first_subscription_at")]
    public DateTimeOffset? FirstSubscriptionAt { get; init; }
}
