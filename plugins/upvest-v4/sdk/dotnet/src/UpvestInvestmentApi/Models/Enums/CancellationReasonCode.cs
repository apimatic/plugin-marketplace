using System;
using System.Text.Json.Serialization;
using UpvestInvestmentApi.Core.Enum;

namespace UpvestInvestmentApi.Models.Enums;

/// <summary>
/// Explains the reason why the order was cancelled .
/// * ACCOUNT_IS_EMPTY -
/// * CANCELLED_BY_CLIENT -
/// * CANCELLED_BY_UPVEST -
/// * PORTFOLIO_IS_BALANCED -
/// * SELL_LIMIT_EXCEEDED -
/// </summary>
[JsonConverter(typeof(StringEnumConverter<CancellationReasonCode>))]
public sealed record CancellationReasonCode : OpenStringEnum<CancellationReasonCode>
{
    private CancellationReasonCode(string value) : base(value)
    {
    }

    public static readonly CancellationReasonCode AccountIsEmpty = new("ACCOUNT_IS_EMPTY");

    public static readonly CancellationReasonCode CancelledByClient = new("CANCELLED_BY_CLIENT");

    public static readonly CancellationReasonCode CancelledByUpvest = new("CANCELLED_BY_UPVEST");

    public static readonly CancellationReasonCode PortfolioIsBalanced = new("PORTFOLIO_IS_BALANCED");

    public static readonly CancellationReasonCode SellLimitExceeded = new("SELL_LIMIT_EXCEEDED");

    public TResult Match<TResult>(Func<TResult> onAccountIsEmpty,
        Func<TResult> onCancelledByClient,
        Func<TResult> onCancelledByUpvest,
        Func<TResult> onPortfolioIsBalanced,
        Func<TResult> onSellLimitExceeded,
        Func<string, TResult> otherwise) =>
        this switch
        {
            _ when this == AccountIsEmpty => onAccountIsEmpty(),
            _ when this == CancelledByClient => onCancelledByClient(),
            _ when this == CancelledByUpvest => onCancelledByUpvest(),
            _ when this == PortfolioIsBalanced => onPortfolioIsBalanced(),
            _ when this == SellLimitExceeded => onSellLimitExceeded(),
            _ => otherwise(Value)
        };

    public void Match(Action onAccountIsEmpty,
        Action onCancelledByClient,
        Action onCancelledByUpvest,
        Action onPortfolioIsBalanced,
        Action onSellLimitExceeded,
        Action<string> otherwise)
    {
        if (this == AccountIsEmpty) onAccountIsEmpty();
        else if (this == CancelledByClient) onCancelledByClient();
        else if (this == CancelledByUpvest) onCancelledByUpvest();
        else if (this == PortfolioIsBalanced) onPortfolioIsBalanced();
        else if (this == SellLimitExceeded) onSellLimitExceeded();
        else otherwise(Value);
    }
}
