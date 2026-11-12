using System;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using UpvestInvestmentApi.Core.Extensions;
using UpvestInvestmentApi.Core.Models;

namespace UpvestInvestmentApi.Models.AnyOf;

/// <summary>
/// A check conducted for a user: KYC, proof of residence, instrument fit, compliance, guardian, or self-assessment.
/// </summary>
[JsonConverter(typeof(UserCheckConverter))]
public record UserCheck
{
    private readonly Optional<UserCheckKnowYourCustomer> _userCheckKnowYourCustomerValue;

    private readonly Optional<UserCheckProofOfResidency> _userCheckProofOfResidencyValue;

    private readonly Optional<UserCheckInstrumentFit> _userCheckInstrumentFitValue;

    private readonly Optional<UserCheckCompliance> _userCheckComplianceValue;

    private readonly Optional<UserCheckGuardian> _userCheckGuardianValue;

    private readonly Optional<UserCheckUsWithholdingTaxStatus> _userCheckUsWithholdingTaxStatusValue;

    private readonly Optional<UnknownArm> _unknownValue;

    private UserCheck(Optional<UserCheckKnowYourCustomer> userCheckKnowYourCustomerValue,
        Optional<UserCheckProofOfResidency> userCheckProofOfResidencyValue,
        Optional<UserCheckInstrumentFit> userCheckInstrumentFitValue,
        Optional<UserCheckCompliance> userCheckComplianceValue,
        Optional<UserCheckGuardian> userCheckGuardianValue,
        Optional<UserCheckUsWithholdingTaxStatus> userCheckUsWithholdingTaxStatusValue,
        Optional<UnknownArm> unknownValue)
    {
        _userCheckKnowYourCustomerValue = userCheckKnowYourCustomerValue;
        _userCheckProofOfResidencyValue = userCheckProofOfResidencyValue;
        _userCheckInstrumentFitValue = userCheckInstrumentFitValue;
        _userCheckComplianceValue = userCheckComplianceValue;
        _userCheckGuardianValue = userCheckGuardianValue;
        _userCheckUsWithholdingTaxStatusValue = userCheckUsWithholdingTaxStatusValue;
        _unknownValue = unknownValue;
    }

    public static UserCheck UserCheckKnowYourCustomer(UserCheckKnowYourCustomer value) =>
        new(Optional<UserCheckKnowYourCustomer>.Some(value), default, default, default, default, default, default);

    public static UserCheck UserCheckProofOfResidency(UserCheckProofOfResidency value) =>
        new(default, Optional<UserCheckProofOfResidency>.Some(value), default, default, default, default, default);

    public static UserCheck UserCheckInstrumentFit(UserCheckInstrumentFit value) =>
        new(default, default, Optional<UserCheckInstrumentFit>.Some(value), default, default, default, default);

    public static UserCheck UserCheckCompliance(UserCheckCompliance value) =>
        new(default, default, default, Optional<UserCheckCompliance>.Some(value), default, default, default);

    public static UserCheck UserCheckGuardian(UserCheckGuardian value) =>
        new(default, default, default, default, Optional<UserCheckGuardian>.Some(value), default, default);

    public static UserCheck UserCheckUsWithholdingTaxStatus(UserCheckUsWithholdingTaxStatus value) =>
        new(
            default,
            default,
            default,
            default,
            default,
            Optional<UserCheckUsWithholdingTaxStatus>.Some(value),
            default);

    internal static UserCheck Unknown(JsonElement value) =>
        new(default, default, default, default, default, default, Optional<UnknownArm>.Some(new UnknownArm(value)));

    public bool TryGetUserCheckKnowYourCustomer([NotNullWhen(true)] out UserCheckKnowYourCustomer? value) =>
        _userCheckKnowYourCustomerValue.TryGetValue(out value);

    public bool TryGetUserCheckProofOfResidency([NotNullWhen(true)] out UserCheckProofOfResidency? value) =>
        _userCheckProofOfResidencyValue.TryGetValue(out value);

    public bool TryGetUserCheckInstrumentFit([NotNullWhen(true)] out UserCheckInstrumentFit? value) =>
        _userCheckInstrumentFitValue.TryGetValue(out value);

    public bool TryGetUserCheckCompliance([NotNullWhen(true)] out UserCheckCompliance? value) =>
        _userCheckComplianceValue.TryGetValue(out value);

    public bool TryGetUserCheckGuardian([NotNullWhen(true)] out UserCheckGuardian? value) =>
        _userCheckGuardianValue.TryGetValue(out value);

    public bool TryGetUserCheckUsWithholdingTaxStatus([NotNullWhen(true)] out UserCheckUsWithholdingTaxStatus? value) =>
        _userCheckUsWithholdingTaxStatusValue.TryGetValue(out value);

    public bool TryGetUnknown(out JsonElement value) => _unknownValue.TryGetValue(out value);

    public static implicit operator UserCheck(UserCheckKnowYourCustomer value) => UserCheckKnowYourCustomer(value);

    public static implicit operator UserCheck(UserCheckProofOfResidency value) => UserCheckProofOfResidency(value);

    public static implicit operator UserCheck(UserCheckInstrumentFit value) => UserCheckInstrumentFit(value);

    public static implicit operator UserCheck(UserCheckCompliance value) => UserCheckCompliance(value);

    public static implicit operator UserCheck(UserCheckGuardian value) => UserCheckGuardian(value);

    public static implicit operator UserCheck(UserCheckUsWithholdingTaxStatus value) =>
        UserCheckUsWithholdingTaxStatus(value);

    public TResult Match<TResult>(Func<UserCheckKnowYourCustomer, TResult> onUserCheckKnowYourCustomer,
        Func<UserCheckProofOfResidency, TResult> onUserCheckProofOfResidency,
        Func<UserCheckInstrumentFit, TResult> onUserCheckInstrumentFit,
        Func<UserCheckCompliance, TResult> onUserCheckCompliance,
        Func<UserCheckGuardian, TResult> onUserCheckGuardian,
        Func<UserCheckUsWithholdingTaxStatus, TResult> onUserCheckUsWithholdingTaxStatus,
        Func<JsonElement, TResult> otherwise) =>
        this switch
        {
            _ when TryGetUserCheckKnowYourCustomer(
                out var userCheckKnowYourCustomerValue) => onUserCheckKnowYourCustomer(userCheckKnowYourCustomerValue),
            _ when TryGetUserCheckProofOfResidency(
                out var userCheckProofOfResidencyValue) => onUserCheckProofOfResidency(userCheckProofOfResidencyValue),
            _ when TryGetUserCheckInstrumentFit(out var userCheckInstrumentFitValue) => onUserCheckInstrumentFit(
                userCheckInstrumentFitValue),
            _ when TryGetUserCheckCompliance(out var userCheckComplianceValue) => onUserCheckCompliance(
                userCheckComplianceValue),
            _ when TryGetUserCheckGuardian(out var userCheckGuardianValue) => onUserCheckGuardian(
                userCheckGuardianValue),
            _ when TryGetUserCheckUsWithholdingTaxStatus(
                out var userCheckUsWithholdingTaxStatusValue) => onUserCheckUsWithholdingTaxStatus(
                userCheckUsWithholdingTaxStatusValue),
            _ when TryGetUnknown(out var unknownValue) => otherwise(unknownValue),
            _ => throw new InvalidOperationException($"{nameof(UserCheck)} holds no value.")
        };

    public void Match(Action<UserCheckKnowYourCustomer> onUserCheckKnowYourCustomer,
        Action<UserCheckProofOfResidency> onUserCheckProofOfResidency,
        Action<UserCheckInstrumentFit> onUserCheckInstrumentFit,
        Action<UserCheckCompliance> onUserCheckCompliance,
        Action<UserCheckGuardian> onUserCheckGuardian,
        Action<UserCheckUsWithholdingTaxStatus> onUserCheckUsWithholdingTaxStatus,
        Action<JsonElement> otherwise)
    {
        if (TryGetUserCheckKnowYourCustomer(out var userCheckKnowYourCustomerValue)) onUserCheckKnowYourCustomer(
            userCheckKnowYourCustomerValue);
        else if (TryGetUserCheckProofOfResidency(out var userCheckProofOfResidencyValue)) onUserCheckProofOfResidency(
            userCheckProofOfResidencyValue);
        else if (TryGetUserCheckInstrumentFit(out var userCheckInstrumentFitValue)) onUserCheckInstrumentFit(
            userCheckInstrumentFitValue);
        else if (TryGetUserCheckCompliance(out var userCheckComplianceValue)) onUserCheckCompliance(
            userCheckComplianceValue);
        else if (TryGetUserCheckGuardian(out var userCheckGuardianValue)) onUserCheckGuardian(userCheckGuardianValue);
        else if (TryGetUserCheckUsWithholdingTaxStatus(
            out var userCheckUsWithholdingTaxStatusValue)) onUserCheckUsWithholdingTaxStatus(
            userCheckUsWithholdingTaxStatusValue);
        else if (TryGetUnknown(out var unknownValue)) otherwise(unknownValue);
        else throw new InvalidOperationException($"{nameof(UserCheck)} holds no value.");
    }
}

file sealed class UserCheckConverter : JsonConverter<UserCheck>
{
    public override UserCheck Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        using var doc = JsonDocument.ParseValue(ref reader);
        var root = doc.RootElement;
        if (JsonSerializer.TryDeserialize<UserCheckKnowYourCustomer>(
            root,
            options,
            out var userCheckKnowYourCustomerValue))
        {
            return UserCheck.UserCheckKnowYourCustomer(userCheckKnowYourCustomerValue);
        }
        if (JsonSerializer.TryDeserialize<UserCheckProofOfResidency>(
            root,
            options,
            out var userCheckProofOfResidencyValue))
        {
            return UserCheck.UserCheckProofOfResidency(userCheckProofOfResidencyValue);
        }
        if (JsonSerializer.TryDeserialize<UserCheckInstrumentFit>(root, options, out var userCheckInstrumentFitValue))
        {
            return UserCheck.UserCheckInstrumentFit(userCheckInstrumentFitValue);
        }
        if (JsonSerializer.TryDeserialize<UserCheckCompliance>(root, options, out var userCheckComplianceValue))
        {
            return UserCheck.UserCheckCompliance(userCheckComplianceValue);
        }
        if (JsonSerializer.TryDeserialize<UserCheckGuardian>(root, options, out var userCheckGuardianValue))
        {
            return UserCheck.UserCheckGuardian(userCheckGuardianValue);
        }
        if (JsonSerializer.TryDeserialize<UserCheckUsWithholdingTaxStatus>(
            root,
            options,
            out var userCheckUsWithholdingTaxStatusValue))
        {
            return UserCheck.UserCheckUsWithholdingTaxStatus(userCheckUsWithholdingTaxStatusValue);
        }
        return UserCheck.Unknown(root);
    }

    public override void Write(Utf8JsonWriter writer, UserCheck value, JsonSerializerOptions options)
    {
        if (value.TryGetUserCheckKnowYourCustomer(out var userCheckKnowYourCustomerValue))
        {
            JsonSerializer.Serialize(writer, userCheckKnowYourCustomerValue, options);
        }
        else if (value.TryGetUserCheckProofOfResidency(out var userCheckProofOfResidencyValue))
        {
            JsonSerializer.Serialize(writer, userCheckProofOfResidencyValue, options);
        }
        else if (value.TryGetUserCheckInstrumentFit(out var userCheckInstrumentFitValue))
        {
            JsonSerializer.Serialize(writer, userCheckInstrumentFitValue, options);
        }
        else if (value.TryGetUserCheckCompliance(out var userCheckComplianceValue))
        {
            JsonSerializer.Serialize(writer, userCheckComplianceValue, options);
        }
        else if (value.TryGetUserCheckGuardian(out var userCheckGuardianValue))
        {
            JsonSerializer.Serialize(writer, userCheckGuardianValue, options);
        }
        else if (value.TryGetUserCheckUsWithholdingTaxStatus(out var userCheckUsWithholdingTaxStatusValue))
        {
            JsonSerializer.Serialize(writer, userCheckUsWithholdingTaxStatusValue, options);
        }
        else if (value.TryGetUnknown(out var unknownValue))
        {
            unknownValue.WriteTo(writer);
        }
        else
        {
            throw new JsonException($"{nameof(UserCheck)} contains no valid value to serialize.");
        }
    }
}
