using System;
using System.Text.Json.Serialization;
using UpvestInvestmentApi.Core.Enum;

namespace UpvestInvestmentApi.Models.Enums;

[JsonConverter(typeof(StringEnumConverter<Order60>))]
public sealed record Order60 : OpenStringEnum<Order60>
{
    private Order60(string value) : base(value)
    {
    }

    public static readonly Order60 Asc = new("ASC");

    public TResult Match<TResult>(Func<TResult> onAsc, Func<string, TResult> otherwise) =>
        this switch
        {
            _ when this == Asc => onAsc(),
            _ => otherwise(Value)
        };

    public void Match(Action onAsc, Action<string> otherwise)
    {
        if (this == Asc) onAsc();
        else otherwise(Value);
    }
}
