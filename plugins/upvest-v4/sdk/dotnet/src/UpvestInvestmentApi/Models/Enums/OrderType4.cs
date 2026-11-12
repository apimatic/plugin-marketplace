using System;
using System.Text.Json.Serialization;
using UpvestInvestmentApi.Core.Enum;

namespace UpvestInvestmentApi.Models.Enums;

/// <summary>
/// How the order is priced.
/// * MARKET — Executes at the best price available.
/// * LIMIT — Executes only at the <c>limit_price</c> or better.
/// * STOP — Becomes a market order once the <c>stop_price</c> is reached.
/// </summary>
[JsonConverter(typeof(StringEnumConverter<OrderType4>))]
public sealed record OrderType4 : OpenStringEnum<OrderType4>
{
    private OrderType4(string value) : base(value)
    {
    }

    public static readonly OrderType4 Market = new("MARKET");

    public static readonly OrderType4 Limit = new("LIMIT");

    public static readonly OrderType4 Stop = new("STOP");

    public TResult Match<TResult>(Func<TResult> onMarket,
        Func<TResult> onLimit,
        Func<TResult> onStop,
        Func<string, TResult> otherwise) =>
        this switch
        {
            _ when this == Market => onMarket(),
            _ when this == Limit => onLimit(),
            _ when this == Stop => onStop(),
            _ => otherwise(Value)
        };

    public void Match(Action onMarket, Action onLimit, Action onStop, Action<string> otherwise)
    {
        if (this == Market) onMarket();
        else if (this == Limit) onLimit();
        else if (this == Stop) onStop();
        else otherwise(Value);
    }
}
