using System;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using UpvestInvestmentApi.Core.Extensions;
using UpvestInvestmentApi.Core.Models;

namespace UpvestInvestmentApi.Models.AnyOf;

/// <summary>
/// The requested account group — either a user account group or a business account group.
/// </summary>
[JsonConverter(typeof(AccountGroupRetrieveResponseConverter))]
public record AccountGroupRetrieveResponse
{
    private readonly Optional<AccountGroup> _accountGroupValue;

    private readonly Optional<BusinessAccountGroup> _businessAccountGroupValue;

    private readonly Optional<UnknownArm> _unknownValue;

    private AccountGroupRetrieveResponse(Optional<AccountGroup> accountGroupValue,
        Optional<BusinessAccountGroup> businessAccountGroupValue,
        Optional<UnknownArm> unknownValue)
    {
        _accountGroupValue = accountGroupValue;
        _businessAccountGroupValue = businessAccountGroupValue;
        _unknownValue = unknownValue;
    }

    public static AccountGroupRetrieveResponse AccountGroup(AccountGroup value) =>
        new(Optional<AccountGroup>.Some(value), default, default);

    public static AccountGroupRetrieveResponse BusinessAccountGroup(BusinessAccountGroup value) =>
        new(default, Optional<BusinessAccountGroup>.Some(value), default);

    internal static AccountGroupRetrieveResponse Unknown(JsonElement value) =>
        new(default, default, Optional<UnknownArm>.Some(new UnknownArm(value)));

    public bool TryGetAccountGroup([NotNullWhen(true)] out AccountGroup? value) =>
        _accountGroupValue.TryGetValue(out value);

    public bool TryGetBusinessAccountGroup([NotNullWhen(true)] out BusinessAccountGroup? value) =>
        _businessAccountGroupValue.TryGetValue(out value);

    public bool TryGetUnknown(out JsonElement value) => _unknownValue.TryGetValue(out value);

    public static implicit operator AccountGroupRetrieveResponse(AccountGroup value) => AccountGroup(value);

    public static implicit operator AccountGroupRetrieveResponse(BusinessAccountGroup value) =>
        BusinessAccountGroup(value);

    public TResult Match<TResult>(Func<AccountGroup, TResult> onAccountGroup,
        Func<BusinessAccountGroup, TResult> onBusinessAccountGroup,
        Func<JsonElement, TResult> otherwise) =>
        this switch
        {
            _ when TryGetAccountGroup(out var accountGroupValue) => onAccountGroup(accountGroupValue),
            _ when TryGetBusinessAccountGroup(out var businessAccountGroupValue) => onBusinessAccountGroup(
                businessAccountGroupValue),
            _ when TryGetUnknown(out var unknownValue) => otherwise(unknownValue),
            _ => throw new InvalidOperationException($"{nameof(AccountGroupRetrieveResponse)} holds no value.")
        };

    public void Match(Action<AccountGroup> onAccountGroup,
        Action<BusinessAccountGroup> onBusinessAccountGroup,
        Action<JsonElement> otherwise)
    {
        if (TryGetAccountGroup(out var accountGroupValue)) onAccountGroup(accountGroupValue);
        else if (TryGetBusinessAccountGroup(out var businessAccountGroupValue)) onBusinessAccountGroup(
            businessAccountGroupValue);
        else if (TryGetUnknown(out var unknownValue)) otherwise(unknownValue);
        else throw new InvalidOperationException($"{nameof(AccountGroupRetrieveResponse)} holds no value.");
    }
}

file sealed class AccountGroupRetrieveResponseConverter : JsonConverter<AccountGroupRetrieveResponse>
{
    public override AccountGroupRetrieveResponse Read(ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options)
    {
        using var doc = JsonDocument.ParseValue(ref reader);
        var root = doc.RootElement;
        if (JsonSerializer.TryDeserialize<AccountGroup>(root, options, out var accountGroupValue))
        {
            return AccountGroupRetrieveResponse.AccountGroup(accountGroupValue);
        }
        if (JsonSerializer.TryDeserialize<BusinessAccountGroup>(root, options, out var businessAccountGroupValue))
        {
            return AccountGroupRetrieveResponse.BusinessAccountGroup(businessAccountGroupValue);
        }
        return AccountGroupRetrieveResponse.Unknown(root);
    }

    public override void Write(Utf8JsonWriter writer, AccountGroupRetrieveResponse value, JsonSerializerOptions options)
    {
        if (value.TryGetAccountGroup(out var accountGroupValue))
        {
            JsonSerializer.Serialize(writer, accountGroupValue, options);
        }
        else if (value.TryGetBusinessAccountGroup(out var businessAccountGroupValue))
        {
            JsonSerializer.Serialize(writer, businessAccountGroupValue, options);
        }
        else if (value.TryGetUnknown(out var unknownValue))
        {
            unknownValue.WriteTo(writer);
        }
        else
        {
            throw new JsonException($"{nameof(AccountGroupRetrieveResponse)} contains no valid value to serialize.");
        }
    }
}
