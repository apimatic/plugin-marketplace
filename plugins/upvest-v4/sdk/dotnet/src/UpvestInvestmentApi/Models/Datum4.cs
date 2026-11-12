using System;
using System.Text.Json.Serialization;
using UpvestInvestmentApi.Models.Enums;

namespace UpvestInvestmentApi.Models;

public record Datum4
{
    /// <summary>
    /// Virtual bank account request unique identifier.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("virtual_bank_account_id")]
    public Guid? VirtualBankAccountId { get; init; }

    /// <summary>
    /// Name of the recipient account for the SEPA Credit Transfer
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("name")]
    public string? Name { get; init; }

    /// <summary>
    /// Alphabetic three-letter <see href="https://www.iso.org/iso-4217-currency-codes.html">ISO 4217</see> currency code.
    /// * EUR — Euro.
    /// * GBP — Pound Sterling.
    /// </summary>
    [JsonPropertyName("currency")]
    public required Currency Currency { get; init; }

    /// <summary>
    /// Owner of the virtual bank account
    /// </summary>
    [JsonPropertyName("owner")]
    public required Owner Owner { get; init; }

    /// <summary>
    /// Identification details
    /// </summary>
    [JsonPropertyName("identification")]
    public required Identification Identification { get; init; }

    /// <summary>
    /// Payment reference the one that should be used for SEPA Credit Transfer
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("remittance_information")]
    public string? RemittanceInformation { get; init; }
}
