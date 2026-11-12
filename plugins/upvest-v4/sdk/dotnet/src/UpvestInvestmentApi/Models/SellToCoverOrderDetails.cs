using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace UpvestInvestmentApi.Models;

/// <summary>
/// A sell-to-cover order placed to raise cash for an outstanding fee amount, together with the amount that remains uncovered after the order settles.
/// </summary>
public record SellToCoverOrderDetails
{
    /// <summary>
    /// The unique identifier of the sell-to-cover order placed to raise cash for a fee amount, as a UUID.
    /// </summary>
    [JsonPropertyName("id")]
    public required Guid Id { get; init; }

    /// <summary>
    /// A positive cash amount, as a decimal string with up to two decimal places.
    /// </summary>
    [JsonPropertyName("residual_amount")]
    [RegularExpression("^[0-9]{1,9}(\\.[0-9]{2})?$")]
    public required string ResidualAmount { get; init; }
}
