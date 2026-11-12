using System;
using System.Text.Json.Serialization;
using UpvestInvestmentApi.Core.Enum;

namespace UpvestInvestmentApi.Models.Enums;

[JsonConverter(typeof(StringEnumConverter<PriceQuality1>))]
public sealed record PriceQuality1 : OpenStringEnum<PriceQuality1>
{
    private PriceQuality1(string value) : base(value)
    {
    }

    public static readonly PriceQuality1 HighestAvailable = new("HIGHEST_AVAILABLE");

    public TResult Match<TResult>(Func<TResult> onHighestAvailable, Func<string, TResult> otherwise) =>
        this switch
        {
            _ when this == HighestAvailable => onHighestAvailable(),
            _ => otherwise(Value)
        };

    public void Match(Action onHighestAvailable, Action<string> otherwise)
    {
        if (this == HighestAvailable) onHighestAvailable();
        else otherwise(Value);
    }
}
