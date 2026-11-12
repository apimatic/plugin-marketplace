using System;
using System.Text.Json.Serialization;
using UpvestInvestmentApi.Core.Enum;

namespace UpvestInvestmentApi.Models.Enums;

/// <summary>
/// The price quality used to calculate the value of this position.
/// * EOD - End of day price
/// * REALTIME - Real-time price
/// * DELAYED - Delayed price
/// * NA - No price was available.
/// </summary>
[JsonConverter(typeof(StringEnumConverter<PriceQuality5>))]
public sealed record PriceQuality5 : OpenStringEnum<PriceQuality5>
{
    private PriceQuality5(string value) : base(value)
    {
    }

    public static readonly PriceQuality5 Eod = new("EOD");

    public static readonly PriceQuality5 Realtime = new("REALTIME");

    public static readonly PriceQuality5 Delayed = new("DELAYED");

    public static readonly PriceQuality5 Na = new("NA");

    public TResult Match<TResult>(Func<TResult> onEod,
        Func<TResult> onRealtime,
        Func<TResult> onDelayed,
        Func<TResult> onNa,
        Func<string, TResult> otherwise) =>
        this switch
        {
            _ when this == Eod => onEod(),
            _ when this == Realtime => onRealtime(),
            _ when this == Delayed => onDelayed(),
            _ when this == Na => onNa(),
            _ => otherwise(Value)
        };

    public void Match(Action onEod, Action onRealtime, Action onDelayed, Action onNa, Action<string> otherwise)
    {
        if (this == Eod) onEod();
        else if (this == Realtime) onRealtime();
        else if (this == Delayed) onDelayed();
        else if (this == Na) onNa();
        else otherwise(Value);
    }
}
