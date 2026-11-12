using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using UpvestInvestmentApi.Models.Enums;

namespace UpvestInvestmentApi.Models;

/// <summary>
/// The share of a return impact figure attributable to one cost category.
/// </summary>
public record CostDetail
{
    /// <summary>
    /// The cost category a return impact figure belongs to.
    /// * ENTRY — One-off costs of building the position: product entry, transaction and incidental costs, the transaction fee and financial transaction tax on the order, and inducements.
    /// * ONGOING — Costs accruing on the capital held: product running costs and the annual AUM-based fee. Always zero for sell orders.
    /// * EXIT — Costs of liquidating the position at the end of the holding period: the sell transaction fee. Always zero for sell orders.
    /// </summary>
    [JsonPropertyName("type")]
    public required CostDetailType Type { get; init; }

    /// <summary>
    /// A positive cash amount, as a decimal string with up to two decimal places.
    /// </summary>
    [JsonPropertyName("cash_amount")]
    [RegularExpression("^[0-9]{1,9}(\\.[0-9]{2})?$")]
    public required string CashAmount { get; init; }

    /// <summary>
    /// Alphabetic three-letter <see href="https://www.iso.org/iso-4217-currency-codes.html">ISO 4217</see> currency code.
    /// * EUR — Euro.
    /// * GBP — Pound Sterling.
    /// </summary>
    [JsonPropertyName("currency")]
    public required Currency Currency { get; init; }

    [JsonPropertyName("as_percentage")]
    [RegularExpression("^-?[0-9]{0,63}(\\.[0-9]{1,27})?$")]
    public required string AsPercentage { get; init; }
}
