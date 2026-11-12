using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using UpvestInvestmentApi.Core.Models;
using UpvestInvestmentApi.Models.Enums;

namespace UpvestInvestmentApi.Models;

public record UserTolDataChangeRequestAddress
{
    /// <summary>
    /// Address. Must not be a P.O. box or c/o address.
    /// </summary>
    [JsonPropertyName("address")]
    public required Address2 Address { get; init; }

    /// <summary>
    /// Issuance date in YYYY-MM-DD format. <see href="https://json-schema.org/draft/2020-12/json-schema-validation.html#RFC3339">RFC 3339, section 5.6</see>
    /// </summary>
    [JsonPropertyName("issuance_date")]
    [JsonConverter(typeof(UpvestInvestmentApi.Core.Converters.DateOnlyDateTimeOffsetConverter))]
    public required DateTimeOffset IssuanceDate { get; init; }

    /// <summary>
    /// Download URL for the document proving the data change. The file size must not exceed 250 MB.
    /// </summary>
    [JsonPropertyName("data_download_link")]
    [MaxLength(1000)]
    public required string DataDownloadLink { get; init; }

    /// <summary>
    /// The type of document used to proof data change
    /// * UTILITY_BILL - Utility bill
    /// * TELEPHONE_BILL - Telephone bill
    /// * INTERNET_BILL - Internet bill
    /// * BANK_STATEMENT - Bank statement
    /// * REGISTRATION_CERT - Registration certificate
    /// * RESIDENCE_PERMIT - Residence permit
    /// * ID_CARD - National Identification document
    /// </summary>
    [JsonPropertyName("document_type")]
    public required DocumentType2 DocumentType { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
