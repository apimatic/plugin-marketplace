using System;
using System.Text.Json.Serialization;
using UpvestInvestmentApi.Core.Enum;

namespace UpvestInvestmentApi.Models.Enums;

/// <summary>
/// The requested price quality.
/// * EOD - End of day prices
/// * HIGHEST_AVAILABLE - The most recent available prices
/// </summary>
[JsonConverter(typeof(StringEnumConverter<PriceQuality4>))]
public sealed record PriceQuality4 : OpenStringEnum<PriceQuality4>
{
    private PriceQuality4(string value) : base(value)
    {
    }

    public static readonly PriceQuality4 Eod = new("EOD");

    public static readonly PriceQuality4 HighestAvailable = new("HIGHEST_AVAILABLE");

    public TResult Match<TResult>(Func<TResult> onEod,
        Func<TResult> onHighestAvailable,
        Func<string, TResult> otherwise) =>
        this switch
        {
            _ when this == Eod => onEod(),
            _ when this == HighestAvailable => onHighestAvailable(),
            _ => otherwise(Value)
        };

    public void Match(Action onEod, Action onHighestAvailable, Action<string> otherwise)
    {
        if (this == Eod) onEod();
        else if (this == HighestAvailable) onHighestAvailable();
        else otherwise(Value);
    }
}
