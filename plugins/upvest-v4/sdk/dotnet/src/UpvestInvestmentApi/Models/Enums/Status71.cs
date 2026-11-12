using System;
using System.Text.Json.Serialization;
using UpvestInvestmentApi.Core.Enum;

namespace UpvestInvestmentApi.Models.Enums;

/// <summary>
/// Status of the Rebalancing Execution Order.
/// * NEW -
/// * PROCESSING -
/// * FILLED -
/// * CANCELLED -
/// </summary>
[JsonConverter(typeof(StringEnumConverter<Status71>))]
public sealed record Status71 : OpenStringEnum<Status71>
{
    private Status71(string value) : base(value)
    {
    }

    public static readonly Status71 New = new("NEW");

    public static readonly Status71 Processing = new("PROCESSING");

    public static readonly Status71 Filled = new("FILLED");

    public static readonly Status71 Cancelled = new("CANCELLED");

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
