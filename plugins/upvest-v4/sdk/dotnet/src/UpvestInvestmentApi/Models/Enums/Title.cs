using System;
using System.Text.Json.Serialization;
using UpvestInvestmentApi.Core.Enum;

namespace UpvestInvestmentApi.Models.Enums;

/// <summary>
/// Title of the user used in reports and statements.
/// * (empty string) -
/// * DR - Doctor
/// * PROF - Professor
/// * PROF_DR -
/// * DIPL_ING - Graduate engineer (Diplom-Ingenieur)
/// * MAGISTER -
/// </summary>
[JsonConverter(typeof(StringEnumConverter<Title>))]
public sealed record Title : OpenStringEnum<Title>
{
    private Title(string value) : base(value)
    {
    }

    public static readonly Title Dr = new("DR");

    public static readonly Title Prof = new("PROF");

    public static readonly Title ProfDr = new("PROF_DR");

    public static readonly Title DiplIng = new("DIPL_ING");

    public static readonly Title Magister = new("MAGISTER");

    public TResult Match<TResult>(Func<TResult> onDr,
        Func<TResult> onProf,
        Func<TResult> onProfDr,
        Func<TResult> onDiplIng,
        Func<TResult> onMagister,
        Func<string, TResult> otherwise) =>
        this switch
        {
            _ when this == Dr => onDr(),
            _ when this == Prof => onProf(),
            _ when this == ProfDr => onProfDr(),
            _ when this == DiplIng => onDiplIng(),
            _ when this == Magister => onMagister(),
            _ => otherwise(Value)
        };

    public void Match(Action onDr,
        Action onProf,
        Action onProfDr,
        Action onDiplIng,
        Action onMagister,
        Action<string> otherwise)
    {
        if (this == Dr) onDr();
        else if (this == Prof) onProf();
        else if (this == ProfDr) onProfDr();
        else if (this == DiplIng) onDiplIng();
        else if (this == Magister) onMagister();
        else otherwise(Value);
    }
}
