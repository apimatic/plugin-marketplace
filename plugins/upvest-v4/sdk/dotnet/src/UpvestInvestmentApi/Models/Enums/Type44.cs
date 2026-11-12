using System;
using System.Text.Json.Serialization;
using UpvestInvestmentApi.Core.Enum;

namespace UpvestInvestmentApi.Models.Enums;

/// <summary>
/// The type of report must be “ORDER_EX_ANTE_COST” or “ORDER_EX_ANTE_COST_SAVINGS_PLAN”.
/// </summary>
[JsonConverter(typeof(StringEnumConverter<Type44>))]
public sealed record Type44 : OpenStringEnum<Type44>
{
    private Type44(string value) : base(value)
    {
    }

    public static readonly Type44 OrderExAnteCost = new("ORDER_EX_ANTE_COST");

    public static readonly Type44 OrderExAnteCostSavingsPlan = new("ORDER_EX_ANTE_COST_SAVINGS_PLAN");

    public TResult Match<TResult>(Func<TResult> onOrderExAnteCost,
        Func<TResult> onOrderExAnteCostSavingsPlan,
        Func<string, TResult> otherwise) =>
        this switch
        {
            _ when this == OrderExAnteCost => onOrderExAnteCost(),
            _ when this == OrderExAnteCostSavingsPlan => onOrderExAnteCostSavingsPlan(),
            _ => otherwise(Value)
        };

    public void Match(Action onOrderExAnteCost, Action onOrderExAnteCostSavingsPlan, Action<string> otherwise)
    {
        if (this == OrderExAnteCost) onOrderExAnteCost();
        else if (this == OrderExAnteCostSavingsPlan) onOrderExAnteCostSavingsPlan();
        else otherwise(Value);
    }
}
