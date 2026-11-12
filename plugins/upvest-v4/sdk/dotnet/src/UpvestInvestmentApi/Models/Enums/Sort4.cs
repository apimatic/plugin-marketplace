using System;
using System.Text.Json.Serialization;
using UpvestInvestmentApi.Core.Enum;

namespace UpvestInvestmentApi.Models.Enums;

[JsonConverter(typeof(StringEnumConverter<Sort4>))]
public sealed record Sort4 : OpenStringEnum<Sort4>
{
    private Sort4(string value) : base(value)
    {
    }

    public static readonly Sort4 Id = new("id");

    public static readonly Sort4 CreatedAt = new("created_at");

    public TResult Match<TResult>(Func<TResult> onId, Func<TResult> onCreatedAt, Func<string, TResult> otherwise) =>
        this switch
        {
            _ when this == Id => onId(),
            _ when this == CreatedAt => onCreatedAt(),
            _ => otherwise(Value)
        };

    public void Match(Action onId, Action onCreatedAt, Action<string> otherwise)
    {
        if (this == Id) onId();
        else if (this == CreatedAt) onCreatedAt();
        else otherwise(Value);
    }
}
