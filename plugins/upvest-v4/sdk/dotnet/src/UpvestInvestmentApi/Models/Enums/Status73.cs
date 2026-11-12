using System;
using System.Text.Json.Serialization;
using UpvestInvestmentApi.Core.Enum;

namespace UpvestInvestmentApi.Models.Enums;

/// <summary>
/// Execution status of the account liquidation order.
/// * <c>NEW</c> — The order has been created and awaits processing.
/// * <c>PROCESSING</c> — The order is being executed.
/// * <c>FILLED</c> — The order has been fully executed.
/// * <c>CANCELLED</c> — The order was cancelled before completion.
/// </summary>
[JsonConverter(typeof(StringEnumConverter<Status73>))]
public sealed record Status73 : OpenStringEnum<Status73>
{
    private Status73(string value) : base(value)
    {
    }

    public static readonly Status73 New = new("NEW");

    public static readonly Status73 Processing = new("PROCESSING");

    public static readonly Status73 Filled = new("FILLED");

    public static readonly Status73 Cancelled = new("CANCELLED");

    public TResult Match<TResult>(Func<TResult> onNew,
        Func<TResult> onProcessing,
        Func<TResult> onFilled,
        Func<TResult> onCancelled,
        Func<string, TResult> otherwise) =>
        this switch
        {
            _ when this == New => onNew(),
            _ when this == Processing => onProcessing(),
            _ when this == Filled => onFilled(),
            _ when this == Cancelled => onCancelled(),
            _ => otherwise(Value)
        };

    public void Match(Action onNew, Action onProcessing, Action onFilled, Action onCancelled, Action<string> otherwise)
    {
        if (this == New) onNew();
        else if (this == Processing) onProcessing();
        else if (this == Filled) onFilled();
        else if (this == Cancelled) onCancelled();
        else otherwise(Value);
    }
}
