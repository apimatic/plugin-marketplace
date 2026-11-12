using System;
using System.Text.Json.Serialization;
using UpvestInvestmentApi.Core.Models;
using UpvestInvestmentApi.Core.Validation.Attributes;

namespace UpvestInvestmentApi.Models;

/// <summary>
/// The account that the planned order would be placed for.
/// </summary>
public record Account12
{
    /// <summary>
    /// Universally Unique Identifier (UUID) of the account.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("id")]
    public Guid? Id { get; init; }

    /// <summary>
    /// The serial account number of the account in the account group.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("account_number")]
    [Minimum(1)]
    public int? AccountNumber { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
