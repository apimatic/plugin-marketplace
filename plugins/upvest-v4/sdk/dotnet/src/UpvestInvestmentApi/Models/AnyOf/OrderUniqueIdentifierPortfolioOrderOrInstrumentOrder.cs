using System;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using UpvestInvestmentApi.Core.Extensions;
using UpvestInvestmentApi.Core.Models;

namespace UpvestInvestmentApi.Models.AnyOf;

/// <summary>
/// Order unique identifier (Portfolio order or Instrument order)
/// </summary>
[JsonConverter(typeof(OrderUniqueIdentifierPortfolioOrderOrInstrumentOrderConverter))]
public record OrderUniqueIdentifierPortfolioOrderOrInstrumentOrder
{
    private readonly Optional<Guid> _guidValue;

    private readonly Optional<Order39> _order39Value;

    private readonly Optional<UnknownArm> _unknownValue;

    private OrderUniqueIdentifierPortfolioOrderOrInstrumentOrder(Optional<Guid> guidValue,
        Optional<Order39> order39Value,
        Optional<UnknownArm> unknownValue)
    {
        _guidValue = guidValue;
        _order39Value = order39Value;
        _unknownValue = unknownValue;
    }

    public static OrderUniqueIdentifierPortfolioOrderOrInstrumentOrder Guid(Guid value) =>
        new(Optional<Guid>.Some(value), default, default);

    public static OrderUniqueIdentifierPortfolioOrderOrInstrumentOrder Order39(Order39 value) =>
        new(default, Optional<Order39>.Some(value), default);

    internal static OrderUniqueIdentifierPortfolioOrderOrInstrumentOrder Unknown(JsonElement value) =>
        new(default, default, Optional<UnknownArm>.Some(new UnknownArm(value)));

    public bool TryGetGuid(out Guid value) => _guidValue.TryGetValue(out value);

    public bool TryGetOrder39([NotNullWhen(true)] out Order39? value) => _order39Value.TryGetValue(out value);

    public bool TryGetUnknown(out JsonElement value) => _unknownValue.TryGetValue(out value);

    public static implicit operator OrderUniqueIdentifierPortfolioOrderOrInstrumentOrder(Guid value) => Guid(value);

    public static implicit operator OrderUniqueIdentifierPortfolioOrderOrInstrumentOrder(Order39 value) =>
        Order39(value);

    public TResult Match<TResult>(Func<Guid, TResult> onGuid,
        Func<Order39, TResult> onOrder39,
        Func<JsonElement, TResult> otherwise) =>
        this switch
        {
            _ when TryGetGuid(out var guidValue) => onGuid(guidValue),
            _ when TryGetOrder39(out var order39Value) => onOrder39(order39Value),
            _ when TryGetUnknown(out var unknownValue) => otherwise(unknownValue),
            _ => throw new InvalidOperationException(
                $"{nameof(OrderUniqueIdentifierPortfolioOrderOrInstrumentOrder)} holds no value.")
        };

    public void Match(Action<Guid> onGuid, Action<Order39> onOrder39, Action<JsonElement> otherwise)
    {
        if (TryGetGuid(out var guidValue)) onGuid(guidValue);
        else if (TryGetOrder39(out var order39Value)) onOrder39(order39Value);
        else if (TryGetUnknown(out var unknownValue)) otherwise(unknownValue);
        else throw new InvalidOperationException(
            $"{nameof(OrderUniqueIdentifierPortfolioOrderOrInstrumentOrder)} holds no value.");
    }
}

file sealed class OrderUniqueIdentifierPortfolioOrderOrInstrumentOrderConverter : JsonConverter<OrderUniqueIdentifierPortfolioOrderOrInstrumentOrder>
{
    public override OrderUniqueIdentifierPortfolioOrderOrInstrumentOrder Read(ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options)
    {
        using var doc = JsonDocument.ParseValue(ref reader);
        var root = doc.RootElement;
        if (JsonSerializer.TryDeserialize<Guid>(root, options, out var guidValue))
        {
            return OrderUniqueIdentifierPortfolioOrderOrInstrumentOrder.Guid(guidValue);
        }
        if (JsonSerializer.TryDeserialize<Order39>(root, options, out var order39Value))
        {
            return OrderUniqueIdentifierPortfolioOrderOrInstrumentOrder.Order39(order39Value);
        }
        return OrderUniqueIdentifierPortfolioOrderOrInstrumentOrder.Unknown(root);
    }

    public override void Write(Utf8JsonWriter writer,
        OrderUniqueIdentifierPortfolioOrderOrInstrumentOrder value,
        JsonSerializerOptions options)
    {
        if (value.TryGetGuid(out var guidValue))
        {
            JsonSerializer.Serialize(writer, guidValue, options);
        }
        else if (value.TryGetOrder39(out var order39Value))
        {
            JsonSerializer.Serialize(writer, order39Value, options);
        }
        else if (value.TryGetUnknown(out var unknownValue))
        {
            unknownValue.WriteTo(writer);
        }
        else
        {
            throw new JsonException(
                $"{nameof(OrderUniqueIdentifierPortfolioOrderOrInstrumentOrder)} contains no valid value to serialize.");
        }
    }
}
