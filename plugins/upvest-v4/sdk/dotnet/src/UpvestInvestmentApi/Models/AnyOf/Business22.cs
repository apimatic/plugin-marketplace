using System;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using UpvestInvestmentApi.Core.Extensions;
using UpvestInvestmentApi.Core.Models;

namespace UpvestInvestmentApi.Models.AnyOf;

/// <summary>
/// A business entity onboarded with Upvest, either a company or a sole trader.
/// </summary>
[JsonConverter(typeof(Business22Converter))]
public record Business22
{
    private readonly Optional<Business2> _business2Value;

    private readonly Optional<Business21> _business21Value;

    private readonly Optional<UnknownArm> _unknownValue;

    private Business22(Optional<Business2> business2Value,
        Optional<Business21> business21Value,
        Optional<UnknownArm> unknownValue)
    {
        _business2Value = business2Value;
        _business21Value = business21Value;
        _unknownValue = unknownValue;
    }

    public static Business22 Business2(Business2 value) => new(Optional<Business2>.Some(value), default, default);

    public static Business22 Business21(Business21 value) => new(default, Optional<Business21>.Some(value), default);

    internal static Business22 Unknown(JsonElement value) =>
        new(default, default, Optional<UnknownArm>.Some(new UnknownArm(value)));

    public bool TryGetBusiness2([NotNullWhen(true)] out Business2? value) => _business2Value.TryGetValue(out value);

    public bool TryGetBusiness21([NotNullWhen(true)] out Business21? value) => _business21Value.TryGetValue(out value);

    public bool TryGetUnknown(out JsonElement value) => _unknownValue.TryGetValue(out value);

    public static implicit operator Business22(Business2 value) => Business2(value);

    public static implicit operator Business22(Business21 value) => Business21(value);

    public TResult Match<TResult>(Func<Business2, TResult> onBusiness2,
        Func<Business21, TResult> onBusiness21,
        Func<JsonElement, TResult> otherwise) =>
        this switch
        {
            _ when TryGetBusiness2(out var business2Value) => onBusiness2(business2Value),
            _ when TryGetBusiness21(out var business21Value) => onBusiness21(business21Value),
            _ when TryGetUnknown(out var unknownValue) => otherwise(unknownValue),
            _ => throw new InvalidOperationException($"{nameof(Business22)} holds no value.")
        };

    public void Match(Action<Business2> onBusiness2, Action<Business21> onBusiness21, Action<JsonElement> otherwise)
    {
        if (TryGetBusiness2(out var business2Value)) onBusiness2(business2Value);
        else if (TryGetBusiness21(out var business21Value)) onBusiness21(business21Value);
        else if (TryGetUnknown(out var unknownValue)) otherwise(unknownValue);
        else throw new InvalidOperationException($"{nameof(Business22)} holds no value.");
    }
}

file sealed class Business22Converter : JsonConverter<Business22>
{
    public override Business22 Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        using var doc = JsonDocument.ParseValue(ref reader);
        var root = doc.RootElement;
        if (JsonSerializer.TryDeserialize<Business2>(root, options, out var business2Value))
        {
            return Business22.Business2(business2Value);
        }
        if (JsonSerializer.TryDeserialize<Business21>(root, options, out var business21Value))
        {
            return Business22.Business21(business21Value);
        }
        return Business22.Unknown(root);
    }

    public override void Write(Utf8JsonWriter writer, Business22 value, JsonSerializerOptions options)
    {
        if (value.TryGetBusiness2(out var business2Value))
        {
            JsonSerializer.Serialize(writer, business2Value, options);
        }
        else if (value.TryGetBusiness21(out var business21Value))
        {
            JsonSerializer.Serialize(writer, business21Value, options);
        }
        else if (value.TryGetUnknown(out var unknownValue))
        {
            unknownValue.WriteTo(writer);
        }
        else
        {
            throw new JsonException($"{nameof(Business22)} contains no valid value to serialize.");
        }
    }
}
