using System;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using UpvestInvestmentApi.Core.Extensions;
using UpvestInvestmentApi.Core.Models;
using UpvestInvestmentApi.Core.Validation;

namespace UpvestInvestmentApi.Models.AnyOf;

[JsonConverter(typeof(InstrumentIdConverter))]
public record InstrumentId
{
    private readonly Optional<string> _stringValue;

    private readonly Optional<Guid> _guidValue;

    private readonly Optional<UnknownArm> _unknownValue;

    private InstrumentId(Optional<string> stringValue, Optional<Guid> guidValue, Optional<UnknownArm> unknownValue)
    {
        _stringValue = stringValue;
        _guidValue = guidValue;
        _unknownValue = unknownValue;
    }

    public static InstrumentId String(string value) => new(Optional<string>.Some(value), default, default);

    public static InstrumentId Guid(Guid value) => new(default, Optional<Guid>.Some(value), default);

    internal static InstrumentId Unknown(JsonElement value) =>
        new(default, default, Optional<UnknownArm>.Some(new UnknownArm(value)));

    public bool TryGetString([NotNullWhen(true)] out string? value) => _stringValue.TryGetValue(out value);

    public bool TryGetGuid(out Guid value) => _guidValue.TryGetValue(out value);

    public bool TryGetUnknown(out JsonElement value) => _unknownValue.TryGetValue(out value);

    public static implicit operator InstrumentId(string value) => String(value);

    public static implicit operator InstrumentId(Guid value) => Guid(value);

    public TResult Match<TResult>(Func<string, TResult> onString,
        Func<Guid, TResult> onGuid,
        Func<JsonElement, TResult> otherwise) =>
        this switch
        {
            _ when TryGetString(out var stringValue) => onString(stringValue),
            _ when TryGetGuid(out var guidValue) => onGuid(guidValue),
            _ when TryGetUnknown(out var unknownValue) => otherwise(unknownValue),
            _ => throw new InvalidOperationException($"{nameof(InstrumentId)} holds no value.")
        };

    public void Match(Action<string> onString, Action<Guid> onGuid, Action<JsonElement> otherwise)
    {
        if (TryGetString(out var stringValue)) onString(stringValue);
        else if (TryGetGuid(out var guidValue)) onGuid(guidValue);
        else if (TryGetUnknown(out var unknownValue)) otherwise(unknownValue);
        else throw new InvalidOperationException($"{nameof(InstrumentId)} holds no value.");
    }
}

file sealed class InstrumentIdConverter : JsonConverter<InstrumentId>
{
    public override InstrumentId Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        using var doc = JsonDocument.ParseValue(ref reader);
        var root = doc.RootElement;
        if (root.ValueKind == JsonValueKind.String)
        {
            var value = root.GetString()!;
            if (value.MatchesPattern("^[A-Z]{2}[A-Z0-9]{9}[0-9]$"))
            {
                return InstrumentId.String(value);
            }
        }
        if (JsonSerializer.TryDeserialize<Guid>(root, options, out var guidValue))
        {
            return InstrumentId.Guid(guidValue);
        }
        return InstrumentId.Unknown(root);
    }

    public override void Write(Utf8JsonWriter writer, InstrumentId value, JsonSerializerOptions options)
    {
        if (value.TryGetString(out var stringValue))
        {
            JsonSerializer.Serialize(writer, stringValue, options);
        }
        else if (value.TryGetGuid(out var guidValue))
        {
            JsonSerializer.Serialize(writer, guidValue, options);
        }
        else if (value.TryGetUnknown(out var unknownValue))
        {
            unknownValue.WriteTo(writer);
        }
        else
        {
            throw new JsonException($"{nameof(InstrumentId)} contains no valid value to serialize.");
        }
    }
}
