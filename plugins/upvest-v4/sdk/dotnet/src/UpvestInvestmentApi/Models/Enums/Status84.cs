using System;
using System.Text.Json.Serialization;
using UpvestInvestmentApi.Core.Enum;

namespace UpvestInvestmentApi.Models.Enums;

/// <summary>
/// Status of a Savings Plan.
/// * ACTIVE -
/// * CANCELLED -
/// </summary>
[JsonConverter(typeof(StringEnumConverter<Status84>))]
public sealed record Status84 : OpenStringEnum<Status84>
{
    private Status84(string value) : base(value)
    {
    }

    public static readonly Status84 Active = new("ACTIVE");

    public static readonly Status84 Cancelled = new("CANCELLED");

    public TResult Match<TResult>(Func<TResult> onActive, Func<TResult> onCancelled, Func<string, TResult> otherwise) =>
        this switch
        {
            _ when this == Active => onActive(),
            _ when this == Cancelled => onCancelled(),
            _ => otherwise(Value)
        };

    public void Match(Action onActive, Action onCancelled, Action<string> otherwise)
    {
        if (this == Active) onActive();
        else if (this == Cancelled) onCancelled();
        else otherwise(Value);
    }
}
