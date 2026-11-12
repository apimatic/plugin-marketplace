using System;
using System.Text.Json.Serialization;
using UpvestInvestmentApi.Core.Enum;

namespace UpvestInvestmentApi.Models.Enums;

/// <summary>
/// The unit in which the holding period is counted.
/// * YEAR — The holding period is counted in years.
/// </summary>
[JsonConverter(typeof(StringEnumConverter<Unit>))]
public sealed record Unit : OpenStringEnum<Unit>
{
    private Unit(string value) : base(value)
    {
    }

    public static readonly Unit Year = new("YEAR");

    public TResult Match<TResult>(Func<TResult> onYear, Func<string, TResult> otherwise) =>
        this switch
        {
            _ when this == Year => onYear(),
            _ => otherwise(Value)
        };

    public void Match(Action onYear, Action<string> otherwise)
    {
        if (this == Year) onYear();
        else otherwise(Value);
    }
}
