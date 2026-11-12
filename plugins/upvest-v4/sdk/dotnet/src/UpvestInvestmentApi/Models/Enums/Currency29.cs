using System;
using System.Text.Json.Serialization;
using UpvestInvestmentApi.Core.Enum;

namespace UpvestInvestmentApi.Models.Enums;

/// <summary>
/// Alphabetic three-letter <see href="https://www.iso.org/iso-4217-currency-codes.html">ISO 4217</see> currency code.
/// * EUR - Euro
/// * GBP - British Pound
/// * USD - US Dollar
/// </summary>
[JsonConverter(typeof(StringEnumConverter<Currency29>))]
public sealed record Currency29 : OpenStringEnum<Currency29>
{
    private Currency29(string value) : base(value)
    {
    }

    public static readonly Currency29 Eur = new("EUR");

    public static readonly Currency29 Gbp = new("GBP");

    public static readonly Currency29 Usd = new("USD");

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
