using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace UpvestInvestmentApi.Models;

public record CounterpartyAgent
{
    /// <summary>
    /// Business Identifier Code (also known as SWIFT-BIC, BIC, SWIFT ID or SWIFT code) <see href="https://en.wikipedia.org/wiki/ISO_9362">ISO 9362</see>.
    /// </summary>
    [JsonPropertyName("bic")]
    [RegularExpression("^[A-Z]{6}[A-Z0-9]{2}([A-Z0-9]{3})?$")]
    public required string Bic { get; init; }
}
