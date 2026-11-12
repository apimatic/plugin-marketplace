using System;
using System.Text.Json.Serialization;
using UpvestInvestmentApi.Core.Enum;

namespace UpvestInvestmentApi.Models.Enums;

/// <summary>
/// Report type
/// * CORPORATE_ACTION_CASH_TRANSACTION - cash transaction document (after corporate action)
/// * CORPORATE_ACTION_SECURITY_TRANSACTION - security transaction document (after corporate action)
/// </summary>
[JsonConverter(typeof(StringEnumConverter<ReportTypeCorporateAction>))]
public sealed record ReportTypeCorporateAction : OpenStringEnum<ReportTypeCorporateAction>
{
    private ReportTypeCorporateAction(string value) : base(value)
    {
    }

    public static readonly ReportTypeCorporateAction CorporateActionCashTransaction = new(
        "CORPORATE_ACTION_CASH_TRANSACTION");

    public static readonly ReportTypeCorporateAction CorporateActionSecurityTransaction = new(
        "CORPORATE_ACTION_SECURITY_TRANSACTION");

    public TResult Match<TResult>(Func<TResult> onCorporateActionCashTransaction,
        Func<TResult> onCorporateActionSecurityTransaction,
        Func<string, TResult> otherwise) =>
        this switch
        {
            _ when this == CorporateActionCashTransaction => onCorporateActionCashTransaction(),
            _ when this == CorporateActionSecurityTransaction => onCorporateActionSecurityTransaction(),
            _ => otherwise(Value)
        };

    public void Match(Action onCorporateActionCashTransaction,
        Action onCorporateActionSecurityTransaction,
        Action<string> otherwise)
    {
        if (this == CorporateActionCashTransaction) onCorporateActionCashTransaction();
        else if (this == CorporateActionSecurityTransaction) onCorporateActionSecurityTransaction();
        else otherwise(Value);
    }
}
