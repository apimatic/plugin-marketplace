using System;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using UpvestInvestmentApi.Core.Extensions;
using UpvestInvestmentApi.Core.Models;

namespace UpvestInvestmentApi.Models.AnyOf;

/// <summary>
/// Response schema for creating a role.
/// </summary>
[JsonConverter(typeof(RoleCreateResponseConverter))]
public record RoleCreateResponse
{
    private readonly Optional<AccountGroupRoleCreateResponse> _accountGroupRoleCreateResponseValue;

    private readonly Optional<BusinessRole> _businessRoleValue;

    private readonly Optional<UnknownArm> _unknownValue;

    private RoleCreateResponse(Optional<AccountGroupRoleCreateResponse> accountGroupRoleCreateResponseValue,
        Optional<BusinessRole> businessRoleValue,
        Optional<UnknownArm> unknownValue)
    {
        _accountGroupRoleCreateResponseValue = accountGroupRoleCreateResponseValue;
        _businessRoleValue = businessRoleValue;
        _unknownValue = unknownValue;
    }

    public static RoleCreateResponse AccountGroupRoleCreateResponse(AccountGroupRoleCreateResponse value) =>
        new(Optional<AccountGroupRoleCreateResponse>.Some(value), default, default);

    public static RoleCreateResponse BusinessRole(BusinessRole value) =>
        new(default, Optional<BusinessRole>.Some(value), default);

    internal static RoleCreateResponse Unknown(JsonElement value) =>
        new(default, default, Optional<UnknownArm>.Some(new UnknownArm(value)));

    public bool TryGetAccountGroupRoleCreateResponse([NotNullWhen(true)] out AccountGroupRoleCreateResponse? value) =>
        _accountGroupRoleCreateResponseValue.TryGetValue(out value);

    public bool TryGetBusinessRole([NotNullWhen(true)] out BusinessRole? value) =>
        _businessRoleValue.TryGetValue(out value);

    public bool TryGetUnknown(out JsonElement value) => _unknownValue.TryGetValue(out value);

    public static implicit operator RoleCreateResponse(AccountGroupRoleCreateResponse value) =>
        AccountGroupRoleCreateResponse(value);

    public static implicit operator RoleCreateResponse(BusinessRole value) => BusinessRole(value);

    public TResult Match<TResult>(Func<AccountGroupRoleCreateResponse, TResult> onAccountGroupRoleCreateResponse,
        Func<BusinessRole, TResult> onBusinessRole,
        Func<JsonElement, TResult> otherwise) =>
        this switch
        {
            _ when TryGetAccountGroupRoleCreateResponse(
                out var accountGroupRoleCreateResponseValue) => onAccountGroupRoleCreateResponse(
                accountGroupRoleCreateResponseValue),
            _ when TryGetBusinessRole(out var businessRoleValue) => onBusinessRole(businessRoleValue),
            _ when TryGetUnknown(out var unknownValue) => otherwise(unknownValue),
            _ => throw new InvalidOperationException($"{nameof(RoleCreateResponse)} holds no value.")
        };

    public void Match(Action<AccountGroupRoleCreateResponse> onAccountGroupRoleCreateResponse,
        Action<BusinessRole> onBusinessRole,
        Action<JsonElement> otherwise)
    {
        if (TryGetAccountGroupRoleCreateResponse(
            out var accountGroupRoleCreateResponseValue)) onAccountGroupRoleCreateResponse(
            accountGroupRoleCreateResponseValue);
        else if (TryGetBusinessRole(out var businessRoleValue)) onBusinessRole(businessRoleValue);
        else if (TryGetUnknown(out var unknownValue)) otherwise(unknownValue);
        else throw new InvalidOperationException($"{nameof(RoleCreateResponse)} holds no value.");
    }
}

file sealed class RoleCreateResponseConverter : JsonConverter<RoleCreateResponse>
{
    public override RoleCreateResponse Read(ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options)
    {
        using var doc = JsonDocument.ParseValue(ref reader);
        var root = doc.RootElement;
        if (JsonSerializer.TryDeserialize<AccountGroupRoleCreateResponse>(
            root,
            options,
            out var accountGroupRoleCreateResponseValue))
        {
            return RoleCreateResponse.AccountGroupRoleCreateResponse(accountGroupRoleCreateResponseValue);
        }
        if (JsonSerializer.TryDeserialize<BusinessRole>(root, options, out var businessRoleValue))
        {
            return RoleCreateResponse.BusinessRole(businessRoleValue);
        }
        return RoleCreateResponse.Unknown(root);
    }

    public override void Write(Utf8JsonWriter writer, RoleCreateResponse value, JsonSerializerOptions options)
    {
        if (value.TryGetAccountGroupRoleCreateResponse(out var accountGroupRoleCreateResponseValue))
        {
            JsonSerializer.Serialize(writer, accountGroupRoleCreateResponseValue, options);
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
            throw new JsonException($"{nameof(RoleCreateResponse)} contains no valid value to serialize.");
        }
    }
}
