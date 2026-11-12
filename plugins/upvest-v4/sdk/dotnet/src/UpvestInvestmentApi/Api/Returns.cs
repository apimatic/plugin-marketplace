using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using UpvestInvestmentApi.Core;
using UpvestInvestmentApi.Core.Authentication;
using UpvestInvestmentApi.Core.Exceptions;
using UpvestInvestmentApi.Core.Models;
using UpvestInvestmentApi.Core.Request;
using UpvestInvestmentApi.Core.Response;
using UpvestInvestmentApi.Errors;
using UpvestInvestmentApi.Models;
using UpvestInvestmentApi.Requests.Returns;

namespace UpvestInvestmentApi.Api;

/// <summary>
/// All accounts returns related paths.
/// </summary>
public sealed class Returns
{
    private readonly RawClient _rawClient;
    private readonly Server _server;
    private readonly AuthSchemes _auth;

    internal Returns(RawClient rawClient, Server server, AuthSchemes auth)
    {
        _rawClient = rawClient;
        _server = server;
        _auth = auth;
    }

    /// <summary>
    /// List account returns
    /// </summary>
    /// <param name="request">The operation's inputs</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="AccountReturnListResponse"/> instance.</returns>
    /// <exception cref="ApiException{TError}"> of <see cref="ListAccountReturnsError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// Returns the account's daily time-weighted return (TWR), which measures investment performance independently of deposits, withdrawals, and other external cash flows.
    /// <para>
    /// Use the <c>offset</c> and <c>limit</c> query parameters to page through results; <c>meta.total_count</c> gives the total number of matching returns.
    /// </para>
    /// <para>
    /// See the Time-weighted returns guide (<see href="https://docs.upvest.co/products/tol/guides/reports/account_reports_time-weighted-returns">TOL</see> / <see href="https://docs.upvest.co/products/byol/guides/reports/account_reports_time-weighted-returns">BYOL</see>) for the calculation method.
    /// </para>
    /// </remarks>
    public Task<AccountReturnListResponse> ListAccountReturns(ListAccountReturnsRequest request,
        RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute(
            _server.Default("/accounts/{account_id}/returns"),
            [new TemplateParam("account_id", request.AccountId)],
            [
                new Param("start_date", request.StartDate),
                new Param("end_date", request.EndDate),
                new Param("sort", request.Sort),
                new Param("order", request.Order),
                new Param("offset", request.Offset),
                new Param("limit", request.Limit),
            ],
            [new HeaderParam("upvest-api-version", request.UpvestApiVersion)],
            HttpMethod.Get,
            EmptyBody.Instance,
            JsonResponse.Create<AccountReturnListResponse>(),
            ListAccountReturnsError.Response,
            _auth.OauthClientCredentials.ForScopes("account_returns:read"),
            requestOptions,
            cancellationToken);
}
