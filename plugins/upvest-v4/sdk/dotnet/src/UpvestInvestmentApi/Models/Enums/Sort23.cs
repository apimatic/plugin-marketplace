using System;
using System.Text.Json.Serialization;
using UpvestInvestmentApi.Core.Enum;

namespace UpvestInvestmentApi.Models.Enums;

[JsonConverter(typeof(StringEnumConverter<Sort23>))]
public sealed record Sort23 : OpenStringEnum<Sort23>
{
    private Sort23(string value) : base(value)
    {
    }

    public static readonly Sort23 Id = new("id");

    public static readonly Sort23 Type = new("type");

    public static readonly Sort23 CreatedAt = new("created_at");

    public TResult Match<TResult>(Func<TResult> onId,
        Func<TResult> onType,
        Func<TResult> onCreatedAt,
        Func<string, TResult> otherwise) =>
        this switch
        {
            _ when this == Id => onId(),
            _ when this == Type => onType(),
            _ when this == CreatedAt => onCreatedAt(),
            _ => otherwise(Value)
        };

    public void Match(Action onId, Action onType, Action onCreatedAt, Action<string> otherwise)
    {
        if (this == Id) onId();
        else if (this == Type) onType();
        else if (this == CreatedAt) onCreatedAt();
        else otherwise(Value);
    }
}
