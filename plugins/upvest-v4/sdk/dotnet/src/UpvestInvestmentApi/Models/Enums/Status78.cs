using System;
using System.Text.Json.Serialization;
using UpvestInvestmentApi.Core.Enum;

namespace UpvestInvestmentApi.Models.Enums;

[JsonConverter(typeof(StringEnumConverter<Status78>))]
public sealed record Status78 : OpenStringEnum<Status78>
{
    private Status78(string value) : base(value)
    {
    }

    public static readonly Status78 New = new("NEW");

    public static readonly Status78 Processing = new("PROCESSING");

    public static readonly Status78 Cancelled = new("CANCELLED");

    public static readonly Status78 Settled = new("SETTLED");

    public TResult Match<TResult>(Func<TResult> onNew,
        Func<TResult> onProcessing,
        Func<TResult> onCancelled,
        Func<TResult> onSettled,
        Func<string, TResult> otherwise) =>
        this switch
        {
            _ when this == New => onNew(),
            _ when this == Processing => onProcessing(),
            _ when this == Cancelled => onCancelled(),
            _ when this == Settled => onSettled(),
            _ => otherwise(Value)
        };

    public void Match(Action onNew, Action onProcessing, Action onCancelled, Action onSettled, Action<string> otherwise)
    {
        if (this == New) onNew();
        else if (this == Processing) onProcessing();
        else if (this == Cancelled) onCancelled();
        else if (this == Settled) onSettled();
        else otherwise(Value);
    }
}
