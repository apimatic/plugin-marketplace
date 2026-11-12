using System;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using UpvestInvestmentApi.Core.Extensions;
using UpvestInvestmentApi.Core.Models;

namespace UpvestInvestmentApi.Models.AnyOf;

/// <summary>
/// The newly created account — either a user account or a business account.
/// </summary>
[JsonConverter(typeof(AccountCreateResponseConverter))]
public record AccountCreateResponse
{
    private readonly Optional<Account> _accountValue;

    private readonly Optional<BusinessAccount> _businessAccountValue;

    private readonly Optional<UnknownArm> _unknownValue;

    private AccountCreateResponse(Optional<Account> accountValue,
        Optional<BusinessAccount> businessAccountValue,
        Optional<UnknownArm> unknownValue)
    {
        _accountValue = accountValue;
        _businessAccountValue = businessAccountValue;
        _unknownValue = unknownValue;
    }

    public static AccountCreateResponse Account(Account value) => new(Optional<Account>.Some(value), default, default);

    public static AccountCreateResponse BusinessAccount(BusinessAccount value) =>
        new(default, Optional<BusinessAccount>.Some(value), default);

    internal static AccountCreateResponse Unknown(JsonElement value) =>
        new(default, default, Optional<UnknownArm>.Some(new UnknownArm(value)));

    public bool TryGetAccount([NotNullWhen(true)] out Account? value) => _accountValue.TryGetValue(out value);

    public bool TryGetBusinessAccount([NotNullWhen(true)] out BusinessAccount? value) =>
        _businessAccountValue.TryGetValue(out value);

    public bool TryGetUnknown(out JsonElement value) => _unknownValue.TryGetValue(out value);

    public static implicit operator AccountCreateResponse(Account value) => Account(value);

    public static implicit operator AccountCreateResponse(BusinessAccount value) => BusinessAccount(value);

    public TResult Match<TResult>(Func<Account, TResult> onAccount,
        Func<BusinessAccount, TResult> onBusinessAccount,
        Func<JsonElement, TResult> otherwise) =>
        this switch
        {
            _ when TryGetAccount(out var accountValue) => onAccount(accountValue),
            _ when TryGetBusinessAccount(out var businessAccountValue) => onBusinessAccount(businessAccountValue),
            _ when TryGetUnknown(out var unknownValue) => otherwise(unknownValue),
            _ => throw new InvalidOperationException($"{nameof(AccountCreateResponse)} holds no value.")
        };

    public void Match(Action<Account> onAccount,
        Action<BusinessAccount> onBusinessAccount,
        Action<JsonElement> otherwise)
    {
        if (TryGetAccount(out var accountValue)) onAccount(accountValue);
        else if (TryGetBusinessAccount(out var businessAccountValue)) onBusinessAccount(businessAccountValue);
        else if (TryGetUnknown(out var unknownValue)) otherwise(unknownValue);
        else throw new InvalidOperationException($"{nameof(AccountCreateResponse)} holds no value.");
    }
}

file sealed class AccountCreateResponseConverter : JsonConverter<AccountCreateResponse>
{
    public override AccountCreateResponse Read(ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options)
    {
        using var doc = JsonDocument.ParseValue(ref reader);
        var root = doc.RootElement;
        if (JsonSerializer.TryDeserialize<Account>(root, options, out var accountValue))
        {
            return AccountCreateResponse.Account(accountValue);
        }
        if (JsonSerializer.TryDeserialize<BusinessAccount>(root, options, out var businessAccountValue))
        {
            return AccountCreateResponse.BusinessAccount(businessAccountValue);
        }
        return AccountCreateResponse.Unknown(root);
    }

    public override void Write(Utf8JsonWriter writer, AccountCreateResponse value, JsonSerializerOptions options)
    {
        if (value.TryGetAccount(out var accountValue))
        {
            JsonSerializer.Serialize(writer, accountValue, options);
        }
        else if (value.TryGetBusinessAccount(out var businessAccountValue))
        {
            JsonSerializer.Serialize(writer, businessAccountValue, options);
        }
        else if (value.TryGetUnknown(out var unknownValue))
        {
            unknownValue.WriteTo(writer);
        }
        else
        {
            throw new JsonException($"{nameof(AccountCreateResponse)} contains no valid value to serialize.");
        }
    }
}
