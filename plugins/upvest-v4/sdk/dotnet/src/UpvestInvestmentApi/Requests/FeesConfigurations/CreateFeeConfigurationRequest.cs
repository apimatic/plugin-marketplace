using UpvestInvestmentApi.Models;
using UpvestInvestmentApi.Models.Enums;

namespace UpvestInvestmentApi.Requests.FeesConfigurations;

/// <summary>
/// The inputs of the CreateFeeConfiguration operation.
/// </summary>
public sealed record CreateFeeConfigurationRequest
{
    /// <summary>
    /// Upvest API version (Note: Do not include quotation marks)
    /// </summary>
    public UpvestApiVersion UpvestApiVersion { get; init; } = UpvestApiVersion._1;

    public FeeConfigurationCreateRequest1? Body { get; init; }
}
