using System;
using System.Text.Json.Serialization;
using UpvestInvestmentApi.Core.Enum;

namespace UpvestInvestmentApi.Models.Enums;

[JsonConverter(typeof(StringEnumConverter<UpvestApiVersion>))]
public sealed record UpvestApiVersion : OpenStringEnum<UpvestApiVersion>
{
    private UpvestApiVersion(string value) : base(value)
    {
    }

    public static readonly UpvestApiVersion _1 = new("1");

    public TResult Match<TResult>(Func<TResult> on_1, Func<string, TResult> otherwise) =>
        this switch
        {
            _ when this == _1 => on_1(),
            _ => otherwise(Value)
        };

    public void Match(Action on_1, Action<string> otherwise)
    {
        if (this == _1) on_1();
        else otherwise(Value);
    }
}
