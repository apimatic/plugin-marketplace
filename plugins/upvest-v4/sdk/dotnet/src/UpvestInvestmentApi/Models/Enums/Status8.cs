using System;
using System.Text.Json.Serialization;
using UpvestInvestmentApi.Core.Enum;

namespace UpvestInvestmentApi.Models.Enums;

/// <summary>
/// Final status of the instrument fit check.
/// * IN_PROGRESS - Instrument fit check is in progress
/// * PASSED - Instrument fit check passed
/// * FAILED - Instrument fit check failed
/// </summary>
[JsonConverter(typeof(StringEnumConverter<Status8>))]
public sealed record Status8 : OpenStringEnum<Status8>
{
    private Status8(string value) : base(value)
    {
    }

    public static readonly Status8 InProgress = new("IN_PROGRESS");

    public static readonly Status8 Passed = new("PASSED");

    public static readonly Status8 Failed = new("FAILED");

    public TResult Match<TResult>(Func<TResult> onInProgress,
        Func<TResult> onPassed,
        Func<TResult> onFailed,
        Func<string, TResult> otherwise) =>
        this switch
        {
            _ when this == InProgress => onInProgress(),
            _ when this == Passed => onPassed(),
            _ when this == Failed => onFailed(),
            _ => otherwise(Value)
        };

    public void Match(Action onInProgress, Action onPassed, Action onFailed, Action<string> otherwise)
    {
        if (this == InProgress) onInProgress();
        else if (this == Passed) onPassed();
        else if (this == Failed) onFailed();
        else otherwise(Value);
    }
}
