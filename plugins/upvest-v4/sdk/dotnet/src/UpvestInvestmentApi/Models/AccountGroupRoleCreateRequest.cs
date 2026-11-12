using System;
using System.Text.Json.Serialization;
using UpvestInvestmentApi.Core.Models;
using UpvestInvestmentApi.Models.Enums;

namespace UpvestInvestmentApi.Models;

/// <summary>
/// Request to create a role assignment for an account group.
/// </summary>
public record AccountGroupRoleCreateRequest
{
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
    /// Universally Unique Identifier (UUID) of the account group.
    /// </summary>
    [JsonPropertyName("entity_id")]
    public required Guid EntityId { get; init; }

    /// <summary>
    /// Role type to assign.
    /// * <c>GUARDIAN</c> — The user is a legal custodian of the child account group.
    /// * <c>OWNER</c> — The second owner of a <c>JOINT</c> account group; the first owner is the user the account group was created with. <c>custody_type</c> does not apply.
    /// </summary>
    [JsonPropertyName("role_type")]
    public required RoleType2 RoleType { get; init; }

    /// <summary>
    /// Custody type for child account groups.
    /// * <c>SOLE_CUSTODY</c> — A single guardian has custody of the child account group.
    /// * <c>JOINT_CUSTODY</c> — Multiple guardians are required for the child account group.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("custody_type")]
    public CustodyType? CustodyType { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
