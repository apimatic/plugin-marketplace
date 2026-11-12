using System;
using System.Text.Json.Serialization;
using UpvestInvestmentApi.Core.Enum;

namespace UpvestInvestmentApi.Models.Enums;

/// <summary>
/// Type of tax identification used by the business.
/// </summary>
[JsonConverter(typeof(StringEnumConverter<TaxIdentificationType>))]
public sealed record TaxIdentificationType : OpenStringEnum<TaxIdentificationType>
{
    private TaxIdentificationType(string value) : base(value)
    {
    }

    public static readonly TaxIdentificationType Steuernummer = new("STEUERNUMMER");

    public static readonly TaxIdentificationType Wirtschaftsidentifikationsnummer = new(
        "WIRTSCHAFTSIDENTIFIKATIONSNUMMER");

    public TResult Match<TResult>(Func<TResult> onSteuernummer,
        Func<TResult> onWirtschaftsidentifikationsnummer,
        Func<string, TResult> otherwise) =>
        this switch
        {
            _ when this == Steuernummer => onSteuernummer(),
            _ when this == Wirtschaftsidentifikationsnummer => onWirtschaftsidentifikationsnummer(),
            _ => otherwise(Value)
        };

    public void Match(Action onSteuernummer, Action onWirtschaftsidentifikationsnummer, Action<string> otherwise)
    {
        if (this == Steuernummer) onSteuernummer();
        else if (this == Wirtschaftsidentifikationsnummer) onWirtschaftsidentifikationsnummer();
        else otherwise(Value);
    }
}
