using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using UpvestInvestmentApi.Core.Models;
using UpvestInvestmentApi.Models.Enums;

namespace UpvestInvestmentApi.Models;

/// <summary>
/// The User Self-Assessment check is completed by the client providing self-assessment information about the user for AML risk monitoring.
/// </summary>
public record UserCheckUserSelfAssessmentCreateRequest
{
    /// <summary>
    /// The type of check must be "USER_SELF_ASSESSMENT".
    /// </summary>
    [JsonPropertyName("type")]
    public string Type { get; init; } = "USER_SELF_ASSESSMENT";

    /// <summary>
    /// The date and time when the self assessment information was provided by the end user.
    /// </summary>
    [JsonPropertyName("check_confirmed_at")]
    public required DateTimeOffset CheckConfirmedAt { get; init; }

    /// <summary>
    /// The user's employment/occupation status.
    /// </summary>
    [JsonPropertyName("user_occupation")]
    public required UserOccupation UserOccupation { get; init; }

    /// <summary>
    /// The industry the user is professionally active in.
    /// </summary>
    [JsonPropertyName("user_industry")]
    public required UserIndustry UserIndustry { get; init; }

    /// <summary>
    /// A monetary range defined by a lower bound and an optional upper bound.
    /// </summary>
    [JsonPropertyName("yearly_gross_income")]
    public required MonetaryRange YearlyGrossIncome { get; init; }

    /// <summary>
    /// The user's sources of income. More than one may apply.
    /// </summary>
    [JsonPropertyName("income_sources")]
    [MinLength(1)]
    public required IReadOnlyList<UserIncomeSource> IncomeSources { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
