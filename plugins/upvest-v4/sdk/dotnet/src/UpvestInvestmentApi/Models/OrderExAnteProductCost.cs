using System.Text.Json.Serialization;

namespace UpvestInvestmentApi.Models;

/// <summary>
/// All costs and associated charges related to the financial instrument.
/// </summary>
public record OrderExAnteProductCost
{
    /// <summary>
    /// A cost figure, given both as a cash amount and as a percentage of the amount invested.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("one_off")]
    public Cost? OneOff { get; init; }

    /// <summary>
    /// A cost figure, given both as a cash amount and as a percentage of the amount invested.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("ongoing")]
    public Cost? Ongoing { get; init; }

    /// <summary>
    /// A cost figure, given both as a cash amount and as a percentage of the amount invested.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("transaction")]
    public Cost? Transaction { get; init; }

    /// <summary>
    /// A cost figure, given both as a cash amount and as a percentage of the amount invested.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("incidental")]
    public Cost? Incidental { get; init; }

    /// <summary>
    /// A cost figure, given both as a cash amount and as a percentage of the amount invested.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("total")]
    public Cost? Total { get; init; }
}
