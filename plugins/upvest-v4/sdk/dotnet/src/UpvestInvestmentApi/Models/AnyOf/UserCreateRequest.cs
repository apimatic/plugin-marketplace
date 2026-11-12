using System;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using UpvestInvestmentApi.Core.Extensions;
using UpvestInvestmentApi.Core.Models;

namespace UpvestInvestmentApi.Models.AnyOf;

/// <summary>
/// Request payload for creating a user. The required fields depend on the operating model (TOL or BYOL).
/// </summary>
[JsonConverter(typeof(UserCreateRequestConverter))]
public record UserCreateRequest
{
    private readonly Optional<UserByolCreateRequest> _userByolCreateRequestValue;

    private readonly Optional<UserTolCreateRequest> _userTolCreateRequestValue;

    private readonly Optional<UnknownArm> _unknownValue;

    private UserCreateRequest(Optional<UserByolCreateRequest> userByolCreateRequestValue,
        Optional<UserTolCreateRequest> userTolCreateRequestValue,
        Optional<UnknownArm> unknownValue)
    {
        _userByolCreateRequestValue = userByolCreateRequestValue;
        _userTolCreateRequestValue = userTolCreateRequestValue;
        _unknownValue = unknownValue;
    }

    public static UserCreateRequest UserByolCreateRequest(UserByolCreateRequest value) =>
        new(Optional<UserByolCreateRequest>.Some(value), default, default);

    public static UserCreateRequest UserTolCreateRequest(UserTolCreateRequest value) =>
        new(default, Optional<UserTolCreateRequest>.Some(value), default);

    internal static UserCreateRequest Unknown(JsonElement value) =>
        new(default, default, Optional<UnknownArm>.Some(new UnknownArm(value)));

    public bool TryGetUserByolCreateRequest([NotNullWhen(true)] out UserByolCreateRequest? value) =>
        _userByolCreateRequestValue.TryGetValue(out value);

    public bool TryGetUserTolCreateRequest([NotNullWhen(true)] out UserTolCreateRequest? value) =>
        _userTolCreateRequestValue.TryGetValue(out value);

    public bool TryGetUnknown(out JsonElement value) => _unknownValue.TryGetValue(out value);

    public static implicit operator UserCreateRequest(UserByolCreateRequest value) => UserByolCreateRequest(value);

    public static implicit operator UserCreateRequest(UserTolCreateRequest value) => UserTolCreateRequest(value);

    public TResult Match<TResult>(Func<UserByolCreateRequest, TResult> onUserByolCreateRequest,
        Func<UserTolCreateRequest, TResult> onUserTolCreateRequest,
        Func<JsonElement, TResult> otherwise) =>
        this switch
        {
            _ when TryGetUserByolCreateRequest(out var userByolCreateRequestValue) => onUserByolCreateRequest(
                userByolCreateRequestValue),
            _ when TryGetUserTolCreateRequest(out var userTolCreateRequestValue) => onUserTolCreateRequest(
                userTolCreateRequestValue),
            _ when TryGetUnknown(out var unknownValue) => otherwise(unknownValue),
            _ => throw new InvalidOperationException($"{nameof(UserCreateRequest)} holds no value.")
        };

    public void Match(Action<UserByolCreateRequest> onUserByolCreateRequest,
        Action<UserTolCreateRequest> onUserTolCreateRequest,
        Action<JsonElement> otherwise)
    {
        if (TryGetUserByolCreateRequest(out var userByolCreateRequestValue)) onUserByolCreateRequest(
            userByolCreateRequestValue);
        else if (TryGetUserTolCreateRequest(out var userTolCreateRequestValue)) onUserTolCreateRequest(
            userTolCreateRequestValue);
        else if (TryGetUnknown(out var unknownValue)) otherwise(unknownValue);
        else throw new InvalidOperationException($"{nameof(UserCreateRequest)} holds no value.");
    }
}

file sealed class UserCreateRequestConverter : JsonConverter<UserCreateRequest>
{
    public override UserCreateRequest Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        using var doc = JsonDocument.ParseValue(ref reader);
        var root = doc.RootElement;
        if (JsonSerializer.TryDeserialize<UserByolCreateRequest>(root, options, out var userByolCreateRequestValue))
        {
            return UserCreateRequest.UserByolCreateRequest(userByolCreateRequestValue);
        }
        if (JsonSerializer.TryDeserialize<UserTolCreateRequest>(root, options, out var userTolCreateRequestValue))
        {
            return UserCreateRequest.UserTolCreateRequest(userTolCreateRequestValue);
        }
        return UserCreateRequest.Unknown(root);
    }

    public override void Write(Utf8JsonWriter writer, UserCreateRequest value, JsonSerializerOptions options)
    {
        if (value.TryGetUserByolCreateRequest(out var userByolCreateRequestValue))
        {
            JsonSerializer.Serialize(writer, userByolCreateRequestValue, options);
        }
        else if (value.TryGetUserTolCreateRequest(out var userTolCreateRequestValue))
        {
            JsonSerializer.Serialize(writer, userTolCreateRequestValue, options);
        }
        else if (value.TryGetUnknown(out var unknownValue))
        {
            unknownValue.WriteTo(writer);
        }
        else
        {
            throw new JsonException($"{nameof(UserCreateRequest)} contains no valid value to serialize.");
        }
    }
}
