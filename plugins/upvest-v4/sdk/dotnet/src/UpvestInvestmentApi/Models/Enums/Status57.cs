using System;
using System.Text.Json.Serialization;
using UpvestInvestmentApi.Core.Enum;

namespace UpvestInvestmentApi.Models.Enums;

/// <summary>
/// Status of the allowance:
/// * ACTIVE - Current allowance.
/// * EXPIRED - Allowance from previous years.
/// </summary>
[JsonConverter(typeof(StringEnumConverter<Status57>))]
public sealed record Status57 : OpenStringEnum<Status57>
{
    private Status57(string value) : base(value)
    {
    }

    public static readonly Status57 Active = new("ACTIVE");

    public static readonly Status57 Expired = new("EXPIRED");

    public TResult Match<TResult>(Func<TResult> onActive, Func<TResult> onExpired, Func<string, TResult> otherwise) =>
        this switch
        {
            _ when this == Active => onActive(),
            _ when this == Expired => onExpired(),
            _ => otherwise(Value)
        };

    public void Match(Action onActive, Action onExpired, Action<string> otherwise)
    {
        if (this == Active) onActive();
        else if (this == Expired) onExpired();
        else otherwise(Value);
    }
}
