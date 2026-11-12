using System;
using System.Text.Json.Serialization;
using UpvestInvestmentApi.Core.Enum;

namespace UpvestInvestmentApi.Models.Enums;

/// <summary>
/// Side of the portfolio order.
/// * BUY -
/// * SELL -
/// </summary>
[JsonConverter(typeof(StringEnumConverter<Side15>))]
public sealed record Side15 : OpenStringEnum<Side15>
{
    private Side15(string value) : base(value)
    {
    }

    public static readonly Side15 Buy = new("BUY");

    public static readonly Side15 Sell = new("SELL");

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
