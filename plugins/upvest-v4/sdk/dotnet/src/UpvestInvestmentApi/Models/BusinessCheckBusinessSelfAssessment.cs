using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using UpvestInvestmentApi.Core.Models;
using UpvestInvestmentApi.Models.Enums;

namespace UpvestInvestmentApi.Models;

/// <summary>
/// The Business Self Assessment check captures information about the business's activities, financials, and purpose of the business relationship for risk scoring.
/// </summary>
public record BusinessCheckBusinessSelfAssessment
{
    /// <summary>
    /// Business Check unique identifier.
    /// </summary>
    [JsonPropertyName("id")]
    public required Guid Id { get; init; }

    /// <summary>
    /// Unique identifier for the business.
    /// </summary>
    [JsonPropertyName("business_id")]
    public required Guid BusinessId { get; init; }

    /// <summary>
    /// The type of check must be "BUSINESS_SELF_ASSESSMENT".
    /// </summary>
    [JsonPropertyName("type")]
    public string Type { get; init; } = "BUSINESS_SELF_ASSESSMENT";

    /// <summary>
    /// The date and time when the self assessment check was confirmed.
    /// </summary>
    [JsonPropertyName("check_confirmed_at")]
    public required DateTimeOffset CheckConfirmedAt { get; init; }

    /// <summary>
    /// Final status of the business check.
    /// * IN_PROGRESS - Check is in progress
    /// * PASSED - Check passed
    /// * FAILED - Check failed
    /// </summary>
    [JsonPropertyName("status")]
    public required Status106 Status { get; init; }

    /// <summary>
    /// The business industry classification.
    /// </summary>
    [JsonPropertyName("business_industry")]
    public required BusinessIndustry BusinessIndustry { get; init; }

    /// <summary>
    /// The purpose of the business relationship.
    /// </summary>
    [JsonPropertyName("purpose_of_business_relationship")]
    public required PurposeOfBusinessRelationship PurposeOfBusinessRelationship { get; init; }

    /// <summary>
    /// List of primary countries where the business operates. ISO 3166-1 alpha-2 country codes.
    /// </summary>
    [JsonPropertyName("primary_countries_of_activity")]
    [MinLength(1)]
    public required IReadOnlyList<PrimaryCountriesOfActivity> PrimaryCountriesOfActivity { get; init; }

    /// <summary>
    /// A monetary range defined by a lower bound and an optional upper bound.
    /// </summary>
    [JsonPropertyName("annual_revenue")]
    public required MonetaryRange AnnualRevenue { get; init; }

    /// <summary>
    /// A monetary range defined by a lower bound and an optional upper bound.
    /// </summary>
    [JsonPropertyName("expected_volume_of_investment")]
    public required MonetaryRange ExpectedVolumeOfInvestment { get; init; }

    /// <summary>
    /// A monetary range defined by a lower bound and an optional upper bound.
    /// </summary>
    [JsonPropertyName("total_asset_value")]
    public required MonetaryRange TotalAssetValue { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
