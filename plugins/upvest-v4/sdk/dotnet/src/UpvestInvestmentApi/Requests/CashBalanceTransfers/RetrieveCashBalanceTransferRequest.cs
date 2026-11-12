using System;
using UpvestInvestmentApi.Models.Enums;

namespace UpvestInvestmentApi.Requests.CashBalanceTransfers;

/// <summary>
/// The inputs of the RetrieveCashBalanceTransfer operation.
/// </summary>
public sealed record RetrieveCashBalanceTransferRequest
{
    /// <summary>
    /// The unique identifier of the cash balance transfer. Universally Unique Identifier (UUID).
    /// </summary>
    public required Guid CashBalanceTransferId { get; init; }

    /// <summary>
    /// Upvest API version (Note: Do not include quotation marks)
    /// </summary>
    public UpvestApiVersion UpvestApiVersion { get; init; } = UpvestApiVersion._1;
}
