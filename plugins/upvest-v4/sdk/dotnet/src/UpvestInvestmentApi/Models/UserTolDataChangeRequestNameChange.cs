using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using UpvestInvestmentApi.Core.Models;
using UpvestInvestmentApi.Models.Enums;

namespace UpvestInvestmentApi.Models;

public record UserTolDataChangeRequestNameChange
{
    /// <summary>
    /// First name of the user. Provide any middle names in <c>middle_name</c>.
    /// </summary>
    [JsonPropertyName("first_name")]
    [StringLength(100, MinimumLength = 2)]
    public required string FirstName { get; init; }

    /// <summary>
    /// Last name of the user.
    /// </summary>
    [JsonPropertyName("last_name")]
    [StringLength(100, MinimumLength = 1)]
    public required string LastName { get; init; }

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
    /// The type of document used to prove the data change
    /// * PASSPORT - Passport
    /// * ID_CARD - National Identification document
    /// </summary>
    [JsonPropertyName("document_type")]
    public required DocumentType DocumentType { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
