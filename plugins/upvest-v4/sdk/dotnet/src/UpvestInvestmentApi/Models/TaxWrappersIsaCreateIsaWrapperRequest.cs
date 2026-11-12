using System;
using System.Text.Json.Serialization;

namespace UpvestInvestmentApi.Models;

/// <summary>
/// Request body for creating an ISA tax wrapper on an account group.
/// </summary>
public record TaxWrappersIsaCreateIsaWrapperRequest
{
    /// <summary>
    /// The ID of the account group to which the tax wrapper belongs.
    /// </summary>
    [JsonPropertyName("account_group_id")]
    public required Guid AccountGroupId { get; init; }

    /// <summary>
    /// The kind of ISA that the tax wrapper represents.
    /// * STOCKS_AND_SHARES_ISA — A Stocks and Shares ISA.
    /// </summary>
    [JsonPropertyName("type")]
    public string Type { get; } = "STOCKS_AND_SHARES_ISA";

    /// <summary>
    /// True if ISA is flexible.
    /// </summary>
    [JsonPropertyName("is_flexible")]
    public required bool IsFlexible { get; init; }
}
