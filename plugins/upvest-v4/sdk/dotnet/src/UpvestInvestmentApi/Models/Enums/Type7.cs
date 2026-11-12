using System;
using System.Text.Json.Serialization;
using UpvestInvestmentApi.Core.Enum;

namespace UpvestInvestmentApi.Models.Enums;

/// <summary>
/// Identifier type.
/// * NATIONAL_ID — national identity card number issued by the user's country.
/// * PASSPORT — passport number issued by the user's country.
/// </summary>
[JsonConverter(typeof(StringEnumConverter<Type7>))]
public sealed record Type7 : OpenStringEnum<Type7>
{
    private Type7(string value) : base(value)
    {
    }

    public static readonly Type7 NationalId = new("NATIONAL_ID");

    public static readonly Type7 Passport = new("PASSPORT");

    public TResult Match<TResult>(Func<TResult> onNationalId,
        Func<TResult> onPassport,
        Func<string, TResult> otherwise) =>
        this switch
        {
            _ when this == NationalId => onNationalId(),
            _ when this == Passport => onPassport(),
            _ => otherwise(Value)
        };

    public void Match(Action onNationalId, Action onPassport, Action<string> otherwise)
    {
        if (this == NationalId) onNationalId();
        else if (this == Passport) onPassport();
        else otherwise(Value);
    }
}
