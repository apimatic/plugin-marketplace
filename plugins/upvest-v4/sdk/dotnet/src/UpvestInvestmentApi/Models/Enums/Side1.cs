using System;
using System.Text.Json.Serialization;
using UpvestInvestmentApi.Core.Enum;

namespace UpvestInvestmentApi.Models.Enums;

/// <summary>
/// Side of the execution.
/// * BUY — a buy execution.
/// * SELL — a sell execution.
/// </summary>
[JsonConverter(typeof(StringEnumConverter<Side1>))]
public sealed record Side1 : OpenStringEnum<Side1>
{
    private Side1(string value) : base(value)
    {
    }

    public static readonly Side1 Buy = new("BUY");

    public static readonly Side1 Sell = new("SELL");

    public TResult Match<TResult>(Func<TResult> onBuy, Func<TResult> onSell, Func<string, TResult> otherwise) =>
        this switch
        {
            _ when this == Buy => onBuy(),
            _ when this == Sell => onSell(),
            _ => otherwise(Value)
        };

    public void Match(Action onBuy, Action onSell, Action<string> otherwise)
    {
        if (this == Buy) onBuy();
        else if (this == Sell) onSell();
        else otherwise(Value);
    }
}
