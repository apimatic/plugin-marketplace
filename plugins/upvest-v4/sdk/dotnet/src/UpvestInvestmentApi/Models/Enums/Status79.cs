using System;
using System.Text.Json.Serialization;
using UpvestInvestmentApi.Core.Enum;

namespace UpvestInvestmentApi.Models.Enums;

/// <summary>
/// Status of the securities transfer
/// * <c>NEW</c> - Securities transfer is created but not started processing.
/// * <c>PROCESSING</c> - Securities transfer is in processing.
/// * <c>SETTLED</c> - Securities transfer was successfully settled.
/// * <c>CANCELLED</c> - Securities transfer was cancelled.
/// </summary>
[JsonConverter(typeof(StringEnumConverter<Status79>))]
public sealed record Status79 : OpenStringEnum<Status79>
{
    private Status79(string value) : base(value)
    {
    }

    public static readonly Status79 New = new("NEW");

    public static readonly Status79 Processing = new("PROCESSING");

    public static readonly Status79 Settled = new("SETTLED");

    public static readonly Status79 Cancelled = new("CANCELLED");

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
