using System;
using UpvestInvestmentApi.Models.Enums;

namespace UpvestInvestmentApi.Requests.UserChecks;

/// <summary>
/// The inputs of the ListUserChecks operation.
/// </summary>
public sealed record ListUserChecksRequest
{
    /// <summary>
    /// The unique identifier of the user. Universally Unique Identifier (UUID).
    /// </summary>
    public required Guid UserId { get; init; }

    /// <summary>
    /// If true, return the full history of checks (all records) instead of only the latest check per type.
    /// </summary>
    public bool ListHistory { get; init; } = false;

    /// <summary>
    /// Filter the returned checks to a single allowed check type (e.g. US_WITHHOLDING_TAX_STATUS).
    /// </summary>
    public Type6? Type { get; init; }

    /// <summary>
    /// Upvest API version (Note: Do not include quotation marks)
    /// </summary>
    public UpvestApiVersion UpvestApiVersion { get; init; } = UpvestApiVersion._1;
}
