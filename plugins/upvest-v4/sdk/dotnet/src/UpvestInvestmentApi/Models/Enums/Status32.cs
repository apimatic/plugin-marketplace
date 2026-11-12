using System;
using System.Text.Json.Serialization;
using UpvestInvestmentApi.Core.Enum;

namespace UpvestInvestmentApi.Models.Enums;

/// <summary>
/// Status of the credit funding
/// * CONFIRMED - Credit Funding was confirmed.
/// * CANCELLED - Credit Funding was cancelled.
/// </summary>
[JsonConverter(typeof(StringEnumConverter<Status32>))]
public sealed record Status32 : OpenStringEnum<Status32>
{
    private Status32(string value) : base(value)
    {
    }

    public static readonly Status32 Confirmed = new("CONFIRMED");

    public static readonly Status32 Cancelled = new("CANCELLED");

    public TResult Match<TResult>(Func<TResult> onConfirmed,
        Func<TResult> onCancelled,
        Func<string, TResult> otherwise) =>
        this switch
        {
            _ when this == Confirmed => onConfirmed(),
            _ when this == Cancelled => onCancelled(),
            _ => otherwise(Value)
        };

    public void Match(Action onConfirmed, Action onCancelled, Action<string> otherwise)
    {
        if (this == Confirmed) onConfirmed();
        else if (this == Cancelled) onCancelled();
        else otherwise(Value);
    }
}
