using System;
using System.Text.Json.Serialization;
using UpvestInvestmentApi.Core.Enum;

namespace UpvestInvestmentApi.Models.Enums;

/// <summary>
/// Role type to assign.
/// * <c>GUARDIAN</c> — The user is a legal custodian of the child account group.
/// * <c>OWNER</c> — The second owner of a <c>JOINT</c> account group; the first owner is the user the account group was created with. <c>custody_type</c> does not apply.
/// </summary>
[JsonConverter(typeof(StringEnumConverter<RoleType2>))]
public sealed record RoleType2 : OpenStringEnum<RoleType2>
{
    private RoleType2(string value) : base(value)
    {
    }

    public static readonly RoleType2 Guardian = new("GUARDIAN");

    public static readonly RoleType2 Owner = new("OWNER");

    public TResult Match<TResult>(Func<TResult> onGuardian, Func<TResult> onOwner, Func<string, TResult> otherwise) =>
        this switch
        {
            _ when this == Guardian => onGuardian(),
            _ when this == Owner => onOwner(),
            _ => otherwise(Value)
        };

    public void Match(Action onGuardian, Action onOwner, Action<string> otherwise)
    {
        if (this == Guardian) onGuardian();
        else if (this == Owner) onOwner();
        else otherwise(Value);
    }
}
