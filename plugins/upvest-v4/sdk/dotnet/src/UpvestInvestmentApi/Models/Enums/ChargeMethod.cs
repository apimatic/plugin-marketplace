using System;
using System.Text.Json.Serialization;
using UpvestInvestmentApi.Core.Enum;

namespace UpvestInvestmentApi.Models.Enums;

/// <summary>
/// How the fee was charged.
/// * CHARGED_BY_CLIENT — Charged by client.
/// * COLLECTED_BY_UPVEST — Charged by client and collected by Upvest.
/// * CHARGED_BY_CLIENT_NET — Charged and collected by client; the fee is deducted from the transaction amount.
/// </summary>
[JsonConverter(typeof(StringEnumConverter<ChargeMethod>))]
public sealed record ChargeMethod : OpenStringEnum<ChargeMethod>
{
    private ChargeMethod(string value) : base(value)
    {
    }

    public static readonly ChargeMethod ChargedByClient = new("CHARGED_BY_CLIENT");

    public static readonly ChargeMethod CollectedByUpvest = new("COLLECTED_BY_UPVEST");

    public static readonly ChargeMethod ChargedByClientNet = new("CHARGED_BY_CLIENT_NET");

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
