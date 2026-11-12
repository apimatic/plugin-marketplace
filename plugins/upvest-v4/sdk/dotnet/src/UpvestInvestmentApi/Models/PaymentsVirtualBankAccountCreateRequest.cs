using System;
using System.Text.Json.Serialization;

namespace UpvestInvestmentApi.Models;

/// <summary>
/// Request body for creating a virtual bank account for an account group.
/// </summary>
public record PaymentsVirtualBankAccountCreateRequest
{
    /// <summary>
    /// Universally Unique Identifier (UUID) of the account group.
    /// </summary>
    [JsonPropertyName("account_group_id")]
    public required Guid AccountGroupId { get; init; }

    /// <summary>
    /// Name of the virtual bank account
    /// </summary>
    [JsonPropertyName("name")]
    public required string Name { get; init; }
}
