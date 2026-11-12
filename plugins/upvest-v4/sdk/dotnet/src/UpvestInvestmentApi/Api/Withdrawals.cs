using System;
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
using UpvestInvestmentApi.Requests.Withdrawals;

namespace UpvestInvestmentApi.Api;

/// <summary>
/// All withdrawals related paths
/// </summary>
public sealed class Withdrawals
{
    private readonly RawClient _rawClient;
    private readonly Server _server;
    private readonly AuthSchemes _auth;

    internal Withdrawals(RawClient rawClient, Server server, AuthSchemes auth)
    {
        _rawClient = rawClient;
        _server = server;
        _auth = auth;
    }

    /// <summary>
    /// Cancel withdrawal by ID
    /// </summary>
    /// <param name="request">The operation's inputs</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>A <see cref="Task"/> instance.</returns>
    /// <exception cref="ApiException{TError}"> of <see cref="CancelCashWithdrawalError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// Cancels a withdrawal specified by its ID. It is only possible to cancel a withdrawal if it has the status <c>NEW</c>.
    /// </remarks>
    public Task CancelCashWithdrawal(CancelCashWithdrawalRequest request,
        RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute(
            _server.Default("/payments/withdrawals/{withdrawal_id}"),
            [new TemplateParam("withdrawal_id", request.WithdrawalId)],
            [],
            [
                new HeaderParam("upvest-api-version", request.UpvestApiVersion),
                new HeaderParam("Idempotency-Key", Guid.NewGuid()),
            ],
            HttpMethod.Delete,
            EmptyBody.Instance,
            VoidResponse.Instance,
            CancelCashWithdrawalError.Response,
            _auth.OauthClientCredentials.ForScopes("payments:admin"),
            requestOptions,
            cancellationToken);

    /// <summary>
    /// Trigger a withdrawal
    /// </summary>
    /// <param name="request">The operation's inputs</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="PaymentsWithdrawal"/> instance.</returns>
    /// <exception cref="ApiException{TError}"> of <see cref="CreateCashWithdrawalError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// Trigger a withdrawal.
    /// <para>
    /// <b>Deprecation notice:</b> The <c>user_id</c> field is deprecated, optional, and will be removed in a future version. For business account withdrawals, ownership is determined by the reference account linked to the business.
    /// </para>
    /// </remarks>
    public Task<PaymentsWithdrawal> CreateCashWithdrawal(CreateCashWithdrawalRequest request,
        RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute(
            _server.Default("/payments/withdrawals"),
            [],
            [],
            [
                new HeaderParam("idempotency-key", request.IdempotencyKey),
                new HeaderParam("upvest-api-version", request.UpvestApiVersion),
            ],
            HttpMethod.Post,
            JsonRequest.Create(request.Body),
            JsonResponse.Create<PaymentsWithdrawal>(),
            CreateCashWithdrawalError.Response,
            _auth.OauthClientCredentials.ForScopes("payments:admin"),
            requestOptions,
            cancellationToken);

    /// <summary>
    /// List withdrawals
    /// </summary>
    /// <param name="request">The operation's inputs</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="WithdrawalsListResponse"/> instance.</returns>
    /// <exception cref="ApiException{TError}"> of <see cref="ListCashWithdrawalsError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// Returns a paginated list of cash withdrawals for the account group specified by its ID.
    /// </remarks>
    public Task<WithdrawalsListResponse> ListCashWithdrawals(ListCashWithdrawalsRequest request,
        RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute(
            _server.Default("/account_groups/{account_group_id}/payments/withdrawals"),
            [new TemplateParam("account_group_id", request.AccountGroupId)],
            [
                new Param("sort", request.Sort),
                new Param("order", request.Order),
                new Param("offset", request.Offset),
                new Param("limit", request.Limit),
            ],
            [new HeaderParam("upvest-api-version", request.UpvestApiVersion)],
            HttpMethod.Get,
            EmptyBody.Instance,
            JsonResponse.Create<WithdrawalsListResponse>(),
            ListCashWithdrawalsError.Response,
            _auth.OauthClientCredentials.ForScopes("payments:admin", "payments:read"),
            requestOptions,
            cancellationToken);

    /// <summary>
    /// Retrieve withdrawal
    /// </summary>
    /// <param name="request">The operation's inputs</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="PaymentsWithdrawal"/> instance.</returns>
    /// <exception cref="ApiException{TError}"> of <see cref="RetrieveCashWithdrawalError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// Returns the cash withdrawal specified by its ID, including its current status, amount, and reference account.
    /// </remarks>
    public Task<PaymentsWithdrawal> RetrieveCashWithdrawal(RetrieveCashWithdrawalRequest request,
        RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute(
            _server.Default("/payments/withdrawals/{withdrawal_id}"),
            [new TemplateParam("withdrawal_id", request.WithdrawalId)],
            [],
            [new HeaderParam("upvest-api-version", request.UpvestApiVersion)],
            HttpMethod.Get,
            EmptyBody.Instance,
            JsonResponse.Create<PaymentsWithdrawal>(),
            RetrieveCashWithdrawalError.Response,
            _auth.OauthClientCredentials.ForScopes("payments:admin", "payments:read"),
            requestOptions,
            cancellationToken);
}
