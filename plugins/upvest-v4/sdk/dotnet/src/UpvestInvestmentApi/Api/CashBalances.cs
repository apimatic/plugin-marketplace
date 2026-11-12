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
using UpvestInvestmentApi.Requests.CashBalances;

namespace UpvestInvestmentApi.Api;

/// <summary>
/// All cash balance related paths
/// </summary>
public sealed class CashBalances
{
    private readonly RawClient _rawClient;
    private readonly Server _server;
    private readonly AuthSchemes _auth;

    internal CashBalances(RawClient rawClient, Server server, AuthSchemes auth)
    {
        _rawClient = rawClient;
        _server = server;
        _auth = auth;
    }

    /// <summary>
    /// Retrieve an account group's cash balance
    /// </summary>
    /// <param name="request">The operation's inputs</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="AccountGroupsPaymentsCashBalanceResponse"/> instance.</returns>
    /// <exception cref="ApiException{TError}"> of <see cref="RetrieveCashBalanceError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// <b>Deprecated.</b> Use <c>GET /account_groups/{account_group_id}/payments/cash_balances/{currency}</c> instead.
    /// <para>
    /// Returns the account group's cash balance.
    /// </para>
    /// </remarks>
    public Task<AccountGroupsPaymentsCashBalanceResponse> RetrieveCashBalance(RetrieveCashBalanceRequest request,
        RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute(
            _server.Default("/account_groups/{account_group_id}/payments/cash_balance"),
            [new TemplateParam("account_group_id", request.AccountGroupId)],
            [],
            [new HeaderParam("upvest-api-version", request.UpvestApiVersion)],
            HttpMethod.Get,
            EmptyBody.Instance,
            JsonResponse.Create<AccountGroupsPaymentsCashBalanceResponse>(),
            RetrieveCashBalanceError.Response,
            _auth.OauthClientCredentials.ForScopes("positions:read"),
            requestOptions,
            cancellationToken);

    /// <summary>
    /// Retrieve an account group's cash balance for particular ISO currency code
    /// </summary>
    /// <param name="request">The operation's inputs</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="AccountGroupsPaymentsCashBalancesResponse"/> instance.</returns>
    /// <exception cref="ApiException{TError}"> of <see cref="RetrieveCashBalanceWithCurrencyError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// Returns the account group's cash balance for the given <c>currency</c>.
    /// <para>
    /// See the Cash balances guide (<see href="https://docs.upvest.co/products/tol/guides/payments/cash_balances/cash_balances_retrieving">TOL</see> / <see href="https://docs.upvest.co/products/byol/guides/payments/cash_balances/cash_balances_retrieving">BYOL</see>) for implementation details.
    /// </para>
    /// </remarks>
    public Task<AccountGroupsPaymentsCashBalancesResponse> RetrieveCashBalanceWithCurrency(RetrieveCashBalanceWithCurrencyRequest request,
        RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute(
            _server.Default("/account_groups/{account_group_id}/payments/cash_balances/{currency}"),
            [
                new TemplateParam("account_group_id", request.AccountGroupId),
                new TemplateParam("currency", request.Currency),
            ],
            [],
            [new HeaderParam("upvest-api-version", request.UpvestApiVersion)],
            HttpMethod.Get,
            EmptyBody.Instance,
            JsonResponse.Create<AccountGroupsPaymentsCashBalancesResponse>(),
            RetrieveCashBalanceWithCurrencyError.Response,
            _auth.OauthClientCredentials.ForScopes("positions:read"),
            requestOptions,
            cancellationToken);

    /// <summary>
    /// Retrieve an account group's cash balances
    /// </summary>
    /// <param name="request">The operation's inputs</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="CashBalancesRetrieveResponse"/> instance.</returns>
    /// <exception cref="ApiException{TError}"> of <see cref="RetrieveCashBalancesError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// Returns the list of cash balances held by the account group.
    /// <para>
    /// See the Cash balances guide (<see href="https://docs.upvest.co/products/tol/guides/payments/cash_balances/cash_balances_intro">TOL</see> / <see href="https://docs.upvest.co/products/byol/guides/payments/cash_balances/cash_balances_intro">BYOL</see>) for how <c>balance</c>, <c>locked_for_trading</c>, <c>pending_settlement</c>, <c>available_for_withdrawal</c>, and <c>available_for_trading</c> relate to each other.
    /// </para>
    /// </remarks>
    public Task<CashBalancesRetrieveResponse> RetrieveCashBalances(RetrieveCashBalancesRequest request,
        RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute(
            _server.Default("/account_groups/{account_group_id}/payments/cash_balances"),
            [new TemplateParam("account_group_id", request.AccountGroupId)],
            [],
            [new HeaderParam("upvest-api-version", request.UpvestApiVersion)],
            HttpMethod.Get,
            EmptyBody.Instance,
            JsonResponse.Create<CashBalancesRetrieveResponse>(),
            RetrieveCashBalancesError.Response,
            _auth.OauthClientCredentials.ForScopes("positions:read"),
            requestOptions,
            cancellationToken);
}
