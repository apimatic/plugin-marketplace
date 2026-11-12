using System.Text.Json.Serialization;

namespace UpvestInvestmentApi.Models;

/// <summary>
/// Third party payments associated with the investment service.
/// </summary>
public record ThirdPartyPayments1
{
    /// <summary>
    /// A cost figure, given both as a cash amount and as a percentage of the amount invested.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("total")]
    public Cost? Total { get; init; }

    /// <summary>
    /// A cost figure, given both as a cash amount and as a percentage of the amount invested.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("received_by_client")]
    public Cost? ReceivedByClient { get; init; }

    /// <summary>
    /// The share of the third-party payments received by Upvest, as a cost figure.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("received_by_upvest")]
    public ReceivedByUpvest? ReceivedByUpvest { get; init; }
}
