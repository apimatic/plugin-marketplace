using System;
using System.Text.Json.Serialization;
using UpvestInvestmentApi.Core.Enum;

namespace UpvestInvestmentApi.Models.Enums;

/// <summary>
/// Final status of the Guardian check.
/// * IN_PROGRESS - Guardian check is in progress
/// * PASSED - Guardian check passed
/// * FAILED - Guardian check failed
/// </summary>
[JsonConverter(typeof(StringEnumConverter<Status10>))]
public sealed record Status10 : OpenStringEnum<Status10>
{
    private Status10(string value) : base(value)
    {
    }

    public static readonly Status10 InProgress = new("IN_PROGRESS");

    public static readonly Status10 Passed = new("PASSED");

    public static readonly Status10 Failed = new("FAILED");

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
