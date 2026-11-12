using System;
using System.Text.Json.Serialization;
using UpvestInvestmentApi.Core.Enum;

namespace UpvestInvestmentApi.Models.Enums;

/// <summary>
/// The kind of tax this component represents.
/// * CAPITAL_GAINS — Capital gains tax.
/// * CHURCH_TAX — German church tax (Kirchensteuer).
/// * SOLIDARITY_SURCHARGE — German solidarity surcharge (Solidaritätszuschlag).
/// * FINANCIAL_TRANSACTION_TAX — Financial transaction tax.
/// * STAMP_DUTY — Stamp duty.
/// * INTERNATIONAL_WITHHOLDING_TAX — Withholding tax levied in another jurisdiction.
/// </summary>
[JsonConverter(typeof(StringEnumConverter<Type49>))]
public sealed record Type49 : OpenStringEnum<Type49>
{
    private Type49(string value) : base(value)
    {
    }

    public static readonly Type49 CapitalGains = new("CAPITAL_GAINS");

    public static readonly Type49 ChurchTax = new("CHURCH_TAX");

    public static readonly Type49 SolidaritySurcharge = new("SOLIDARITY_SURCHARGE");

    public static readonly Type49 FinancialTransactionTax = new("FINANCIAL_TRANSACTION_TAX");

    public static readonly Type49 StampDuty = new("STAMP_DUTY");

    public static readonly Type49 InternationalWithholdingTax = new("INTERNATIONAL_WITHHOLDING_TAX");

    public TResult Match<TResult>(Func<TResult> onCapitalGains,
        Func<TResult> onChurchTax,
        Func<TResult> onSolidaritySurcharge,
        Func<TResult> onFinancialTransactionTax,
        Func<TResult> onStampDuty,
        Func<TResult> onInternationalWithholdingTax,
        Func<string, TResult> otherwise) =>
        this switch
        {
            _ when this == CapitalGains => onCapitalGains(),
            _ when this == ChurchTax => onChurchTax(),
            _ when this == SolidaritySurcharge => onSolidaritySurcharge(),
            _ when this == FinancialTransactionTax => onFinancialTransactionTax(),
            _ when this == StampDuty => onStampDuty(),
            _ when this == InternationalWithholdingTax => onInternationalWithholdingTax(),
            _ => otherwise(Value)
        };

    public void Match(Action onCapitalGains,
        Action onChurchTax,
        Action onSolidaritySurcharge,
        Action onFinancialTransactionTax,
        Action onStampDuty,
        Action onInternationalWithholdingTax,
        Action<string> otherwise)
    {
        if (this == CapitalGains) onCapitalGains();
        else if (this == ChurchTax) onChurchTax();
        else if (this == SolidaritySurcharge) onSolidaritySurcharge();
        else if (this == FinancialTransactionTax) onFinancialTransactionTax();
        else if (this == StampDuty) onStampDuty();
        else if (this == InternationalWithholdingTax) onInternationalWithholdingTax();
        else otherwise(Value);
    }
}
