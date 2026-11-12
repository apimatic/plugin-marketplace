using System;
using System.Text.Json.Serialization;
using UpvestInvestmentApi.Core.Enum;

namespace UpvestInvestmentApi.Models.Enums;

/// <summary>
/// The elliptic curve the key uses.
/// * P-521 — NIST P-521.
/// </summary>
[JsonConverter(typeof(StringEnumConverter<Crv>))]
public sealed record Crv : OpenStringEnum<Crv>
{
    private Crv(string value) : base(value)
    {
    }

    public static readonly Crv P521 = new("P-521");

    public TResult Match<TResult>(Func<TResult> onP521, Func<string, TResult> otherwise) =>
        this switch
        {
            _ when this == P521 => onP521(),
            _ => otherwise(Value)
        };

    public void Match(Action onP521, Action<string> otherwise)
    {
        if (this == P521) onP521();
        else otherwise(Value);
    }
}
