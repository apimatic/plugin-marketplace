using System;
using System.Text.Json.Serialization;
using UpvestInvestmentApi.Core.Enum;

namespace UpvestInvestmentApi.Models.Enums;

/// <summary>
/// Execution status of the account liquidation.
/// * <c>NEW</c> — The liquidation has been created and awaits processing.
/// * <c>PROCESSING</c> — The liquidation orders are being executed.
/// * <c>FILLED</c> — All liquidation orders have been fully executed.
/// * <c>CANCELLED</c> — The liquidation was cancelled before completion.
/// * <c>SETTLED</c> — The liquidation proceeds have settled as cash.
/// </summary>
[JsonConverter(typeof(StringEnumConverter<Status72>))]
public sealed record Status72 : OpenStringEnum<Status72>
{
    private Status72(string value) : base(value)
    {
    }

    public static readonly Status72 New = new("NEW");

    public static readonly Status72 Processing = new("PROCESSING");

    public static readonly Status72 Filled = new("FILLED");

    public static readonly Status72 Cancelled = new("CANCELLED");

    public static readonly Status72 Settled = new("SETTLED");

    public TResult Match<TResult>(Func<TResult> onNew,
        Func<TResult> onProcessing,
        Func<TResult> onFilled,
        Func<TResult> onCancelled,
        Func<TResult> onSettled,
        Func<string, TResult> otherwise) =>
        this switch
        {
            _ when this == New => onNew(),
            _ when this == Processing => onProcessing(),
            _ when this == Filled => onFilled(),
            _ when this == Cancelled => onCancelled(),
            _ when this == Settled => onSettled(),
            _ => otherwise(Value)
        };

    public void Match(Action onNew,
        Action onProcessing,
        Action onFilled,
        Action onCancelled,
        Action onSettled,
        Action<string> otherwise)
    {
        if (this == New) onNew();
        else if (this == Processing) onProcessing();
        else if (this == Filled) onFilled();
        else if (this == Cancelled) onCancelled();
        else if (this == Settled) onSettled();
        else otherwise(Value);
    }
}
