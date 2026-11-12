using System;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using UpvestInvestmentApi.Core.Extensions;
using UpvestInvestmentApi.Core.Models;

namespace UpvestInvestmentApi.Models.AnyOf;

/// <summary>
/// Request to create an account for either a user or a business, within an existing account group.
/// </summary>
[JsonConverter(typeof(AccountCreateRequestConverter))]
public record AccountCreateRequest
{
    private readonly Optional<AccountCreateUserRequest> _accountCreateUserRequestValue;

    private readonly Optional<AccountCreateBusinessRequest> _accountCreateBusinessRequestValue;

    private readonly Optional<UnknownArm> _unknownValue;

    private AccountCreateRequest(Optional<AccountCreateUserRequest> accountCreateUserRequestValue,
        Optional<AccountCreateBusinessRequest> accountCreateBusinessRequestValue,
        Optional<UnknownArm> unknownValue)
    {
        _accountCreateUserRequestValue = accountCreateUserRequestValue;
        _accountCreateBusinessRequestValue = accountCreateBusinessRequestValue;
        _unknownValue = unknownValue;
    }

    public static AccountCreateRequest AccountCreateUserRequest(AccountCreateUserRequest value) =>
        new(Optional<AccountCreateUserRequest>.Some(value), default, default);

    public static AccountCreateRequest AccountCreateBusinessRequest(AccountCreateBusinessRequest value) =>
        new(default, Optional<AccountCreateBusinessRequest>.Some(value), default);

    internal static AccountCreateRequest Unknown(JsonElement value) =>
        new(default, default, Optional<UnknownArm>.Some(new UnknownArm(value)));

    public bool TryGetAccountCreateUserRequest([NotNullWhen(true)] out AccountCreateUserRequest? value) =>
        _accountCreateUserRequestValue.TryGetValue(out value);

    public bool TryGetAccountCreateBusinessRequest([NotNullWhen(true)] out AccountCreateBusinessRequest? value) =>
        _accountCreateBusinessRequestValue.TryGetValue(out value);

    public bool TryGetUnknown(out JsonElement value) => _unknownValue.TryGetValue(out value);

    public static implicit operator AccountCreateRequest(AccountCreateUserRequest value) =>
        AccountCreateUserRequest(value);

    public static implicit operator AccountCreateRequest(AccountCreateBusinessRequest value) =>
        AccountCreateBusinessRequest(value);

    public TResult Match<TResult>(Func<AccountCreateUserRequest, TResult> onAccountCreateUserRequest,
        Func<AccountCreateBusinessRequest, TResult> onAccountCreateBusinessRequest,
        Func<JsonElement, TResult> otherwise) =>
        this switch
        {
            _ when TryGetAccountCreateUserRequest(out var accountCreateUserRequestValue) => onAccountCreateUserRequest(
                accountCreateUserRequestValue),
            _ when TryGetAccountCreateBusinessRequest(
                out var accountCreateBusinessRequestValue) => onAccountCreateBusinessRequest(
                accountCreateBusinessRequestValue),
            _ when TryGetUnknown(out var unknownValue) => otherwise(unknownValue),
            _ => throw new InvalidOperationException($"{nameof(AccountCreateRequest)} holds no value.")
        };

    public void Match(Action<AccountCreateUserRequest> onAccountCreateUserRequest,
        Action<AccountCreateBusinessRequest> onAccountCreateBusinessRequest,
        Action<JsonElement> otherwise)
    {
        if (TryGetAccountCreateUserRequest(out var accountCreateUserRequestValue)) onAccountCreateUserRequest(
            accountCreateUserRequestValue);
        else if (TryGetAccountCreateBusinessRequest(
            out var accountCreateBusinessRequestValue)) onAccountCreateBusinessRequest(
            accountCreateBusinessRequestValue);
        else if (TryGetUnknown(out var unknownValue)) otherwise(unknownValue);
        else throw new InvalidOperationException($"{nameof(AccountCreateRequest)} holds no value.");
    }
}

file sealed class AccountCreateRequestConverter : JsonConverter<AccountCreateRequest>
{
    public override AccountCreateRequest Read(ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options)
    {
        using var doc = JsonDocument.ParseValue(ref reader);
        var root = doc.RootElement;
        if (JsonSerializer.TryDeserialize<AccountCreateUserRequest>(
            root,
            options,
            out var accountCreateUserRequestValue))
        {
            return AccountCreateRequest.AccountCreateUserRequest(accountCreateUserRequestValue);
        }
        if (JsonSerializer.TryDeserialize<AccountCreateBusinessRequest>(
            root,
            options,
            out var accountCreateBusinessRequestValue))
        {
            return AccountCreateRequest.AccountCreateBusinessRequest(accountCreateBusinessRequestValue);
        }
        return AccountCreateRequest.Unknown(root);
    }

    public override void Write(Utf8JsonWriter writer, AccountCreateRequest value, JsonSerializerOptions options)
    {
        if (value.TryGetAccountCreateUserRequest(out var accountCreateUserRequestValue))
        {
            JsonSerializer.Serialize(writer, accountCreateUserRequestValue, options);
        }
        else if (value.TryGetAccountCreateBusinessRequest(out var accountCreateBusinessRequestValue))
        {
            JsonSerializer.Serialize(writer, accountCreateBusinessRequestValue, options);
        }
        else if (value.TryGetUnknown(out var unknownValue))
        {
            unknownValue.WriteTo(writer);
        }
        else
        {
            throw new JsonException($"{nameof(AccountCreateRequest)} contains no valid value to serialize.");
        }
    }
}
