using System;
using System.Text.Json.Serialization;
using UpvestInvestmentApi.Core.Enum;

namespace UpvestInvestmentApi.Models.Enums;

/// <summary>
/// Reason why TIN is missing
/// * TIN_NOT_YET_ASSIGNED - Indicates that the tax identification number has not yet been assigned by the tax authorities. A common example is, that a user has moved to a country and thus became taxable, but that the tax authorities have not yet assigned the TIN to this user.
/// * COUNTRY_HAS_NO_TIN - Indicates that the specific country does not provide a TIN.
/// * OTHER_REASONS - Applies in case of other reasons - i.e. when a user does not have the TIN at hand. Note this may cause additional inquiries by our customer service team.
/// </summary>
[JsonConverter(typeof(StringEnumConverter<MissingTinReason>))]
public sealed record MissingTinReason : OpenStringEnum<MissingTinReason>
{
    private MissingTinReason(string value) : base(value)
    {
    }

    public static readonly MissingTinReason TinNotYetAssigned = new("TIN_NOT_YET_ASSIGNED");

    public static readonly MissingTinReason CountryHasNoTin = new("COUNTRY_HAS_NO_TIN");

    public static readonly MissingTinReason OtherReasons = new("OTHER_REASONS");

    public TResult Match<TResult>(Func<TResult> onTinNotYetAssigned,
        Func<TResult> onCountryHasNoTin,
        Func<TResult> onOtherReasons,
        Func<string, TResult> otherwise) =>
        this switch
        {
            _ when this == TinNotYetAssigned => onTinNotYetAssigned(),
            _ when this == CountryHasNoTin => onCountryHasNoTin(),
            _ when this == OtherReasons => onOtherReasons(),
            _ => otherwise(Value)
        };

    public void Match(Action onTinNotYetAssigned,
        Action onCountryHasNoTin,
        Action onOtherReasons,
        Action<string> otherwise)
    {
        if (this == TinNotYetAssigned) onTinNotYetAssigned();
        else if (this == CountryHasNoTin) onCountryHasNoTin();
        else if (this == OtherReasons) onOtherReasons();
        else otherwise(Value);
    }
}
