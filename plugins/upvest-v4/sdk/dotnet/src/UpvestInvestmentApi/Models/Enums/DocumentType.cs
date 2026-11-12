using System;
using System.Text.Json.Serialization;
using UpvestInvestmentApi.Core.Enum;

namespace UpvestInvestmentApi.Models.Enums;

/// <summary>
/// The type of document used to prove the data change
/// * PASSPORT - Passport
/// * ID_CARD - National Identification document
/// </summary>
[JsonConverter(typeof(StringEnumConverter<DocumentType>))]
public sealed record DocumentType : OpenStringEnum<DocumentType>
{
    private DocumentType(string value) : base(value)
    {
    }

    public static readonly DocumentType Passport = new("PASSPORT");

    public static readonly DocumentType IdCard = new("ID_CARD");

    public TResult Match<TResult>(Func<TResult> onPassport, Func<TResult> onIdCard, Func<string, TResult> otherwise) =>
        this switch
        {
            _ when this == Passport => onPassport(),
            _ when this == IdCard => onIdCard(),
            _ => otherwise(Value)
        };

    public void Match(Action onPassport, Action onIdCard, Action<string> otherwise)
    {
        if (this == Passport) onPassport();
        else if (this == IdCard) onIdCard();
        else otherwise(Value);
    }
}
