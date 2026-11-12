using System;
using System.Text.Json.Serialization;
using UpvestInvestmentApi.Core.Enum;

namespace UpvestInvestmentApi.Models.Enums;

/// <summary>
/// What the fee is charged for.
/// * TRANSACTION_FEE_BUY — A fee charged on a buy order.
/// * TRANSACTION_FEE_SELL — A fee charged on a sell order.
/// * ANNUAL_AUM_BASED_FEE — An annual fee charged as a percentage of assets under management.
/// </summary>
[JsonConverter(typeof(StringEnumConverter<FeeType8>))]
public sealed record FeeType8 : OpenStringEnum<FeeType8>
{
    private FeeType8(string value) : base(value)
    {
    }

    public static readonly FeeType8 TransactionFeeBuy = new("TRANSACTION_FEE_BUY");

    public static readonly FeeType8 TransactionFeeSell = new("TRANSACTION_FEE_SELL");

    public static readonly FeeType8 AnnualAumBasedFee = new("ANNUAL_AUM_BASED_FEE");

    public TResult Match<TResult>(Func<TResult> onTransactionFeeBuy,
        Func<TResult> onTransactionFeeSell,
        Func<TResult> onAnnualAumBasedFee,
        Func<string, TResult> otherwise) =>
        this switch
        {
            _ when this == TransactionFeeBuy => onTransactionFeeBuy(),
            _ when this == TransactionFeeSell => onTransactionFeeSell(),
            _ when this == AnnualAumBasedFee => onAnnualAumBasedFee(),
            _ => otherwise(Value)
        };

    public void Match(Action onTransactionFeeBuy,
        Action onTransactionFeeSell,
        Action onAnnualAumBasedFee,
        Action<string> otherwise)
    {
        if (this == TransactionFeeBuy) onTransactionFeeBuy();
        else if (this == TransactionFeeSell) onTransactionFeeSell();
        else if (this == AnnualAumBasedFee) onAnnualAumBasedFee();
        else otherwise(Value);
    }
}
