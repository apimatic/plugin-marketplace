using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using UpvestInvestmentApi.Models.Enums;

namespace UpvestInvestmentApi.Models;

/// <summary>
/// A webhook subscription, registering a URL that the Investment API calls when the selected events occur.
/// </summary>
public record Webhook
{
    /// <summary>
    /// Webhook unique identifier.
    /// </summary>
    [JsonPropertyName("id")]
    public required Guid Id { get; init; }

    /// <summary>
    /// Date and time when the resource was created. <see href="https://datatracker.ietf.org/doc/html/rfc3339#section-5.6">RFC 3339-5</see>, <see href="https://www.iso.org/iso-8601-date-and-time-format.html">ISO8601 UTC</see>
    /// </summary>
    [JsonPropertyName("created_at")]
    public required DateTimeOffset CreatedAt { get; init; }

    /// <summary>
    /// Date and time when the resource was last updated. <see href="https://datatracker.ietf.org/doc/html/rfc3339#section-5.6">RFC 3339-5</see>, <see href="https://www.iso.org/iso-8601-date-and-time-format.html">ISO8601 UTC</see>
    /// </summary>
    [JsonPropertyName("updated_at")]
    public required DateTimeOffset UpdatedAt { get; init; }

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
    /// Enable/disable webhook.
    /// </summary>
    [JsonPropertyName("enabled")]
    public required bool Enabled { get; init; }

    /// <summary>
    /// Subscription types to receive webhooks for.
    /// </summary>
    [JsonPropertyName("type")]
    public required IReadOnlyList<TypeEnum> Type { get; init; }

    /// <summary>
    /// Subscription types to exclude when <c>type</c> is <c>ALL</c>.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("exclude_type")]
    public IReadOnlyList<ExcludeType>? ExcludeType { get; init; }

    /// <summary>
    /// Configuration of webhook packages collection.
    /// </summary>
    [JsonPropertyName("config")]
    public required Config Config { get; init; }
}
