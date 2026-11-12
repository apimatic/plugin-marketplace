using System;
using System.Text.Json.Serialization;
using UpvestInvestmentApi.Core.Models;

namespace UpvestInvestmentApi.Models;

/// <summary>
/// Request to create an account group for a business.
/// </summary>
public record AccountGroupCreateBusinessRequest
{
    /// <summary>
    /// Unique identifier for the business.
    /// </summary>
    [JsonPropertyName("business_id")]
    public required Guid BusinessId { get; init; }

    /// <summary>
    /// Account group type.
    /// * BUSINESS - Account group of a business holding assets.
    /// </summary>
    [JsonPropertyName("type")]
    public string Type { get; } = "BUSINESS";

    /// <summary>
    /// Official securities account number, assigned at account group level. A string of 7 to 12 digits.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("securities_account_number")]
    public string? SecuritiesAccountNumber { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
