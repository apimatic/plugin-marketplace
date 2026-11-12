using System;
using System.Text.Json.Serialization;
using UpvestInvestmentApi.Core.Enum;

namespace UpvestInvestmentApi.Models.Enums;

/// <summary>
/// Country specific legal designation of the company.
/// </summary>
[JsonConverter(typeof(StringEnumConverter<LegalDesignation>))]
public sealed record LegalDesignation : OpenStringEnum<LegalDesignation>
{
    private LegalDesignation(string value) : base(value)
    {
    }

    public static readonly LegalDesignation GesellschaftMitBeschraenkterHaftung = new(
        "GESELLSCHAFT_MIT_BESCHRAENKTER_HAFTUNG");

    public static readonly LegalDesignation Unternehmergesellschaft = new("UNTERNEHMERGESELLSCHAFT");

    public static readonly LegalDesignation Aktiengesellschaft = new("AKTIENGESELLSCHAFT");

    public TResult Match<TResult>(Func<TResult> onGesellschaftMitBeschraenkterHaftung,
        Func<TResult> onUnternehmergesellschaft,
        Func<TResult> onAktiengesellschaft,
        Func<string, TResult> otherwise) =>
        this switch
        {
            _ when this == GesellschaftMitBeschraenkterHaftung => onGesellschaftMitBeschraenkterHaftung(),
            _ when this == Unternehmergesellschaft => onUnternehmergesellschaft(),
            _ when this == Aktiengesellschaft => onAktiengesellschaft(),
            _ => otherwise(Value)
        };

    public void Match(Action onGesellschaftMitBeschraenkterHaftung,
        Action onUnternehmergesellschaft,
        Action onAktiengesellschaft,
        Action<string> otherwise)
    {
        if (this == GesellschaftMitBeschraenkterHaftung) onGesellschaftMitBeschraenkterHaftung();
        else if (this == Unternehmergesellschaft) onUnternehmergesellschaft();
        else if (this == Aktiengesellschaft) onAktiengesellschaft();
        else otherwise(Value);
    }
}
