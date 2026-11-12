using System;
using System.Text.Json.Serialization;
using UpvestInvestmentApi.Core.Enum;

namespace UpvestInvestmentApi.Models.Enums;

[JsonConverter(typeof(StringEnumConverter<ExcludeType>))]
public sealed record ExcludeType : OpenStringEnum<ExcludeType>
{
    private ExcludeType(string value) : base(value)
    {
    }

    public static readonly ExcludeType Business = new("BUSINESS");

    public static readonly ExcludeType Role = new("ROLE");

    public static readonly ExcludeType User = new("USER");

    public static readonly ExcludeType UserCheck = new("USER_CHECK");

    public static readonly ExcludeType Order = new("ORDER");

    public static readonly ExcludeType OrderCancellation = new("ORDER_CANCELLATION");

    public static readonly ExcludeType Execution = new("EXECUTION");

    public static readonly ExcludeType Position = new("POSITION");

    public static readonly ExcludeType CashBalance = new("CASH_BALANCE");

    public static readonly ExcludeType Account = new("ACCOUNT");

    public static readonly ExcludeType AccountGroup = new("ACCOUNT_GROUP");

    public static readonly ExcludeType Instrument = new("INSTRUMENT");

    public static readonly ExcludeType Report = new("REPORT");

    public static readonly ExcludeType TreasuryReport = new("TREASURY_REPORT");

    public static readonly ExcludeType DirectDebit = new("DIRECT_DEBIT");

    public static readonly ExcludeType Withdrawal = new("WITHDRAWAL");

    public static readonly ExcludeType Portfolio = new("PORTFOLIO");

    public static readonly ExcludeType PortfolioAllocation = new("PORTFOLIO_ALLOCATION");

    public static readonly ExcludeType PortfolioOrder = new("PORTFOLIO_ORDER");

    public static readonly ExcludeType CorporateAction = new("CORPORATE_ACTION");

    public static readonly ExcludeType AccountValuation = new("ACCOUNT_VALUATION");

    public static readonly ExcludeType IntradayAccountValuation = new("INTRADAY_ACCOUNT_VALUATION");

    public static readonly ExcludeType CashTransaction = new("CASH_TRANSACTION");

    public static readonly ExcludeType SecurityTransaction = new("SECURITY_TRANSACTION");

    public static readonly ExcludeType AccountLiquidation = new("ACCOUNT_LIQUIDATION");

    public static readonly ExcludeType AccountReturns = new("ACCOUNT_RETURNS");

    public static readonly ExcludeType VirtualCashIncrease = new("VIRTUAL_CASH_INCREASE");

    public static readonly ExcludeType VirtualCashDecrease = new("VIRTUAL_CASH_DECREASE");

    public static readonly ExcludeType FeeCollection = new("FEE_COLLECTION");

    public static readonly ExcludeType SavingsPlan = new("SAVINGS_PLAN");

    public static readonly ExcludeType SavingsPlanExecution = new("SAVINGS_PLAN_EXECUTION");

    public static readonly ExcludeType RebalancingExecutionOrder = new("REBALANCING_EXECUTION_ORDER");

    public static readonly ExcludeType TaxExemption = new("TAX_EXEMPTION");

    public static readonly ExcludeType TaxCollection = new("TAX_COLLECTION");

    public static readonly ExcludeType IsaWrapper = new("ISA_WRAPPER");

    public static readonly ExcludeType IsaWrapperAllowance = new("ISA_WRAPPER_ALLOWANCE");

    public static readonly ExcludeType CreditFunding = new("CREDIT_FUNDING");

    public static readonly ExcludeType VirtualBankAccount = new("VIRTUAL_BANK_ACCOUNT");

    public static readonly ExcludeType SecuritiesTransfer = new("SECURITIES_TRANSFER");

    public static readonly ExcludeType AccountTransfer = new("ACCOUNT_TRANSFER");

    public static readonly ExcludeType Topup = new("TOPUP");

    public static readonly ExcludeType IsaTransfer = new("ISA_TRANSFER");

    public static readonly ExcludeType CashBalanceTransfer = new("CASH_BALANCE_TRANSFER");

    public TResult Match<TResult>(Func<TResult> onBusiness,
        Func<TResult> onRole,
        Func<TResult> onUser,
        Func<TResult> onUserCheck,
        Func<TResult> onOrder,
        Func<TResult> onOrderCancellation,
        Func<TResult> onExecution,
        Func<TResult> onPosition,
        Func<TResult> onCashBalance,
        Func<TResult> onAccount,
        Func<TResult> onAccountGroup,
        Func<TResult> onInstrument,
        Func<TResult> onReport,
        Func<TResult> onTreasuryReport,
        Func<TResult> onDirectDebit,
        Func<TResult> onWithdrawal,
        Func<TResult> onPortfolio,
        Func<TResult> onPortfolioAllocation,
        Func<TResult> onPortfolioOrder,
        Func<TResult> onCorporateAction,
        Func<TResult> onAccountValuation,
        Func<TResult> onIntradayAccountValuation,
        Func<TResult> onCashTransaction,
        Func<TResult> onSecurityTransaction,
        Func<TResult> onAccountLiquidation,
        Func<TResult> onAccountReturns,
        Func<TResult> onVirtualCashIncrease,
        Func<TResult> onVirtualCashDecrease,
        Func<TResult> onFeeCollection,
        Func<TResult> onSavingsPlan,
        Func<TResult> onSavingsPlanExecution,
        Func<TResult> onRebalancingExecutionOrder,
        Func<TResult> onTaxExemption,
        Func<TResult> onTaxCollection,
        Func<TResult> onIsaWrapper,
        Func<TResult> onIsaWrapperAllowance,
        Func<TResult> onCreditFunding,
        Func<TResult> onVirtualBankAccount,
        Func<TResult> onSecuritiesTransfer,
        Func<TResult> onAccountTransfer,
        Func<TResult> onTopup,
        Func<TResult> onIsaTransfer,
        Func<TResult> onCashBalanceTransfer,
        Func<string, TResult> otherwise) =>
        this switch
        {
            _ when this == Business => onBusiness(),
            _ when this == Role => onRole(),
            _ when this == User => onUser(),
            _ when this == UserCheck => onUserCheck(),
            _ when this == Order => onOrder(),
            _ when this == OrderCancellation => onOrderCancellation(),
            _ when this == Execution => onExecution(),
            _ when this == Position => onPosition(),
            _ when this == CashBalance => onCashBalance(),
            _ when this == Account => onAccount(),
            _ when this == AccountGroup => onAccountGroup(),
            _ when this == Instrument => onInstrument(),
            _ when this == Report => onReport(),
            _ when this == TreasuryReport => onTreasuryReport(),
            _ when this == DirectDebit => onDirectDebit(),
            _ when this == Withdrawal => onWithdrawal(),
            _ when this == Portfolio => onPortfolio(),
            _ when this == PortfolioAllocation => onPortfolioAllocation(),
            _ when this == PortfolioOrder => onPortfolioOrder(),
            _ when this == CorporateAction => onCorporateAction(),
            _ when this == AccountValuation => onAccountValuation(),
            _ when this == IntradayAccountValuation => onIntradayAccountValuation(),
            _ when this == CashTransaction => onCashTransaction(),
            _ when this == SecurityTransaction => onSecurityTransaction(),
            _ when this == AccountLiquidation => onAccountLiquidation(),
            _ when this == AccountReturns => onAccountReturns(),
            _ when this == VirtualCashIncrease => onVirtualCashIncrease(),
            _ when this == VirtualCashDecrease => onVirtualCashDecrease(),
            _ when this == FeeCollection => onFeeCollection(),
            _ when this == SavingsPlan => onSavingsPlan(),
            _ when this == SavingsPlanExecution => onSavingsPlanExecution(),
            _ when this == RebalancingExecutionOrder => onRebalancingExecutionOrder(),
            _ when this == TaxExemption => onTaxExemption(),
            _ when this == TaxCollection => onTaxCollection(),
            _ when this == IsaWrapper => onIsaWrapper(),
            _ when this == IsaWrapperAllowance => onIsaWrapperAllowance(),
            _ when this == CreditFunding => onCreditFunding(),
            _ when this == VirtualBankAccount => onVirtualBankAccount(),
            _ when this == SecuritiesTransfer => onSecuritiesTransfer(),
            _ when this == AccountTransfer => onAccountTransfer(),
            _ when this == Topup => onTopup(),
            _ when this == IsaTransfer => onIsaTransfer(),
            _ when this == CashBalanceTransfer => onCashBalanceTransfer(),
            _ => otherwise(Value)
        };

    public void Match(Action onBusiness,
        Action onRole,
        Action onUser,
        Action onUserCheck,
        Action onOrder,
        Action onOrderCancellation,
        Action onExecution,
        Action onPosition,
        Action onCashBalance,
        Action onAccount,
        Action onAccountGroup,
        Action onInstrument,
        Action onReport,
        Action onTreasuryReport,
        Action onDirectDebit,
        Action onWithdrawal,
        Action onPortfolio,
        Action onPortfolioAllocation,
        Action onPortfolioOrder,
        Action onCorporateAction,
        Action onAccountValuation,
        Action onIntradayAccountValuation,
        Action onCashTransaction,
        Action onSecurityTransaction,
        Action onAccountLiquidation,
        Action onAccountReturns,
        Action onVirtualCashIncrease,
        Action onVirtualCashDecrease,
        Action onFeeCollection,
        Action onSavingsPlan,
        Action onSavingsPlanExecution,
        Action onRebalancingExecutionOrder,
        Action onTaxExemption,
        Action onTaxCollection,
        Action onIsaWrapper,
        Action onIsaWrapperAllowance,
        Action onCreditFunding,
        Action onVirtualBankAccount,
        Action onSecuritiesTransfer,
        Action onAccountTransfer,
        Action onTopup,
        Action onIsaTransfer,
        Action onCashBalanceTransfer,
        Action<string> otherwise)
    {
        if (this == Business) onBusiness();
        else if (this == Role) onRole();
        else if (this == User) onUser();
        else if (this == UserCheck) onUserCheck();
        else if (this == Order) onOrder();
        else if (this == OrderCancellation) onOrderCancellation();
        else if (this == Execution) onExecution();
        else if (this == Position) onPosition();
        else if (this == CashBalance) onCashBalance();
        else if (this == Account) onAccount();
        else if (this == AccountGroup) onAccountGroup();
        else if (this == Instrument) onInstrument();
        else if (this == Report) onReport();
        else if (this == TreasuryReport) onTreasuryReport();
        else if (this == DirectDebit) onDirectDebit();
        else if (this == Withdrawal) onWithdrawal();
        else if (this == Portfolio) onPortfolio();
        else if (this == PortfolioAllocation) onPortfolioAllocation();
        else if (this == PortfolioOrder) onPortfolioOrder();
        else if (this == CorporateAction) onCorporateAction();
        else if (this == AccountValuation) onAccountValuation();
        else if (this == IntradayAccountValuation) onIntradayAccountValuation();
        else if (this == CashTransaction) onCashTransaction();
        else if (this == SecurityTransaction) onSecurityTransaction();
        else if (this == AccountLiquidation) onAccountLiquidation();
        else if (this == AccountReturns) onAccountReturns();
        else if (this == VirtualCashIncrease) onVirtualCashIncrease();
        else if (this == VirtualCashDecrease) onVirtualCashDecrease();
        else if (this == FeeCollection) onFeeCollection();
        else if (this == SavingsPlan) onSavingsPlan();
        else if (this == SavingsPlanExecution) onSavingsPlanExecution();
        else if (this == RebalancingExecutionOrder) onRebalancingExecutionOrder();
        else if (this == TaxExemption) onTaxExemption();
        else if (this == TaxCollection) onTaxCollection();
        else if (this == IsaWrapper) onIsaWrapper();
        else if (this == IsaWrapperAllowance) onIsaWrapperAllowance();
        else if (this == CreditFunding) onCreditFunding();
        else if (this == VirtualBankAccount) onVirtualBankAccount();
        else if (this == SecuritiesTransfer) onSecuritiesTransfer();
        else if (this == AccountTransfer) onAccountTransfer();
        else if (this == Topup) onTopup();
        else if (this == IsaTransfer) onIsaTransfer();
        else if (this == CashBalanceTransfer) onCashBalanceTransfer();
        else otherwise(Value);
    }
}
