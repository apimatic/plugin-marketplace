using System;
using System.Text.Json.Serialization;
using UpvestInvestmentApi.Core.Enum;

namespace UpvestInvestmentApi.Models.Enums;

/// <summary>
/// The ordering applied to the list.
/// * ASC — Ascending order.
/// * DESC — Descending order.
/// </summary>
[JsonConverter(typeof(StringEnumConverter<Order1>))]
public sealed record Order1 : OpenStringEnum<Order1>
{
    private Order1(string value) : base(value)
    {
    }

    public static readonly Order1 Asc = new("ASC");

    public static readonly Order1 Desc = new("DESC");

    public TResult Match<TResult>(Func<TResult> onAsc, Func<TResult> onDesc, Func<string, TResult> otherwise) =>
        this switch
        {
            _ when this == Asc => onAsc(),
            _ when this == Desc => onDesc(),
            _ => otherwise(Value)
        };

    public void Match(Action onAsc, Action onDesc, Action<string> otherwise)
    {
        if (this == Asc) onAsc();
        else if (this == Desc) onDesc();
        else otherwise(Value);
    }
}
