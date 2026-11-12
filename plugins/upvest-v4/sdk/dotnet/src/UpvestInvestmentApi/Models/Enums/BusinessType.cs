using System;
using System.Text.Json.Serialization;
using UpvestInvestmentApi.Core.Enum;

namespace UpvestInvestmentApi.Models.Enums;

/// <summary>
/// Type of the business.
/// </summary>
[JsonConverter(typeof(StringEnumConverter<BusinessType>))]
public sealed record BusinessType : OpenStringEnum<BusinessType>
{
    private BusinessType(string value) : base(value)
    {
    }

    public static readonly BusinessType LimitedLiabilityCompany = new("LIMITED_LIABILITY_COMPANY");

    public TResult Match<TResult>(Func<TResult> onLimitedLiabilityCompany, Func<string, TResult> otherwise) =>
        this switch
        {
            _ when this == LimitedLiabilityCompany => onLimitedLiabilityCompany(),
            _ => otherwise(Value)
        };

    public void Match(Action onLimitedLiabilityCompany, Action<string> otherwise)
    {
        if (this == LimitedLiabilityCompany) onLimitedLiabilityCompany();
        else otherwise(Value);
    }
}
