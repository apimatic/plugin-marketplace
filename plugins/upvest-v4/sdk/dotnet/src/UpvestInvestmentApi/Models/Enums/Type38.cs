using System;
using System.Text.Json.Serialization;
using UpvestInvestmentApi.Core.Enum;

namespace UpvestInvestmentApi.Models.Enums;

/// <summary>
/// The kind of fee this component represents.
/// * TRANSACTION_LUMP_SUM — Lump sum transaction fee.
/// * PLATFORM — Platform fee.
/// * SERVICE — Service fee for a client portfolio.
/// * VAT — Value-added tax.
/// * CUSTODY — Custody fee.
/// </summary>
[JsonConverter(typeof(StringEnumConverter<Type38>))]
public sealed record Type38 : OpenStringEnum<Type38>
{
    private Type38(string value) : base(value)
    {
    }

    public static readonly Type38 TransactionLumpSum = new("TRANSACTION_LUMP_SUM");

    public static readonly Type38 Platform = new("PLATFORM");

    public static readonly Type38 Service = new("SERVICE");

    public static readonly Type38 Vat = new("VAT");

    public static readonly Type38 Custody = new("CUSTODY");

    public TResult Match<TResult>(Func<TResult> onTransactionLumpSum,
        Func<TResult> onPlatform,
        Func<TResult> onService,
        Func<TResult> onVat,
        Func<TResult> onCustody,
        Func<string, TResult> otherwise) =>
        this switch
        {
            _ when this == TransactionLumpSum => onTransactionLumpSum(),
            _ when this == Platform => onPlatform(),
            _ when this == Service => onService(),
            _ when this == Vat => onVat(),
            _ when this == Custody => onCustody(),
            _ => otherwise(Value)
        };

    public void Match(Action onTransactionLumpSum,
        Action onPlatform,
        Action onService,
        Action onVat,
        Action onCustody,
        Action<string> otherwise)
    {
        if (this == TransactionLumpSum) onTransactionLumpSum();
        else if (this == Platform) onPlatform();
        else if (this == Service) onService();
        else if (this == Vat) onVat();
        else if (this == Custody) onCustody();
        else otherwise(Value);
    }
}
