using System;
using System.Text.Json.Serialization;
using UpvestInvestmentApi.Core.Enum;

namespace UpvestInvestmentApi.Models.Enums;

/// <summary>
/// The type of the ID used in the request.
/// * ISIN - International Securities Identification Number
/// * WKN - German securities identification code
/// </summary>
[JsonConverter(typeof(StringEnumConverter<InstrumentIdType10>))]
public sealed record InstrumentIdType10 : OpenStringEnum<InstrumentIdType10>
{
    private InstrumentIdType10(string value) : base(value)
    {
    }

    public static readonly InstrumentIdType10 Isin = new("ISIN");

    public static readonly InstrumentIdType10 Wkn = new("WKN");

    public TResult Match<TResult>(Func<TResult> onIsin, Func<TResult> onWkn, Func<string, TResult> otherwise) =>
        this switch
        {
            _ when this == Isin => onIsin(),
            _ when this == Wkn => onWkn(),
            _ => otherwise(Value)
        };

    public void Match(Action onIsin, Action onWkn, Action<string> otherwise)
    {
        if (this == Isin) onIsin();
        else if (this == Wkn) onWkn();
        else otherwise(Value);
    }
}
