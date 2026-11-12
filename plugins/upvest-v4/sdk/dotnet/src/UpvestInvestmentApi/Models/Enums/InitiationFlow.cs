using System;
using System.Text.Json.Serialization;
using UpvestInvestmentApi.Core.Enum;

namespace UpvestInvestmentApi.Models.Enums;

/// <summary>
/// Identifies what triggered the order.
/// * API — initiated directly via the client API.
/// * PORTFOLIO — initiated by a portfolio order.
/// * CASH_DIVIDEND_REINVESTMENT — initiated as part of dividend reinvestment.
/// * PORTFOLIO_REBALANCING — initiated by an automated rebalancing.
/// * SELL_TO_COVER_FEES — initiated automatically to cover outstanding fees.
/// * SELL_TO_COVER_TAXES — initiated automatically to cover tax obligations.
/// * ACCOUNT_LIQUIDATION — initiated as part of an account liquidation.
/// * UPVEST_OPERATIONS — initiated by Upvest operations.
/// * SAVINGS_PLAN — initiated by a savings plan execution.
/// * CLIENT_OPERATIONS — initiated by client operations.
/// * AUTO_INVESTMENT — initiated automatically by auto-investment to invest incoming cash, for example a cash dividend.
/// * PORTFOLIO_SAVINGS_PLAN — initiated by a savings plan execution for a portfolio.
/// * PORTFOLIO_AUTO_INVESTMENT — initiated by a portfolio order that auto-investment created to invest incoming cash, for example a cash dividend.
/// </summary>
[JsonConverter(typeof(StringEnumConverter<InitiationFlow>))]
public sealed record InitiationFlow : OpenStringEnum<InitiationFlow>
{
    private InitiationFlow(string value) : base(value)
    {
    }

    public static readonly InitiationFlow Api = new("API");

    public static readonly InitiationFlow Portfolio = new("PORTFOLIO");

    public static readonly InitiationFlow CashDividendReinvestment = new("CASH_DIVIDEND_REINVESTMENT");

    public static readonly InitiationFlow PortfolioRebalancing = new("PORTFOLIO_REBALANCING");

    public static readonly InitiationFlow SellToCoverFees = new("SELL_TO_COVER_FEES");

    public static readonly InitiationFlow SellToCoverTaxes = new("SELL_TO_COVER_TAXES");

    public static readonly InitiationFlow AccountLiquidation = new("ACCOUNT_LIQUIDATION");

    public static readonly InitiationFlow UpvestOperations = new("UPVEST_OPERATIONS");

    public static readonly InitiationFlow SavingsPlan = new("SAVINGS_PLAN");

    public static readonly InitiationFlow ClientOperations = new("CLIENT_OPERATIONS");

    public static readonly InitiationFlow AutoInvestment = new("AUTO_INVESTMENT");

    public static readonly InitiationFlow PortfolioSavingsPlan = new("PORTFOLIO_SAVINGS_PLAN");

    public static readonly InitiationFlow PortfolioAutoInvestment = new("PORTFOLIO_AUTO_INVESTMENT");

    public TResult Match<TResult>(Func<TResult> onApi,
        Func<TResult> onPortfolio,
        Func<TResult> onCashDividendReinvestment,
        Func<TResult> onPortfolioRebalancing,
        Func<TResult> onSellToCoverFees,
        Func<TResult> onSellToCoverTaxes,
        Func<TResult> onAccountLiquidation,
        Func<TResult> onUpvestOperations,
        Func<TResult> onSavingsPlan,
        Func<TResult> onClientOperations,
        Func<TResult> onAutoInvestment,
        Func<TResult> onPortfolioSavingsPlan,
        Func<TResult> onPortfolioAutoInvestment,
        Func<string, TResult> otherwise) =>
        this switch
        {
            _ when this == Api => onApi(),
            _ when this == Portfolio => onPortfolio(),
            _ when this == CashDividendReinvestment => onCashDividendReinvestment(),
            _ when this == PortfolioRebalancing => onPortfolioRebalancing(),
            _ when this == SellToCoverFees => onSellToCoverFees(),
            _ when this == SellToCoverTaxes => onSellToCoverTaxes(),
            _ when this == AccountLiquidation => onAccountLiquidation(),
            _ when this == UpvestOperations => onUpvestOperations(),
            _ when this == SavingsPlan => onSavingsPlan(),
            _ when this == ClientOperations => onClientOperations(),
            _ when this == AutoInvestment => onAutoInvestment(),
            _ when this == PortfolioSavingsPlan => onPortfolioSavingsPlan(),
            _ when this == PortfolioAutoInvestment => onPortfolioAutoInvestment(),
            _ => otherwise(Value)
        };

    public void Match(Action onApi,
        Action onPortfolio,
        Action onCashDividendReinvestment,
        Action onPortfolioRebalancing,
        Action onSellToCoverFees,
        Action onSellToCoverTaxes,
        Action onAccountLiquidation,
        Action onUpvestOperations,
        Action onSavingsPlan,
        Action onClientOperations,
        Action onAutoInvestment,
        Action onPortfolioSavingsPlan,
        Action onPortfolioAutoInvestment,
        Action<string> otherwise)
    {
        if (this == Api) onApi();
        else if (this == Portfolio) onPortfolio();
        else if (this == CashDividendReinvestment) onCashDividendReinvestment();
        else if (this == PortfolioRebalancing) onPortfolioRebalancing();
        else if (this == SellToCoverFees) onSellToCoverFees();
        else if (this == SellToCoverTaxes) onSellToCoverTaxes();
        else if (this == AccountLiquidation) onAccountLiquidation();
        else if (this == UpvestOperations) onUpvestOperations();
        else if (this == SavingsPlan) onSavingsPlan();
        else if (this == ClientOperations) onClientOperations();
        else if (this == AutoInvestment) onAutoInvestment();
        else if (this == PortfolioSavingsPlan) onPortfolioSavingsPlan();
        else if (this == PortfolioAutoInvestment) onPortfolioAutoInvestment();
        else otherwise(Value);
    }
}
