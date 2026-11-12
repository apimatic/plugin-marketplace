using System;
using System.Text.Json.Serialization;
using UpvestInvestmentApi.Core.Enum;

namespace UpvestInvestmentApi.Models.Enums;

/// <summary>
/// Type of the reference.
/// * ACCOUNT_GROUP - Account group
/// * CASH_BALANCE_TRANSFER - Cash balance transfer
/// * CORPORATE_ACTION - Corporate action
/// * CORPORATE_ACTION_TRANSACTION_ID - Corporate action transaction ID
/// * CREDIT_FUNDING - Credit Funding
/// * DIRECT_DEBIT - Direct debit funding request
/// * EXTERNAL_DIRECT_DEBIT - External direct debit collection
/// * FEE_COLLECTION - Fee collection
/// * ISA_TRANSFER - ISA transfer
/// * ORDER - Order
/// * ORDER_EXECUTION - Order execution
/// * PENSION_DE_ALLOWANCE - German pension allowance
/// * PENSION_DE_ALLOWANCE_UPDATE - German pension allowance update
/// * TAX_TRANSACTION - Tax transaction
/// * TOPUP - Cash top up
/// * TRANSACTION_FEE_EXECUTION - Transaction fee execution
/// * VIRTUAL_CASH_DECREASE - Virtual cash decreased
/// * VIRTUAL_CASH_INCREASE - Virtual cash increased
/// * WITHDRAWAL - Cash withdrawal
/// </summary>
[JsonConverter(typeof(StringEnumConverter<Type50>))]
public sealed record Type50 : OpenStringEnum<Type50>
{
    private Type50(string value) : base(value)
    {
    }

    public static readonly Type50 AccountGroup = new("ACCOUNT_GROUP");

    public static readonly Type50 CashBalanceTransfer = new("CASH_BALANCE_TRANSFER");

    public static readonly Type50 CorporateAction = new("CORPORATE_ACTION");

    public static readonly Type50 CorporateActionTransactionId = new("CORPORATE_ACTION_TRANSACTION_ID");

    public static readonly Type50 CreditFunding = new("CREDIT_FUNDING");

    public static readonly Type50 DirectDebit = new("DIRECT_DEBIT");

    public static readonly Type50 ExternalDirectDebit = new("EXTERNAL_DIRECT_DEBIT");

    public static readonly Type50 FeeCollection = new("FEE_COLLECTION");

    public static readonly Type50 IsaTransfer = new("ISA_TRANSFER");

    public static readonly Type50 Order = new("ORDER");

    public static readonly Type50 OrderExecution = new("ORDER_EXECUTION");

    public static readonly Type50 PensionDeAllowance = new("PENSION_DE_ALLOWANCE");

    public static readonly Type50 PensionDeAllowanceUpdate = new("PENSION_DE_ALLOWANCE_UPDATE");

    public static readonly Type50 TaxTransaction = new("TAX_TRANSACTION");

    public static readonly Type50 Topup = new("TOPUP");

    public static readonly Type50 TransactionFeeExecution = new("TRANSACTION_FEE_EXECUTION");

    public static readonly Type50 VirtualCashDecrease = new("VIRTUAL_CASH_DECREASE");

    public static readonly Type50 VirtualCashIncrease = new("VIRTUAL_CASH_INCREASE");

    public static readonly Type50 Withdrawal = new("WITHDRAWAL");

    public TResult Match<TResult>(Func<TResult> onAccountGroup,
        Func<TResult> onCashBalanceTransfer,
        Func<TResult> onCorporateAction,
        Func<TResult> onCorporateActionTransactionId,
        Func<TResult> onCreditFunding,
        Func<TResult> onDirectDebit,
        Func<TResult> onExternalDirectDebit,
        Func<TResult> onFeeCollection,
        Func<TResult> onIsaTransfer,
        Func<TResult> onOrder,
        Func<TResult> onOrderExecution,
        Func<TResult> onPensionDeAllowance,
        Func<TResult> onPensionDeAllowanceUpdate,
        Func<TResult> onTaxTransaction,
        Func<TResult> onTopup,
        Func<TResult> onTransactionFeeExecution,
        Func<TResult> onVirtualCashDecrease,
        Func<TResult> onVirtualCashIncrease,
        Func<TResult> onWithdrawal,
        Func<string, TResult> otherwise) =>
        this switch
        {
            _ when this == AccountGroup => onAccountGroup(),
            _ when this == CashBalanceTransfer => onCashBalanceTransfer(),
            _ when this == CorporateAction => onCorporateAction(),
            _ when this == CorporateActionTransactionId => onCorporateActionTransactionId(),
            _ when this == CreditFunding => onCreditFunding(),
            _ when this == DirectDebit => onDirectDebit(),
            _ when this == ExternalDirectDebit => onExternalDirectDebit(),
            _ when this == FeeCollection => onFeeCollection(),
            _ when this == IsaTransfer => onIsaTransfer(),
            _ when this == Order => onOrder(),
            _ when this == OrderExecution => onOrderExecution(),
            _ when this == PensionDeAllowance => onPensionDeAllowance(),
            _ when this == PensionDeAllowanceUpdate => onPensionDeAllowanceUpdate(),
            _ when this == TaxTransaction => onTaxTransaction(),
            _ when this == Topup => onTopup(),
            _ when this == TransactionFeeExecution => onTransactionFeeExecution(),
            _ when this == VirtualCashDecrease => onVirtualCashDecrease(),
            _ when this == VirtualCashIncrease => onVirtualCashIncrease(),
            _ when this == Withdrawal => onWithdrawal(),
            _ => otherwise(Value)
        };

    public void Match(Action onAccountGroup,
        Action onCashBalanceTransfer,
        Action onCorporateAction,
        Action onCorporateActionTransactionId,
        Action onCreditFunding,
        Action onDirectDebit,
        Action onExternalDirectDebit,
        Action onFeeCollection,
        Action onIsaTransfer,
        Action onOrder,
        Action onOrderExecution,
        Action onPensionDeAllowance,
        Action onPensionDeAllowanceUpdate,
        Action onTaxTransaction,
        Action onTopup,
        Action onTransactionFeeExecution,
        Action onVirtualCashDecrease,
        Action onVirtualCashIncrease,
        Action onWithdrawal,
        Action<string> otherwise)
    {
        if (this == AccountGroup) onAccountGroup();
        else if (this == CashBalanceTransfer) onCashBalanceTransfer();
        else if (this == CorporateAction) onCorporateAction();
        else if (this == CorporateActionTransactionId) onCorporateActionTransactionId();
        else if (this == CreditFunding) onCreditFunding();
        else if (this == DirectDebit) onDirectDebit();
        else if (this == ExternalDirectDebit) onExternalDirectDebit();
        else if (this == FeeCollection) onFeeCollection();
        else if (this == IsaTransfer) onIsaTransfer();
        else if (this == Order) onOrder();
        else if (this == OrderExecution) onOrderExecution();
        else if (this == PensionDeAllowance) onPensionDeAllowance();
        else if (this == PensionDeAllowanceUpdate) onPensionDeAllowanceUpdate();
        else if (this == TaxTransaction) onTaxTransaction();
        else if (this == Topup) onTopup();
        else if (this == TransactionFeeExecution) onTransactionFeeExecution();
        else if (this == VirtualCashDecrease) onVirtualCashDecrease();
        else if (this == VirtualCashIncrease) onVirtualCashIncrease();
        else if (this == Withdrawal) onWithdrawal();
        else otherwise(Value);
    }
}
