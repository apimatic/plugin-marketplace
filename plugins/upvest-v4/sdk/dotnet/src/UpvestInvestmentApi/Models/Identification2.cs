using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using UpvestInvestmentApi.Core.Models;

namespace UpvestInvestmentApi.Models;

public record Identification2
{
    /// <summary>
    /// International Bank Account Number <see href="https://en.wikipedia.org/wiki/International_Bank_Account_Number">IBAN</see>.
    /// </summary>
    [JsonPropertyName("iban")]
    [RegularExpression("^[A-Z]{2}[0-9]{2}[A-Z0-9]{11,26}$")]
    public required string Iban { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
