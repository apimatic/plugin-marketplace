using System;
using System.Text.Json.Serialization;
using UpvestInvestmentApi.Core.Enum;

namespace UpvestInvestmentApi.Models.Enums;

/// <summary>
/// Type of the Savings plan.
/// * PORTFOLIO -
/// * INSTRUMENT -
/// </summary>
[JsonConverter(typeof(StringEnumConverter<Type67>))]
public sealed record Type67 : OpenStringEnum<Type67>
{
    private Type67(string value) : base(value)
    {
    }

    public static readonly Type67 Portfolio = new("PORTFOLIO");

    public static readonly Type67 Instrument = new("INSTRUMENT");

    public TResult Match<TResult>(Func<TResult> onPortfolio,
        Func<TResult> onInstrument,
        Func<string, TResult> otherwise) =>
        this switch
        {
            _ when this == Portfolio => onPortfolio(),
            _ when this == Instrument => onInstrument(),
            _ => otherwise(Value)
        };

    public void Match(Action onPortfolio, Action onInstrument, Action<string> otherwise)
    {
        if (this == Portfolio) onPortfolio();
        else if (this == Instrument) onInstrument();
        else otherwise(Value);
    }
}
