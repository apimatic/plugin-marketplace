using System;
using System.Text.Json.Serialization;
using UpvestInvestmentApi.Core.Enum;

namespace UpvestInvestmentApi.Models.Enums;

/// <summary>
/// Status of the virtual cash
/// * ISSUED - Virtual cash decrease is created.
/// * CONFIRMED - Virtual cash decrease was successfully processed.
/// * QUEUED - Virtual cash decrease was queued.
/// * CANCELLED - Virtual cash decrease was cancelled.
/// </summary>
[JsonConverter(typeof(StringEnumConverter<Status83>))]
public sealed record Status83 : OpenStringEnum<Status83>
{
    private Status83(string value) : base(value)
    {
    }

    public static readonly Status83 Issued = new("ISSUED");

    public static readonly Status83 Confirmed = new("CONFIRMED");

    public static readonly Status83 Queued = new("QUEUED");

    public static readonly Status83 Cancelled = new("CANCELLED");

    public TResult Match<TResult>(Func<TResult> onIssued,
        Func<TResult> onConfirmed,
        Func<TResult> onQueued,
        Func<TResult> onCancelled,
        Func<string, TResult> otherwise) =>
        this switch
        {
            _ when this == Issued => onIssued(),
            _ when this == Confirmed => onConfirmed(),
            _ when this == Queued => onQueued(),
            _ when this == Cancelled => onCancelled(),
            _ => otherwise(Value)
        };

    public void Match(Action onIssued,
        Action onConfirmed,
        Action onQueued,
        Action onCancelled,
        Action<string> otherwise)
    {
        if (this == Issued) onIssued();
        else if (this == Confirmed) onConfirmed();
        else if (this == Queued) onQueued();
        else if (this == Cancelled) onCancelled();
        else otherwise(Value);
    }
}
