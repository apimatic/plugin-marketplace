using System;
using System.Text.Json.Serialization;
using UpvestInvestmentApi.Core.Enum;

namespace UpvestInvestmentApi.Models.Enums;

[JsonConverter(typeof(StringEnumConverter<Sort>))]
public sealed record Sort : OpenStringEnum<Sort>
{
    private Sort(string value) : base(value)
    {
    }

    public static readonly Sort CreatedAt = new("created_at");

    public static readonly Sort UpdatedAt = new("updated_at");

    public static readonly Sort Title = new("title");

    public static readonly Sort Url = new("url");

    public static readonly Sort Enabled = new("enabled");

    public TResult Match<TResult>(Func<TResult> onCreatedAt,
        Func<TResult> onUpdatedAt,
        Func<TResult> onTitle,
        Func<TResult> onUrl,
        Func<TResult> onEnabled,
        Func<string, TResult> otherwise) =>
        this switch
        {
            _ when this == CreatedAt => onCreatedAt(),
            _ when this == UpdatedAt => onUpdatedAt(),
            _ when this == Title => onTitle(),
            _ when this == Url => onUrl(),
            _ when this == Enabled => onEnabled(),
            _ => otherwise(Value)
        };

    public void Match(Action onCreatedAt,
        Action onUpdatedAt,
        Action onTitle,
        Action onUrl,
        Action onEnabled,
        Action<string> otherwise)
    {
        if (this == CreatedAt) onCreatedAt();
        else if (this == UpdatedAt) onUpdatedAt();
        else if (this == Title) onTitle();
        else if (this == Url) onUrl();
        else if (this == Enabled) onEnabled();
        else otherwise(Value);
    }
}
