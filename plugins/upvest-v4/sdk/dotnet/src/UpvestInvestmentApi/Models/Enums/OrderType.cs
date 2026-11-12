using System;
using System.Text.Json.Serialization;
using UpvestInvestmentApi.Core.Enum;

namespace UpvestInvestmentApi.Models.Enums;

/// <summary>
/// Type of the order.
/// * MARKET — executes immediately at the best available market price.
/// * LIMIT — executes only at or better than the specified <c>limit_price</c>.
/// * STOP — triggers when the market price reaches <c>stop_price</c>, then executes at the prevailing market price.
/// </summary>
[JsonConverter(typeof(StringEnumConverter<OrderType>))]
public sealed record OrderType : OpenStringEnum<OrderType>
{
    private OrderType(string value) : base(value)
    {
    }

    public static readonly OrderType Market = new("MARKET");

    public static readonly OrderType Limit = new("LIMIT");

    public static readonly OrderType Stop = new("STOP");

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
