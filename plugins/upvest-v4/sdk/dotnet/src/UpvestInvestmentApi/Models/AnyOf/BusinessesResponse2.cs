using System;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using UpvestInvestmentApi.Core.Extensions;
using UpvestInvestmentApi.Core.Models;

namespace UpvestInvestmentApi.Models.AnyOf;

/// <summary>
/// The requested business, either a company or a sole trader.
/// </summary>
[JsonConverter(typeof(BusinessesResponse2Converter))]
public record BusinessesResponse2
{
    private readonly Optional<BusinessesResponse> _businessesResponseValue;

    private readonly Optional<BusinessesResponse1> _businessesResponse1Value;

    private readonly Optional<UnknownArm> _unknownValue;

    private BusinessesResponse2(Optional<BusinessesResponse> businessesResponseValue,
        Optional<BusinessesResponse1> businessesResponse1Value,
        Optional<UnknownArm> unknownValue)
    {
        _businessesResponseValue = businessesResponseValue;
        _businessesResponse1Value = businessesResponse1Value;
        _unknownValue = unknownValue;
    }

    public static BusinessesResponse2 BusinessesResponse(BusinessesResponse value) =>
        new(Optional<BusinessesResponse>.Some(value), default, default);

    public static BusinessesResponse2 BusinessesResponse1(BusinessesResponse1 value) =>
        new(default, Optional<BusinessesResponse1>.Some(value), default);

    internal static BusinessesResponse2 Unknown(JsonElement value) =>
        new(default, default, Optional<UnknownArm>.Some(new UnknownArm(value)));

    public bool TryGetBusinessesResponse([NotNullWhen(true)] out BusinessesResponse? value) =>
        _businessesResponseValue.TryGetValue(out value);

    public bool TryGetBusinessesResponse1([NotNullWhen(true)] out BusinessesResponse1? value) =>
        _businessesResponse1Value.TryGetValue(out value);

    public bool TryGetUnknown(out JsonElement value) => _unknownValue.TryGetValue(out value);

    public static implicit operator BusinessesResponse2(BusinessesResponse value) => BusinessesResponse(value);

    public static implicit operator BusinessesResponse2(BusinessesResponse1 value) => BusinessesResponse1(value);

    public TResult Match<TResult>(Func<BusinessesResponse, TResult> onBusinessesResponse,
        Func<BusinessesResponse1, TResult> onBusinessesResponse1,
        Func<JsonElement, TResult> otherwise) =>
        this switch
        {
            _ when TryGetBusinessesResponse(out var businessesResponseValue) => onBusinessesResponse(
                businessesResponseValue),
            _ when TryGetBusinessesResponse1(out var businessesResponse1Value) => onBusinessesResponse1(
                businessesResponse1Value),
            _ when TryGetUnknown(out var unknownValue) => otherwise(unknownValue),
            _ => throw new InvalidOperationException($"{nameof(BusinessesResponse2)} holds no value.")
        };

    public void Match(Action<BusinessesResponse> onBusinessesResponse,
        Action<BusinessesResponse1> onBusinessesResponse1,
        Action<JsonElement> otherwise)
    {
        if (TryGetBusinessesResponse(out var businessesResponseValue)) onBusinessesResponse(businessesResponseValue);
        else if (TryGetBusinessesResponse1(out var businessesResponse1Value)) onBusinessesResponse1(
            businessesResponse1Value);
        else if (TryGetUnknown(out var unknownValue)) otherwise(unknownValue);
        else throw new InvalidOperationException($"{nameof(BusinessesResponse2)} holds no value.");
    }
}

file sealed class BusinessesResponse2Converter : JsonConverter<BusinessesResponse2>
{
    public override BusinessesResponse2 Read(ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options)
    {
        using var doc = JsonDocument.ParseValue(ref reader);
        var root = doc.RootElement;
        if (JsonSerializer.TryDeserialize<BusinessesResponse>(root, options, out var businessesResponseValue))
        {
            return BusinessesResponse2.BusinessesResponse(businessesResponseValue);
        }
        if (JsonSerializer.TryDeserialize<BusinessesResponse1>(root, options, out var businessesResponse1Value))
        {
            return BusinessesResponse2.BusinessesResponse1(businessesResponse1Value);
        }
        return BusinessesResponse2.Unknown(root);
    }

    public override void Write(Utf8JsonWriter writer, BusinessesResponse2 value, JsonSerializerOptions options)
    {
        if (value.TryGetBusinessesResponse(out var businessesResponseValue))
        {
            JsonSerializer.Serialize(writer, businessesResponseValue, options);
        }
        else if (value.TryGetBusinessesResponse1(out var businessesResponse1Value))
        {
            JsonSerializer.Serialize(writer, businessesResponse1Value, options);
        }
        else if (value.TryGetUnknown(out var unknownValue))
        {
            unknownValue.WriteTo(writer);
        }
        else
        {
            throw new JsonException($"{nameof(BusinessesResponse2)} contains no valid value to serialize.");
        }
    }
}
