using System;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using UpvestInvestmentApi.Core.Extensions;
using UpvestInvestmentApi.Core.Models;

namespace UpvestInvestmentApi.Models.AnyOf;

[JsonConverter(typeof(Datum711Converter))]
public record Datum711
{
    private readonly Optional<Account> _accountValue;

    private readonly Optional<BusinessAccount> _businessAccountValue;

    private readonly Optional<UnknownArm> _unknownValue;

    private Datum711(Optional<Account> accountValue,
        Optional<BusinessAccount> businessAccountValue,
        Optional<UnknownArm> unknownValue)
    {
        _accountValue = accountValue;
        _businessAccountValue = businessAccountValue;
        _unknownValue = unknownValue;
    }

    public static Datum711 Account(Account value) => new(Optional<Account>.Some(value), default, default);

    public static Datum711 BusinessAccount(BusinessAccount value) =>
        new(default, Optional<BusinessAccount>.Some(value), default);

    internal static Datum711 Unknown(JsonElement value) =>
        new(default, default, Optional<UnknownArm>.Some(new UnknownArm(value)));

    public bool TryGetAccount([NotNullWhen(true)] out Account? value) => _accountValue.TryGetValue(out value);

    public bool TryGetBusinessAccount([NotNullWhen(true)] out BusinessAccount? value) =>
        _businessAccountValue.TryGetValue(out value);

    public bool TryGetUnknown(out JsonElement value) => _unknownValue.TryGetValue(out value);

    public static implicit operator Datum711(Account value) => Account(value);

    public static implicit operator Datum711(BusinessAccount value) => BusinessAccount(value);

    public TResult Match<TResult>(Func<Account, TResult> onAccount,
        Func<BusinessAccount, TResult> onBusinessAccount,
        Func<JsonElement, TResult> otherwise) =>
        this switch
        {
            _ when TryGetAccount(out var accountValue) => onAccount(accountValue),
            _ when TryGetBusinessAccount(out var businessAccountValue) => onBusinessAccount(businessAccountValue),
            _ when TryGetUnknown(out var unknownValue) => otherwise(unknownValue),
            _ => throw new InvalidOperationException($"{nameof(Datum711)} holds no value.")
        };

    public void Match(Action<Account> onAccount,
        Action<BusinessAccount> onBusinessAccount,
        Action<JsonElement> otherwise)
    {
        if (TryGetAccount(out var accountValue)) onAccount(accountValue);
        else if (TryGetBusinessAccount(out var businessAccountValue)) onBusinessAccount(businessAccountValue);
        else if (TryGetUnknown(out var unknownValue)) otherwise(unknownValue);
        else throw new InvalidOperationException($"{nameof(Datum711)} holds no value.");
    }
}

file sealed class Datum711Converter : JsonConverter<Datum711>
{
    public override Datum711 Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        using var doc = JsonDocument.ParseValue(ref reader);
        var root = doc.RootElement;
        if (JsonSerializer.TryDeserialize<Account>(root, options, out var accountValue))
        {
            return Datum711.Account(accountValue);
        }
        if (JsonSerializer.TryDeserialize<BusinessAccount>(root, options, out var businessAccountValue))
        {
            return Datum711.BusinessAccount(businessAccountValue);
        }
        return Datum711.Unknown(root);
    }

    public override void Write(Utf8JsonWriter writer, Datum711 value, JsonSerializerOptions options)
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
            throw new JsonException($"{nameof(Datum711)} contains no valid value to serialize.");
        }
    }
}
