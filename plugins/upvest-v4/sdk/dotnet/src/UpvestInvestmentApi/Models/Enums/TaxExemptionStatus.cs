using System;
using System.Text.Json.Serialization;
using UpvestInvestmentApi.Core.Enum;

namespace UpvestInvestmentApi.Models.Enums;

/// <summary>
/// Tax exemption status
/// * NEW - The tax exemption request is created.
/// * ACTIVE - The tax exemption is valid and active for the current year.
/// * EXPIRED - The tax exemption is no longer <c>ACTIVE</c> and the <c>valid_to_date</c> already lies in the past. An update is not possible.
/// * CANCELLED - The tax exemption could not be created or was cancelled.
/// </summary>
[JsonConverter(typeof(StringEnumConverter<TaxExemptionStatus>))]
public sealed record TaxExemptionStatus : OpenStringEnum<TaxExemptionStatus>
{
    private TaxExemptionStatus(string value) : base(value)
    {
    }

    public static readonly TaxExemptionStatus New = new("NEW");

    public static readonly TaxExemptionStatus Active = new("ACTIVE");

    public static readonly TaxExemptionStatus Expired = new("EXPIRED");

    public static readonly TaxExemptionStatus Cancelled = new("CANCELLED");

    public TResult Match<TResult>(Func<TResult> onNew,
        Func<TResult> onActive,
        Func<TResult> onExpired,
        Func<TResult> onCancelled,
        Func<string, TResult> otherwise) =>
        this switch
        {
            _ when this == New => onNew(),
            _ when this == Active => onActive(),
            _ when this == Expired => onExpired(),
            _ when this == Cancelled => onCancelled(),
            _ => otherwise(Value)
        };

    public void Match(Action onNew, Action onActive, Action onExpired, Action onCancelled, Action<string> otherwise)
    {
        if (this == New) onNew();
        else if (this == Active) onActive();
        else if (this == Expired) onExpired();
        else if (this == Cancelled) onCancelled();
        else otherwise(Value);
    }
}
