using System;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using UpvestInvestmentApi.Core.Extensions;
using UpvestInvestmentApi.Core.Models;

namespace UpvestInvestmentApi.Models.AnyOf;

/// <summary>
/// The business created, either a company or a sole trader.
/// </summary>
[JsonConverter(typeof(BusinessCreateRequest1Converter))]
public record BusinessCreateRequest1
{
    private readonly Optional<BusinessCompanyCreateResponse> _businessCompanyCreateResponseValue;

    private readonly Optional<BusinessSoleTraderCreateResponse> _businessSoleTraderCreateResponseValue;

    private readonly Optional<UnknownArm> _unknownValue;

    private BusinessCreateRequest1(Optional<BusinessCompanyCreateResponse> businessCompanyCreateResponseValue,
        Optional<BusinessSoleTraderCreateResponse> businessSoleTraderCreateResponseValue,
        Optional<UnknownArm> unknownValue)
    {
        _businessCompanyCreateResponseValue = businessCompanyCreateResponseValue;
        _businessSoleTraderCreateResponseValue = businessSoleTraderCreateResponseValue;
        _unknownValue = unknownValue;
    }

    public static BusinessCreateRequest1 BusinessCompanyCreateResponse(BusinessCompanyCreateResponse value) =>
        new(Optional<BusinessCompanyCreateResponse>.Some(value), default, default);

    public static BusinessCreateRequest1 BusinessSoleTraderCreateResponse(BusinessSoleTraderCreateResponse value) =>
        new(default, Optional<BusinessSoleTraderCreateResponse>.Some(value), default);

    internal static BusinessCreateRequest1 Unknown(JsonElement value) =>
        new(default, default, Optional<UnknownArm>.Some(new UnknownArm(value)));

    public bool TryGetBusinessCompanyCreateResponse([NotNullWhen(true)] out BusinessCompanyCreateResponse? value) =>
        _businessCompanyCreateResponseValue.TryGetValue(out value);

    public bool TryGetBusinessSoleTraderCreateResponse([NotNullWhen(true)] out BusinessSoleTraderCreateResponse? value) =>
        _businessSoleTraderCreateResponseValue.TryGetValue(out value);

    public bool TryGetUnknown(out JsonElement value) => _unknownValue.TryGetValue(out value);

    public static implicit operator BusinessCreateRequest1(BusinessCompanyCreateResponse value) =>
        BusinessCompanyCreateResponse(value);

    public static implicit operator BusinessCreateRequest1(BusinessSoleTraderCreateResponse value) =>
        BusinessSoleTraderCreateResponse(value);

    public TResult Match<TResult>(Func<BusinessCompanyCreateResponse, TResult> onBusinessCompanyCreateResponse,
        Func<BusinessSoleTraderCreateResponse, TResult> onBusinessSoleTraderCreateResponse,
        Func<JsonElement, TResult> otherwise) =>
        this switch
        {
            _ when TryGetBusinessCompanyCreateResponse(
                out var businessCompanyCreateResponseValue) => onBusinessCompanyCreateResponse(
                businessCompanyCreateResponseValue),
            _ when TryGetBusinessSoleTraderCreateResponse(
                out var businessSoleTraderCreateResponseValue) => onBusinessSoleTraderCreateResponse(
                businessSoleTraderCreateResponseValue),
            _ when TryGetUnknown(out var unknownValue) => otherwise(unknownValue),
            _ => throw new InvalidOperationException($"{nameof(BusinessCreateRequest1)} holds no value.")
        };

    public void Match(Action<BusinessCompanyCreateResponse> onBusinessCompanyCreateResponse,
        Action<BusinessSoleTraderCreateResponse> onBusinessSoleTraderCreateResponse,
        Action<JsonElement> otherwise)
    {
        if (TryGetBusinessCompanyCreateResponse(
            out var businessCompanyCreateResponseValue)) onBusinessCompanyCreateResponse(
            businessCompanyCreateResponseValue);
        else if (TryGetBusinessSoleTraderCreateResponse(
            out var businessSoleTraderCreateResponseValue)) onBusinessSoleTraderCreateResponse(
            businessSoleTraderCreateResponseValue);
        else if (TryGetUnknown(out var unknownValue)) otherwise(unknownValue);
        else throw new InvalidOperationException($"{nameof(BusinessCreateRequest1)} holds no value.");
    }
}

file sealed class BusinessCreateRequest1Converter : JsonConverter<BusinessCreateRequest1>
{
    public override BusinessCreateRequest1 Read(ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options)
    {
        using var doc = JsonDocument.ParseValue(ref reader);
        var root = doc.RootElement;
        if (JsonSerializer.TryDeserialize<BusinessCompanyCreateResponse>(
            root,
            options,
            out var businessCompanyCreateResponseValue))
        {
            return BusinessCreateRequest1.BusinessCompanyCreateResponse(businessCompanyCreateResponseValue);
        }
        if (JsonSerializer.TryDeserialize<BusinessSoleTraderCreateResponse>(
            root,
            options,
            out var businessSoleTraderCreateResponseValue))
        {
            return BusinessCreateRequest1.BusinessSoleTraderCreateResponse(businessSoleTraderCreateResponseValue);
        }
        return BusinessCreateRequest1.Unknown(root);
    }

    public override void Write(Utf8JsonWriter writer, BusinessCreateRequest1 value, JsonSerializerOptions options)
    {
        if (value.TryGetBusinessCompanyCreateResponse(out var businessCompanyCreateResponseValue))
        {
            JsonSerializer.Serialize(writer, businessCompanyCreateResponseValue, options);
        }
        else if (value.TryGetBusinessSoleTraderCreateResponse(out var businessSoleTraderCreateResponseValue))
        {
            JsonSerializer.Serialize(writer, businessSoleTraderCreateResponseValue, options);
        }
        else if (value.TryGetUnknown(out var unknownValue))
        {
            unknownValue.WriteTo(writer);
        }
        else
        {
            throw new JsonException($"{nameof(BusinessCreateRequest1)} contains no valid value to serialize.");
        }
    }
}
