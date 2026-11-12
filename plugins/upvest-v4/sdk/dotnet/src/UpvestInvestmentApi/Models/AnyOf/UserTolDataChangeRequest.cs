using System;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using UpvestInvestmentApi.Core.Extensions;
using UpvestInvestmentApi.Core.Models;

namespace UpvestInvestmentApi.Models.AnyOf;

/// <summary>
/// Request payload for changing user data. The required proof documents depend on the type of change.
/// </summary>
[JsonConverter(typeof(UserTolDataChangeRequestConverter))]
public record UserTolDataChangeRequest
{
    private readonly Optional<UserTolDataChangeRequestNameChange> _userTolDataChangeRequestNameChangeValue;

    private readonly Optional<UserTolDataChangeRequestOther> _userTolDataChangeRequestOtherValue;

    private readonly Optional<UserTolDataChangeRequestNationality> _userTolDataChangeRequestNationalityValue;

    private readonly Optional<UserTolDataChangeRequestAddress> _userTolDataChangeRequestAddressValue;

    private readonly Optional<UnknownArm> _unknownValue;

    private UserTolDataChangeRequest(Optional<UserTolDataChangeRequestNameChange> userTolDataChangeRequestNameChangeValue,
        Optional<UserTolDataChangeRequestOther> userTolDataChangeRequestOtherValue,
        Optional<UserTolDataChangeRequestNationality> userTolDataChangeRequestNationalityValue,
        Optional<UserTolDataChangeRequestAddress> userTolDataChangeRequestAddressValue,
        Optional<UnknownArm> unknownValue)
    {
        _userTolDataChangeRequestNameChangeValue = userTolDataChangeRequestNameChangeValue;
        _userTolDataChangeRequestOtherValue = userTolDataChangeRequestOtherValue;
        _userTolDataChangeRequestNationalityValue = userTolDataChangeRequestNationalityValue;
        _userTolDataChangeRequestAddressValue = userTolDataChangeRequestAddressValue;
        _unknownValue = unknownValue;
    }

    public static UserTolDataChangeRequest UserTolDataChangeRequestNameChange(UserTolDataChangeRequestNameChange value) =>
        new(Optional<UserTolDataChangeRequestNameChange>.Some(value), default, default, default, default);

    public static UserTolDataChangeRequest UserTolDataChangeRequestOther(UserTolDataChangeRequestOther value) =>
        new(default, Optional<UserTolDataChangeRequestOther>.Some(value), default, default, default);

    public static UserTolDataChangeRequest UserTolDataChangeRequestNationality(UserTolDataChangeRequestNationality value) =>
        new(default, default, Optional<UserTolDataChangeRequestNationality>.Some(value), default, default);

    public static UserTolDataChangeRequest UserTolDataChangeRequestAddress(UserTolDataChangeRequestAddress value) =>
        new(default, default, default, Optional<UserTolDataChangeRequestAddress>.Some(value), default);

    internal static UserTolDataChangeRequest Unknown(JsonElement value) =>
        new(default, default, default, default, Optional<UnknownArm>.Some(new UnknownArm(value)));

    public bool TryGetUserTolDataChangeRequestNameChange([NotNullWhen(true)] out UserTolDataChangeRequestNameChange? value) =>
        _userTolDataChangeRequestNameChangeValue.TryGetValue(out value);

    public bool TryGetUserTolDataChangeRequestOther([NotNullWhen(true)] out UserTolDataChangeRequestOther? value) =>
        _userTolDataChangeRequestOtherValue.TryGetValue(out value);

    public bool TryGetUserTolDataChangeRequestNationality([NotNullWhen(true)] out UserTolDataChangeRequestNationality? value) =>
        _userTolDataChangeRequestNationalityValue.TryGetValue(out value);

    public bool TryGetUserTolDataChangeRequestAddress([NotNullWhen(true)] out UserTolDataChangeRequestAddress? value) =>
        _userTolDataChangeRequestAddressValue.TryGetValue(out value);

    public bool TryGetUnknown(out JsonElement value) => _unknownValue.TryGetValue(out value);

    public static implicit operator UserTolDataChangeRequest(UserTolDataChangeRequestNameChange value) =>
        UserTolDataChangeRequestNameChange(value);

    public static implicit operator UserTolDataChangeRequest(UserTolDataChangeRequestOther value) =>
        UserTolDataChangeRequestOther(value);

    public static implicit operator UserTolDataChangeRequest(UserTolDataChangeRequestNationality value) =>
        UserTolDataChangeRequestNationality(value);

    public static implicit operator UserTolDataChangeRequest(UserTolDataChangeRequestAddress value) =>
        UserTolDataChangeRequestAddress(value);

    public TResult Match<TResult>(Func<UserTolDataChangeRequestNameChange, TResult> onUserTolDataChangeRequestNameChange,
        Func<UserTolDataChangeRequestOther, TResult> onUserTolDataChangeRequestOther,
        Func<UserTolDataChangeRequestNationality, TResult> onUserTolDataChangeRequestNationality,
        Func<UserTolDataChangeRequestAddress, TResult> onUserTolDataChangeRequestAddress,
        Func<JsonElement, TResult> otherwise) =>
        this switch
        {
            _ when TryGetUserTolDataChangeRequestNameChange(
                out var userTolDataChangeRequestNameChangeValue) => onUserTolDataChangeRequestNameChange(
                userTolDataChangeRequestNameChangeValue),
            _ when TryGetUserTolDataChangeRequestOther(
                out var userTolDataChangeRequestOtherValue) => onUserTolDataChangeRequestOther(
                userTolDataChangeRequestOtherValue),
            _ when TryGetUserTolDataChangeRequestNationality(
                out var userTolDataChangeRequestNationalityValue) => onUserTolDataChangeRequestNationality(
                userTolDataChangeRequestNationalityValue),
            _ when TryGetUserTolDataChangeRequestAddress(
                out var userTolDataChangeRequestAddressValue) => onUserTolDataChangeRequestAddress(
                userTolDataChangeRequestAddressValue),
            _ when TryGetUnknown(out var unknownValue) => otherwise(unknownValue),
            _ => throw new InvalidOperationException($"{nameof(UserTolDataChangeRequest)} holds no value.")
        };

    public void Match(Action<UserTolDataChangeRequestNameChange> onUserTolDataChangeRequestNameChange,
        Action<UserTolDataChangeRequestOther> onUserTolDataChangeRequestOther,
        Action<UserTolDataChangeRequestNationality> onUserTolDataChangeRequestNationality,
        Action<UserTolDataChangeRequestAddress> onUserTolDataChangeRequestAddress,
        Action<JsonElement> otherwise)
    {
        if (TryGetUserTolDataChangeRequestNameChange(
            out var userTolDataChangeRequestNameChangeValue)) onUserTolDataChangeRequestNameChange(
            userTolDataChangeRequestNameChangeValue);
        else if (TryGetUserTolDataChangeRequestOther(
            out var userTolDataChangeRequestOtherValue)) onUserTolDataChangeRequestOther(
            userTolDataChangeRequestOtherValue);
        else if (TryGetUserTolDataChangeRequestNationality(
            out var userTolDataChangeRequestNationalityValue)) onUserTolDataChangeRequestNationality(
            userTolDataChangeRequestNationalityValue);
        else if (TryGetUserTolDataChangeRequestAddress(
            out var userTolDataChangeRequestAddressValue)) onUserTolDataChangeRequestAddress(
            userTolDataChangeRequestAddressValue);
        else if (TryGetUnknown(out var unknownValue)) otherwise(unknownValue);
        else throw new InvalidOperationException($"{nameof(UserTolDataChangeRequest)} holds no value.");
    }
}

file sealed class UserTolDataChangeRequestConverter : JsonConverter<UserTolDataChangeRequest>
{
    public override UserTolDataChangeRequest Read(ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options)
    {
        using var doc = JsonDocument.ParseValue(ref reader);
        var root = doc.RootElement;
        if (JsonSerializer.TryDeserialize<UserTolDataChangeRequestNameChange>(
            root,
            options,
            out var userTolDataChangeRequestNameChangeValue))
        {
            return UserTolDataChangeRequest.UserTolDataChangeRequestNameChange(userTolDataChangeRequestNameChangeValue);
        }
        if (JsonSerializer.TryDeserialize<UserTolDataChangeRequestOther>(
            root,
            options,
            out var userTolDataChangeRequestOtherValue))
        {
            return UserTolDataChangeRequest.UserTolDataChangeRequestOther(userTolDataChangeRequestOtherValue);
        }
        if (JsonSerializer.TryDeserialize<UserTolDataChangeRequestNationality>(
            root,
            options,
            out var userTolDataChangeRequestNationalityValue))
        {
            return UserTolDataChangeRequest.UserTolDataChangeRequestNationality(
                userTolDataChangeRequestNationalityValue);
        }
        if (JsonSerializer.TryDeserialize<UserTolDataChangeRequestAddress>(
            root,
            options,
            out var userTolDataChangeRequestAddressValue))
        {
            return UserTolDataChangeRequest.UserTolDataChangeRequestAddress(userTolDataChangeRequestAddressValue);
        }
        return UserTolDataChangeRequest.Unknown(root);
    }

    public override void Write(Utf8JsonWriter writer, UserTolDataChangeRequest value, JsonSerializerOptions options)
    {
        if (value.TryGetUserTolDataChangeRequestNameChange(out var userTolDataChangeRequestNameChangeValue))
        {
            JsonSerializer.Serialize(writer, userTolDataChangeRequestNameChangeValue, options);
        }
        else if (value.TryGetUserTolDataChangeRequestOther(out var userTolDataChangeRequestOtherValue))
        {
            JsonSerializer.Serialize(writer, userTolDataChangeRequestOtherValue, options);
        }
        else if (value.TryGetUserTolDataChangeRequestNationality(out var userTolDataChangeRequestNationalityValue))
        {
            JsonSerializer.Serialize(writer, userTolDataChangeRequestNationalityValue, options);
        }
        else if (value.TryGetUserTolDataChangeRequestAddress(out var userTolDataChangeRequestAddressValue))
        {
            JsonSerializer.Serialize(writer, userTolDataChangeRequestAddressValue, options);
        }
        else if (value.TryGetUnknown(out var unknownValue))
        {
            unknownValue.WriteTo(writer);
        }
        else
        {
            throw new JsonException($"{nameof(UserTolDataChangeRequest)} contains no valid value to serialize.");
        }
    }
}
