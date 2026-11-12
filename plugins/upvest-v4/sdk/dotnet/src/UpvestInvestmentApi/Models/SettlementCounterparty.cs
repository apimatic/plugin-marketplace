using System.Text.Json.Serialization;

namespace UpvestInvestmentApi.Models;

/// <summary>
/// A participant in the settlement chain, identified by an identification and an optional account.
/// </summary>
public record SettlementCounterparty
{
    /// <summary>
    /// Identification of a settlement counterparty.
    /// * <c>BIC</c> Party identified by BIC.
    /// * <c>PROPRIETARY</c> Party identified by a proprietary code under a Data Source Scheme.
    /// * <c>NAME_AND_ADDRESS</c> Party identified by name and address.
    /// </summary>
    [JsonPropertyName("identification")]
    public required SettlementCounterpartyIdentification Identification { get; init; }

    /// <summary>
    /// Account of a settlement counterparty.
    /// * <c>SAFE</c> - Safekeeping account.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("account")]
    public SettlementCounterpartyAccount? Account { get; init; }
}
