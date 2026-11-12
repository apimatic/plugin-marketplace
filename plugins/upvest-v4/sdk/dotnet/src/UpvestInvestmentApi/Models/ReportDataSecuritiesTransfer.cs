using System.Collections.Generic;
using System.Text.Json.Serialization;
using UpvestInvestmentApi.Core.Models;

namespace UpvestInvestmentApi.Models;

/// <summary>
/// The contents of a securities transfer report, including the account it relates to and the transferred instrument.
/// </summary>
public record ReportDataSecuritiesTransfer
{
    /// <summary>
    /// The account that the report relates to.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("account")]
    public Account7? Account { get; init; }

    /// <summary>
    /// Identifiers of the resources that the report relates to, such as the order or corporate action that triggered it.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("references")]
    public IReadOnlyList<ReportReferenceData>? References { get; init; }

    /// <summary>
    /// The instrument that the report relates to.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("instrument")]
    public ReportInstrument? Instrument { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
