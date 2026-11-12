using System;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using UpvestInvestmentApi.Core.Extensions;
using UpvestInvestmentApi.Core.Models;

namespace UpvestInvestmentApi.Models.AnyOf;

/// <summary>
/// A fee included in an ex-ante cost calculation, expressed as an absolute amount, a relative rate, or a reference to a transaction fee model.
/// </summary>
[JsonConverter(typeof(Fee4Converter))]
public record Fee4
{
    private readonly Optional<AbsoluteFee4> _absoluteFee4Value;

    private readonly Optional<RelativeFee> _relativeFeeValue;

    private readonly Optional<TransactionFee> _transactionFeeValue;

    private readonly Optional<UnknownArm> _unknownValue;

    private Fee4(Optional<AbsoluteFee4> absoluteFee4Value,
        Optional<RelativeFee> relativeFeeValue,
        Optional<TransactionFee> transactionFeeValue,
        Optional<UnknownArm> unknownValue)
    {
        _absoluteFee4Value = absoluteFee4Value;
        _relativeFeeValue = relativeFeeValue;
        _transactionFeeValue = transactionFeeValue;
        _unknownValue = unknownValue;
    }

    public static Fee4 AbsoluteFee4(AbsoluteFee4 value) =>
        new(Optional<AbsoluteFee4>.Some(value), default, default, default);

    public static Fee4 RelativeFee(RelativeFee value) =>
        new(default, Optional<RelativeFee>.Some(value), default, default);

    public static Fee4 TransactionFee(TransactionFee value) =>
        new(default, default, Optional<TransactionFee>.Some(value), default);

    internal static Fee4 Unknown(JsonElement value) =>
        new(default, default, default, Optional<UnknownArm>.Some(new UnknownArm(value)));

    public bool TryGetAbsoluteFee4([NotNullWhen(true)] out AbsoluteFee4? value) =>
        _absoluteFee4Value.TryGetValue(out value);

    public bool TryGetRelativeFee([NotNullWhen(true)] out RelativeFee? value) =>
        _relativeFeeValue.TryGetValue(out value);

    public bool TryGetTransactionFee([NotNullWhen(true)] out TransactionFee? value) =>
        _transactionFeeValue.TryGetValue(out value);

    public bool TryGetUnknown(out JsonElement value) => _unknownValue.TryGetValue(out value);

    public static implicit operator Fee4(AbsoluteFee4 value) => AbsoluteFee4(value);

    public static implicit operator Fee4(RelativeFee value) => RelativeFee(value);

    public static implicit operator Fee4(TransactionFee value) => TransactionFee(value);

    public TResult Match<TResult>(Func<AbsoluteFee4, TResult> onAbsoluteFee4,
        Func<RelativeFee, TResult> onRelativeFee,
        Func<TransactionFee, TResult> onTransactionFee,
        Func<JsonElement, TResult> otherwise) =>
        this switch
        {
            _ when TryGetAbsoluteFee4(out var absoluteFee4Value) => onAbsoluteFee4(absoluteFee4Value),
            _ when TryGetRelativeFee(out var relativeFeeValue) => onRelativeFee(relativeFeeValue),
            _ when TryGetTransactionFee(out var transactionFeeValue) => onTransactionFee(transactionFeeValue),
            _ when TryGetUnknown(out var unknownValue) => otherwise(unknownValue),
            _ => throw new InvalidOperationException($"{nameof(Fee4)} holds no value.")
        };

    public void Match(Action<AbsoluteFee4> onAbsoluteFee4,
        Action<RelativeFee> onRelativeFee,
        Action<TransactionFee> onTransactionFee,
        Action<JsonElement> otherwise)
    {
        if (TryGetAbsoluteFee4(out var absoluteFee4Value)) onAbsoluteFee4(absoluteFee4Value);
        else if (TryGetRelativeFee(out var relativeFeeValue)) onRelativeFee(relativeFeeValue);
        else if (TryGetTransactionFee(out var transactionFeeValue)) onTransactionFee(transactionFeeValue);
        else if (TryGetUnknown(out var unknownValue)) otherwise(unknownValue);
        else throw new InvalidOperationException($"{nameof(Fee4)} holds no value.");
    }
}

file sealed class Fee4Converter : JsonConverter<Fee4>
{
    public override Fee4 Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        using var doc = JsonDocument.ParseValue(ref reader);
        var root = doc.RootElement;
        if (JsonSerializer.TryDeserialize<AbsoluteFee4>(root, options, out var absoluteFee4Value))
        {
            return Fee4.AbsoluteFee4(absoluteFee4Value);
        }
        if (JsonSerializer.TryDeserialize<RelativeFee>(root, options, out var relativeFeeValue))
        {
            return Fee4.RelativeFee(relativeFeeValue);
        }
        if (JsonSerializer.TryDeserialize<TransactionFee>(root, options, out var transactionFeeValue))
        {
            return Fee4.TransactionFee(transactionFeeValue);
        }
        return Fee4.Unknown(root);
    }

    public override void Write(Utf8JsonWriter writer, Fee4 value, JsonSerializerOptions options)
    {
        if (value.TryGetAbsoluteFee4(out var absoluteFee4Value))
        {
            JsonSerializer.Serialize(writer, absoluteFee4Value, options);
        }
        else if (value.TryGetRelativeFee(out var relativeFeeValue))
        {
            JsonSerializer.Serialize(writer, relativeFeeValue, options);
        }
        else if (value.TryGetTransactionFee(out var transactionFeeValue))
        {
            JsonSerializer.Serialize(writer, transactionFeeValue, options);
        }
        else if (value.TryGetUnknown(out var unknownValue))
        {
            unknownValue.WriteTo(writer);
        }
        else
        {
            throw new JsonException($"{nameof(Fee4)} contains no valid value to serialize.");
        }
    }
}
