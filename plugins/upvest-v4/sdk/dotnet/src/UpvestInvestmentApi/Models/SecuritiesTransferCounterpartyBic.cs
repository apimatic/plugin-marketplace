using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using UpvestInvestmentApi.Core.Models;

namespace UpvestInvestmentApi.Models;

/// <summary>
/// Counterparty with BIC (Bank Identifier Code) based identification for securities transfer.
/// </summary>
public record SecuritiesTransferCounterpartyBic
{
    /// <summary>
    /// Type of the counterparty.
    /// </summary>
    [JsonPropertyName("type")]
    public string Type { get; init; } = "BIC";

    /// <summary>
    /// Business Identifier Code (also known as SWIFT-BIC, BIC, SWIFT ID or SWIFT code) <see href="https://en.wikipedia.org/wiki/ISO_9362">ISO 9362</see>.
    /// </summary>
    [JsonPropertyName("id")]
    [RegularExpression("^[A-Z]{6}[A-Z0-9]{2}([A-Z0-9]{3})?$")]
    public required string Id { get; init; }

    /// <summary>
    /// The account number is composed of valid Swift charset with a max length of 28 if provided. The account number helps other brokers identify the owner of the assets.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("account_number")]
    [RegularExpression("^[0-9A-Za-z+?/\\-:()\\.,' ]{0,28}$")]
    public string? AccountNumber { get; init; }

    /// <summary>
    /// The name is going to be split into 4 lines of 35 characters, the split is space based. This means that even if the name is exactly 140 of length, we may drop out the last parts if they don't fit into 4x35.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("name")]
    [RegularExpression("^[0-9A-Za-z+?/\\-:()\\.,' ]{0,140}$")]
    public string? Name { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
