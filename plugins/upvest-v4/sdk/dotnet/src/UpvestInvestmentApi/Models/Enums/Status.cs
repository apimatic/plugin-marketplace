using System;
using System.Text.Json.Serialization;
using UpvestInvestmentApi.Core.Enum;

namespace UpvestInvestmentApi.Models.Enums;

/// <summary>
/// Status of the user.
/// * ACTIVE - The user is active.
/// * INACTIVE - The user is deactivated, or is a new user who has not yet passed the onboarding checks. Using <c>INACTIVE</c> for new users is deprecated.
/// * OFFBOARDING - Offboarding of the user has been initiated.
/// * OFFBOARDED - The user has been offboarded.
/// <para>
/// In a future release, Upvest will create new users as <c>ACTIVE</c>, and <c>ACTIVE</c> will no longer mean that the user has passed the onboarding checks.
/// </para>
/// <para>
/// Do not wait for the user to become <c>ACTIVE</c> before you create an account group. Upvest creates the user's role with the account group (for example, the <c>OWNER</c> role for a <c>PERSONAL</c> account group). Any checks that the user has already passed count towards that role. To know when the user has met the onboarding requirements for an account group or business, listen for the <c>ROLE.ACTIVATED</c> webhook event. The account group stays <c>PENDING_APPROVAL</c> until all its requirements are met, and the <c>ACCOUNT_GROUP.ACTIVATED</c> webhook event signals that it is <c>ACTIVE</c>.
/// </para>
/// </summary>
[JsonConverter(typeof(StringEnumConverter<Status>))]
public sealed record Status : OpenStringEnum<Status>
{
    private Status(string value) : base(value)
    {
    }

    public static readonly Status Active = new("ACTIVE");

    public static readonly Status Inactive = new("INACTIVE");

    public static readonly Status Offboarding = new("OFFBOARDING");

    public static readonly Status Offboarded = new("OFFBOARDED");

    public TResult Match<TResult>(Func<TResult> onActive,
        Func<TResult> onInactive,
        Func<TResult> onOffboarding,
        Func<TResult> onOffboarded,
        Func<string, TResult> otherwise) =>
        this switch
        {
            _ when this == Active => onActive(),
            _ when this == Inactive => onInactive(),
            _ when this == Offboarding => onOffboarding(),
            _ when this == Offboarded => onOffboarded(),
            _ => otherwise(Value)
        };

    public void Match(Action onActive,
        Action onInactive,
        Action onOffboarding,
        Action onOffboarded,
        Action<string> otherwise)
    {
        if (this == Active) onActive();
        else if (this == Inactive) onInactive();
        else if (this == Offboarding) onOffboarding();
        else if (this == Offboarded) onOffboarded();
        else otherwise(Value);
    }
}
