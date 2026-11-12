using System;
using System.Text.Json.Serialization;
using UpvestInvestmentApi.Core.Enum;

namespace UpvestInvestmentApi.Models.Enums;

/// <summary>
/// Role type for an account group.
/// * <c>OWNER</c> — The user owns the account group.
/// * <c>GUARDIAN</c> — The user is a legal custodian of a child account group.
/// * <c>CHILD</c> — The user is the child beneficiary of a child account group.
/// </summary>
[JsonConverter(typeof(StringEnumConverter<RoleType>))]
public sealed record RoleType : OpenStringEnum<RoleType>
{
    private RoleType(string value) : base(value)
    {
    }

    public static readonly RoleType Owner = new("OWNER");

    public static readonly RoleType Guardian = new("GUARDIAN");

    public static readonly RoleType Child = new("CHILD");

    public TResult Match<TResult>(Func<TResult> onOwner,
        Func<TResult> onGuardian,
        Func<TResult> onChild,
        Func<string, TResult> otherwise) =>
        this switch
        {
            _ when this == Owner => onOwner(),
            _ when this == Guardian => onGuardian(),
            _ when this == Child => onChild(),
            _ => otherwise(Value)
        };

    public void Match(Action onOwner, Action onGuardian, Action onChild, Action<string> otherwise)
    {
        if (this == Owner) onOwner();
        else if (this == Guardian) onGuardian();
        else if (this == Child) onChild();
        else otherwise(Value);
    }
}
