using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using UpvestInvestmentApi.Models.Enums;

namespace UpvestInvestmentApi.Models;

/// <summary>
/// A single fee amount contributing to a fee calculation subtotal, identified by the kind of fee it represents.
/// </summary>
public record FeeBreakdownComponent
{
    /// <summary>
    /// The kind of fee this component represents.
    /// * TRANSACTION_LUMP_SUM — Lump sum transaction fee.
    /// * PLATFORM — Platform fee.
    /// * SERVICE — Service fee for a client portfolio.
    /// * VAT — Value-added tax.
    /// * CUSTODY — Custody fee.
    /// </summary>
    [JsonPropertyName("type")]
    public required Type38 Type { get; init; }

    /// <summary>
    /// A positive cash amount, as a decimal string with up to two decimal places.
    /// </summary>
    [JsonPropertyName("amount")]
    [RegularExpression("^[0-9]{1,9}(\\.[0-9]{2})?$")]
    public required string Amount { get; init; }
}
