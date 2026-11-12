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
using UpvestInvestmentApi.Requests.Liquidations;

namespace UpvestInvestmentApi.Api;

/// <summary>
/// All accounts liquidations related paths.
/// </summary>
public sealed class Liquidations
{
    private readonly RawClient _rawClient;
    private readonly Server _server;
    private readonly AuthSchemes _auth;

    internal Liquidations(RawClient rawClient, Server server, AuthSchemes auth)
    {
        _rawClient = rawClient;
        _server = server;
        _auth = auth;
    }

    /// <summary>
    /// Cancel account liquidation
    /// </summary>
    /// <param name="request">The operation's inputs</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>A <see cref="Task"/> instance.</returns>
    /// <exception cref="ApiException{TError}"> of <see cref="CancelAccountLiquidationError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// Cancels a pending account liquidation. Only liquidations in the <c>NEW</c> status can be cancelled.
    /// <para>
    /// See the Liquidations guide (<see href="https://docs.upvest.co/products/tol/guides/liquidations">TOL</see> / <see href="https://docs.upvest.co/products/byol/guides/liquidations">BYOL</see>) for implementation details.
    /// </para>
    /// </remarks>
    public Task CancelAccountLiquidation(CancelAccountLiquidationRequest request,
        RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute(
            _server.Default("/accounts/{account_id}/liquidations/{account_liquidation_id}"),
            [
                new TemplateParam("account_id", request.AccountId),
                new TemplateParam("account_liquidation_id", request.AccountLiquidationId),
            ],
            [],
            [
                new HeaderParam("upvest-api-version", request.UpvestApiVersion),
                new HeaderParam("Idempotency-Key", Guid.NewGuid()),
            ],
            HttpMethod.Delete,
            EmptyBody.Instance,
            VoidResponse.Instance,
            CancelAccountLiquidationError.Response,
            _auth.OauthClientCredentials.ForScopes("account_liquidations:admin"),
            requestOptions,
            cancellationToken);

    /// <summary>
    /// Create account liquidation request
    /// </summary>
    /// <param name="request">The operation's inputs</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="AccountLiquidation"/> instance.</returns>
    /// <exception cref="ApiException{TError}"> of <see cref="CreateAccountLiquidationError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// Initiates a full liquidation of an investment account, placing sell orders for all held positions and converting the proceeds to cash.
    /// <para>
    /// Exactly one of <c>user_id</c> or <c>business_id</c> must be provided in the request body.
    /// </para>
    /// <para>
    /// See the Liquidations guide (<see href="https://docs.upvest.co/products/tol/guides/liquidations">TOL</see> / <see href="https://docs.upvest.co/products/byol/guides/liquidations">BYOL</see>) for implementation details.
    /// </para>
    /// </remarks>
    public Task<AccountLiquidation> CreateAccountLiquidation(CreateAccountLiquidationRequest request,
        RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute(
            _server.Default("/accounts/{account_id}/liquidations"),
            [new TemplateParam("account_id", request.AccountId)],
            [],
            [
                new HeaderParam("idempotency-key", request.IdempotencyKey),
                new HeaderParam("upvest-api-version", request.UpvestApiVersion),
            ],
            HttpMethod.Post,
            JsonRequest.Create(request.Body),
            JsonResponse.Create<AccountLiquidation>(),
            CreateAccountLiquidationError.Response,
            _auth.OauthClientCredentials.ForScopes("account_liquidations:admin"),
            requestOptions,
            cancellationToken);

    /// <summary>
    /// List accounts liquidations
    /// </summary>
    /// <param name="request">The operation's inputs</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="PortfoliosOrdersListResponse1"/> instance.</returns>
    /// <exception cref="ApiException{TError}"> of <see cref="ListAccountsLiquidationsError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// Returns a paginated list of account liquidation requests for the authenticated client.
    /// <para>
    /// See the Liquidations guide (<see href="https://docs.upvest.co/products/tol/guides/liquidations">TOL</see> / <see href="https://docs.upvest.co/products/byol/guides/liquidations">BYOL</see>) for implementation details.
    /// </para>
    /// </remarks>
    public Task<PortfoliosOrdersListResponse1> ListAccountsLiquidations(ListAccountsLiquidationsRequest request,
        RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute(
            _server.Default("/accounts/{account_id}/liquidations"),
            [new TemplateParam("account_id", request.AccountId)],
            [
                new Param("sort", request.Sort),
                new Param("order", request.Order),
                new Param("offset", request.Offset),
                new Param("limit", request.Limit),
                new Param("start_date", request.StartDate),
                new Param("end_date", request.EndDate),
            ],
            [new HeaderParam("upvest-api-version", request.UpvestApiVersion)],
            HttpMethod.Get,
            EmptyBody.Instance,
            JsonResponse.Create<PortfoliosOrdersListResponse1>(),
            ListAccountsLiquidationsError.Response,
            _auth.OauthClientCredentials.ForScopes("account_liquidations:read", "account_liquidations:admin"),
            requestOptions,
            cancellationToken);

    /// <summary>
    /// Retrieve account liquidation
    /// </summary>
    /// <param name="request">The operation's inputs</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="AccountLiquidation"/> instance.</returns>
    /// <exception cref="ApiException{TError}"> of <see cref="RetrieveAccountLiquidationError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// Retrieves an account liquidation by its ID, including the status of each individual sell order.
    /// <para>
    /// See the Liquidations guide (<see href="https://docs.upvest.co/products/tol/guides/liquidations">TOL</see> / <see href="https://docs.upvest.co/products/byol/guides/liquidations">BYOL</see>) for implementation details.
    /// </para>
    /// </remarks>
    public Task<AccountLiquidation> RetrieveAccountLiquidation(RetrieveAccountLiquidationRequest request,
        RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute(
            _server.Default("/accounts/{account_id}/liquidations/{account_liquidation_id}"),
            [
                new TemplateParam("account_id", request.AccountId),
                new TemplateParam("account_liquidation_id", request.AccountLiquidationId),
            ],
            [],
            [new HeaderParam("upvest-api-version", request.UpvestApiVersion)],
            HttpMethod.Get,
            EmptyBody.Instance,
            JsonResponse.Create<AccountLiquidation>(),
            RetrieveAccountLiquidationError.Response,
            _auth.OauthClientCredentials.ForScopes("account_liquidations:read", "account_liquidations:admin"),
            requestOptions,
            cancellationToken);
}
