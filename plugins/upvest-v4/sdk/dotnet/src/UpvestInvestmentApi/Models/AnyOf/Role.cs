using System;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using UpvestInvestmentApi.Core.Extensions;
using UpvestInvestmentApi.Core.Models;

namespace UpvestInvestmentApi.Models.AnyOf;

/// <summary>
/// A role assigned to a user for a specific entity (business or account group).
/// </summary>
[JsonConverter(typeof(RoleConverter))]
public record Role
{
    private readonly Optional<AccountGroupRole> _accountGroupRoleValue;

    private readonly Optional<BusinessRole> _businessRoleValue;

    private readonly Optional<UnknownArm> _unknownValue;

    private Role(Optional<AccountGroupRole> accountGroupRoleValue,
        Optional<BusinessRole> businessRoleValue,
        Optional<UnknownArm> unknownValue)
    {
        _accountGroupRoleValue = accountGroupRoleValue;
        _businessRoleValue = businessRoleValue;
        _unknownValue = unknownValue;
    }

    public static Role AccountGroupRole(AccountGroupRole value) =>
        new(Optional<AccountGroupRole>.Some(value), default, default);

    public static Role BusinessRole(BusinessRole value) => new(default, Optional<BusinessRole>.Some(value), default);

    internal static Role Unknown(JsonElement value) =>
        new(default, default, Optional<UnknownArm>.Some(new UnknownArm(value)));

    public bool TryGetAccountGroupRole([NotNullWhen(true)] out AccountGroupRole? value) =>
        _accountGroupRoleValue.TryGetValue(out value);

    public bool TryGetBusinessRole([NotNullWhen(true)] out BusinessRole? value) =>
        _businessRoleValue.TryGetValue(out value);

    public bool TryGetUnknown(out JsonElement value) => _unknownValue.TryGetValue(out value);

    public static implicit operator Role(AccountGroupRole value) => AccountGroupRole(value);

    public static implicit operator Role(BusinessRole value) => BusinessRole(value);

    public TResult Match<TResult>(Func<AccountGroupRole, TResult> onAccountGroupRole,
        Func<BusinessRole, TResult> onBusinessRole,
        Func<JsonElement, TResult> otherwise) =>
        this switch
        {
            _ when TryGetAccountGroupRole(out var accountGroupRoleValue) => onAccountGroupRole(accountGroupRoleValue),
            _ when TryGetBusinessRole(out var businessRoleValue) => onBusinessRole(businessRoleValue),
            _ when TryGetUnknown(out var unknownValue) => otherwise(unknownValue),
            _ => throw new InvalidOperationException($"{nameof(Role)} holds no value.")
        };

    public void Match(Action<AccountGroupRole> onAccountGroupRole,
        Action<BusinessRole> onBusinessRole,
        Action<JsonElement> otherwise)
    {
        if (TryGetAccountGroupRole(out var accountGroupRoleValue)) onAccountGroupRole(accountGroupRoleValue);
        else if (TryGetBusinessRole(out var businessRoleValue)) onBusinessRole(businessRoleValue);
        else if (TryGetUnknown(out var unknownValue)) otherwise(unknownValue);
        else throw new InvalidOperationException($"{nameof(Role)} holds no value.");
    }
}

file sealed class RoleConverter : JsonConverter<Role>
{
    public override Role Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        using var doc = JsonDocument.ParseValue(ref reader);
        var root = doc.RootElement;
        if (JsonSerializer.TryDeserialize<AccountGroupRole>(root, options, out var accountGroupRoleValue))
        {
            return Role.AccountGroupRole(accountGroupRoleValue);
        }
        if (JsonSerializer.TryDeserialize<BusinessRole>(root, options, out var businessRoleValue))
        {
            return Role.BusinessRole(businessRoleValue);
        }
        return Role.Unknown(root);
    }

    public override void Write(Utf8JsonWriter writer, Role value, JsonSerializerOptions options)
    {
        if (value.TryGetAccountGroupRole(out var accountGroupRoleValue))
        {
            JsonSerializer.Serialize(writer, accountGroupRoleValue, options);
        }
        else if (value.TryGetBusinessRole(out var businessRoleValue))
        {
            JsonSerializer.Serialize(writer, businessRoleValue, options);
        }
        else if (value.TryGetUnknown(out var unknownValue))
        {
            unknownValue.WriteTo(writer);
        }
        else
        {
            throw new JsonException($"{nameof(Role)} contains no valid value to serialize.");
        }
    }
}
