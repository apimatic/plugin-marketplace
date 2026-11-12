using System;
using System.Text.Json.Serialization;
using UpvestInvestmentApi.Core.Enum;

namespace UpvestInvestmentApi.Models.Enums;

/// <summary>
/// The kind of identifier given in <c>instrument_id</c>.
/// * ISIN — International Securities Identification Number.
/// </summary>
[JsonConverter(typeof(StringEnumConverter<InstrumentIdType>))]
public sealed record InstrumentIdType : OpenStringEnum<InstrumentIdType>
{
    private InstrumentIdType(string value) : base(value)
    {
    }

    public static readonly InstrumentIdType Isin = new("ISIN");

    public TResult Match<TResult>(Func<TResult> onIsin, Func<string, TResult> otherwise) =>
        this switch
        {
            _ when this == Isin => onIsin(),
            _ => otherwise(Value)
        };

    public void Match(Action onIsin, Action<string> otherwise)
    {
        if (this == Isin) onIsin();
        else otherwise(Value);
    }
}
