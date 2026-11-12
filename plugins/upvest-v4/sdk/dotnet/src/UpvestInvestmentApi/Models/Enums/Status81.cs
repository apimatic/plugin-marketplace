using System;
using System.Text.Json.Serialization;
using UpvestInvestmentApi.Core.Enum;

namespace UpvestInvestmentApi.Models.Enums;

/// <summary>
/// Status of the transfer
/// * NEW - Transfer is created.
/// * PROCESSING - Transfer is being processed.
/// * SETTLED - Transfer is completed.
/// * CANCELLED - Transfer is cancelled.
/// </summary>
[JsonConverter(typeof(StringEnumConverter<Status81>))]
public sealed record Status81 : OpenStringEnum<Status81>
{
    private Status81(string value) : base(value)
    {
    }

    public static readonly Status81 New = new("NEW");

    public static readonly Status81 Processing = new("PROCESSING");

    public static readonly Status81 Settled = new("SETTLED");

    public static readonly Status81 Cancelled = new("CANCELLED");

    public TResult Match<TResult>(Func<TResult> onNew,
        Func<TResult> onProcessing,
        Func<TResult> onSettled,
        Func<TResult> onCancelled,
        Func<string, TResult> otherwise) =>
        this switch
        {
            _ when this == New => onNew(),
            _ when this == Processing => onProcessing(),
            _ when this == Settled => onSettled(),
            _ when this == Cancelled => onCancelled(),
            _ => otherwise(Value)
        };

    public void Match(Action onNew, Action onProcessing, Action onSettled, Action onCancelled, Action<string> otherwise)
    {
        if (this == New) onNew();
        else if (this == Processing) onProcessing();
        else if (this == Settled) onSettled();
        else if (this == Cancelled) onCancelled();
        else otherwise(Value);
    }
}
