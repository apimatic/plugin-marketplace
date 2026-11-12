using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace UpvestInvestmentApi.Models;

/// <summary>
/// Counterparty of the ISA transfer.
/// </summary>
public record Counterparty2
{
    /// <summary>
    /// The account number is composed of valid Swift charset with a max length of 28 if provided. The account number helps other brokers identify the owner of the assets.
    /// </summary>
    [JsonPropertyName("account_number")]
    [RegularExpression("^[0-9A-Za-z+?/\\-:()\\.,' ]{0,28}$")]
    public required string AccountNumber { get; init; }
}
