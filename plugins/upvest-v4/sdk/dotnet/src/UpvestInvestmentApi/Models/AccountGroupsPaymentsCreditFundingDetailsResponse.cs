using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace UpvestInvestmentApi.Models;

/// <summary>
/// Virtual bank account details for funding an account group via SEPA Credit Transfer. Each entry includes an IBAN, BIC, and <c>remittance_information</c> the end user must include in their bank transfer.
/// </summary>
public record AccountGroupsPaymentsCreditFundingDetailsResponse
{
    /// <summary>
    /// Offset/limit pagination metadata for a list response. Contains the <c>offset</c> and <c>limit</c> applied to the request, the <c>count</c> of resources returned in this page, and the <c>total_count</c> of matching resources.
    /// </summary>
    [JsonPropertyName("meta")]
    public required Meta Meta { get; init; }

    [JsonPropertyName("data")]
    public required IReadOnlyList<Datum4> Data { get; init; }
}
