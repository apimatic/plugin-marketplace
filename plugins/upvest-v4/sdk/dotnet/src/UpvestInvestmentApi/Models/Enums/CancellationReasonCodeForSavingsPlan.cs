using System;
using System.Text.Json.Serialization;
using UpvestInvestmentApi.Core.Enum;

namespace UpvestInvestmentApi.Models.Enums;

/// <summary>
/// Explains the reason why the savings plan was cancelled .
/// * CANCELLED_BY_CLIENT: The savings plan was cancelled by the client.
/// * CANCELLED_BY_UPVEST: The savings plan was cancelled by Upvest.
/// </summary>
[JsonConverter(typeof(StringEnumConverter<CancellationReasonCodeForSavingsPlan>))]
public sealed record CancellationReasonCodeForSavingsPlan : OpenStringEnum<CancellationReasonCodeForSavingsPlan>
{
    private CancellationReasonCodeForSavingsPlan(string value) : base(value)
    {
    }

    public static readonly CancellationReasonCodeForSavingsPlan CancelledByClient = new("CANCELLED_BY_CLIENT");

    public static readonly CancellationReasonCodeForSavingsPlan CancelledByUpvest = new("CANCELLED_BY_UPVEST");

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
