using System;
using System.Text.Json.Serialization;
using UpvestInvestmentApi.Core.Enum;

namespace UpvestInvestmentApi.Models.Enums;

/// <summary>
/// The type of the ID used in the request.
/// * ISIN - International Securities Identification Number
/// * UPVEST - UPVEST's unique instrument identifier
/// </summary>
[JsonConverter(typeof(StringEnumConverter<InstrumentIdType4>))]
public sealed record InstrumentIdType4 : OpenStringEnum<InstrumentIdType4>
{
    private InstrumentIdType4(string value) : base(value)
    {
    }

    public static readonly InstrumentIdType4 Isin = new("ISIN");

    public static readonly InstrumentIdType4 Upvest = new("UPVEST");

    public TResult Match<TResult>(Func<TResult> onIsin, Func<TResult> onUpvest, Func<string, TResult> otherwise) =>
        this switch
        {
            _ when this == Isin => onIsin(),
            _ when this == Upvest => onUpvest(),
            _ => otherwise(Value)
        };

    public void Match(Action onIsin, Action onUpvest, Action<string> otherwise)
    {
        if (this == Isin) onIsin();
        else if (this == Upvest) onUpvest();
        else otherwise(Value);
    }
}
