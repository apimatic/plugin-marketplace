using System;
using System.Text.Json.Serialization;
using UpvestInvestmentApi.Core.Enum;

namespace UpvestInvestmentApi.Models.Enums;

/// <summary>
/// Explains the reason why the savings plan execution was cancelled .
/// * CANCELLED_BY_CLIENT: The savings plan execution was cancelled by the client.
/// * CANCELLED_BY_UPVEST: The savings plan execution was cancelled by Upvest.
/// </summary>
[JsonConverter(typeof(StringEnumConverter<CancellationReasonCodeForSavingsPlanExecution>))]
public sealed record CancellationReasonCodeForSavingsPlanExecution : OpenStringEnum<CancellationReasonCodeForSavingsPlanExecution>
{
    private CancellationReasonCodeForSavingsPlanExecution(string value) : base(value)
    {
    }

    public static readonly CancellationReasonCodeForSavingsPlanExecution CancelledByClient = new("CANCELLED_BY_CLIENT");

    public static readonly CancellationReasonCodeForSavingsPlanExecution CancelledByUpvest = new("CANCELLED_BY_UPVEST");

    public TResult Match<TResult>(Func<TResult> onCancelledByClient,
        Func<TResult> onCancelledByUpvest,
        Func<string, TResult> otherwise) =>
        this switch
        {
            _ when this == CancelledByClient => onCancelledByClient(),
            _ when this == CancelledByUpvest => onCancelledByUpvest(),
            _ => otherwise(Value)
        };

    public void Match(Action onCancelledByClient, Action onCancelledByUpvest, Action<string> otherwise)
    {
        if (this == CancelledByClient) onCancelledByClient();
        else if (this == CancelledByUpvest) onCancelledByUpvest();
        else otherwise(Value);
    }
}
