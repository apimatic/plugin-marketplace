using System;
using System.Text.Json.Serialization;

namespace UpvestInvestmentApi.Models;

/// <summary>
/// An account associated with a portfolio allocation, identified by its account UUID.
/// </summary>
public record PortfoliosAllocationAccount
{
    /// <summary>
    /// Universally Unique Identifier (UUID) of the account.
    /// </summary>
    [JsonPropertyName("id")]
    public required Guid Id { get; init; }
}
