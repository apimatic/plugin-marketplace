using System;
using System.Text.Json.Serialization;
using UpvestInvestmentApi.Core.Enum;

namespace UpvestInvestmentApi.Models.Enums;

[JsonConverter(typeof(StringEnumConverter<Sort25>))]
public sealed record Sort25 : OpenStringEnum<Sort25>
{
    private Sort25(string value) : base(value)
    {
    }

    public static readonly Sort25 AccountId = new("account_id");

    public TResult Match<TResult>(Func<TResult> onAccountId, Func<string, TResult> otherwise) =>
        this switch
        {
            _ when this == AccountId => onAccountId(),
            _ => otherwise(Value)
        };

    public void Match(Action onAccountId, Action<string> otherwise)
    {
        if (this == AccountId) onAccountId();
        else otherwise(Value);
    }
}
