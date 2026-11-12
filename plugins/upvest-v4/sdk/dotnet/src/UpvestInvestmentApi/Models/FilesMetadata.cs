using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace UpvestInvestmentApi.Models;

/// <summary>
/// The metadata of a file held for download, together with a signed URL for retrieving it.
/// </summary>
public record FilesMetadata
{
    /// <summary>
    /// Files metadata identifier.
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
    /// The one-time URL for downloading the file. The URL expires 15 minutes after it is issued.
    /// </summary>
    [JsonPropertyName("signed_url")]
    [MaxLength(1000)]
    public required string SignedUrl { get; init; }

    /// <summary>
    /// The name of the file.
    /// </summary>
    [JsonPropertyName("file_name")]
    [RegularExpression("^[a-z0-9-_\\.]{1,32}$")]
    public required string FileName { get; init; }

    /// <summary>
    /// The size of the file in bytes.
    /// </summary>
    [JsonPropertyName("content_length")]
    public required int ContentLength { get; init; }

    /// <summary>
    /// The checksum of the file's contents, as a hexadecimal string.
    /// </summary>
    [JsonPropertyName("checksum")]
    [RegularExpression("^[a-f0-9]{64}$")]
    public required string Checksum { get; init; }
}
