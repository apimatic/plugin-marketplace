using System;
using System.Text.Json.Serialization;
using UpvestInvestmentApi.Core.Models;

namespace UpvestInvestmentApi.Models;

public record AccountLiquidationRequest1
{
    /// <summary>
    /// Unique identifier of the user, as a UUID.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("user_id")]
    public Guid? UserId { get; init; }

    /// <summary>
    /// Unique identifier for the business.
    /// </summary>
    [JsonPropertyName("business_id")]
    public required Guid BusinessId { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
