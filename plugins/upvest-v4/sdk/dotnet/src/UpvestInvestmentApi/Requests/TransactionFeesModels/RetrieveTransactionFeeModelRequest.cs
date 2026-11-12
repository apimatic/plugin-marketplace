using System;
using UpvestInvestmentApi.Models.Enums;

namespace UpvestInvestmentApi.Requests.TransactionFeesModels;

/// <summary>
/// The inputs of the RetrieveTransactionFeeModel operation.
/// </summary>
public sealed record RetrieveTransactionFeeModelRequest
{
    /// <summary>
    /// The unique identifier of the transaction fee model. Universally Unique Identifier (UUID).
    /// </summary>
    public required Guid TransactionFeeModelId { get; init; }

    /// <summary>
    /// Upvest API version (Note: Do not include quotation marks)
    /// </summary>
    public UpvestApiVersion UpvestApiVersion { get; init; } = UpvestApiVersion._1;
}
