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
using UpvestInvestmentApi.Requests.Valuations;

namespace UpvestInvestmentApi.Api;

/// <summary>
/// All valuations related paths.
/// </summary>
public sealed class Valuations
{
    private readonly RawClient _rawClient;
    private readonly Server _server;
    private readonly AuthSchemes _auth;

    internal Valuations(RawClient rawClient, Server server, AuthSchemes auth)
    {
        _rawClient = rawClient;
        _server = server;
        _auth = auth;
    }

    /// <summary>
    /// Get current valuation for an account
    /// </summary>
    /// <param name="request">The operation's inputs</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="AccountValuation"/> instance.</returns>
    /// <exception cref="ApiException{TError}"> of <see cref="GetAccountValuationError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// Returns the account's current valuation, calculated from its current positions and the requested <c>price_quality</c>.
    /// <para>
    /// See the Account valuations guide (<see href="https://docs.upvest.co/products/tol/guides/positions/valuations">TOL</see> / <see href="https://docs.upvest.co/products/byol/guides/positions/valuations">BYOL</see>) for the difference between <c>EOD</c> and <c>HIGHEST_AVAILABLE</c> price quality.
    /// </para>
    /// </remarks>
    public Task<AccountValuation> GetAccountValuation(GetAccountValuationRequest request,
        RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute(
            _server.Default("/accounts/{account_id}/valuations/current"),
            [new TemplateParam("account_id", request.AccountId)],
            [new Param("price_quality", request.PriceQuality)],
            [new HeaderParam("upvest-api-version", request.UpvestApiVersion)],
            HttpMethod.Get,
            EmptyBody.Instance,
            JsonResponse.Create<AccountValuation>(),
            GetAccountValuationError.Response,
            _auth.OauthClientCredentials.ForScopes("valuations:read"),
            requestOptions,
            cancellationToken);

    /// <summary>
    /// List valuation history for an account
    /// </summary>
    /// <param name="request">The operation's inputs</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="AccountValuationListResponse"/> instance.</returns>
    /// <exception cref="ApiException{TError}"> of <see cref="ListAccountValuationHistoryError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// Returns the account's historical end-of-day valuations.
    /// <para>
    /// Use the <c>offset</c> and <c>limit</c> query parameters to page through results; <c>meta.total_count</c> gives the total number of matching valuations.
    /// </para>
    /// <para>
    /// See the Account valuations guide (<see href="https://docs.upvest.co/products/tol/guides/positions/valuations">TOL</see> / <see href="https://docs.upvest.co/products/byol/guides/positions/valuations">BYOL</see>) for how valuations are calculated.
    /// </para>
    /// </remarks>
    public Task<AccountValuationListResponse> ListAccountValuationHistory(ListAccountValuationHistoryRequest request,
        RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute(
            _server.Default("/accounts/{account_id}/valuations"),
            [new TemplateParam("account_id", request.AccountId)],
            [
                new Param("start_date", request.StartDate?.ToDate()),
                new Param("end_date", request.EndDate?.ToDate()),
                new Param("sort", request.Sort),
                new Param("order", request.Order),
                new Param("offset", request.Offset),
                new Param("limit", request.Limit),
            ],
            [new HeaderParam("upvest-api-version", request.UpvestApiVersion)],
            HttpMethod.Get,
            EmptyBody.Instance,
            JsonResponse.Create<AccountValuationListResponse>(),
            ListAccountValuationHistoryError.Response,
            _auth.OauthClientCredentials.ForScopes("valuations:read"),
            requestOptions,
            cancellationToken);
}
