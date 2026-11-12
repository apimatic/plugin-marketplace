using System;
using UpvestInvestmentApi.Models;
using UpvestInvestmentApi.Models.Enums;

namespace UpvestInvestmentApi.Requests.FeesConfigurations;

/// <summary>
/// The inputs of the UpdateFeeConfiguration operation.
/// </summary>
public sealed record UpdateFeeConfigurationRequest
{
    /// <summary>
    /// The unique identifier of the account. Universally Unique Identifier (UUID).
    /// </summary>
    public required Guid AccountId { get; init; }

    /// <summary>
    /// Upvest API version (Note: Do not include quotation marks)
    /// </summary>
    public UpvestApiVersion UpvestApiVersion { get; init; } = UpvestApiVersion._1;

    public FeeConfigurationUpdateRequest? Body { get; init; }
}
