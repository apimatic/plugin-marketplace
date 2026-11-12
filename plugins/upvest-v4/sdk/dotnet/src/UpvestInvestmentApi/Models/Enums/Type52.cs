using System;
using System.Text.Json.Serialization;
using UpvestInvestmentApi.Core.Enum;

namespace UpvestInvestmentApi.Models.Enums;

/// <summary>
/// Type of identification.
/// * <c>BIC</c> - Party identified by BIC.
/// * <c>PROPRIETARY</c> - Party identified by a proprietary code under a Data Source Scheme.
/// * <c>NAME_AND_ADDRESS</c> - Party identified by name and address.
/// </summary>
[JsonConverter(typeof(StringEnumConverter<Type52>))]
public sealed record Type52 : OpenStringEnum<Type52>
{
    private Type52(string value) : base(value)
    {
    }

    public static readonly Type52 Bic = new("BIC");

    public static readonly Type52 Proprietary = new("PROPRIETARY");

    public static readonly Type52 NameAndAddress = new("NAME_AND_ADDRESS");

    public TResult Match<TResult>(Func<TResult> onBic,
        Func<TResult> onProprietary,
        Func<TResult> onNameAndAddress,
        Func<string, TResult> otherwise) =>
        this switch
        {
            _ when this == Bic => onBic(),
            _ when this == Proprietary => onProprietary(),
            _ when this == NameAndAddress => onNameAndAddress(),
            _ => otherwise(Value)
        };

    public void Match(Action onBic, Action onProprietary, Action onNameAndAddress, Action<string> otherwise)
    {
        if (this == Bic) onBic();
        else if (this == Proprietary) onProprietary();
        else if (this == NameAndAddress) onNameAndAddress();
        else otherwise(Value);
    }
}
