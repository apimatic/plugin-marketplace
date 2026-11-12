using System;
using System.Text.Json.Serialization;
using UpvestInvestmentApi.Core.Enum;

namespace UpvestInvestmentApi.Models.Enums;

[JsonConverter(typeof(StringEnumConverter<ClosureReason>))]
public sealed record ClosureReason : OpenStringEnum<ClosureReason>
{
    private ClosureReason(string value) : base(value)
    {
    }

    public static readonly ClosureReason Dunning = new("dunning");

    public static readonly ClosureReason PowerOfAttorney = new("power_of_attorney");

    public static readonly ClosureReason LossOfLegalCapacity = new("loss_of_legal_capacity");

    public static readonly ClosureReason Aml = new("aml");

    public static readonly ClosureReason RiskBased = new("risk_based");

    public static readonly ClosureReason ContractBreach = new("contract_breach");

    public static readonly ClosureReason UserInitiated = new("user_initiated");

    public TResult Match<TResult>(Func<TResult> onDunning,
        Func<TResult> onPowerOfAttorney,
        Func<TResult> onLossOfLegalCapacity,
        Func<TResult> onAml,
        Func<TResult> onRiskBased,
        Func<TResult> onContractBreach,
        Func<TResult> onUserInitiated,
        Func<string, TResult> otherwise) =>
        this switch
        {
            _ when this == Dunning => onDunning(),
            _ when this == PowerOfAttorney => onPowerOfAttorney(),
            _ when this == LossOfLegalCapacity => onLossOfLegalCapacity(),
            _ when this == Aml => onAml(),
            _ when this == RiskBased => onRiskBased(),
            _ when this == ContractBreach => onContractBreach(),
            _ when this == UserInitiated => onUserInitiated(),
            _ => otherwise(Value)
        };

    public void Match(Action onDunning,
        Action onPowerOfAttorney,
        Action onLossOfLegalCapacity,
        Action onAml,
        Action onRiskBased,
        Action onContractBreach,
        Action onUserInitiated,
        Action<string> otherwise)
    {
        if (this == Dunning) onDunning();
        else if (this == PowerOfAttorney) onPowerOfAttorney();
        else if (this == LossOfLegalCapacity) onLossOfLegalCapacity();
        else if (this == Aml) onAml();
        else if (this == RiskBased) onRiskBased();
        else if (this == ContractBreach) onContractBreach();
        else if (this == UserInitiated) onUserInitiated();
        else otherwise(Value);
    }
}
