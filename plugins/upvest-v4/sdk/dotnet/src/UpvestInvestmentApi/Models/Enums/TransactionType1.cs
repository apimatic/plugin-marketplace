using System;
using System.Text.Json.Serialization;
using UpvestInvestmentApi.Core.Enum;

namespace UpvestInvestmentApi.Models.Enums;

/// <summary>
/// Transaction type
/// * ACCUMULATION - Accumulation
/// * ACCUMULATION_CANCELLATION - Accumulation cancellation
/// * ANNUAL_GENERAL_MEETING - Annual general meeting
/// * ANNUAL_GENERAL_MEETING_CANCELLATION - Annual general meeting cancellation
/// * ATTACHMENT - Attachment
/// * ATTACHMENT_CANCELLATION - Attachment cancellation
/// * BALANCE_CORRECTION - Balance correction
/// * BALANCE_CORRECTION_CANCELLATION - Balance correction cancellation
/// * BANKRUPTCY - Bankruptcy
/// * BANKRUPTCY_CANCELLATION - Bankruptcy cancellation
/// * BOND_DEFAULT - Bond default
/// * BOND_DEFAULT_CANCELLATION - Bond default cancellation
/// * BOND_HOLDER_MEETING - Bond holder meeting
/// * BOND_HOLDER_MEETING_CANCELLATION - Bond holder meeting cancellation
/// * BONUS_ISSUE - Bonus Issue/Capitalisation Issue
/// * BONUS_ISSUE_CANCELLATION - Bonus Issue/Capitalisation Issue, Cancellation
/// * CALL_ON_INTERMEDIATE_SECURITIES - Call on Intermediate Securities
/// * CALL_ON_INTERMEDIATE_SECURITIES_CANCELLATION - Call on Intermediate Securities, Cancellation
/// * CAPITAL_DISTRIBUTION - Capital distribution
/// * CAPITAL_DISTRIBUTION_CANCELLATION - Capital distribution cancellation
/// * CAPITAL_GAINS_DISTRIBUTION - Capital gains distribution
/// * CAPITAL_GAINS_DISTRIBUTION_CANCELLATION - Capital gains distribution cancellation
/// * CAPITALISATION - Capitalisation
/// * CAPITALISATION_CANCELLATION - Capitalisation cancellation
/// * CASH_DISTRIBUTION_FROM_NON_ELIGIBLE_SECURITIES_SALES - Cash distribution from non eligible securities sales
/// * CASH_DISTRIBUTION_FROM_NON_ELIGIBLE_SECURITIES_SALES_CANCELLATION - Cash distribution from non eligible securities sales cancellation
/// * CASH_DIVIDEND - Cash dividend
/// * CASH_DIVIDEND_CANCELLATION - Cash dividend cancellation
/// * CHANGE - Change
/// * CHANGE_CANCELLATION - Change, Cancellation
/// * CLASS_ACTION - Class action
/// * CLASS_ACTION_CANCELLATION - Class action cancellation
/// * COMPANY_OPTION - Company option
/// * COMPANY_OPTION_CANCELLATION - Company option cancellation
/// * CONSENT - Consent
/// * CONSENT_CANCELLATION - Consent cancellation
/// * CONVERSION - Conversion
/// * CONVERSION_CANCELLATION - Conversion cancellation
/// * COURT_MEETING - Court meeting
/// * COURT_MEETING_CANCELLATION - Court meeting cancellation
/// * CREDIT_EVENT - Credit event
/// * CREDIT_EVENT_CANCELLATION - Credit event cancellation
/// * DECREASE_IN_VALUE - Decrease in value
/// * DECREASE_IN_VALUE_CANCELLATION - Decrease in value cancellation
/// * DETACHMENT - Detachment
/// * DETACHMENT_CANCELLATION - Detachment cancellation
/// * DISCLOSURE - Disclosure
/// * DISCLOSURE_CANCELLATION - Disclosure cancellation
/// * DIVIDEND_OPTION - Dividend Option
/// * DIVIDEND_OPTION_CANCELLATION - Dividend Option, Cancellation
/// * DIVIDEND_REINVESTMENT - Dividend Reinvestment
/// * DIVIDEND_REINVESTMENT_CANCELLATION - Dividend Reinvestment, Cancellation
/// * DRAWING - Drawing
/// * DRAWING_CANCELLATION - Drawing cancellation
/// * DUST_CLEANUP - Dust Cleanup
/// * DUTCH_AUCTION - Dutch Auction
/// * DUTCH_AUCTION_CANCELLATION - Dutch Auction, Cancellation
/// * EXCHANGE - Exchange
/// * EXCHANGE_CANCELLATION - Exchange cancellation
/// * EXTRAORDINARY_OR_SPECIAL_GENERAL_MEETING - Extraordinary or special general meeting
/// * EXTRAORDINARY_OR_SPECIAL_GENERAL_MEETING_CANCELLATION - Extraordinary or special general meeting cancellation
/// * FINAL_MATURITY - Final maturity
/// * FINAL_MATURITY_CANCELLATION - Final maturity cancellation
/// * FULL_CALL - Full call
/// * FULL_CALL_CANCELLATION - Full call cancellation
/// * INCREASE_IN_VALUE - Increase in value
/// * INCREASE_IN_VALUE_CANCELLATION - Increase in value cancellation
/// * INFORMATION - Information
/// * INFORMATION_CANCELLATION - Information cancellation
/// * INSTALMENT_CALL - Instalment call
/// * INSTALMENT_CALL_CANCELLATION - Instalment call cancellation
/// * INTEREST_PAYMENT - Interest payment
/// * INTEREST_PAYMENT_CANCELLATION - Interest payment cancellation
/// * INTERMEDIATE_SECURITIES_DISTRIBUTION - Intermediate Securities Distribution
/// * INTERMEDIATE_SECURITIES_DISTRIBUTION_CANCELLATION - Intermediate Securities Distribution, Cancellation
/// * LIQUIDATION_PAYMENT - Liquidation Dividend/Liquidation Payment
/// * LIQUIDATION_PAYMENT_CANCELLATION - Liquidation Dividend/Liquidation Payment, Cancellation
/// * MATURITY_EXTENSION - Maturity extension
/// * MATURITY_EXTENSION_CANCELLATION - Maturity extension cancellation
/// * MERGER - Merger
/// * MERGER_CANCELLATION - Merger, Cancellation
/// * NON_OFFICIAL_OFFER - Non-Official Offer
/// * NON_OFFICIAL_OFFER_CANCELLATION - Non-Official Offer, Cancellation
/// * NON_US_TEFRA_D_CERTIFICATION - Non us tefra d certification
/// * NON_US_TEFRA_D_CERTIFICATION_CANCELLATION - Non us tefra d certification cancellation
/// * ODD_LOT_SALE - Odd Lot Sale/Purchase
/// * ODD_LOT_SALE_CANCELLATION - Odd Lot Sale/Purchase, Cancellation
/// * ORDER_EXECUTION - Order execution
/// * ORDER_EXECUTION_CANCELLATION - Order execution cancellation
/// * ORDINARY_GENERAL_MEETING - Ordinary general meeting
/// * ORDINARY_GENERAL_MEETING_CANCELLATION - Ordinary general meeting cancellation
/// * OTHER_EVENT - Other Event
/// * OTHER_EVENT_CANCELLATION - Other Event cancellation
/// * PARI_PASSU - Pari passu
/// * PARI_PASSU_CANCELLATION - Pari passu cancellation
/// * PARTIAL_DEFEASANCE - Partial defeasance
/// * PARTIAL_DEFEASANCE_CANCELLATION - Partial defeasance cancellation
/// * PARTIAL_REDEMPTION_WITH_POOL_FACTOR_REDUCTION - Partial redemption with pool factor reduction
/// * PARTIAL_REDEMPTION_WITH_POOL_FACTOR_REDUCTION_CANCELLATION - Partial redemption with pool factor reduction cancellation
/// * PARTIAL_REDEMPTION_WITHOUT_POOL_FACTOR_REDUCTION - Partial redemption without pool factor reduction
/// * PARTIAL_REDEMPTION_WITHOUT_POOL_FACTOR_REDUCTION_CANCELLATION - Partial redemption without pool factor reduction cancellation
/// * PAY_IN_KIND - Pay in kind
/// * PAY_IN_KIND_CANCELLATION - Pay in kind cancellation
/// * PEAK_FRACTION_COMPENSATION - Peak fraction compensation
/// * PEAK_ORDER_ADJUSTMENT - Peak order adjustment
/// * PLACE_OF_INCORPORATION - Place of incorporation
/// * PLACE_OF_INCORPORATION_CANCELLATION - Place of incorporation cancellation
/// * PRIORITY_ISSUE - Priority Issue
/// * PRIORITY_ISSUE_CANCELLATION - Priority Issue, Cancellation
/// * PUT_REDEMPTION - Put redemption
/// * PUT_REDEMPTION_CANCELLATION - Put redemption cancellation
/// * REDENOMINATION - Redenomination
/// * REDENOMINATION_CANCELLATION - Redenomination cancellation
/// * REMARKETING_AGREEMENT - Remarketing agreement
/// * REMARKETING_AGREEMENT_CANCELLATION - Remarketing agreement cancellation
/// * REPURCHASE_OFFER - Repurchase Offer/Issuer Bid/Reverse Rights
/// * REPURCHASE_OFFER_CANCELLATION - Repurchase Offer/Issuer Bid/Reverse Rights, Cancellation
/// * REVERSE_STOCK_SPLIT - Reverse Stock Split/Change in Nominal Value
/// * REVERSE_STOCK_SPLIT_CANCELLATION - Reverse Stock Split/Change in Nominal Value, Cancellation
/// * RIGHTS_ISSUE - Rights Issue/Subscription Rights/Rights Offer
/// * RIGHTS_ISSUE_CANCELLATION - Rights Issue/Subscription Rights/Rights Offer, Cancellation
/// * SCRIP_DIVIDEND - Scrip dividend
/// * SCRIP_DIVIDEND_CANCELLATION - Scrip dividend cancellation
/// * SECURITIES_TRANSFER - Securities transfer
/// * SECURITIES_TRANSFER_CANCELLATION - Securities transfer cancellation
/// * SHARES_PREMIUM_DIVIDEND - Shares premium dividend
/// * SHARES_PREMIUM_DIVIDEND_CANCELLATION - Shares premium dividend cancellation
/// * SMALLEST_NEGOTIABLE_UNIT - Smallest negotiable unit
/// * SMALLEST_NEGOTIABLE_UNIT_CANCELLATION - Smallest negotiable unit cancellation
/// * SPIN_OFF - Spin-Off
/// * SPIN_OFF_CANCELLATION - Spin-Off, Cancellation
/// * STOCK_DIVIDEND - Stock Dividend
/// * STOCK_DIVIDEND_CANCELLATION - Stock Dividend, Cancellation
/// * STOCK_SPLIT - Stock Split/Change in Nominal Value/Subdivision
/// * STOCK_SPLIT_CANCELLATION - Stock Split/Change in Nominal Value/Subdivision, Cancellation
/// * TAX_ON_NON_DISTRIBUTED_PROCEEDS - Tax on non distributed proceeds
/// * TAX_ON_NON_DISTRIBUTED_PROCEEDS_CANCELLATION - Tax on non distributed proceeds cancellation
/// * TAX_RECLAIM - Tax reclaim
/// * TAX_RECLAIM_CANCELLATION - Tax reclaim cancellation
/// * TENDER - Tender/Acquisition/Takeover/Purchase Offer
/// * TENDER_CANCELLATION - Tender/Acquisition/Takeover/Purchase Offer, Cancellation
/// * TRADING_STATUS_ACTIVE - Trading status active
/// * TRADING_STATUS_ACTIVE_CANCELLATION - Trading status active cancellation
/// * TRADING_STATUS_DELISTED - Trading status delisted
/// * TRADING_STATUS_DELISTED_CANCELLATION - Trading status delisted cancellation
/// * TRADING_STATUS_SUSPENDED - Trading status suspended
/// * TRADING_STATUS_SUSPENDED_CANCELLATION - Trading status suspended cancellation
/// * VIRTUAL_CASH_CORRECTION_CANCELLATION - Virtual cash correction cancellation
/// * WARRANT_EXERCISE - Warrant exercise
/// * WARRANT_EXERCISE_CANCELLATION - Warrant exercise cancellation
/// * WITHHOLDING_TAX_RELIEF_CERTIFICATION - Withholding tax relief certification
/// * WITHHOLDING_TAX_RELIEF_CERTIFICATION_CANCELLATION - Withholding tax relief certification cancellation
/// * WORTHLESS - Worthless
/// * WORTHLESS_CANCELLATION - Worthless, Cancellation
/// * SECURITIES_LENDING - Securities lending
/// </summary>
[JsonConverter(typeof(StringEnumConverter<TransactionType1>))]
public sealed record TransactionType1 : OpenStringEnum<TransactionType1>
{
    private TransactionType1(string value) : base(value)
    {
    }

    public static readonly TransactionType1 Accumulation = new("ACCUMULATION");

    public static readonly TransactionType1 AccumulationCancellation = new("ACCUMULATION_CANCELLATION");

    public static readonly TransactionType1 AnnualGeneralMeeting = new("ANNUAL_GENERAL_MEETING");

    public static readonly TransactionType1 AnnualGeneralMeetingCancellation = new(
        "ANNUAL_GENERAL_MEETING_CANCELLATION");

    public static readonly TransactionType1 Attachment = new("ATTACHMENT");

    public static readonly TransactionType1 AttachmentCancellation = new("ATTACHMENT_CANCELLATION");

    public static readonly TransactionType1 BalanceCorrection = new("BALANCE_CORRECTION");

    public static readonly TransactionType1 BalanceCorrectionCancellation = new("BALANCE_CORRECTION_CANCELLATION");

    public static readonly TransactionType1 Bankruptcy = new("BANKRUPTCY");

    public static readonly TransactionType1 BankruptcyCancellation = new("BANKRUPTCY_CANCELLATION");

    public static readonly TransactionType1 BondDefault = new("BOND_DEFAULT");

    public static readonly TransactionType1 BondDefaultCancellation = new("BOND_DEFAULT_CANCELLATION");

    public static readonly TransactionType1 BondHolderMeeting = new("BOND_HOLDER_MEETING");

    public static readonly TransactionType1 BondHolderMeetingCancellation = new("BOND_HOLDER_MEETING_CANCELLATION");

    public static readonly TransactionType1 BonusIssue = new("BONUS_ISSUE");

    public static readonly TransactionType1 BonusIssueCancellation = new("BONUS_ISSUE_CANCELLATION");

    public static readonly TransactionType1 CallOnIntermediateSecurities = new("CALL_ON_INTERMEDIATE_SECURITIES");

    public static readonly TransactionType1 CallOnIntermediateSecuritiesCancellation = new(
        "CALL_ON_INTERMEDIATE_SECURITIES_CANCELLATION");

    public static readonly TransactionType1 CapitalDistribution = new("CAPITAL_DISTRIBUTION");

    public static readonly TransactionType1 CapitalDistributionCancellation = new("CAPITAL_DISTRIBUTION_CANCELLATION");

    public static readonly TransactionType1 CapitalGainsDistribution = new("CAPITAL_GAINS_DISTRIBUTION");

    public static readonly TransactionType1 CapitalGainsDistributionCancellation = new(
        "CAPITAL_GAINS_DISTRIBUTION_CANCELLATION");

    public static readonly TransactionType1 Capitalisation = new("CAPITALISATION");

    public static readonly TransactionType1 CapitalisationCancellation = new("CAPITALISATION_CANCELLATION");

    public static readonly TransactionType1 CashDistributionFromNonEligibleSecuritiesSales = new(
        "CASH_DISTRIBUTION_FROM_NON_ELIGIBLE_SECURITIES_SALES");

    public static readonly TransactionType1 CashDistributionFromNonEligibleSecuritiesSalesCancellation = new(
        "CASH_DISTRIBUTION_FROM_NON_ELIGIBLE_SECURITIES_SALES_CANCELLATION");

    public static readonly TransactionType1 CashDividend = new("CASH_DIVIDEND");

    public static readonly TransactionType1 CashDividendCancellation = new("CASH_DIVIDEND_CANCELLATION");

    public static readonly TransactionType1 Change = new("CHANGE");

    public static readonly TransactionType1 ChangeCancellation = new("CHANGE_CANCELLATION");

    public static readonly TransactionType1 ClassAction = new("CLASS_ACTION");

    public static readonly TransactionType1 ClassActionCancellation = new("CLASS_ACTION_CANCELLATION");

    public static readonly TransactionType1 CompanyOption = new("COMPANY_OPTION");

    public static readonly TransactionType1 CompanyOptionCancellation = new("COMPANY_OPTION_CANCELLATION");

    public static readonly TransactionType1 Consent = new("CONSENT");

    public static readonly TransactionType1 ConsentCancellation = new("CONSENT_CANCELLATION");

    public static readonly TransactionType1 Conversion = new("CONVERSION");

    public static readonly TransactionType1 ConversionCancellation = new("CONVERSION_CANCELLATION");

    public static readonly TransactionType1 CourtMeeting = new("COURT_MEETING");

    public static readonly TransactionType1 CourtMeetingCancellation = new("COURT_MEETING_CANCELLATION");

    public static readonly TransactionType1 CreditEvent = new("CREDIT_EVENT");

    public static readonly TransactionType1 CreditEventCancellation = new("CREDIT_EVENT_CANCELLATION");

    public static readonly TransactionType1 DecreaseInValue = new("DECREASE_IN_VALUE");

    public static readonly TransactionType1 DecreaseInValueCancellation = new("DECREASE_IN_VALUE_CANCELLATION");

    public static readonly TransactionType1 Detachment = new("DETACHMENT");

    public static readonly TransactionType1 DetachmentCancellation = new("DETACHMENT_CANCELLATION");

    public static readonly TransactionType1 Disclosure = new("DISCLOSURE");

    public static readonly TransactionType1 DisclosureCancellation = new("DISCLOSURE_CANCELLATION");

    public static readonly TransactionType1 DividendOption = new("DIVIDEND_OPTION");

    public static readonly TransactionType1 DividendOptionCancellation = new("DIVIDEND_OPTION_CANCELLATION");

    public static readonly TransactionType1 DividendReinvestment = new("DIVIDEND_REINVESTMENT");

    public static readonly TransactionType1 DividendReinvestmentCancellation = new(
        "DIVIDEND_REINVESTMENT_CANCELLATION");

    public static readonly TransactionType1 Drawing = new("DRAWING");

    public static readonly TransactionType1 DrawingCancellation = new("DRAWING_CANCELLATION");

    public static readonly TransactionType1 DustCleanup = new("DUST_CLEANUP");

    public static readonly TransactionType1 DutchAuction = new("DUTCH_AUCTION");

    public static readonly TransactionType1 DutchAuctionCancellation = new("DUTCH_AUCTION_CANCELLATION");

    public static readonly TransactionType1 Exchange = new("EXCHANGE");

    public static readonly TransactionType1 ExchangeCancellation = new("EXCHANGE_CANCELLATION");

    public static readonly TransactionType1 ExtraordinaryOrSpecialGeneralMeeting = new(
        "EXTRAORDINARY_OR_SPECIAL_GENERAL_MEETING");

    public static readonly TransactionType1 ExtraordinaryOrSpecialGeneralMeetingCancellation = new(
        "EXTRAORDINARY_OR_SPECIAL_GENERAL_MEETING_CANCELLATION");

    public static readonly TransactionType1 FinalMaturity = new("FINAL_MATURITY");

    public static readonly TransactionType1 FinalMaturityCancellation = new("FINAL_MATURITY_CANCELLATION");

    public static readonly TransactionType1 FullCall = new("FULL_CALL");

    public static readonly TransactionType1 FullCallCancellation = new("FULL_CALL_CANCELLATION");

    public static readonly TransactionType1 IncreaseInValue = new("INCREASE_IN_VALUE");

    public static readonly TransactionType1 IncreaseInValueCancellation = new("INCREASE_IN_VALUE_CANCELLATION");

    public static readonly TransactionType1 Information = new("INFORMATION");

    public static readonly TransactionType1 InformationCancellation = new("INFORMATION_CANCELLATION");

    public static readonly TransactionType1 InstalmentCall = new("INSTALMENT_CALL");

    public static readonly TransactionType1 InstalmentCallCancellation = new("INSTALMENT_CALL_CANCELLATION");

    public static readonly TransactionType1 InterestPayment = new("INTEREST_PAYMENT");

    public static readonly TransactionType1 InterestPaymentCancellation = new("INTEREST_PAYMENT_CANCELLATION");

    public static readonly TransactionType1 IntermediateSecuritiesDistribution = new(
        "INTERMEDIATE_SECURITIES_DISTRIBUTION");

    public static readonly TransactionType1 IntermediateSecuritiesDistributionCancellation = new(
        "INTERMEDIATE_SECURITIES_DISTRIBUTION_CANCELLATION");

    public static readonly TransactionType1 LiquidationPayment = new("LIQUIDATION_PAYMENT");

    public static readonly TransactionType1 LiquidationPaymentCancellation = new("LIQUIDATION_PAYMENT_CANCELLATION");

    public static readonly TransactionType1 MaturityExtension = new("MATURITY_EXTENSION");

    public static readonly TransactionType1 MaturityExtensionCancellation = new("MATURITY_EXTENSION_CANCELLATION");

    public static readonly TransactionType1 Merger = new("MERGER");

    public static readonly TransactionType1 MergerCancellation = new("MERGER_CANCELLATION");

    public static readonly TransactionType1 NonOfficialOffer = new("NON_OFFICIAL_OFFER");

    public static readonly TransactionType1 NonOfficialOfferCancellation = new("NON_OFFICIAL_OFFER_CANCELLATION");

    public static readonly TransactionType1 NonUsTefraDCertification = new("NON_US_TEFRA_D_CERTIFICATION");

    public static readonly TransactionType1 NonUsTefraDCertificationCancellation = new(
        "NON_US_TEFRA_D_CERTIFICATION_CANCELLATION");

    public static readonly TransactionType1 OddLotSale = new("ODD_LOT_SALE");

    public static readonly TransactionType1 OddLotSaleCancellation = new("ODD_LOT_SALE_CANCELLATION");

    public static readonly TransactionType1 OrderExecution = new("ORDER_EXECUTION");

    public static readonly TransactionType1 OrderExecutionCancellation = new("ORDER_EXECUTION_CANCELLATION");

    public static readonly TransactionType1 OrdinaryGeneralMeeting = new("ORDINARY_GENERAL_MEETING");

    public static readonly TransactionType1 OrdinaryGeneralMeetingCancellation = new(
        "ORDINARY_GENERAL_MEETING_CANCELLATION");

    public static readonly TransactionType1 OtherEvent = new("OTHER_EVENT");

    public static readonly TransactionType1 OtherEventCancellation = new("OTHER_EVENT_CANCELLATION");

    public static readonly TransactionType1 PariPassu = new("PARI_PASSU");

    public static readonly TransactionType1 PariPassuCancellation = new("PARI_PASSU_CANCELLATION");

    public static readonly TransactionType1 PartialDefeasance = new("PARTIAL_DEFEASANCE");

    public static readonly TransactionType1 PartialDefeasanceCancellation = new("PARTIAL_DEFEASANCE_CANCELLATION");

    public static readonly TransactionType1 PartialRedemptionWithPoolFactorReduction = new(
        "PARTIAL_REDEMPTION_WITH_POOL_FACTOR_REDUCTION");

    public static readonly TransactionType1 PartialRedemptionWithPoolFactorReductionCancellation = new(
        "PARTIAL_REDEMPTION_WITH_POOL_FACTOR_REDUCTION_CANCELLATION");

    public static readonly TransactionType1 PartialRedemptionWithoutPoolFactorReduction = new(
        "PARTIAL_REDEMPTION_WITHOUT_POOL_FACTOR_REDUCTION");

    public static readonly TransactionType1 PartialRedemptionWithoutPoolFactorReductionCancellation = new(
        "PARTIAL_REDEMPTION_WITHOUT_POOL_FACTOR_REDUCTION_CANCELLATION");

    public static readonly TransactionType1 PayInKind = new("PAY_IN_KIND");

    public static readonly TransactionType1 PayInKindCancellation = new("PAY_IN_KIND_CANCELLATION");

    public static readonly TransactionType1 PeakFractionCompensation = new("PEAK_FRACTION_COMPENSATION");

    public static readonly TransactionType1 PeakOrderAdjustment = new("PEAK_ORDER_ADJUSTMENT");

    public static readonly TransactionType1 PlaceOfIncorporation = new("PLACE_OF_INCORPORATION");

    public static readonly TransactionType1 PlaceOfIncorporationCancellation = new(
        "PLACE_OF_INCORPORATION_CANCELLATION");

    public static readonly TransactionType1 PriorityIssue = new("PRIORITY_ISSUE");

    public static readonly TransactionType1 PriorityIssueCancellation = new("PRIORITY_ISSUE_CANCELLATION");

    public static readonly TransactionType1 PutRedemption = new("PUT_REDEMPTION");

    public static readonly TransactionType1 PutRedemptionCancellation = new("PUT_REDEMPTION_CANCELLATION");

    public static readonly TransactionType1 Redenomination = new("REDENOMINATION");

    public static readonly TransactionType1 RedenominationCancellation = new("REDENOMINATION_CANCELLATION");

    public static readonly TransactionType1 RemarketingAgreement = new("REMARKETING_AGREEMENT");

    public static readonly TransactionType1 RemarketingAgreementCancellation = new(
        "REMARKETING_AGREEMENT_CANCELLATION");

    public static readonly TransactionType1 RepurchaseOffer = new("REPURCHASE_OFFER");

    public static readonly TransactionType1 RepurchaseOfferCancellation = new("REPURCHASE_OFFER_CANCELLATION");

    public static readonly TransactionType1 ReverseStockSplit = new("REVERSE_STOCK_SPLIT");

    public static readonly TransactionType1 ReverseStockSplitCancellation = new("REVERSE_STOCK_SPLIT_CANCELLATION");

    public static readonly TransactionType1 RightsIssue = new("RIGHTS_ISSUE");

    public static readonly TransactionType1 RightsIssueCancellation = new("RIGHTS_ISSUE_CANCELLATION");

    public static readonly TransactionType1 ScripDividend = new("SCRIP_DIVIDEND");

    public static readonly TransactionType1 ScripDividendCancellation = new("SCRIP_DIVIDEND_CANCELLATION");

    public static readonly TransactionType1 SecuritiesTransfer = new("SECURITIES_TRANSFER");

    public static readonly TransactionType1 SecuritiesTransferCancellation = new("SECURITIES_TRANSFER_CANCELLATION");

    public static readonly TransactionType1 SharesPremiumDividend = new("SHARES_PREMIUM_DIVIDEND");

    public static readonly TransactionType1 SharesPremiumDividendCancellation = new(
        "SHARES_PREMIUM_DIVIDEND_CANCELLATION");

    public static readonly TransactionType1 SmallestNegotiableUnit = new("SMALLEST_NEGOTIABLE_UNIT");

    public static readonly TransactionType1 SmallestNegotiableUnitCancellation = new(
        "SMALLEST_NEGOTIABLE_UNIT_CANCELLATION");

    public static readonly TransactionType1 SpinOff = new("SPIN_OFF");

    public static readonly TransactionType1 SpinOffCancellation = new("SPIN_OFF_CANCELLATION");

    public static readonly TransactionType1 StockDividend = new("STOCK_DIVIDEND");

    public static readonly TransactionType1 StockDividendCancellation = new("STOCK_DIVIDEND_CANCELLATION");

    public static readonly TransactionType1 StockSplit = new("STOCK_SPLIT");

    public static readonly TransactionType1 StockSplitCancellation = new("STOCK_SPLIT_CANCELLATION");

    public static readonly TransactionType1 TaxOnNonDistributedProceeds = new("TAX_ON_NON_DISTRIBUTED_PROCEEDS");

    public static readonly TransactionType1 TaxOnNonDistributedProceedsCancellation = new(
        "TAX_ON_NON_DISTRIBUTED_PROCEEDS_CANCELLATION");

    public static readonly TransactionType1 TaxReclaim = new("TAX_RECLAIM");

    public static readonly TransactionType1 TaxReclaimCancellation = new("TAX_RECLAIM_CANCELLATION");

    public static readonly TransactionType1 Tender = new("TENDER");

    public static readonly TransactionType1 TenderCancellation = new("TENDER_CANCELLATION");

    public static readonly TransactionType1 TradingStatusActive = new("TRADING_STATUS_ACTIVE");

    public static readonly TransactionType1 TradingStatusActiveCancellation = new("TRADING_STATUS_ACTIVE_CANCELLATION");

    public static readonly TransactionType1 TradingStatusDelisted = new("TRADING_STATUS_DELISTED");

    public static readonly TransactionType1 TradingStatusDelistedCancellation = new(
        "TRADING_STATUS_DELISTED_CANCELLATION");

    public static readonly TransactionType1 TradingStatusSuspended = new("TRADING_STATUS_SUSPENDED");

    public static readonly TransactionType1 TradingStatusSuspendedCancellation = new(
        "TRADING_STATUS_SUSPENDED_CANCELLATION");

    public static readonly TransactionType1 VirtualCashCorrectionCancellation = new(
        "VIRTUAL_CASH_CORRECTION_CANCELLATION");

    public static readonly TransactionType1 WarrantExercise = new("WARRANT_EXERCISE");

    public static readonly TransactionType1 WarrantExerciseCancellation = new("WARRANT_EXERCISE_CANCELLATION");

    public static readonly TransactionType1 WithholdingTaxReliefCertification = new(
        "WITHHOLDING_TAX_RELIEF_CERTIFICATION");

    public static readonly TransactionType1 WithholdingTaxReliefCertificationCancellation = new(
        "WITHHOLDING_TAX_RELIEF_CERTIFICATION_CANCELLATION");

    public static readonly TransactionType1 Worthless = new("WORTHLESS");

    public static readonly TransactionType1 WorthlessCancellation = new("WORTHLESS_CANCELLATION");

    public static readonly TransactionType1 SecuritiesLending = new("SECURITIES_LENDING");

    public TResult Match<TResult>(Func<TResult> onAccumulation,
        Func<TResult> onAccumulationCancellation,
        Func<TResult> onAnnualGeneralMeeting,
        Func<TResult> onAnnualGeneralMeetingCancellation,
        Func<TResult> onAttachment,
        Func<TResult> onAttachmentCancellation,
        Func<TResult> onBalanceCorrection,
        Func<TResult> onBalanceCorrectionCancellation,
        Func<TResult> onBankruptcy,
        Func<TResult> onBankruptcyCancellation,
        Func<TResult> onBondDefault,
        Func<TResult> onBondDefaultCancellation,
        Func<TResult> onBondHolderMeeting,
        Func<TResult> onBondHolderMeetingCancellation,
        Func<TResult> onBonusIssue,
        Func<TResult> onBonusIssueCancellation,
        Func<TResult> onCallOnIntermediateSecurities,
        Func<TResult> onCallOnIntermediateSecuritiesCancellation,
        Func<TResult> onCapitalDistribution,
        Func<TResult> onCapitalDistributionCancellation,
        Func<TResult> onCapitalGainsDistribution,
        Func<TResult> onCapitalGainsDistributionCancellation,
        Func<TResult> onCapitalisation,
        Func<TResult> onCapitalisationCancellation,
        Func<TResult> onCashDistributionFromNonEligibleSecuritiesSales,
        Func<TResult> onCashDistributionFromNonEligibleSecuritiesSalesCancellation,
        Func<TResult> onCashDividend,
        Func<TResult> onCashDividendCancellation,
        Func<TResult> onChange,
        Func<TResult> onChangeCancellation,
        Func<TResult> onClassAction,
        Func<TResult> onClassActionCancellation,
        Func<TResult> onCompanyOption,
        Func<TResult> onCompanyOptionCancellation,
        Func<TResult> onConsent,
        Func<TResult> onConsentCancellation,
        Func<TResult> onConversion,
        Func<TResult> onConversionCancellation,
        Func<TResult> onCourtMeeting,
        Func<TResult> onCourtMeetingCancellation,
        Func<TResult> onCreditEvent,
        Func<TResult> onCreditEventCancellation,
        Func<TResult> onDecreaseInValue,
        Func<TResult> onDecreaseInValueCancellation,
        Func<TResult> onDetachment,
        Func<TResult> onDetachmentCancellation,
        Func<TResult> onDisclosure,
        Func<TResult> onDisclosureCancellation,
        Func<TResult> onDividendOption,
        Func<TResult> onDividendOptionCancellation,
        Func<TResult> onDividendReinvestment,
        Func<TResult> onDividendReinvestmentCancellation,
        Func<TResult> onDrawing,
        Func<TResult> onDrawingCancellation,
        Func<TResult> onDustCleanup,
        Func<TResult> onDutchAuction,
        Func<TResult> onDutchAuctionCancellation,
        Func<TResult> onExchange,
        Func<TResult> onExchangeCancellation,
        Func<TResult> onExtraordinaryOrSpecialGeneralMeeting,
        Func<TResult> onExtraordinaryOrSpecialGeneralMeetingCancellation,
        Func<TResult> onFinalMaturity,
        Func<TResult> onFinalMaturityCancellation,
        Func<TResult> onFullCall,
        Func<TResult> onFullCallCancellation,
        Func<TResult> onIncreaseInValue,
        Func<TResult> onIncreaseInValueCancellation,
        Func<TResult> onInformation,
        Func<TResult> onInformationCancellation,
        Func<TResult> onInstalmentCall,
        Func<TResult> onInstalmentCallCancellation,
        Func<TResult> onInterestPayment,
        Func<TResult> onInterestPaymentCancellation,
        Func<TResult> onIntermediateSecuritiesDistribution,
        Func<TResult> onIntermediateSecuritiesDistributionCancellation,
        Func<TResult> onLiquidationPayment,
        Func<TResult> onLiquidationPaymentCancellation,
        Func<TResult> onMaturityExtension,
        Func<TResult> onMaturityExtensionCancellation,
        Func<TResult> onMerger,
        Func<TResult> onMergerCancellation,
        Func<TResult> onNonOfficialOffer,
        Func<TResult> onNonOfficialOfferCancellation,
        Func<TResult> onNonUsTefraDCertification,
        Func<TResult> onNonUsTefraDCertificationCancellation,
        Func<TResult> onOddLotSale,
        Func<TResult> onOddLotSaleCancellation,
        Func<TResult> onOrderExecution,
        Func<TResult> onOrderExecutionCancellation,
        Func<TResult> onOrdinaryGeneralMeeting,
        Func<TResult> onOrdinaryGeneralMeetingCancellation,
        Func<TResult> onOtherEvent,
        Func<TResult> onOtherEventCancellation,
        Func<TResult> onPariPassu,
        Func<TResult> onPariPassuCancellation,
        Func<TResult> onPartialDefeasance,
        Func<TResult> onPartialDefeasanceCancellation,
        Func<TResult> onPartialRedemptionWithPoolFactorReduction,
        Func<TResult> onPartialRedemptionWithPoolFactorReductionCancellation,
        Func<TResult> onPartialRedemptionWithoutPoolFactorReduction,
        Func<TResult> onPartialRedemptionWithoutPoolFactorReductionCancellation,
        Func<TResult> onPayInKind,
        Func<TResult> onPayInKindCancellation,
        Func<TResult> onPeakFractionCompensation,
        Func<TResult> onPeakOrderAdjustment,
        Func<TResult> onPlaceOfIncorporation,
        Func<TResult> onPlaceOfIncorporationCancellation,
        Func<TResult> onPriorityIssue,
        Func<TResult> onPriorityIssueCancellation,
        Func<TResult> onPutRedemption,
        Func<TResult> onPutRedemptionCancellation,
        Func<TResult> onRedenomination,
        Func<TResult> onRedenominationCancellation,
        Func<TResult> onRemarketingAgreement,
        Func<TResult> onRemarketingAgreementCancellation,
        Func<TResult> onRepurchaseOffer,
        Func<TResult> onRepurchaseOfferCancellation,
        Func<TResult> onReverseStockSplit,
        Func<TResult> onReverseStockSplitCancellation,
        Func<TResult> onRightsIssue,
        Func<TResult> onRightsIssueCancellation,
        Func<TResult> onScripDividend,
        Func<TResult> onScripDividendCancellation,
        Func<TResult> onSecuritiesTransfer,
        Func<TResult> onSecuritiesTransferCancellation,
        Func<TResult> onSharesPremiumDividend,
        Func<TResult> onSharesPremiumDividendCancellation,
        Func<TResult> onSmallestNegotiableUnit,
        Func<TResult> onSmallestNegotiableUnitCancellation,
        Func<TResult> onSpinOff,
        Func<TResult> onSpinOffCancellation,
        Func<TResult> onStockDividend,
        Func<TResult> onStockDividendCancellation,
        Func<TResult> onStockSplit,
        Func<TResult> onStockSplitCancellation,
        Func<TResult> onTaxOnNonDistributedProceeds,
        Func<TResult> onTaxOnNonDistributedProceedsCancellation,
        Func<TResult> onTaxReclaim,
        Func<TResult> onTaxReclaimCancellation,
        Func<TResult> onTender,
        Func<TResult> onTenderCancellation,
        Func<TResult> onTradingStatusActive,
        Func<TResult> onTradingStatusActiveCancellation,
        Func<TResult> onTradingStatusDelisted,
        Func<TResult> onTradingStatusDelistedCancellation,
        Func<TResult> onTradingStatusSuspended,
        Func<TResult> onTradingStatusSuspendedCancellation,
        Func<TResult> onVirtualCashCorrectionCancellation,
        Func<TResult> onWarrantExercise,
        Func<TResult> onWarrantExerciseCancellation,
        Func<TResult> onWithholdingTaxReliefCertification,
        Func<TResult> onWithholdingTaxReliefCertificationCancellation,
        Func<TResult> onWorthless,
        Func<TResult> onWorthlessCancellation,
        Func<TResult> onSecuritiesLending,
        Func<string, TResult> otherwise) =>
        this switch
        {
            _ when this == Accumulation => onAccumulation(),
            _ when this == AccumulationCancellation => onAccumulationCancellation(),
            _ when this == AnnualGeneralMeeting => onAnnualGeneralMeeting(),
            _ when this == AnnualGeneralMeetingCancellation => onAnnualGeneralMeetingCancellation(),
            _ when this == Attachment => onAttachment(),
            _ when this == AttachmentCancellation => onAttachmentCancellation(),
            _ when this == BalanceCorrection => onBalanceCorrection(),
            _ when this == BalanceCorrectionCancellation => onBalanceCorrectionCancellation(),
            _ when this == Bankruptcy => onBankruptcy(),
            _ when this == BankruptcyCancellation => onBankruptcyCancellation(),
            _ when this == BondDefault => onBondDefault(),
            _ when this == BondDefaultCancellation => onBondDefaultCancellation(),
            _ when this == BondHolderMeeting => onBondHolderMeeting(),
            _ when this == BondHolderMeetingCancellation => onBondHolderMeetingCancellation(),
            _ when this == BonusIssue => onBonusIssue(),
            _ when this == BonusIssueCancellation => onBonusIssueCancellation(),
            _ when this == CallOnIntermediateSecurities => onCallOnIntermediateSecurities(),
            _ when this == CallOnIntermediateSecuritiesCancellation => onCallOnIntermediateSecuritiesCancellation(),
            _ when this == CapitalDistribution => onCapitalDistribution(),
            _ when this == CapitalDistributionCancellation => onCapitalDistributionCancellation(),
            _ when this == CapitalGainsDistribution => onCapitalGainsDistribution(),
            _ when this == CapitalGainsDistributionCancellation => onCapitalGainsDistributionCancellation(),
            _ when this == Capitalisation => onCapitalisation(),
            _ when this == CapitalisationCancellation => onCapitalisationCancellation(),
            _ when this ==
                CashDistributionFromNonEligibleSecuritiesSales => onCashDistributionFromNonEligibleSecuritiesSales(),
            _ when this ==
                CashDistributionFromNonEligibleSecuritiesSalesCancellation => onCashDistributionFromNonEligibleSecuritiesSalesCancellation(),
            _ when this == CashDividend => onCashDividend(),
            _ when this == CashDividendCancellation => onCashDividendCancellation(),
            _ when this == Change => onChange(),
            _ when this == ChangeCancellation => onChangeCancellation(),
            _ when this == ClassAction => onClassAction(),
            _ when this == ClassActionCancellation => onClassActionCancellation(),
            _ when this == CompanyOption => onCompanyOption(),
            _ when this == CompanyOptionCancellation => onCompanyOptionCancellation(),
            _ when this == Consent => onConsent(),
            _ when this == ConsentCancellation => onConsentCancellation(),
            _ when this == Conversion => onConversion(),
            _ when this == ConversionCancellation => onConversionCancellation(),
            _ when this == CourtMeeting => onCourtMeeting(),
            _ when this == CourtMeetingCancellation => onCourtMeetingCancellation(),
            _ when this == CreditEvent => onCreditEvent(),
            _ when this == CreditEventCancellation => onCreditEventCancellation(),
            _ when this == DecreaseInValue => onDecreaseInValue(),
            _ when this == DecreaseInValueCancellation => onDecreaseInValueCancellation(),
            _ when this == Detachment => onDetachment(),
            _ when this == DetachmentCancellation => onDetachmentCancellation(),
            _ when this == Disclosure => onDisclosure(),
            _ when this == DisclosureCancellation => onDisclosureCancellation(),
            _ when this == DividendOption => onDividendOption(),
            _ when this == DividendOptionCancellation => onDividendOptionCancellation(),
            _ when this == DividendReinvestment => onDividendReinvestment(),
            _ when this == DividendReinvestmentCancellation => onDividendReinvestmentCancellation(),
            _ when this == Drawing => onDrawing(),
            _ when this == DrawingCancellation => onDrawingCancellation(),
            _ when this == DustCleanup => onDustCleanup(),
            _ when this == DutchAuction => onDutchAuction(),
            _ when this == DutchAuctionCancellation => onDutchAuctionCancellation(),
            _ when this == Exchange => onExchange(),
            _ when this == ExchangeCancellation => onExchangeCancellation(),
            _ when this == ExtraordinaryOrSpecialGeneralMeeting => onExtraordinaryOrSpecialGeneralMeeting(),
            _ when this ==
                ExtraordinaryOrSpecialGeneralMeetingCancellation => onExtraordinaryOrSpecialGeneralMeetingCancellation(),
            _ when this == FinalMaturity => onFinalMaturity(),
            _ when this == FinalMaturityCancellation => onFinalMaturityCancellation(),
            _ when this == FullCall => onFullCall(),
            _ when this == FullCallCancellation => onFullCallCancellation(),
            _ when this == IncreaseInValue => onIncreaseInValue(),
            _ when this == IncreaseInValueCancellation => onIncreaseInValueCancellation(),
            _ when this == Information => onInformation(),
            _ when this == InformationCancellation => onInformationCancellation(),
            _ when this == InstalmentCall => onInstalmentCall(),
            _ when this == InstalmentCallCancellation => onInstalmentCallCancellation(),
            _ when this == InterestPayment => onInterestPayment(),
            _ when this == InterestPaymentCancellation => onInterestPaymentCancellation(),
            _ when this == IntermediateSecuritiesDistribution => onIntermediateSecuritiesDistribution(),
            _ when this ==
                IntermediateSecuritiesDistributionCancellation => onIntermediateSecuritiesDistributionCancellation(),
            _ when this == LiquidationPayment => onLiquidationPayment(),
            _ when this == LiquidationPaymentCancellation => onLiquidationPaymentCancellation(),
            _ when this == MaturityExtension => onMaturityExtension(),
            _ when this == MaturityExtensionCancellation => onMaturityExtensionCancellation(),
            _ when this == Merger => onMerger(),
            _ when this == MergerCancellation => onMergerCancellation(),
            _ when this == NonOfficialOffer => onNonOfficialOffer(),
            _ when this == NonOfficialOfferCancellation => onNonOfficialOfferCancellation(),
            _ when this == NonUsTefraDCertification => onNonUsTefraDCertification(),
            _ when this == NonUsTefraDCertificationCancellation => onNonUsTefraDCertificationCancellation(),
            _ when this == OddLotSale => onOddLotSale(),
            _ when this == OddLotSaleCancellation => onOddLotSaleCancellation(),
            _ when this == OrderExecution => onOrderExecution(),
            _ when this == OrderExecutionCancellation => onOrderExecutionCancellation(),
            _ when this == OrdinaryGeneralMeeting => onOrdinaryGeneralMeeting(),
            _ when this == OrdinaryGeneralMeetingCancellation => onOrdinaryGeneralMeetingCancellation(),
            _ when this == OtherEvent => onOtherEvent(),
            _ when this == OtherEventCancellation => onOtherEventCancellation(),
            _ when this == PariPassu => onPariPassu(),
            _ when this == PariPassuCancellation => onPariPassuCancellation(),
            _ when this == PartialDefeasance => onPartialDefeasance(),
            _ when this == PartialDefeasanceCancellation => onPartialDefeasanceCancellation(),
            _ when this == PartialRedemptionWithPoolFactorReduction => onPartialRedemptionWithPoolFactorReduction(),
            _ when this ==
                PartialRedemptionWithPoolFactorReductionCancellation => onPartialRedemptionWithPoolFactorReductionCancellation(),
            _ when this ==
                PartialRedemptionWithoutPoolFactorReduction => onPartialRedemptionWithoutPoolFactorReduction(),
            _ when this ==
                PartialRedemptionWithoutPoolFactorReductionCancellation => onPartialRedemptionWithoutPoolFactorReductionCancellation(),
            _ when this == PayInKind => onPayInKind(),
            _ when this == PayInKindCancellation => onPayInKindCancellation(),
            _ when this == PeakFractionCompensation => onPeakFractionCompensation(),
            _ when this == PeakOrderAdjustment => onPeakOrderAdjustment(),
            _ when this == PlaceOfIncorporation => onPlaceOfIncorporation(),
            _ when this == PlaceOfIncorporationCancellation => onPlaceOfIncorporationCancellation(),
            _ when this == PriorityIssue => onPriorityIssue(),
            _ when this == PriorityIssueCancellation => onPriorityIssueCancellation(),
            _ when this == PutRedemption => onPutRedemption(),
            _ when this == PutRedemptionCancellation => onPutRedemptionCancellation(),
            _ when this == Redenomination => onRedenomination(),
            _ when this == RedenominationCancellation => onRedenominationCancellation(),
            _ when this == RemarketingAgreement => onRemarketingAgreement(),
            _ when this == RemarketingAgreementCancellation => onRemarketingAgreementCancellation(),
            _ when this == RepurchaseOffer => onRepurchaseOffer(),
            _ when this == RepurchaseOfferCancellation => onRepurchaseOfferCancellation(),
            _ when this == ReverseStockSplit => onReverseStockSplit(),
            _ when this == ReverseStockSplitCancellation => onReverseStockSplitCancellation(),
            _ when this == RightsIssue => onRightsIssue(),
            _ when this == RightsIssueCancellation => onRightsIssueCancellation(),
            _ when this == ScripDividend => onScripDividend(),
            _ when this == ScripDividendCancellation => onScripDividendCancellation(),
            _ when this == SecuritiesTransfer => onSecuritiesTransfer(),
            _ when this == SecuritiesTransferCancellation => onSecuritiesTransferCancellation(),
            _ when this == SharesPremiumDividend => onSharesPremiumDividend(),
            _ when this == SharesPremiumDividendCancellation => onSharesPremiumDividendCancellation(),
            _ when this == SmallestNegotiableUnit => onSmallestNegotiableUnit(),
            _ when this == SmallestNegotiableUnitCancellation => onSmallestNegotiableUnitCancellation(),
            _ when this == SpinOff => onSpinOff(),
            _ when this == SpinOffCancellation => onSpinOffCancellation(),
            _ when this == StockDividend => onStockDividend(),
            _ when this == StockDividendCancellation => onStockDividendCancellation(),
            _ when this == StockSplit => onStockSplit(),
            _ when this == StockSplitCancellation => onStockSplitCancellation(),
            _ when this == TaxOnNonDistributedProceeds => onTaxOnNonDistributedProceeds(),
            _ when this == TaxOnNonDistributedProceedsCancellation => onTaxOnNonDistributedProceedsCancellation(),
            _ when this == TaxReclaim => onTaxReclaim(),
            _ when this == TaxReclaimCancellation => onTaxReclaimCancellation(),
            _ when this == Tender => onTender(),
            _ when this == TenderCancellation => onTenderCancellation(),
            _ when this == TradingStatusActive => onTradingStatusActive(),
            _ when this == TradingStatusActiveCancellation => onTradingStatusActiveCancellation(),
            _ when this == TradingStatusDelisted => onTradingStatusDelisted(),
            _ when this == TradingStatusDelistedCancellation => onTradingStatusDelistedCancellation(),
            _ when this == TradingStatusSuspended => onTradingStatusSuspended(),
            _ when this == TradingStatusSuspendedCancellation => onTradingStatusSuspendedCancellation(),
            _ when this == VirtualCashCorrectionCancellation => onVirtualCashCorrectionCancellation(),
            _ when this == WarrantExercise => onWarrantExercise(),
            _ when this == WarrantExerciseCancellation => onWarrantExerciseCancellation(),
            _ when this == WithholdingTaxReliefCertification => onWithholdingTaxReliefCertification(),
            _ when this ==
                WithholdingTaxReliefCertificationCancellation => onWithholdingTaxReliefCertificationCancellation(),
            _ when this == Worthless => onWorthless(),
            _ when this == WorthlessCancellation => onWorthlessCancellation(),
            _ when this == SecuritiesLending => onSecuritiesLending(),
            _ => otherwise(Value)
        };

    public void Match(Action onAccumulation,
        Action onAccumulationCancellation,
        Action onAnnualGeneralMeeting,
        Action onAnnualGeneralMeetingCancellation,
        Action onAttachment,
        Action onAttachmentCancellation,
        Action onBalanceCorrection,
        Action onBalanceCorrectionCancellation,
        Action onBankruptcy,
        Action onBankruptcyCancellation,
        Action onBondDefault,
        Action onBondDefaultCancellation,
        Action onBondHolderMeeting,
        Action onBondHolderMeetingCancellation,
        Action onBonusIssue,
        Action onBonusIssueCancellation,
        Action onCallOnIntermediateSecurities,
        Action onCallOnIntermediateSecuritiesCancellation,
        Action onCapitalDistribution,
        Action onCapitalDistributionCancellation,
        Action onCapitalGainsDistribution,
        Action onCapitalGainsDistributionCancellation,
        Action onCapitalisation,
        Action onCapitalisationCancellation,
        Action onCashDistributionFromNonEligibleSecuritiesSales,
        Action onCashDistributionFromNonEligibleSecuritiesSalesCancellation,
        Action onCashDividend,
        Action onCashDividendCancellation,
        Action onChange,
        Action onChangeCancellation,
        Action onClassAction,
        Action onClassActionCancellation,
        Action onCompanyOption,
        Action onCompanyOptionCancellation,
        Action onConsent,
        Action onConsentCancellation,
        Action onConversion,
        Action onConversionCancellation,
        Action onCourtMeeting,
        Action onCourtMeetingCancellation,
        Action onCreditEvent,
        Action onCreditEventCancellation,
        Action onDecreaseInValue,
        Action onDecreaseInValueCancellation,
        Action onDetachment,
        Action onDetachmentCancellation,
        Action onDisclosure,
        Action onDisclosureCancellation,
        Action onDividendOption,
        Action onDividendOptionCancellation,
        Action onDividendReinvestment,
        Action onDividendReinvestmentCancellation,
        Action onDrawing,
        Action onDrawingCancellation,
        Action onDustCleanup,
        Action onDutchAuction,
        Action onDutchAuctionCancellation,
        Action onExchange,
        Action onExchangeCancellation,
        Action onExtraordinaryOrSpecialGeneralMeeting,
        Action onExtraordinaryOrSpecialGeneralMeetingCancellation,
        Action onFinalMaturity,
        Action onFinalMaturityCancellation,
        Action onFullCall,
        Action onFullCallCancellation,
        Action onIncreaseInValue,
        Action onIncreaseInValueCancellation,
        Action onInformation,
        Action onInformationCancellation,
        Action onInstalmentCall,
        Action onInstalmentCallCancellation,
        Action onInterestPayment,
        Action onInterestPaymentCancellation,
        Action onIntermediateSecuritiesDistribution,
        Action onIntermediateSecuritiesDistributionCancellation,
        Action onLiquidationPayment,
        Action onLiquidationPaymentCancellation,
        Action onMaturityExtension,
        Action onMaturityExtensionCancellation,
        Action onMerger,
        Action onMergerCancellation,
        Action onNonOfficialOffer,
        Action onNonOfficialOfferCancellation,
        Action onNonUsTefraDCertification,
        Action onNonUsTefraDCertificationCancellation,
        Action onOddLotSale,
        Action onOddLotSaleCancellation,
        Action onOrderExecution,
        Action onOrderExecutionCancellation,
        Action onOrdinaryGeneralMeeting,
        Action onOrdinaryGeneralMeetingCancellation,
        Action onOtherEvent,
        Action onOtherEventCancellation,
        Action onPariPassu,
        Action onPariPassuCancellation,
        Action onPartialDefeasance,
        Action onPartialDefeasanceCancellation,
        Action onPartialRedemptionWithPoolFactorReduction,
        Action onPartialRedemptionWithPoolFactorReductionCancellation,
        Action onPartialRedemptionWithoutPoolFactorReduction,
        Action onPartialRedemptionWithoutPoolFactorReductionCancellation,
        Action onPayInKind,
        Action onPayInKindCancellation,
        Action onPeakFractionCompensation,
        Action onPeakOrderAdjustment,
        Action onPlaceOfIncorporation,
        Action onPlaceOfIncorporationCancellation,
        Action onPriorityIssue,
        Action onPriorityIssueCancellation,
        Action onPutRedemption,
        Action onPutRedemptionCancellation,
        Action onRedenomination,
        Action onRedenominationCancellation,
        Action onRemarketingAgreement,
        Action onRemarketingAgreementCancellation,
        Action onRepurchaseOffer,
        Action onRepurchaseOfferCancellation,
        Action onReverseStockSplit,
        Action onReverseStockSplitCancellation,
        Action onRightsIssue,
        Action onRightsIssueCancellation,
        Action onScripDividend,
        Action onScripDividendCancellation,
        Action onSecuritiesTransfer,
        Action onSecuritiesTransferCancellation,
        Action onSharesPremiumDividend,
        Action onSharesPremiumDividendCancellation,
        Action onSmallestNegotiableUnit,
        Action onSmallestNegotiableUnitCancellation,
        Action onSpinOff,
        Action onSpinOffCancellation,
        Action onStockDividend,
        Action onStockDividendCancellation,
        Action onStockSplit,
        Action onStockSplitCancellation,
        Action onTaxOnNonDistributedProceeds,
        Action onTaxOnNonDistributedProceedsCancellation,
        Action onTaxReclaim,
        Action onTaxReclaimCancellation,
        Action onTender,
        Action onTenderCancellation,
        Action onTradingStatusActive,
        Action onTradingStatusActiveCancellation,
        Action onTradingStatusDelisted,
        Action onTradingStatusDelistedCancellation,
        Action onTradingStatusSuspended,
        Action onTradingStatusSuspendedCancellation,
        Action onVirtualCashCorrectionCancellation,
        Action onWarrantExercise,
        Action onWarrantExerciseCancellation,
        Action onWithholdingTaxReliefCertification,
        Action onWithholdingTaxReliefCertificationCancellation,
        Action onWorthless,
        Action onWorthlessCancellation,
        Action onSecuritiesLending,
        Action<string> otherwise)
    {
        if (this == Accumulation) onAccumulation();
        else if (this == AccumulationCancellation) onAccumulationCancellation();
        else if (this == AnnualGeneralMeeting) onAnnualGeneralMeeting();
        else if (this == AnnualGeneralMeetingCancellation) onAnnualGeneralMeetingCancellation();
        else if (this == Attachment) onAttachment();
        else if (this == AttachmentCancellation) onAttachmentCancellation();
        else if (this == BalanceCorrection) onBalanceCorrection();
        else if (this == BalanceCorrectionCancellation) onBalanceCorrectionCancellation();
        else if (this == Bankruptcy) onBankruptcy();
        else if (this == BankruptcyCancellation) onBankruptcyCancellation();
        else if (this == BondDefault) onBondDefault();
        else if (this == BondDefaultCancellation) onBondDefaultCancellation();
        else if (this == BondHolderMeeting) onBondHolderMeeting();
        else if (this == BondHolderMeetingCancellation) onBondHolderMeetingCancellation();
        else if (this == BonusIssue) onBonusIssue();
        else if (this == BonusIssueCancellation) onBonusIssueCancellation();
        else if (this == CallOnIntermediateSecurities) onCallOnIntermediateSecurities();
        else if (this == CallOnIntermediateSecuritiesCancellation) onCallOnIntermediateSecuritiesCancellation();
        else if (this == CapitalDistribution) onCapitalDistribution();
        else if (this == CapitalDistributionCancellation) onCapitalDistributionCancellation();
        else if (this == CapitalGainsDistribution) onCapitalGainsDistribution();
        else if (this == CapitalGainsDistributionCancellation) onCapitalGainsDistributionCancellation();
        else if (this == Capitalisation) onCapitalisation();
        else if (this == CapitalisationCancellation) onCapitalisationCancellation();
        else if (this ==
            CashDistributionFromNonEligibleSecuritiesSales) onCashDistributionFromNonEligibleSecuritiesSales();
        else if (this ==
            CashDistributionFromNonEligibleSecuritiesSalesCancellation) onCashDistributionFromNonEligibleSecuritiesSalesCancellation();
        else if (this == CashDividend) onCashDividend();
        else if (this == CashDividendCancellation) onCashDividendCancellation();
        else if (this == Change) onChange();
        else if (this == ChangeCancellation) onChangeCancellation();
        else if (this == ClassAction) onClassAction();
        else if (this == ClassActionCancellation) onClassActionCancellation();
        else if (this == CompanyOption) onCompanyOption();
        else if (this == CompanyOptionCancellation) onCompanyOptionCancellation();
        else if (this == Consent) onConsent();
        else if (this == ConsentCancellation) onConsentCancellation();
        else if (this == Conversion) onConversion();
        else if (this == ConversionCancellation) onConversionCancellation();
        else if (this == CourtMeeting) onCourtMeeting();
        else if (this == CourtMeetingCancellation) onCourtMeetingCancellation();
        else if (this == CreditEvent) onCreditEvent();
        else if (this == CreditEventCancellation) onCreditEventCancellation();
        else if (this == DecreaseInValue) onDecreaseInValue();
        else if (this == DecreaseInValueCancellation) onDecreaseInValueCancellation();
        else if (this == Detachment) onDetachment();
        else if (this == DetachmentCancellation) onDetachmentCancellation();
        else if (this == Disclosure) onDisclosure();
        else if (this == DisclosureCancellation) onDisclosureCancellation();
        else if (this == DividendOption) onDividendOption();
        else if (this == DividendOptionCancellation) onDividendOptionCancellation();
        else if (this == DividendReinvestment) onDividendReinvestment();
        else if (this == DividendReinvestmentCancellation) onDividendReinvestmentCancellation();
        else if (this == Drawing) onDrawing();
        else if (this == DrawingCancellation) onDrawingCancellation();
        else if (this == DustCleanup) onDustCleanup();
        else if (this == DutchAuction) onDutchAuction();
        else if (this == DutchAuctionCancellation) onDutchAuctionCancellation();
        else if (this == Exchange) onExchange();
        else if (this == ExchangeCancellation) onExchangeCancellation();
        else if (this == ExtraordinaryOrSpecialGeneralMeeting) onExtraordinaryOrSpecialGeneralMeeting();
        else if (this ==
            ExtraordinaryOrSpecialGeneralMeetingCancellation) onExtraordinaryOrSpecialGeneralMeetingCancellation();
        else if (this == FinalMaturity) onFinalMaturity();
        else if (this == FinalMaturityCancellation) onFinalMaturityCancellation();
        else if (this == FullCall) onFullCall();
        else if (this == FullCallCancellation) onFullCallCancellation();
        else if (this == IncreaseInValue) onIncreaseInValue();
        else if (this == IncreaseInValueCancellation) onIncreaseInValueCancellation();
        else if (this == Information) onInformation();
        else if (this == InformationCancellation) onInformationCancellation();
        else if (this == InstalmentCall) onInstalmentCall();
        else if (this == InstalmentCallCancellation) onInstalmentCallCancellation();
        else if (this == InterestPayment) onInterestPayment();
        else if (this == InterestPaymentCancellation) onInterestPaymentCancellation();
        else if (this == IntermediateSecuritiesDistribution) onIntermediateSecuritiesDistribution();
        else if (this ==
            IntermediateSecuritiesDistributionCancellation) onIntermediateSecuritiesDistributionCancellation();
        else if (this == LiquidationPayment) onLiquidationPayment();
        else if (this == LiquidationPaymentCancellation) onLiquidationPaymentCancellation();
        else if (this == MaturityExtension) onMaturityExtension();
        else if (this == MaturityExtensionCancellation) onMaturityExtensionCancellation();
        else if (this == Merger) onMerger();
        else if (this == MergerCancellation) onMergerCancellation();
        else if (this == NonOfficialOffer) onNonOfficialOffer();
        else if (this == NonOfficialOfferCancellation) onNonOfficialOfferCancellation();
        else if (this == NonUsTefraDCertification) onNonUsTefraDCertification();
        else if (this == NonUsTefraDCertificationCancellation) onNonUsTefraDCertificationCancellation();
        else if (this == OddLotSale) onOddLotSale();
        else if (this == OddLotSaleCancellation) onOddLotSaleCancellation();
        else if (this == OrderExecution) onOrderExecution();
        else if (this == OrderExecutionCancellation) onOrderExecutionCancellation();
        else if (this == OrdinaryGeneralMeeting) onOrdinaryGeneralMeeting();
        else if (this == OrdinaryGeneralMeetingCancellation) onOrdinaryGeneralMeetingCancellation();
        else if (this == OtherEvent) onOtherEvent();
        else if (this == OtherEventCancellation) onOtherEventCancellation();
        else if (this == PariPassu) onPariPassu();
        else if (this == PariPassuCancellation) onPariPassuCancellation();
        else if (this == PartialDefeasance) onPartialDefeasance();
        else if (this == PartialDefeasanceCancellation) onPartialDefeasanceCancellation();
        else if (this == PartialRedemptionWithPoolFactorReduction) onPartialRedemptionWithPoolFactorReduction();
        else if (this ==
            PartialRedemptionWithPoolFactorReductionCancellation) onPartialRedemptionWithPoolFactorReductionCancellation();
        else if (this == PartialRedemptionWithoutPoolFactorReduction) onPartialRedemptionWithoutPoolFactorReduction();
        else if (this ==
            PartialRedemptionWithoutPoolFactorReductionCancellation) onPartialRedemptionWithoutPoolFactorReductionCancellation();
        else if (this == PayInKind) onPayInKind();
        else if (this == PayInKindCancellation) onPayInKindCancellation();
        else if (this == PeakFractionCompensation) onPeakFractionCompensation();
        else if (this == PeakOrderAdjustment) onPeakOrderAdjustment();
        else if (this == PlaceOfIncorporation) onPlaceOfIncorporation();
        else if (this == PlaceOfIncorporationCancellation) onPlaceOfIncorporationCancellation();
        else if (this == PriorityIssue) onPriorityIssue();
        else if (this == PriorityIssueCancellation) onPriorityIssueCancellation();
        else if (this == PutRedemption) onPutRedemption();
        else if (this == PutRedemptionCancellation) onPutRedemptionCancellation();
        else if (this == Redenomination) onRedenomination();
        else if (this == RedenominationCancellation) onRedenominationCancellation();
        else if (this == RemarketingAgreement) onRemarketingAgreement();
        else if (this == RemarketingAgreementCancellation) onRemarketingAgreementCancellation();
        else if (this == RepurchaseOffer) onRepurchaseOffer();
        else if (this == RepurchaseOfferCancellation) onRepurchaseOfferCancellation();
        else if (this == ReverseStockSplit) onReverseStockSplit();
        else if (this == ReverseStockSplitCancellation) onReverseStockSplitCancellation();
        else if (this == RightsIssue) onRightsIssue();
        else if (this == RightsIssueCancellation) onRightsIssueCancellation();
        else if (this == ScripDividend) onScripDividend();
        else if (this == ScripDividendCancellation) onScripDividendCancellation();
        else if (this == SecuritiesTransfer) onSecuritiesTransfer();
        else if (this == SecuritiesTransferCancellation) onSecuritiesTransferCancellation();
        else if (this == SharesPremiumDividend) onSharesPremiumDividend();
        else if (this == SharesPremiumDividendCancellation) onSharesPremiumDividendCancellation();
        else if (this == SmallestNegotiableUnit) onSmallestNegotiableUnit();
        else if (this == SmallestNegotiableUnitCancellation) onSmallestNegotiableUnitCancellation();
        else if (this == SpinOff) onSpinOff();
        else if (this == SpinOffCancellation) onSpinOffCancellation();
        else if (this == StockDividend) onStockDividend();
        else if (this == StockDividendCancellation) onStockDividendCancellation();
        else if (this == StockSplit) onStockSplit();
        else if (this == StockSplitCancellation) onStockSplitCancellation();
        else if (this == TaxOnNonDistributedProceeds) onTaxOnNonDistributedProceeds();
        else if (this == TaxOnNonDistributedProceedsCancellation) onTaxOnNonDistributedProceedsCancellation();
        else if (this == TaxReclaim) onTaxReclaim();
        else if (this == TaxReclaimCancellation) onTaxReclaimCancellation();
        else if (this == Tender) onTender();
        else if (this == TenderCancellation) onTenderCancellation();
        else if (this == TradingStatusActive) onTradingStatusActive();
        else if (this == TradingStatusActiveCancellation) onTradingStatusActiveCancellation();
        else if (this == TradingStatusDelisted) onTradingStatusDelisted();
        else if (this == TradingStatusDelistedCancellation) onTradingStatusDelistedCancellation();
        else if (this == TradingStatusSuspended) onTradingStatusSuspended();
        else if (this == TradingStatusSuspendedCancellation) onTradingStatusSuspendedCancellation();
        else if (this == VirtualCashCorrectionCancellation) onVirtualCashCorrectionCancellation();
        else if (this == WarrantExercise) onWarrantExercise();
        else if (this == WarrantExerciseCancellation) onWarrantExerciseCancellation();
        else if (this == WithholdingTaxReliefCertification) onWithholdingTaxReliefCertification();
        else if (this ==
            WithholdingTaxReliefCertificationCancellation) onWithholdingTaxReliefCertificationCancellation();
        else if (this == Worthless) onWorthless();
        else if (this == WorthlessCancellation) onWorthlessCancellation();
        else if (this == SecuritiesLending) onSecuritiesLending();
        else otherwise(Value);
    }
}
