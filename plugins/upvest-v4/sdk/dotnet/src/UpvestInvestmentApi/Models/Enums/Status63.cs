using System;
using System.Text.Json.Serialization;
using UpvestInvestmentApi.Core.Enum;

namespace UpvestInvestmentApi.Models.Enums;

/// <summary>
/// Tax residency status
/// * PENDING - It indicates that the tax residency records are not yet processed by Upvest.
/// * ACTIVE - It indicates that tax residency records are processed, and the tax residency record is the one in use.
/// </summary>
[JsonConverter(typeof(StringEnumConverter<Status63>))]
public sealed record Status63 : OpenStringEnum<Status63>
{
    private Status63(string value) : base(value)
    {
    }

    public static readonly Status63 Pending = new("PENDING");

    public static readonly Status63 Active = new("ACTIVE");

    public TResult Match<TResult>(Func<TResult> onPending, Func<TResult> onActive, Func<string, TResult> otherwise) =>
        this switch
        {
            _ when this == Pending => onPending(),
            _ when this == Active => onActive(),
            _ => otherwise(Value)
        };

    public void Match(Action onPending, Action onActive, Action<string> otherwise)
    {
        if (this == Pending) onPending();
        else if (this == Active) onActive();
        else otherwise(Value);
    }
}
