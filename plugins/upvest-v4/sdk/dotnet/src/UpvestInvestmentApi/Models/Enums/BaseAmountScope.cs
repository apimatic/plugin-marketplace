using System;
using System.Text.Json.Serialization;
using UpvestInvestmentApi.Core.Enum;

namespace UpvestInvestmentApi.Models.Enums;

/// <summary>
/// The scope of the base amount that fee tiers are evaluated against.
/// * <c>GROSS_AMOUNT</c> — Tiers are evaluated against the gross cash amount of the transaction the fee model is applied to (e.g. the total cash value of an order, a contribution or a transfer).
/// * <c>ORDER</c> — Tiers are evaluated against the total cash value of each order. DEPRECATED: Use <c>GROSS_AMOUNT</c> instead. Existing fee models using <c>ORDER</c> continue to work unchanged.
/// </summary>
[JsonConverter(typeof(StringEnumConverter<BaseAmountScope>))]
public sealed record BaseAmountScope : OpenStringEnum<BaseAmountScope>
{
    private BaseAmountScope(string value) : base(value)
    {
    }

    public static readonly BaseAmountScope GrossAmount = new("GROSS_AMOUNT");

    public static readonly BaseAmountScope Order = new("ORDER");

    public TResult Match<TResult>(Func<TResult> onGrossAmount,
        Func<TResult> onOrder,
        Func<string, TResult> otherwise) =>
        this switch
        {
            _ when this == GrossAmount => onGrossAmount(),
            _ when this == Order => onOrder(),
            _ => otherwise(Value)
        };

    public void Match(Action onGrossAmount, Action onOrder, Action<string> otherwise)
    {
        if (this == GrossAmount) onGrossAmount();
        else if (this == Order) onOrder();
        else otherwise(Value);
    }
}
