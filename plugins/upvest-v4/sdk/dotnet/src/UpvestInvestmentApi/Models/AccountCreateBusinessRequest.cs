using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using UpvestInvestmentApi.Core.Models;
using UpvestInvestmentApi.Models.Enums;

namespace UpvestInvestmentApi.Models;

/// <summary>
/// Request to create an account for a business within an existing account group.
/// </summary>
public record AccountCreateBusinessRequest
{
    /// <summary>
    /// Unique identifier for the business.
    /// </summary>
    [JsonPropertyName("business_id")]
    public required Guid BusinessId { get; init; }

    /// <summary>
    /// Universally Unique Identifier (UUID) of the account group.
    /// </summary>
    [JsonPropertyName("account_group_id")]
    public required Guid AccountGroupId { get; init; }

    /// <summary>
    /// Account type.
    /// * TRADING - Orders in accounts of this type are created on a specific instrument basis.
    /// * PORTFOLIO - Orders in accounts of this type are created on a portfolio basis and additional portfolio functionality is available.
    /// </summary>
    [JsonPropertyName("type")]
    public required Type16 Type { get; init; }

    /// <summary>
    /// The name of the account.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("name")]
    [MaxLength(100)]
    public string? Name { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
