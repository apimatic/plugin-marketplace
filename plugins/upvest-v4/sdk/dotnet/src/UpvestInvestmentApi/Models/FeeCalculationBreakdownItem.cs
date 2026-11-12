using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace UpvestInvestmentApi.Models;

/// <summary>
/// The fees calculated for one fee model over one subperiod of a fee collection period, broken down into individual components.
/// </summary>
public record FeeCalculationBreakdownItem
{
    /// <summary>
    /// The unique identifier of the fee model, as a UUID. Upvest provides this value when a fee model is set up.
    /// </summary>
    [JsonPropertyName("fee_model_id")]
    public required Guid FeeModelId { get; init; }

    /// <summary>
    /// The start date of the fee subperiod, as a <see href="https://datatracker.ietf.org/doc/html/rfc3339#section-5.6">RFC 3339, section 5.6</see> full date in <c>YYYY-MM-DD</c> format.
    /// </summary>
    [JsonPropertyName("subperiod_start")]
    [JsonConverter(typeof(UpvestInvestmentApi.Core.Converters.DateOnlyDateTimeOffsetConverter))]
    public required DateTimeOffset SubperiodStart { get; init; }

    /// <summary>
    /// The end date of the fee subperiod, as a <see href="https://datatracker.ietf.org/doc/html/rfc3339#section-5.6">RFC 3339, section 5.6</see> full date in <c>YYYY-MM-DD</c> format.
    /// </summary>
    [JsonPropertyName("subperiod_end")]
    [JsonConverter(typeof(UpvestInvestmentApi.Core.Converters.DateOnlyDateTimeOffsetConverter))]
    public required DateTimeOffset SubperiodEnd { get; init; }

    /// <summary>
    /// A positive cash amount, as a decimal string with up to two decimal places.
    /// </summary>
    [JsonPropertyName("subtotal_amount")]
    [RegularExpression("^[0-9]{1,9}(\\.[0-9]{2})?$")]
    public required string SubtotalAmount { get; init; }

    /// <summary>
    /// Individual fee components contributing to the subtotal.
    /// </summary>
    [JsonPropertyName("components")]
    public required IReadOnlyList<FeeBreakdownComponent> Components { get; init; }
}
