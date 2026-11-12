using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using UpvestInvestmentApi.Core.Models;
using UpvestInvestmentApi.Core.Validation;
using UpvestInvestmentApi.Core.Validation.Attributes;
using UpvestInvestmentApi.Models.Enums;

namespace UpvestInvestmentApi.Models;

/// <summary>
/// Request payload for changing the data of a BYOL user.
/// </summary>
public record UserByolDataChangeRequest
{
    /// <summary>
    /// First name of the user.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("first_name")]
    [StringLength(100, MinimumLength = 2)]
    public string? FirstName { get; init; }

    /// <summary>
    /// If applicable, middle name(s) of the user.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("middle_name")]
    [MaxLength(100)]
    public string? MiddleName { get; init; }

    /// <summary>
    /// Last name of the user.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("last_name")]
    [StringLength(100, MinimumLength = 2)]
    public string? LastName { get; init; }

    /// <summary>
    /// Email of the user. Must be a valid email address.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("email")]
    [MaxLength(100)]
    [Format(FormatKind.Email)]
    public string? Email { get; init; }

    /// <summary>
    /// Salutation of the user used in reports and statements.
    /// * (empty string) -
    /// * SALUTATION_MALE -
    /// * SALUTATION_FEMALE -
    /// * SALUTATION_FEMALE_MARRIED -
    /// * SALUTATION_DIVERSE -
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("salutation")]
    public Salutation? Salutation { get; init; }

    /// <summary>
    /// Title of the user used in reports and statements.
    /// * (empty string) -
    /// * DR - Doctor
    /// * PROF - Professor
    /// * PROF_DR -
    /// * DIPL_ING - Graduate engineer (Diplom-Ingenieur)
    /// * MAGISTER -
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("title")]
    public Title? Title { get; init; }

    /// <summary>
    /// Birth date of the user in YYYY-MM-DD format. <see href="https://json-schema.org/draft/2020-12/json-schema-validation.html#RFC3339">RFC 3339, section 5.6</see>
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("birth_date")]
    [JsonConverter(typeof(UpvestInvestmentApi.Core.Converters.DateOnlyDateTimeOffsetConverter))]
    public DateTimeOffset? BirthDate { get; init; }

    /// <summary>
    /// The name of a city, as it appears in a postal address.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("birth_city")]
    [StringLength(85, MinimumLength = 1)]
    public string? BirthCity { get; init; }

    /// <summary>
    /// Accepted country code. <see href="https://en.wikipedia.org/wiki/ISO_3166-1_alpha-2">ISO 3166-1 alpha-2 codes</see>.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("birth_country")]
    public BirthCountry? BirthCountry { get; init; }

    /// <summary>
    /// If applicable, birth name of the user.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("birth_name")]
    [MaxLength(100)]
    public string? BirthName { get; init; }

    /// <summary>
    /// The user's date of death in YYYY-MM-DD format. <see href="https://json-schema.org/draft/2020-12/json-schema-validation.html#RFC3339">RFC 3339, section 5.6</see>. Send an empty string to clear a decease date that was recorded in error.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("decease_date")]
    [RegularExpression("^$|^\\d{4}-(0[1-9]|1[012])-(0[1-9]|[12][0-9]|3[01])$")]
    public string? DeceaseDate { get; init; }

    /// <summary>
    /// Nationalities of the user. <see href="https://en.wikipedia.org/wiki/ISO_3166-1_alpha-2">ISO 3166 alpha-2 Codes</see>.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("nationalities")]
    [MinLength(1)]
    public IReadOnlyList<Nationality>? Nationalities { get; init; }

    /// <summary>
    /// The end user's address.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("address")]
    public Address? Address { get; init; }

    /// <summary>
    /// User postal address. Needs to be specified if different to the residential address, otherwise it is automatically populated.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("postal_address")]
    public Address? PostalAddress { get; init; }

    /// <summary>
    /// Unique identifier of the market the user is onboarded on. Only relevant if the client is operating in different markets and the client is configured accordingly
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("branch_id")]
    public Guid? BranchId { get; init; }

    /// <summary>
    /// Gender of the user. Required for users applying for the German pension government bonus.
    /// * (empty string) -
    /// * MALE -
    /// * FEMALE -
    /// * DIVERSE -
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("gender")]
    public Gender? Gender { get; init; }

    /// <summary>
    /// The user's assigned social security number (German social insurance number, e.g. <c>25300972S014</c>). Required for users applying for the German pension government bonus.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("social_security_number")]
    [RegularExpression("^(\\d{2}(0[1-9]|[12]\\d|3[01])(0[1-9]|1[0-2])\\d{2}[A-Z]\\d{3})?$")]
    public string? SocialSecurityNumber { get; init; }

    /// <summary>
    /// Labels applied to the user by the client. Omitted for users that have no tags.
    /// * CLIENT_EMPLOYEE - The user is an employee of the client.
    /// <para>
    /// Providing this field in a data change request replaces the full set of tags; send an empty array to remove all tags.
    /// </para>
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("tags")]
    [UniqueItems]
    public IReadOnlyList<Tag>? Tags { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
