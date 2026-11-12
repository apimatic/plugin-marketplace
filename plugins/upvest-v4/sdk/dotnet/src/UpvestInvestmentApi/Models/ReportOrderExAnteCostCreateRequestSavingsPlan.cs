using System.Collections.Generic;
using System.Text.Json.Serialization;
using UpvestInvestmentApi.Core.Models;
using UpvestInvestmentApi.Models.AnyOf;

namespace UpvestInvestmentApi.Models;

public record ReportOrderExAnteCostCreateRequestSavingsPlan
{
    /// <summary>
    /// The type of report must be “ORDER_EX_ANTE_COST_SAVINGS_PLAN”. Savings plan ex-ante reports are only supported for individual users, not for business entities.
    /// </summary>
    [JsonPropertyName("type")]
    public string Type { get; init; } = "ORDER_EX_ANTE_COST_SAVINGS_PLAN";

    /// <summary>
    /// Savings Plan Order details.
    /// </summary>
    [JsonPropertyName("order")]
    public required ExAnteCostSavingsPlanOrder Order { get; init; }

    /// <summary>
    /// Client fees.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("fees")]
    public IReadOnlyList<Fee4>? Fees { get; init; }

    /// <summary>
    /// Client inducements.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("inducements")]
    public IReadOnlyList<Inducement>? Inducements { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
