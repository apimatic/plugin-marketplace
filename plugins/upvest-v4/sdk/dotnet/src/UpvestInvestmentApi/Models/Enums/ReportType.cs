using System;
using System.Text.Json.Serialization;
using UpvestInvestmentApi.Core.Enum;

namespace UpvestInvestmentApi.Models.Enums;

/// <summary>
/// Report type
/// * ACCOUNT_CLOSING - Securities account closure
/// * ACCOUNT_OPENING - Securities account opening
/// * AD_HOC_ACCOUNT_STATEMENT - Ad hoc account statement
/// * ANNUAL_INCOME_STATEMENT - Annual tax income statement ("Erträgnisaufstellung")
/// * ANNUAL_TAX_STATEMENT - Annual tax reporting
/// * BANK_ACCOUNT_CONNECTED - Connect reference bank account
/// * BUY_ORDER - Buy order
/// * CANCELLED_ORDER - Cancelled buy or sell order (not yet executed, user cancels or trading venue cancelled)
/// * CORPORATE_ACTION_CASH_TRANSACTION - cash transaction document (after corporate action)
/// * CORPORATE_ACTION_SECURITY_TRANSACTION - security transaction document (after corporate action)
/// * DIRECT_DEBIT_MANDATE - Creation of SEPA direct debit mandate
/// * EX_POST_COST - Ex-post cost report
/// * FEE_COLLECTION - Intake of service fees
/// * FRENCH_IFU - French tax statement (Imprimé fiscal unique)
/// * GENERIC_COMMUNICATION - Generic communication
/// * INCOME_DISTRIBUTION - Income distribution report
/// * LOSS_THRESHOLD - Notification that a holding has depreciated by 10%, or a multiple thereof, against its purchase value
/// * MONTHLY_BILLING_STATEMENT - Monthly billing activities statement
/// * ORDER_EX_ANTE_COST - Ex-ante cost report for a single order
/// * ORDER_EX_ANTE_COST_SAVINGS_PLAN - Ex-ante cost report for a savings plan order
/// * QUARTERLY_ACCOUNT_STATEMENT - Quarterly account statement
/// * REVOKED_ORDER - Revoked buy or sell order ("Storno")
/// * SECURITIES_TRANSFER_INCOMING - Securities are transferred in
/// * SECURITIES_TRANSFER_OUTGOING - Securities are being transferred out
/// * SELL_ORDER - Sell order
/// * TAX_CONSOLIDATED_CERTIFICATE_UK - UK Consolidated Tax Certificate
/// * TAX_PAYMENT - Tax payment document
/// * TAX_PREPAYMENT_DE - German tax prepayment (Vorabpauschale)
/// * TAX_PREPAYMENT_DE_CANCELLATION - German tax prepayment (Vorabpauschale) cancellation
/// * TAX_REFUND - Tax refund document (after tax optimization)
/// </summary>
[JsonConverter(typeof(StringEnumConverter<ReportType>))]
public sealed record ReportType : OpenStringEnum<ReportType>
{
    private ReportType(string value) : base(value)
    {
    }

    public static readonly ReportType AccountClosing = new("ACCOUNT_CLOSING");

    public static readonly ReportType AccountOpening = new("ACCOUNT_OPENING");

    public static readonly ReportType AdHocAccountStatement = new("AD_HOC_ACCOUNT_STATEMENT");

    public static readonly ReportType AnnualIncomeStatement = new("ANNUAL_INCOME_STATEMENT");

    public static readonly ReportType AnnualTaxStatement = new("ANNUAL_TAX_STATEMENT");

    public static readonly ReportType BankAccountConnected = new("BANK_ACCOUNT_CONNECTED");

    public static readonly ReportType BuyOrder = new("BUY_ORDER");

    public static readonly ReportType CancelledOrder = new("CANCELLED_ORDER");

    public static readonly ReportType CorporateActionCashTransaction = new("CORPORATE_ACTION_CASH_TRANSACTION");

    public static readonly ReportType CorporateActionSecurityTransaction = new("CORPORATE_ACTION_SECURITY_TRANSACTION");

    public static readonly ReportType DirectDebitMandate = new("DIRECT_DEBIT_MANDATE");

    public static readonly ReportType ExPostCost = new("EX_POST_COST");

    public static readonly ReportType FeeCollection = new("FEE_COLLECTION");

    public static readonly ReportType FrenchIfu = new("FRENCH_IFU");

    public static readonly ReportType GenericCommunication = new("GENERIC_COMMUNICATION");

    public static readonly ReportType IncomeDistribution = new("INCOME_DISTRIBUTION");

    public static readonly ReportType LossThreshold = new("LOSS_THRESHOLD");

    public static readonly ReportType MonthlyBillingStatement = new("MONTHLY_BILLING_STATEMENT");

    public static readonly ReportType OrderExAnteCost = new("ORDER_EX_ANTE_COST");

    public static readonly ReportType OrderExAnteCostSavingsPlan = new("ORDER_EX_ANTE_COST_SAVINGS_PLAN");

    public static readonly ReportType QuarterlyAccountStatement = new("QUARTERLY_ACCOUNT_STATEMENT");

    public static readonly ReportType RevokedOrder = new("REVOKED_ORDER");

    public static readonly ReportType SecuritiesTransferIncoming = new("SECURITIES_TRANSFER_INCOMING");

    public static readonly ReportType SecuritiesTransferOutgoing = new("SECURITIES_TRANSFER_OUTGOING");

    public static readonly ReportType SellOrder = new("SELL_ORDER");

    public static readonly ReportType TaxConsolidatedCertificateUk = new("TAX_CONSOLIDATED_CERTIFICATE_UK");

    public static readonly ReportType TaxPayment = new("TAX_PAYMENT");

    public static readonly ReportType TaxPrepaymentDe = new("TAX_PREPAYMENT_DE");

    public static readonly ReportType TaxPrepaymentDeCancellation = new("TAX_PREPAYMENT_DE_CANCELLATION");

    public static readonly ReportType TaxRefund = new("TAX_REFUND");

    public TResult Match<TResult>(Func<TResult> onAccountClosing,
        Func<TResult> onAccountOpening,
        Func<TResult> onAdHocAccountStatement,
        Func<TResult> onAnnualIncomeStatement,
        Func<TResult> onAnnualTaxStatement,
        Func<TResult> onBankAccountConnected,
        Func<TResult> onBuyOrder,
        Func<TResult> onCancelledOrder,
        Func<TResult> onCorporateActionCashTransaction,
        Func<TResult> onCorporateActionSecurityTransaction,
        Func<TResult> onDirectDebitMandate,
        Func<TResult> onExPostCost,
        Func<TResult> onFeeCollection,
        Func<TResult> onFrenchIfu,
        Func<TResult> onGenericCommunication,
        Func<TResult> onIncomeDistribution,
        Func<TResult> onLossThreshold,
        Func<TResult> onMonthlyBillingStatement,
        Func<TResult> onOrderExAnteCost,
        Func<TResult> onOrderExAnteCostSavingsPlan,
        Func<TResult> onQuarterlyAccountStatement,
        Func<TResult> onRevokedOrder,
        Func<TResult> onSecuritiesTransferIncoming,
        Func<TResult> onSecuritiesTransferOutgoing,
        Func<TResult> onSellOrder,
        Func<TResult> onTaxConsolidatedCertificateUk,
        Func<TResult> onTaxPayment,
        Func<TResult> onTaxPrepaymentDe,
        Func<TResult> onTaxPrepaymentDeCancellation,
        Func<TResult> onTaxRefund,
        Func<string, TResult> otherwise) =>
        this switch
        {
            _ when this == AccountClosing => onAccountClosing(),
            _ when this == AccountOpening => onAccountOpening(),
            _ when this == AdHocAccountStatement => onAdHocAccountStatement(),
            _ when this == AnnualIncomeStatement => onAnnualIncomeStatement(),
            _ when this == AnnualTaxStatement => onAnnualTaxStatement(),
            _ when this == BankAccountConnected => onBankAccountConnected(),
            _ when this == BuyOrder => onBuyOrder(),
            _ when this == CancelledOrder => onCancelledOrder(),
            _ when this == CorporateActionCashTransaction => onCorporateActionCashTransaction(),
            _ when this == CorporateActionSecurityTransaction => onCorporateActionSecurityTransaction(),
            _ when this == DirectDebitMandate => onDirectDebitMandate(),
            _ when this == ExPostCost => onExPostCost(),
            _ when this == FeeCollection => onFeeCollection(),
            _ when this == FrenchIfu => onFrenchIfu(),
            _ when this == GenericCommunication => onGenericCommunication(),
            _ when this == IncomeDistribution => onIncomeDistribution(),
            _ when this == LossThreshold => onLossThreshold(),
            _ when this == MonthlyBillingStatement => onMonthlyBillingStatement(),
            _ when this == OrderExAnteCost => onOrderExAnteCost(),
            _ when this == OrderExAnteCostSavingsPlan => onOrderExAnteCostSavingsPlan(),
            _ when this == QuarterlyAccountStatement => onQuarterlyAccountStatement(),
            _ when this == RevokedOrder => onRevokedOrder(),
            _ when this == SecuritiesTransferIncoming => onSecuritiesTransferIncoming(),
            _ when this == SecuritiesTransferOutgoing => onSecuritiesTransferOutgoing(),
            _ when this == SellOrder => onSellOrder(),
            _ when this == TaxConsolidatedCertificateUk => onTaxConsolidatedCertificateUk(),
            _ when this == TaxPayment => onTaxPayment(),
            _ when this == TaxPrepaymentDe => onTaxPrepaymentDe(),
            _ when this == TaxPrepaymentDeCancellation => onTaxPrepaymentDeCancellation(),
            _ when this == TaxRefund => onTaxRefund(),
            _ => otherwise(Value)
        };

    public void Match(Action onAccountClosing,
        Action onAccountOpening,
        Action onAdHocAccountStatement,
        Action onAnnualIncomeStatement,
        Action onAnnualTaxStatement,
        Action onBankAccountConnected,
        Action onBuyOrder,
        Action onCancelledOrder,
        Action onCorporateActionCashTransaction,
        Action onCorporateActionSecurityTransaction,
        Action onDirectDebitMandate,
        Action onExPostCost,
        Action onFeeCollection,
        Action onFrenchIfu,
        Action onGenericCommunication,
        Action onIncomeDistribution,
        Action onLossThreshold,
        Action onMonthlyBillingStatement,
        Action onOrderExAnteCost,
        Action onOrderExAnteCostSavingsPlan,
        Action onQuarterlyAccountStatement,
        Action onRevokedOrder,
        Action onSecuritiesTransferIncoming,
        Action onSecuritiesTransferOutgoing,
        Action onSellOrder,
        Action onTaxConsolidatedCertificateUk,
        Action onTaxPayment,
        Action onTaxPrepaymentDe,
        Action onTaxPrepaymentDeCancellation,
        Action onTaxRefund,
        Action<string> otherwise)
    {
        if (this == AccountClosing) onAccountClosing();
        else if (this == AccountOpening) onAccountOpening();
        else if (this == AdHocAccountStatement) onAdHocAccountStatement();
        else if (this == AnnualIncomeStatement) onAnnualIncomeStatement();
        else if (this == AnnualTaxStatement) onAnnualTaxStatement();
        else if (this == BankAccountConnected) onBankAccountConnected();
        else if (this == BuyOrder) onBuyOrder();
        else if (this == CancelledOrder) onCancelledOrder();
        else if (this == CorporateActionCashTransaction) onCorporateActionCashTransaction();
        else if (this == CorporateActionSecurityTransaction) onCorporateActionSecurityTransaction();
        else if (this == DirectDebitMandate) onDirectDebitMandate();
        else if (this == ExPostCost) onExPostCost();
        else if (this == FeeCollection) onFeeCollection();
        else if (this == FrenchIfu) onFrenchIfu();
        else if (this == GenericCommunication) onGenericCommunication();
        else if (this == IncomeDistribution) onIncomeDistribution();
        else if (this == LossThreshold) onLossThreshold();
        else if (this == MonthlyBillingStatement) onMonthlyBillingStatement();
        else if (this == OrderExAnteCost) onOrderExAnteCost();
        else if (this == OrderExAnteCostSavingsPlan) onOrderExAnteCostSavingsPlan();
        else if (this == QuarterlyAccountStatement) onQuarterlyAccountStatement();
        else if (this == RevokedOrder) onRevokedOrder();
        else if (this == SecuritiesTransferIncoming) onSecuritiesTransferIncoming();
        else if (this == SecuritiesTransferOutgoing) onSecuritiesTransferOutgoing();
        else if (this == SellOrder) onSellOrder();
        else if (this == TaxConsolidatedCertificateUk) onTaxConsolidatedCertificateUk();
        else if (this == TaxPayment) onTaxPayment();
        else if (this == TaxPrepaymentDe) onTaxPrepaymentDe();
        else if (this == TaxPrepaymentDeCancellation) onTaxPrepaymentDeCancellation();
        else if (this == TaxRefund) onTaxRefund();
        else otherwise(Value);
    }
}
