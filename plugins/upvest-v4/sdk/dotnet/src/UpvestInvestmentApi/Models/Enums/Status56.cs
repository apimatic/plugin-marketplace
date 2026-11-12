using System;
using System.Text.Json.Serialization;
using UpvestInvestmentApi.Core.Enum;

namespace UpvestInvestmentApi.Models.Enums;

/// <summary>
/// Status of the tax wrapper
/// * NEW - The tax wrapper is newly created and not yet active due to pending checks.
/// * ACTIVE - The tax wrapper is currently active and in use.
/// * INACTIVE - The tax wrapper is not currently active. New subscriptions not allowed.
/// * CLOSED - The tax wrapper has been closed and is no longer available.
/// </summary>
[JsonConverter(typeof(StringEnumConverter<Status56>))]
public sealed record Status56 : OpenStringEnum<Status56>
{
    private Status56(string value) : base(value)
    {
    }

    public static readonly Status56 New = new("NEW");

    public static readonly Status56 Active = new("ACTIVE");

    public static readonly Status56 Inactive = new("INACTIVE");

    public static readonly Status56 Closed = new("CLOSED");

    public TResult Match<TResult>(Func<TResult> onNew,
        Func<TResult> onActive,
        Func<TResult> onInactive,
        Func<TResult> onClosed,
        Func<string, TResult> otherwise) =>
        this switch
        {
            _ when this == New => onNew(),
            _ when this == Active => onActive(),
            _ when this == Inactive => onInactive(),
            _ when this == Closed => onClosed(),
            _ => otherwise(Value)
        };

    public void Match(Action onNew, Action onActive, Action onInactive, Action onClosed, Action<string> otherwise)
    {
        if (this == New) onNew();
        else if (this == Active) onActive();
        else if (this == Inactive) onInactive();
        else if (this == Closed) onClosed();
        else otherwise(Value);
    }
}
