using System;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using UpvestInvestmentApi.Core.Extensions;
using UpvestInvestmentApi.Core.Models;

namespace UpvestInvestmentApi.Models.AnyOf;

/// <summary>
/// A single tier of a transaction fee model — either an absolute tier with a fixed cash amount or a relative tier defined in basis points.
/// </summary>
[JsonConverter(typeof(FeeTierConverter))]
public record FeeTier
{
    private readonly Optional<AbsoluteTransactionFeeTier> _absoluteTransactionFeeTierValue;

    private readonly Optional<RelativeTransactionFeeTier> _relativeTransactionFeeTierValue;

    private readonly Optional<UnknownArm> _unknownValue;

    private FeeTier(Optional<AbsoluteTransactionFeeTier> absoluteTransactionFeeTierValue,
        Optional<RelativeTransactionFeeTier> relativeTransactionFeeTierValue,
        Optional<UnknownArm> unknownValue)
    {
        _absoluteTransactionFeeTierValue = absoluteTransactionFeeTierValue;
        _relativeTransactionFeeTierValue = relativeTransactionFeeTierValue;
        _unknownValue = unknownValue;
    }

    public static FeeTier AbsoluteTransactionFeeTier(AbsoluteTransactionFeeTier value) =>
        new(Optional<AbsoluteTransactionFeeTier>.Some(value), default, default);

    public static FeeTier RelativeTransactionFeeTier(RelativeTransactionFeeTier value) =>
        new(default, Optional<RelativeTransactionFeeTier>.Some(value), default);

    internal static FeeTier Unknown(JsonElement value) =>
        new(default, default, Optional<UnknownArm>.Some(new UnknownArm(value)));

    public bool TryGetAbsoluteTransactionFeeTier([NotNullWhen(true)] out AbsoluteTransactionFeeTier? value) =>
        _absoluteTransactionFeeTierValue.TryGetValue(out value);

    public bool TryGetRelativeTransactionFeeTier([NotNullWhen(true)] out RelativeTransactionFeeTier? value) =>
        _relativeTransactionFeeTierValue.TryGetValue(out value);

    public bool TryGetUnknown(out JsonElement value) => _unknownValue.TryGetValue(out value);

    public static implicit operator FeeTier(AbsoluteTransactionFeeTier value) => AbsoluteTransactionFeeTier(value);

    public static implicit operator FeeTier(RelativeTransactionFeeTier value) => RelativeTransactionFeeTier(value);

    public TResult Match<TResult>(Func<AbsoluteTransactionFeeTier, TResult> onAbsoluteTransactionFeeTier,
        Func<RelativeTransactionFeeTier, TResult> onRelativeTransactionFeeTier,
        Func<JsonElement, TResult> otherwise) =>
        this switch
        {
            _ when TryGetAbsoluteTransactionFeeTier(
                out var absoluteTransactionFeeTierValue) => onAbsoluteTransactionFeeTier(
                absoluteTransactionFeeTierValue),
            _ when TryGetRelativeTransactionFeeTier(
                out var relativeTransactionFeeTierValue) => onRelativeTransactionFeeTier(
                relativeTransactionFeeTierValue),
            _ when TryGetUnknown(out var unknownValue) => otherwise(unknownValue),
            _ => throw new InvalidOperationException($"{nameof(FeeTier)} holds no value.")
        };

    public void Match(Action<AbsoluteTransactionFeeTier> onAbsoluteTransactionFeeTier,
        Action<RelativeTransactionFeeTier> onRelativeTransactionFeeTier,
        Action<JsonElement> otherwise)
    {
        if (TryGetAbsoluteTransactionFeeTier(out var absoluteTransactionFeeTierValue)) onAbsoluteTransactionFeeTier(
            absoluteTransactionFeeTierValue);
        else if (TryGetRelativeTransactionFeeTier(
            out var relativeTransactionFeeTierValue)) onRelativeTransactionFeeTier(relativeTransactionFeeTierValue);
        else if (TryGetUnknown(out var unknownValue)) otherwise(unknownValue);
        else throw new InvalidOperationException($"{nameof(FeeTier)} holds no value.");
    }
}

file sealed class FeeTierConverter : JsonConverter<FeeTier>
{
    public override FeeTier Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        using var doc = JsonDocument.ParseValue(ref reader);
        var root = doc.RootElement;
        if (JsonSerializer.TryDeserialize<AbsoluteTransactionFeeTier>(
            root,
            options,
            out var absoluteTransactionFeeTierValue))
        {
            return FeeTier.AbsoluteTransactionFeeTier(absoluteTransactionFeeTierValue);
        }
        if (JsonSerializer.TryDeserialize<RelativeTransactionFeeTier>(
            root,
            options,
            out var relativeTransactionFeeTierValue))
        {
            return FeeTier.RelativeTransactionFeeTier(relativeTransactionFeeTierValue);
        }
        return FeeTier.Unknown(root);
    }

    public override void Write(Utf8JsonWriter writer, FeeTier value, JsonSerializerOptions options)
    {
        if (value.TryGetAbsoluteTransactionFeeTier(out var absoluteTransactionFeeTierValue))
        {
            JsonSerializer.Serialize(writer, absoluteTransactionFeeTierValue, options);
        }
        else if (value.TryGetRelativeTransactionFeeTier(out var relativeTransactionFeeTierValue))
        {
            JsonSerializer.Serialize(writer, relativeTransactionFeeTierValue, options);
        }
        else if (value.TryGetUnknown(out var unknownValue))
        {
            unknownValue.WriteTo(writer);
        }
        else
        {
            throw new JsonException($"{nameof(FeeTier)} contains no valid value to serialize.");
        }
    }
}
