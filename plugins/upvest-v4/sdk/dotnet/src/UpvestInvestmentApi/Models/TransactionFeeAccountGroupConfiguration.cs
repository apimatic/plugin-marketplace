using System;
using System.Text.Json.Serialization;
using UpvestInvestmentApi.Models.Enums;

namespace UpvestInvestmentApi.Models;

public record TransactionFeeAccountGroupConfiguration
{
    /// <summary>
    /// Transaction fee account group configuration unique identifier.
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
    /// Universally Unique Identifier (UUID) of the transaction fee model.
    /// </summary>
    [JsonPropertyName("fee_model_id")]
    public required Guid FeeModelId { get; init; }

    /// <summary>
    /// Universally Unique Identifier (UUID) of the account group.
    /// </summary>
    [JsonPropertyName("account_group_id")]
    public required Guid AccountGroupId { get; init; }

    /// <summary>
    /// The operation type a transaction fee model is assigned to.
    /// * PENSION_DE_CONTRIBUTION -
    /// * PENSION_DE_CONTRIBUTION_GOVERNMENT_BONUS -
    /// * PENSION_DE_INCOMING_TRANSFER -
    /// * PENSION_DE_OUTGOING_TRANSFER -
    /// </summary>
    [JsonPropertyName("transaction_category")]
    public required TransactionCategory TransactionCategory { get; init; }
}
