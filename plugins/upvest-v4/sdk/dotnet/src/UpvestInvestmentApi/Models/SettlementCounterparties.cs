using System.Text.Json.Serialization;

namespace UpvestInvestmentApi.Models;

/// <summary>
/// Settlement counterparties for the securities transfer.
/// When <c>settlement_counterparties</c> is provided, <c>settlement_agent</c> is required. Other participants are optional but must respect the following dependency rules:
/// * <c>settlement_custodian</c> presence requires <c>settlement_party</c> to be present.
/// * <c>settlement_intermediary_1</c> presence requires <c>settlement_custodian</c> to be present.
/// * <c>settlement_intermediary_2</c> presence requires <c>settlement_intermediary_1</c> to be present.
/// <para>
///  Note: <c>settlement_custodian</c> can be provided without an explicit <c>settlement_party</c> since the default <c>counterparty</c> field at transfer level serves as the settlement party.
/// </para>
/// </summary>
public record SettlementCounterparties
{
    /// <summary>
    /// A participant in the settlement chain, identified by an identification and an optional account.
    /// </summary>
    [JsonPropertyName("settlement_agent")]
    public required SettlementCounterparty SettlementAgent { get; init; }

    /// <summary>
    /// A participant in the settlement chain, identified by an identification and an optional account.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("settlement_custodian")]
    public SettlementCounterparty? SettlementCustodian { get; init; }

    /// <summary>
    /// A participant in the settlement chain, identified by an identification and an optional account.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("settlement_intermediary_1")]
    public SettlementCounterparty? SettlementIntermediary1 { get; init; }

    /// <summary>
    /// A participant in the settlement chain, identified by an identification and an optional account.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("settlement_intermediary_2")]
    public SettlementCounterparty? SettlementIntermediary2 { get; init; }

    /// <summary>
    /// A participant in the settlement chain, identified by an identification and an optional account.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("settlement_party")]
    public SettlementCounterparty? SettlementParty { get; init; }
}
