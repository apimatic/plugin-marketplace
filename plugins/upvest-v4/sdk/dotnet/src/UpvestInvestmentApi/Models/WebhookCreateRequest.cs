using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using UpvestInvestmentApi.Models.Enums;

namespace UpvestInvestmentApi.Models;

/// <summary>
/// Request body for creating a webhook subscription.
/// </summary>
public record WebhookCreateRequest
{
    /// <summary>
    /// Title of the webhook for use on tenant side.
    /// </summary>
    [JsonPropertyName("title")]
    [RegularExpression("^[a-zA-Z0-9 ()\\[\\]{}.-]{1,32}$")]
    public required string Title { get; init; }

    /// <summary>
    /// The callback URL to be called by the webhook.
    /// </summary>
    [JsonPropertyName("url")]
    [MaxLength(1000)]
    public required string Url { get; init; }

    /// <summary>
    /// Subscription types to receive webhooks for.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("type")]
    public IReadOnlyList<TypeEnum>? Type { get; init; }

    /// <summary>
    /// Subscription types to exclude when <c>type</c> is <c>ALL</c>.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("exclude_type")]
    public IReadOnlyList<ExcludeType>? ExcludeType { get; init; }

    /// <summary>
    /// Configuration of webhook packages collection.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("config")]
    public Config? Config { get; init; }
}
