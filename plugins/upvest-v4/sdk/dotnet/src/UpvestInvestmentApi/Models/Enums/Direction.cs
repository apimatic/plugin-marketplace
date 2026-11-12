using System;
using System.Text.Json.Serialization;
using UpvestInvestmentApi.Core.Enum;

namespace UpvestInvestmentApi.Models.Enums;

[JsonConverter(typeof(StringEnumConverter<Direction>))]
public sealed record Direction : OpenStringEnum<Direction>
{
    private Direction(string value) : base(value)
    {
    }

    public static readonly Direction Incoming = new("INCOMING");

    public static readonly Direction Outgoing = new("OUTGOING");

    public TResult Match<TResult>(Func<TResult> onIncoming,
        Func<TResult> onOutgoing,
        Func<string, TResult> otherwise) =>
        this switch
        {
            _ when this == Incoming => onIncoming(),
            _ when this == Outgoing => onOutgoing(),
            _ => otherwise(Value)
        };

    public void Match(Action onIncoming, Action onOutgoing, Action<string> otherwise)
    {
        if (this == Incoming) onIncoming();
        else if (this == Outgoing) onOutgoing();
        else otherwise(Value);
    }
}
