using System;
using System.Text.Json.Serialization;
using UpvestInvestmentApi.Core.Enum;

namespace UpvestInvestmentApi.Models.Enums;

[JsonConverter(typeof(StringEnumConverter<Sort9>))]
public sealed record Sort9 : OpenStringEnum<Sort9>
{
    private Sort9(string value) : base(value)
    {
    }

    public static readonly Sort9 CreatedAt = new("created_at");

    public TResult Match<TResult>(Func<TResult> onCreatedAt, Func<string, TResult> otherwise) =>
        this switch
        {
            _ when this == CreatedAt => onCreatedAt(),
            _ => otherwise(Value)
        };

    public void Match(Action onCreatedAt, Action<string> otherwise)
    {
        if (this == CreatedAt) onCreatedAt();
        else otherwise(Value);
    }
}
