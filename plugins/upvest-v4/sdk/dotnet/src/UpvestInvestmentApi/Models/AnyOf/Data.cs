using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using UpvestInvestmentApi.Core.Extensions;
using UpvestInvestmentApi.Core.Models;

namespace UpvestInvestmentApi.Models.AnyOf;

/// <summary>
/// List of the requested users
/// </summary>
[JsonConverter(typeof(DataConverter))]
public record Data
{
    private readonly Optional<Data1> _data1Value;

    private readonly Optional<IReadOnlyList<object>> _listOfAnonymousObjectValue;

    private readonly Optional<UnknownArm> _unknownValue;

    private Data(Optional<Data1> data1Value,
        Optional<IReadOnlyList<object>> listOfAnonymousObjectValue,
        Optional<UnknownArm> unknownValue)
    {
        _data1Value = data1Value;
        _listOfAnonymousObjectValue = listOfAnonymousObjectValue;
        _unknownValue = unknownValue;
    }

    public static Data Data1(Data1 value) => new(Optional<Data1>.Some(value), default, default);

    public static Data ListOfAnonymousObject(IReadOnlyList<object> value) =>
        new(default, Optional<IReadOnlyList<object>>.Some(value), default);

    internal static Data Unknown(JsonElement value) =>
        new(default, default, Optional<UnknownArm>.Some(new UnknownArm(value)));

    public bool TryGetData1([NotNullWhen(true)] out Data1? value) => _data1Value.TryGetValue(out value);

    public bool TryGetListOfAnonymousObject([NotNullWhen(true)] out IReadOnlyList<object>? value) =>
        _listOfAnonymousObjectValue.TryGetValue(out value);

    public bool TryGetUnknown(out JsonElement value) => _unknownValue.TryGetValue(out value);

    public static implicit operator Data(Data1 value) => Data1(value);

    public TResult Match<TResult>(Func<Data1, TResult> onData1,
        Func<IReadOnlyList<object>, TResult> onListOfAnonymousObject,
        Func<JsonElement, TResult> otherwise) =>
        this switch
        {
            _ when TryGetData1(out var data1Value) => onData1(data1Value),
            _ when TryGetListOfAnonymousObject(out var listOfAnonymousObjectValue) => onListOfAnonymousObject(
                listOfAnonymousObjectValue),
            _ when TryGetUnknown(out var unknownValue) => otherwise(unknownValue),
            _ => throw new InvalidOperationException($"{nameof(Data)} holds no value.")
        };

    public void Match(Action<Data1> onData1,
        Action<IReadOnlyList<object>> onListOfAnonymousObject,
        Action<JsonElement> otherwise)
    {
        if (TryGetData1(out var data1Value)) onData1(data1Value);
        else if (TryGetListOfAnonymousObject(out var listOfAnonymousObjectValue)) onListOfAnonymousObject(
            listOfAnonymousObjectValue);
        else if (TryGetUnknown(out var unknownValue)) otherwise(unknownValue);
        else throw new InvalidOperationException($"{nameof(Data)} holds no value.");
    }
}

file sealed class DataConverter : JsonConverter<Data>
{
    public override Data Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        using var doc = JsonDocument.ParseValue(ref reader);
        var root = doc.RootElement;
        if (JsonSerializer.TryDeserialize<Data1>(root, options, out var data1Value))
        {
            return Data.Data1(data1Value);
        }
        if (JsonSerializer.TryDeserialize<IReadOnlyList<object>>(root, options, out var listOfAnonymousObjectValue))
        {
            return Data.ListOfAnonymousObject(listOfAnonymousObjectValue);
        }
        return Data.Unknown(root);
    }

    public override void Write(Utf8JsonWriter writer, Data value, JsonSerializerOptions options)
    {
        if (value.TryGetData1(out var data1Value))
        {
            JsonSerializer.Serialize(writer, data1Value, options);
        }
        else if (value.TryGetListOfAnonymousObject(out var listOfAnonymousObjectValue))
        {
            JsonSerializer.Serialize(writer, listOfAnonymousObjectValue, options);
        }
        else if (value.TryGetUnknown(out var unknownValue))
        {
            unknownValue.WriteTo(writer);
        }
        else
        {
            throw new JsonException($"{nameof(Data)} contains no valid value to serialize.");
        }
    }
}
