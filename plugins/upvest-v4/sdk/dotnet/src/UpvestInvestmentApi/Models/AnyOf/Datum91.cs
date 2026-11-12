using System;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using UpvestInvestmentApi.Core.Extensions;
using UpvestInvestmentApi.Core.Models;

namespace UpvestInvestmentApi.Models.AnyOf;

[JsonConverter(typeof(Datum91Converter))]
public record Datum91
{
    private readonly Optional<UserReport> _userReportValue;

    private readonly Optional<UserReportOrder> _userReportOrderValue;

    private readonly Optional<UserReportIncomeDistribution> _userReportIncomeDistributionValue;

    private readonly Optional<UserReportCorporateAction> _userReportCorporateActionValue;

    private readonly Optional<UserReportSecuritiesTransfer> _userReportSecuritiesTransferValue;

    private readonly Optional<UnknownArm> _unknownValue;

    private Datum91(Optional<UserReport> userReportValue,
        Optional<UserReportOrder> userReportOrderValue,
        Optional<UserReportIncomeDistribution> userReportIncomeDistributionValue,
        Optional<UserReportCorporateAction> userReportCorporateActionValue,
        Optional<UserReportSecuritiesTransfer> userReportSecuritiesTransferValue,
        Optional<UnknownArm> unknownValue)
    {
        _userReportValue = userReportValue;
        _userReportOrderValue = userReportOrderValue;
        _userReportIncomeDistributionValue = userReportIncomeDistributionValue;
        _userReportCorporateActionValue = userReportCorporateActionValue;
        _userReportSecuritiesTransferValue = userReportSecuritiesTransferValue;
        _unknownValue = unknownValue;
    }

    public static Datum91 UserReport(UserReport value) =>
        new(Optional<UserReport>.Some(value), default, default, default, default, default);

    public static Datum91 UserReportOrder(UserReportOrder value) =>
        new(default, Optional<UserReportOrder>.Some(value), default, default, default, default);

    public static Datum91 UserReportIncomeDistribution(UserReportIncomeDistribution value) =>
        new(default, default, Optional<UserReportIncomeDistribution>.Some(value), default, default, default);

    public static Datum91 UserReportCorporateAction(UserReportCorporateAction value) =>
        new(default, default, default, Optional<UserReportCorporateAction>.Some(value), default, default);

    public static Datum91 UserReportSecuritiesTransfer(UserReportSecuritiesTransfer value) =>
        new(default, default, default, default, Optional<UserReportSecuritiesTransfer>.Some(value), default);

    internal static Datum91 Unknown(JsonElement value) =>
        new(default, default, default, default, default, Optional<UnknownArm>.Some(new UnknownArm(value)));

    public bool TryGetUserReport([NotNullWhen(true)] out UserReport? value) => _userReportValue.TryGetValue(out value);

    public bool TryGetUserReportOrder([NotNullWhen(true)] out UserReportOrder? value) =>
        _userReportOrderValue.TryGetValue(out value);

    public bool TryGetUserReportIncomeDistribution([NotNullWhen(true)] out UserReportIncomeDistribution? value) =>
        _userReportIncomeDistributionValue.TryGetValue(out value);

    public bool TryGetUserReportCorporateAction([NotNullWhen(true)] out UserReportCorporateAction? value) =>
        _userReportCorporateActionValue.TryGetValue(out value);

    public bool TryGetUserReportSecuritiesTransfer([NotNullWhen(true)] out UserReportSecuritiesTransfer? value) =>
        _userReportSecuritiesTransferValue.TryGetValue(out value);

    public bool TryGetUnknown(out JsonElement value) => _unknownValue.TryGetValue(out value);

    public static implicit operator Datum91(UserReport value) => UserReport(value);

    public static implicit operator Datum91(UserReportOrder value) => UserReportOrder(value);

    public static implicit operator Datum91(UserReportIncomeDistribution value) => UserReportIncomeDistribution(value);

    public static implicit operator Datum91(UserReportCorporateAction value) => UserReportCorporateAction(value);

    public static implicit operator Datum91(UserReportSecuritiesTransfer value) => UserReportSecuritiesTransfer(value);

    public TResult Match<TResult>(Func<UserReport, TResult> onUserReport,
        Func<UserReportOrder, TResult> onUserReportOrder,
        Func<UserReportIncomeDistribution, TResult> onUserReportIncomeDistribution,
        Func<UserReportCorporateAction, TResult> onUserReportCorporateAction,
        Func<UserReportSecuritiesTransfer, TResult> onUserReportSecuritiesTransfer,
        Func<JsonElement, TResult> otherwise) =>
        this switch
        {
            _ when TryGetUserReport(out var userReportValue) => onUserReport(userReportValue),
            _ when TryGetUserReportOrder(out var userReportOrderValue) => onUserReportOrder(userReportOrderValue),
            _ when TryGetUserReportIncomeDistribution(
                out var userReportIncomeDistributionValue) => onUserReportIncomeDistribution(
                userReportIncomeDistributionValue),
            _ when TryGetUserReportCorporateAction(
                out var userReportCorporateActionValue) => onUserReportCorporateAction(userReportCorporateActionValue),
            _ when TryGetUserReportSecuritiesTransfer(
                out var userReportSecuritiesTransferValue) => onUserReportSecuritiesTransfer(
                userReportSecuritiesTransferValue),
            _ when TryGetUnknown(out var unknownValue) => otherwise(unknownValue),
            _ => throw new InvalidOperationException($"{nameof(Datum91)} holds no value.")
        };

    public void Match(Action<UserReport> onUserReport,
        Action<UserReportOrder> onUserReportOrder,
        Action<UserReportIncomeDistribution> onUserReportIncomeDistribution,
        Action<UserReportCorporateAction> onUserReportCorporateAction,
        Action<UserReportSecuritiesTransfer> onUserReportSecuritiesTransfer,
        Action<JsonElement> otherwise)
    {
        if (TryGetUserReport(out var userReportValue)) onUserReport(userReportValue);
        else if (TryGetUserReportOrder(out var userReportOrderValue)) onUserReportOrder(userReportOrderValue);
        else if (TryGetUserReportIncomeDistribution(
            out var userReportIncomeDistributionValue)) onUserReportIncomeDistribution(
            userReportIncomeDistributionValue);
        else if (TryGetUserReportCorporateAction(out var userReportCorporateActionValue)) onUserReportCorporateAction(
            userReportCorporateActionValue);
        else if (TryGetUserReportSecuritiesTransfer(
            out var userReportSecuritiesTransferValue)) onUserReportSecuritiesTransfer(
            userReportSecuritiesTransferValue);
        else if (TryGetUnknown(out var unknownValue)) otherwise(unknownValue);
        else throw new InvalidOperationException($"{nameof(Datum91)} holds no value.");
    }
}

file sealed class Datum91Converter : JsonConverter<Datum91>
{
    public override Datum91 Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        using var doc = JsonDocument.ParseValue(ref reader);
        var root = doc.RootElement;
        if (JsonSerializer.TryDeserialize<UserReport>(root, options, out var userReportValue))
        {
            return Datum91.UserReport(userReportValue);
        }
        if (JsonSerializer.TryDeserialize<UserReportOrder>(root, options, out var userReportOrderValue))
        {
            return Datum91.UserReportOrder(userReportOrderValue);
        }
        if (JsonSerializer.TryDeserialize<UserReportIncomeDistribution>(
            root,
            options,
            out var userReportIncomeDistributionValue))
        {
            return Datum91.UserReportIncomeDistribution(userReportIncomeDistributionValue);
        }
        if (JsonSerializer.TryDeserialize<UserReportCorporateAction>(
            root,
            options,
            out var userReportCorporateActionValue))
        {
            return Datum91.UserReportCorporateAction(userReportCorporateActionValue);
        }
        if (JsonSerializer.TryDeserialize<UserReportSecuritiesTransfer>(
            root,
            options,
            out var userReportSecuritiesTransferValue))
        {
            return Datum91.UserReportSecuritiesTransfer(userReportSecuritiesTransferValue);
        }
        return Datum91.Unknown(root);
    }

    public override void Write(Utf8JsonWriter writer, Datum91 value, JsonSerializerOptions options)
    {
        if (value.TryGetUserReport(out var userReportValue))
        {
            JsonSerializer.Serialize(writer, userReportValue, options);
        }
        else if (value.TryGetUserReportOrder(out var userReportOrderValue))
        {
            JsonSerializer.Serialize(writer, userReportOrderValue, options);
        }
        else if (value.TryGetUserReportIncomeDistribution(out var userReportIncomeDistributionValue))
        {
            JsonSerializer.Serialize(writer, userReportIncomeDistributionValue, options);
        }
        else if (value.TryGetUserReportCorporateAction(out var userReportCorporateActionValue))
        {
            JsonSerializer.Serialize(writer, userReportCorporateActionValue, options);
        }
        else if (value.TryGetUserReportSecuritiesTransfer(out var userReportSecuritiesTransferValue))
        {
            JsonSerializer.Serialize(writer, userReportSecuritiesTransferValue, options);
        }
        else if (value.TryGetUnknown(out var unknownValue))
        {
            unknownValue.WriteTo(writer);
        }
        else
        {
            throw new JsonException($"{nameof(Datum91)} contains no valid value to serialize.");
        }
    }
}
