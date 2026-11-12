using System;
using System.Text.Json.Serialization;
using UpvestInvestmentApi.Core.Enum;

namespace UpvestInvestmentApi.Models.Enums;

/// <summary>
/// Status of the fee collection.
/// * PROCESSING — The fee collection is in progress.
/// * FINALISED — The fees have been collected from the account and the funds transferred to the client.
/// * CANCELLED — The fee collection was cancelled.
/// </summary>
[JsonConverter(typeof(StringEnumConverter<Status53>))]
public sealed record Status53 : OpenStringEnum<Status53>
{
    private Status53(string value) : base(value)
    {
    }

    public static readonly Status53 Processing = new("PROCESSING");

    public static readonly Status53 Finalised = new("FINALISED");

    public static readonly Status53 Cancelled = new("CANCELLED");

    public TResult Match<TResult>(Func<TResult> onProcessing,
        Func<TResult> onFinalised,
        Func<TResult> onCancelled,
        Func<string, TResult> otherwise) =>
        this switch
        {
            _ when this == Processing => onProcessing(),
            _ when this == Finalised => onFinalised(),
            _ when this == Cancelled => onCancelled(),
            _ => otherwise(Value)
        };

    public void Match(Action onProcessing, Action onFinalised, Action onCancelled, Action<string> otherwise)
    {
        if (this == Processing) onProcessing();
        else if (this == Finalised) onFinalised();
        else if (this == Cancelled) onCancelled();
        else otherwise(Value);
    }
}
