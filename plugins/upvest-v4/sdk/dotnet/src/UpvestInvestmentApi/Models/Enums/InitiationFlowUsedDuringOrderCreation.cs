using System;
using System.Text.Json.Serialization;
using UpvestInvestmentApi.Core.Enum;

namespace UpvestInvestmentApi.Models.Enums;

/// <summary>
/// Identifies what triggered the portfolio order.
/// * API — initiated directly via the client API.
/// * SAVINGS_PLAN — initiated by a savings plan execution.
/// * AUTO_INVESTMENT — initiated automatically by auto-investment to invest incoming cash.
/// </summary>
[JsonConverter(typeof(StringEnumConverter<InitiationFlowUsedDuringOrderCreation>))]
public sealed record InitiationFlowUsedDuringOrderCreation : OpenStringEnum<InitiationFlowUsedDuringOrderCreation>
{
    private InitiationFlowUsedDuringOrderCreation(string value) : base(value)
    {
    }

    public static readonly InitiationFlowUsedDuringOrderCreation Api = new("API");

    public static readonly InitiationFlowUsedDuringOrderCreation SavingsPlan = new("SAVINGS_PLAN");

    public static readonly InitiationFlowUsedDuringOrderCreation AutoInvestment = new("AUTO_INVESTMENT");

    public TResult Match<TResult>(Func<TResult> onApi,
        Func<TResult> onSavingsPlan,
        Func<TResult> onAutoInvestment,
        Func<string, TResult> otherwise) =>
        this switch
        {
            _ when this == Api => onApi(),
            _ when this == SavingsPlan => onSavingsPlan(),
            _ when this == AutoInvestment => onAutoInvestment(),
            _ => otherwise(Value)
        };

    public void Match(Action onApi, Action onSavingsPlan, Action onAutoInvestment, Action<string> otherwise)
    {
        if (this == Api) onApi();
        else if (this == SavingsPlan) onSavingsPlan();
        else if (this == AutoInvestment) onAutoInvestment();
        else otherwise(Value);
    }
}
