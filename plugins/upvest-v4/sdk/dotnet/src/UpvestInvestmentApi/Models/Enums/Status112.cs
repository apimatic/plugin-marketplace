using System;
using System.Text.Json.Serialization;
using UpvestInvestmentApi.Core.Enum;

namespace UpvestInvestmentApi.Models.Enums;

/// <summary>
/// Status of the role assignment.
/// * <c>PENDING</c> — The role has been created but is not yet active.
/// * <c>ACTIVE</c> — The role is active.
/// * <c>DEACTIVATED</c> — The role has been deactivated and cannot be reactivated.
/// </summary>
[JsonConverter(typeof(StringEnumConverter<Status112>))]
public sealed record Status112 : OpenStringEnum<Status112>
{
    private Status112(string value) : base(value)
    {
    }

    public static readonly Status112 Pending = new("PENDING");

    public static readonly Status112 Active = new("ACTIVE");

    public static readonly Status112 Deactivated = new("DEACTIVATED");

    public TResult Match<TResult>(Func<TResult> onPending,
        Func<TResult> onActive,
        Func<TResult> onDeactivated,
        Func<string, TResult> otherwise) =>
        this switch
        {
            _ when this == Pending => onPending(),
            _ when this == Active => onActive(),
            _ when this == Deactivated => onDeactivated(),
            _ => otherwise(Value)
        };

    public void Match(Action onPending, Action onActive, Action onDeactivated, Action<string> otherwise)
    {
        if (this == Pending) onPending();
        else if (this == Active) onActive();
        else if (this == Deactivated) onDeactivated();
        else otherwise(Value);
    }
}
