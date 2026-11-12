using System;
using System.Text.Json.Serialization;
using UpvestInvestmentApi.Core.Enum;

namespace UpvestInvestmentApi.Models.Enums;

/// <summary>
/// Unit of time.
/// * WEEK -
/// * MONTH -
/// * YEAR -
/// </summary>
[JsonConverter(typeof(StringEnumConverter<Period1>))]
public sealed record Period1 : OpenStringEnum<Period1>
{
    private Period1(string value) : base(value)
    {
    }

    public static readonly Period1 Week = new("WEEK");

    public static readonly Period1 Month = new("MONTH");

    public static readonly Period1 Year = new("YEAR");

    public TResult Match<TResult>(Func<TResult> onWeek,
        Func<TResult> onMonth,
        Func<TResult> onYear,
        Func<string, TResult> otherwise) =>
        this switch
        {
            _ when this == Week => onWeek(),
            _ when this == Month => onMonth(),
            _ when this == Year => onYear(),
            _ => otherwise(Value)
        };

    public void Match(Action onWeek, Action onMonth, Action onYear, Action<string> otherwise)
    {
        if (this == Week) onWeek();
        else if (this == Month) onMonth();
        else if (this == Year) onYear();
        else otherwise(Value);
    }
}
