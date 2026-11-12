using System;
using System.Text.Json.Serialization;
using UpvestInvestmentApi.Core.Models;
using UpvestInvestmentApi.Models.Enums;

namespace UpvestInvestmentApi.Models;

public record User
{
    /// <summary>
    /// Unique identifier of the user, as a UUID.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("id")]
    public Guid? Id { get; init; }

    /// <summary>
    /// Relation of the user to the account group.
    /// * <c>OWNER</c> — The user owns the account group. A <c>JOINT</c> account group has exactly 2 <c>OWNER</c> users.
    /// * <c>CHILD</c> — The user is the child in a child account group.
    /// * <c>GUARDIAN</c> — The user is a guardian of a child account group.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("type")]
    public Type12? Type { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
