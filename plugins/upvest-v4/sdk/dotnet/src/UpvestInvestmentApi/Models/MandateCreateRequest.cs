using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace UpvestInvestmentApi.Models;

/// <summary>
/// Request body for creating a direct debit mandate. Exactly one of <c>user_id</c> or <c>business_id</c> must be provided.
/// </summary>
public record MandateCreateRequest
{
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

    /// <summary>
    /// Timestamp of when user validated the mandate
    /// </summary>
    [JsonPropertyName("confirmed_at")]
    public required DateTimeOffset ConfirmedAt { get; init; }
}
