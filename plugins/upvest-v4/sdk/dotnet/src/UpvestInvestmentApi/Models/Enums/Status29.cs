using System;
using System.Text.Json.Serialization;
using UpvestInvestmentApi.Core.Enum;

namespace UpvestInvestmentApi.Models.Enums;

/// <summary>
/// Status of the top up
/// * CONFIRMED - The top up is created and confirmed.
/// * SETTLED - The top up is settled.
/// * CANCELLED - The top up is cancelled
/// </summary>
[JsonConverter(typeof(StringEnumConverter<Status29>))]
public sealed record Status29 : OpenStringEnum<Status29>
{
    private Status29(string value) : base(value)
    {
    }

    public static readonly Status29 Confirmed = new("CONFIRMED");

    public static readonly Status29 Settled = new("SETTLED");

    public static readonly Status29 Cancelled = new("CANCELLED");

    public TResult Match<TResult>(Func<TResult> onConfirmed,
        Func<TResult> onSettled,
        Func<TResult> onCancelled,
        Func<string, TResult> otherwise) =>
        this switch
        {
            _ when this == Confirmed => onConfirmed(),
            _ when this == Settled => onSettled(),
            _ when this == Cancelled => onCancelled(),
            _ => otherwise(Value)
        };

    public void Match(Action onConfirmed, Action onSettled, Action onCancelled, Action<string> otherwise)
    {
        if (this == Confirmed) onConfirmed();
        else if (this == Settled) onSettled();
        else if (this == Cancelled) onCancelled();
        else otherwise(Value);
    }
}
