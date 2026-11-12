using System;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using UpvestInvestmentApi.Core.Extensions;
using UpvestInvestmentApi.Core.Models;

namespace UpvestInvestmentApi.Models.AnyOf;

/// <summary>
/// Request payload for creating a user check: KYC, proof of residence, instrument fit, guardian, or self-assessment.
/// </summary>
[JsonConverter(typeof(UserCheckCreateRequestConverter))]
public record UserCheckCreateRequest
{
    private readonly Optional<UserCheckKnowYourCustomerCreateRequest> _userCheckKnowYourCustomerCreateRequestValue;

    private readonly Optional<UserCheckProofOfResidencyCreateRequest> _userCheckProofOfResidencyCreateRequestValue;

    private readonly Optional<UserCheckInstrumentFitCreateRequest> _userCheckInstrumentFitCreateRequestValue;

    private readonly Optional<UserCheckGuardianCreateRequest> _userCheckGuardianCreateRequestValue;

    private readonly Optional<UserCheckUserSelfAssessmentCreateRequest> _userCheckUserSelfAssessmentCreateRequestValue;

    private readonly Optional<UserCheckUsWithholdingTaxStatusCreateRequest> _userCheckUsWithholdingTaxStatusCreateRequestValue;

    private readonly Optional<UnknownArm> _unknownValue;

    private UserCheckCreateRequest(Optional<UserCheckKnowYourCustomerCreateRequest> userCheckKnowYourCustomerCreateRequestValue,
        Optional<UserCheckProofOfResidencyCreateRequest> userCheckProofOfResidencyCreateRequestValue,
        Optional<UserCheckInstrumentFitCreateRequest> userCheckInstrumentFitCreateRequestValue,
        Optional<UserCheckGuardianCreateRequest> userCheckGuardianCreateRequestValue,
        Optional<UserCheckUserSelfAssessmentCreateRequest> userCheckUserSelfAssessmentCreateRequestValue,
        Optional<UserCheckUsWithholdingTaxStatusCreateRequest> userCheckUsWithholdingTaxStatusCreateRequestValue,
        Optional<UnknownArm> unknownValue)
    {
        _userCheckKnowYourCustomerCreateRequestValue = userCheckKnowYourCustomerCreateRequestValue;
        _userCheckProofOfResidencyCreateRequestValue = userCheckProofOfResidencyCreateRequestValue;
        _userCheckInstrumentFitCreateRequestValue = userCheckInstrumentFitCreateRequestValue;
        _userCheckGuardianCreateRequestValue = userCheckGuardianCreateRequestValue;
        _userCheckUserSelfAssessmentCreateRequestValue = userCheckUserSelfAssessmentCreateRequestValue;
        _userCheckUsWithholdingTaxStatusCreateRequestValue = userCheckUsWithholdingTaxStatusCreateRequestValue;
        _unknownValue = unknownValue;
    }

    public static UserCheckCreateRequest UserCheckKnowYourCustomerCreateRequest(UserCheckKnowYourCustomerCreateRequest value) =>
        new(
            Optional<UserCheckKnowYourCustomerCreateRequest>.Some(value),
            default,
            default,
            default,
            default,
            default,
            default);

    public static UserCheckCreateRequest UserCheckProofOfResidencyCreateRequest(UserCheckProofOfResidencyCreateRequest value) =>
        new(
            default,
            Optional<UserCheckProofOfResidencyCreateRequest>.Some(value),
            default,
            default,
            default,
            default,
            default);

    public static UserCheckCreateRequest UserCheckInstrumentFitCreateRequest(UserCheckInstrumentFitCreateRequest value) =>
        new(
            default,
            default,
            Optional<UserCheckInstrumentFitCreateRequest>.Some(value),
            default,
            default,
            default,
            default);

    public static UserCheckCreateRequest UserCheckGuardianCreateRequest(UserCheckGuardianCreateRequest value) =>
        new(default, default, default, Optional<UserCheckGuardianCreateRequest>.Some(value), default, default, default);

    public static UserCheckCreateRequest UserCheckUserSelfAssessmentCreateRequest(UserCheckUserSelfAssessmentCreateRequest value) =>
        new(
            default,
            default,
            default,
            default,
            Optional<UserCheckUserSelfAssessmentCreateRequest>.Some(value),
            default,
            default);

    public static UserCheckCreateRequest UserCheckUsWithholdingTaxStatusCreateRequest(UserCheckUsWithholdingTaxStatusCreateRequest value) =>
        new(
            default,
            default,
            default,
            default,
            default,
            Optional<UserCheckUsWithholdingTaxStatusCreateRequest>.Some(value),
            default);

    internal static UserCheckCreateRequest Unknown(JsonElement value) =>
        new(default, default, default, default, default, default, Optional<UnknownArm>.Some(new UnknownArm(value)));

    public bool TryGetUserCheckKnowYourCustomerCreateRequest([NotNullWhen(true)] out UserCheckKnowYourCustomerCreateRequest? value) =>
        _userCheckKnowYourCustomerCreateRequestValue.TryGetValue(out value);

    public bool TryGetUserCheckProofOfResidencyCreateRequest([NotNullWhen(true)] out UserCheckProofOfResidencyCreateRequest? value) =>
        _userCheckProofOfResidencyCreateRequestValue.TryGetValue(out value);

    public bool TryGetUserCheckInstrumentFitCreateRequest([NotNullWhen(true)] out UserCheckInstrumentFitCreateRequest? value) =>
        _userCheckInstrumentFitCreateRequestValue.TryGetValue(out value);

    public bool TryGetUserCheckGuardianCreateRequest([NotNullWhen(true)] out UserCheckGuardianCreateRequest? value) =>
        _userCheckGuardianCreateRequestValue.TryGetValue(out value);

    public bool TryGetUserCheckUserSelfAssessmentCreateRequest([NotNullWhen(true)] out UserCheckUserSelfAssessmentCreateRequest? value) =>
        _userCheckUserSelfAssessmentCreateRequestValue.TryGetValue(out value);

    public bool TryGetUserCheckUsWithholdingTaxStatusCreateRequest([NotNullWhen(true)] out UserCheckUsWithholdingTaxStatusCreateRequest? value) =>
        _userCheckUsWithholdingTaxStatusCreateRequestValue.TryGetValue(out value);

    public bool TryGetUnknown(out JsonElement value) => _unknownValue.TryGetValue(out value);

    public static implicit operator UserCheckCreateRequest(UserCheckKnowYourCustomerCreateRequest value) =>
        UserCheckKnowYourCustomerCreateRequest(value);

    public static implicit operator UserCheckCreateRequest(UserCheckProofOfResidencyCreateRequest value) =>
        UserCheckProofOfResidencyCreateRequest(value);

    public static implicit operator UserCheckCreateRequest(UserCheckInstrumentFitCreateRequest value) =>
        UserCheckInstrumentFitCreateRequest(value);

    public static implicit operator UserCheckCreateRequest(UserCheckGuardianCreateRequest value) =>
        UserCheckGuardianCreateRequest(value);

    public static implicit operator UserCheckCreateRequest(UserCheckUserSelfAssessmentCreateRequest value) =>
        UserCheckUserSelfAssessmentCreateRequest(value);

    public static implicit operator UserCheckCreateRequest(UserCheckUsWithholdingTaxStatusCreateRequest value) =>
        UserCheckUsWithholdingTaxStatusCreateRequest(value);

    public TResult Match<TResult>(Func<UserCheckKnowYourCustomerCreateRequest, TResult> onUserCheckKnowYourCustomerCreateRequest,
        Func<UserCheckProofOfResidencyCreateRequest, TResult> onUserCheckProofOfResidencyCreateRequest,
        Func<UserCheckInstrumentFitCreateRequest, TResult> onUserCheckInstrumentFitCreateRequest,
        Func<UserCheckGuardianCreateRequest, TResult> onUserCheckGuardianCreateRequest,
        Func<UserCheckUserSelfAssessmentCreateRequest, TResult> onUserCheckUserSelfAssessmentCreateRequest,
        Func<UserCheckUsWithholdingTaxStatusCreateRequest, TResult> onUserCheckUsWithholdingTaxStatusCreateRequest,
        Func<JsonElement, TResult> otherwise) =>
        this switch
        {
            _ when TryGetUserCheckKnowYourCustomerCreateRequest(
                out var userCheckKnowYourCustomerCreateRequestValue) => onUserCheckKnowYourCustomerCreateRequest(
                userCheckKnowYourCustomerCreateRequestValue),
            _ when TryGetUserCheckProofOfResidencyCreateRequest(
                out var userCheckProofOfResidencyCreateRequestValue) => onUserCheckProofOfResidencyCreateRequest(
                userCheckProofOfResidencyCreateRequestValue),
            _ when TryGetUserCheckInstrumentFitCreateRequest(
                out var userCheckInstrumentFitCreateRequestValue) => onUserCheckInstrumentFitCreateRequest(
                userCheckInstrumentFitCreateRequestValue),
            _ when TryGetUserCheckGuardianCreateRequest(
                out var userCheckGuardianCreateRequestValue) => onUserCheckGuardianCreateRequest(
                userCheckGuardianCreateRequestValue),
            _ when TryGetUserCheckUserSelfAssessmentCreateRequest(
                out var userCheckUserSelfAssessmentCreateRequestValue) => onUserCheckUserSelfAssessmentCreateRequest(
                userCheckUserSelfAssessmentCreateRequestValue),
            _ when TryGetUserCheckUsWithholdingTaxStatusCreateRequest(
                out var userCheckUsWithholdingTaxStatusCreateRequestValue) => onUserCheckUsWithholdingTaxStatusCreateRequest(
                userCheckUsWithholdingTaxStatusCreateRequestValue),
            _ when TryGetUnknown(out var unknownValue) => otherwise(unknownValue),
            _ => throw new InvalidOperationException($"{nameof(UserCheckCreateRequest)} holds no value.")
        };

    public void Match(Action<UserCheckKnowYourCustomerCreateRequest> onUserCheckKnowYourCustomerCreateRequest,
        Action<UserCheckProofOfResidencyCreateRequest> onUserCheckProofOfResidencyCreateRequest,
        Action<UserCheckInstrumentFitCreateRequest> onUserCheckInstrumentFitCreateRequest,
        Action<UserCheckGuardianCreateRequest> onUserCheckGuardianCreateRequest,
        Action<UserCheckUserSelfAssessmentCreateRequest> onUserCheckUserSelfAssessmentCreateRequest,
        Action<UserCheckUsWithholdingTaxStatusCreateRequest> onUserCheckUsWithholdingTaxStatusCreateRequest,
        Action<JsonElement> otherwise)
    {
        if (TryGetUserCheckKnowYourCustomerCreateRequest(
            out var userCheckKnowYourCustomerCreateRequestValue)) onUserCheckKnowYourCustomerCreateRequest(
            userCheckKnowYourCustomerCreateRequestValue);
        else if (TryGetUserCheckProofOfResidencyCreateRequest(
            out var userCheckProofOfResidencyCreateRequestValue)) onUserCheckProofOfResidencyCreateRequest(
            userCheckProofOfResidencyCreateRequestValue);
        else if (TryGetUserCheckInstrumentFitCreateRequest(
            out var userCheckInstrumentFitCreateRequestValue)) onUserCheckInstrumentFitCreateRequest(
            userCheckInstrumentFitCreateRequestValue);
        else if (TryGetUserCheckGuardianCreateRequest(
            out var userCheckGuardianCreateRequestValue)) onUserCheckGuardianCreateRequest(
            userCheckGuardianCreateRequestValue);
        else if (TryGetUserCheckUserSelfAssessmentCreateRequest(
            out var userCheckUserSelfAssessmentCreateRequestValue)) onUserCheckUserSelfAssessmentCreateRequest(
            userCheckUserSelfAssessmentCreateRequestValue);
        else if (TryGetUserCheckUsWithholdingTaxStatusCreateRequest(
            out var userCheckUsWithholdingTaxStatusCreateRequestValue)) onUserCheckUsWithholdingTaxStatusCreateRequest(
            userCheckUsWithholdingTaxStatusCreateRequestValue);
        else if (TryGetUnknown(out var unknownValue)) otherwise(unknownValue);
        else throw new InvalidOperationException($"{nameof(UserCheckCreateRequest)} holds no value.");
    }
}

file sealed class UserCheckCreateRequestConverter : JsonConverter<UserCheckCreateRequest>
{
    public override UserCheckCreateRequest Read(ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options)
    {
        using var doc = JsonDocument.ParseValue(ref reader);
        var root = doc.RootElement;
        if (JsonSerializer.TryDeserialize<UserCheckKnowYourCustomerCreateRequest>(
            root,
            options,
            out var userCheckKnowYourCustomerCreateRequestValue))
        {
            return UserCheckCreateRequest.UserCheckKnowYourCustomerCreateRequest(
                userCheckKnowYourCustomerCreateRequestValue);
        }
        if (JsonSerializer.TryDeserialize<UserCheckProofOfResidencyCreateRequest>(
            root,
            options,
            out var userCheckProofOfResidencyCreateRequestValue))
        {
            return UserCheckCreateRequest.UserCheckProofOfResidencyCreateRequest(
                userCheckProofOfResidencyCreateRequestValue);
        }
        if (JsonSerializer.TryDeserialize<UserCheckInstrumentFitCreateRequest>(
            root,
            options,
            out var userCheckInstrumentFitCreateRequestValue))
        {
            return UserCheckCreateRequest.UserCheckInstrumentFitCreateRequest(userCheckInstrumentFitCreateRequestValue);
        }
        if (JsonSerializer.TryDeserialize<UserCheckGuardianCreateRequest>(
            root,
            options,
            out var userCheckGuardianCreateRequestValue))
        {
            return UserCheckCreateRequest.UserCheckGuardianCreateRequest(userCheckGuardianCreateRequestValue);
        }
        if (JsonSerializer.TryDeserialize<UserCheckUserSelfAssessmentCreateRequest>(
            root,
            options,
            out var userCheckUserSelfAssessmentCreateRequestValue))
        {
            return UserCheckCreateRequest.UserCheckUserSelfAssessmentCreateRequest(
                userCheckUserSelfAssessmentCreateRequestValue);
        }
        if (JsonSerializer.TryDeserialize<UserCheckUsWithholdingTaxStatusCreateRequest>(
            root,
            options,
            out var userCheckUsWithholdingTaxStatusCreateRequestValue))
        {
            return UserCheckCreateRequest.UserCheckUsWithholdingTaxStatusCreateRequest(
                userCheckUsWithholdingTaxStatusCreateRequestValue);
        }
        return UserCheckCreateRequest.Unknown(root);
    }

    public override void Write(Utf8JsonWriter writer, UserCheckCreateRequest value, JsonSerializerOptions options)
    {
        if (value.TryGetUserCheckKnowYourCustomerCreateRequest(out var userCheckKnowYourCustomerCreateRequestValue))
        {
            JsonSerializer.Serialize(writer, userCheckKnowYourCustomerCreateRequestValue, options);
        }
        else if (value.TryGetUserCheckProofOfResidencyCreateRequest(
            out var userCheckProofOfResidencyCreateRequestValue))
        {
            JsonSerializer.Serialize(writer, userCheckProofOfResidencyCreateRequestValue, options);
        }
        else if (value.TryGetUserCheckInstrumentFitCreateRequest(out var userCheckInstrumentFitCreateRequestValue))
        {
            JsonSerializer.Serialize(writer, userCheckInstrumentFitCreateRequestValue, options);
        }
        else if (value.TryGetUserCheckGuardianCreateRequest(out var userCheckGuardianCreateRequestValue))
        {
            JsonSerializer.Serialize(writer, userCheckGuardianCreateRequestValue, options);
        }
        else if (value.TryGetUserCheckUserSelfAssessmentCreateRequest(
            out var userCheckUserSelfAssessmentCreateRequestValue))
        {
            JsonSerializer.Serialize(writer, userCheckUserSelfAssessmentCreateRequestValue, options);
        }
        else if (value.TryGetUserCheckUsWithholdingTaxStatusCreateRequest(
            out var userCheckUsWithholdingTaxStatusCreateRequestValue))
        {
            JsonSerializer.Serialize(writer, userCheckUsWithholdingTaxStatusCreateRequestValue, options);
        }
        else if (value.TryGetUnknown(out var unknownValue))
        {
            unknownValue.WriteTo(writer);
        }
        else
        {
            throw new JsonException($"{nameof(UserCheckCreateRequest)} contains no valid value to serialize.");
        }
    }
}
