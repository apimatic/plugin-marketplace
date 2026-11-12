using System;
using System.Text.Json.Serialization;
using UpvestInvestmentApi.Core.Enum;

namespace UpvestInvestmentApi.Models.Enums;

/// <summary>
/// Status of the virtual cash
/// * ISSUED - Virtual cash increase is created.
/// * CONFIRMED - Virtual cash increase was successfully processed.
/// * CANCELLED - Virtual cash increase was cancelled.
/// </summary>
[JsonConverter(typeof(StringEnumConverter<Status82>))]
public sealed record Status82 : OpenStringEnum<Status82>
{
    private Status82(string value) : base(value)
    {
    }

    public static readonly Status82 Issued = new("ISSUED");

    public static readonly Status82 Confirmed = new("CONFIRMED");

    public static readonly Status82 Cancelled = new("CANCELLED");

    public TResult Match<TResult>(Func<TResult> onIssued,
        Func<TResult> onConfirmed,
        Func<TResult> onCancelled,
        Func<string, TResult> otherwise) =>
        this switch
        {
            _ when this == Issued => onIssued(),
            _ when this == Confirmed => onConfirmed(),
            _ when this == Cancelled => onCancelled(),
            _ => otherwise(Value)
        };

    public void Match(Action onIssued, Action onConfirmed, Action onCancelled, Action<string> otherwise)
    {
        if (this == Issued) onIssued();
        else if (this == Confirmed) onConfirmed();
        else if (this == Cancelled) onCancelled();
        else otherwise(Value);
    }
}
