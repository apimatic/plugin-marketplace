using System;
using System.Text.Json.Serialization;
using UpvestInvestmentApi.Core.Enum;

namespace UpvestInvestmentApi.Models.Enums;

/// <summary>
/// Salutation of the user used in reports and statements.
/// * (empty string) -
/// * SALUTATION_MALE -
/// * SALUTATION_FEMALE -
/// * SALUTATION_FEMALE_MARRIED -
/// * SALUTATION_DIVERSE -
/// </summary>
[JsonConverter(typeof(StringEnumConverter<Salutation>))]
public sealed record Salutation : OpenStringEnum<Salutation>
{
    private Salutation(string value) : base(value)
    {
    }

    public static readonly Salutation SalutationMale = new("SALUTATION_MALE");

    public static readonly Salutation SalutationFemale = new("SALUTATION_FEMALE");

    public static readonly Salutation SalutationFemaleMarried = new("SALUTATION_FEMALE_MARRIED");

    public static readonly Salutation SalutationDiverse = new("SALUTATION_DIVERSE");

    public TResult Match<TResult>(Func<TResult> onSalutationMale,
        Func<TResult> onSalutationFemale,
        Func<TResult> onSalutationFemaleMarried,
        Func<TResult> onSalutationDiverse,
        Func<string, TResult> otherwise) =>
        this switch
        {
            _ when this == SalutationMale => onSalutationMale(),
            _ when this == SalutationFemale => onSalutationFemale(),
            _ when this == SalutationFemaleMarried => onSalutationFemaleMarried(),
            _ when this == SalutationDiverse => onSalutationDiverse(),
            _ => otherwise(Value)
        };

    public void Match(Action onSalutationMale,
        Action onSalutationFemale,
        Action onSalutationFemaleMarried,
        Action onSalutationDiverse,
        Action<string> otherwise)
    {
        if (this == SalutationMale) onSalutationMale();
        else if (this == SalutationFemale) onSalutationFemale();
        else if (this == SalutationFemaleMarried) onSalutationFemaleMarried();
        else if (this == SalutationDiverse) onSalutationDiverse();
        else otherwise(Value);
    }
}
