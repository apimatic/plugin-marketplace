using System;
using System.Text.Json.Serialization;
using UpvestInvestmentApi.Core.Enum;

namespace UpvestInvestmentApi.Models.Enums;

/// <summary>
/// The salutation used for the end user in reports and statements.
/// * SALUTATION_MALE — Herr.
/// * SALUTATION_FEMALE — Frau.
/// * SALUTATION_FEMALE_MARRIED — Frau, married form.
/// * SALUTATION_DIVERSE — Gender-neutral salutation.
/// <para>
/// An empty string means no salutation is printed.
/// </para>
/// </summary>
[JsonConverter(typeof(StringEnumConverter<Salutation10>))]
public sealed record Salutation10 : OpenStringEnum<Salutation10>
{
    private Salutation10(string value) : base(value)
    {
    }

    public static readonly Salutation10 SalutationMale = new("SALUTATION_MALE");

    public static readonly Salutation10 SalutationFemale = new("SALUTATION_FEMALE");

    public static readonly Salutation10 SalutationFemaleMarried = new("SALUTATION_FEMALE_MARRIED");

    public static readonly Salutation10 SalutationDiverse = new("SALUTATION_DIVERSE");

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
