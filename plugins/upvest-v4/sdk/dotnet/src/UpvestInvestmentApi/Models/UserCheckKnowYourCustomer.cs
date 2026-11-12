using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using UpvestInvestmentApi.Core.Models;
using UpvestInvestmentApi.Models.Enums;

namespace UpvestInvestmentApi.Models;

/// <summary>
/// The KYC (Know your customer) check is completed by the client sharing the valid and relevant KYC data for the user.
/// </summary>
public record UserCheckKnowYourCustomer
{
    /// <summary>
    /// User Check unique identifier.
    /// </summary>
    [JsonPropertyName("id")]
    public required Guid Id { get; init; }

    /// <summary>
    /// Unique identifier of the user, as a UUID.
    /// </summary>
    [JsonPropertyName("user_id")]
    public required Guid UserId { get; init; }

    /// <summary>
    /// The type of check must be “KYC”.
    /// </summary>
    [JsonPropertyName("type")]
    public string Type { get; init; } = "KYC";

    /// <summary>
    /// Completion date and time of the KYC check. Must not be older than 24 months.
    /// </summary>
    [JsonPropertyName("check_confirmed_at")]
    public required DateTimeOffset CheckConfirmedAt { get; init; }

    /// <summary>
    /// Download URL for the KYC evidence file. The file size must not exceed 250 MB.
    /// </summary>
    [JsonPropertyName("data_download_link")]
    [MaxLength(1000)]
    public required string DataDownloadLink { get; init; }

    /// <summary>
    /// The type of document used in the KYC process.
    /// * PASSPORT - Passport
    /// * ID_CARD - National Identification document
    /// * RESIDENCE_PERMIT - Residence Permit
    /// * DRIVING_LICENSE - Driving License
    /// * TWO_PLUS_TWO_VERIFICATION_PROOF - Two plus two verification proof (for GB residence users only)
    /// </summary>
    [JsonPropertyName("document_type")]
    public required DocumentType3 DocumentType { get; init; }

    /// <summary>
    /// Expiration date of the document used in KYC process in YYYY-MM-DD format.
    /// <para>
    /// <b>The field is required for the following document types:</b>
    /// * PASSPORT
    /// * ID_CARD
    /// * RESIDENCE_PERMIT
    /// * DRIVING_LICENSE
    /// </para>
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("document_expiration_date")]
    [JsonConverter(typeof(UpvestInvestmentApi.Core.Converters.DateOnlyDateTimeOffsetConverter))]
    public DateTimeOffset? DocumentExpirationDate { get; init; }

    /// <summary>
    /// Issuing country of the document used in the KYC process. <see href="https://en.wikipedia.org/wiki/ISO_3166-1_alpha-2">ISO 3166 alpha-2 codes</see>.
    /// <para>
    /// <b>The field is required for the following document types:</b>
    /// * PASSPORT
    /// * ID_CARD
    /// * RESIDENCE_PERMIT
    /// * DRIVING_LICENSE
    /// </para>
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("nationality")]
    [RegularExpression("^[A-Z]{2}$")]
    public string? Nationality { get; init; }

    /// <summary>
    /// Final status of the KYC check.
    /// * IN_PROGRESS - KYC check is in progress
    /// * PASSED - KYC check passed
    /// * FAILED - KYC check failed
    /// </summary>
    [JsonPropertyName("status")]
    public required Status6 Status { get; init; }

    /// <summary>
    /// Provider that was used to perform the KYC check.
    /// </summary>
    [JsonPropertyName("provider")]
    [MaxLength(100)]
    public required string Provider { get; init; }

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
    [JsonPropertyName("method")]
    public required Method Method { get; init; }

    /// <summary>
    /// Address. Must not be a P.O. box or c/o address.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("confirmed_address")]
    public Address2? ConfirmedAddress { get; init; }

    /// <summary>
    /// Marks this check as a KYC refresh/update as opposed to an initial record.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("kyc_update")]
    public bool? KycUpdate { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
