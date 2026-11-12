using System;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using UpvestInvestmentApi.Core.Extensions;
using UpvestInvestmentApi.Core.Models;

namespace UpvestInvestmentApi.Models.AnyOf;

[JsonConverter(typeof(Datum10Converter))]
public record Datum10
{
    private readonly Optional<BusinessReport> _businessReportValue;

    private readonly Optional<BusinessReportOrder> _businessReportOrderValue;

    private readonly Optional<BusinessReportIncomeDistribution> _businessReportIncomeDistributionValue;

    private readonly Optional<BusinessReportSecuritiesTransfer> _businessReportSecuritiesTransferValue;

    private readonly Optional<UnknownArm> _unknownValue;

    private Datum10(Optional<BusinessReport> businessReportValue,
        Optional<BusinessReportOrder> businessReportOrderValue,
        Optional<BusinessReportIncomeDistribution> businessReportIncomeDistributionValue,
        Optional<BusinessReportSecuritiesTransfer> businessReportSecuritiesTransferValue,
        Optional<UnknownArm> unknownValue)
    {
        _businessReportValue = businessReportValue;
        _businessReportOrderValue = businessReportOrderValue;
        _businessReportIncomeDistributionValue = businessReportIncomeDistributionValue;
        _businessReportSecuritiesTransferValue = businessReportSecuritiesTransferValue;
        _unknownValue = unknownValue;
    }

    public static Datum10 BusinessReport(BusinessReport value) =>
        new(Optional<BusinessReport>.Some(value), default, default, default, default);

    public static Datum10 BusinessReportOrder(BusinessReportOrder value) =>
        new(default, Optional<BusinessReportOrder>.Some(value), default, default, default);

    public static Datum10 BusinessReportIncomeDistribution(BusinessReportIncomeDistribution value) =>
        new(default, default, Optional<BusinessReportIncomeDistribution>.Some(value), default, default);

    public static Datum10 BusinessReportSecuritiesTransfer(BusinessReportSecuritiesTransfer value) =>
        new(default, default, default, Optional<BusinessReportSecuritiesTransfer>.Some(value), default);

    internal static Datum10 Unknown(JsonElement value) =>
        new(default, default, default, default, Optional<UnknownArm>.Some(new UnknownArm(value)));

    public bool TryGetBusinessReport([NotNullWhen(true)] out BusinessReport? value) =>
        _businessReportValue.TryGetValue(out value);

    public bool TryGetBusinessReportOrder([NotNullWhen(true)] out BusinessReportOrder? value) =>
        _businessReportOrderValue.TryGetValue(out value);

    public bool TryGetBusinessReportIncomeDistribution([NotNullWhen(true)] out BusinessReportIncomeDistribution? value) =>
        _businessReportIncomeDistributionValue.TryGetValue(out value);

    public bool TryGetBusinessReportSecuritiesTransfer([NotNullWhen(true)] out BusinessReportSecuritiesTransfer? value) =>
        _businessReportSecuritiesTransferValue.TryGetValue(out value);

    public bool TryGetUnknown(out JsonElement value) => _unknownValue.TryGetValue(out value);

    public static implicit operator Datum10(BusinessReport value) => BusinessReport(value);

    public static implicit operator Datum10(BusinessReportOrder value) => BusinessReportOrder(value);

    public static implicit operator Datum10(BusinessReportIncomeDistribution value) =>
        BusinessReportIncomeDistribution(value);

    public static implicit operator Datum10(BusinessReportSecuritiesTransfer value) =>
        BusinessReportSecuritiesTransfer(value);

    public TResult Match<TResult>(Func<BusinessReport, TResult> onBusinessReport,
        Func<BusinessReportOrder, TResult> onBusinessReportOrder,
        Func<BusinessReportIncomeDistribution, TResult> onBusinessReportIncomeDistribution,
        Func<BusinessReportSecuritiesTransfer, TResult> onBusinessReportSecuritiesTransfer,
        Func<JsonElement, TResult> otherwise) =>
        this switch
        {
            _ when TryGetBusinessReport(out var businessReportValue) => onBusinessReport(businessReportValue),
            _ when TryGetBusinessReportOrder(out var businessReportOrderValue) => onBusinessReportOrder(
                businessReportOrderValue),
            _ when TryGetBusinessReportIncomeDistribution(
                out var businessReportIncomeDistributionValue) => onBusinessReportIncomeDistribution(
                businessReportIncomeDistributionValue),
            _ when TryGetBusinessReportSecuritiesTransfer(
                out var businessReportSecuritiesTransferValue) => onBusinessReportSecuritiesTransfer(
                businessReportSecuritiesTransferValue),
            _ when TryGetUnknown(out var unknownValue) => otherwise(unknownValue),
            _ => throw new InvalidOperationException($"{nameof(Datum10)} holds no value.")
        };

    public void Match(Action<BusinessReport> onBusinessReport,
        Action<BusinessReportOrder> onBusinessReportOrder,
        Action<BusinessReportIncomeDistribution> onBusinessReportIncomeDistribution,
        Action<BusinessReportSecuritiesTransfer> onBusinessReportSecuritiesTransfer,
        Action<JsonElement> otherwise)
    {
        if (TryGetBusinessReport(out var businessReportValue)) onBusinessReport(businessReportValue);
        else if (TryGetBusinessReportOrder(out var businessReportOrderValue)) onBusinessReportOrder(
            businessReportOrderValue);
        else if (TryGetBusinessReportIncomeDistribution(
            out var businessReportIncomeDistributionValue)) onBusinessReportIncomeDistribution(
            businessReportIncomeDistributionValue);
        else if (TryGetBusinessReportSecuritiesTransfer(
            out var businessReportSecuritiesTransferValue)) onBusinessReportSecuritiesTransfer(
            businessReportSecuritiesTransferValue);
        else if (TryGetUnknown(out var unknownValue)) otherwise(unknownValue);
        else throw new InvalidOperationException($"{nameof(Datum10)} holds no value.");
    }
}

file sealed class Datum10Converter : JsonConverter<Datum10>
{
    public override Datum10 Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        using var doc = JsonDocument.ParseValue(ref reader);
        var root = doc.RootElement;
        if (JsonSerializer.TryDeserialize<BusinessReport>(root, options, out var businessReportValue))
        {
            return Datum10.BusinessReport(businessReportValue);
        }
        if (JsonSerializer.TryDeserialize<BusinessReportOrder>(root, options, out var businessReportOrderValue))
        {
            return Datum10.BusinessReportOrder(businessReportOrderValue);
        }
        if (JsonSerializer.TryDeserialize<BusinessReportIncomeDistribution>(
            root,
            options,
            out var businessReportIncomeDistributionValue))
        {
            return Datum10.BusinessReportIncomeDistribution(businessReportIncomeDistributionValue);
        }
        if (JsonSerializer.TryDeserialize<BusinessReportSecuritiesTransfer>(
            root,
            options,
            out var businessReportSecuritiesTransferValue))
        {
            return Datum10.BusinessReportSecuritiesTransfer(businessReportSecuritiesTransferValue);
        }
        return Datum10.Unknown(root);
    }

    public override void Write(Utf8JsonWriter writer, Datum10 value, JsonSerializerOptions options)
    {
        if (value.TryGetBusinessReport(out var businessReportValue))
        {
            JsonSerializer.Serialize(writer, businessReportValue, options);
        }
        else if (value.TryGetBusinessReportOrder(out var businessReportOrderValue))
        {
            JsonSerializer.Serialize(writer, businessReportOrderValue, options);
        }
        else if (value.TryGetBusinessReportIncomeDistribution(out var businessReportIncomeDistributionValue))
        {
            JsonSerializer.Serialize(writer, businessReportIncomeDistributionValue, options);
        }
        else if (value.TryGetBusinessReportSecuritiesTransfer(out var businessReportSecuritiesTransferValue))
        {
            JsonSerializer.Serialize(writer, businessReportSecuritiesTransferValue, options);
        }
        else if (value.TryGetUnknown(out var unknownValue))
        {
            unknownValue.WriteTo(writer);
        }
        else
        {
            throw new JsonException($"{nameof(Datum10)} contains no valid value to serialize.");
        }
    }
}
