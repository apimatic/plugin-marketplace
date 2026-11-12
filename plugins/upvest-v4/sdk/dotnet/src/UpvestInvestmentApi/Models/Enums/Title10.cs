using System;
using System.Text.Json.Serialization;
using UpvestInvestmentApi.Core.Enum;

namespace UpvestInvestmentApi.Models.Enums;

/// <summary>
/// The academic title used for the end user in reports and statements.
/// * DR — Doctor.
/// * PROF — Professor.
/// * PROF_DR — Professor Doctor.
/// * DIPL_ING — Graduate engineer (Diplom-Ingenieur).
/// * MAGISTER — Magister.
/// <para>
/// An empty string means no title is printed.
/// </para>
/// </summary>
[JsonConverter(typeof(StringEnumConverter<Title10>))]
public sealed record Title10 : OpenStringEnum<Title10>
{
    private Title10(string value) : base(value)
    {
    }

    public static readonly Title10 Dr = new("DR");

    public static readonly Title10 Prof = new("PROF");

    public static readonly Title10 ProfDr = new("PROF_DR");

    public static readonly Title10 DiplIng = new("DIPL_ING");

    public static readonly Title10 Magister = new("MAGISTER");

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
