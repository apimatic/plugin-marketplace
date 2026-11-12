using System.Text.Json.Serialization;
using UpvestInvestmentApi.Core.Models;
using UpvestInvestmentApi.Models.Enums;

namespace UpvestInvestmentApi.Models;

/// <summary>
/// Offset/limit pagination metadata for a list response whose sort field and order are always returned.
/// </summary>
public record Meta28
{
    /// <summary>
    /// Amount of resource to offset in the response.
    /// </summary>
    [JsonPropertyName("offset")]
    public required int Offset { get; init; }

    /// <summary>
    /// Total limit of the response.
    /// </summary>
    [JsonPropertyName("limit")]
    public required int Limit { get; init; }

    /// <summary>
    /// Count of the resources returned in the response.
    /// </summary>
    [JsonPropertyName("count")]
    public required int Count { get; init; }

    /// <summary>
    /// Total count of all the resources.
    /// </summary>
    [JsonPropertyName("total_count")]
    public required int TotalCount { get; init; }

    /// <summary>
    /// The field that the list is sorted by.
    /// </summary>
    [JsonPropertyName("sort")]
    public required string Sort { get; init; }

    /// <summary>
    /// The ordering applied to the list.
    /// * ASC — Ascending order.
    /// * DESC — Descending order.
    /// </summary>
    [JsonPropertyName("order")]
    public required Order1 Order { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
