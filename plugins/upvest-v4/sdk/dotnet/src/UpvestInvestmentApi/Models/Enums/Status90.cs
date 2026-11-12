using System;
using System.Text.Json.Serialization;
using UpvestInvestmentApi.Core.Enum;

namespace UpvestInvestmentApi.Models.Enums;

/// <summary>
/// Status of a Savings Plan Execution.
/// * NEW -
/// * PROCESSING -
/// * FILLED -
/// * SETTLED -
/// * CANCELLED -
/// </summary>
[JsonConverter(typeof(StringEnumConverter<Status90>))]
public sealed record Status90 : OpenStringEnum<Status90>
{
    private Status90(string value) : base(value)
    {
    }

    public static readonly Status90 New = new("NEW");

    public static readonly Status90 Processing = new("PROCESSING");

    public static readonly Status90 Filled = new("FILLED");

    public static readonly Status90 Settled = new("SETTLED");

    public static readonly Status90 Cancelled = new("CANCELLED");

    public TResult Match<TResult>(Func<TResult> onNew,
        Func<TResult> onProcessing,
        Func<TResult> onFilled,
        Func<TResult> onSettled,
        Func<TResult> onCancelled,
        Func<string, TResult> otherwise) =>
        this switch
        {
            _ when this == New => onNew(),
            _ when this == Processing => onProcessing(),
            _ when this == Filled => onFilled(),
            _ when this == Settled => onSettled(),
            _ when this == Cancelled => onCancelled(),
            _ => otherwise(Value)
        };

    public void Match(Action onNew,
        Action onProcessing,
        Action onFilled,
        Action onSettled,
        Action onCancelled,
        Action<string> otherwise)
    {
        if (this == New) onNew();
        else if (this == Processing) onProcessing();
        else if (this == Filled) onFilled();
        else if (this == Settled) onSettled();
        else if (this == Cancelled) onCancelled();
        else otherwise(Value);
    }
}
