using System;
using UpvestInvestmentApi.Models.Enums;

namespace UpvestInvestmentApi.Requests.Withdrawals;

/// <summary>
/// The inputs of the RetrieveCashWithdrawal operation.
/// </summary>
public sealed record RetrieveCashWithdrawalRequest
{
    /// <summary>
    /// The unique identifier of the cash withdrawal. Universally Unique Identifier (UUID).
    /// </summary>
    public required Guid WithdrawalId { get; init; }

    /// <summary>
    /// Upvest API version (Note: Do not include quotation marks)
    /// </summary>
    public UpvestApiVersion UpvestApiVersion { get; init; } = UpvestApiVersion._1;
}
