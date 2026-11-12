using System;
using UpvestInvestmentApi.Models.Enums;

namespace UpvestInvestmentApi.Requests.Reports;

/// <summary>
/// The inputs of the RetrieveReport operation.
/// </summary>
public sealed record RetrieveReportRequest
{
    /// <summary>
    /// The unique identifier of the report. Universally Unique Identifier (UUID).
    /// </summary>
    public required Guid ReportId { get; init; }

    /// <summary>
    /// Upvest API version (Note: Do not include quotation marks)
    /// </summary>
    public UpvestApiVersion UpvestApiVersion { get; init; } = UpvestApiVersion._1;

    /// <summary>
    /// Report format
    /// </summary>
    public Accept Accept { get; init; } = Accept.ApplicationJson;
}
