using System;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using UpvestInvestmentApi.Core.Extensions;
using UpvestInvestmentApi.Core.Models;

namespace UpvestInvestmentApi.Models.AnyOf;

[JsonConverter(typeof(SavingsPlanCreateRequestConverter))]
public record SavingsPlanCreateRequest
{
    private readonly Optional<SavingsPlanPortfolio> _savingsPlanPortfolioValue;

    private readonly Optional<SavingsPlanInstrument3> _savingsPlanInstrument3Value;

    private readonly Optional<UnknownArm> _unknownValue;

    private SavingsPlanCreateRequest(Optional<SavingsPlanPortfolio> savingsPlanPortfolioValue,
        Optional<SavingsPlanInstrument3> savingsPlanInstrument3Value,
        Optional<UnknownArm> unknownValue)
    {
        _savingsPlanPortfolioValue = savingsPlanPortfolioValue;
        _savingsPlanInstrument3Value = savingsPlanInstrument3Value;
        _unknownValue = unknownValue;
    }

    public static SavingsPlanCreateRequest SavingsPlanPortfolio(SavingsPlanPortfolio value) =>
        new(Optional<SavingsPlanPortfolio>.Some(value), default, default);

    public static SavingsPlanCreateRequest SavingsPlanInstrument3(SavingsPlanInstrument3 value) =>
        new(default, Optional<SavingsPlanInstrument3>.Some(value), default);

    internal static SavingsPlanCreateRequest Unknown(JsonElement value) =>
        new(default, default, Optional<UnknownArm>.Some(new UnknownArm(value)));

    public bool TryGetSavingsPlanPortfolio([NotNullWhen(true)] out SavingsPlanPortfolio? value) =>
        _savingsPlanPortfolioValue.TryGetValue(out value);

    public bool TryGetSavingsPlanInstrument3([NotNullWhen(true)] out SavingsPlanInstrument3? value) =>
        _savingsPlanInstrument3Value.TryGetValue(out value);

    public bool TryGetUnknown(out JsonElement value) => _unknownValue.TryGetValue(out value);

    public static implicit operator SavingsPlanCreateRequest(SavingsPlanPortfolio value) => SavingsPlanPortfolio(value);

    public static implicit operator SavingsPlanCreateRequest(SavingsPlanInstrument3 value) =>
        SavingsPlanInstrument3(value);

    public TResult Match<TResult>(Func<SavingsPlanPortfolio, TResult> onSavingsPlanPortfolio,
        Func<SavingsPlanInstrument3, TResult> onSavingsPlanInstrument3,
        Func<JsonElement, TResult> otherwise) =>
        this switch
        {
            _ when TryGetSavingsPlanPortfolio(out var savingsPlanPortfolioValue) => onSavingsPlanPortfolio(
                savingsPlanPortfolioValue),
            _ when TryGetSavingsPlanInstrument3(out var savingsPlanInstrument3Value) => onSavingsPlanInstrument3(
                savingsPlanInstrument3Value),
            _ when TryGetUnknown(out var unknownValue) => otherwise(unknownValue),
            _ => throw new InvalidOperationException($"{nameof(SavingsPlanCreateRequest)} holds no value.")
        };

    public void Match(Action<SavingsPlanPortfolio> onSavingsPlanPortfolio,
        Action<SavingsPlanInstrument3> onSavingsPlanInstrument3,
        Action<JsonElement> otherwise)
    {
        if (TryGetSavingsPlanPortfolio(out var savingsPlanPortfolioValue)) onSavingsPlanPortfolio(
            savingsPlanPortfolioValue);
        else if (TryGetSavingsPlanInstrument3(out var savingsPlanInstrument3Value)) onSavingsPlanInstrument3(
            savingsPlanInstrument3Value);
        else if (TryGetUnknown(out var unknownValue)) otherwise(unknownValue);
        else throw new InvalidOperationException($"{nameof(SavingsPlanCreateRequest)} holds no value.");
    }
}

file sealed class SavingsPlanCreateRequestConverter : JsonConverter<SavingsPlanCreateRequest>
{
    public override SavingsPlanCreateRequest Read(ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options)
    {
        using var doc = JsonDocument.ParseValue(ref reader);
        var root = doc.RootElement;
        if (JsonSerializer.TryDeserialize<SavingsPlanPortfolio>(root, options, out var savingsPlanPortfolioValue))
        {
            return SavingsPlanCreateRequest.SavingsPlanPortfolio(savingsPlanPortfolioValue);
        }
        if (JsonSerializer.TryDeserialize<SavingsPlanInstrument3>(root, options, out var savingsPlanInstrument3Value))
        {
            return SavingsPlanCreateRequest.SavingsPlanInstrument3(savingsPlanInstrument3Value);
        }
        return SavingsPlanCreateRequest.Unknown(root);
    }

    public override void Write(Utf8JsonWriter writer, SavingsPlanCreateRequest value, JsonSerializerOptions options)
    {
        if (value.TryGetSavingsPlanPortfolio(out var savingsPlanPortfolioValue))
        {
            JsonSerializer.Serialize(writer, savingsPlanPortfolioValue, options);
        }
        else if (value.TryGetSavingsPlanInstrument3(out var savingsPlanInstrument3Value))
        {
            JsonSerializer.Serialize(writer, savingsPlanInstrument3Value, options);
        }
        else if (value.TryGetUnknown(out var unknownValue))
        {
            unknownValue.WriteTo(writer);
        }
        else
        {
            throw new JsonException($"{nameof(SavingsPlanCreateRequest)} contains no valid value to serialize.");
        }
    }
}
