using System;
using System.Text.Json.Serialization;
using UpvestInvestmentApi.Core.Enum;

namespace UpvestInvestmentApi.Models.Enums;

/// <summary>
/// Report reference type
/// * CORPORATE_ACTION_TRANSACTION_ID - Corporate action transaction identifier
/// * ACCOUNT_GROUP_ID - Account group identifier
/// * ACCOUNT_ID - Account identifier
/// * ORDER_ID - Order identifier
/// </summary>
[JsonConverter(typeof(StringEnumConverter<ReportReferenceType>))]
public sealed record ReportReferenceType : OpenStringEnum<ReportReferenceType>
{
    private ReportReferenceType(string value) : base(value)
    {
    }

    public static readonly ReportReferenceType CorporateActionTransactionId = new("CORPORATE_ACTION_TRANSACTION_ID");

    public static readonly ReportReferenceType AccountGroupId = new("ACCOUNT_GROUP_ID");

    public static readonly ReportReferenceType AccountId = new("ACCOUNT_ID");

    public static readonly ReportReferenceType OrderId = new("ORDER_ID");

    public TResult Match<TResult>(Func<TResult> onCorporateActionTransactionId,
        Func<TResult> onAccountGroupId,
        Func<TResult> onAccountId,
        Func<TResult> onOrderId,
        Func<string, TResult> otherwise) =>
        this switch
        {
            _ when this == CorporateActionTransactionId => onCorporateActionTransactionId(),
            _ when this == AccountGroupId => onAccountGroupId(),
            _ when this == AccountId => onAccountId(),
            _ when this == OrderId => onOrderId(),
            _ => otherwise(Value)
        };

    public void Match(Action onCorporateActionTransactionId,
        Action onAccountGroupId,
        Action onAccountId,
        Action onOrderId,
        Action<string> otherwise)
    {
        if (this == CorporateActionTransactionId) onCorporateActionTransactionId();
        else if (this == AccountGroupId) onAccountGroupId();
        else if (this == AccountId) onAccountId();
        else if (this == OrderId) onOrderId();
        else otherwise(Value);
    }
}
