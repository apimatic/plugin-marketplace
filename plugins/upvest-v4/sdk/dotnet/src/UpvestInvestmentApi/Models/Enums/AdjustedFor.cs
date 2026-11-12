using System;
using System.Text.Json.Serialization;
using UpvestInvestmentApi.Core.Enum;

namespace UpvestInvestmentApi.Models.Enums;

[JsonConverter(typeof(StringEnumConverter<AdjustedFor>))]
public sealed record AdjustedFor : OpenStringEnum<AdjustedFor>
{
    private AdjustedFor(string value) : base(value)
    {
    }

    public static readonly AdjustedFor None = new("NONE");

    public static readonly AdjustedFor All = new("ALL");

    public TResult Match<TResult>(Func<TResult> onNone, Func<TResult> onAll, Func<string, TResult> otherwise) =>
        this switch
        {
            _ when this == None => onNone(),
            _ when this == All => onAll(),
            _ => otherwise(Value)
        };

    public void Match(Action onNone, Action onAll, Action<string> otherwise)
    {
        if (this == None) onNone();
        else if (this == All) onAll();
        else otherwise(Value);
    }
}
