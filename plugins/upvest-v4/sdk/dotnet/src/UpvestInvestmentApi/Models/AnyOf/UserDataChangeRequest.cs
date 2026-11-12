using System;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using UpvestInvestmentApi.Core.Extensions;
using UpvestInvestmentApi.Core.Models;

namespace UpvestInvestmentApi.Models.AnyOf;

/// <summary>
/// Request payload for changing user data. The permitted changes depend on the operating model (TOL or BYOL).
/// </summary>
[JsonConverter(typeof(UserDataChangeRequestConverter))]
public record UserDataChangeRequest
{
    private readonly Optional<UserByolDataChangeRequest> _userByolDataChangeRequestValue;

    private readonly Optional<UserTolDataChangeRequest> _userTolDataChangeRequestValue;

    private readonly Optional<UnknownArm> _unknownValue;

    private UserDataChangeRequest(Optional<UserByolDataChangeRequest> userByolDataChangeRequestValue,
        Optional<UserTolDataChangeRequest> userTolDataChangeRequestValue,
        Optional<UnknownArm> unknownValue)
    {
        _userByolDataChangeRequestValue = userByolDataChangeRequestValue;
        _userTolDataChangeRequestValue = userTolDataChangeRequestValue;
        _unknownValue = unknownValue;
    }

    public static UserDataChangeRequest UserByolDataChangeRequest(UserByolDataChangeRequest value) =>
        new(Optional<UserByolDataChangeRequest>.Some(value), default, default);

    public static UserDataChangeRequest UserTolDataChangeRequest(UserTolDataChangeRequest value) =>
        new(default, Optional<UserTolDataChangeRequest>.Some(value), default);

    internal static UserDataChangeRequest Unknown(JsonElement value) =>
        new(default, default, Optional<UnknownArm>.Some(new UnknownArm(value)));

    public bool TryGetUserByolDataChangeRequest([NotNullWhen(true)] out UserByolDataChangeRequest? value) =>
        _userByolDataChangeRequestValue.TryGetValue(out value);

    public bool TryGetUserTolDataChangeRequest([NotNullWhen(true)] out UserTolDataChangeRequest? value) =>
        _userTolDataChangeRequestValue.TryGetValue(out value);

    public bool TryGetUnknown(out JsonElement value) => _unknownValue.TryGetValue(out value);

    public static implicit operator UserDataChangeRequest(UserByolDataChangeRequest value) =>
        UserByolDataChangeRequest(value);

    public static implicit operator UserDataChangeRequest(UserTolDataChangeRequest value) =>
        UserTolDataChangeRequest(value);

    public TResult Match<TResult>(Func<UserByolDataChangeRequest, TResult> onUserByolDataChangeRequest,
        Func<UserTolDataChangeRequest, TResult> onUserTolDataChangeRequest,
        Func<JsonElement, TResult> otherwise) =>
        this switch
        {
            _ when TryGetUserByolDataChangeRequest(
                out var userByolDataChangeRequestValue) => onUserByolDataChangeRequest(userByolDataChangeRequestValue),
            _ when TryGetUserTolDataChangeRequest(out var userTolDataChangeRequestValue) => onUserTolDataChangeRequest(
                userTolDataChangeRequestValue),
            _ when TryGetUnknown(out var unknownValue) => otherwise(unknownValue),
            _ => throw new InvalidOperationException($"{nameof(UserDataChangeRequest)} holds no value.")
        };

    public void Match(Action<UserByolDataChangeRequest> onUserByolDataChangeRequest,
        Action<UserTolDataChangeRequest> onUserTolDataChangeRequest,
        Action<JsonElement> otherwise)
    {
        if (TryGetUserByolDataChangeRequest(out var userByolDataChangeRequestValue)) onUserByolDataChangeRequest(
            userByolDataChangeRequestValue);
        else if (TryGetUserTolDataChangeRequest(out var userTolDataChangeRequestValue)) onUserTolDataChangeRequest(
            userTolDataChangeRequestValue);
        else if (TryGetUnknown(out var unknownValue)) otherwise(unknownValue);
        else throw new InvalidOperationException($"{nameof(UserDataChangeRequest)} holds no value.");
    }
}

file sealed class UserDataChangeRequestConverter : JsonConverter<UserDataChangeRequest>
{
    public override UserDataChangeRequest Read(ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options)
    {
        using var doc = JsonDocument.ParseValue(ref reader);
        var root = doc.RootElement;
        if (JsonSerializer.TryDeserialize<UserByolDataChangeRequest>(
            root,
            options,
            out var userByolDataChangeRequestValue))
        {
            return UserDataChangeRequest.UserByolDataChangeRequest(userByolDataChangeRequestValue);
        }
        if (JsonSerializer.TryDeserialize<UserTolDataChangeRequest>(
            root,
            options,
            out var userTolDataChangeRequestValue))
        {
            return UserDataChangeRequest.UserTolDataChangeRequest(userTolDataChangeRequestValue);
        }
        return UserDataChangeRequest.Unknown(root);
    }

    public override void Write(Utf8JsonWriter writer, UserDataChangeRequest value, JsonSerializerOptions options)
    {
        if (value.TryGetUserByolDataChangeRequest(out var userByolDataChangeRequestValue))
        {
            JsonSerializer.Serialize(writer, userByolDataChangeRequestValue, options);
        }
        else if (value.TryGetUserTolDataChangeRequest(out var userTolDataChangeRequestValue))
        {
            JsonSerializer.Serialize(writer, userTolDataChangeRequestValue, options);
        }
        else if (value.TryGetUnknown(out var unknownValue))
        {
            unknownValue.WriteTo(writer);
        }
        else
        {
            throw new JsonException($"{nameof(UserDataChangeRequest)} contains no valid value to serialize.");
        }
    }
}
