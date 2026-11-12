using System;
using UpvestInvestmentApi.Models.Enums;

namespace UpvestInvestmentApi.Requests.Businesses;

/// <summary>
/// The inputs of the RetrieveBusiness operation.
/// </summary>
public sealed record RetrieveBusinessRequest
{
    /// <summary>
    /// The unique identifier of the business. Universally Unique Identifier (UUID).
    /// </summary>
    public required Guid BusinessId { get; init; }

    /// <summary>
    /// Upvest API version (Note: Do not include quotation marks)
    /// </summary>
    public UpvestApiVersion UpvestApiVersion { get; init; } = UpvestApiVersion._1;
}
