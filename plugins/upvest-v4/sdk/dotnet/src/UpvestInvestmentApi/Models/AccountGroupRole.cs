using System;
using System.Text.Json.Serialization;
using UpvestInvestmentApi.Core.Models;
using UpvestInvestmentApi.Models.Enums;

namespace UpvestInvestmentApi.Models;

/// <summary>
/// Role assignment for an account group.
/// </summary>
public record AccountGroupRole
{
    /// <summary>
    /// Unique identifier for the role.
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
    [JsonPropertyName("user_id")]
    public required Guid UserId { get; init; }

    /// <summary>
    /// The entity type; must be <c>ACCOUNT_GROUP</c> for account group roles.
    /// </summary>
    [JsonPropertyName("entity_type")]
    public string EntityType { get; init; } = "ACCOUNT_GROUP";

    /// <summary>
    /// Unique identifier of the entity a role is attached to.
    /// </summary>
    [JsonPropertyName("entity_id")]
    public required Guid EntityId { get; init; }

    /// <summary>
    /// Role type for an account group.
    /// * <c>OWNER</c> — The user owns the account group.
    /// * <c>GUARDIAN</c> — The user is a legal custodian of a child account group.
    /// * <c>CHILD</c> — The user is the child beneficiary of a child account group.
    /// </summary>
    [JsonPropertyName("role_type")]
    public required RoleType RoleType { get; init; }

    /// <summary>
    /// Custody type for child account groups.
    /// * <c>SOLE_CUSTODY</c> — A single guardian has custody of the child account group.
    /// * <c>JOINT_CUSTODY</c> — Multiple guardians are required for the child account group.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("custody_type")]
    public CustodyType? CustodyType { get; init; }

    /// <summary>
    /// Status of the role assignment.
    /// * <c>PENDING</c> — The role has been created but is not yet active.
    /// * <c>ACTIVE</c> — The role is active.
    /// * <c>DEACTIVATED</c> — The role has been deactivated and cannot be reactivated.
    /// </summary>
    [JsonPropertyName("status")]
    public required Status112 Status { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
