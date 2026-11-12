using System;
using System.Text.Json.Serialization;
using UpvestInvestmentApi.Core.Enum;

namespace UpvestInvestmentApi.Models.Enums;

[JsonConverter(typeof(StringEnumConverter<Sort30>))]
public sealed record Sort30 : OpenStringEnum<Sort30>
{
    private Sort30(string value) : base(value)
    {
    }

    public static readonly Sort30 BookingDate = new("booking_date");

    public TResult Match<TResult>(Func<TResult> onBookingDate, Func<string, TResult> otherwise) =>
        this switch
        {
            _ when this == BookingDate => onBookingDate(),
            _ => otherwise(Value)
        };

    public void Match(Action onBookingDate, Action<string> otherwise)
    {
        if (this == BookingDate) onBookingDate();
        else otherwise(Value);
    }
}
