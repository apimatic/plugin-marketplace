using System;
using System.Text.Json.Serialization;
using UpvestInvestmentApi.Core.Enum;

namespace UpvestInvestmentApi.Models.Enums;

/// <summary>
/// Gender of the user. Required for users applying for the German pension government bonus.
/// * (empty string) -
/// * MALE -
/// * FEMALE -
/// * DIVERSE -
/// </summary>
[JsonConverter(typeof(StringEnumConverter<Gender>))]
public sealed record Gender : OpenStringEnum<Gender>
{
    private Gender(string value) : base(value)
    {
    }

    public static readonly Gender Male = new("MALE");

    public static readonly Gender Female = new("FEMALE");

    public static readonly Gender Diverse = new("DIVERSE");

    public TResult Match<TResult>(Func<TResult> onMale,
        Func<TResult> onFemale,
        Func<TResult> onDiverse,
        Func<string, TResult> otherwise) =>
        this switch
        {
            _ when this == Male => onMale(),
            _ when this == Female => onFemale(),
            _ when this == Diverse => onDiverse(),
            _ => otherwise(Value)
        };

    public void Match(Action onMale, Action onFemale, Action onDiverse, Action<string> otherwise)
    {
        if (this == Male) onMale();
        else if (this == Female) onFemale();
        else if (this == Diverse) onDiverse();
        else otherwise(Value);
    }
}
