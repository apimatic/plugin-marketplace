using System;
using System.Text.Json.Serialization;
using UpvestInvestmentApi.Core.Enum;

namespace UpvestInvestmentApi.Models.Enums;

/// <summary>
/// Status of the cash balance transfer.
/// * ISSUED - Transfer has been created and the cash movement is in progress.
/// * CONFIRMED - Cash was successfully moved from the source to the target account group.
/// * CANCELLED - Transfer was cancelled and no cash was moved.
/// </summary>
[JsonConverter(typeof(StringEnumConverter<Status37>))]
public sealed record Status37 : OpenStringEnum<Status37>
{
    private Status37(string value) : base(value)
    {
    }

    public static readonly Status37 Issued = new("ISSUED");

    public static readonly Status37 Confirmed = new("CONFIRMED");

    public static readonly Status37 Cancelled = new("CANCELLED");

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
