using System;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using UpvestInvestmentApi.Core.Extensions;
using UpvestInvestmentApi.Core.Models;

namespace UpvestInvestmentApi.Models.AnyOf;

/// <summary>
/// Request payload for creating a business check, either a KYB check or a self-assessment.
/// </summary>
[JsonConverter(typeof(BusinessCheckCreateRequestConverter))]
public record BusinessCheckCreateRequest
{
    private readonly Optional<BusinessCheckKnowYourBusinessCreateRequest> _businessCheckKnowYourBusinessCreateRequestValue;

    private readonly Optional<BusinessCheckBusinessSelfAssessmentCreateRequest> _businessCheckBusinessSelfAssessmentCreateRequestValue;

    private readonly Optional<UnknownArm> _unknownValue;

    private BusinessCheckCreateRequest(Optional<BusinessCheckKnowYourBusinessCreateRequest> businessCheckKnowYourBusinessCreateRequestValue,
        Optional<BusinessCheckBusinessSelfAssessmentCreateRequest> businessCheckBusinessSelfAssessmentCreateRequestValue,
        Optional<UnknownArm> unknownValue)
    {
        _businessCheckKnowYourBusinessCreateRequestValue = businessCheckKnowYourBusinessCreateRequestValue;
        _businessCheckBusinessSelfAssessmentCreateRequestValue = businessCheckBusinessSelfAssessmentCreateRequestValue;
        _unknownValue = unknownValue;
    }

    public static BusinessCheckCreateRequest BusinessCheckKnowYourBusinessCreateRequest(BusinessCheckKnowYourBusinessCreateRequest value) =>
        new(Optional<BusinessCheckKnowYourBusinessCreateRequest>.Some(value), default, default);

    public static BusinessCheckCreateRequest BusinessCheckBusinessSelfAssessmentCreateRequest(BusinessCheckBusinessSelfAssessmentCreateRequest value) =>
        new(default, Optional<BusinessCheckBusinessSelfAssessmentCreateRequest>.Some(value), default);

    internal static BusinessCheckCreateRequest Unknown(JsonElement value) =>
        new(default, default, Optional<UnknownArm>.Some(new UnknownArm(value)));

    public bool TryGetBusinessCheckKnowYourBusinessCreateRequest([NotNullWhen(true)] out BusinessCheckKnowYourBusinessCreateRequest? value) =>
        _businessCheckKnowYourBusinessCreateRequestValue.TryGetValue(out value);

    public bool TryGetBusinessCheckBusinessSelfAssessmentCreateRequest([NotNullWhen(true)] out BusinessCheckBusinessSelfAssessmentCreateRequest? value) =>
        _businessCheckBusinessSelfAssessmentCreateRequestValue.TryGetValue(out value);

    public bool TryGetUnknown(out JsonElement value) => _unknownValue.TryGetValue(out value);

    public static implicit operator BusinessCheckCreateRequest(BusinessCheckKnowYourBusinessCreateRequest value) =>
        BusinessCheckKnowYourBusinessCreateRequest(value);

    public static implicit operator BusinessCheckCreateRequest(BusinessCheckBusinessSelfAssessmentCreateRequest value) =>
        BusinessCheckBusinessSelfAssessmentCreateRequest(value);

    public TResult Match<TResult>(Func<BusinessCheckKnowYourBusinessCreateRequest, TResult> onBusinessCheckKnowYourBusinessCreateRequest,
        Func<BusinessCheckBusinessSelfAssessmentCreateRequest, TResult> onBusinessCheckBusinessSelfAssessmentCreateRequest,
        Func<JsonElement, TResult> otherwise) =>
        this switch
        {
            _ when TryGetBusinessCheckKnowYourBusinessCreateRequest(
                out var businessCheckKnowYourBusinessCreateRequestValue) => onBusinessCheckKnowYourBusinessCreateRequest(
                businessCheckKnowYourBusinessCreateRequestValue),
            _ when TryGetBusinessCheckBusinessSelfAssessmentCreateRequest(
                out var businessCheckBusinessSelfAssessmentCreateRequestValue) => onBusinessCheckBusinessSelfAssessmentCreateRequest(
                businessCheckBusinessSelfAssessmentCreateRequestValue),
            _ when TryGetUnknown(out var unknownValue) => otherwise(unknownValue),
            _ => throw new InvalidOperationException($"{nameof(BusinessCheckCreateRequest)} holds no value.")
        };

    public void Match(Action<BusinessCheckKnowYourBusinessCreateRequest> onBusinessCheckKnowYourBusinessCreateRequest,
        Action<BusinessCheckBusinessSelfAssessmentCreateRequest> onBusinessCheckBusinessSelfAssessmentCreateRequest,
        Action<JsonElement> otherwise)
    {
        if (TryGetBusinessCheckKnowYourBusinessCreateRequest(
            out var businessCheckKnowYourBusinessCreateRequestValue)) onBusinessCheckKnowYourBusinessCreateRequest(
            businessCheckKnowYourBusinessCreateRequestValue);
        else if (TryGetBusinessCheckBusinessSelfAssessmentCreateRequest(
            out var businessCheckBusinessSelfAssessmentCreateRequestValue)) onBusinessCheckBusinessSelfAssessmentCreateRequest(
            businessCheckBusinessSelfAssessmentCreateRequestValue);
        else if (TryGetUnknown(out var unknownValue)) otherwise(unknownValue);
        else throw new InvalidOperationException($"{nameof(BusinessCheckCreateRequest)} holds no value.");
    }
}

file sealed class BusinessCheckCreateRequestConverter : JsonConverter<BusinessCheckCreateRequest>
{
    public override BusinessCheckCreateRequest Read(ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options)
    {
        using var doc = JsonDocument.ParseValue(ref reader);
        var root = doc.RootElement;
        if (JsonSerializer.TryDeserialize<BusinessCheckKnowYourBusinessCreateRequest>(
            root,
            options,
            out var businessCheckKnowYourBusinessCreateRequestValue))
        {
            return BusinessCheckCreateRequest.BusinessCheckKnowYourBusinessCreateRequest(
                businessCheckKnowYourBusinessCreateRequestValue);
        }
        if (JsonSerializer.TryDeserialize<BusinessCheckBusinessSelfAssessmentCreateRequest>(
            root,
            options,
            out var businessCheckBusinessSelfAssessmentCreateRequestValue))
        {
            return BusinessCheckCreateRequest.BusinessCheckBusinessSelfAssessmentCreateRequest(
                businessCheckBusinessSelfAssessmentCreateRequestValue);
        }
        return BusinessCheckCreateRequest.Unknown(root);
    }

    public override void Write(Utf8JsonWriter writer, BusinessCheckCreateRequest value, JsonSerializerOptions options)
    {
        if (value.TryGetBusinessCheckKnowYourBusinessCreateRequest(
            out var businessCheckKnowYourBusinessCreateRequestValue))
        {
            JsonSerializer.Serialize(writer, businessCheckKnowYourBusinessCreateRequestValue, options);
        }
        else if (value.TryGetBusinessCheckBusinessSelfAssessmentCreateRequest(
            out var businessCheckBusinessSelfAssessmentCreateRequestValue))
        {
            JsonSerializer.Serialize(writer, businessCheckBusinessSelfAssessmentCreateRequestValue, options);
        }
        else if (value.TryGetUnknown(out var unknownValue))
        {
            unknownValue.WriteTo(writer);
        }
        else
        {
            throw new JsonException($"{nameof(BusinessCheckCreateRequest)} contains no valid value to serialize.");
        }
    }
}
