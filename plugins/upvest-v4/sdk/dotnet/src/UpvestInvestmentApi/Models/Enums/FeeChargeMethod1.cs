using System;
using System.Text.Json.Serialization;
using UpvestInvestmentApi.Core.Enum;

namespace UpvestInvestmentApi.Models.Enums;

/// <summary>
/// Indicates how the transaction fee is charged.
/// * <c>CHARGED_BY_CLIENT</c> — The fee is charged by the client as part of post-trade settlement; the fee movement occurs outside Upvest cash balances.
/// * <c>COLLECTED_BY_UPVEST</c> — The fee is charged by the client and collected by Upvest; the fee amount is debited from the user's Upvest cash balance.
/// * <c>CHARGED_BY_CLIENT_NET</c> — The fee is charged and collected by the client; the fee amount is deducted from the transaction amount, so the user's Upvest cash balance changes by the net amount.
/// </summary>
[JsonConverter(typeof(StringEnumConverter<FeeChargeMethod1>))]
public sealed record FeeChargeMethod1 : OpenStringEnum<FeeChargeMethod1>
{
    private FeeChargeMethod1(string value) : base(value)
    {
    }

    public static readonly FeeChargeMethod1 ChargedByClient = new("CHARGED_BY_CLIENT");

    public static readonly FeeChargeMethod1 CollectedByUpvest = new("COLLECTED_BY_UPVEST");

    public static readonly FeeChargeMethod1 ChargedByClientNet = new("CHARGED_BY_CLIENT_NET");

    public TResult Match<TResult>(Func<TResult> onChargedByClient,
        Func<TResult> onCollectedByUpvest,
        Func<TResult> onChargedByClientNet,
        Func<string, TResult> otherwise) =>
        this switch
        {
            _ when this == ChargedByClient => onChargedByClient(),
            _ when this == CollectedByUpvest => onCollectedByUpvest(),
            _ when this == ChargedByClientNet => onChargedByClientNet(),
            _ => otherwise(Value)
        };

    public void Match(Action onChargedByClient,
        Action onCollectedByUpvest,
        Action onChargedByClientNet,
        Action<string> otherwise)
    {
        if (this == ChargedByClient) onChargedByClient();
        else if (this == CollectedByUpvest) onCollectedByUpvest();
        else if (this == ChargedByClientNet) onChargedByClientNet();
        else otherwise(Value);
    }
}
