using System;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using UpvestInvestmentApi.Core.Extensions;
using UpvestInvestmentApi.Core.Models;

namespace UpvestInvestmentApi.Models.AnyOf;

/// <summary>
/// A MiFID II ex-ante cost report, estimating the costs of a planned order before it is placed.
/// </summary>
[JsonConverter(typeof(ReportOrderExAnteCostConverter))]
public record ReportOrderExAnteCost
{
    private readonly Optional<UserReportOrderExAnteCost> _userReportOrderExAnteCostValue;

    private readonly Optional<BusinessReportOrderExAnteCost> _businessReportOrderExAnteCostValue;

    private readonly Optional<UnknownArm> _unknownValue;

    private ReportOrderExAnteCost(Optional<UserReportOrderExAnteCost> userReportOrderExAnteCostValue,
        Optional<BusinessReportOrderExAnteCost> businessReportOrderExAnteCostValue,
        Optional<UnknownArm> unknownValue)
    {
        _userReportOrderExAnteCostValue = userReportOrderExAnteCostValue;
        _businessReportOrderExAnteCostValue = businessReportOrderExAnteCostValue;
        _unknownValue = unknownValue;
    }

    public static ReportOrderExAnteCost UserReportOrderExAnteCost(UserReportOrderExAnteCost value) =>
        new(Optional<UserReportOrderExAnteCost>.Some(value), default, default);

    public static ReportOrderExAnteCost BusinessReportOrderExAnteCost(BusinessReportOrderExAnteCost value) =>
        new(default, Optional<BusinessReportOrderExAnteCost>.Some(value), default);

    internal static ReportOrderExAnteCost Unknown(JsonElement value) =>
        new(default, default, Optional<UnknownArm>.Some(new UnknownArm(value)));

    public bool TryGetUserReportOrderExAnteCost([NotNullWhen(true)] out UserReportOrderExAnteCost? value) =>
        _userReportOrderExAnteCostValue.TryGetValue(out value);

    public bool TryGetBusinessReportOrderExAnteCost([NotNullWhen(true)] out BusinessReportOrderExAnteCost? value) =>
        _businessReportOrderExAnteCostValue.TryGetValue(out value);

    public bool TryGetUnknown(out JsonElement value) => _unknownValue.TryGetValue(out value);

    public static implicit operator ReportOrderExAnteCost(UserReportOrderExAnteCost value) =>
        UserReportOrderExAnteCost(value);

    public static implicit operator ReportOrderExAnteCost(BusinessReportOrderExAnteCost value) =>
        BusinessReportOrderExAnteCost(value);

    public TResult Match<TResult>(Func<UserReportOrderExAnteCost, TResult> onUserReportOrderExAnteCost,
        Func<BusinessReportOrderExAnteCost, TResult> onBusinessReportOrderExAnteCost,
        Func<JsonElement, TResult> otherwise) =>
        this switch
        {
            _ when TryGetUserReportOrderExAnteCost(
                out var userReportOrderExAnteCostValue) => onUserReportOrderExAnteCost(userReportOrderExAnteCostValue),
            _ when TryGetBusinessReportOrderExAnteCost(
                out var businessReportOrderExAnteCostValue) => onBusinessReportOrderExAnteCost(
                businessReportOrderExAnteCostValue),
            _ when TryGetUnknown(out var unknownValue) => otherwise(unknownValue),
            _ => throw new InvalidOperationException($"{nameof(ReportOrderExAnteCost)} holds no value.")
        };

    public void Match(Action<UserReportOrderExAnteCost> onUserReportOrderExAnteCost,
        Action<BusinessReportOrderExAnteCost> onBusinessReportOrderExAnteCost,
        Action<JsonElement> otherwise)
    {
        if (TryGetUserReportOrderExAnteCost(out var userReportOrderExAnteCostValue)) onUserReportOrderExAnteCost(
            userReportOrderExAnteCostValue);
        else if (TryGetBusinessReportOrderExAnteCost(
            out var businessReportOrderExAnteCostValue)) onBusinessReportOrderExAnteCost(
            businessReportOrderExAnteCostValue);
        else if (TryGetUnknown(out var unknownValue)) otherwise(unknownValue);
        else throw new InvalidOperationException($"{nameof(ReportOrderExAnteCost)} holds no value.");
    }
}

file sealed class ReportOrderExAnteCostConverter : JsonConverter<ReportOrderExAnteCost>
{
    public override ReportOrderExAnteCost Read(ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options)
    {
        using var doc = JsonDocument.ParseValue(ref reader);
        var root = doc.RootElement;
        if (JsonSerializer.TryDeserialize<UserReportOrderExAnteCost>(
            root,
            options,
            out var userReportOrderExAnteCostValue))
        {
            return ReportOrderExAnteCost.UserReportOrderExAnteCost(userReportOrderExAnteCostValue);
        }
        if (JsonSerializer.TryDeserialize<BusinessReportOrderExAnteCost>(
            root,
            options,
            out var businessReportOrderExAnteCostValue))
        {
            return ReportOrderExAnteCost.BusinessReportOrderExAnteCost(businessReportOrderExAnteCostValue);
        }
        return ReportOrderExAnteCost.Unknown(root);
    }

    public override void Write(Utf8JsonWriter writer, ReportOrderExAnteCost value, JsonSerializerOptions options)
    {
        if (value.TryGetUserReportOrderExAnteCost(out var userReportOrderExAnteCostValue))
        {
            JsonSerializer.Serialize(writer, userReportOrderExAnteCostValue, options);
        }
        else if (value.TryGetBusinessReportOrderExAnteCost(out var businessReportOrderExAnteCostValue))
        {
            JsonSerializer.Serialize(writer, businessReportOrderExAnteCostValue, options);
        }
        else if (value.TryGetUnknown(out var unknownValue))
        {
            unknownValue.WriteTo(writer);
        }
        else
        {
            throw new JsonException($"{nameof(ReportOrderExAnteCost)} contains no valid value to serialize.");
        }
    }
}
