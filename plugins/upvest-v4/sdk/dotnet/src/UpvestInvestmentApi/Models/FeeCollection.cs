using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using UpvestInvestmentApi.Models.Enums;

namespace UpvestInvestmentApi.Models;

/// <summary>
/// A fee collection, which processes a fee amount charged to an account. The amount either originates from a fee calculation performed by Upvest or is a pre-calculated amount supplied by the client.
/// </summary>
public record FeeCollection
{
    /// <summary>
    /// The unique identifier of the fee collection, as a UUID.
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
    /// Universally Unique Identifier (UUID) of the account.
    /// </summary>
    [JsonPropertyName("account_id")]
    public required Guid AccountId { get; init; }

    /// <summary>
    /// Universally Unique Identifier (UUID) of the account group.
    /// </summary>
    [JsonPropertyName("account_group_id")]
    public required Guid AccountGroupId { get; init; }

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
    /// How much of the fee amount has been covered so far, split by the source of the cash, together with any amount still outstanding.
    /// </summary>
    [JsonPropertyName("processed_amount")]
    public required ProcessedAmount ProcessedAmount { get; init; }

    /// <summary>
    /// The sell-to-cover orders placed to raise cash for this fee collection.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("sell_to_cover_orders")]
    public IReadOnlyList<SellToCoverOrderDetails>? SellToCoverOrders { get; init; }

    /// <summary>
    /// Alphabetic three-letter <see href="https://www.iso.org/iso-4217-currency-codes.html">ISO 4217</see> currency code.
    /// * EUR — Euro.
    /// * GBP — Pound Sterling.
    /// </summary>
    [JsonPropertyName("currency")]
    public required Currency Currency { get; init; }

    /// <summary>
    /// Status of the fee collection.
    /// * PROCESSING — The fee collection is in progress.
    /// * FINALISED — The fees have been collected from the account and the funds transferred to the client.
    /// * CANCELLED — The fee collection was cancelled.
    /// </summary>
    [JsonPropertyName("status")]
    public required Status53 Status { get; init; }

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

    /// <summary>
    /// Breakdown of the fee collection by fee model and subperiod. Populated only for fee collections created from daily fee model calculations.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("calculation_breakdown")]
    public IReadOnlyList<FeeCalculationBreakdownItem>? CalculationBreakdown { get; init; }

    /// <summary>
    /// The unique identifier of the fee collection, as a UUID.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("replaced_collection_id")]
    public Guid? ReplacedCollectionId { get; init; }
}
