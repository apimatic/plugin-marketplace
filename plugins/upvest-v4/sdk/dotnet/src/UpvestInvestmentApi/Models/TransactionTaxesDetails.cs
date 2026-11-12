using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace UpvestInvestmentApi.Models;

/// <summary>
/// Entity representing the transaction taxes details.
/// </summary>
public record TransactionTaxesDetails
{
    /// <summary>
    /// The total tax amount, with its currency.
    /// </summary>
    [JsonPropertyName("total_amount")]
    public required TotalAmount TotalAmount { get; init; }

    /// <summary>
    /// The individual tax components making up the total.
    /// </summary>
    [JsonPropertyName("tax_breakdown")]
    public required IReadOnlyList<TransactionTax1> TaxBreakdown { get; init; }
}
