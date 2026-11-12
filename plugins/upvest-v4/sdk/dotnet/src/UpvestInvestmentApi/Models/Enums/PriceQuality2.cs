using System;
using System.Text.Json.Serialization;
using UpvestInvestmentApi.Core.Enum;

namespace UpvestInvestmentApi.Models.Enums;

/// <summary>
/// The quality of the price data returned.
/// * REALTIME — Priced in real time.
/// * DELAYED — Priced with a delay set by the data owner.
/// </summary>
[JsonConverter(typeof(StringEnumConverter<PriceQuality2>))]
public sealed record PriceQuality2 : OpenStringEnum<PriceQuality2>
{
    private PriceQuality2(string value) : base(value)
    {
    }

    public static readonly PriceQuality2 Realtime = new("REALTIME");

    public static readonly PriceQuality2 Delayed = new("DELAYED");

    public TResult Match<TResult>(Func<TResult> onRealtime, Func<TResult> onDelayed, Func<string, TResult> otherwise) =>
        this switch
        {
            _ when this == Realtime => onRealtime(),
            _ when this == Delayed => onDelayed(),
            _ => otherwise(Value)
        };

    public void Match(Action onRealtime, Action onDelayed, Action<string> otherwise)
    {
        if (this == Realtime) onRealtime();
        else if (this == Delayed) onDelayed();
        else otherwise(Value);
    }
}
