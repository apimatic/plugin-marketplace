using System;
using System.Text.Json.Serialization;
using UpvestInvestmentApi.Core.Enum;

namespace UpvestInvestmentApi.Models.Enums;

[JsonConverter(typeof(StringEnumConverter<Sort36>))]
public sealed record Sort36 : OpenStringEnum<Sort36>
{
    private Sort36(string value) : base(value)
    {
    }

    public static readonly Sort36 ExecutionDate = new("execution_date");

    public static readonly Sort36 CreatedAt = new("created_at");

    public static readonly Sort36 UpdatedAt = new("updated_at");

    public TResult Match<TResult>(Func<TResult> onExecutionDate,
        Func<TResult> onCreatedAt,
        Func<TResult> onUpdatedAt,
        Func<string, TResult> otherwise) =>
        this switch
        {
            _ when this == ExecutionDate => onExecutionDate(),
            _ when this == CreatedAt => onCreatedAt(),
            _ when this == UpdatedAt => onUpdatedAt(),
            _ => otherwise(Value)
        };

    public void Match(Action onExecutionDate, Action onCreatedAt, Action onUpdatedAt, Action<string> otherwise)
    {
        if (this == ExecutionDate) onExecutionDate();
        else if (this == CreatedAt) onCreatedAt();
        else if (this == UpdatedAt) onUpdatedAt();
        else otherwise(Value);
    }
}
