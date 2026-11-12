using System;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using UpvestInvestmentApi.Core.Extensions;
using UpvestInvestmentApi.Core.Models;

namespace UpvestInvestmentApi.Models.AnyOf;

/// <summary>
/// Response schema for retrieving a role.
/// </summary>
[JsonConverter(typeof(RoleRetrieveResponseConverter))]
public record RoleRetrieveResponse
{
    private readonly Optional<AccountGroupRole> _accountGroupRoleValue;

    private readonly Optional<BusinessRole> _businessRoleValue;

    private readonly Optional<UnknownArm> _unknownValue;

    private RoleRetrieveResponse(Optional<AccountGroupRole> accountGroupRoleValue,
        Optional<BusinessRole> businessRoleValue,
        Optional<UnknownArm> unknownValue)
    {
        _accountGroupRoleValue = accountGroupRoleValue;
        _businessRoleValue = businessRoleValue;
        _unknownValue = unknownValue;
    }

    public static RoleRetrieveResponse AccountGroupRole(AccountGroupRole value) =>
        new(Optional<AccountGroupRole>.Some(value), default, default);

    public static RoleRetrieveResponse BusinessRole(BusinessRole value) =>
        new(default, Optional<BusinessRole>.Some(value), default);

    internal static RoleRetrieveResponse Unknown(JsonElement value) =>
        new(default, default, Optional<UnknownArm>.Some(new UnknownArm(value)));

    public bool TryGetAccountGroupRole([NotNullWhen(true)] out AccountGroupRole? value) =>
        _accountGroupRoleValue.TryGetValue(out value);

    public bool TryGetBusinessRole([NotNullWhen(true)] out BusinessRole? value) =>
        _businessRoleValue.TryGetValue(out value);

    public bool TryGetUnknown(out JsonElement value) => _unknownValue.TryGetValue(out value);

    public static implicit operator RoleRetrieveResponse(AccountGroupRole value) => AccountGroupRole(value);

    public static implicit operator RoleRetrieveResponse(BusinessRole value) => BusinessRole(value);

    public TResult Match<TResult>(Func<AccountGroupRole, TResult> onAccountGroupRole,
        Func<BusinessRole, TResult> onBusinessRole,
        Func<JsonElement, TResult> otherwise) =>
        this switch
        {
            _ when TryGetAccountGroupRole(out var accountGroupRoleValue) => onAccountGroupRole(accountGroupRoleValue),
            _ when TryGetBusinessRole(out var businessRoleValue) => onBusinessRole(businessRoleValue),
            _ when TryGetUnknown(out var unknownValue) => otherwise(unknownValue),
            _ => throw new InvalidOperationException($"{nameof(RoleRetrieveResponse)} holds no value.")
        };

    public void Match(Action<AccountGroupRole> onAccountGroupRole,
        Action<BusinessRole> onBusinessRole,
        Action<JsonElement> otherwise)
    {
        if (TryGetAccountGroupRole(out var accountGroupRoleValue)) onAccountGroupRole(accountGroupRoleValue);
        else if (TryGetBusinessRole(out var businessRoleValue)) onBusinessRole(businessRoleValue);
        else if (TryGetUnknown(out var unknownValue)) otherwise(unknownValue);
        else throw new InvalidOperationException($"{nameof(RoleRetrieveResponse)} holds no value.");
    }
}

file sealed class RoleRetrieveResponseConverter : JsonConverter<RoleRetrieveResponse>
{
    public override RoleRetrieveResponse Read(ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options)
    {
        using var doc = JsonDocument.ParseValue(ref reader);
        var root = doc.RootElement;
        if (JsonSerializer.TryDeserialize<AccountGroupRole>(root, options, out var accountGroupRoleValue))
        {
            return RoleRetrieveResponse.AccountGroupRole(accountGroupRoleValue);
        }
        if (JsonSerializer.TryDeserialize<BusinessRole>(root, options, out var businessRoleValue))
        {
            return RoleRetrieveResponse.BusinessRole(businessRoleValue);
        }
        return RoleRetrieveResponse.Unknown(root);
    }

    public override void Write(Utf8JsonWriter writer, RoleRetrieveResponse value, JsonSerializerOptions options)
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
            throw new JsonException($"{nameof(RoleRetrieveResponse)} contains no valid value to serialize.");
        }
    }
}
