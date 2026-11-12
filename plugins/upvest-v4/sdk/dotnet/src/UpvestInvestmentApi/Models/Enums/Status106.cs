using System;
using System.Text.Json.Serialization;
using UpvestInvestmentApi.Core.Enum;

namespace UpvestInvestmentApi.Models.Enums;

/// <summary>
/// Final status of the business check.
/// * IN_PROGRESS - Check is in progress
/// * PASSED - Check passed
/// * FAILED - Check failed
/// </summary>
[JsonConverter(typeof(StringEnumConverter<Status106>))]
public sealed record Status106 : OpenStringEnum<Status106>
{
    private Status106(string value) : base(value)
    {
    }

    public static readonly Status106 InProgress = new("IN_PROGRESS");

    public static readonly Status106 Passed = new("PASSED");

    public static readonly Status106 Failed = new("FAILED");

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
