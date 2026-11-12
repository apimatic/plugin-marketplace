using System.Text.Json.Serialization;

namespace UpvestInvestmentApi.Models;

/// <summary>
/// Aggregated totals of product costs, service costs and third party payments.
/// </summary>
public record OrderExAnteAggregatedCost
{
    /// <summary>
    /// A cost figure, given both as a cash amount and as a percentage of the amount invested.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("product")]
    public Cost? Product { get; init; }

    /// <summary>
    /// A cost figure, given both as a cash amount and as a percentage of the amount invested.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("service")]
    public Cost? Service { get; init; }

    /// <summary>
    /// A cost figure, given both as a cash amount and as a percentage of the amount invested.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("third_party")]
    public Cost? ThirdParty { get; init; }

    /// <summary>
    /// A cost figure, given both as a cash amount and as a percentage of the amount invested.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("total")]
    public Cost? Total { get; init; }
}
