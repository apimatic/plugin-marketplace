using System;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using UpvestInvestmentApi.Core.Extensions;
using UpvestInvestmentApi.Core.Models;

namespace UpvestInvestmentApi.Models.AnyOf;

/// <summary>
/// Request payload for creating a business, either a company or a sole trader.
/// </summary>
[JsonConverter(typeof(BusinessCreateRequestConverter))]
public record BusinessCreateRequest
{
    private readonly Optional<BusinessCompanyCreateRequest> _businessCompanyCreateRequestValue;

    private readonly Optional<BusinessSoleTraderCreateRequest> _businessSoleTraderCreateRequestValue;

    private readonly Optional<UnknownArm> _unknownValue;

    private BusinessCreateRequest(Optional<BusinessCompanyCreateRequest> businessCompanyCreateRequestValue,
        Optional<BusinessSoleTraderCreateRequest> businessSoleTraderCreateRequestValue,
        Optional<UnknownArm> unknownValue)
    {
        _businessCompanyCreateRequestValue = businessCompanyCreateRequestValue;
        _businessSoleTraderCreateRequestValue = businessSoleTraderCreateRequestValue;
        _unknownValue = unknownValue;
    }

    public static BusinessCreateRequest BusinessCompanyCreateRequest(BusinessCompanyCreateRequest value) =>
        new(Optional<BusinessCompanyCreateRequest>.Some(value), default, default);

    public static BusinessCreateRequest BusinessSoleTraderCreateRequest(BusinessSoleTraderCreateRequest value) =>
        new(default, Optional<BusinessSoleTraderCreateRequest>.Some(value), default);

    internal static BusinessCreateRequest Unknown(JsonElement value) =>
        new(default, default, Optional<UnknownArm>.Some(new UnknownArm(value)));

    public bool TryGetBusinessCompanyCreateRequest([NotNullWhen(true)] out BusinessCompanyCreateRequest? value) =>
        _businessCompanyCreateRequestValue.TryGetValue(out value);

    public bool TryGetBusinessSoleTraderCreateRequest([NotNullWhen(true)] out BusinessSoleTraderCreateRequest? value) =>
        _businessSoleTraderCreateRequestValue.TryGetValue(out value);

    public bool TryGetUnknown(out JsonElement value) => _unknownValue.TryGetValue(out value);

    public static implicit operator BusinessCreateRequest(BusinessCompanyCreateRequest value) =>
        BusinessCompanyCreateRequest(value);

    public static implicit operator BusinessCreateRequest(BusinessSoleTraderCreateRequest value) =>
        BusinessSoleTraderCreateRequest(value);

    public TResult Match<TResult>(Func<BusinessCompanyCreateRequest, TResult> onBusinessCompanyCreateRequest,
        Func<BusinessSoleTraderCreateRequest, TResult> onBusinessSoleTraderCreateRequest,
        Func<JsonElement, TResult> otherwise) =>
        this switch
        {
            _ when TryGetBusinessCompanyCreateRequest(
                out var businessCompanyCreateRequestValue) => onBusinessCompanyCreateRequest(
                businessCompanyCreateRequestValue),
            _ when TryGetBusinessSoleTraderCreateRequest(
                out var businessSoleTraderCreateRequestValue) => onBusinessSoleTraderCreateRequest(
                businessSoleTraderCreateRequestValue),
            _ when TryGetUnknown(out var unknownValue) => otherwise(unknownValue),
            _ => throw new InvalidOperationException($"{nameof(BusinessCreateRequest)} holds no value.")
        };

    public void Match(Action<BusinessCompanyCreateRequest> onBusinessCompanyCreateRequest,
        Action<BusinessSoleTraderCreateRequest> onBusinessSoleTraderCreateRequest,
        Action<JsonElement> otherwise)
    {
        if (TryGetBusinessCompanyCreateRequest(
            out var businessCompanyCreateRequestValue)) onBusinessCompanyCreateRequest(
            businessCompanyCreateRequestValue);
        else if (TryGetBusinessSoleTraderCreateRequest(
            out var businessSoleTraderCreateRequestValue)) onBusinessSoleTraderCreateRequest(
            businessSoleTraderCreateRequestValue);
        else if (TryGetUnknown(out var unknownValue)) otherwise(unknownValue);
        else throw new InvalidOperationException($"{nameof(BusinessCreateRequest)} holds no value.");
    }
}

file sealed class BusinessCreateRequestConverter : JsonConverter<BusinessCreateRequest>
{
    public override BusinessCreateRequest Read(ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options)
    {
        using var doc = JsonDocument.ParseValue(ref reader);
        var root = doc.RootElement;
        if (JsonSerializer.TryDeserialize<BusinessCompanyCreateRequest>(
            root,
            options,
            out var businessCompanyCreateRequestValue))
        {
            return BusinessCreateRequest.BusinessCompanyCreateRequest(businessCompanyCreateRequestValue);
        }
        if (JsonSerializer.TryDeserialize<BusinessSoleTraderCreateRequest>(
            root,
            options,
            out var businessSoleTraderCreateRequestValue))
        {
            return BusinessCreateRequest.BusinessSoleTraderCreateRequest(businessSoleTraderCreateRequestValue);
        }
        return BusinessCreateRequest.Unknown(root);
    }

    public override void Write(Utf8JsonWriter writer, BusinessCreateRequest value, JsonSerializerOptions options)
    {
        if (value.TryGetBusinessCompanyCreateRequest(out var businessCompanyCreateRequestValue))
        {
            JsonSerializer.Serialize(writer, businessCompanyCreateRequestValue, options);
        }
        else if (value.TryGetBusinessSoleTraderCreateRequest(out var businessSoleTraderCreateRequestValue))
        {
            JsonSerializer.Serialize(writer, businessSoleTraderCreateRequestValue, options);
        }
        else if (value.TryGetUnknown(out var unknownValue))
        {
            unknownValue.WriteTo(writer);
        }
        else
        {
            throw new JsonException($"{nameof(BusinessCreateRequest)} contains no valid value to serialize.");
        }
    }
}
