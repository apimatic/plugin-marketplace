using System;
using System.Text.Json.Serialization;
using UpvestInvestmentApi.Core.Models;
using UpvestInvestmentApi.Models.Enums;

namespace UpvestInvestmentApi.Models;

public record Key
{
    /// <summary>
    /// The identifier of the key, matching the <c>kid</c> in the signature header of a webhook payload.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("kid")]
    public Guid? Kid { get; init; }

    /// <summary>
    /// The cryptographic algorithm family of the key.
    /// * EC — Elliptic curve.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("kty")]
    public Kty? Kty { get; init; } = Kty.Ec;

    /// <summary>
    /// The elliptic curve the key uses.
    /// * P-521 — NIST P-521.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("crv")]
    public Crv? Crv { get; init; } = Crv.P521;

    /// <summary>
    /// The x coordinate of the elliptic curve point, base64url encoded.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("x")]
    public string? X { get; init; }

    /// <summary>
    /// The y coordinate of the elliptic curve point, base64url encoded.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("y")]
    public string? Y { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
