using System;
using System.Text.Json.Serialization;
using UpvestInvestmentApi.Core.Enum;

namespace UpvestInvestmentApi.Models.Enums;

/// <summary>
/// Type of the Portfolio Order.
/// * BUY -
/// * SELL -
/// * REBALANCING -
/// </summary>
[JsonConverter(typeof(StringEnumConverter<Type46>))]
public sealed record Type46 : OpenStringEnum<Type46>
{
    private Type46(string value) : base(value)
    {
    }

    public static readonly Type46 Buy = new("BUY");

    public static readonly Type46 Sell = new("SELL");

    public static readonly Type46 Rebalancing = new("REBALANCING");

    public TResult Match<TResult>(Func<TResult> onBuy,
        Func<TResult> onSell,
        Func<TResult> onRebalancing,
        Func<string, TResult> otherwise) =>
        this switch
        {
            _ when this == Buy => onBuy(),
            _ when this == Sell => onSell(),
            _ when this == Rebalancing => onRebalancing(),
            _ => otherwise(Value)
        };

    public void Match(Action onBuy, Action onSell, Action onRebalancing, Action<string> otherwise)
    {
        if (this == Buy) onBuy();
        else if (this == Sell) onSell();
        else if (this == Rebalancing) onRebalancing();
        else otherwise(Value);
    }
}
