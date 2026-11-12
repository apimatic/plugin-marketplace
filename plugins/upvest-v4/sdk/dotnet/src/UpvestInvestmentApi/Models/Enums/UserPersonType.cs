using System;
using System.Text.Json.Serialization;
using UpvestInvestmentApi.Core.Enum;

namespace UpvestInvestmentApi.Models.Enums;

/// <summary>
/// US tax person classification of the user.
/// * US_PERSON - The user is a US person for tax purposes.
/// * NON_RESIDENT_ALIEN - The user is a non-resident alien for US tax purposes.
/// </summary>
[JsonConverter(typeof(StringEnumConverter<UserPersonType>))]
public sealed record UserPersonType : OpenStringEnum<UserPersonType>
{
    private UserPersonType(string value) : base(value)
    {
    }

    public static readonly UserPersonType UsPerson = new("US_PERSON");

    public static readonly UserPersonType NonResidentAlien = new("NON_RESIDENT_ALIEN");

    public TResult Match<TResult>(Func<TResult> onUsPerson,
        Func<TResult> onNonResidentAlien,
        Func<string, TResult> otherwise) =>
        this switch
        {
            _ when this == UsPerson => onUsPerson(),
            _ when this == NonResidentAlien => onNonResidentAlien(),
            _ => otherwise(Value)
        };

    public void Match(Action onUsPerson, Action onNonResidentAlien, Action<string> otherwise)
    {
        if (this == UsPerson) onUsPerson();
        else if (this == NonResidentAlien) onNonResidentAlien();
        else otherwise(Value);
    }
}
