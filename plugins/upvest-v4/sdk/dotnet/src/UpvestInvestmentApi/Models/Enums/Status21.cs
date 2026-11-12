using System;
using System.Text.Json.Serialization;
using UpvestInvestmentApi.Core.Enum;

namespace UpvestInvestmentApi.Models.Enums;

/// <summary>
/// The status of the account.
/// * <c>PENDING_APPROVAL</c> — Account approval is pending — the account is visible through our API but cannot be acted on.
/// * <c>ACTIVE</c> — Account is active — full functionality of the Investment API is accessible.
/// * <c>CLOSING</c> — Account is closing — only sell orders or the transfer of positions out are permissible before the account is closed.
/// * <c>CLOSED</c> — Account is closed with zero balance.
/// * <c>LOCKED</c> — Account is locked for all actions.
/// </summary>
[JsonConverter(typeof(StringEnumConverter<Status21>))]
public sealed record Status21 : OpenStringEnum<Status21>
{
    private Status21(string value) : base(value)
    {
    }

    public static readonly Status21 PendingApproval = new("PENDING_APPROVAL");

    public static readonly Status21 Active = new("ACTIVE");

    public static readonly Status21 Closing = new("CLOSING");

    public static readonly Status21 Closed = new("CLOSED");

    public static readonly Status21 Locked = new("LOCKED");

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
