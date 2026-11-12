using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using UpvestInvestmentApi.Core;
using UpvestInvestmentApi.Core.Authentication;
using UpvestInvestmentApi.Core.Exceptions;
using UpvestInvestmentApi.Core.Extensions;
using UpvestInvestmentApi.Core.Models;
using UpvestInvestmentApi.Core.Request;
using UpvestInvestmentApi.Core.Response;
using UpvestInvestmentApi.Errors;
using UpvestInvestmentApi.Models;
using UpvestInvestmentApi.Models.AnyOf;
using UpvestInvestmentApi.Requests.Reports;

namespace UpvestInvestmentApi.Api;

/// <summary>
/// All reports related paths.
/// </summary>
public sealed class Reports
{
    private readonly RawClient _rawClient;
    private readonly Server _server;
    private readonly AuthSchemes _auth;

    internal Reports(RawClient rawClient, Server server, AuthSchemes auth)
    {
        _rawClient = rawClient;
        _server = server;
        _auth = auth;
    }

    /// <summary>
    /// Create a user report
    /// </summary>
    /// <param name="request">The operation's inputs</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="ReportOrderExAnteCost"/> instance.</returns>
    /// <exception cref="ApiException{TError}"> of <see cref="CreateReportError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// Creates a report from data the client submits, for either an end user or a business.
    /// <para>
    /// This is how clients supply the planned fee structure and order details that Upvest needs to produce a compliant MiFID II ex-ante cost report before an order is placed.
    /// </para>
    /// <para>
    /// See the ex-ante cost report data submission guide (<see href="https://docs.upvest.co/products/tol/guides/reports/ex-ante_reports_data">TOL</see> / <see href="https://docs.upvest.co/products/byol/guides/reports/ex-ante_reports_data">BYOL</see>) for the required fee and order data.
    /// </para>
    /// </remarks>
    public Task<ReportOrderExAnteCost> CreateReport(CreateReportRequest request,
        RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute(
            _server.Default("/reports"),
            [],
            [],
            [
                new HeaderParam("upvest-api-version", request.UpvestApiVersion),
                new HeaderParam("idempotency-key", request.IdempotencyKey),
            ],
            HttpMethod.Post,
            JsonRequest.Create(request.Body),
            JsonResponse.Create<ReportOrderExAnteCost>(),
            CreateReportError.Response,
            _auth.OauthClientCredentials.ForScopes("reports:admin"),
            requestOptions,
            cancellationToken);

    /// <summary>
    /// List business reports
    /// </summary>
    /// <param name="request">The operation's inputs</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="BusinessReportsListResponse"/> instance.</returns>
    /// <exception cref="ApiException{TError}"> of <see cref="ListBusinessReportsError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// Returns a paginated list of reports generated for the business identified by <c>business_id</c>.
    /// <para>
    /// Use the <c>offset</c> and <c>limit</c> query parameters to page through results; <c>meta.total_count</c> gives the total number of matching reports. Use <c>type</c> and <c>instrument</c> to filter results, and <c>start_date</c>/<c>end_date</c> to limit the range of report generation dates.
    /// </para>
    /// </remarks>
    public Task<BusinessReportsListResponse> ListBusinessReports(ListBusinessReportsRequest request,
        RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute(
            _server.Default("/businesses/{business_id}/reports"),
            [new TemplateParam("business_id", request.BusinessId)],
            [
                new Param("type", request.Type),
                new Param("instrument", request.Instrument),
                new Param("start_date", request.StartDate?.ToDate()),
                new Param("end_date", request.EndDate?.ToDate()),
                new Param("sort", request.Sort),
                new Param("order", request.Order),
                new Param("limit", request.Limit),
                new Param("offset", request.Offset),
            ],
            [new HeaderParam("upvest-api-version", request.UpvestApiVersion)],
            HttpMethod.Get,
            EmptyBody.Instance,
            JsonResponse.Create<BusinessReportsListResponse>(),
            ListBusinessReportsError.Response,
            _auth.OauthClientCredentials.ForScopes("reports:read", "reports:admin"),
            requestOptions,
            cancellationToken);

    /// <summary>
    /// List user reports
    /// </summary>
    /// <param name="request">The operation's inputs</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="ReportsListResponse"/> instance.</returns>
    /// <exception cref="ApiException{TError}"> of <see cref="ListUserReportsError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// Returns the list of reports generated for the end user identified by <c>user_id</c>.
    /// <para>
    /// Narrow the list with the <c>type</c>, <c>instrument</c>, <c>start_date</c>, and <c>end_date</c> query parameters, and page through results with <c>offset</c> and <c>limit</c>; <c>meta.total_count</c> gives the total number of matching reports. Subscribe to the <c>REPORT.CREATED</c> webhook event to be notified as reports are generated, rather than polling this endpoint.
    /// </para>
    /// <para>
    /// See the accessing end user reports guide (<see href="https://docs.upvest.co/products/tol/guides/reports/user_reports_access">TOL</see> / <see href="https://docs.upvest.co/products/byol/guides/reports/user_reports_access">BYOL</see>) for the available report types and query parameters.
    /// </para>
    /// </remarks>
    public Task<ReportsListResponse> ListUserReports(ListUserReportsRequest request,
        RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute(
            _server.Default("/users/{user_id}/reports"),
            [new TemplateParam("user_id", request.UserId)],
            [
                new Param("type", request.Type),
                new Param("instrument", request.Instrument),
                new Param("start_date", request.StartDate?.ToDate()),
                new Param("end_date", request.EndDate?.ToDate()),
                new Param("sort", request.Sort),
                new Param("order", request.Order),
                new Param("limit", request.Limit),
                new Param("offset", request.Offset),
            ],
            [new HeaderParam("upvest-api-version", request.UpvestApiVersion)],
            HttpMethod.Get,
            EmptyBody.Instance,
            JsonResponse.Create<ReportsListResponse>(),
            ListUserReportsError.Response,
            _auth.OauthClientCredentials.ForScopes("reports:read", "reports:admin"),
            requestOptions,
            cancellationToken);

    /// <summary>
    /// Retrieve a report
    /// </summary>
    /// <param name="request">The operation's inputs</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="Report"/> instance.</returns>
    /// <exception cref="ApiException{TError}"> of <see cref="RetrieveReportError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// Retrieve a report for either a natural person or a business entity.
    /// </remarks>
    public Task<Report> RetrieveReport(RetrieveReportRequest request,
        RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute(
            _server.Default("/reports/{report_id}"),
            [new TemplateParam("report_id", request.ReportId)],
            [],
            [
                new HeaderParam("upvest-api-version", request.UpvestApiVersion),
                new HeaderParam("accept", request.Accept),
            ],
            HttpMethod.Get,
            EmptyBody.Instance,
            JsonResponse.Create<Report>(),
            RetrieveReportError.Response,
            _auth.OauthClientCredentials.ForScopes("reports:read", "reports:admin"),
            requestOptions,
            cancellationToken);
}
