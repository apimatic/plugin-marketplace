using System;
using System.Text.Json.Serialization;
using UpvestInvestmentApi.Core.Enum;

namespace UpvestInvestmentApi.Models.Enums;

[JsonConverter(typeof(StringEnumConverter<Sort21>))]
public sealed record Sort21 : OpenStringEnum<Sort21>
{
    private Sort21(string value) : base(value)
    {
    }

    public static readonly Sort21 CreatedAt = new("created_at");

    public static readonly Sort21 ValidFrom = new("valid_from");

    public TResult Match<TResult>(Func<TResult> onCreatedAt,
        Func<TResult> onValidFrom,
        Func<string, TResult> otherwise) =>
        this switch
        {
            _ when this == CreatedAt => onCreatedAt(),
            _ when this == ValidFrom => onValidFrom(),
            _ => otherwise(Value)
        };

    public void Match(Action onCreatedAt, Action onValidFrom, Action<string> otherwise)
    {
        if (this == CreatedAt) onCreatedAt();
        else if (this == ValidFrom) onValidFrom();
        else otherwise(Value);
    }
}
