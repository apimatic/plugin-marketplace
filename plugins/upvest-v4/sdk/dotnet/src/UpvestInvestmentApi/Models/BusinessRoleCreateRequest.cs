using System;
using System.Text.Json.Serialization;
using UpvestInvestmentApi.Core.Models;
using UpvestInvestmentApi.Models.Enums;

namespace UpvestInvestmentApi.Models;

/// <summary>
/// Request to create a role for a business entity.
/// </summary>
public record BusinessRoleCreateRequest
{
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
    /// Unique identifier for the business.
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

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
