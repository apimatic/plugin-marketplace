using System;
using System.Text.Json.Serialization;
using UpvestInvestmentApi.Core.Enum;

namespace UpvestInvestmentApi.Models.Enums;

/// <summary>
/// The unit of the savings plan interval.
/// * WEEK — The interval is counted in weeks.
/// * MONTH — The interval is counted in months.
/// * YEAR — The interval is counted in years.
/// </summary>
[JsonConverter(typeof(StringEnumConverter<Period>))]
public sealed record Period : OpenStringEnum<Period>
{
    private Period(string value) : base(value)
    {
    }

    public static readonly Period Week = new("WEEK");

    public static readonly Period Month = new("MONTH");

    public static readonly Period Year = new("YEAR");

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
