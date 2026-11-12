using System;
using System.Text.Json.Serialization;
using UpvestInvestmentApi.Core.Enum;

namespace UpvestInvestmentApi.Models.Enums;

/// <summary>
/// Execution flow for order processing. Defaults to <c>STRAIGHT_THROUGH</c> if not specified.
/// * STRAIGHT_THROUGH — the order is routed and executed directly without manual intervention.
/// * BLOCK — the order is bundled with other orders for block execution.
/// </summary>
[JsonConverter(typeof(StringEnumConverter<ExecutionFlow>))]
public sealed record ExecutionFlow : OpenStringEnum<ExecutionFlow>
{
    private ExecutionFlow(string value) : base(value)
    {
    }

    public static readonly ExecutionFlow StraightThrough = new("STRAIGHT_THROUGH");

    public static readonly ExecutionFlow Block = new("BLOCK");

    public TResult Match<TResult>(Func<TResult> onStraightThrough,
        Func<TResult> onBlock,
        Func<string, TResult> otherwise) =>
        this switch
        {
            _ when this == StraightThrough => onStraightThrough(),
            _ when this == Block => onBlock(),
            _ => otherwise(Value)
        };

    public void Match(Action onStraightThrough, Action onBlock, Action<string> otherwise)
    {
        if (this == StraightThrough) onStraightThrough();
        else if (this == Block) onBlock();
        else otherwise(Value);
    }
}
