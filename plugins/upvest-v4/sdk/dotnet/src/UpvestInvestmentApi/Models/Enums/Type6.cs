using System;
using System.Text.Json.Serialization;
using UpvestInvestmentApi.Core.Enum;

namespace UpvestInvestmentApi.Models.Enums;

[JsonConverter(typeof(StringEnumConverter<Type6>))]
public sealed record Type6 : OpenStringEnum<Type6>
{
    private Type6(string value) : base(value)
    {
    }

    public static readonly Type6 Kyc = new("KYC");

    public static readonly Type6 InstrumentFit = new("INSTRUMENT_FIT");

    public static readonly Type6 Por = new("POR");

    public static readonly Type6 Compliance = new("COMPLIANCE");

    public static readonly Type6 Guardian = new("GUARDIAN");

    public static readonly Type6 UserSelfAssessment = new("USER_SELF_ASSESSMENT");

    public static readonly Type6 UsWithholdingTaxStatus = new("US_WITHHOLDING_TAX_STATUS");

    public TResult Match<TResult>(Func<TResult> onKyc,
        Func<TResult> onInstrumentFit,
        Func<TResult> onPor,
        Func<TResult> onCompliance,
        Func<TResult> onGuardian,
        Func<TResult> onUserSelfAssessment,
        Func<TResult> onUsWithholdingTaxStatus,
        Func<string, TResult> otherwise) =>
        this switch
        {
            _ when this == Kyc => onKyc(),
            _ when this == InstrumentFit => onInstrumentFit(),
            _ when this == Por => onPor(),
            _ when this == Compliance => onCompliance(),
            _ when this == Guardian => onGuardian(),
            _ when this == UserSelfAssessment => onUserSelfAssessment(),
            _ when this == UsWithholdingTaxStatus => onUsWithholdingTaxStatus(),
            _ => otherwise(Value)
        };

    public void Match(Action onKyc,
        Action onInstrumentFit,
        Action onPor,
        Action onCompliance,
        Action onGuardian,
        Action onUserSelfAssessment,
        Action onUsWithholdingTaxStatus,
        Action<string> otherwise)
    {
        if (this == Kyc) onKyc();
        else if (this == InstrumentFit) onInstrumentFit();
        else if (this == Por) onPor();
        else if (this == Compliance) onCompliance();
        else if (this == Guardian) onGuardian();
        else if (this == UserSelfAssessment) onUserSelfAssessment();
        else if (this == UsWithholdingTaxStatus) onUsWithholdingTaxStatus();
        else otherwise(Value);
    }
}
