using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using UpvestInvestmentApi.Core.Validation;
using UpvestInvestmentApi.Core.Validation.Attributes;
using UpvestInvestmentApi.Models.Enums;

namespace UpvestInvestmentApi.Models;

/// <summary>
/// A user onboarded under the Bring Your Own Licence (BYOL) operating model, where the client holds the regulatory licence.
/// </summary>
public record UserByol
{
    /// <summary>
    /// Unique identifier of the user, as a UUID.
    /// </summary>
    [JsonPropertyName("id")]
    public required Guid Id { get; init; }

    /// <summary>
    /// Date and time when the resource was created. <see href="https://datatracker.ietf.org/doc/html/rfc3339#section-5.6">RFC 3339-5</see>, <see href="https://www.iso.org/iso-8601-date-and-time-format.html">ISO8601 UTC</see>
    /// </summary>
    [JsonPropertyName("created_at")]
    public required DateTimeOffset CreatedAt { get; init; }

    /// <summary>
    /// Date and time when the resource was last updated. <see href="https://datatracker.ietf.org/doc/html/rfc3339#section-5.6">RFC 3339-5</see>, <see href="https://www.iso.org/iso-8601-date-and-time-format.html">ISO8601 UTC</see>
    /// </summary>
    [JsonPropertyName("updated_at")]
    public required DateTimeOffset UpdatedAt { get; init; }

    /// <summary>
    /// First name of the user. Provide any middle names in <c>middle_name</c>.
    /// </summary>
    [JsonPropertyName("first_name")]
    [StringLength(100, MinimumLength = 2)]
    public required string FirstName { get; init; }

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
    [JsonPropertyName("last_name")]
    [StringLength(100, MinimumLength = 1)]
    public required string LastName { get; init; }

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
    [JsonPropertyName("birth_date")]
    [JsonConverter(typeof(UpvestInvestmentApi.Core.Converters.DateOnlyDateTimeOffsetConverter))]
    public required DateTimeOffset BirthDate { get; init; }

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

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("decease_date")]
    public DateTimeOffset? DeceaseDate { get; init; }

    /// <summary>
    /// Nationalities of the user. <see href="https://en.wikipedia.org/wiki/ISO_3166-1_alpha-2">ISO 3166 alpha-2 Codes</see>.
    /// </summary>
    [JsonPropertyName("nationalities")]
    [MinLength(1)]
    public required IReadOnlyList<Nationality> Nationalities { get; init; }

    /// <summary>
    /// The end user's address.
    /// </summary>
    [JsonPropertyName("address")]
    public required Address Address { get; init; }

    /// <summary>
    /// User postal address. Needs to be specified if different to the residential address, otherwise it is automatically populated.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("postal_address")]
    public Address? PostalAddress { get; init; }

    /// <summary>
    /// Status of the user.
    /// * ACTIVE - The user is active.
    /// * INACTIVE - The user is deactivated, or is a new user who has not yet passed the onboarding checks. Using <c>INACTIVE</c> for new users is deprecated.
    /// * OFFBOARDING - Offboarding of the user has been initiated.
    /// * OFFBOARDED - The user has been offboarded.
    /// <para>
    /// In a future release, Upvest will create new users as <c>ACTIVE</c>, and <c>ACTIVE</c> will no longer mean that the user has passed the onboarding checks.
    /// </para>
    /// <para>
    /// Do not wait for the user to become <c>ACTIVE</c> before you create an account group. Upvest creates the user's role with the account group (for example, the <c>OWNER</c> role for a <c>PERSONAL</c> account group). Any checks that the user has already passed count towards that role. To know when the user has met the onboarding requirements for an account group or business, listen for the <c>ROLE.ACTIVATED</c> webhook event. The account group stays <c>PENDING_APPROVAL</c> until all its requirements are met, and the <c>ACCOUNT_GROUP.ACTIVATED</c> webhook event signals that it is <c>ACTIVE</c>.
    /// </para>
    /// </summary>
    [JsonPropertyName("status")]
    public required Status Status { get; init; }

    /// <summary>
    /// Email of the user. Must be a valid email address.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("email")]
    [MaxLength(100)]
    [Format(FormatKind.Email)]
    public string? Email { get; init; }

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
}
