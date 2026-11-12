using System;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using UpvestInvestmentApi.Core.Extensions;
using UpvestInvestmentApi.Core.Models;

namespace UpvestInvestmentApi.Models.AnyOf;

/// <summary>
/// A fee applied to an order. Either a fixed absolute cash fee (<c>absolute_fee_configuration_item</c>) or a reference to a predefined transaction fee model.
/// </summary>
[JsonConverter(typeof(FeeConverter))]
public record Fee
{
    private readonly Optional<AbsoluteFee> _absoluteFeeValue;

    private readonly Optional<TransactionFeeModel> _transactionFeeModelValue;

    private readonly Optional<UnknownArm> _unknownValue;

    private Fee(Optional<AbsoluteFee> absoluteFeeValue,
        Optional<TransactionFeeModel> transactionFeeModelValue,
        Optional<UnknownArm> unknownValue)
    {
        _absoluteFeeValue = absoluteFeeValue;
        _transactionFeeModelValue = transactionFeeModelValue;
        _unknownValue = unknownValue;
    }

    public static Fee AbsoluteFee(AbsoluteFee value) => new(Optional<AbsoluteFee>.Some(value), default, default);

    public static Fee TransactionFeeModel(TransactionFeeModel value) =>
        new(default, Optional<TransactionFeeModel>.Some(value), default);

    internal static Fee Unknown(JsonElement value) =>
        new(default, default, Optional<UnknownArm>.Some(new UnknownArm(value)));

    public bool TryGetAbsoluteFee([NotNullWhen(true)] out AbsoluteFee? value) =>
        _absoluteFeeValue.TryGetValue(out value);

    public bool TryGetTransactionFeeModel([NotNullWhen(true)] out TransactionFeeModel? value) =>
        _transactionFeeModelValue.TryGetValue(out value);

    public bool TryGetUnknown(out JsonElement value) => _unknownValue.TryGetValue(out value);

    public static implicit operator Fee(AbsoluteFee value) => AbsoluteFee(value);

    public static implicit operator Fee(TransactionFeeModel value) => TransactionFeeModel(value);

    public TResult Match<TResult>(Func<AbsoluteFee, TResult> onAbsoluteFee,
        Func<TransactionFeeModel, TResult> onTransactionFeeModel,
        Func<JsonElement, TResult> otherwise) =>
        this switch
        {
            _ when TryGetAbsoluteFee(out var absoluteFeeValue) => onAbsoluteFee(absoluteFeeValue),
            _ when TryGetTransactionFeeModel(out var transactionFeeModelValue) => onTransactionFeeModel(
                transactionFeeModelValue),
            _ when TryGetUnknown(out var unknownValue) => otherwise(unknownValue),
            _ => throw new InvalidOperationException($"{nameof(Fee)} holds no value.")
        };

    public void Match(Action<AbsoluteFee> onAbsoluteFee,
        Action<TransactionFeeModel> onTransactionFeeModel,
        Action<JsonElement> otherwise)
    {
        if (TryGetAbsoluteFee(out var absoluteFeeValue)) onAbsoluteFee(absoluteFeeValue);
        else if (TryGetTransactionFeeModel(out var transactionFeeModelValue)) onTransactionFeeModel(
            transactionFeeModelValue);
        else if (TryGetUnknown(out var unknownValue)) otherwise(unknownValue);
        else throw new InvalidOperationException($"{nameof(Fee)} holds no value.");
    }
}

file sealed class FeeConverter : JsonConverter<Fee>
{
    public override Fee Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        using var doc = JsonDocument.ParseValue(ref reader);
        var root = doc.RootElement;
        if (JsonSerializer.TryDeserialize<AbsoluteFee>(root, options, out var absoluteFeeValue))
        {
            return Fee.AbsoluteFee(absoluteFeeValue);
        }
        if (JsonSerializer.TryDeserialize<TransactionFeeModel>(root, options, out var transactionFeeModelValue))
        {
            return Fee.TransactionFeeModel(transactionFeeModelValue);
        }
        return Fee.Unknown(root);
    }

    public override void Write(Utf8JsonWriter writer, Fee value, JsonSerializerOptions options)
    {
        if (value.TryGetAbsoluteFee(out var absoluteFeeValue))
        {
            JsonSerializer.Serialize(writer, absoluteFeeValue, options);
        }
        else if (value.TryGetTransactionFeeModel(out var transactionFeeModelValue))
        {
            JsonSerializer.Serialize(writer, transactionFeeModelValue, options);
        }
        else if (value.TryGetUnknown(out var unknownValue))
        {
            unknownValue.WriteTo(writer);
        }
        else
        {
            throw new JsonException($"{nameof(Fee)} contains no valid value to serialize.");
        }
    }
}
