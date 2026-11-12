using System;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using UpvestInvestmentApi.Core.Extensions;
using UpvestInvestmentApi.Core.Models;

namespace UpvestInvestmentApi.Models.AnyOf;

[JsonConverter(typeof(Datum71Converter))]
public record Datum71
{
    private readonly Optional<AccountGroup> _accountGroupValue;

    private readonly Optional<BusinessAccountGroup> _businessAccountGroupValue;

    private readonly Optional<UnknownArm> _unknownValue;

    private Datum71(Optional<AccountGroup> accountGroupValue,
        Optional<BusinessAccountGroup> businessAccountGroupValue,
        Optional<UnknownArm> unknownValue)
    {
        _accountGroupValue = accountGroupValue;
        _businessAccountGroupValue = businessAccountGroupValue;
        _unknownValue = unknownValue;
    }

    public static Datum71 AccountGroup(AccountGroup value) => new(Optional<AccountGroup>.Some(value), default, default);

    public static Datum71 BusinessAccountGroup(BusinessAccountGroup value) =>
        new(default, Optional<BusinessAccountGroup>.Some(value), default);

    internal static Datum71 Unknown(JsonElement value) =>
        new(default, default, Optional<UnknownArm>.Some(new UnknownArm(value)));

    public bool TryGetAccountGroup([NotNullWhen(true)] out AccountGroup? value) =>
        _accountGroupValue.TryGetValue(out value);

    public bool TryGetBusinessAccountGroup([NotNullWhen(true)] out BusinessAccountGroup? value) =>
        _businessAccountGroupValue.TryGetValue(out value);

    public bool TryGetUnknown(out JsonElement value) => _unknownValue.TryGetValue(out value);

    public static implicit operator Datum71(AccountGroup value) => AccountGroup(value);

    public static implicit operator Datum71(BusinessAccountGroup value) => BusinessAccountGroup(value);

    public TResult Match<TResult>(Func<AccountGroup, TResult> onAccountGroup,
        Func<BusinessAccountGroup, TResult> onBusinessAccountGroup,
        Func<JsonElement, TResult> otherwise) =>
        this switch
        {
            _ when TryGetAccountGroup(out var accountGroupValue) => onAccountGroup(accountGroupValue),
            _ when TryGetBusinessAccountGroup(out var businessAccountGroupValue) => onBusinessAccountGroup(
                businessAccountGroupValue),
            _ when TryGetUnknown(out var unknownValue) => otherwise(unknownValue),
            _ => throw new InvalidOperationException($"{nameof(Datum71)} holds no value.")
        };

    public void Match(Action<AccountGroup> onAccountGroup,
        Action<BusinessAccountGroup> onBusinessAccountGroup,
        Action<JsonElement> otherwise)
    {
        if (TryGetAccountGroup(out var accountGroupValue)) onAccountGroup(accountGroupValue);
        else if (TryGetBusinessAccountGroup(out var businessAccountGroupValue)) onBusinessAccountGroup(
            businessAccountGroupValue);
        else if (TryGetUnknown(out var unknownValue)) otherwise(unknownValue);
        else throw new InvalidOperationException($"{nameof(Datum71)} holds no value.");
    }
}

file sealed class Datum71Converter : JsonConverter<Datum71>
{
    public override Datum71 Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        using var doc = JsonDocument.ParseValue(ref reader);
        var root = doc.RootElement;
        if (JsonSerializer.TryDeserialize<AccountGroup>(root, options, out var accountGroupValue))
        {
            return Datum71.AccountGroup(accountGroupValue);
        }
        if (JsonSerializer.TryDeserialize<BusinessAccountGroup>(root, options, out var businessAccountGroupValue))
        {
            return Datum71.BusinessAccountGroup(businessAccountGroupValue);
        }
        return Datum71.Unknown(root);
    }

    public override void Write(Utf8JsonWriter writer, Datum71 value, JsonSerializerOptions options)
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
            throw new JsonException($"{nameof(Datum71)} contains no valid value to serialize.");
        }
    }
}
