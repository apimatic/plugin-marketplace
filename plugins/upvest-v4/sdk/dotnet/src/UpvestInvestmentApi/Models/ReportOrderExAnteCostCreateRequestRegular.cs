using System.Collections.Generic;
using System.Text.Json.Serialization;
using UpvestInvestmentApi.Core.Models;
using UpvestInvestmentApi.Models.AnyOf;

namespace UpvestInvestmentApi.Models;

public record ReportOrderExAnteCostCreateRequestRegular
{
    /// <summary>
    /// The type of report must be “ORDER_EX_ANTE_COST”.
    /// </summary>
    [JsonPropertyName("type")]
    public string Type { get; init; } = "ORDER_EX_ANTE_COST";

    /// <summary>
    /// The planned order that an ex-ante cost report is calculated for.
    /// </summary>
    [JsonPropertyName("order")]
    public required Order561 Order { get; init; }

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
