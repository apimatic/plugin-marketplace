using System;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using UpvestInvestmentApi.Core.Extensions;
using UpvestInvestmentApi.Core.Models;

namespace UpvestInvestmentApi.Models.AnyOf;

/// <summary>
/// Request body for initiating an account liquidation. Exactly one of <c>user_id</c> or <c>business_id</c> must be provided.
/// </summary>
[JsonConverter(typeof(AccountLiquidationRequest2Converter))]
public record AccountLiquidationRequest2
{
    private readonly Optional<AccountLiquidationRequest> _accountLiquidationRequestValue;

    private readonly Optional<AccountLiquidationRequest1> _accountLiquidationRequest1Value;

    private readonly Optional<UnknownArm> _unknownValue;

    private AccountLiquidationRequest2(Optional<AccountLiquidationRequest> accountLiquidationRequestValue,
        Optional<AccountLiquidationRequest1> accountLiquidationRequest1Value,
        Optional<UnknownArm> unknownValue)
    {
        _accountLiquidationRequestValue = accountLiquidationRequestValue;
        _accountLiquidationRequest1Value = accountLiquidationRequest1Value;
        _unknownValue = unknownValue;
    }

    public static AccountLiquidationRequest2 AccountLiquidationRequest(AccountLiquidationRequest value) =>
        new(Optional<AccountLiquidationRequest>.Some(value), default, default);

    public static AccountLiquidationRequest2 AccountLiquidationRequest1(AccountLiquidationRequest1 value) =>
        new(default, Optional<AccountLiquidationRequest1>.Some(value), default);

    internal static AccountLiquidationRequest2 Unknown(JsonElement value) =>
        new(default, default, Optional<UnknownArm>.Some(new UnknownArm(value)));

    public bool TryGetAccountLiquidationRequest([NotNullWhen(true)] out AccountLiquidationRequest? value) =>
        _accountLiquidationRequestValue.TryGetValue(out value);

    public bool TryGetAccountLiquidationRequest1([NotNullWhen(true)] out AccountLiquidationRequest1? value) =>
        _accountLiquidationRequest1Value.TryGetValue(out value);

    public bool TryGetUnknown(out JsonElement value) => _unknownValue.TryGetValue(out value);

    public static implicit operator AccountLiquidationRequest2(AccountLiquidationRequest value) =>
        AccountLiquidationRequest(value);

    public static implicit operator AccountLiquidationRequest2(AccountLiquidationRequest1 value) =>
        AccountLiquidationRequest1(value);

    public TResult Match<TResult>(Func<AccountLiquidationRequest, TResult> onAccountLiquidationRequest,
        Func<AccountLiquidationRequest1, TResult> onAccountLiquidationRequest1,
        Func<JsonElement, TResult> otherwise) =>
        this switch
        {
            _ when TryGetAccountLiquidationRequest(
                out var accountLiquidationRequestValue) => onAccountLiquidationRequest(accountLiquidationRequestValue),
            _ when TryGetAccountLiquidationRequest1(
                out var accountLiquidationRequest1Value) => onAccountLiquidationRequest1(
                accountLiquidationRequest1Value),
            _ when TryGetUnknown(out var unknownValue) => otherwise(unknownValue),
            _ => throw new InvalidOperationException($"{nameof(AccountLiquidationRequest2)} holds no value.")
        };

    public void Match(Action<AccountLiquidationRequest> onAccountLiquidationRequest,
        Action<AccountLiquidationRequest1> onAccountLiquidationRequest1,
        Action<JsonElement> otherwise)
    {
        if (TryGetAccountLiquidationRequest(out var accountLiquidationRequestValue)) onAccountLiquidationRequest(
            accountLiquidationRequestValue);
        else if (TryGetAccountLiquidationRequest1(
            out var accountLiquidationRequest1Value)) onAccountLiquidationRequest1(accountLiquidationRequest1Value);
        else if (TryGetUnknown(out var unknownValue)) otherwise(unknownValue);
        else throw new InvalidOperationException($"{nameof(AccountLiquidationRequest2)} holds no value.");
    }
}

file sealed class AccountLiquidationRequest2Converter : JsonConverter<AccountLiquidationRequest2>
{
    public override AccountLiquidationRequest2 Read(ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options)
    {
        using var doc = JsonDocument.ParseValue(ref reader);
        var root = doc.RootElement;
        if (JsonSerializer.TryDeserialize<AccountLiquidationRequest>(
            root,
            options,
            out var accountLiquidationRequestValue))
        {
            return AccountLiquidationRequest2.AccountLiquidationRequest(accountLiquidationRequestValue);
        }
        if (JsonSerializer.TryDeserialize<AccountLiquidationRequest1>(
            root,
            options,
            out var accountLiquidationRequest1Value))
        {
            return AccountLiquidationRequest2.AccountLiquidationRequest1(accountLiquidationRequest1Value);
        }
        return AccountLiquidationRequest2.Unknown(root);
    }

    public override void Write(Utf8JsonWriter writer, AccountLiquidationRequest2 value, JsonSerializerOptions options)
    {
        if (value.TryGetAccountLiquidationRequest(out var accountLiquidationRequestValue))
        {
            JsonSerializer.Serialize(writer, accountLiquidationRequestValue, options);
        }
        else if (value.TryGetAccountLiquidationRequest1(out var accountLiquidationRequest1Value))
        {
            JsonSerializer.Serialize(writer, accountLiquidationRequest1Value, options);
        }
        else if (value.TryGetUnknown(out var unknownValue))
        {
            unknownValue.WriteTo(writer);
        }
        else
        {
            throw new JsonException($"{nameof(AccountLiquidationRequest2)} contains no valid value to serialize.");
        }
    }
}
