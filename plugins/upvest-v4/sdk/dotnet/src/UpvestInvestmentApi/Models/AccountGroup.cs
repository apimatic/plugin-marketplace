using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using UpvestInvestmentApi.Models.Enums;

namespace UpvestInvestmentApi.Models;

/// <summary>
/// An account group owned by a user. Aggregates its accounts for tax calculation and regulatory reporting, holds positions in the form of cash, and carries the official securities account number.
/// </summary>
public record AccountGroup
{
    /// <summary>
    /// Universally Unique Identifier (UUID) of the account group.
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
    /// The users associated with the account group, each with their relation type.
    /// </summary>
    [JsonPropertyName("users")]
    public required IReadOnlyList<User> Users { get; init; }

    /// <summary>
    /// Status of the account group.
    /// * <c>PENDING_APPROVAL</c> — Account group approval is pending — the account group is visible through our API but cannot be acted on.
    /// * <c>ACTIVE</c> — Account group is active — full functionality of the Investment API is accessible.
    /// * <c>CLOSING</c> — Account group is closing.
    /// * <c>CLOSED</c> — Account group is closed.
    /// * <c>LOCKED</c> — Account group is locked for all actions.
    /// </summary>
    [JsonPropertyName("status")]
    public required Status18 Status { get; init; }

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
    [JsonPropertyName("securities_account_number")]
    public required string SecuritiesAccountNumber { get; init; }
}
