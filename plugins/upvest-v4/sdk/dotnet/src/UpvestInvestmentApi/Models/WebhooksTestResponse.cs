using System.Text.Json.Serialization;
using UpvestInvestmentApi.Core.Models;

namespace UpvestInvestmentApi.Models;

/// <summary>
/// The outcome of a webhook subscription test, reporting what the subscribed URL returned when test data was delivered to it.
/// </summary>
public record WebhooksTestResponse
{
    /// <summary>
    /// The URL that the test data was delivered to.
    /// </summary>
    [JsonPropertyName("url")]
    public required string Url { get; init; }

    /// <summary>
    /// What the subscribed endpoint returned in response to the test delivery.
    /// </summary>
    [JsonPropertyName("response")]
    public required ResponseModel Response { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
