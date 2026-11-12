using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using UpvestInvestmentApi.Models.Enums;

namespace UpvestInvestmentApi.Models;

/// <summary>
/// Request body for updating a webhook subscription. Omitted fields keep their current values.
/// </summary>
public record WebhookUpdateRequest
{
    /// <summary>
    /// Title of the webhook for use on tenant side.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("title")]
    [RegularExpression("^[a-zA-Z0-9 ()\\[\\]{}.-]{1,32}$")]
    public string? Title { get; init; }

    /// <summary>
    /// The callback URL to be called by the webhook.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("url")]
    [MaxLength(1000)]
    public string? Url { get; init; }

    /// <summary>
    /// Enable/disable webhook.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("enabled")]
    public bool? Enabled { get; init; }

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
