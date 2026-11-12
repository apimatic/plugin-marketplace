using System;
using System.Text.Json.Serialization;
using UpvestInvestmentApi.Core.Enum;

namespace UpvestInvestmentApi.Models.Enums;

/// <summary>
/// Account group type.
/// * CHILD - Account group of a child user holding assets in a child account.
/// * FRENCH_PEA - Account group of a french resident holding assets in Plan d'Epargne en Actions.
/// * ISA - Account group of a UK resident holding assets in an individual savings account.
/// * JOINT - Account group legally and beneficially owned by exactly 2 users. The user the account group is created with becomes the first owner and receives an OWNER role. The second owner is added by creating an OWNER role for them (POST /roles); no further owners can be added. The account group activates only once both OWNER roles are active.
/// * LEGAL_ENTITY - Account group of a legal entity holding assets on behalf of their users.
/// * PENSION_DE_CHILD - Account group of a child user holding assets in a German pension (Frühstartrente) account. Like CHILD it has one CHILD user and, depending on custody, one or two GUARDIAN users; like PENSION_DE it activates only once its tax wrapper is active.
/// * PERSONAL - Account group of a person holding assets on their own behalf.
/// </summary>
[JsonConverter(typeof(StringEnumConverter<Type13>))]
public sealed record Type13 : OpenStringEnum<Type13>
{
    private Type13(string value) : base(value)
    {
    }

    public static readonly Type13 Child = new("CHILD");

    public static readonly Type13 FrenchPea = new("FRENCH_PEA");

    public static readonly Type13 Isa = new("ISA");

    public static readonly Type13 Joint = new("JOINT");

    public static readonly Type13 LegalEntity = new("LEGAL_ENTITY");

    public static readonly Type13 PensionDeChild = new("PENSION_DE_CHILD");

    public static readonly Type13 Personal = new("PERSONAL");

    public TResult Match<TResult>(Func<TResult> onChild,
        Func<TResult> onFrenchPea,
        Func<TResult> onIsa,
        Func<TResult> onJoint,
        Func<TResult> onLegalEntity,
        Func<TResult> onPensionDeChild,
        Func<TResult> onPersonal,
        Func<string, TResult> otherwise) =>
        this switch
        {
            _ when this == Child => onChild(),
            _ when this == FrenchPea => onFrenchPea(),
            _ when this == Isa => onIsa(),
            _ when this == Joint => onJoint(),
            _ when this == LegalEntity => onLegalEntity(),
            _ when this == PensionDeChild => onPensionDeChild(),
            _ when this == Personal => onPersonal(),
            _ => otherwise(Value)
        };

    public void Match(Action onChild,
        Action onFrenchPea,
        Action onIsa,
        Action onJoint,
        Action onLegalEntity,
        Action onPensionDeChild,
        Action onPersonal,
        Action<string> otherwise)
    {
        if (this == Child) onChild();
        else if (this == FrenchPea) onFrenchPea();
        else if (this == Isa) onIsa();
        else if (this == Joint) onJoint();
        else if (this == LegalEntity) onLegalEntity();
        else if (this == PensionDeChild) onPensionDeChild();
        else if (this == Personal) onPersonal();
        else otherwise(Value);
    }
}
