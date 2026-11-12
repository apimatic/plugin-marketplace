using System.Text.Json.Serialization;
using UpvestInvestmentApi.Core.Models;
using UpvestInvestmentApi.Models.Enums;

namespace UpvestInvestmentApi.Models;

public record WithoutTaxIdentifierNumber
{
    /// <summary>
    /// Accepted country code. <see href="https://en.wikipedia.org/wiki/ISO_3166-1_alpha-2">ISO 3166-1 alpha-2 codes</see>.
    /// </summary>
    [JsonPropertyName("country")]
    public required Country Country { get; init; }

    /// <summary>
    /// Reason why TIN is missing
    /// * TIN_NOT_YET_ASSIGNED - Indicates that the tax identification number has not yet been assigned by the tax authorities. A common example is, that a user has moved to a country and thus became taxable, but that the tax authorities have not yet assigned the TIN to this user.
    /// * COUNTRY_HAS_NO_TIN - Indicates that the specific country does not provide a TIN.
    /// * OTHER_REASONS - Applies in case of other reasons - i.e. when a user does not have the TIN at hand. Note this may cause additional inquiries by our customer service team.
    /// </summary>
    [JsonPropertyName("missing_tin_reason")]
    public required MissingTinReason MissingTinReason { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
