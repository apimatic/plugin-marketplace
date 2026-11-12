using UpvestInvestmentApi.Models;
using UpvestInvestmentApi.Models.Enums;

namespace UpvestInvestmentApi.Requests.TransactionFeesModels;

/// <summary>
/// The inputs of the CreateTransactionFeeModel operation.
/// </summary>
public sealed record CreateTransactionFeeModelRequest
{
    /// <summary>
    /// Upvest API version (Note: Do not include quotation marks)
    /// </summary>
    public UpvestApiVersion UpvestApiVersion { get; init; } = UpvestApiVersion._1;

    public FeeConfigurationCreateRequest? Body { get; init; }
}
