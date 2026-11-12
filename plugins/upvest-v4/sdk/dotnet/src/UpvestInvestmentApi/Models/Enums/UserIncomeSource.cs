using System;
using System.Text.Json.Serialization;
using UpvestInvestmentApi.Core.Enum;

namespace UpvestInvestmentApi.Models.Enums;

/// <summary>
/// Source of user's income.
/// </summary>
[JsonConverter(typeof(StringEnumConverter<UserIncomeSource>))]
public sealed record UserIncomeSource : OpenStringEnum<UserIncomeSource>
{
    private UserIncomeSource(string value) : base(value)
    {
    }

    public static readonly UserIncomeSource EmploymentIncome = new("EMPLOYMENT_INCOME");

    public static readonly UserIncomeSource CapitalGainsSavingsAndInvestments = new(
        "CAPITAL_GAINS_SAVINGS_AND_INVESTMENTS");

    public static readonly UserIncomeSource Inheritance = new("INHERITANCE");

    public static readonly UserIncomeSource SelfEmployment = new("SELF_EMPLOYMENT");

    public static readonly UserIncomeSource RealEstateSaleRental = new("REAL_ESTATE_SALE_RENTAL");

    public static readonly UserIncomeSource Donations = new("DONATIONS");

    public static readonly UserIncomeSource BusinessEnterpriseRevenue = new("BUSINESS_ENTERPRISE_REVENUE");

    public static readonly UserIncomeSource GovernmentOrSocialBenefits = new("GOVERNMENT_OR_SOCIAL_BENEFITS");

    public static readonly UserIncomeSource PensionRetirementFunds = new("PENSION_RETIREMENT_FUNDS");

    public static readonly UserIncomeSource SoleTrader = new("SOLE_TRADER");

    public static readonly UserIncomeSource Other = new("OTHER");

    public static readonly UserIncomeSource None = new("NONE");

    public TResult Match<TResult>(Func<TResult> onEmploymentIncome,
        Func<TResult> onCapitalGainsSavingsAndInvestments,
        Func<TResult> onInheritance,
        Func<TResult> onSelfEmployment,
        Func<TResult> onRealEstateSaleRental,
        Func<TResult> onDonations,
        Func<TResult> onBusinessEnterpriseRevenue,
        Func<TResult> onGovernmentOrSocialBenefits,
        Func<TResult> onPensionRetirementFunds,
        Func<TResult> onSoleTrader,
        Func<TResult> onOther,
        Func<TResult> onNone,
        Func<string, TResult> otherwise) =>
        this switch
        {
            _ when this == EmploymentIncome => onEmploymentIncome(),
            _ when this == CapitalGainsSavingsAndInvestments => onCapitalGainsSavingsAndInvestments(),
            _ when this == Inheritance => onInheritance(),
            _ when this == SelfEmployment => onSelfEmployment(),
            _ when this == RealEstateSaleRental => onRealEstateSaleRental(),
            _ when this == Donations => onDonations(),
            _ when this == BusinessEnterpriseRevenue => onBusinessEnterpriseRevenue(),
            _ when this == GovernmentOrSocialBenefits => onGovernmentOrSocialBenefits(),
            _ when this == PensionRetirementFunds => onPensionRetirementFunds(),
            _ when this == SoleTrader => onSoleTrader(),
            _ when this == Other => onOther(),
            _ when this == None => onNone(),
            _ => otherwise(Value)
        };

    public void Match(Action onEmploymentIncome,
        Action onCapitalGainsSavingsAndInvestments,
        Action onInheritance,
        Action onSelfEmployment,
        Action onRealEstateSaleRental,
        Action onDonations,
        Action onBusinessEnterpriseRevenue,
        Action onGovernmentOrSocialBenefits,
        Action onPensionRetirementFunds,
        Action onSoleTrader,
        Action onOther,
        Action onNone,
        Action<string> otherwise)
    {
        if (this == EmploymentIncome) onEmploymentIncome();
        else if (this == CapitalGainsSavingsAndInvestments) onCapitalGainsSavingsAndInvestments();
        else if (this == Inheritance) onInheritance();
        else if (this == SelfEmployment) onSelfEmployment();
        else if (this == RealEstateSaleRental) onRealEstateSaleRental();
        else if (this == Donations) onDonations();
        else if (this == BusinessEnterpriseRevenue) onBusinessEnterpriseRevenue();
        else if (this == GovernmentOrSocialBenefits) onGovernmentOrSocialBenefits();
        else if (this == PensionRetirementFunds) onPensionRetirementFunds();
        else if (this == SoleTrader) onSoleTrader();
        else if (this == Other) onOther();
        else if (this == None) onNone();
        else otherwise(Value);
    }
}
