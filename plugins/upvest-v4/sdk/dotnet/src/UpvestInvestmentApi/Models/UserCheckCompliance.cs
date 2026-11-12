using System;
using System.Text.Json.Serialization;
using UpvestInvestmentApi.Core.Models;
using UpvestInvestmentApi.Models.Enums;

namespace UpvestInvestmentApi.Models;

/// <summary>
/// A compliance check conducted by Upvest for a user, including the check and user identifiers.
/// </summary>
public record UserCheckCompliance
{
    /// <summary>
    /// User Check unique identifier.
    /// </summary>
    [JsonPropertyName("id")]
    public required Guid Id { get; init; }

    /// <summary>
    /// Unique identifier of the user, as a UUID.
    /// </summary>
    [JsonPropertyName("user_id")]
    public required Guid UserId { get; init; }

    /// <summary>
    /// The type of check must be COMPLIANCE.
    /// </summary>
    [JsonPropertyName("type")]
    public string Type { get; init; } = "COMPLIANCE";

    /// <summary>
    /// Final status of the COMPLIANCE check.
    /// * IN_PROGRESS - Compliance check is in progress
    /// * PASSED - Compliance check passed
    /// * FAILED - Compliance check failed
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("status")]
    public Status9? Status { get; init; }

    /// <summary>
    /// Completion date and time of the COMPLIANCE check.
    /// </summary>
    [JsonPropertyName("check_confirmed_at")]
    public required DateTimeOffset CheckConfirmedAt { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
