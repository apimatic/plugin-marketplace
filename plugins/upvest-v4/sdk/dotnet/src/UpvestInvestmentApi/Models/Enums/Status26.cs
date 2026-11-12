using System;
using System.Text.Json.Serialization;
using UpvestInvestmentApi.Core.Enum;

namespace UpvestInvestmentApi.Models.Enums;

/// <summary>
/// Status of the direct debit
/// * NEW - Direct debit is created but not started processing.
/// * PROCESSING - Direct debit is in processing.
/// * CONFIRMED - Direct debit was successfully processed.
/// * CANCELLED - Direct debit was cancelled.
/// </summary>
[JsonConverter(typeof(StringEnumConverter<Status26>))]
public sealed record Status26 : OpenStringEnum<Status26>
{
    private Status26(string value) : base(value)
    {
    }

    public static readonly Status26 New = new("NEW");

    public static readonly Status26 Processing = new("PROCESSING");

    public static readonly Status26 Confirmed = new("CONFIRMED");

    public static readonly Status26 Cancelled = new("CANCELLED");

    public TResult Match<TResult>(Func<TResult> onNew,
        Func<TResult> onProcessing,
        Func<TResult> onConfirmed,
        Func<TResult> onCancelled,
        Func<string, TResult> otherwise) =>
        this switch
        {
            _ when this == New => onNew(),
            _ when this == Processing => onProcessing(),
            _ when this == Confirmed => onConfirmed(),
            _ when this == Cancelled => onCancelled(),
            _ => otherwise(Value)
        };

    public void Match(Action onNew,
        Action onProcessing,
        Action onConfirmed,
        Action onCancelled,
        Action<string> otherwise)
    {
        if (this == New) onNew();
        else if (this == Processing) onProcessing();
        else if (this == Confirmed) onConfirmed();
        else if (this == Cancelled) onCancelled();
        else otherwise(Value);
    }
}
