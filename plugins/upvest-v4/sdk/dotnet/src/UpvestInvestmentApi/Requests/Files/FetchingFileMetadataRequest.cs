using System.ComponentModel.DataAnnotations;
using UpvestInvestmentApi.Models.Enums;

namespace UpvestInvestmentApi.Requests.Files;

/// <summary>
/// The inputs of the FetchingFileMetadata operation.
/// </summary>
public sealed record FetchingFileMetadataRequest
{
    /// <summary>
    /// Folder containing the file. Must match the pattern <c>^[a-z0-9-_\.]{1,32}$</c>.
    /// </summary>
    [RegularExpression("^[a-z0-9-_\\.]{1,32}$")]
    public required string Folder { get; init; }

    /// <summary>
    /// Name of the file to retrieve. Must match the pattern <c>^[a-z0-9-_\.]{1,255}$</c>.
    /// </summary>
    [RegularExpression("^[a-z0-9-_\\.]{1,255}$")]
    public required string FileName { get; init; }

    /// <summary>
    /// To enable HTTP redirect.
    /// </summary>
    public string Redirect { get; init; } = "0";

    /// <summary>
    /// Upvest API version (Note: Do not include quotation marks)
    /// </summary>
    public UpvestApiVersion UpvestApiVersion { get; init; } = UpvestApiVersion._1;
}
