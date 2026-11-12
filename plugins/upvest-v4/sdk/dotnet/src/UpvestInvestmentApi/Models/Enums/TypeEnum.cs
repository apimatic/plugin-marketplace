using System;
using System.Text.Json.Serialization;
using UpvestInvestmentApi.Core.Enum;

namespace UpvestInvestmentApi.Models.Enums;

[JsonConverter(typeof(StringEnumConverter<TypeEnum>))]
public sealed record TypeEnum : OpenStringEnum<TypeEnum>
{
    private TypeEnum(string value) : base(value)
    {
    }

    public static readonly TypeEnum All = new("ALL");

    public static readonly TypeEnum Business = new("BUSINESS");

    public static readonly TypeEnum Role = new("ROLE");

    public static readonly TypeEnum User = new("USER");

    public static readonly TypeEnum UserCheck = new("USER_CHECK");

    public static readonly TypeEnum Order = new("ORDER");

    public static readonly TypeEnum OrderCancellation = new("ORDER_CANCELLATION");

    public static readonly TypeEnum Execution = new("EXECUTION");

    public static readonly TypeEnum Position = new("POSITION");

    public static readonly TypeEnum CashBalance = new("CASH_BALANCE");

    public static readonly TypeEnum Account = new("ACCOUNT");

    public static readonly TypeEnum AccountGroup = new("ACCOUNT_GROUP");

    public static readonly TypeEnum Instrument = new("INSTRUMENT");

    public static readonly TypeEnum Report = new("REPORT");

    public static readonly TypeEnum TreasuryReport = new("TREASURY_REPORT");

    public static readonly TypeEnum DirectDebit = new("DIRECT_DEBIT");

    public static readonly TypeEnum Withdrawal = new("WITHDRAWAL");

    public static readonly TypeEnum Portfolio = new("PORTFOLIO");

    public static readonly TypeEnum PortfolioAllocation = new("PORTFOLIO_ALLOCATION");

    public static readonly TypeEnum PortfolioOrder = new("PORTFOLIO_ORDER");

    public static readonly TypeEnum CorporateAction = new("CORPORATE_ACTION");

    public static readonly TypeEnum AccountValuation = new("ACCOUNT_VALUATION");

    public static readonly TypeEnum IntradayAccountValuation = new("INTRADAY_ACCOUNT_VALUATION");

    public static readonly TypeEnum CashTransaction = new("CASH_TRANSACTION");

    public static readonly TypeEnum SecurityTransaction = new("SECURITY_TRANSACTION");

    public static readonly TypeEnum AccountLiquidation = new("ACCOUNT_LIQUIDATION");

    public static readonly TypeEnum AccountReturns = new("ACCOUNT_RETURNS");

    public static readonly TypeEnum VirtualCashIncrease = new("VIRTUAL_CASH_INCREASE");

    public static readonly TypeEnum VirtualCashDecrease = new("VIRTUAL_CASH_DECREASE");

    public static readonly TypeEnum FeeCollection = new("FEE_COLLECTION");

    public static readonly TypeEnum SavingsPlan = new("SAVINGS_PLAN");

    public static readonly TypeEnum SavingsPlanExecution = new("SAVINGS_PLAN_EXECUTION");

    public static readonly TypeEnum RebalancingExecutionOrder = new("REBALANCING_EXECUTION_ORDER");

    public static readonly TypeEnum TaxExemption = new("TAX_EXEMPTION");

    public static readonly TypeEnum TaxCollection = new("TAX_COLLECTION");

    public static readonly TypeEnum IsaWrapper = new("ISA_WRAPPER");

    public static readonly TypeEnum IsaWrapperAllowance = new("ISA_WRAPPER_ALLOWANCE");

    public static readonly TypeEnum CreditFunding = new("CREDIT_FUNDING");

    public static readonly TypeEnum VirtualBankAccount = new("VIRTUAL_BANK_ACCOUNT");

    public static readonly TypeEnum SecuritiesTransfer = new("SECURITIES_TRANSFER");

    public static readonly TypeEnum AccountTransfer = new("ACCOUNT_TRANSFER");

    public static readonly TypeEnum Topup = new("TOPUP");

    public static readonly TypeEnum IsaTransfer = new("ISA_TRANSFER");

    public static readonly TypeEnum CashBalanceTransfer = new("CASH_BALANCE_TRANSFER");

    public TResult Match<TResult>(Func<TResult> onAll,
        Func<TResult> onBusiness,
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
            _ when this == All => onAll(),
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

    public void Match(Action onAll,
        Action onBusiness,
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
        if (this == All) onAll();
        else if (this == Business) onBusiness();
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
