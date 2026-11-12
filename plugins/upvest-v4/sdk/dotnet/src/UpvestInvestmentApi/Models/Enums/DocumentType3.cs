using System;
using System.Text.Json.Serialization;
using UpvestInvestmentApi.Core.Enum;

namespace UpvestInvestmentApi.Models.Enums;

/// <summary>
/// The type of document used in the KYC process.
/// * PASSPORT - Passport
/// * ID_CARD - National Identification document
/// * RESIDENCE_PERMIT - Residence Permit
/// * DRIVING_LICENSE - Driving License
/// * TWO_PLUS_TWO_VERIFICATION_PROOF - Two plus two verification proof (for GB residence users only)
/// </summary>
[JsonConverter(typeof(StringEnumConverter<DocumentType3>))]
public sealed record DocumentType3 : OpenStringEnum<DocumentType3>
{
    private DocumentType3(string value) : base(value)
    {
    }

    public static readonly DocumentType3 Passport = new("PASSPORT");

    public static readonly DocumentType3 IdCard = new("ID_CARD");

    public static readonly DocumentType3 ResidencePermit = new("RESIDENCE_PERMIT");

    public static readonly DocumentType3 DrivingLicense = new("DRIVING_LICENSE");

    public static readonly DocumentType3 TwoPlusTwoVerificationProof = new("TWO_PLUS_TWO_VERIFICATION_PROOF");

    public TResult Match<TResult>(Func<TResult> onPassport,
        Func<TResult> onIdCard,
        Func<TResult> onResidencePermit,
        Func<TResult> onDrivingLicense,
        Func<TResult> onTwoPlusTwoVerificationProof,
        Func<string, TResult> otherwise) =>
        this switch
        {
            _ when this == Passport => onPassport(),
            _ when this == IdCard => onIdCard(),
            _ when this == ResidencePermit => onResidencePermit(),
            _ when this == DrivingLicense => onDrivingLicense(),
            _ when this == TwoPlusTwoVerificationProof => onTwoPlusTwoVerificationProof(),
            _ => otherwise(Value)
        };

    public void Match(Action onPassport,
        Action onIdCard,
        Action onResidencePermit,
        Action onDrivingLicense,
        Action onTwoPlusTwoVerificationProof,
        Action<string> otherwise)
    {
        if (this == Passport) onPassport();
        else if (this == IdCard) onIdCard();
        else if (this == ResidencePermit) onResidencePermit();
        else if (this == DrivingLicense) onDrivingLicense();
        else if (this == TwoPlusTwoVerificationProof) onTwoPlusTwoVerificationProof();
        else otherwise(Value);
    }
}
