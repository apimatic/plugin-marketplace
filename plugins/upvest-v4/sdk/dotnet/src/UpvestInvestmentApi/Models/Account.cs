using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using UpvestInvestmentApi.Core.Validation.Attributes;
using UpvestInvestmentApi.Models.Enums;

namespace UpvestInvestmentApi.Models;

/// <summary>
/// An account held by a user. Accounts belong to an account group and hold positions in the form of units.
/// </summary>
public record Account
{
    /// <summary>
    /// Universally Unique Identifier (UUID) of the account.
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
    /// Universally Unique Identifier (UUID) of the account group.
    /// </summary>
    [JsonPropertyName("account_group_id")]
    public required Guid AccountGroupId { get; init; }

    /// <summary>
    /// Account type.
    /// * TRADING - Orders in accounts of this type are created on a specific instrument basis.
    /// * PORTFOLIO - Orders in accounts of this type are created on a portfolio basis and additional portfolio functionality is available.
    /// </summary>
    [JsonPropertyName("type")]
    public required Type16 Type { get; init; }

    /// <summary>
    /// The users associated with the account, each with their relation type.
    /// </summary>
    [JsonPropertyName("users")]
    public required IReadOnlyList<User> Users { get; init; }

    /// <summary>
    /// The serial account number of the account in the account group.
    /// </summary>
    [JsonPropertyName("account_number")]
    [Minimum(1)]
    public required int AccountNumber { get; init; }

    /// <summary>
    /// The name of the account.
    /// </summary>
    [JsonPropertyName("name")]
    [MaxLength(100)]
    public required string Name { get; init; }

    /// <summary>
    /// The status of the account.
    /// * <c>PENDING_APPROVAL</c> — Account approval is pending — the account is visible through our API but cannot be acted on.
    /// * <c>ACTIVE</c> — Account is active — full functionality of the Investment API is accessible.
    /// * <c>CLOSING</c> — Account is closing — only sell orders or the transfer of positions out are permissible before the account is closed.
    /// * <c>CLOSED</c> — Account is closed with zero balance.
    /// * <c>LOCKED</c> — Account is locked for all actions.
    /// </summary>
    [JsonPropertyName("status")]
    public required Status21 Status { get; init; }
}
