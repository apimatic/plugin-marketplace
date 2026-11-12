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
using UpvestInvestmentApi.Requests.VirtualCashBalances;

namespace UpvestInvestmentApi.Api;

/// <summary>
/// All virtual cash balances related paths
/// </summary>
public sealed class VirtualCashBalances
{
    private readonly RawClient _rawClient;
    private readonly Server _server;
    private readonly AuthSchemes _auth;

    internal VirtualCashBalances(RawClient rawClient, Server server, AuthSchemes auth)
    {
        _rawClient = rawClient;
        _server = server;
        _auth = auth;
    }

    /// <summary>
    /// Cancel virtual cash decrease by ID
    /// </summary>
    /// <param name="request">The operation's inputs</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>A <see cref="Task"/> instance.</returns>
    /// <exception cref="ApiException{TError}"> of <see cref="CancelVirtualCashDecreaseError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// Cancels a virtual cash decrease specified by its ID. It is only possible to cancel a virtual cash decrease if it has the status <c>ISSUED</c> or <c>QUEUED</c>.
    /// </remarks>
    public Task CancelVirtualCashDecrease(CancelVirtualCashDecreaseRequest request,
        RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute(
            _server.Default("/virtual_cash_balances/decreases/{virtual_cash_decrease_id}"),
            [new TemplateParam("virtual_cash_decrease_id", request.VirtualCashDecreaseId)],
            [],
            [
                new HeaderParam("upvest-api-version", request.UpvestApiVersion),
                new HeaderParam("Idempotency-Key", Guid.NewGuid()),
            ],
            HttpMethod.Delete,
            EmptyBody.Instance,
            VoidResponse.Instance,
            CancelVirtualCashDecreaseError.Response,
            _auth.OauthClientCredentials.ForScopes("virtual_cash_balances:admin"),
            requestOptions,
            cancellationToken);

    /// <summary>
    /// Trigger a virtual cash decrease
    /// </summary>
    /// <param name="request">The operation's inputs</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="VirtualCashBalanceVirtualCashDecrease"/> instance.</returns>
    /// <exception cref="ApiException{TError}"> of <see cref="CreateVirtualCashDecreaseError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// Decreases an account group's virtual cash balance, for example after an order has settled or before a withdrawal.
    /// <para>
    /// If the account group does not yet have sufficient real cash, the decrease is queued with status <c>QUEUED</c> and confirmed automatically once funds arrive rather than being rejected. Requires the <c>Idempotency-Key</c> header to prevent duplicate decreases.
    /// </para>
    /// <para>
    /// See the Virtual cash guide (<see href="https://docs.upvest.co/products/tol/guides/virtual_cash/implementing_virtual_cash">TOL</see> / <see href="https://docs.upvest.co/products/byol/guides/virtual_cash/implementing_virtual_cash">BYOL</see>) for supported use cases.
    /// </para>
    /// </remarks>
    public Task<VirtualCashBalanceVirtualCashDecrease> CreateVirtualCashDecrease(CreateVirtualCashDecreaseRequest request,
        RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute(
            _server.Default("/virtual_cash_balances/decreases"),
            [],
            [],
            [
                new HeaderParam("idempotency-key", request.IdempotencyKey),
                new HeaderParam("upvest-api-version", request.UpvestApiVersion),
            ],
            HttpMethod.Post,
            JsonRequest.Create(request.Body),
            JsonResponse.Create<VirtualCashBalanceVirtualCashDecrease>(),
            CreateVirtualCashDecreaseError.Response,
            _auth.OauthClientCredentials.ForScopes("virtual_cash_balances:admin"),
            requestOptions,
            cancellationToken);

    /// <summary>
    /// Trigger a virtual cash increase
    /// </summary>
    /// <param name="request">The operation's inputs</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="VirtualCashBalanceVirtualCashIncrease"/> instance.</returns>
    /// <exception cref="ApiException{TError}"> of <see cref="CreateVirtualCashIncreaseError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// Increases an account group's virtual cash balance, making the specified <c>amount</c> available for trading before the corresponding real cash has settled.
    /// <para>
    /// Requires the <c>Idempotency-Key</c> header to prevent duplicate increases.
    /// </para>
    /// <para>
    /// See the Virtual cash guide (<see href="https://docs.upvest.co/products/tol/guides/virtual_cash/implementing_virtual_cash">TOL</see> / <see href="https://docs.upvest.co/products/byol/guides/virtual_cash/implementing_virtual_cash">BYOL</see>) for supported use cases.
    /// </para>
    /// </remarks>
    public Task<VirtualCashBalanceVirtualCashIncrease> CreateVirtualCashIncrease(CreateVirtualCashIncreaseRequest request,
        RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute(
            _server.Default("/virtual_cash_balances/increases"),
            [],
            [],
            [
                new HeaderParam("idempotency-key", request.IdempotencyKey),
                new HeaderParam("upvest-api-version", request.UpvestApiVersion),
            ],
            HttpMethod.Post,
            JsonRequest.Create(request.Body),
            JsonResponse.Create<VirtualCashBalanceVirtualCashIncrease>(),
            CreateVirtualCashIncreaseError.Response,
            _auth.OauthClientCredentials.ForScopes("virtual_cash_balances:admin"),
            requestOptions,
            cancellationToken);
}
