using System;
using System.Text.Json.Serialization;
using UpvestInvestmentApi.Core.Enum;

namespace UpvestInvestmentApi.Models.Enums;

/// <summary>
/// Report format
/// </summary>
[JsonConverter(typeof(StringEnumConverter<Accept>))]
public sealed record Accept : OpenStringEnum<Accept>
{
    private Accept(string value) : base(value)
    {
    }

    public static readonly Accept ApplicationJson = new("application/json");

    public static readonly Accept ApplicationPdf = new("application/pdf");

    public TResult Match<TResult>(Func<TResult> onApplicationJson,
        Func<TResult> onApplicationPdf,
        Func<string, TResult> otherwise) =>
        this switch
        {
            _ when this == ApplicationJson => onApplicationJson(),
            _ when this == ApplicationPdf => onApplicationPdf(),
            _ => otherwise(Value)
        };

    public void Match(Action onApplicationJson, Action onApplicationPdf, Action<string> otherwise)
    {
        if (this == ApplicationJson) onApplicationJson();
        else if (this == ApplicationPdf) onApplicationPdf();
        else otherwise(Value);
    }
}
