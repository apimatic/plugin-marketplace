using System;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using UpvestInvestmentApi.Core.Models;
using UpvestInvestmentApi.Core.Validation;

namespace UpvestInvestmentApi.Models.AnyOf;

/// <summary>
/// Instrument unique identifier.
/// </summary>
[JsonConverter(typeof(InstrumentUniqueIdentifier5Converter))]
public record InstrumentUniqueIdentifier5
{
    private readonly Optional<string> _stringValue;

    private readonly Optional<string> _string2Value;

    private readonly Optional<UnknownArm> _unknownValue;

    private InstrumentUniqueIdentifier5(Optional<string> stringValue,
        Optional<string> string2Value,
        Optional<UnknownArm> unknownValue)
    {
        _stringValue = stringValue;
        _string2Value = string2Value;
        _unknownValue = unknownValue;
    }

    public static InstrumentUniqueIdentifier5 String(string value) =>
        new(Optional<string>.Some(value), default, default);

    public static InstrumentUniqueIdentifier5 String2(string value) =>
        new(default, Optional<string>.Some(value), default);

    internal static InstrumentUniqueIdentifier5 Unknown(JsonElement value) =>
        new(default, default, Optional<UnknownArm>.Some(new UnknownArm(value)));

    public bool TryGetString([NotNullWhen(true)] out string? value) => _stringValue.TryGetValue(out value);

    public bool TryGetString2([NotNullWhen(true)] out string? value) => _string2Value.TryGetValue(out value);

    public bool TryGetUnknown(out JsonElement value) => _unknownValue.TryGetValue(out value);

    public TResult Match<TResult>(Func<string, TResult> onString,
        Func<string, TResult> onString2,
        Func<JsonElement, TResult> otherwise) =>
        this switch
        {
            _ when TryGetString(out var stringValue) => onString(stringValue),
            _ when TryGetString2(out var string2Value) => onString2(string2Value),
            _ when TryGetUnknown(out var unknownValue) => otherwise(unknownValue),
            _ => throw new InvalidOperationException($"{nameof(InstrumentUniqueIdentifier5)} holds no value.")
        };

    public void Match(Action<string> onString, Action<string> onString2, Action<JsonElement> otherwise)
    {
        if (TryGetString(out var stringValue)) onString(stringValue);
        else if (TryGetString2(out var string2Value)) onString2(string2Value);
        else if (TryGetUnknown(out var unknownValue)) otherwise(unknownValue);
        else throw new InvalidOperationException($"{nameof(InstrumentUniqueIdentifier5)} holds no value.");
    }
}

file sealed class InstrumentUniqueIdentifier5Converter : JsonConverter<InstrumentUniqueIdentifier5>
{
    public override InstrumentUniqueIdentifier5 Read(ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options)
    {
        using var doc = JsonDocument.ParseValue(ref reader);
        var root = doc.RootElement;
        if (root.ValueKind == JsonValueKind.String)
        {
            var value = root.GetString()!;
            if (value.MatchesPattern("^[A-Z]{2}[A-Z0-9]{9}[0-9]$"))
            {
                return InstrumentUniqueIdentifier5.String(value);
            }
            if (value.MatchesPattern("^[A-HJ-NP-Z0-9]{6}$"))
            {
                return InstrumentUniqueIdentifier5.String2(value);
            }
        }
        return InstrumentUniqueIdentifier5.Unknown(root);
    }

    public override void Write(Utf8JsonWriter writer, InstrumentUniqueIdentifier5 value, JsonSerializerOptions options)
    {
        if (value.TryGetString(out var stringValue))
        {
            JsonSerializer.Serialize(writer, stringValue, options);
        }
        else if (value.TryGetString2(out var string2Value))
        {
            JsonSerializer.Serialize(writer, string2Value, options);
        }
        else if (value.TryGetUnknown(out var unknownValue))
        {
            unknownValue.WriteTo(writer);
        }
        else
        {
            throw new JsonException($"{nameof(InstrumentUniqueIdentifier5)} contains no valid value to serialize.");
        }
    }
}
