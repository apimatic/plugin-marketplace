using System;
using System.Text.Json.Serialization;
using UpvestInvestmentApi.Core.Enum;

namespace UpvestInvestmentApi.Models.Enums;

/// <summary>
/// Type of the fee collection.
/// * SERVICE_FEE — Service fee intake in a pre-defined cadence, for example monthly.
/// * SERVICE_FEE_LIQUIDATION — Service fee intake resulting from a portfolio liquidation.
/// </summary>
[JsonConverter(typeof(StringEnumConverter<Type37>))]
public sealed record Type37 : OpenStringEnum<Type37>
{
    private Type37(string value) : base(value)
    {
    }

    public static readonly Type37 ServiceFee = new("SERVICE_FEE");

    public static readonly Type37 ServiceFeeLiquidation = new("SERVICE_FEE_LIQUIDATION");

    public TResult Match<TResult>(Func<TResult> onServiceFee,
        Func<TResult> onServiceFeeLiquidation,
        Func<string, TResult> otherwise) =>
        this switch
        {
            _ when this == ServiceFee => onServiceFee(),
            _ when this == ServiceFeeLiquidation => onServiceFeeLiquidation(),
            _ => otherwise(Value)
        };

    public void Match(Action onServiceFee, Action onServiceFeeLiquidation, Action<string> otherwise)
    {
        if (this == ServiceFee) onServiceFee();
        else if (this == ServiceFeeLiquidation) onServiceFeeLiquidation();
        else otherwise(Value);
    }
}
