using System;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using UpvestInvestmentApi.Core.Extensions;
using UpvestInvestmentApi.Core.Models;

namespace UpvestInvestmentApi.Models.AnyOf;

/// <summary>
/// Request schema for creating a role.
/// </summary>
[JsonConverter(typeof(RoleCreateRequestConverter))]
public record RoleCreateRequest
{
    private readonly Optional<AccountGroupRoleCreateRequest> _accountGroupRoleCreateRequestValue;

    private readonly Optional<BusinessRoleCreateRequest> _businessRoleCreateRequestValue;

    private readonly Optional<UnknownArm> _unknownValue;

    private RoleCreateRequest(Optional<AccountGroupRoleCreateRequest> accountGroupRoleCreateRequestValue,
        Optional<BusinessRoleCreateRequest> businessRoleCreateRequestValue,
        Optional<UnknownArm> unknownValue)
    {
        _accountGroupRoleCreateRequestValue = accountGroupRoleCreateRequestValue;
        _businessRoleCreateRequestValue = businessRoleCreateRequestValue;
        _unknownValue = unknownValue;
    }

    public static RoleCreateRequest AccountGroupRoleCreateRequest(AccountGroupRoleCreateRequest value) =>
        new(Optional<AccountGroupRoleCreateRequest>.Some(value), default, default);

    public static RoleCreateRequest BusinessRoleCreateRequest(BusinessRoleCreateRequest value) =>
        new(default, Optional<BusinessRoleCreateRequest>.Some(value), default);

    internal static RoleCreateRequest Unknown(JsonElement value) =>
        new(default, default, Optional<UnknownArm>.Some(new UnknownArm(value)));

    public bool TryGetAccountGroupRoleCreateRequest([NotNullWhen(true)] out AccountGroupRoleCreateRequest? value) =>
        _accountGroupRoleCreateRequestValue.TryGetValue(out value);

    public bool TryGetBusinessRoleCreateRequest([NotNullWhen(true)] out BusinessRoleCreateRequest? value) =>
        _businessRoleCreateRequestValue.TryGetValue(out value);

    public bool TryGetUnknown(out JsonElement value) => _unknownValue.TryGetValue(out value);

    public static implicit operator RoleCreateRequest(AccountGroupRoleCreateRequest value) =>
        AccountGroupRoleCreateRequest(value);

    public static implicit operator RoleCreateRequest(BusinessRoleCreateRequest value) =>
        BusinessRoleCreateRequest(value);

    public TResult Match<TResult>(Func<AccountGroupRoleCreateRequest, TResult> onAccountGroupRoleCreateRequest,
        Func<BusinessRoleCreateRequest, TResult> onBusinessRoleCreateRequest,
        Func<JsonElement, TResult> otherwise) =>
        this switch
        {
            _ when TryGetAccountGroupRoleCreateRequest(
                out var accountGroupRoleCreateRequestValue) => onAccountGroupRoleCreateRequest(
                accountGroupRoleCreateRequestValue),
            _ when TryGetBusinessRoleCreateRequest(
                out var businessRoleCreateRequestValue) => onBusinessRoleCreateRequest(businessRoleCreateRequestValue),
            _ when TryGetUnknown(out var unknownValue) => otherwise(unknownValue),
            _ => throw new InvalidOperationException($"{nameof(RoleCreateRequest)} holds no value.")
        };

    public void Match(Action<AccountGroupRoleCreateRequest> onAccountGroupRoleCreateRequest,
        Action<BusinessRoleCreateRequest> onBusinessRoleCreateRequest,
        Action<JsonElement> otherwise)
    {
        if (TryGetAccountGroupRoleCreateRequest(
            out var accountGroupRoleCreateRequestValue)) onAccountGroupRoleCreateRequest(
            accountGroupRoleCreateRequestValue);
        else if (TryGetBusinessRoleCreateRequest(out var businessRoleCreateRequestValue)) onBusinessRoleCreateRequest(
            businessRoleCreateRequestValue);
        else if (TryGetUnknown(out var unknownValue)) otherwise(unknownValue);
        else throw new InvalidOperationException($"{nameof(RoleCreateRequest)} holds no value.");
    }
}

file sealed class RoleCreateRequestConverter : JsonConverter<RoleCreateRequest>
{
    public override RoleCreateRequest Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        using var doc = JsonDocument.ParseValue(ref reader);
        var root = doc.RootElement;
        if (JsonSerializer.TryDeserialize<AccountGroupRoleCreateRequest>(
            root,
            options,
            out var accountGroupRoleCreateRequestValue))
        {
            return RoleCreateRequest.AccountGroupRoleCreateRequest(accountGroupRoleCreateRequestValue);
        }
        if (JsonSerializer.TryDeserialize<BusinessRoleCreateRequest>(
            root,
            options,
            out var businessRoleCreateRequestValue))
        {
            return RoleCreateRequest.BusinessRoleCreateRequest(businessRoleCreateRequestValue);
        }
        return RoleCreateRequest.Unknown(root);
    }

    public override void Write(Utf8JsonWriter writer, RoleCreateRequest value, JsonSerializerOptions options)
    {
        if (value.TryGetAccountGroupRoleCreateRequest(out var accountGroupRoleCreateRequestValue))
        {
            JsonSerializer.Serialize(writer, accountGroupRoleCreateRequestValue, options);
        }
        else if (value.TryGetBusinessRoleCreateRequest(out var businessRoleCreateRequestValue))
        {
            JsonSerializer.Serialize(writer, businessRoleCreateRequestValue, options);
        }
        else if (value.TryGetUnknown(out var unknownValue))
        {
            unknownValue.WriteTo(writer);
        }
        else
        {
            throw new JsonException($"{nameof(RoleCreateRequest)} contains no valid value to serialize.");
        }
    }
}
