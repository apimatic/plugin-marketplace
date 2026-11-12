using UpvestInvestmentApi.Models;
using UpvestInvestmentApi.Models.Enums;

namespace UpvestInvestmentApi.Requests.TransactionFeesConfigurations;

/// <summary>
/// The inputs of the CreateTransactionFeeAccountGroupConfiguration operation.
/// </summary>
public sealed record CreateTransactionFeeAccountGroupConfigurationRequest
{
    /// <summary>
    /// Upvest API version (Note: Do not include quotation marks)
    /// </summary>
    public UpvestApiVersion UpvestApiVersion { get; init; } = UpvestApiVersion._1;

    public TransactionFeeAccountGroupConfigurationCreateRequest? Body { get; init; }
}
