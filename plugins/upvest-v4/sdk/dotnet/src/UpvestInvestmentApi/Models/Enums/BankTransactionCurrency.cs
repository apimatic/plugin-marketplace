using System;
using System.Text.Json.Serialization;
using UpvestInvestmentApi.Core.Enum;

namespace UpvestInvestmentApi.Models.Enums;

/// <summary>
/// Alphabetic three-letter <see href="https://www.iso.org/iso-4217-currency-codes.html">ISO 4217</see> currency code
/// </summary>
[JsonConverter(typeof(StringEnumConverter<BankTransactionCurrency>))]
public sealed record BankTransactionCurrency : OpenStringEnum<BankTransactionCurrency>
{
    private BankTransactionCurrency(string value) : base(value)
    {
    }

    public static readonly BankTransactionCurrency Eur = new("EUR");

    public static readonly BankTransactionCurrency Gbp = new("GBP");

    public static readonly BankTransactionCurrency Usd = new("USD");

    public static readonly BankTransactionCurrency Jpy = new("JPY");

    public static readonly BankTransactionCurrency Chf = new("CHF");

    public TResult Match<TResult>(Func<TResult> onEur,
        Func<TResult> onGbp,
        Func<TResult> onUsd,
        Func<TResult> onJpy,
        Func<TResult> onChf,
        Func<string, TResult> otherwise) =>
        this switch
        {
            _ when this == Eur => onEur(),
            _ when this == Gbp => onGbp(),
            _ when this == Usd => onUsd(),
            _ when this == Jpy => onJpy(),
            _ when this == Chf => onChf(),
            _ => otherwise(Value)
        };

    public void Match(Action onEur, Action onGbp, Action onUsd, Action onJpy, Action onChf, Action<string> otherwise)
    {
        if (this == Eur) onEur();
        else if (this == Gbp) onGbp();
        else if (this == Usd) onUsd();
        else if (this == Jpy) onJpy();
        else if (this == Chf) onChf();
        else otherwise(Value);
    }
}
