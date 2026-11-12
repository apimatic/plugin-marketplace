using System.Text.Json.Serialization;

namespace UpvestInvestmentApi.Models;

/// <summary>
/// Contents of the order ex-ante cost report for a business.
/// </summary>
public record BusinessReportDataOrderExAnteCost
{
    /// <summary>
    /// The holding period assumed when estimating the costs in this report. Costs are projected on the basis that the instrument is held for this period before being sold.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("holding_period")]
    public HoldingPeriod? HoldingPeriod { get; init; }

    /// <summary>
    /// The instrument that the planned order relates to.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("instrument")]
    public Instrument2? Instrument { get; init; }

    /// <summary>
    /// The execution venue on which the planned order would be executed.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("venue")]
    public Venue1? Venue { get; init; }

    /// <summary>
    /// The account that the planned order would be placed for.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("account")]
    public Account12? Account { get; init; }

    /// <summary>
    /// The account group that the account belongs to.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("account_group")]
    public AccountGroup4? AccountGroup { get; init; }

    /// <summary>
    /// The business that the report is addressed to.
    /// </summary>
    [JsonPropertyName("business")]
    public required Business Business { get; init; }

    /// <summary>
    /// The planned order whose costs this report estimates.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("order")]
    public Order57? Order { get; init; }

    /// <summary>
    /// The cumulative effect of the estimated costs on the investment return, shown for each year of the assumed holding period.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("return_impact")]
    public ReturnImpact? ReturnImpact { get; init; }

    /// <summary>
    /// Aggregated totals of product costs, service costs and third party payments.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("total_cost")]
    public OrderExAnteAggregatedCost? TotalCost { get; init; }

    /// <summary>
    /// All costs and associated charges related to the financial instrument.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("product_cost")]
    public OrderExAnteProductCost? ProductCost { get; init; }

    /// <summary>
    /// All costs and associated charges related to the investment service(s) and/or ancillary services.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("service_cost")]
    public OrderExAnteServiceCost? ServiceCost { get; init; }

    /// <summary>
    /// Third party payments associated with the investment service.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("third_party_payments")]
    public ThirdPartyPayments1? ThirdPartyPayments { get; init; }
}
