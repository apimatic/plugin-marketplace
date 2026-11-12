using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace UpvestInvestmentApi.Models;

/// <summary>
/// SWIFT details
/// </summary>
public record Swift
{
    /// <summary>
    /// International Bank Account Number <see href="https://en.wikipedia.org/wiki/International_Bank_Account_Number">IBAN</see>.
    /// </summary>
    [JsonPropertyName("iban")]
    [RegularExpression("^[A-Z]{2}[0-9]{2}[A-Z0-9]{11,26}$")]
    public required string Iban { get; init; }

    /// <summary>
    /// Business Identifier Code (also known as SWIFT-BIC, BIC, SWIFT ID or SWIFT code) <see href="https://en.wikipedia.org/wiki/ISO_9362">ISO 9362</see>.
    /// </summary>
    [JsonPropertyName("bic")]
    [RegularExpression("^[A-Z]{6}[A-Z0-9]{2}([A-Z0-9]{3})?$")]
    public required string Bic { get; init; }
}
