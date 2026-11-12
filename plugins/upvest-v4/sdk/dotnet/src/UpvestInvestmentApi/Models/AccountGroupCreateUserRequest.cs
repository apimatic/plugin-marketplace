using System;
using System.Text.Json.Serialization;
using UpvestInvestmentApi.Core.Models;
using UpvestInvestmentApi.Models.Enums;

namespace UpvestInvestmentApi.Models;

/// <summary>
/// Request to create an account group for a user.
/// </summary>
public record AccountGroupCreateUserRequest
{
    /// <summary>
    /// Unique identifier of the user, as a UUID.
    /// </summary>
    [JsonPropertyName("user_id")]
    public required Guid UserId { get; init; }

    /// <summary>
    /// Account group type.
    /// * CHILD - Account group of a child user holding assets in a child account.
    /// * FRENCH_PEA - Account group of a french resident holding assets in Plan d'Epargne en Actions.
    /// * ISA - Account group of a UK resident holding assets in an individual savings account.
    /// * JOINT - Account group legally and beneficially owned by exactly 2 users. The user the account group is created with becomes the first owner and receives an OWNER role. The second owner is added by creating an OWNER role for them (POST /roles); no further owners can be added. The account group activates only once both OWNER roles are active.
    /// * LEGAL_ENTITY - Account group of a legal entity holding assets on behalf of their users.
    /// * PENSION_DE_CHILD - Account group of a child user holding assets in a German pension (Frühstartrente) account. Like CHILD it has one CHILD user and, depending on custody, one or two GUARDIAN users; like PENSION_DE it activates only once its tax wrapper is active.
    /// * PERSONAL - Account group of a person holding assets on their own behalf.
    /// </summary>
    [JsonPropertyName("type")]
    public required Type13 Type { get; init; }

    /// <summary>
    /// Official securities account number, assigned at account group level. A string of 7 to 12 digits.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("securities_account_number")]
    public string? SecuritiesAccountNumber { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
