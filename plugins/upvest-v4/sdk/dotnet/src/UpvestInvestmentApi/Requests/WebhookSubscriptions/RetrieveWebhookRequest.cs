using System;
using UpvestInvestmentApi.Models.Enums;

namespace UpvestInvestmentApi.Requests.WebhookSubscriptions;

/// <summary>
/// The inputs of the RetrieveWebhook operation.
/// </summary>
public sealed record RetrieveWebhookRequest
{
    /// <summary>
    /// The unique identifier of the webhook subscription. Universally Unique Identifier (UUID).
    /// </summary>
    public required Guid WebhookId { get; init; }

    /// <summary>
    /// Upvest API version (Note: Do not include quotation marks)
    /// </summary>
    public UpvestApiVersion UpvestApiVersion { get; init; } = UpvestApiVersion._1;
}
