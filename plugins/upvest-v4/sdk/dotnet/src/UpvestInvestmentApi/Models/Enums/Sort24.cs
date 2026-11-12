using System;
using System.Text.Json.Serialization;
using UpvestInvestmentApi.Core.Enum;

namespace UpvestInvestmentApi.Models.Enums;

[JsonConverter(typeof(StringEnumConverter<Sort24>))]
public sealed record Sort24 : OpenStringEnum<Sort24>
{
    private Sort24(string value) : base(value)
    {
    }

    public static readonly Sort24 Id = new("id");

    public TResult Match<TResult>(Func<TResult> onId, Func<string, TResult> otherwise) =>
        this switch
        {
            _ when this == Id => onId(),
            _ => otherwise(Value)
        };

    public void Match(Action onId, Action<string> otherwise)
    {
        if (this == Id) onId();
        else otherwise(Value);
    }
}
