using System;
using UpvestInvestmentApi.Models.AnyOf;
using UpvestInvestmentApi.Models.Enums;

namespace UpvestInvestmentApi.Requests.Reports;

/// <summary>
/// The inputs of the CreateReport operation.
/// </summary>
public sealed record CreateReportRequest
{
    /// <summary>
    /// Upvest API version (Note: Do not include quotation marks)
    /// </summary>
    public UpvestApiVersion UpvestApiVersion { get; init; } = UpvestApiVersion._1;

    /// <summary>
    /// Optional. A UUID to be used as an idempotency key.  A retry with the same key within 30 days returns the result of the first request instead of creating a duplicate.
    /// https://docs.upvest.co/documentation/concepts/api_concepts/idempotency
    /// </summary>
    public Guid? IdempotencyKey { get; init; }

    public ReportOrderExAnteCostCreateRequest? Body { get; init; }
}
