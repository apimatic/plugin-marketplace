using System;
using System.Text.Json.Serialization;
using UpvestInvestmentApi.Core.Models;
using UpvestInvestmentApi.Models.Enums;

namespace UpvestInvestmentApi.Models;

/// <summary>
/// Role assignment for a business entity.
/// </summary>
public record BusinessRole
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
    /// The entity type; must be <c>BUSINESS</c> for business roles.
    /// </summary>
    [JsonPropertyName("entity_type")]
    public string EntityType { get; init; } = "BUSINESS";

    /// <summary>
    /// Unique identifier of the entity a role is attached to.
    /// </summary>
    [JsonPropertyName("entity_id")]
    public required Guid EntityId { get; init; }

    /// <summary>
    /// Role type for a business entity.
    /// * <c>LEGAL_REPRESENTATIVE</c> — The user is a legal representative of the business.
    /// * <c>AUTHORISED_SIGNATORY</c> — The user is authorised to sign documents and make commitments on behalf of the business.
    /// * <c>ULTIMATE_BENEFICIAL_OWNER</c> — The user ultimately owns or controls the business.
    /// * <c>CONTRACTING_EXECUTIVE</c> — The user is able to enter into contracts on behalf of the business.
    /// * <c>TRADER</c> — The user is authorised to place orders on behalf of the business.
    /// * <c>SOLE_TRADER</c> — The user places orders on behalf of a sole trader entity.
    /// </summary>
    [JsonPropertyName("role_type")]
    public required RoleType1 RoleType { get; init; }

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
