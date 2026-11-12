using System;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using UpvestInvestmentApi.Core.Extensions;
using UpvestInvestmentApi.Core.Models;

namespace UpvestInvestmentApi.Models.AnyOf;

/// <summary>
/// Request to create an account group for either a user or a business. Provide <c>user_id</c> for user account groups or <c>business_id</c> for business account groups.
/// </summary>
[JsonConverter(typeof(AccountGroupCreateRequestConverter))]
public record AccountGroupCreateRequest
{
    private readonly Optional<AccountGroupCreateUserRequest> _accountGroupCreateUserRequestValue;

    private readonly Optional<AccountGroupCreateBusinessRequest> _accountGroupCreateBusinessRequestValue;

    private readonly Optional<UnknownArm> _unknownValue;

    private AccountGroupCreateRequest(Optional<AccountGroupCreateUserRequest> accountGroupCreateUserRequestValue,
        Optional<AccountGroupCreateBusinessRequest> accountGroupCreateBusinessRequestValue,
        Optional<UnknownArm> unknownValue)
    {
        _accountGroupCreateUserRequestValue = accountGroupCreateUserRequestValue;
        _accountGroupCreateBusinessRequestValue = accountGroupCreateBusinessRequestValue;
        _unknownValue = unknownValue;
    }

    public static AccountGroupCreateRequest AccountGroupCreateUserRequest(AccountGroupCreateUserRequest value) =>
        new(Optional<AccountGroupCreateUserRequest>.Some(value), default, default);

    public static AccountGroupCreateRequest AccountGroupCreateBusinessRequest(AccountGroupCreateBusinessRequest value) =>
        new(default, Optional<AccountGroupCreateBusinessRequest>.Some(value), default);

    internal static AccountGroupCreateRequest Unknown(JsonElement value) =>
        new(default, default, Optional<UnknownArm>.Some(new UnknownArm(value)));

    public bool TryGetAccountGroupCreateUserRequest([NotNullWhen(true)] out AccountGroupCreateUserRequest? value) =>
        _accountGroupCreateUserRequestValue.TryGetValue(out value);

    public bool TryGetAccountGroupCreateBusinessRequest([NotNullWhen(true)] out AccountGroupCreateBusinessRequest? value) =>
        _accountGroupCreateBusinessRequestValue.TryGetValue(out value);

    public bool TryGetUnknown(out JsonElement value) => _unknownValue.TryGetValue(out value);

    public static implicit operator AccountGroupCreateRequest(AccountGroupCreateUserRequest value) =>
        AccountGroupCreateUserRequest(value);

    public static implicit operator AccountGroupCreateRequest(AccountGroupCreateBusinessRequest value) =>
        AccountGroupCreateBusinessRequest(value);

    public TResult Match<TResult>(Func<AccountGroupCreateUserRequest, TResult> onAccountGroupCreateUserRequest,
        Func<AccountGroupCreateBusinessRequest, TResult> onAccountGroupCreateBusinessRequest,
        Func<JsonElement, TResult> otherwise) =>
        this switch
        {
            _ when TryGetAccountGroupCreateUserRequest(
                out var accountGroupCreateUserRequestValue) => onAccountGroupCreateUserRequest(
                accountGroupCreateUserRequestValue),
            _ when TryGetAccountGroupCreateBusinessRequest(
                out var accountGroupCreateBusinessRequestValue) => onAccountGroupCreateBusinessRequest(
                accountGroupCreateBusinessRequestValue),
            _ when TryGetUnknown(out var unknownValue) => otherwise(unknownValue),
            _ => throw new InvalidOperationException($"{nameof(AccountGroupCreateRequest)} holds no value.")
        };

    public void Match(Action<AccountGroupCreateUserRequest> onAccountGroupCreateUserRequest,
        Action<AccountGroupCreateBusinessRequest> onAccountGroupCreateBusinessRequest,
        Action<JsonElement> otherwise)
    {
        if (TryGetAccountGroupCreateUserRequest(
            out var accountGroupCreateUserRequestValue)) onAccountGroupCreateUserRequest(
            accountGroupCreateUserRequestValue);
        else if (TryGetAccountGroupCreateBusinessRequest(
            out var accountGroupCreateBusinessRequestValue)) onAccountGroupCreateBusinessRequest(
            accountGroupCreateBusinessRequestValue);
        else if (TryGetUnknown(out var unknownValue)) otherwise(unknownValue);
        else throw new InvalidOperationException($"{nameof(AccountGroupCreateRequest)} holds no value.");
    }
}

file sealed class AccountGroupCreateRequestConverter : JsonConverter<AccountGroupCreateRequest>
{
    public override AccountGroupCreateRequest Read(ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options)
    {
        using var doc = JsonDocument.ParseValue(ref reader);
        var root = doc.RootElement;
        if (JsonSerializer.TryDeserialize<AccountGroupCreateUserRequest>(
            root,
            options,
            out var accountGroupCreateUserRequestValue))
        {
            return AccountGroupCreateRequest.AccountGroupCreateUserRequest(accountGroupCreateUserRequestValue);
        }
        if (JsonSerializer.TryDeserialize<AccountGroupCreateBusinessRequest>(
            root,
            options,
            out var accountGroupCreateBusinessRequestValue))
        {
            return AccountGroupCreateRequest.AccountGroupCreateBusinessRequest(accountGroupCreateBusinessRequestValue);
        }
        return AccountGroupCreateRequest.Unknown(root);
    }

    public override void Write(Utf8JsonWriter writer, AccountGroupCreateRequest value, JsonSerializerOptions options)
    {
        if (value.TryGetAccountGroupCreateUserRequest(out var accountGroupCreateUserRequestValue))
        {
            JsonSerializer.Serialize(writer, accountGroupCreateUserRequestValue, options);
        }
        else if (value.TryGetAccountGroupCreateBusinessRequest(out var accountGroupCreateBusinessRequestValue))
        {
            JsonSerializer.Serialize(writer, accountGroupCreateBusinessRequestValue, options);
        }
        else if (value.TryGetUnknown(out var unknownValue))
        {
            unknownValue.WriteTo(writer);
        }
        else
        {
            throw new JsonException($"{nameof(AccountGroupCreateRequest)} contains no valid value to serialize.");
        }
    }
}
