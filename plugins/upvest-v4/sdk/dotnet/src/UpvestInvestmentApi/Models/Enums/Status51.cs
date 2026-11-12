using System;
using System.Text.Json.Serialization;
using UpvestInvestmentApi.Core.Enum;

namespace UpvestInvestmentApi.Models.Enums;

/// <summary>
/// The execution status of the order.
/// * NEW — the order has been received and validated, awaiting routing.
/// * PROCESSING — the order is being routed for execution.
/// * FILLED — the order has been fully executed.
/// * CANCELLED — the order was cancelled before being fully executed.
/// </summary>
[JsonConverter(typeof(StringEnumConverter<Status51>))]
public sealed record Status51 : OpenStringEnum<Status51>
{
    private Status51(string value) : base(value)
    {
    }

    public static readonly Status51 New = new("NEW");

    public static readonly Status51 Processing = new("PROCESSING");

    public static readonly Status51 Filled = new("FILLED");

    public static readonly Status51 Cancelled = new("CANCELLED");

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
