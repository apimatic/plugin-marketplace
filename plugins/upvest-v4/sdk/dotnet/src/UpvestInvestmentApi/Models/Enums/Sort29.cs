using System;
using System.Text.Json.Serialization;
using UpvestInvestmentApi.Core.Enum;

namespace UpvestInvestmentApi.Models.Enums;

[JsonConverter(typeof(StringEnumConverter<Sort29>))]
public sealed record Sort29 : OpenStringEnum<Sort29>
{
    private Sort29(string value) : base(value)
    {
    }

    public static readonly Sort29 ValuationTime = new("valuation_time");

    public TResult Match<TResult>(Func<TResult> onValuationTime, Func<string, TResult> otherwise) =>
        this switch
        {
            _ when this == ValuationTime => onValuationTime(),
            _ => otherwise(Value)
        };

    public void Match(Action onValuationTime, Action<string> otherwise)
    {
        if (this == ValuationTime) onValuationTime();
        else otherwise(Value);
    }
}
