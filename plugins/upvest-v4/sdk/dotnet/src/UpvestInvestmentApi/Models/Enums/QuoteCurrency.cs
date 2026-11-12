using System;
using System.Text.Json.Serialization;
using UpvestInvestmentApi.Core.Enum;

namespace UpvestInvestmentApi.Models.Enums;

/// <summary>
/// Alphabetic three-letter <see href="https://www.iso.org/iso-4217-currency-codes.html">ISO 4217</see> currency code.
/// * EUR — Euro.
/// * GBP — Pound Sterling.
/// * USD — The United States dollar.
/// </summary>
[JsonConverter(typeof(StringEnumConverter<QuoteCurrency>))]
public sealed record QuoteCurrency : OpenStringEnum<QuoteCurrency>
{
    private QuoteCurrency(string value) : base(value)
    {
    }

    public static readonly QuoteCurrency Eur = new("EUR");

    public static readonly QuoteCurrency Gbp = new("GBP");

    public static readonly QuoteCurrency Usd = new("USD");

    public TResult Match<TResult>(Func<TResult> onEur,
        Func<TResult> onGbp,
        Func<TResult> onUsd,
        Func<string, TResult> otherwise) =>
        this switch
        {
            _ when this == Eur => onEur(),
            _ when this == Gbp => onGbp(),
            _ when this == Usd => onUsd(),
            _ => otherwise(Value)
        };

    public void Match(Action onEur, Action onGbp, Action onUsd, Action<string> otherwise)
    {
        if (this == Eur) onEur();
        else if (this == Gbp) onGbp();
        else if (this == Usd) onUsd();
        else otherwise(Value);
    }
}
