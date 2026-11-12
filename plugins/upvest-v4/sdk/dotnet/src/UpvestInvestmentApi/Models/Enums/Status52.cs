using System;
using System.Text.Json.Serialization;
using UpvestInvestmentApi.Core.Enum;

namespace UpvestInvestmentApi.Models.Enums;

/// <summary>
/// Status of the execution.
/// * FILLED — the execution has been filled.
/// * SETTLED — the execution has settled and securities and cash have been exchanged.
/// * CANCELLED — the execution was cancelled before settlement.
/// </summary>
[JsonConverter(typeof(StringEnumConverter<Status52>))]
public sealed record Status52 : OpenStringEnum<Status52>
{
    private Status52(string value) : base(value)
    {
    }

    public static readonly Status52 Filled = new("FILLED");

    public static readonly Status52 Settled = new("SETTLED");

    public static readonly Status52 Cancelled = new("CANCELLED");

    public TResult Match<TResult>(Func<TResult> onFilled,
        Func<TResult> onSettled,
        Func<TResult> onCancelled,
        Func<string, TResult> otherwise) =>
        this switch
        {
            _ when this == Filled => onFilled(),
            _ when this == Settled => onSettled(),
            _ when this == Cancelled => onCancelled(),
            _ => otherwise(Value)
        };

    public void Match(Action onFilled, Action onSettled, Action onCancelled, Action<string> otherwise)
    {
        if (this == Filled) onFilled();
        else if (this == Settled) onSettled();
        else if (this == Cancelled) onCancelled();
        else otherwise(Value);
    }
}
