using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using UpvestInvestmentApi.Models.AnyOf;

namespace UpvestInvestmentApi.Models;

/// <summary>
/// Request payload for setting a user's tax residencies. The submitted set replaces any previously recorded tax residencies.
/// </summary>
public record TaxResidenciesSetRequest
{
    /// <summary>
    /// Tax residencies to record for the user. Must contain at least one entry
    /// </summary>
    [JsonPropertyName("tax_residencies")]
    [MinLength(1)]
    public required IReadOnlyList<TaxResidencyForCreateRequest> TaxResidencies { get; init; }
}
