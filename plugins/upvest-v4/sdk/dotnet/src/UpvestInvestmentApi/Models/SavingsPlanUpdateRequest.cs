using System.Text.Json.Serialization;

namespace UpvestInvestmentApi.Models;

public record SavingsPlanUpdateRequest
{
    /// <summary>
    /// Funding configuration. Pass <c>null</c> to remove funding from the plan.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("funding")]
    public SavingsPlanFunding? Funding { get; init; }
}
