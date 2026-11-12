using System;
using System.Text.Json.Serialization;
using UpvestInvestmentApi.Core.Enum;

namespace UpvestInvestmentApi.Models.Enums;

/// <summary>
/// The cost category a return impact figure belongs to.
/// * ENTRY — One-off costs of building the position: product entry, transaction and incidental costs, the transaction fee and financial transaction tax on the order, and inducements.
/// * ONGOING — Costs accruing on the capital held: product running costs and the annual AUM-based fee. Always zero for sell orders.
/// * EXIT — Costs of liquidating the position at the end of the holding period: the sell transaction fee. Always zero for sell orders.
/// </summary>
[JsonConverter(typeof(StringEnumConverter<CostDetailType>))]
public sealed record CostDetailType : OpenStringEnum<CostDetailType>
{
    private CostDetailType(string value) : base(value)
    {
    }

    public static readonly CostDetailType Entry = new("ENTRY");

    public static readonly CostDetailType Ongoing = new("ONGOING");

    public static readonly CostDetailType Exit = new("EXIT");

    public TResult Match<TResult>(Func<TResult> onEntry,
        Func<TResult> onOngoing,
        Func<TResult> onExit,
        Func<string, TResult> otherwise) =>
        this switch
        {
            _ when this == Entry => onEntry(),
            _ when this == Ongoing => onOngoing(),
            _ when this == Exit => onExit(),
            _ => otherwise(Value)
        };

    public void Match(Action onEntry, Action onOngoing, Action onExit, Action<string> otherwise)
    {
        if (this == Entry) onEntry();
        else if (this == Ongoing) onOngoing();
        else if (this == Exit) onExit();
        else otherwise(Value);
    }
}
