using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using UpvestInvestmentApi.Models.Enums;

namespace UpvestInvestmentApi.Models;

/// <summary>
/// Identification of a settlement counterparty.
/// * <c>BIC</c> Party identified by BIC.
/// * <c>PROPRIETARY</c> Party identified by a proprietary code under a Data Source Scheme.
/// * <c>NAME_AND_ADDRESS</c> Party identified by name and address.
/// </summary>
public record SettlementCounterpartyIdentification
{
    /// <summary>
    /// Type of identification.
    /// * <c>BIC</c> - Party identified by BIC.
    /// * <c>PROPRIETARY</c> - Party identified by a proprietary code under a Data Source Scheme.
    /// * <c>NAME_AND_ADDRESS</c> - Party identified by name and address.
    /// </summary>
    [JsonPropertyName("type")]
    public required Type52 Type { get; init; }

    /// <summary>
    /// Identification value. The format depends on the <c>type</c>:
    /// * For <c>BIC</c>: A valid BIC code.
    /// * For <c>PROPRIETARY</c>: A proprietary identifier under the given <c>scheme</c>.
    /// * For <c>NAME_AND_ADDRESS</c>: Name and address of the party.
    /// </summary>
    [JsonPropertyName("value")]
    public required string Value { get; init; }

    /// <summary>
    /// ISO Data Source Scheme code. <b>Required</b> when <c>type</c> is <c>PROPRIETARY</c>. Identifies the source of the proprietary identification (e.g. <c>CRST</c>, <c>DAKV</c>, <c>CEDE</c>).
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("scheme")]
    [RegularExpression("^[A-Z]{1,8}$")]
    public string? Scheme { get; init; }
}
