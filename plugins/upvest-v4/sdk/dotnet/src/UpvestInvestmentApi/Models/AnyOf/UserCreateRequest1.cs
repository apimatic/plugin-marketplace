using System;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using UpvestInvestmentApi.Core.Extensions;
using UpvestInvestmentApi.Core.Models;

namespace UpvestInvestmentApi.Models.AnyOf;

/// <summary>
/// The details of the created user.
/// </summary>
[JsonConverter(typeof(UserCreateRequest1Converter))]
public record UserCreateRequest1
{
    private readonly Optional<UserByol> _userByolValue;

    private readonly Optional<UserTol> _userTolValue;

    private readonly Optional<UnknownArm> _unknownValue;

    private UserCreateRequest1(Optional<UserByol> userByolValue,
        Optional<UserTol> userTolValue,
        Optional<UnknownArm> unknownValue)
    {
        _userByolValue = userByolValue;
        _userTolValue = userTolValue;
        _unknownValue = unknownValue;
    }

    public static UserCreateRequest1 UserByol(UserByol value) => new(Optional<UserByol>.Some(value), default, default);

    public static UserCreateRequest1 UserTol(UserTol value) => new(default, Optional<UserTol>.Some(value), default);

    internal static UserCreateRequest1 Unknown(JsonElement value) =>
        new(default, default, Optional<UnknownArm>.Some(new UnknownArm(value)));

    public bool TryGetUserByol([NotNullWhen(true)] out UserByol? value) => _userByolValue.TryGetValue(out value);

    public bool TryGetUserTol([NotNullWhen(true)] out UserTol? value) => _userTolValue.TryGetValue(out value);

    public bool TryGetUnknown(out JsonElement value) => _unknownValue.TryGetValue(out value);

    public static implicit operator UserCreateRequest1(UserByol value) => UserByol(value);

    public static implicit operator UserCreateRequest1(UserTol value) => UserTol(value);

    public TResult Match<TResult>(Func<UserByol, TResult> onUserByol,
        Func<UserTol, TResult> onUserTol,
        Func<JsonElement, TResult> otherwise) =>
        this switch
        {
            _ when TryGetUserByol(out var userByolValue) => onUserByol(userByolValue),
            _ when TryGetUserTol(out var userTolValue) => onUserTol(userTolValue),
            _ when TryGetUnknown(out var unknownValue) => otherwise(unknownValue),
            _ => throw new InvalidOperationException($"{nameof(UserCreateRequest1)} holds no value.")
        };

    public void Match(Action<UserByol> onUserByol, Action<UserTol> onUserTol, Action<JsonElement> otherwise)
    {
        if (TryGetUserByol(out var userByolValue)) onUserByol(userByolValue);
        else if (TryGetUserTol(out var userTolValue)) onUserTol(userTolValue);
        else if (TryGetUnknown(out var unknownValue)) otherwise(unknownValue);
        else throw new InvalidOperationException($"{nameof(UserCreateRequest1)} holds no value.");
    }
}

file sealed class UserCreateRequest1Converter : JsonConverter<UserCreateRequest1>
{
    public override UserCreateRequest1 Read(ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options)
    {
        using var doc = JsonDocument.ParseValue(ref reader);
        var root = doc.RootElement;
        if (JsonSerializer.TryDeserialize<UserByol>(root, options, out var userByolValue))
        {
            return UserCreateRequest1.UserByol(userByolValue);
        }
        if (JsonSerializer.TryDeserialize<UserTol>(root, options, out var userTolValue))
        {
            return UserCreateRequest1.UserTol(userTolValue);
        }
        return UserCreateRequest1.Unknown(root);
    }

    public override void Write(Utf8JsonWriter writer, UserCreateRequest1 value, JsonSerializerOptions options)
    {
        if (value.TryGetUserByol(out var userByolValue))
        {
            JsonSerializer.Serialize(writer, userByolValue, options);
        }
        else if (value.TryGetUserTol(out var userTolValue))
        {
            JsonSerializer.Serialize(writer, userTolValue, options);
        }
        else if (value.TryGetUnknown(out var unknownValue))
        {
            unknownValue.WriteTo(writer);
        }
        else
        {
            throw new JsonException($"{nameof(UserCreateRequest1)} contains no valid value to serialize.");
        }
    }
}
