using System;
using System.Text.Json.Serialization;
using UpvestInvestmentApi.Core.Enum;

namespace UpvestInvestmentApi.Models.Enums;

/// <summary>
/// Status of the business.
/// * ACTIVE -
/// * INACTIVE -
/// * OFFBOARDING -
/// * OFFBOARDED -
/// </summary>
[JsonConverter(typeof(StringEnumConverter<Status100>))]
public sealed record Status100 : OpenStringEnum<Status100>
{
    private Status100(string value) : base(value)
    {
    }

    public static readonly Status100 Active = new("ACTIVE");

    public static readonly Status100 Inactive = new("INACTIVE");

    public static readonly Status100 Offboarding = new("OFFBOARDING");

    public static readonly Status100 Offboarded = new("OFFBOARDED");

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
