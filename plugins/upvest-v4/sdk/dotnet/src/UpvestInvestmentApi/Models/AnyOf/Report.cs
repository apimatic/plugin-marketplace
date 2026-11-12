using System;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using UpvestInvestmentApi.Core.Extensions;
using UpvestInvestmentApi.Core.Models;

namespace UpvestInvestmentApi.Models.AnyOf;

/// <summary>
/// A report generated for an end user or a business. The shape of <c>data</c> depends on the report <c>type</c>.
/// </summary>
[JsonConverter(typeof(ReportConverter))]
public record Report
{
    private readonly Optional<UserReport> _userReportValue;

    private readonly Optional<BusinessReport> _businessReportValue;

    private readonly Optional<UserReportOrderExAnteCost> _userReportOrderExAnteCostValue;

    private readonly Optional<BusinessReportOrderExAnteCost> _businessReportOrderExAnteCostValue;

    private readonly Optional<UserReportOrder> _userReportOrderValue;

    private readonly Optional<BusinessReportOrder> _businessReportOrderValue;

    private readonly Optional<UserReportIncomeDistribution> _userReportIncomeDistributionValue;

    private readonly Optional<BusinessReportIncomeDistribution> _businessReportIncomeDistributionValue;

    private readonly Optional<UserReportCorporateAction> _userReportCorporateActionValue;

    private readonly Optional<UserReportSecuritiesTransfer> _userReportSecuritiesTransferValue;

    private readonly Optional<BusinessReportSecuritiesTransfer> _businessReportSecuritiesTransferValue;

    private readonly Optional<UnknownArm> _unknownValue;

    private Report(Optional<UserReport> userReportValue,
        Optional<BusinessReport> businessReportValue,
        Optional<UserReportOrderExAnteCost> userReportOrderExAnteCostValue,
        Optional<BusinessReportOrderExAnteCost> businessReportOrderExAnteCostValue,
        Optional<UserReportOrder> userReportOrderValue,
        Optional<BusinessReportOrder> businessReportOrderValue,
        Optional<UserReportIncomeDistribution> userReportIncomeDistributionValue,
        Optional<BusinessReportIncomeDistribution> businessReportIncomeDistributionValue,
        Optional<UserReportCorporateAction> userReportCorporateActionValue,
        Optional<UserReportSecuritiesTransfer> userReportSecuritiesTransferValue,
        Optional<BusinessReportSecuritiesTransfer> businessReportSecuritiesTransferValue,
        Optional<UnknownArm> unknownValue)
    {
        _userReportValue = userReportValue;
        _businessReportValue = businessReportValue;
        _userReportOrderExAnteCostValue = userReportOrderExAnteCostValue;
        _businessReportOrderExAnteCostValue = businessReportOrderExAnteCostValue;
        _userReportOrderValue = userReportOrderValue;
        _businessReportOrderValue = businessReportOrderValue;
        _userReportIncomeDistributionValue = userReportIncomeDistributionValue;
        _businessReportIncomeDistributionValue = businessReportIncomeDistributionValue;
        _userReportCorporateActionValue = userReportCorporateActionValue;
        _userReportSecuritiesTransferValue = userReportSecuritiesTransferValue;
        _businessReportSecuritiesTransferValue = businessReportSecuritiesTransferValue;
        _unknownValue = unknownValue;
    }

    public static Report UserReport(UserReport value) =>
        new(
            Optional<UserReport>.Some(value),
            default,
            default,
            default,
            default,
            default,
            default,
            default,
            default,
            default,
            default,
            default);

    public static Report BusinessReport(BusinessReport value) =>
        new(
            default,
            Optional<BusinessReport>.Some(value),
            default,
            default,
            default,
            default,
            default,
            default,
            default,
            default,
            default,
            default);

    public static Report UserReportOrderExAnteCost(UserReportOrderExAnteCost value) =>
        new(
            default,
            default,
            Optional<UserReportOrderExAnteCost>.Some(value),
            default,
            default,
            default,
            default,
            default,
            default,
            default,
            default,
            default);

    public static Report BusinessReportOrderExAnteCost(BusinessReportOrderExAnteCost value) =>
        new(
            default,
            default,
            default,
            Optional<BusinessReportOrderExAnteCost>.Some(value),
            default,
            default,
            default,
            default,
            default,
            default,
            default,
            default);

    public static Report UserReportOrder(UserReportOrder value) =>
        new(
            default,
            default,
            default,
            default,
            Optional<UserReportOrder>.Some(value),
            default,
            default,
            default,
            default,
            default,
            default,
            default);

    public static Report BusinessReportOrder(BusinessReportOrder value) =>
        new(
            default,
            default,
            default,
            default,
            default,
            Optional<BusinessReportOrder>.Some(value),
            default,
            default,
            default,
            default,
            default,
            default);

    public static Report UserReportIncomeDistribution(UserReportIncomeDistribution value) =>
        new(
            default,
            default,
            default,
            default,
            default,
            default,
            Optional<UserReportIncomeDistribution>.Some(value),
            default,
            default,
            default,
            default,
            default);

    public static Report BusinessReportIncomeDistribution(BusinessReportIncomeDistribution value) =>
        new(
            default,
            default,
            default,
            default,
            default,
            default,
            default,
            Optional<BusinessReportIncomeDistribution>.Some(value),
            default,
            default,
            default,
            default);

    public static Report UserReportCorporateAction(UserReportCorporateAction value) =>
        new(
            default,
            default,
            default,
            default,
            default,
            default,
            default,
            default,
            Optional<UserReportCorporateAction>.Some(value),
            default,
            default,
            default);

    public static Report UserReportSecuritiesTransfer(UserReportSecuritiesTransfer value) =>
        new(
            default,
            default,
            default,
            default,
            default,
            default,
            default,
            default,
            default,
            Optional<UserReportSecuritiesTransfer>.Some(value),
            default,
            default);

    public static Report BusinessReportSecuritiesTransfer(BusinessReportSecuritiesTransfer value) =>
        new(
            default,
            default,
            default,
            default,
            default,
            default,
            default,
            default,
            default,
            default,
            Optional<BusinessReportSecuritiesTransfer>.Some(value),
            default);

    internal static Report Unknown(JsonElement value) =>
        new(
            default,
            default,
            default,
            default,
            default,
            default,
            default,
            default,
            default,
            default,
            default,
            Optional<UnknownArm>.Some(new UnknownArm(value)));

    public bool TryGetUserReport([NotNullWhen(true)] out UserReport? value) => _userReportValue.TryGetValue(out value);

    public bool TryGetBusinessReport([NotNullWhen(true)] out BusinessReport? value) =>
        _businessReportValue.TryGetValue(out value);

    public bool TryGetUserReportOrderExAnteCost([NotNullWhen(true)] out UserReportOrderExAnteCost? value) =>
        _userReportOrderExAnteCostValue.TryGetValue(out value);

    public bool TryGetBusinessReportOrderExAnteCost([NotNullWhen(true)] out BusinessReportOrderExAnteCost? value) =>
        _businessReportOrderExAnteCostValue.TryGetValue(out value);

    public bool TryGetUserReportOrder([NotNullWhen(true)] out UserReportOrder? value) =>
        _userReportOrderValue.TryGetValue(out value);

    public bool TryGetBusinessReportOrder([NotNullWhen(true)] out BusinessReportOrder? value) =>
        _businessReportOrderValue.TryGetValue(out value);

    public bool TryGetUserReportIncomeDistribution([NotNullWhen(true)] out UserReportIncomeDistribution? value) =>
        _userReportIncomeDistributionValue.TryGetValue(out value);

    public bool TryGetBusinessReportIncomeDistribution([NotNullWhen(true)] out BusinessReportIncomeDistribution? value) =>
        _businessReportIncomeDistributionValue.TryGetValue(out value);

    public bool TryGetUserReportCorporateAction([NotNullWhen(true)] out UserReportCorporateAction? value) =>
        _userReportCorporateActionValue.TryGetValue(out value);

    public bool TryGetUserReportSecuritiesTransfer([NotNullWhen(true)] out UserReportSecuritiesTransfer? value) =>
        _userReportSecuritiesTransferValue.TryGetValue(out value);

    public bool TryGetBusinessReportSecuritiesTransfer([NotNullWhen(true)] out BusinessReportSecuritiesTransfer? value) =>
        _businessReportSecuritiesTransferValue.TryGetValue(out value);

    public bool TryGetUnknown(out JsonElement value) => _unknownValue.TryGetValue(out value);

    public static implicit operator Report(UserReport value) => UserReport(value);

    public static implicit operator Report(BusinessReport value) => BusinessReport(value);

    public static implicit operator Report(UserReportOrderExAnteCost value) => UserReportOrderExAnteCost(value);

    public static implicit operator Report(BusinessReportOrderExAnteCost value) => BusinessReportOrderExAnteCost(value);

    public static implicit operator Report(UserReportOrder value) => UserReportOrder(value);

    public static implicit operator Report(BusinessReportOrder value) => BusinessReportOrder(value);

    public static implicit operator Report(UserReportIncomeDistribution value) => UserReportIncomeDistribution(value);

    public static implicit operator Report(BusinessReportIncomeDistribution value) =>
        BusinessReportIncomeDistribution(value);

    public static implicit operator Report(UserReportCorporateAction value) => UserReportCorporateAction(value);

    public static implicit operator Report(UserReportSecuritiesTransfer value) => UserReportSecuritiesTransfer(value);

    public static implicit operator Report(BusinessReportSecuritiesTransfer value) =>
        BusinessReportSecuritiesTransfer(value);

    public TResult Match<TResult>(Func<UserReport, TResult> onUserReport,
        Func<BusinessReport, TResult> onBusinessReport,
        Func<UserReportOrderExAnteCost, TResult> onUserReportOrderExAnteCost,
        Func<BusinessReportOrderExAnteCost, TResult> onBusinessReportOrderExAnteCost,
        Func<UserReportOrder, TResult> onUserReportOrder,
        Func<BusinessReportOrder, TResult> onBusinessReportOrder,
        Func<UserReportIncomeDistribution, TResult> onUserReportIncomeDistribution,
        Func<BusinessReportIncomeDistribution, TResult> onBusinessReportIncomeDistribution,
        Func<UserReportCorporateAction, TResult> onUserReportCorporateAction,
        Func<UserReportSecuritiesTransfer, TResult> onUserReportSecuritiesTransfer,
        Func<BusinessReportSecuritiesTransfer, TResult> onBusinessReportSecuritiesTransfer,
        Func<JsonElement, TResult> otherwise) =>
        this switch
        {
            _ when TryGetUserReport(out var userReportValue) => onUserReport(userReportValue),
            _ when TryGetBusinessReport(out var businessReportValue) => onBusinessReport(businessReportValue),
            _ when TryGetUserReportOrderExAnteCost(
                out var userReportOrderExAnteCostValue) => onUserReportOrderExAnteCost(userReportOrderExAnteCostValue),
            _ when TryGetBusinessReportOrderExAnteCost(
                out var businessReportOrderExAnteCostValue) => onBusinessReportOrderExAnteCost(
                businessReportOrderExAnteCostValue),
            _ when TryGetUserReportOrder(out var userReportOrderValue) => onUserReportOrder(userReportOrderValue),
            _ when TryGetBusinessReportOrder(out var businessReportOrderValue) => onBusinessReportOrder(
                businessReportOrderValue),
            _ when TryGetUserReportIncomeDistribution(
                out var userReportIncomeDistributionValue) => onUserReportIncomeDistribution(
                userReportIncomeDistributionValue),
            _ when TryGetBusinessReportIncomeDistribution(
                out var businessReportIncomeDistributionValue) => onBusinessReportIncomeDistribution(
                businessReportIncomeDistributionValue),
            _ when TryGetUserReportCorporateAction(
                out var userReportCorporateActionValue) => onUserReportCorporateAction(userReportCorporateActionValue),
            _ when TryGetUserReportSecuritiesTransfer(
                out var userReportSecuritiesTransferValue) => onUserReportSecuritiesTransfer(
                userReportSecuritiesTransferValue),
            _ when TryGetBusinessReportSecuritiesTransfer(
                out var businessReportSecuritiesTransferValue) => onBusinessReportSecuritiesTransfer(
                businessReportSecuritiesTransferValue),
            _ when TryGetUnknown(out var unknownValue) => otherwise(unknownValue),
            _ => throw new InvalidOperationException($"{nameof(Report)} holds no value.")
        };

    public void Match(Action<UserReport> onUserReport,
        Action<BusinessReport> onBusinessReport,
        Action<UserReportOrderExAnteCost> onUserReportOrderExAnteCost,
        Action<BusinessReportOrderExAnteCost> onBusinessReportOrderExAnteCost,
        Action<UserReportOrder> onUserReportOrder,
        Action<BusinessReportOrder> onBusinessReportOrder,
        Action<UserReportIncomeDistribution> onUserReportIncomeDistribution,
        Action<BusinessReportIncomeDistribution> onBusinessReportIncomeDistribution,
        Action<UserReportCorporateAction> onUserReportCorporateAction,
        Action<UserReportSecuritiesTransfer> onUserReportSecuritiesTransfer,
        Action<BusinessReportSecuritiesTransfer> onBusinessReportSecuritiesTransfer,
        Action<JsonElement> otherwise)
    {
        if (TryGetUserReport(out var userReportValue)) onUserReport(userReportValue);
        else if (TryGetBusinessReport(out var businessReportValue)) onBusinessReport(businessReportValue);
        else if (TryGetUserReportOrderExAnteCost(out var userReportOrderExAnteCostValue)) onUserReportOrderExAnteCost(
            userReportOrderExAnteCostValue);
        else if (TryGetBusinessReportOrderExAnteCost(
            out var businessReportOrderExAnteCostValue)) onBusinessReportOrderExAnteCost(
            businessReportOrderExAnteCostValue);
        else if (TryGetUserReportOrder(out var userReportOrderValue)) onUserReportOrder(userReportOrderValue);
        else if (TryGetBusinessReportOrder(out var businessReportOrderValue)) onBusinessReportOrder(
            businessReportOrderValue);
        else if (TryGetUserReportIncomeDistribution(
            out var userReportIncomeDistributionValue)) onUserReportIncomeDistribution(
            userReportIncomeDistributionValue);
        else if (TryGetBusinessReportIncomeDistribution(
            out var businessReportIncomeDistributionValue)) onBusinessReportIncomeDistribution(
            businessReportIncomeDistributionValue);
        else if (TryGetUserReportCorporateAction(out var userReportCorporateActionValue)) onUserReportCorporateAction(
            userReportCorporateActionValue);
        else if (TryGetUserReportSecuritiesTransfer(
            out var userReportSecuritiesTransferValue)) onUserReportSecuritiesTransfer(
            userReportSecuritiesTransferValue);
        else if (TryGetBusinessReportSecuritiesTransfer(
            out var businessReportSecuritiesTransferValue)) onBusinessReportSecuritiesTransfer(
            businessReportSecuritiesTransferValue);
        else if (TryGetUnknown(out var unknownValue)) otherwise(unknownValue);
        else throw new InvalidOperationException($"{nameof(Report)} holds no value.");
    }
}

file sealed class ReportConverter : JsonConverter<Report>
{
    public override Report Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        using var doc = JsonDocument.ParseValue(ref reader);
        var root = doc.RootElement;
        if (JsonSerializer.TryDeserialize<UserReport>(root, options, out var userReportValue))
        {
            return Report.UserReport(userReportValue);
        }
        if (JsonSerializer.TryDeserialize<BusinessReport>(root, options, out var businessReportValue))
        {
            return Report.BusinessReport(businessReportValue);
        }
        if (JsonSerializer.TryDeserialize<UserReportOrderExAnteCost>(
            root,
            options,
            out var userReportOrderExAnteCostValue))
        {
            return Report.UserReportOrderExAnteCost(userReportOrderExAnteCostValue);
        }
        if (JsonSerializer.TryDeserialize<BusinessReportOrderExAnteCost>(
            root,
            options,
            out var businessReportOrderExAnteCostValue))
        {
            return Report.BusinessReportOrderExAnteCost(businessReportOrderExAnteCostValue);
        }
        if (JsonSerializer.TryDeserialize<UserReportOrder>(root, options, out var userReportOrderValue))
        {
            return Report.UserReportOrder(userReportOrderValue);
        }
        if (JsonSerializer.TryDeserialize<BusinessReportOrder>(root, options, out var businessReportOrderValue))
        {
            return Report.BusinessReportOrder(businessReportOrderValue);
        }
        if (JsonSerializer.TryDeserialize<UserReportIncomeDistribution>(
            root,
            options,
            out var userReportIncomeDistributionValue))
        {
            return Report.UserReportIncomeDistribution(userReportIncomeDistributionValue);
        }
        if (JsonSerializer.TryDeserialize<BusinessReportIncomeDistribution>(
            root,
            options,
            out var businessReportIncomeDistributionValue))
        {
            return Report.BusinessReportIncomeDistribution(businessReportIncomeDistributionValue);
        }
        if (JsonSerializer.TryDeserialize<UserReportCorporateAction>(
            root,
            options,
            out var userReportCorporateActionValue))
        {
            return Report.UserReportCorporateAction(userReportCorporateActionValue);
        }
        if (JsonSerializer.TryDeserialize<UserReportSecuritiesTransfer>(
            root,
            options,
            out var userReportSecuritiesTransferValue))
        {
            return Report.UserReportSecuritiesTransfer(userReportSecuritiesTransferValue);
        }
        if (JsonSerializer.TryDeserialize<BusinessReportSecuritiesTransfer>(
            root,
            options,
            out var businessReportSecuritiesTransferValue))
        {
            return Report.BusinessReportSecuritiesTransfer(businessReportSecuritiesTransferValue);
        }
        return Report.Unknown(root);
    }

    public override void Write(Utf8JsonWriter writer, Report value, JsonSerializerOptions options)
    {
        if (value.TryGetUserReport(out var userReportValue))
        {
            JsonSerializer.Serialize(writer, userReportValue, options);
        }
        else if (value.TryGetBusinessReport(out var businessReportValue))
        {
            JsonSerializer.Serialize(writer, businessReportValue, options);
        }
        else if (value.TryGetUserReportOrderExAnteCost(out var userReportOrderExAnteCostValue))
        {
            JsonSerializer.Serialize(writer, userReportOrderExAnteCostValue, options);
        }
        else if (value.TryGetBusinessReportOrderExAnteCost(out var businessReportOrderExAnteCostValue))
        {
            JsonSerializer.Serialize(writer, businessReportOrderExAnteCostValue, options);
        }
        else if (value.TryGetUserReportOrder(out var userReportOrderValue))
        {
            JsonSerializer.Serialize(writer, userReportOrderValue, options);
        }
        else if (value.TryGetBusinessReportOrder(out var businessReportOrderValue))
        {
            JsonSerializer.Serialize(writer, businessReportOrderValue, options);
        }
        else if (value.TryGetUserReportIncomeDistribution(out var userReportIncomeDistributionValue))
        {
            JsonSerializer.Serialize(writer, userReportIncomeDistributionValue, options);
        }
        else if (value.TryGetBusinessReportIncomeDistribution(out var businessReportIncomeDistributionValue))
        {
            JsonSerializer.Serialize(writer, businessReportIncomeDistributionValue, options);
        }
        else if (value.TryGetUserReportCorporateAction(out var userReportCorporateActionValue))
        {
            JsonSerializer.Serialize(writer, userReportCorporateActionValue, options);
        }
        else if (value.TryGetUserReportSecuritiesTransfer(out var userReportSecuritiesTransferValue))
        {
            JsonSerializer.Serialize(writer, userReportSecuritiesTransferValue, options);
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
            throw new JsonException($"{nameof(Report)} contains no valid value to serialize.");
        }
    }
}
