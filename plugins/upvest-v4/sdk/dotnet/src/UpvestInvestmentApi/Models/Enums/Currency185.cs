using System;
using System.Text.Json.Serialization;
using UpvestInvestmentApi.Core.Enum;

namespace UpvestInvestmentApi.Models.Enums;

/// <summary>
/// Alphabetic three-letter <see href="https://www.iso.org/iso-4217-currency-codes.html">ISO 4217</see> currency code.
/// * <c>EUR</c> — Euro.
/// * <c>GBP</c> — Pound sterling.
/// </summary>
[JsonConverter(typeof(StringEnumConverter<Currency185>))]
public sealed record Currency185 : OpenStringEnum<Currency185>
{
    private Currency185(string value) : base(value)
    {
    }

    public static readonly Currency185 Eur = new("EUR");

    public static readonly Currency185 Gbp = new("GBP");

    public TResult Match<TResult>(Func<TResult> onEur, Func<TResult> onGbp, Func<string, TResult> otherwise) =>
        this switch
        {
            _ when this == Eur => onEur(),
            _ when this == Gbp => onGbp(),
            _ => otherwise(Value)
        };

    public void Match(Action onEur, Action onGbp, Action<string> otherwise)
    {
        if (this == Eur) onEur();
        else if (this == Gbp) onGbp();
        else otherwise(Value);
    }
}
