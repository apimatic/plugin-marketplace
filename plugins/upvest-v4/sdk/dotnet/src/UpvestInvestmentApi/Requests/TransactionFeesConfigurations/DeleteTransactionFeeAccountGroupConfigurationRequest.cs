using System;
using UpvestInvestmentApi.Models.Enums;

namespace UpvestInvestmentApi.Requests.TransactionFeesConfigurations;

/// <summary>
/// The inputs of the DeleteTransactionFeeAccountGroupConfiguration operation.
/// </summary>
public sealed record DeleteTransactionFeeAccountGroupConfigurationRequest
{
    /// <summary>
    /// The unique identifier of the account group. Universally Unique Identifier (UUID).
    /// </summary>
    public required Guid AccountGroupId { get; init; }

    /// <summary>
    /// The unique identifier of the transaction fee account group configuration. Universally Unique Identifier (UUID).
    /// </summary>
    public required Guid Id { get; init; }

    /// <summary>
    /// Upvest API version (Note: Do not include quotation marks)
    /// </summary>
    public UpvestApiVersion UpvestApiVersion { get; init; } = UpvestApiVersion._1;
}
