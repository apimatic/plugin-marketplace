using System;
using System.Text.Json.Serialization;
using UpvestInvestmentApi.Core.Enum;

namespace UpvestInvestmentApi.Models.Enums;

/// <summary>
/// Country specific legal designation of the sole trader business.
/// </summary>
[JsonConverter(typeof(StringEnumConverter<LegalDesignation1>))]
public sealed record LegalDesignation1 : OpenStringEnum<LegalDesignation1>
{
    private LegalDesignation1(string value) : base(value)
    {
    }

    public static readonly LegalDesignation1 Einzelunternehmer = new("EINZELUNTERNEHMER");

    public static readonly LegalDesignation1 Freiberufler = new("FREIBERUFLER");

    public static readonly LegalDesignation1 EingetragenerKaufmann = new("EINGETRAGENER_KAUFMANN");

    public static readonly LegalDesignation1 EingetrageneKauffrau = new("EINGETRAGENE_KAUFFRAU");

    public TResult Match<TResult>(Func<TResult> onEinzelunternehmer,
        Func<TResult> onFreiberufler,
        Func<TResult> onEingetragenerKaufmann,
        Func<TResult> onEingetrageneKauffrau,
        Func<string, TResult> otherwise) =>
        this switch
        {
            _ when this == Einzelunternehmer => onEinzelunternehmer(),
            _ when this == Freiberufler => onFreiberufler(),
            _ when this == EingetragenerKaufmann => onEingetragenerKaufmann(),
            _ when this == EingetrageneKauffrau => onEingetrageneKauffrau(),
            _ => otherwise(Value)
        };

    public void Match(Action onEinzelunternehmer,
        Action onFreiberufler,
        Action onEingetragenerKaufmann,
        Action onEingetrageneKauffrau,
        Action<string> otherwise)
    {
        if (this == Einzelunternehmer) onEinzelunternehmer();
        else if (this == Freiberufler) onFreiberufler();
        else if (this == EingetragenerKaufmann) onEingetragenerKaufmann();
        else if (this == EingetrageneKauffrau) onEingetrageneKauffrau();
        else otherwise(Value);
    }
}
