using System;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using UpvestInvestmentApi.Core.Extensions;
using UpvestInvestmentApi.Core.Models;

namespace UpvestInvestmentApi.Models.AnyOf;

/// <summary>
/// The planned order that an ex-ante cost report is calculated for.
/// </summary>
[JsonConverter(typeof(Order561Converter))]
public record Order561
{
    private readonly Optional<ExAnteCostUserOrder> _exAnteCostUserOrderValue;

    private readonly Optional<ExAnteCostBusinessOrder> _exAnteCostBusinessOrderValue;

    private readonly Optional<UnknownArm> _unknownValue;

    private Order561(Optional<ExAnteCostUserOrder> exAnteCostUserOrderValue,
        Optional<ExAnteCostBusinessOrder> exAnteCostBusinessOrderValue,
        Optional<UnknownArm> unknownValue)
    {
        _exAnteCostUserOrderValue = exAnteCostUserOrderValue;
        _exAnteCostBusinessOrderValue = exAnteCostBusinessOrderValue;
        _unknownValue = unknownValue;
    }

    public static Order561 ExAnteCostUserOrder(ExAnteCostUserOrder value) =>
        new(Optional<ExAnteCostUserOrder>.Some(value), default, default);

    public static Order561 ExAnteCostBusinessOrder(ExAnteCostBusinessOrder value) =>
        new(default, Optional<ExAnteCostBusinessOrder>.Some(value), default);

    internal static Order561 Unknown(JsonElement value) =>
        new(default, default, Optional<UnknownArm>.Some(new UnknownArm(value)));

    public bool TryGetExAnteCostUserOrder([NotNullWhen(true)] out ExAnteCostUserOrder? value) =>
        _exAnteCostUserOrderValue.TryGetValue(out value);

    public bool TryGetExAnteCostBusinessOrder([NotNullWhen(true)] out ExAnteCostBusinessOrder? value) =>
        _exAnteCostBusinessOrderValue.TryGetValue(out value);

    public bool TryGetUnknown(out JsonElement value) => _unknownValue.TryGetValue(out value);

    public static implicit operator Order561(ExAnteCostUserOrder value) => ExAnteCostUserOrder(value);

    public static implicit operator Order561(ExAnteCostBusinessOrder value) => ExAnteCostBusinessOrder(value);

    public TResult Match<TResult>(Func<ExAnteCostUserOrder, TResult> onExAnteCostUserOrder,
        Func<ExAnteCostBusinessOrder, TResult> onExAnteCostBusinessOrder,
        Func<JsonElement, TResult> otherwise) =>
        this switch
        {
            _ when TryGetExAnteCostUserOrder(out var exAnteCostUserOrderValue) => onExAnteCostUserOrder(
                exAnteCostUserOrderValue),
            _ when TryGetExAnteCostBusinessOrder(out var exAnteCostBusinessOrderValue) => onExAnteCostBusinessOrder(
                exAnteCostBusinessOrderValue),
            _ when TryGetUnknown(out var unknownValue) => otherwise(unknownValue),
            _ => throw new InvalidOperationException($"{nameof(Order561)} holds no value.")
        };

    public void Match(Action<ExAnteCostUserOrder> onExAnteCostUserOrder,
        Action<ExAnteCostBusinessOrder> onExAnteCostBusinessOrder,
        Action<JsonElement> otherwise)
    {
        if (TryGetExAnteCostUserOrder(out var exAnteCostUserOrderValue)) onExAnteCostUserOrder(
            exAnteCostUserOrderValue);
        else if (TryGetExAnteCostBusinessOrder(out var exAnteCostBusinessOrderValue)) onExAnteCostBusinessOrder(
            exAnteCostBusinessOrderValue);
        else if (TryGetUnknown(out var unknownValue)) otherwise(unknownValue);
        else throw new InvalidOperationException($"{nameof(Order561)} holds no value.");
    }
}

file sealed class Order561Converter : JsonConverter<Order561>
{
    public override Order561 Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        using var doc = JsonDocument.ParseValue(ref reader);
        var root = doc.RootElement;
        if (JsonSerializer.TryDeserialize<ExAnteCostUserOrder>(root, options, out var exAnteCostUserOrderValue))
        {
            return Order561.ExAnteCostUserOrder(exAnteCostUserOrderValue);
        }
        if (JsonSerializer.TryDeserialize<ExAnteCostBusinessOrder>(root, options, out var exAnteCostBusinessOrderValue))
        {
            return Order561.ExAnteCostBusinessOrder(exAnteCostBusinessOrderValue);
        }
        return Order561.Unknown(root);
    }

    public override void Write(Utf8JsonWriter writer, Order561 value, JsonSerializerOptions options)
    {
        if (value.TryGetExAnteCostUserOrder(out var exAnteCostUserOrderValue))
        {
            JsonSerializer.Serialize(writer, exAnteCostUserOrderValue, options);
        }
        else if (value.TryGetExAnteCostBusinessOrder(out var exAnteCostBusinessOrderValue))
        {
            JsonSerializer.Serialize(writer, exAnteCostBusinessOrderValue, options);
        }
        else if (value.TryGetUnknown(out var unknownValue))
        {
            unknownValue.WriteTo(writer);
        }
        else
        {
            throw new JsonException($"{nameof(Order561)} contains no valid value to serialize.");
        }
    }
}
