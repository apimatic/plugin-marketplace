using System.Text.Json.Serialization;
using UpvestInvestmentApi.Core.Models;

namespace UpvestInvestmentApi.Models;

public record Counterparty
{
    [JsonPropertyName("identification")]
    public required Identification1 Identification { get; init; }

    [JsonPropertyName("account")]
    public required Account3 Account { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
