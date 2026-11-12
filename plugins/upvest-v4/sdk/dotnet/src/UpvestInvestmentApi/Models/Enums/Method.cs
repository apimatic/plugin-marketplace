using System;
using System.Text.Json.Serialization;
using UpvestInvestmentApi.Core.Enum;

namespace UpvestInvestmentApi.Models.Enums;

/// <summary>
/// Method used for AML-compliant KYC process
/// * VIDEO_ID - Video identification
/// * IN_PERSON_ID - In-person identification at the post office or the client's outlet
/// * ELECTRONIC_ID - Advanced electronic identification methods (namely German eID)
/// * LIVENESS_PHOTO_ID - Photos and security features of the identification document in combination with a video-based liveness check (residence country must not be Germany in this case)
/// * QUALIFIED_ELECTRONIC_SIGNATURE_WITH_TX - Qualified electronic signature accompanied by a bank transaction for verification
/// * TWO_PLUS_TWO_VERIFICATION - A method of verifying identity by matching at least two personal details from two separate sources (for GB residence users only)
/// * ID_COLLECTION - The identification document of the user is collected but has not undergone verification
/// </summary>
[JsonConverter(typeof(StringEnumConverter<Method>))]
public sealed record Method : OpenStringEnum<Method>
{
    private Method(string value) : base(value)
    {
    }

    public static readonly Method VideoId = new("VIDEO_ID");

    public static readonly Method InPersonId = new("IN_PERSON_ID");

    public static readonly Method ElectronicId = new("ELECTRONIC_ID");

    public static readonly Method LivenessPhotoId = new("LIVENESS_PHOTO_ID");

    public static readonly Method QualifiedElectronicSignatureWithTx = new("QUALIFIED_ELECTRONIC_SIGNATURE_WITH_TX");

    public static readonly Method TwoPlusTwoVerification = new("TWO_PLUS_TWO_VERIFICATION");

    public static readonly Method IdCollection = new("ID_COLLECTION");

    public TResult Match<TResult>(Func<TResult> onVideoId,
        Func<TResult> onInPersonId,
        Func<TResult> onElectronicId,
        Func<TResult> onLivenessPhotoId,
        Func<TResult> onQualifiedElectronicSignatureWithTx,
        Func<TResult> onTwoPlusTwoVerification,
        Func<TResult> onIdCollection,
        Func<string, TResult> otherwise) =>
        this switch
        {
            _ when this == VideoId => onVideoId(),
            _ when this == InPersonId => onInPersonId(),
            _ when this == ElectronicId => onElectronicId(),
            _ when this == LivenessPhotoId => onLivenessPhotoId(),
            _ when this == QualifiedElectronicSignatureWithTx => onQualifiedElectronicSignatureWithTx(),
            _ when this == TwoPlusTwoVerification => onTwoPlusTwoVerification(),
            _ when this == IdCollection => onIdCollection(),
            _ => otherwise(Value)
        };

    public void Match(Action onVideoId,
        Action onInPersonId,
        Action onElectronicId,
        Action onLivenessPhotoId,
        Action onQualifiedElectronicSignatureWithTx,
        Action onTwoPlusTwoVerification,
        Action onIdCollection,
        Action<string> otherwise)
    {
        if (this == VideoId) onVideoId();
        else if (this == InPersonId) onInPersonId();
        else if (this == ElectronicId) onElectronicId();
        else if (this == LivenessPhotoId) onLivenessPhotoId();
        else if (this == QualifiedElectronicSignatureWithTx) onQualifiedElectronicSignatureWithTx();
        else if (this == TwoPlusTwoVerification) onTwoPlusTwoVerification();
        else if (this == IdCollection) onIdCollection();
        else otherwise(Value);
    }
}
