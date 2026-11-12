using System;
using System.Text.Json.Serialization;
using UpvestInvestmentApi.Core.Enum;

namespace UpvestInvestmentApi.Models.Enums;

/// <summary>
/// Direction of the securities transfer
/// * <c>INCOMING</c> - Securities transfer is incoming to the user.
/// * <c>OUTGOING</c> - Securities transfer is outgoing from the user.
/// </summary>
[JsonConverter(typeof(StringEnumConverter<Direction1>))]
public sealed record Direction1 : OpenStringEnum<Direction1>
{
    private Direction1(string value) : base(value)
    {
    }

    public static readonly Direction1 Incoming = new("INCOMING");

    public static readonly Direction1 Outgoing = new("OUTGOING");

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
