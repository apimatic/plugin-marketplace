using System;
using System.Text.Json.Serialization;
using UpvestInvestmentApi.Core.Enum;

namespace UpvestInvestmentApi.Models.Enums;

/// <summary>
/// The quality of the price to use in the valuation.
/// * <c>EOD</c> — End of day prices.
/// * <c>HIGHEST_AVAILABLE</c> — The most recent available prices.
/// </summary>
[JsonConverter(typeof(StringEnumConverter<PriceQuality3>))]
public sealed record PriceQuality3 : OpenStringEnum<PriceQuality3>
{
    private PriceQuality3(string value) : base(value)
    {
    }

    public static readonly PriceQuality3 Eod = new("EOD");

    public static readonly PriceQuality3 HighestAvailable = new("HIGHEST_AVAILABLE");

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
