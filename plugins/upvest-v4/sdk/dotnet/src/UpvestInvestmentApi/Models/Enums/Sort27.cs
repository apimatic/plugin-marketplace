using System;
using System.Text.Json.Serialization;
using UpvestInvestmentApi.Core.Enum;

namespace UpvestInvestmentApi.Models.Enums;

[JsonConverter(typeof(StringEnumConverter<Sort27>))]
public sealed record Sort27 : OpenStringEnum<Sort27>
{
    private Sort27(string value) : base(value)
    {
    }

    public static readonly Sort27 Status = new("status");

    public TResult Match<TResult>(Func<TResult> onStatus, Func<string, TResult> otherwise) =>
        this switch
        {
            _ when this == Status => onStatus(),
            _ => otherwise(Value)
        };

    public void Match(Action onStatus, Action<string> otherwise)
    {
        if (this == Status) onStatus();
        else otherwise(Value);
    }
}
