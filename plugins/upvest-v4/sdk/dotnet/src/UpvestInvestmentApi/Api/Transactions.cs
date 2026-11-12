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
using UpvestInvestmentApi.Requests.Transactions;

namespace UpvestInvestmentApi.Api;

/// <summary>
/// All transactions related paths.
/// </summary>
public sealed class Transactions
{
    private readonly RawClient _rawClient;
    private readonly Server _server;
    private readonly AuthSchemes _auth;

    internal Transactions(RawClient rawClient, Server server, AuthSchemes auth)
    {
        _rawClient = rawClient;
        _server = server;
        _auth = auth;
    }

    /// <summary>
    /// List cash transactions
    /// </summary>
    /// <param name="request">The operation's inputs</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="CashTransactionListResponse"/> instance.</returns>
    /// <exception cref="ApiException{TError}"> of <see cref="ListCashTransactionsError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// Returns the list of cash transactions for an account group.
    /// <para>
    /// Cash movements are recorded at account group level, so this endpoint is filtered by <c>account_group_id</c> rather than by account. Restrict the period with the <c>start_date</c> and <c>end_date</c> query parameters, and page through results with <c>offset</c> and <c>limit</c>; <c>meta.total_count</c> gives the total number of matching transactions.
    /// </para>
    /// <para>
    /// See the transactions reports guide (<see href="https://docs.upvest.co/products/tol/guides/reports/account_reports_transactions">TOL</see> / <see href="https://docs.upvest.co/products/byol/guides/reports/account_reports_transactions">BYOL</see> / <see href="https://docs.upvest.co/products/omnibus/guides/reports/account_reports_transactions">Omnibus</see>) for the full list of transaction types.
    /// </para>
    /// </remarks>
    public Task<CashTransactionListResponse> ListCashTransactions(ListCashTransactionsRequest request,
        RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute(
            _server.Default("/transactions/cash"),
            [],
            [
                new Param("account_group_id", request.AccountGroupId),
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
            JsonResponse.Create<CashTransactionListResponse>(),
            ListCashTransactionsError.Response,
            _auth.OauthClientCredentials.ForScopes("transactions:read"),
            requestOptions,
            cancellationToken);

    /// <summary>
    /// List securities transactions
    /// </summary>
    /// <param name="request">The operation's inputs</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="SecurityTransactionListResponse"/> instance.</returns>
    /// <exception cref="ApiException{TError}"> of <see cref="ListSecuritiesTransactionsError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// Returns the list of securities transactions for an account group or a single account.
    /// <para>
    /// Securities movements are recorded at account level, so this endpoint accepts both <c>account_group_id</c> and <c>account_id</c>. Restrict the period with the <c>start_date</c> and <c>end_date</c> query parameters, and page through results with <c>offset</c> and <c>limit</c>; <c>meta.total_count</c> gives the total number of matching transactions.
    /// </para>
    /// <para>
    /// See the transactions reports guide (<see href="https://docs.upvest.co/products/tol/guides/reports/account_reports_transactions">TOL</see> / <see href="https://docs.upvest.co/products/byol/guides/reports/account_reports_transactions">BYOL</see> / <see href="https://docs.upvest.co/products/omnibus/guides/reports/account_reports_transactions">Omnibus</see>) for the full list of transaction types.
    /// </para>
    /// </remarks>
    public Task<SecurityTransactionListResponse> ListSecuritiesTransactions(ListSecuritiesTransactionsRequest request,
        RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute(
            _server.Default("/transactions/securities"),
            [],
            [
                new Param("account_group_id", request.AccountGroupId),
                new Param("account_id", request.AccountId),
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
            JsonResponse.Create<SecurityTransactionListResponse>(),
            ListSecuritiesTransactionsError.Response,
            _auth.OauthClientCredentials.ForScopes("transactions:read"),
            requestOptions,
            cancellationToken);
}
