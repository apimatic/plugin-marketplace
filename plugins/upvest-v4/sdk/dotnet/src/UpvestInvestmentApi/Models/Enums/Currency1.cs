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
[JsonConverter(typeof(StringEnumConverter<Currency1>))]
public sealed record Currency1 : OpenStringEnum<Currency1>
{
    private Currency1(string value) : base(value)
    {
    }

    public static readonly Currency1 Eur = new("EUR");

    public static readonly Currency1 Gbp = new("GBP");

    public static readonly Currency1 Usd = new("USD");

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
