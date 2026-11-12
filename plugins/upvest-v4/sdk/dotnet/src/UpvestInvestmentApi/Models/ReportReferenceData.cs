using System;
using System.Text.Json.Serialization;
using UpvestInvestmentApi.Core.Models;
using UpvestInvestmentApi.Models.Enums;

namespace UpvestInvestmentApi.Models;

/// <summary>
/// A reference from a report to the resource that it relates to.
/// </summary>
public record ReportReferenceData
{
    /// <summary>
    /// The unique identifier of the referenced resource, as a UUID.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("id")]
    public Guid? Id { get; init; }

    /// <summary>
    /// Report reference type
    /// * CORPORATE_ACTION_TRANSACTION_ID - Corporate action transaction identifier
    /// * ACCOUNT_GROUP_ID - Account group identifier
    /// * ACCOUNT_ID - Account identifier
    /// * ORDER_ID - Order identifier
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("type")]
    public ReportReferenceType? Type { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
