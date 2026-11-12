using System;
using System.Text.Json.Serialization;
using UpvestInvestmentApi.Core.Enum;

namespace UpvestInvestmentApi.Models.Enums;

[JsonConverter(typeof(StringEnumConverter<Sort33>))]
public sealed record Sort33 : OpenStringEnum<Sort33>
{
    private Sort33(string value) : base(value)
    {
    }

    public static readonly Sort33 Date = new("date");

    public TResult Match<TResult>(Func<TResult> onDate, Func<string, TResult> otherwise) =>
        this switch
        {
            _ when this == Date => onDate(),
            _ => otherwise(Value)
        };

    public void Match(Action onDate, Action<string> otherwise)
    {
        if (this == Date) onDate();
        else otherwise(Value);
    }
}
