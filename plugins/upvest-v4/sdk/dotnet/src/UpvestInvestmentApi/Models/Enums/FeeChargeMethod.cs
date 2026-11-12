using System;
using System.Text.Json.Serialization;
using UpvestInvestmentApi.Core.Enum;

namespace UpvestInvestmentApi.Models.Enums;

/// <summary>
/// Indicates whether the fee will be charged by client or by other methods.
/// * CHARGED_BY_CLIENT -
/// * COLLECTED_BY_UPVEST -
/// </summary>
[JsonConverter(typeof(StringEnumConverter<FeeChargeMethod>))]
public sealed record FeeChargeMethod : OpenStringEnum<FeeChargeMethod>
{
    private FeeChargeMethod(string value) : base(value)
    {
    }

    public static readonly FeeChargeMethod ChargedByClient = new("CHARGED_BY_CLIENT");

    public static readonly FeeChargeMethod CollectedByUpvest = new("COLLECTED_BY_UPVEST");

    public TResult Match<TResult>(Func<TResult> onChargedByClient,
        Func<TResult> onCollectedByUpvest,
        Func<string, TResult> otherwise) =>
        this switch
        {
            _ when this == ChargedByClient => onChargedByClient(),
            _ when this == CollectedByUpvest => onCollectedByUpvest(),
            _ => otherwise(Value)
        };

    public void Match(Action onChargedByClient, Action onCollectedByUpvest, Action<string> otherwise)
    {
        if (this == ChargedByClient) onChargedByClient();
        else if (this == CollectedByUpvest) onCollectedByUpvest();
        else otherwise(Value);
    }
}
