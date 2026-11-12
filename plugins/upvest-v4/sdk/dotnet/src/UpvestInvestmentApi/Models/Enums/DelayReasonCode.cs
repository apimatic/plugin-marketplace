using System;
using System.Text.Json.Serialization;
using UpvestInvestmentApi.Core.Enum;

namespace UpvestInvestmentApi.Models.Enums;

/// <summary>
/// Categorised reason why a securities transfer is delayed past the regulatory deadline.
/// * <c>COUNTERPARTY_NOT_INSTRUCTING</c> - The counterparty has not yet instructed the transfer.
/// * <c>COUNTERPARTY_NOT_RESPONDING</c> - The counterparty is not responding.
/// * <c>COUNTERPARTY_DOES_NOT_AGREE_TO_DELIVERY_DETAILS</c> - The counterparty does not agree to the delivery details.
/// * <c>COUNTERPARTY_NOT_ACCEPTING</c> - The counterparty is not accepting the transfer.
/// </summary>
[JsonConverter(typeof(StringEnumConverter<DelayReasonCode>))]
public sealed record DelayReasonCode : OpenStringEnum<DelayReasonCode>
{
    private DelayReasonCode(string value) : base(value)
    {
    }

    public static readonly DelayReasonCode CounterpartyNotInstructing = new("COUNTERPARTY_NOT_INSTRUCTING");

    public static readonly DelayReasonCode CounterpartyNotResponding = new("COUNTERPARTY_NOT_RESPONDING");

    public static readonly DelayReasonCode CounterpartyDoesNotAgreeToDeliveryDetails = new(
        "COUNTERPARTY_DOES_NOT_AGREE_TO_DELIVERY_DETAILS");

    public static readonly DelayReasonCode CounterpartyNotAccepting = new("COUNTERPARTY_NOT_ACCEPTING");

    public TResult Match<TResult>(Func<TResult> onCounterpartyNotInstructing,
        Func<TResult> onCounterpartyNotResponding,
        Func<TResult> onCounterpartyDoesNotAgreeToDeliveryDetails,
        Func<TResult> onCounterpartyNotAccepting,
        Func<string, TResult> otherwise) =>
        this switch
        {
            _ when this == CounterpartyNotInstructing => onCounterpartyNotInstructing(),
            _ when this == CounterpartyNotResponding => onCounterpartyNotResponding(),
            _ when this == CounterpartyDoesNotAgreeToDeliveryDetails => onCounterpartyDoesNotAgreeToDeliveryDetails(),
            _ when this == CounterpartyNotAccepting => onCounterpartyNotAccepting(),
            _ => otherwise(Value)
        };

    public void Match(Action onCounterpartyNotInstructing,
        Action onCounterpartyNotResponding,
        Action onCounterpartyDoesNotAgreeToDeliveryDetails,
        Action onCounterpartyNotAccepting,
        Action<string> otherwise)
    {
        if (this == CounterpartyNotInstructing) onCounterpartyNotInstructing();
        else if (this == CounterpartyNotResponding) onCounterpartyNotResponding();
        else if (this == CounterpartyDoesNotAgreeToDeliveryDetails) onCounterpartyDoesNotAgreeToDeliveryDetails();
        else if (this == CounterpartyNotAccepting) onCounterpartyNotAccepting();
        else otherwise(Value);
    }
}
