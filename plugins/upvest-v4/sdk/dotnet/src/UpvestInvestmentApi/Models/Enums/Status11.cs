using System;
using System.Text.Json.Serialization;
using UpvestInvestmentApi.Core.Enum;

namespace UpvestInvestmentApi.Models.Enums;

/// <summary>
/// Final status of the US Withholding Tax Status check.
/// * IN_PROGRESS - US Withholding Tax Status check is in progress
/// * PASSED - US Withholding Tax Status check passed
/// * FAILED - US Withholding Tax Status check failed
/// <para>
/// A documented status ("KYC", "W8-BEN" or "W9") is corroborated against the user's tax residency: it fails when the declared <c>person_type</c> contradicts the tax residency Upvest holds for the user, or when the user has no active tax residency on record. An "UNDOCUMENTED" status is recorded as declared and is not corroborated against tax residency.
/// </para>
/// </summary>
[JsonConverter(typeof(StringEnumConverter<Status11>))]
public sealed record Status11 : OpenStringEnum<Status11>
{
    private Status11(string value) : base(value)
    {
    }

    public static readonly Status11 InProgress = new("IN_PROGRESS");

    public static readonly Status11 Passed = new("PASSED");

    public static readonly Status11 Failed = new("FAILED");

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
