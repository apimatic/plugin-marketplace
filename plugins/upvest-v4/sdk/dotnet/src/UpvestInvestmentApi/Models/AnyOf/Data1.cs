using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using UpvestInvestmentApi.Core.Extensions;
using UpvestInvestmentApi.Core.Models;

namespace UpvestInvestmentApi.Models.AnyOf;

[JsonConverter(typeof(Data1Converter))]
public record Data1
{
    private readonly Optional<IReadOnlyList<UserByol>> _listOfUserByolValue;

    private readonly Optional<IReadOnlyList<UserTol>> _listOfUserTolValue;

    private readonly Optional<UnknownArm> _unknownValue;

    private Data1(Optional<IReadOnlyList<UserByol>> listOfUserByolValue,
        Optional<IReadOnlyList<UserTol>> listOfUserTolValue,
        Optional<UnknownArm> unknownValue)
    {
        _listOfUserByolValue = listOfUserByolValue;
        _listOfUserTolValue = listOfUserTolValue;
        _unknownValue = unknownValue;
    }

    public static Data1 ListOfUserByol(IReadOnlyList<UserByol> value) =>
        new(Optional<IReadOnlyList<UserByol>>.Some(value), default, default);

    public static Data1 ListOfUserTol(IReadOnlyList<UserTol> value) =>
        new(default, Optional<IReadOnlyList<UserTol>>.Some(value), default);

    internal static Data1 Unknown(JsonElement value) =>
        new(default, default, Optional<UnknownArm>.Some(new UnknownArm(value)));

    public bool TryGetListOfUserByol([NotNullWhen(true)] out IReadOnlyList<UserByol>? value) =>
        _listOfUserByolValue.TryGetValue(out value);

    public bool TryGetListOfUserTol([NotNullWhen(true)] out IReadOnlyList<UserTol>? value) =>
        _listOfUserTolValue.TryGetValue(out value);

    public bool TryGetUnknown(out JsonElement value) => _unknownValue.TryGetValue(out value);

    public TResult Match<TResult>(Func<IReadOnlyList<UserByol>, TResult> onListOfUserByol,
        Func<IReadOnlyList<UserTol>, TResult> onListOfUserTol,
        Func<JsonElement, TResult> otherwise) =>
        this switch
        {
            _ when TryGetListOfUserByol(out var listOfUserByolValue) => onListOfUserByol(listOfUserByolValue),
            _ when TryGetListOfUserTol(out var listOfUserTolValue) => onListOfUserTol(listOfUserTolValue),
            _ when TryGetUnknown(out var unknownValue) => otherwise(unknownValue),
            _ => throw new InvalidOperationException($"{nameof(Data1)} holds no value.")
        };

    public void Match(Action<IReadOnlyList<UserByol>> onListOfUserByol,
        Action<IReadOnlyList<UserTol>> onListOfUserTol,
        Action<JsonElement> otherwise)
    {
        if (TryGetListOfUserByol(out var listOfUserByolValue)) onListOfUserByol(listOfUserByolValue);
        else if (TryGetListOfUserTol(out var listOfUserTolValue)) onListOfUserTol(listOfUserTolValue);
        else if (TryGetUnknown(out var unknownValue)) otherwise(unknownValue);
        else throw new InvalidOperationException($"{nameof(Data1)} holds no value.");
    }
}

file sealed class Data1Converter : JsonConverter<Data1>
{
    public override Data1 Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        using var doc = JsonDocument.ParseValue(ref reader);
        var root = doc.RootElement;
        if (JsonSerializer.TryDeserialize<IReadOnlyList<UserByol>>(root, options, out var listOfUserByolValue))
        {
            return Data1.ListOfUserByol(listOfUserByolValue);
        }
        if (JsonSerializer.TryDeserialize<IReadOnlyList<UserTol>>(root, options, out var listOfUserTolValue))
        {
            return Data1.ListOfUserTol(listOfUserTolValue);
        }
        return Data1.Unknown(root);
    }

    public override void Write(Utf8JsonWriter writer, Data1 value, JsonSerializerOptions options)
    {
        if (value.TryGetListOfUserByol(out var listOfUserByolValue))
        {
            JsonSerializer.Serialize(writer, listOfUserByolValue, options);
        }
        else if (value.TryGetListOfUserTol(out var listOfUserTolValue))
        {
            JsonSerializer.Serialize(writer, listOfUserTolValue, options);
        }
        else if (value.TryGetUnknown(out var unknownValue))
        {
            unknownValue.WriteTo(writer);
        }
        else
        {
            throw new JsonException($"{nameof(Data1)} contains no valid value to serialize.");
        }
    }
}
