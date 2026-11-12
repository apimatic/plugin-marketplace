using System;
using UpvestInvestmentApi.Models.Enums;

namespace UpvestInvestmentApi.Requests.CashBalances;

/// <summary>
/// The inputs of the RetrieveCashBalanceWithCurrency operation.
/// </summary>
public sealed record RetrieveCashBalanceWithCurrencyRequest
{
    /// <summary>
    /// The unique identifier of the account group. Universally Unique Identifier (UUID).
    /// </summary>
    public required Guid AccountGroupId { get; init; }

    /// <summary>
    /// The <see href="https://www.iso.org/iso-4217-currency-codes.html">ISO 4217</see> alphabetic currency code identifying the cash balance (e.g. <c>EUR</c>).
    /// </summary>
    public required Currency1 Currency { get; init; }

    /// <summary>
    /// Upvest API version (Note: Do not include quotation marks)
    /// </summary>
    public UpvestApiVersion UpvestApiVersion { get; init; } = UpvestApiVersion._1;
}
