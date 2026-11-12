using System.Collections.Generic;
using System.Text.Json.Serialization;
using UpvestInvestmentApi.Core.Models;

namespace UpvestInvestmentApi.Models;

/// <summary>
/// What the subscribed endpoint returned in response to the test delivery.
/// </summary>
public record ResponseModel
{
    /// <summary>
    /// The HTTP status code returned by the endpoint.
    /// </summary>
    [JsonPropertyName("status")]
    public required int Status { get; init; }

    /// <summary>
    /// The HTTP response headers returned by the endpoint.
    /// </summary>
    [JsonPropertyName("headers")]
    public required IReadOnlyDictionary<string, string> Headers { get; init; }

    /// <summary>
    /// The response body returned by the endpoint.
    /// </summary>
    [JsonPropertyName("body")]
    public required string Body { get; init; }

    /// <summary>
    /// The reason the test delivery failed. Present only when the endpoint could not be reached or did not respond.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("error")]
    public string? Error { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
