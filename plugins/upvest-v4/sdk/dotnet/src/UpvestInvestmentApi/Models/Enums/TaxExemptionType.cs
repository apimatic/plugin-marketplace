using System;
using System.Text.Json.Serialization;
using UpvestInvestmentApi.Core.Enum;

namespace UpvestInvestmentApi.Models.Enums;

/// <summary>
/// Tax exemption type
/// * SINGLE - Tax exemption for Individual.
/// * MARRIED - Tax exemption for married couples.
/// * CIVIL_PARTNERSHIP - Tax exemption for registered civil partnerships.
/// </summary>
[JsonConverter(typeof(StringEnumConverter<TaxExemptionType>))]
public sealed record TaxExemptionType : OpenStringEnum<TaxExemptionType>
{
    private TaxExemptionType(string value) : base(value)
    {
    }

    public static readonly TaxExemptionType Single = new("SINGLE");

    public static readonly TaxExemptionType Married = new("MARRIED");

    public static readonly TaxExemptionType CivilPartnership = new("CIVIL_PARTNERSHIP");

    public TResult Match<TResult>(Func<TResult> onSingle,
        Func<TResult> onMarried,
        Func<TResult> onCivilPartnership,
        Func<string, TResult> otherwise) =>
        this switch
        {
            _ when this == Single => onSingle(),
            _ when this == Married => onMarried(),
            _ when this == CivilPartnership => onCivilPartnership(),
            _ => otherwise(Value)
        };

    public void Match(Action onSingle, Action onMarried, Action onCivilPartnership, Action<string> otherwise)
    {
        if (this == Single) onSingle();
        else if (this == Married) onMarried();
        else if (this == CivilPartnership) onCivilPartnership();
        else otherwise(Value);
    }
}
