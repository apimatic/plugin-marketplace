using System.Text.Json.Serialization;

namespace UpvestInvestmentApi.Models;

/// <summary>
/// Account of a settlement counterparty.
/// * <c>SAFE</c> - Safekeeping account.
/// </summary>
public record SettlementCounterpartyAccount
{
    /// <summary>
    /// Type of the account.
    /// * <c>SAFE</c> - Safekeeping account.
    /// </summary>
    [JsonPropertyName("type")]
    public string Type { get; } = "SAFE";

    /// <summary>
    /// Account identifier value.
    /// </summary>
    [JsonPropertyName("value")]
    public required string Value { get; init; }
}
