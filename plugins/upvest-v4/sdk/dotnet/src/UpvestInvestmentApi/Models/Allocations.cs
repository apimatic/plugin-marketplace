using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using UpvestInvestmentApi.Core.Models;

namespace UpvestInvestmentApi.Models;

public record Allocations
{
    /// <summary>
    /// List of allocations
    /// </summary>
    [JsonPropertyName("allocations")]
    public required IReadOnlyList<Guid> AllocationsValue { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
