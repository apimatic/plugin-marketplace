using System;
using System.Text.Json.Serialization;
using UpvestInvestmentApi.Core.Enum;

namespace UpvestInvestmentApi.Models.Enums;

/// <summary>
/// Status of the account group.
/// * <c>PENDING_APPROVAL</c> — Account group approval is pending — the account group is visible through our API but cannot be acted on.
/// * <c>ACTIVE</c> — Account group is active — full functionality of the Investment API is accessible.
/// * <c>CLOSING</c> — Account group is closing.
/// * <c>CLOSED</c> — Account group is closed.
/// * <c>LOCKED</c> — Account group is locked for all actions.
/// </summary>
[JsonConverter(typeof(StringEnumConverter<Status18>))]
public sealed record Status18 : OpenStringEnum<Status18>
{
    private Status18(string value) : base(value)
    {
    }

    public static readonly Status18 PendingApproval = new("PENDING_APPROVAL");

    public static readonly Status18 Active = new("ACTIVE");

    public static readonly Status18 Closing = new("CLOSING");

    public static readonly Status18 Closed = new("CLOSED");

    public static readonly Status18 Locked = new("LOCKED");

    public TResult Match<TResult>(Func<TResult> onPendingApproval,
        Func<TResult> onActive,
        Func<TResult> onClosing,
        Func<TResult> onClosed,
        Func<TResult> onLocked,
        Func<string, TResult> otherwise) =>
        this switch
        {
            _ when this == PendingApproval => onPendingApproval(),
            _ when this == Active => onActive(),
            _ when this == Closing => onClosing(),
            _ when this == Closed => onClosed(),
            _ when this == Locked => onLocked(),
            _ => otherwise(Value)
        };

    public void Match(Action onPendingApproval,
        Action onActive,
        Action onClosing,
        Action onClosed,
        Action onLocked,
        Action<string> otherwise)
    {
        if (this == PendingApproval) onPendingApproval();
        else if (this == Active) onActive();
        else if (this == Closing) onClosing();
        else if (this == Closed) onClosed();
        else if (this == Locked) onLocked();
        else otherwise(Value);
    }
}
