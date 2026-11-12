using System;
using System.Text.Json.Serialization;
using UpvestInvestmentApi.Core.Enum;

namespace UpvestInvestmentApi.Models.Enums;

/// <summary>
/// The value type of the transaction fee model.
/// * <c>ABSOLUTE</c> — Tier fees are fixed cash amounts.
/// * <c>RELATIVE</c> — Tier fees are percentages of the order value, expressed in basis points.
/// </summary>
[JsonConverter(typeof(StringEnumConverter<ValueTypeEnum>))]
public sealed record ValueTypeEnum : OpenStringEnum<ValueTypeEnum>
{
    private ValueTypeEnum(string value) : base(value)
    {
    }

    public static readonly ValueTypeEnum Absolute = new("ABSOLUTE");

    public static readonly ValueTypeEnum Relative = new("RELATIVE");

    public TResult Match<TResult>(Func<TResult> onAbsolute,
        Func<TResult> onRelative,
        Func<string, TResult> otherwise) =>
        this switch
        {
            _ when this == Absolute => onAbsolute(),
            _ when this == Relative => onRelative(),
            _ => otherwise(Value)
        };

    public void Match(Action onAbsolute, Action onRelative, Action<string> otherwise)
    {
        if (this == Absolute) onAbsolute();
        else if (this == Relative) onRelative();
        else otherwise(Value);
    }
}
