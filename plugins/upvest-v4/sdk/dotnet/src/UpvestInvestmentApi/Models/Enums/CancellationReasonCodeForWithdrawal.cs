using System;
using System.Text.Json.Serialization;
using UpvestInvestmentApi.Core.Enum;

namespace UpvestInvestmentApi.Models.Enums;

/// <summary>
/// Reason the withdrawal was cancelled. The field is present in case the withdrawal has a status of CANCELLED.
/// * CANCELLED_BY_BANK - The payment was not completed by your bank. Please check your account details or contact support.
/// * CANCELLED_BY_UPVEST - The payment was cancelled. Contact support for details.
/// * CANCELLED_BY_CLIENT - The payment was cancelled at your request.
/// * OTHER - Reason not available (applies to historical data only).
/// </summary>
[JsonConverter(typeof(StringEnumConverter<CancellationReasonCodeForWithdrawal>))]
public sealed record CancellationReasonCodeForWithdrawal : OpenStringEnum<CancellationReasonCodeForWithdrawal>
{
    private CancellationReasonCodeForWithdrawal(string value) : base(value)
    {
    }

    public static readonly CancellationReasonCodeForWithdrawal CancelledByBank = new("CANCELLED_BY_BANK");

    public static readonly CancellationReasonCodeForWithdrawal CancelledByUpvest = new("CANCELLED_BY_UPVEST");

    public static readonly CancellationReasonCodeForWithdrawal CancelledByClient = new("CANCELLED_BY_CLIENT");

    public static readonly CancellationReasonCodeForWithdrawal Other = new("OTHER");

    public TResult Match<TResult>(Func<TResult> onCancelledByBank,
        Func<TResult> onCancelledByUpvest,
        Func<TResult> onCancelledByClient,
        Func<TResult> onOther,
        Func<string, TResult> otherwise) =>
        this switch
        {
            _ when this == CancelledByBank => onCancelledByBank(),
            _ when this == CancelledByUpvest => onCancelledByUpvest(),
            _ when this == CancelledByClient => onCancelledByClient(),
            _ when this == Other => onOther(),
            _ => otherwise(Value)
        };

    public void Match(Action onCancelledByBank,
        Action onCancelledByUpvest,
        Action onCancelledByClient,
        Action onOther,
        Action<string> otherwise)
    {
        if (this == CancelledByBank) onCancelledByBank();
        else if (this == CancelledByUpvest) onCancelledByUpvest();
        else if (this == CancelledByClient) onCancelledByClient();
        else if (this == Other) onOther();
        else otherwise(Value);
    }
}
