using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using UpvestInvestmentApi.Core.Models;
using UpvestInvestmentApi.Models.Enums;

namespace UpvestInvestmentApi.Models;

/// <summary>
/// The Guardian check is completed by the client providing documentation proving the guardian relationship with the child user.
/// </summary>
public record UserCheckGuardianCreateRequest
{
    /// <summary>
    /// The type of check must be “GUARDIAN“.
    /// </summary>
    [JsonPropertyName("type")]
    public string Type { get; init; } = "GUARDIAN";

    /// <summary>
    /// Completion date and time of the PoR check.
    /// </summary>
    [JsonPropertyName("check_confirmed_at")]
    public required DateTimeOffset CheckConfirmedAt { get; init; }

    /// <summary>
    /// Unique identifier for the GUARDIAN role for this check. The check counts only towards the activation of this role..
    /// </summary>
    [JsonPropertyName("role_id")]
    public required Guid RoleId { get; init; }

    /// <summary>
    /// The type of document used in the Guardian check. A check carries one document, so a guardian with sole custody submits the birth certificate and the proof of custody as two checks of this type.
    /// * BIRTH_CERTIFICATE - Birth certificate proving guardian relationship. Required for every guardian role.
    /// * SOLE_CUSTODY_PROOF - Document proving the guardian holds sole custody of the child. Required in addition to the birth certificate when the role identified by role_id has a custody_type of SOLE_CUSTODY, and accepted only for such a role.
    /// </summary>
    [JsonPropertyName("document_type")]
    public required DocumentType5 DocumentType { get; init; }

    /// <summary>
    /// Download URL for the guardian evidence file. The file size must not exceed 250 MB.
    /// </summary>
    [JsonPropertyName("data_download_link")]
    [MaxLength(1000)]
    public required string DataDownloadLink { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
