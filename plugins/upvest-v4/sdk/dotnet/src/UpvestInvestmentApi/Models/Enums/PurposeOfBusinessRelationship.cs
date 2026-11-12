using System;
using System.Text.Json.Serialization;
using UpvestInvestmentApi.Core.Enum;

namespace UpvestInvestmentApi.Models.Enums;

/// <summary>
/// The purpose of the business relationship.
/// </summary>
[JsonConverter(typeof(StringEnumConverter<PurposeOfBusinessRelationship>))]
public sealed record PurposeOfBusinessRelationship : OpenStringEnum<PurposeOfBusinessRelationship>
{
    private PurposeOfBusinessRelationship(string value) : base(value)
    {
    }

    public static readonly PurposeOfBusinessRelationship WealthGrowth = new("WEALTH_GROWTH");

    public static readonly PurposeOfBusinessRelationship TreasuryLiquidityManagement = new(
        "TREASURY_LIQUIDITY_MANAGEMENT");

    public static readonly PurposeOfBusinessRelationship HedgingRiskManagement = new("HEDGING_RISK_MANAGEMENT");

    public static readonly PurposeOfBusinessRelationship EmployeeBenefitFunding = new("EMPLOYEE_BENEFIT_FUNDING");

    public static readonly PurposeOfBusinessRelationship StrategicInvestment = new("STRATEGIC_INVESTMENT");

    public TResult Match<TResult>(Func<TResult> onWealthGrowth,
        Func<TResult> onTreasuryLiquidityManagement,
        Func<TResult> onHedgingRiskManagement,
        Func<TResult> onEmployeeBenefitFunding,
        Func<TResult> onStrategicInvestment,
        Func<string, TResult> otherwise) =>
        this switch
        {
            _ when this == WealthGrowth => onWealthGrowth(),
            _ when this == TreasuryLiquidityManagement => onTreasuryLiquidityManagement(),
            _ when this == HedgingRiskManagement => onHedgingRiskManagement(),
            _ when this == EmployeeBenefitFunding => onEmployeeBenefitFunding(),
            _ when this == StrategicInvestment => onStrategicInvestment(),
            _ => otherwise(Value)
        };

    public void Match(Action onWealthGrowth,
        Action onTreasuryLiquidityManagement,
        Action onHedgingRiskManagement,
        Action onEmployeeBenefitFunding,
        Action onStrategicInvestment,
        Action<string> otherwise)
    {
        if (this == WealthGrowth) onWealthGrowth();
        else if (this == TreasuryLiquidityManagement) onTreasuryLiquidityManagement();
        else if (this == HedgingRiskManagement) onHedgingRiskManagement();
        else if (this == EmployeeBenefitFunding) onEmployeeBenefitFunding();
        else if (this == StrategicInvestment) onStrategicInvestment();
        else otherwise(Value);
    }
}
