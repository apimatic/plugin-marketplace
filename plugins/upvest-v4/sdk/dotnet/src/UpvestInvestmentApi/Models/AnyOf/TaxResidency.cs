using System;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using UpvestInvestmentApi.Core.Extensions;
using UpvestInvestmentApi.Core.Models;

namespace UpvestInvestmentApi.Models.AnyOf;

/// <summary>
/// A single tax residency of a user. Provide either a tax identifier number for the country, or a reason why the TIN is missing.
/// </summary>
[JsonConverter(typeof(TaxResidencyConverter))]
public record TaxResidency
{
    private readonly Optional<WithTaxIdentifierNumber> _withTaxIdentifierNumberValue;

    private readonly Optional<WithoutTaxIdentifierNumber> _withoutTaxIdentifierNumberValue;

    private readonly Optional<UnknownArm> _unknownValue;

    private TaxResidency(Optional<WithTaxIdentifierNumber> withTaxIdentifierNumberValue,
        Optional<WithoutTaxIdentifierNumber> withoutTaxIdentifierNumberValue,
        Optional<UnknownArm> unknownValue)
    {
        _withTaxIdentifierNumberValue = withTaxIdentifierNumberValue;
        _withoutTaxIdentifierNumberValue = withoutTaxIdentifierNumberValue;
        _unknownValue = unknownValue;
    }

    public static TaxResidency WithTaxIdentifierNumber(WithTaxIdentifierNumber value) =>
        new(Optional<WithTaxIdentifierNumber>.Some(value), default, default);

    public static TaxResidency WithoutTaxIdentifierNumber(WithoutTaxIdentifierNumber value) =>
        new(default, Optional<WithoutTaxIdentifierNumber>.Some(value), default);

    internal static TaxResidency Unknown(JsonElement value) =>
        new(default, default, Optional<UnknownArm>.Some(new UnknownArm(value)));

    public bool TryGetWithTaxIdentifierNumber([NotNullWhen(true)] out WithTaxIdentifierNumber? value) =>
        _withTaxIdentifierNumberValue.TryGetValue(out value);

    public bool TryGetWithoutTaxIdentifierNumber([NotNullWhen(true)] out WithoutTaxIdentifierNumber? value) =>
        _withoutTaxIdentifierNumberValue.TryGetValue(out value);

    public bool TryGetUnknown(out JsonElement value) => _unknownValue.TryGetValue(out value);

    public static implicit operator TaxResidency(WithTaxIdentifierNumber value) => WithTaxIdentifierNumber(value);

    public static implicit operator TaxResidency(WithoutTaxIdentifierNumber value) => WithoutTaxIdentifierNumber(value);

    public TResult Match<TResult>(Func<WithTaxIdentifierNumber, TResult> onWithTaxIdentifierNumber,
        Func<WithoutTaxIdentifierNumber, TResult> onWithoutTaxIdentifierNumber,
        Func<JsonElement, TResult> otherwise) =>
        this switch
        {
            _ when TryGetWithTaxIdentifierNumber(out var withTaxIdentifierNumberValue) => onWithTaxIdentifierNumber(
                withTaxIdentifierNumberValue),
            _ when TryGetWithoutTaxIdentifierNumber(
                out var withoutTaxIdentifierNumberValue) => onWithoutTaxIdentifierNumber(
                withoutTaxIdentifierNumberValue),
            _ when TryGetUnknown(out var unknownValue) => otherwise(unknownValue),
            _ => throw new InvalidOperationException($"{nameof(TaxResidency)} holds no value.")
        };

    public void Match(Action<WithTaxIdentifierNumber> onWithTaxIdentifierNumber,
        Action<WithoutTaxIdentifierNumber> onWithoutTaxIdentifierNumber,
        Action<JsonElement> otherwise)
    {
        if (TryGetWithTaxIdentifierNumber(out var withTaxIdentifierNumberValue)) onWithTaxIdentifierNumber(
            withTaxIdentifierNumberValue);
        else if (TryGetWithoutTaxIdentifierNumber(
            out var withoutTaxIdentifierNumberValue)) onWithoutTaxIdentifierNumber(withoutTaxIdentifierNumberValue);
        else if (TryGetUnknown(out var unknownValue)) otherwise(unknownValue);
        else throw new InvalidOperationException($"{nameof(TaxResidency)} holds no value.");
    }
}

file sealed class TaxResidencyConverter : JsonConverter<TaxResidency>
{
    public override TaxResidency Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        using var doc = JsonDocument.ParseValue(ref reader);
        var root = doc.RootElement;
        if (JsonSerializer.TryDeserialize<WithTaxIdentifierNumber>(root, options, out var withTaxIdentifierNumberValue))
        {
            return TaxResidency.WithTaxIdentifierNumber(withTaxIdentifierNumberValue);
        }
        if (JsonSerializer.TryDeserialize<WithoutTaxIdentifierNumber>(
            root,
            options,
            out var withoutTaxIdentifierNumberValue))
        {
            return TaxResidency.WithoutTaxIdentifierNumber(withoutTaxIdentifierNumberValue);
        }
        return TaxResidency.Unknown(root);
    }

    public override void Write(Utf8JsonWriter writer, TaxResidency value, JsonSerializerOptions options)
    {
        if (value.TryGetWithTaxIdentifierNumber(out var withTaxIdentifierNumberValue))
        {
            JsonSerializer.Serialize(writer, withTaxIdentifierNumberValue, options);
        }
        else if (value.TryGetWithoutTaxIdentifierNumber(out var withoutTaxIdentifierNumberValue))
        {
            JsonSerializer.Serialize(writer, withoutTaxIdentifierNumberValue, options);
        }
        else if (value.TryGetUnknown(out var unknownValue))
        {
            unknownValue.WriteTo(writer);
        }
        else
        {
            throw new JsonException($"{nameof(TaxResidency)} contains no valid value to serialize.");
        }
    }
}
