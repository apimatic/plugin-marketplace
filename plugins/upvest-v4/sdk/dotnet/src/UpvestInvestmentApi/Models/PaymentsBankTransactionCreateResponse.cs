using System;
using System.Text.Json.Serialization;
using UpvestInvestmentApi.Core.Models;

namespace UpvestInvestmentApi.Models;

/// <summary>
/// Response returned after recording an incoming bank transaction. Contains the internal transaction <c>id</c> and the bank's own <c>bank_reference</c>.
/// </summary>
public record PaymentsBankTransactionCreateResponse
{
    /// <summary>
    /// Bank transaction unique identifier
    /// </summary>
    [JsonPropertyName("id")]
    public required Guid Id { get; init; }

    /// <summary>
    /// Bank reference of the bank transaction (created by the bank to unambiguously identify the bank transaction in the banks systems)
    /// </summary>
    [JsonPropertyName("bank_reference")]
    public required string BankReference { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
