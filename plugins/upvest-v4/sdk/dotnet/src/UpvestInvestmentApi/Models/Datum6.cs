using System;
using System.Text.Json.Serialization;

namespace UpvestInvestmentApi.Models;

/// <summary>
/// Represents a virtual bank account assigned to an account group. Provides an IBAN and BIC that end users can use to send SEPA Credit Transfers directly to their investment account.
/// </summary>
public record Datum6
{
    /// <summary>
    /// Virtual bank account request unique identifier.
    /// </summary>
    [JsonPropertyName("id")]
    public required Guid Id { get; init; }

    /// <summary>
    /// Date and time when the resource was created. <see href="https://datatracker.ietf.org/doc/html/rfc3339#section-5.6">RFC 3339-5</see>, <see href="https://www.iso.org/iso-8601-date-and-time-format.html">ISO8601 UTC</see>
    /// </summary>
    [JsonPropertyName("created_at")]
    public required DateTimeOffset CreatedAt { get; init; }

    /// <summary>
    /// Universally Unique Identifier (UUID) of the account group.
    /// </summary>
    [JsonPropertyName("account_group_id")]
    public required Guid AccountGroupId { get; init; }

    /// <summary>
    /// Name of the virtual bank account
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("name")]
    public string? Name { get; init; }

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
}
