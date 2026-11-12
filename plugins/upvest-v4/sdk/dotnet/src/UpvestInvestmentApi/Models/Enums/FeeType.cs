using System;
using System.Text.Json.Serialization;
using UpvestInvestmentApi.Core.Enum;

namespace UpvestInvestmentApi.Models.Enums;

/// <summary>
/// Fee type
/// * TRANSACTION_FEE_BUY -
/// * TRANSACTION_FEE_SELL -
/// </summary>
[JsonConverter(typeof(StringEnumConverter<FeeType>))]
public sealed record FeeType : OpenStringEnum<FeeType>
{
    private FeeType(string value) : base(value)
    {
    }

    public static readonly FeeType TransactionFeeBuy = new("TRANSACTION_FEE_BUY");

    public static readonly FeeType TransactionFeeSell = new("TRANSACTION_FEE_SELL");

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
