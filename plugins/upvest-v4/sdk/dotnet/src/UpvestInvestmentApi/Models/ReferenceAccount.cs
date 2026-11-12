using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace UpvestInvestmentApi.Models;

/// <summary>
/// A verified reference bank account belonging to a user, used as the destination for cash withdrawals.
/// </summary>
public record ReferenceAccount
{
    /// <summary>
    /// Reference account unique identifier.
    /// </summary>
    [JsonPropertyName("id")]
    public required Guid Id { get; init; }

    /// <summary>
    /// Date and time when the resource was created. <see href="https://datatracker.ietf.org/doc/html/rfc3339#section-5.6">RFC 3339-5</see>, <see href="https://www.iso.org/iso-8601-date-and-time-format.html">ISO8601 UTC</see>
    /// </summary>
    [JsonPropertyName("created_at")]
    public required DateTimeOffset CreatedAt { get; init; }

    /// <summary>
    /// Date and time when the resource was last updated. <see href="https://datatracker.ietf.org/doc/html/rfc3339#section-5.6">RFC 3339-5</see>, <see href="https://www.iso.org/iso-8601-date-and-time-format.html">ISO8601 UTC</see>
    /// </summary>
    [JsonPropertyName("updated_at")]
    public required DateTimeOffset UpdatedAt { get; init; }

    /// <summary>
    /// Unique identifier of the user, as a UUID.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("user_id")]
    public Guid? UserId { get; init; }

    /// <summary>
    /// Unique identifier for the business.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("business_id")]
    public Guid? BusinessId { get; init; }

    /// <summary>
    /// Name of the reference account holder
    /// </summary>
    [JsonPropertyName("account_owner")]
    [MaxLength(140)]
    public required string AccountOwner { get; init; }

    /// <summary>
    /// Human-readable name of the reference bank account
    /// </summary>
    [JsonPropertyName("name")]
    [MaxLength(100)]
    public required string Name { get; init; }

    /// <summary>
    /// Obfuscated International Bank Account Number <see href="https://en.wikipedia.org/wiki/International_Bank_Account_Number">IBAN</see>.
    /// </summary>
    [JsonPropertyName("iban")]
    [RegularExpression("^[A-Z]{2}[0-9]{2}[A-Z0-9]{2}\\*{10}[A-Z0-9]{4}$")]
    public required string Iban { get; init; }

    /// <summary>
    /// Business Identifier Code (also known as SWIFT-BIC, BIC, SWIFT ID or SWIFT code) <see href="https://en.wikipedia.org/wiki/ISO_9362">ISO 9362</see>.
    /// </summary>
    [JsonPropertyName("bic")]
    [RegularExpression("^[A-Z]{6}[A-Z0-9]{2}([A-Z0-9]{3})?$")]
    public required string Bic { get; init; }

    /// <summary>
    /// Timestamp of when user validated the reference account
    /// </summary>
    [JsonPropertyName("confirmed_at")]
    public required DateTimeOffset ConfirmedAt { get; init; }
}
