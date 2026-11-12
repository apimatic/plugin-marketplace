using System;
using System.Text.Json.Serialization;
using UpvestInvestmentApi.Core.Enum;

namespace UpvestInvestmentApi.Models.Enums;

/// <summary>
/// Instrument trading status
/// * ACTIVE - The instrument can currently be traded on the Upvest platform.
/// * INACTIVE - The instrument cannot currently be traded on the Upvest platform.
/// </summary>
[JsonConverter(typeof(StringEnumConverter<InstrumentTradingStatus>))]
public sealed record InstrumentTradingStatus : OpenStringEnum<InstrumentTradingStatus>
{
    private InstrumentTradingStatus(string value) : base(value)
    {
    }

    public static readonly InstrumentTradingStatus Active = new("ACTIVE");

    public static readonly InstrumentTradingStatus Inactive = new("INACTIVE");

    public TResult Match<TResult>(Func<TResult> onActive, Func<TResult> onInactive, Func<string, TResult> otherwise) =>
        this switch
        {
            _ when this == Active => onActive(),
            _ when this == Inactive => onInactive(),
            _ => otherwise(Value)
        };

    public void Match(Action onActive, Action onInactive, Action<string> otherwise)
    {
        if (this == Active) onActive();
        else if (this == Inactive) onInactive();
        else otherwise(Value);
    }
}
