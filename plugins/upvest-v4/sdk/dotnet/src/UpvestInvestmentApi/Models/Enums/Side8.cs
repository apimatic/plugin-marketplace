using System;
using System.Text.Json.Serialization;
using UpvestInvestmentApi.Core.Enum;

namespace UpvestInvestmentApi.Models.Enums;

/// <summary>
/// Whether the order buys or sells the instrument.
/// * BUY — The order buys the instrument.
/// * SELL — The order sells the instrument.
/// </summary>
[JsonConverter(typeof(StringEnumConverter<Side8>))]
public sealed record Side8 : OpenStringEnum<Side8>
{
    private Side8(string value) : base(value)
    {
    }

    public static readonly Side8 Buy = new("BUY");

    public static readonly Side8 Sell = new("SELL");

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
