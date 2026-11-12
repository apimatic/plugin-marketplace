using System;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using UpvestInvestmentApi.Core.Extensions;
using UpvestInvestmentApi.Core.Models;

namespace UpvestInvestmentApi.Models.AnyOf;

[JsonConverter(typeof(SavingsPlanExecutionConverter))]
public record SavingsPlanExecution
{
    private readonly Optional<SavingsPlanExecutionInstrument> _savingsPlanExecutionInstrumentValue;

    private readonly Optional<SavingsPlanExecutionPortfolio> _savingsPlanExecutionPortfolioValue;

    private readonly Optional<UnknownArm> _unknownValue;

    private SavingsPlanExecution(Optional<SavingsPlanExecutionInstrument> savingsPlanExecutionInstrumentValue,
        Optional<SavingsPlanExecutionPortfolio> savingsPlanExecutionPortfolioValue,
        Optional<UnknownArm> unknownValue)
    {
        _savingsPlanExecutionInstrumentValue = savingsPlanExecutionInstrumentValue;
        _savingsPlanExecutionPortfolioValue = savingsPlanExecutionPortfolioValue;
        _unknownValue = unknownValue;
    }

    public static SavingsPlanExecution SavingsPlanExecutionInstrument(SavingsPlanExecutionInstrument value) =>
        new(Optional<SavingsPlanExecutionInstrument>.Some(value), default, default);

    public static SavingsPlanExecution SavingsPlanExecutionPortfolio(SavingsPlanExecutionPortfolio value) =>
        new(default, Optional<SavingsPlanExecutionPortfolio>.Some(value), default);

    internal static SavingsPlanExecution Unknown(JsonElement value) =>
        new(default, default, Optional<UnknownArm>.Some(new UnknownArm(value)));

    public bool TryGetSavingsPlanExecutionInstrument([NotNullWhen(true)] out SavingsPlanExecutionInstrument? value) =>
        _savingsPlanExecutionInstrumentValue.TryGetValue(out value);

    public bool TryGetSavingsPlanExecutionPortfolio([NotNullWhen(true)] out SavingsPlanExecutionPortfolio? value) =>
        _savingsPlanExecutionPortfolioValue.TryGetValue(out value);

    public bool TryGetUnknown(out JsonElement value) => _unknownValue.TryGetValue(out value);

    public static implicit operator SavingsPlanExecution(SavingsPlanExecutionInstrument value) =>
        SavingsPlanExecutionInstrument(value);

    public static implicit operator SavingsPlanExecution(SavingsPlanExecutionPortfolio value) =>
        SavingsPlanExecutionPortfolio(value);

    public TResult Match<TResult>(Func<SavingsPlanExecutionInstrument, TResult> onSavingsPlanExecutionInstrument,
        Func<SavingsPlanExecutionPortfolio, TResult> onSavingsPlanExecutionPortfolio,
        Func<JsonElement, TResult> otherwise) =>
        this switch
        {
            _ when TryGetSavingsPlanExecutionInstrument(
                out var savingsPlanExecutionInstrumentValue) => onSavingsPlanExecutionInstrument(
                savingsPlanExecutionInstrumentValue),
            _ when TryGetSavingsPlanExecutionPortfolio(
                out var savingsPlanExecutionPortfolioValue) => onSavingsPlanExecutionPortfolio(
                savingsPlanExecutionPortfolioValue),
            _ when TryGetUnknown(out var unknownValue) => otherwise(unknownValue),
            _ => throw new InvalidOperationException($"{nameof(SavingsPlanExecution)} holds no value.")
        };

    public void Match(Action<SavingsPlanExecutionInstrument> onSavingsPlanExecutionInstrument,
        Action<SavingsPlanExecutionPortfolio> onSavingsPlanExecutionPortfolio,
        Action<JsonElement> otherwise)
    {
        if (TryGetSavingsPlanExecutionInstrument(
            out var savingsPlanExecutionInstrumentValue)) onSavingsPlanExecutionInstrument(
            savingsPlanExecutionInstrumentValue);
        else if (TryGetSavingsPlanExecutionPortfolio(
            out var savingsPlanExecutionPortfolioValue)) onSavingsPlanExecutionPortfolio(
            savingsPlanExecutionPortfolioValue);
        else if (TryGetUnknown(out var unknownValue)) otherwise(unknownValue);
        else throw new InvalidOperationException($"{nameof(SavingsPlanExecution)} holds no value.");
    }
}

file sealed class SavingsPlanExecutionConverter : JsonConverter<SavingsPlanExecution>
{
    public override SavingsPlanExecution Read(ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options)
    {
        using var doc = JsonDocument.ParseValue(ref reader);
        var root = doc.RootElement;
        if (JsonSerializer.TryDeserialize<SavingsPlanExecutionInstrument>(
            root,
            options,
            out var savingsPlanExecutionInstrumentValue))
        {
            return SavingsPlanExecution.SavingsPlanExecutionInstrument(savingsPlanExecutionInstrumentValue);
        }
        if (JsonSerializer.TryDeserialize<SavingsPlanExecutionPortfolio>(
            root,
            options,
            out var savingsPlanExecutionPortfolioValue))
        {
            return SavingsPlanExecution.SavingsPlanExecutionPortfolio(savingsPlanExecutionPortfolioValue);
        }
        return SavingsPlanExecution.Unknown(root);
    }

    public override void Write(Utf8JsonWriter writer, SavingsPlanExecution value, JsonSerializerOptions options)
    {
        if (value.TryGetSavingsPlanExecutionInstrument(out var savingsPlanExecutionInstrumentValue))
        {
            JsonSerializer.Serialize(writer, savingsPlanExecutionInstrumentValue, options);
        }
        else if (value.TryGetSavingsPlanExecutionPortfolio(out var savingsPlanExecutionPortfolioValue))
        {
            JsonSerializer.Serialize(writer, savingsPlanExecutionPortfolioValue, options);
        }
        else if (value.TryGetUnknown(out var unknownValue))
        {
            unknownValue.WriteTo(writer);
        }
        else
        {
            throw new JsonException($"{nameof(SavingsPlanExecution)} contains no valid value to serialize.");
        }
    }
}
