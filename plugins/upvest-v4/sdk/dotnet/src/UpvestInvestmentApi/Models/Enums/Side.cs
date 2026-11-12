using System;
using System.Text.Json.Serialization;
using UpvestInvestmentApi.Core.Enum;

namespace UpvestInvestmentApi.Models.Enums;

/// <summary>
/// Side of the order.
/// * BUY — purchases the specified instrument.
/// * SELL — disposes of the specified instrument.
/// </summary>
[JsonConverter(typeof(StringEnumConverter<Side>))]
public sealed record Side : OpenStringEnum<Side>
{
    private Side(string value) : base(value)
    {
    }

    public static readonly Side Buy = new("BUY");

    public static readonly Side Sell = new("SELL");

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
