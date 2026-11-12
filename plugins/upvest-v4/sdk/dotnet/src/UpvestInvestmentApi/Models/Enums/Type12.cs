using System;
using System.Text.Json.Serialization;
using UpvestInvestmentApi.Core.Enum;

namespace UpvestInvestmentApi.Models.Enums;

/// <summary>
/// Relation of the user to the account group.
/// * <c>OWNER</c> — The user owns the account group. A <c>JOINT</c> account group has exactly 2 <c>OWNER</c> users.
/// * <c>CHILD</c> — The user is the child in a child account group.
/// * <c>GUARDIAN</c> — The user is a guardian of a child account group.
/// </summary>
[JsonConverter(typeof(StringEnumConverter<Type12>))]
public sealed record Type12 : OpenStringEnum<Type12>
{
    private Type12(string value) : base(value)
    {
    }

    public static readonly Type12 Owner = new("OWNER");

    public static readonly Type12 Child = new("CHILD");

    public static readonly Type12 Guardian = new("GUARDIAN");

    public TResult Match<TResult>(Func<TResult> onOwner,
        Func<TResult> onChild,
        Func<TResult> onGuardian,
        Func<string, TResult> otherwise) =>
        this switch
        {
            _ when this == Owner => onOwner(),
            _ when this == Child => onChild(),
            _ when this == Guardian => onGuardian(),
            _ => otherwise(Value)
        };

    public void Match(Action onOwner, Action onChild, Action onGuardian, Action<string> otherwise)
    {
        if (this == Owner) onOwner();
        else if (this == Child) onChild();
        else if (this == Guardian) onGuardian();
        else otherwise(Value);
    }
}
