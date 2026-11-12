using System;
using System.Text.Json.Serialization;
using UpvestInvestmentApi.Core.Enum;

namespace UpvestInvestmentApi.Models.Enums;

/// <summary>
/// Reason for Rebalancing Execution Order Cancellation. The field is present in case the Order has a status of CANCELLED.
/// * ACCOUNT_IS_EMPTY -
/// * ACCOUNT_NOT_FOUND -
/// * CANCELLED_BY_CLIENT -
/// * CANCELLED_BY_UPVEST -
/// * CONFIGURATION_IS_MISSING -
/// * INVALID_ACCOUNT_TYPE -
/// * PORTFOLIO_IS_BALANCED -
/// * UNKNOWN -
/// </summary>
[JsonConverter(typeof(StringEnumConverter<CancellationReason3>))]
public sealed record CancellationReason3 : OpenStringEnum<CancellationReason3>
{
    private CancellationReason3(string value) : base(value)
    {
    }

    public static readonly CancellationReason3 AccountIsEmpty = new("ACCOUNT_IS_EMPTY");

    public static readonly CancellationReason3 AccountNotFound = new("ACCOUNT_NOT_FOUND");

    public static readonly CancellationReason3 CancelledByClient = new("CANCELLED_BY_CLIENT");

    public static readonly CancellationReason3 CancelledByUpvest = new("CANCELLED_BY_UPVEST");

    public static readonly CancellationReason3 ConfigurationIsMissing = new("CONFIGURATION_IS_MISSING");

    public static readonly CancellationReason3 InvalidAccountType = new("INVALID_ACCOUNT_TYPE");

    public static readonly CancellationReason3 PortfolioIsBalanced = new("PORTFOLIO_IS_BALANCED");

    public static readonly CancellationReason3 Unknown = new("UNKNOWN");

    public TResult Match<TResult>(Func<TResult> onAccountIsEmpty,
        Func<TResult> onAccountNotFound,
        Func<TResult> onCancelledByClient,
        Func<TResult> onCancelledByUpvest,
        Func<TResult> onConfigurationIsMissing,
        Func<TResult> onInvalidAccountType,
        Func<TResult> onPortfolioIsBalanced,
        Func<TResult> onUnknown,
        Func<string, TResult> otherwise) =>
        this switch
        {
            _ when this == AccountIsEmpty => onAccountIsEmpty(),
            _ when this == AccountNotFound => onAccountNotFound(),
            _ when this == CancelledByClient => onCancelledByClient(),
            _ when this == CancelledByUpvest => onCancelledByUpvest(),
            _ when this == ConfigurationIsMissing => onConfigurationIsMissing(),
            _ when this == InvalidAccountType => onInvalidAccountType(),
            _ when this == PortfolioIsBalanced => onPortfolioIsBalanced(),
            _ when this == Unknown => onUnknown(),
            _ => otherwise(Value)
        };

    public void Match(Action onAccountIsEmpty,
        Action onAccountNotFound,
        Action onCancelledByClient,
        Action onCancelledByUpvest,
        Action onConfigurationIsMissing,
        Action onInvalidAccountType,
        Action onPortfolioIsBalanced,
        Action onUnknown,
        Action<string> otherwise)
    {
        if (this == AccountIsEmpty) onAccountIsEmpty();
        else if (this == AccountNotFound) onAccountNotFound();
        else if (this == CancelledByClient) onCancelledByClient();
        else if (this == CancelledByUpvest) onCancelledByUpvest();
        else if (this == ConfigurationIsMissing) onConfigurationIsMissing();
        else if (this == InvalidAccountType) onInvalidAccountType();
        else if (this == PortfolioIsBalanced) onPortfolioIsBalanced();
        else if (this == Unknown) onUnknown();
        else otherwise(Value);
    }
}
