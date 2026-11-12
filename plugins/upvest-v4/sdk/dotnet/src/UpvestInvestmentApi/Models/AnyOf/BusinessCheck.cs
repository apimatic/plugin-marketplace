using System;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using UpvestInvestmentApi.Core.Extensions;
using UpvestInvestmentApi.Core.Models;

namespace UpvestInvestmentApi.Models.AnyOf;

/// <summary>
/// A check conducted for a business, either a KYB check or a self-assessment.
/// </summary>
[JsonConverter(typeof(BusinessCheckConverter))]
public record BusinessCheck
{
    private readonly Optional<BusinessCheckKyb> _businessCheckKybValue;

    private readonly Optional<BusinessCheckBusinessSelfAssessment> _businessCheckBusinessSelfAssessmentValue;

    private readonly Optional<UnknownArm> _unknownValue;

    private BusinessCheck(Optional<BusinessCheckKyb> businessCheckKybValue,
        Optional<BusinessCheckBusinessSelfAssessment> businessCheckBusinessSelfAssessmentValue,
        Optional<UnknownArm> unknownValue)
    {
        _businessCheckKybValue = businessCheckKybValue;
        _businessCheckBusinessSelfAssessmentValue = businessCheckBusinessSelfAssessmentValue;
        _unknownValue = unknownValue;
    }

    public static BusinessCheck BusinessCheckKyb(BusinessCheckKyb value) =>
        new(Optional<BusinessCheckKyb>.Some(value), default, default);

    public static BusinessCheck BusinessCheckBusinessSelfAssessment(BusinessCheckBusinessSelfAssessment value) =>
        new(default, Optional<BusinessCheckBusinessSelfAssessment>.Some(value), default);

    internal static BusinessCheck Unknown(JsonElement value) =>
        new(default, default, Optional<UnknownArm>.Some(new UnknownArm(value)));

    public bool TryGetBusinessCheckKyb([NotNullWhen(true)] out BusinessCheckKyb? value) =>
        _businessCheckKybValue.TryGetValue(out value);

    public bool TryGetBusinessCheckBusinessSelfAssessment([NotNullWhen(true)] out BusinessCheckBusinessSelfAssessment? value) =>
        _businessCheckBusinessSelfAssessmentValue.TryGetValue(out value);

    public bool TryGetUnknown(out JsonElement value) => _unknownValue.TryGetValue(out value);

    public static implicit operator BusinessCheck(BusinessCheckKyb value) => BusinessCheckKyb(value);

    public static implicit operator BusinessCheck(BusinessCheckBusinessSelfAssessment value) =>
        BusinessCheckBusinessSelfAssessment(value);

    public TResult Match<TResult>(Func<BusinessCheckKyb, TResult> onBusinessCheckKyb,
        Func<BusinessCheckBusinessSelfAssessment, TResult> onBusinessCheckBusinessSelfAssessment,
        Func<JsonElement, TResult> otherwise) =>
        this switch
        {
            _ when TryGetBusinessCheckKyb(out var businessCheckKybValue) => onBusinessCheckKyb(businessCheckKybValue),
            _ when TryGetBusinessCheckBusinessSelfAssessment(
                out var businessCheckBusinessSelfAssessmentValue) => onBusinessCheckBusinessSelfAssessment(
                businessCheckBusinessSelfAssessmentValue),
            _ when TryGetUnknown(out var unknownValue) => otherwise(unknownValue),
            _ => throw new InvalidOperationException($"{nameof(BusinessCheck)} holds no value.")
        };

    public void Match(Action<BusinessCheckKyb> onBusinessCheckKyb,
        Action<BusinessCheckBusinessSelfAssessment> onBusinessCheckBusinessSelfAssessment,
        Action<JsonElement> otherwise)
    {
        if (TryGetBusinessCheckKyb(out var businessCheckKybValue)) onBusinessCheckKyb(businessCheckKybValue);
        else if (TryGetBusinessCheckBusinessSelfAssessment(
            out var businessCheckBusinessSelfAssessmentValue)) onBusinessCheckBusinessSelfAssessment(
            businessCheckBusinessSelfAssessmentValue);
        else if (TryGetUnknown(out var unknownValue)) otherwise(unknownValue);
        else throw new InvalidOperationException($"{nameof(BusinessCheck)} holds no value.");
    }
}

file sealed class BusinessCheckConverter : JsonConverter<BusinessCheck>
{
    public override BusinessCheck Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        using var doc = JsonDocument.ParseValue(ref reader);
        var root = doc.RootElement;
        if (JsonSerializer.TryDeserialize<BusinessCheckKyb>(root, options, out var businessCheckKybValue))
        {
            return BusinessCheck.BusinessCheckKyb(businessCheckKybValue);
        }
        if (JsonSerializer.TryDeserialize<BusinessCheckBusinessSelfAssessment>(
            root,
            options,
            out var businessCheckBusinessSelfAssessmentValue))
        {
            return BusinessCheck.BusinessCheckBusinessSelfAssessment(businessCheckBusinessSelfAssessmentValue);
        }
        return BusinessCheck.Unknown(root);
    }

    public override void Write(Utf8JsonWriter writer, BusinessCheck value, JsonSerializerOptions options)
    {
        if (value.TryGetBusinessCheckKyb(out var businessCheckKybValue))
        {
            JsonSerializer.Serialize(writer, businessCheckKybValue, options);
        }
        else if (value.TryGetBusinessCheckBusinessSelfAssessment(out var businessCheckBusinessSelfAssessmentValue))
        {
            JsonSerializer.Serialize(writer, businessCheckBusinessSelfAssessmentValue, options);
        }
        else if (value.TryGetUnknown(out var unknownValue))
        {
            unknownValue.WriteTo(writer);
        }
        else
        {
            throw new JsonException($"{nameof(BusinessCheck)} contains no valid value to serialize.");
        }
    }
}
