using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace UpvestInvestmentApi.Models;

/// <summary>
/// Entity representing the financial instrument.
/// </summary>
public record Instrument6
{
    /// <summary>
    /// String representing the instrument internal identifier.
    /// </summary>
    [JsonPropertyName("uuid")]
    public required Guid Uuid { get; init; }

    /// <summary>
    /// International securities identification number defined by <see href="https://en.wikipedia.org/wiki/International_Securities_Identification_Number">ISO 6166</see>.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("isin")]
    [RegularExpression("^[A-Z]{2}[A-Z0-9]{9}[0-9]$")]
    public string? Isin { get; init; }
}
