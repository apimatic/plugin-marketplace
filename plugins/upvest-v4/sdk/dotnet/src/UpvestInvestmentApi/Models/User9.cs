using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using UpvestInvestmentApi.Core.Models;
using UpvestInvestmentApi.Models.Enums;

namespace UpvestInvestmentApi.Models;

/// <summary>
/// The end user that the report is addressed to.
/// </summary>
public record User9
{
    /// <summary>
    /// First name of the user.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("first_name")]
    [StringLength(100, MinimumLength = 2)]
    public string? FirstName { get; init; }

    /// <summary>
    /// Last name of the user.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("last_name")]
    [StringLength(100, MinimumLength = 2)]
    public string? LastName { get; init; }

    /// <summary>
    /// The salutation used for the end user in reports and statements.
    /// * SALUTATION_MALE — Herr.
    /// * SALUTATION_FEMALE — Frau.
    /// * SALUTATION_FEMALE_MARRIED — Frau, married form.
    /// * SALUTATION_DIVERSE — Gender-neutral salutation.
    /// <para>
    /// An empty string means no salutation is printed.
    /// </para>
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("salutation")]
    public Salutation10? Salutation { get; init; }

    /// <summary>
    /// The academic title used for the end user in reports and statements.
    /// * DR — Doctor.
    /// * PROF — Professor.
    /// * PROF_DR — Professor Doctor.
    /// * DIPL_ING — Graduate engineer (Diplom-Ingenieur).
    /// * MAGISTER — Magister.
    /// <para>
    /// An empty string means no title is printed.
    /// </para>
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("title")]
    public Title10? Title { get; init; }

    /// <summary>
    /// The residential address of the end user, as printed on the report.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("address")]
    public Address30? Address { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
