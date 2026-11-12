using System;
using System.Text.Json.Serialization;
using UpvestInvestmentApi.Core.Enum;

namespace UpvestInvestmentApi.Models.Enums;

/// <summary>
/// Account type.
/// * TRADING - Orders in accounts of this type are created on a specific instrument basis.
/// * PORTFOLIO - Orders in accounts of this type are created on a portfolio basis and additional portfolio functionality is available.
/// </summary>
[JsonConverter(typeof(StringEnumConverter<Type16>))]
public sealed record Type16 : OpenStringEnum<Type16>
{
    private Type16(string value) : base(value)
    {
    }

    public static readonly Type16 Trading = new("TRADING");

    public static readonly Type16 Portfolio = new("PORTFOLIO");

    public TResult Match<TResult>(Func<TResult> onTrading,
        Func<TResult> onPortfolio,
        Func<string, TResult> otherwise) =>
        this switch
        {
            _ when this == Trading => onTrading(),
            _ when this == Portfolio => onPortfolio(),
            _ => otherwise(Value)
        };

    public void Match(Action onTrading, Action onPortfolio, Action<string> otherwise)
    {
        if (this == Trading) onTrading();
        else if (this == Portfolio) onPortfolio();
        else otherwise(Value);
    }
}
