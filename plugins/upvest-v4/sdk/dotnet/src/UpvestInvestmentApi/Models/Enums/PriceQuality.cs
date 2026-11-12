using System;
using System.Text.Json.Serialization;
using UpvestInvestmentApi.Core.Enum;

namespace UpvestInvestmentApi.Models.Enums;

[JsonConverter(typeof(StringEnumConverter<PriceQuality>))]
public sealed record PriceQuality : OpenStringEnum<PriceQuality>
{
    private PriceQuality(string value) : base(value)
    {
    }

    public static readonly PriceQuality Eod = new("EOD");

    public static readonly PriceQuality Realtime = new("REALTIME");

    public static readonly PriceQuality Delayed = new("DELAYED");

    public TResult Match<TResult>(Func<TResult> onEod,
        Func<TResult> onRealtime,
        Func<TResult> onDelayed,
        Func<string, TResult> otherwise) =>
        this switch
        {
            _ when this == Eod => onEod(),
            _ when this == Realtime => onRealtime(),
            _ when this == Delayed => onDelayed(),
            _ => otherwise(Value)
        };

    public void Match(Action onEod, Action onRealtime, Action onDelayed, Action<string> otherwise)
    {
        if (this == Eod) onEod();
        else if (this == Realtime) onRealtime();
        else if (this == Delayed) onDelayed();
        else otherwise(Value);
    }
}
