using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using UpvestInvestmentApi.Core.Models;

namespace UpvestInvestmentApi.Models;

public record Accounts
{
    /// <summary>
    /// List of accounts
    /// </summary>
    [JsonPropertyName("accounts")]
    public required IReadOnlyList<Guid> AccountsValue { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
