using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using UpvestInvestmentApi.Models.Enums;

namespace UpvestInvestmentApi.Models;

/// <summary>
/// Request body for creating a fee collection from a fee amount the client has already calculated.
/// </summary>
public record FeeCollectionCreateRequest
{
    /// <summary>
    /// Universally Unique Identifier (UUID) of the account.
    /// </summary>
    [JsonPropertyName("account_id")]
    public required Guid AccountId { get; init; }

    /// <summary>
    /// Type of the fee collection.
    /// * SERVICE_FEE — Service fee intake in a pre-defined cadence, for example monthly.
    /// * SERVICE_FEE_LIQUIDATION — Service fee intake resulting from a portfolio liquidation.
    /// </summary>
    [JsonPropertyName("type")]
    public required Type37 Type { get; init; }

    /// <summary>
    /// A positive cash amount, as a decimal string with up to two decimal places.
    /// </summary>
    [JsonPropertyName("collection_amount")]
    [RegularExpression("^[0-9]{1,9}(\\.[0-9]{2})?$")]
    public required string CollectionAmount { get; init; }

    /// <summary>
    /// Alphabetic three-letter <see href="https://www.iso.org/iso-4217-currency-codes.html">ISO 4217</see> currency code.
    /// * EUR — Euro.
    /// * GBP — Pound Sterling.
    /// </summary>
    [JsonPropertyName("currency")]
    public required Currency Currency { get; init; }

    /// <summary>
    /// The start date of the fee collection period, as a <see href="https://datatracker.ietf.org/doc/html/rfc3339#section-5.6">RFC 3339, section 5.6</see> full date in <c>YYYY-MM-DD</c> format.
    /// </summary>
    [JsonPropertyName("period_start")]
    [JsonConverter(typeof(UpvestInvestmentApi.Core.Converters.DateOnlyDateTimeOffsetConverter))]
    public required DateTimeOffset PeriodStart { get; init; }

    /// <summary>
    /// The end date of the fee collection period, as a <see href="https://datatracker.ietf.org/doc/html/rfc3339#section-5.6">RFC 3339, section 5.6</see> full date in <c>YYYY-MM-DD</c> format.
    /// </summary>
    [JsonPropertyName("period_end")]
    [JsonConverter(typeof(UpvestInvestmentApi.Core.Converters.DateOnlyDateTimeOffsetConverter))]
    public required DateTimeOffset PeriodEnd { get; init; }
}
