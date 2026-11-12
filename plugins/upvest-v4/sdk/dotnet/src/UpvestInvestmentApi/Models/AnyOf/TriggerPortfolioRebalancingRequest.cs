using System;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using UpvestInvestmentApi.Core.Extensions;
using UpvestInvestmentApi.Core.Models;

namespace UpvestInvestmentApi.Models.AnyOf;

[JsonConverter(typeof(TriggerPortfolioRebalancingRequestConverter))]
public record TriggerPortfolioRebalancingRequest
{
    private readonly Optional<Accounts> _accountsValue;

    private readonly Optional<Allocations> _allocationsValue;

    private readonly Optional<UnknownArm> _unknownValue;

    private TriggerPortfolioRebalancingRequest(Optional<Accounts> accountsValue,
        Optional<Allocations> allocationsValue,
        Optional<UnknownArm> unknownValue)
    {
        _accountsValue = accountsValue;
        _allocationsValue = allocationsValue;
        _unknownValue = unknownValue;
    }

    public static TriggerPortfolioRebalancingRequest Accounts(Accounts value) =>
        new(Optional<Accounts>.Some(value), default, default);

    public static TriggerPortfolioRebalancingRequest Allocations(Allocations value) =>
        new(default, Optional<Allocations>.Some(value), default);

    internal static TriggerPortfolioRebalancingRequest Unknown(JsonElement value) =>
        new(default, default, Optional<UnknownArm>.Some(new UnknownArm(value)));

    public bool TryGetAccounts([NotNullWhen(true)] out Accounts? value) => _accountsValue.TryGetValue(out value);

    public bool TryGetAllocations([NotNullWhen(true)] out Allocations? value) =>
        _allocationsValue.TryGetValue(out value);

    public bool TryGetUnknown(out JsonElement value) => _unknownValue.TryGetValue(out value);

    public static implicit operator TriggerPortfolioRebalancingRequest(Accounts value) => Accounts(value);

    public static implicit operator TriggerPortfolioRebalancingRequest(Allocations value) => Allocations(value);

    public TResult Match<TResult>(Func<Accounts, TResult> onAccounts,
        Func<Allocations, TResult> onAllocations,
        Func<JsonElement, TResult> otherwise) =>
        this switch
        {
            _ when TryGetAccounts(out var accountsValue) => onAccounts(accountsValue),
            _ when TryGetAllocations(out var allocationsValue) => onAllocations(allocationsValue),
            _ when TryGetUnknown(out var unknownValue) => otherwise(unknownValue),
            _ => throw new InvalidOperationException($"{nameof(TriggerPortfolioRebalancingRequest)} holds no value.")
        };

    public void Match(Action<Accounts> onAccounts, Action<Allocations> onAllocations, Action<JsonElement> otherwise)
    {
        if (TryGetAccounts(out var accountsValue)) onAccounts(accountsValue);
        else if (TryGetAllocations(out var allocationsValue)) onAllocations(allocationsValue);
        else if (TryGetUnknown(out var unknownValue)) otherwise(unknownValue);
        else throw new InvalidOperationException($"{nameof(TriggerPortfolioRebalancingRequest)} holds no value.");
    }
}

file sealed class TriggerPortfolioRebalancingRequestConverter : JsonConverter<TriggerPortfolioRebalancingRequest>
{
    public override TriggerPortfolioRebalancingRequest Read(ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options)
    {
        using var doc = JsonDocument.ParseValue(ref reader);
        var root = doc.RootElement;
        if (JsonSerializer.TryDeserialize<Accounts>(root, options, out var accountsValue))
        {
            return TriggerPortfolioRebalancingRequest.Accounts(accountsValue);
        }
        if (JsonSerializer.TryDeserialize<Allocations>(root, options, out var allocationsValue))
        {
            return TriggerPortfolioRebalancingRequest.Allocations(allocationsValue);
        }
        return TriggerPortfolioRebalancingRequest.Unknown(root);
    }

    public override void Write(Utf8JsonWriter writer,
        TriggerPortfolioRebalancingRequest value,
        JsonSerializerOptions options)
    {
        if (value.TryGetAccounts(out var accountsValue))
        {
            JsonSerializer.Serialize(writer, accountsValue, options);
        }
        else if (value.TryGetAllocations(out var allocationsValue))
        {
            JsonSerializer.Serialize(writer, allocationsValue, options);
        }
        else if (value.TryGetUnknown(out var unknownValue))
        {
            unknownValue.WriteTo(writer);
        }
        else
        {
            throw new JsonException(
                $"{nameof(TriggerPortfolioRebalancingRequest)} contains no valid value to serialize.");
        }
    }
}
