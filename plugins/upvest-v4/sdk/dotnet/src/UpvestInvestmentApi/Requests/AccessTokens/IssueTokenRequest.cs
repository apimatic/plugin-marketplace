using System;
using System.ComponentModel.DataAnnotations;
using UpvestInvestmentApi.Models.Enums;

namespace UpvestInvestmentApi.Requests.AccessTokens;

/// <summary>
/// The inputs of the IssueToken operation.
/// </summary>
public sealed record IssueTokenRequest
{
    /// <summary>
    /// Upvest API version (Note: Do not include quotation marks)
    /// </summary>
    public UpvestApiVersion UpvestApiVersion { get; init; } = UpvestApiVersion._1;

    /// <summary>
    /// Client ID given during onboarding.
    /// </summary>
    public required Guid ClientId { get; init; }

    /// <summary>
    /// Client Secret given during onboarding.
    /// </summary>
    [MaxLength(1000)]
    public required string ClientSecret { get; init; }

    /// <summary>
    /// This must always be <c>client_credentials</c>.
    /// </summary>
    public string GrantType { get; init; } = "client_credentials";

    /// <summary>
    /// List of space delimited scopes to request for this access token.
    /// </summary>
    [MaxLength(1000)]
    public required string Scope { get; init; }
}
