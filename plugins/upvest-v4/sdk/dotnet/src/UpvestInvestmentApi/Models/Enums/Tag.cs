using System;
using System.Text.Json.Serialization;
using UpvestInvestmentApi.Core.Enum;

namespace UpvestInvestmentApi.Models.Enums;

[JsonConverter(typeof(StringEnumConverter<Tag>))]
public sealed record Tag : OpenStringEnum<Tag>
{
    private Tag(string value) : base(value)
    {
    }

    public static readonly Tag ClientEmployee = new("CLIENT_EMPLOYEE");

    public TResult Match<TResult>(Func<TResult> onClientEmployee, Func<string, TResult> otherwise) =>
        this switch
        {
            _ when this == ClientEmployee => onClientEmployee(),
            _ => otherwise(Value)
        };

    public void Match(Action onClientEmployee, Action<string> otherwise)
    {
        if (this == ClientEmployee) onClientEmployee();
        else otherwise(Value);
    }
}
