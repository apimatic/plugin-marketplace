using System;
using System.Text.Json.Serialization;
using UpvestInvestmentApi.Core.Enum;

namespace UpvestInvestmentApi.Models.Enums;

/// <summary>
/// What the transaction fee is charged for.
/// * TRANSACTION_FEE_BUY — A fee charged on a buy order.
/// * TRANSACTION_FEE_SELL — A fee charged on a sell order.
/// </summary>
[JsonConverter(typeof(StringEnumConverter<FeeType10>))]
public sealed record FeeType10 : OpenStringEnum<FeeType10>
{
    private FeeType10(string value) : base(value)
    {
    }

    public static readonly FeeType10 TransactionFeeBuy = new("TRANSACTION_FEE_BUY");

    public static readonly FeeType10 TransactionFeeSell = new("TRANSACTION_FEE_SELL");

    public TResult Match<TResult>(Func<TResult> onTransactionFeeBuy,
        Func<TResult> onTransactionFeeSell,
        Func<string, TResult> otherwise) =>
        this switch
        {
            _ when this == TransactionFeeBuy => onTransactionFeeBuy(),
            _ when this == TransactionFeeSell => onTransactionFeeSell(),
            _ => otherwise(Value)
        };

    public void Match(Action onTransactionFeeBuy, Action onTransactionFeeSell, Action<string> otherwise)
    {
        if (this == TransactionFeeBuy) onTransactionFeeBuy();
        else if (this == TransactionFeeSell) onTransactionFeeSell();
        else otherwise(Value);
    }
}
