using System;
using System.Text.Json.Serialization;
using UpvestInvestmentApi.Core.Enum;

namespace UpvestInvestmentApi.Models.Enums;

/// <summary>
/// The kind of resource that this reference points to.
/// * ORDER — Order.
/// * ORDER_EXECUTION — Order execution.
/// * CORPORATE_ACTION — Corporate action.
/// * CORPORATE_ACTION_TRANSACTION_ID — Corporate action transaction ID.
/// </summary>
[JsonConverter(typeof(StringEnumConverter<Type51>))]
public sealed record Type51 : OpenStringEnum<Type51>
{
    private Type51(string value) : base(value)
    {
    }

    public static readonly Type51 Order = new("ORDER");

    public static readonly Type51 OrderExecution = new("ORDER_EXECUTION");

    public static readonly Type51 CorporateAction = new("CORPORATE_ACTION");

    public static readonly Type51 CorporateActionTransactionId = new("CORPORATE_ACTION_TRANSACTION_ID");

    public TResult Match<TResult>(Func<TResult> onOrder,
        Func<TResult> onOrderExecution,
        Func<TResult> onCorporateAction,
        Func<TResult> onCorporateActionTransactionId,
        Func<string, TResult> otherwise) =>
        this switch
        {
            _ when this == Order => onOrder(),
            _ when this == OrderExecution => onOrderExecution(),
            _ when this == CorporateAction => onCorporateAction(),
            _ when this == CorporateActionTransactionId => onCorporateActionTransactionId(),
            _ => otherwise(Value)
        };

    public void Match(Action onOrder,
        Action onOrderExecution,
        Action onCorporateAction,
        Action onCorporateActionTransactionId,
        Action<string> otherwise)
    {
        if (this == Order) onOrder();
        else if (this == OrderExecution) onOrderExecution();
        else if (this == CorporateAction) onCorporateAction();
        else if (this == CorporateActionTransactionId) onCorporateActionTransactionId();
        else otherwise(Value);
    }
}
