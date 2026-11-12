using System;
using System.Text.Json.Serialization;
using UpvestInvestmentApi.Core.Enum;

namespace UpvestInvestmentApi.Models.Enums;

/// <summary>
/// The cryptographic algorithm family of the key.
/// * EC — Elliptic curve.
/// </summary>
[JsonConverter(typeof(StringEnumConverter<Kty>))]
public sealed record Kty : OpenStringEnum<Kty>
{
    private Kty(string value) : base(value)
    {
    }

    public static readonly Kty Ec = new("EC");

    public TResult Match<TResult>(Func<TResult> onEc, Func<string, TResult> otherwise) =>
        this switch
        {
            _ when this == Ec => onEc(),
            _ => otherwise(Value)
        };

    public void Match(Action onEc, Action<string> otherwise)
    {
        if (this == Ec) onEc();
        else otherwise(Value);
    }
}
