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
using UpvestInvestmentApi.Requests.CashBalanceTransfers;

namespace UpvestInvestmentApi.Api;

/// <summary>
/// All cash balance transfer related paths
/// </summary>
public sealed class CashBalanceTransfers
{
    private readonly RawClient _rawClient;
    private readonly Server _server;
    private readonly AuthSchemes _auth;

    internal CashBalanceTransfers(RawClient rawClient, Server server, AuthSchemes auth)
    {
        _rawClient = rawClient;
        _server = server;
        _auth = auth;
    }

    /// <summary>
    /// Cancel cash balance transfer by ID
    /// </summary>
    /// <param name="request">The operation's inputs</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>A <see cref="Task"/> instance.</returns>
    /// <exception cref="ApiException{TError}"> of <see cref="CancelCashBalanceTransferError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// Cancels a cash balance transfer specified by its ID. It is only possible to cancel a transfer while it has the status <c>ISSUED</c>.
    /// </remarks>
    public Task CancelCashBalanceTransfer(CancelCashBalanceTransferRequest request,
        RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute(
            _server.Default("/payments/cash_balance_transfers/{cash_balance_transfer_id}"),
            [new TemplateParam("cash_balance_transfer_id", request.CashBalanceTransferId)],
            [],
            [
                new HeaderParam("upvest-api-version", request.UpvestApiVersion),
                new HeaderParam("Idempotency-Key", Guid.NewGuid()),
            ],
            HttpMethod.Delete,
            EmptyBody.Instance,
            VoidResponse.Instance,
            CancelCashBalanceTransferError.Response,
            _auth.OauthClientCredentials.ForScopes("cash_balance_transfers:admin"),
            requestOptions,
            cancellationToken);

    /// <summary>
    /// Create a cash balance transfer
    /// </summary>
    /// <param name="request">The operation's inputs</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="PaymentsCashBalanceTransfer"/> instance.</returns>
    /// <exception cref="ApiException{TError}"> of <see cref="CreateCashBalanceTransferError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// Create an internal cash balance transfer between two account groups belonging to the same tenant. The cash leaves the source account group and arrives at the target account group as a single operation, with no external bank transfer. Only settled cash denominated in the same currency (EUR) can be transferred. Both account groups must be of the same type, and the type must be one of <c>PERSONAL</c>, <c>CHILD</c>, <c>BUSINESS</c>, or <c>JOINT</c>. Both account groups must have exactly the same owners: for a <c>JOINT</c> account group, the same two owners must hold both.
    /// </remarks>
    public Task<PaymentsCashBalanceTransfer> CreateCashBalanceTransfer(CreateCashBalanceTransferRequest request,
        RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute(
            _server.Default("/payments/cash_balance_transfers"),
            [],
            [],
            [
                new HeaderParam("idempotency-key", request.IdempotencyKey),
                new HeaderParam("upvest-api-version", request.UpvestApiVersion),
            ],
            HttpMethod.Post,
            JsonRequest.Create(request.Body),
            JsonResponse.Create<PaymentsCashBalanceTransfer>(),
            CreateCashBalanceTransferError.Response,
            _auth.OauthClientCredentials.ForScopes("cash_balance_transfers:admin"),
            requestOptions,
            cancellationToken);

    /// <summary>
    /// List cash balance transfers of a business
    /// </summary>
    /// <param name="request">The operation's inputs</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="BusinessCashBalanceTransfersListResponse"/> instance.</returns>
    /// <exception cref="ApiException{TError}"> of <see cref="ListBusinessCashBalanceTransfersError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// Returns the list of cash balance transfers of a business specified by ID.
    /// </remarks>
    public Task<BusinessCashBalanceTransfersListResponse> ListBusinessCashBalanceTransfers(ListBusinessCashBalanceTransfersRequest request,
        RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute(
            _server.Default("/businesses/{business_id}/payments/cash_balance_transfers"),
            [new TemplateParam("business_id", request.BusinessId)],
            [
                new Param("sort", request.Sort),
                new Param("order", request.Order),
                new Param("offset", request.Offset),
                new Param("limit", request.Limit),
            ],
            [new HeaderParam("upvest-api-version", request.UpvestApiVersion)],
            HttpMethod.Get,
            EmptyBody.Instance,
            JsonResponse.Create<BusinessCashBalanceTransfersListResponse>(),
            ListBusinessCashBalanceTransfersError.Response,
            _auth.OauthClientCredentials.ForScopes("cash_balance_transfers:admin", "cash_balance_transfers:read"),
            requestOptions,
            cancellationToken);

    /// <summary>
    /// List cash balance transfers
    /// </summary>
    /// <param name="request">The operation's inputs</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="CashBalanceTransfersListResponse"/> instance.</returns>
    /// <exception cref="ApiException{TError}"> of <see cref="ListCashBalanceTransfersError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// Returns a paginated list of all cash balance transfers initiated by the client, across all account groups and users.
    /// </remarks>
    public Task<CashBalanceTransfersListResponse> ListCashBalanceTransfers(ListCashBalanceTransfersRequest request,
        RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute(
            _server.Default("/payments/cash_balance_transfers"),
            [],
            [
                new Param("sort", request.Sort),
                new Param("order", request.Order),
                new Param("offset", request.Offset),
                new Param("limit", request.Limit),
            ],
            [new HeaderParam("upvest-api-version", request.UpvestApiVersion)],
            HttpMethod.Get,
            EmptyBody.Instance,
            JsonResponse.Create<CashBalanceTransfersListResponse>(),
            ListCashBalanceTransfersError.Response,
            _auth.OauthClientCredentials.ForScopes("cash_balance_transfers:admin", "cash_balance_transfers:read"),
            requestOptions,
            cancellationToken);

    /// <summary>
    /// List cash balance transfers of a user
    /// </summary>
    /// <param name="request">The operation's inputs</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="UserCashBalanceTransfersListResponse"/> instance.</returns>
    /// <exception cref="ApiException{TError}"> of <see cref="ListUserCashBalanceTransfersError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// Returns the list of cash balance transfers of a user specified by ID.
    /// </remarks>
    public Task<UserCashBalanceTransfersListResponse> ListUserCashBalanceTransfers(ListUserCashBalanceTransfersRequest request,
        RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute(
            _server.Default("/users/{user_id}/payments/cash_balance_transfers"),
            [new TemplateParam("user_id", request.UserId)],
            [
                new Param("sort", request.Sort),
                new Param("order", request.Order),
                new Param("offset", request.Offset),
                new Param("limit", request.Limit),
            ],
            [new HeaderParam("upvest-api-version", request.UpvestApiVersion)],
            HttpMethod.Get,
            EmptyBody.Instance,
            JsonResponse.Create<UserCashBalanceTransfersListResponse>(),
            ListUserCashBalanceTransfersError.Response,
            _auth.OauthClientCredentials.ForScopes("cash_balance_transfers:admin", "cash_balance_transfers:read"),
            requestOptions,
            cancellationToken);

    /// <summary>
    /// Retrieve cash balance transfer
    /// </summary>
    /// <param name="request">The operation's inputs</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="PaymentsCashBalanceTransfer"/> instance.</returns>
    /// <exception cref="ApiException{TError}"> of <see cref="RetrieveCashBalanceTransferError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// Retrieve a cash balance transfer by its ID.
    /// </remarks>
    public Task<PaymentsCashBalanceTransfer> RetrieveCashBalanceTransfer(RetrieveCashBalanceTransferRequest request,
        RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute(
            _server.Default("/payments/cash_balance_transfers/{cash_balance_transfer_id}"),
            [new TemplateParam("cash_balance_transfer_id", request.CashBalanceTransferId)],
            [],
            [new HeaderParam("upvest-api-version", request.UpvestApiVersion)],
            HttpMethod.Get,
            EmptyBody.Instance,
            JsonResponse.Create<PaymentsCashBalanceTransfer>(),
            RetrieveCashBalanceTransferError.Response,
            _auth.OauthClientCredentials.ForScopes("cash_balance_transfers:admin", "cash_balance_transfers:read"),
            requestOptions,
            cancellationToken);
}
