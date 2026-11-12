using UpvestInvestmentApi.Models.Enums;

namespace UpvestInvestmentApi.Requests.WebhookSubscriptions;

/// <summary>
/// The inputs of the GetJwks operation.
/// </summary>
public sealed record GetJwksRequest
{
    /// <summary>
    /// Upvest API version (Note: Do not include quotation marks)
    /// </summary>
    public UpvestApiVersion UpvestApiVersion { get; init; } = UpvestApiVersion._1;
}
