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
using UpvestInvestmentApi.Requests.Portfolios;

namespace UpvestInvestmentApi.Api;

/// <summary>
/// All portfolios related paths.
/// </summary>
public sealed class Portfolios
{
    private readonly RawClient _rawClient;
    private readonly Server _server;
    private readonly AuthSchemes _auth;

    internal Portfolios(RawClient rawClient, Server server, AuthSchemes auth)
    {
        _rawClient = rawClient;
        _server = server;
        _auth = auth;
    }

    /// <summary>
    /// Cancel portfolios order
    /// </summary>
    /// <param name="request">The operation's inputs</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>A <see cref="Task"/> instance.</returns>
    /// <exception cref="ApiException{TError}"> of <see cref="CancelPortfoliosOrderError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// Cancel portfolios order. Cancellations may not be possible - in rare situations, some individual orders within portfolios order may already have been filled. In this case, cancellation could result in a mix of cancelled and filled orders.
    /// </remarks>
    public Task CancelPortfoliosOrder(CancelPortfoliosOrderRequest request,
        RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute(
            _server.Default("/portfolios/orders/{portfolio_order_id}"),
            [new TemplateParam("portfolio_order_id", request.PortfolioOrderId)],
            [],
            [
                new HeaderParam("upvest-api-version", request.UpvestApiVersion),
                new HeaderParam("Idempotency-Key", Guid.NewGuid()),
            ],
            HttpMethod.Delete,
            EmptyBody.Instance,
            VoidResponse.Instance,
            CancelPortfoliosOrderError.Response,
            _auth.OauthClientCredentials.ForScopes("portfolios:admin"),
            requestOptions,
            cancellationToken);

    /// <summary>
    /// Create portfolios allocation
    /// </summary>
    /// <param name="request">The operation's inputs</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="PortfoliosAllocation"/> instance.</returns>
    /// <exception cref="ApiException{TError}"> of <see cref="CreatePortfoliosAllocationError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// Creates a named portfolio allocation specifying a set of instrument weights.
    /// <para>
    /// The <c>allocation</c> array must contain at least one instrument entry. Weights are expressed as percentages and must sum to 100.
    /// </para>
    /// <para>
    /// See the Portfolios guide (<see href="https://docs.upvest.co/products/tol/guides/portfolios">TOL</see> / <see href="https://docs.upvest.co/products/byol/guides/portfolios">BYOL</see>) for implementation details.
    /// </para>
    /// </remarks>
    public Task<PortfoliosAllocation> CreatePortfoliosAllocation(CreatePortfoliosAllocationRequest request,
        RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute(
            _server.Default("/portfolios/allocations"),
            [],
            [],
            [
                new HeaderParam("idempotency-key", request.IdempotencyKey),
                new HeaderParam("upvest-api-version", request.UpvestApiVersion),
            ],
            HttpMethod.Post,
            JsonRequest.Create(request.Body),
            JsonResponse.Create<PortfoliosAllocation>(),
            CreatePortfoliosAllocationError.Response,
            _auth.OauthClientCredentials.ForScopes("portfolios:admin"),
            requestOptions,
            cancellationToken);

    /// <summary>
    /// Create portfolios configuration
    /// </summary>
    /// <param name="request">The operation's inputs</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="PortfoliosConfiguration"/> instance.</returns>
    /// <exception cref="ApiException{TError}"> of <see cref="CreatePortfoliosConfigurationError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// Creates a portfolio configuration for an investment account, associating it with a target allocation and optional rebalancing strategies.
    /// <para>
    /// Only one active configuration per account is permitted.
    /// </para>
    /// <para>
    /// See the Portfolios guide (<see href="https://docs.upvest.co/products/tol/guides/portfolios">TOL</see> / <see href="https://docs.upvest.co/products/byol/guides/portfolios">BYOL</see>) for implementation details.
    /// </para>
    /// </remarks>
    public Task<PortfoliosConfiguration> CreatePortfoliosConfiguration(CreatePortfoliosConfigurationRequest request,
        RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute(
            _server.Default("/portfolios/configurations"),
            [],
            [],
            [
                new HeaderParam("idempotency-key", request.IdempotencyKey),
                new HeaderParam("upvest-api-version", request.UpvestApiVersion),
            ],
            HttpMethod.Post,
            JsonRequest.Create(request.Body),
            JsonResponse.Create<PortfoliosConfiguration>(),
            CreatePortfoliosConfigurationError.Response,
            _auth.OauthClientCredentials.ForScopes("portfolios:admin"),
            requestOptions,
            cancellationToken);

    /// <summary>
    /// Create portfolios order
    /// </summary>
    /// <param name="request">The operation's inputs</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="PortfoliosOrder"/> instance.</returns>
    /// <exception cref="ApiException{TError}"> of <see cref="CreatePortfoliosOrderError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// Places a buy or sell portfolio order for the specified account, distributing the cash amount across instruments according to the account's allocation weights.
    /// <para>
    /// One underlying instrument order is generated per instrument in the allocation.
    /// </para>
    /// <para>
    /// See the Portfolios guide (<see href="https://docs.upvest.co/products/tol/guides/portfolios">TOL</see> / <see href="https://docs.upvest.co/products/byol/guides/portfolios">BYOL</see>) for implementation details.
    /// </para>
    /// </remarks>
    public Task<PortfoliosOrder> CreatePortfoliosOrder(CreatePortfoliosOrderRequest request,
        RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute(
            _server.Default("/portfolios/orders"),
            [],
            [],
            [
                new HeaderParam("idempotency-key", request.IdempotencyKey),
                new HeaderParam("upvest-api-version", request.UpvestApiVersion),
            ],
            HttpMethod.Post,
            JsonRequest.Create(request.Body),
            JsonResponse.Create<PortfoliosOrder>(),
            CreatePortfoliosOrderError.Response,
            _auth.OauthClientCredentials.ForScopes("portfolios:admin"),
            requestOptions,
            cancellationToken);

    /// <summary>
    /// Delete portfolios configuration
    /// </summary>
    /// <param name="request">The operation's inputs</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>A <see cref="Task"/> instance.</returns>
    /// <exception cref="ApiException{TError}"> of <see cref="DeletePortfoliosConfigurationError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// Delete portfolios configuration (hard delete)
    /// </remarks>
    public Task DeletePortfoliosConfiguration(DeletePortfoliosConfigurationRequest request,
        RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute(
            _server.Default("/portfolios/configurations/{account_id}"),
            [new TemplateParam("account_id", request.AccountId)],
            [],
            [
                new HeaderParam("upvest-api-version", request.UpvestApiVersion),
                new HeaderParam("Idempotency-Key", Guid.NewGuid()),
            ],
            HttpMethod.Delete,
            EmptyBody.Instance,
            VoidResponse.Instance,
            DeletePortfoliosConfigurationError.Response,
            _auth.OauthClientCredentials.ForScopes("portfolios:admin"),
            requestOptions,
            cancellationToken);

    /// <summary>
    /// List portfolios allocation accounts
    /// </summary>
    /// <param name="request">The operation's inputs</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="PortfoliosAllocationAccountsListResponse"/> instance.</returns>
    /// <exception cref="ApiException{TError}"> of <see cref="ListPortfoliosAllocationAccountsError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// Returns a paginated list of accounts associated with a specific portfolio allocation.
    /// <para>
    /// See the Portfolios guide (<see href="https://docs.upvest.co/products/tol/guides/portfolios">TOL</see> / <see href="https://docs.upvest.co/products/byol/guides/portfolios">BYOL</see>) for implementation details.
    /// </para>
    /// </remarks>
    public Task<PortfoliosAllocationAccountsListResponse> ListPortfoliosAllocationAccounts(ListPortfoliosAllocationAccountsRequest request,
        RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute(
            _server.Default("/portfolios/allocations/{allocation_id}/accounts"),
            [new TemplateParam("allocation_id", request.AllocationId)],
            [
                new Param("sort", request.Sort),
                new Param("order", request.Order),
                new Param("offset", request.Offset),
                new Param("limit", request.Limit),
            ],
            [new HeaderParam("upvest-api-version", request.UpvestApiVersion)],
            HttpMethod.Get,
            EmptyBody.Instance,
            JsonResponse.Create<PortfoliosAllocationAccountsListResponse>(),
            ListPortfoliosAllocationAccountsError.Response,
            _auth.OauthClientCredentials.ForScopes("portfolios:read", "portfolios:admin"),
            requestOptions,
            cancellationToken);

    /// <summary>
    /// List portfolios allocations
    /// </summary>
    /// <param name="request">The operation's inputs</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="PortfoliosAllocationsListResponse"/> instance.</returns>
    /// <exception cref="ApiException{TError}"> of <see cref="ListPortfoliosAllocationsError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// Returns a paginated list of portfolio allocations for the authenticated client.
    /// <para>
    /// Allocations define the target instrument weights that portfolio configurations use to invest and rebalance.
    /// </para>
    /// <para>
    /// See the Portfolios guide (<see href="https://docs.upvest.co/products/tol/guides/portfolios">TOL</see> / <see href="https://docs.upvest.co/products/byol/guides/portfolios">BYOL</see>) for implementation details.
    /// </para>
    /// </remarks>
    public Task<PortfoliosAllocationsListResponse> ListPortfoliosAllocations(ListPortfoliosAllocationsRequest request,
        RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute(
            _server.Default("/portfolios/allocations"),
            [],
            [
                new Param("sort", request.Sort),
                new Param("order", request.Order),
                new Param("offset", request.Offset),
                new Param("limit", request.Limit),
                new Param("start_date", request.StartDate),
                new Param("end_date", request.EndDate),
                new Param("instrument_ids", request.InstrumentIds),
            ],
            [new HeaderParam("upvest-api-version", request.UpvestApiVersion)],
            HttpMethod.Get,
            EmptyBody.Instance,
            JsonResponse.Create<PortfoliosAllocationsListResponse>(),
            ListPortfoliosAllocationsError.Response,
            _auth.OauthClientCredentials.ForScopes("portfolios:read", "portfolios:admin"),
            requestOptions,
            cancellationToken);

    /// <summary>
    /// List portfolios configurations
    /// </summary>
    /// <param name="request">The operation's inputs</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="PortfoliosConfigurationsListResponse"/> instance.</returns>
    /// <exception cref="ApiException{TError}"> of <see cref="ListPortfoliosConfigurationsError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// Returns a paginated list of portfolio configurations for the authenticated client.
    /// <para>
    /// Each configuration links an account to an allocation and defines which rebalancing strategies apply to that account.
    /// </para>
    /// <para>
    /// See the Portfolios guide (<see href="https://docs.upvest.co/products/tol/guides/portfolios">TOL</see> / <see href="https://docs.upvest.co/products/byol/guides/portfolios">BYOL</see>) for implementation details.
    /// </para>
    /// </remarks>
    public Task<PortfoliosConfigurationsListResponse> ListPortfoliosConfigurations(ListPortfoliosConfigurationsRequest request,
        RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute(
            _server.Default("/portfolios/configurations"),
            [],
            [
                new Param("sort", request.Sort),
                new Param("order", request.Order),
                new Param("offset", request.Offset),
                new Param("limit", request.Limit),
                new Param("start_date", request.StartDate),
                new Param("end_date", request.EndDate),
                new Param("account_id", request.AccountId),
                new Param("allocation_id", request.AllocationId),
            ],
            [new HeaderParam("upvest-api-version", request.UpvestApiVersion)],
            HttpMethod.Get,
            EmptyBody.Instance,
            JsonResponse.Create<PortfoliosConfigurationsListResponse>(),
            ListPortfoliosConfigurationsError.Response,
            _auth.OauthClientCredentials.ForScopes("portfolios:read", "portfolios:admin"),
            requestOptions,
            cancellationToken);

    /// <summary>
    /// List portfolios orders
    /// </summary>
    /// <param name="request">The operation's inputs</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="PortfoliosOrdersListResponse"/> instance.</returns>
    /// <exception cref="ApiException{TError}"> of <see cref="ListPortfoliosOrdersError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// Returns a paginated list of portfolio orders for the authenticated client.
    /// <para>
    /// Portfolio orders represent buy or sell instructions that invest or withdraw a cash amount across all instruments in the account's current allocation.
    /// </para>
    /// <para>
    /// See the Portfolios guide (<see href="https://docs.upvest.co/products/tol/guides/portfolios">TOL</see> / <see href="https://docs.upvest.co/products/byol/guides/portfolios">BYOL</see>) for order lifecycle details.
    /// </para>
    /// </remarks>
    public Task<PortfoliosOrdersListResponse> ListPortfoliosOrders(ListPortfoliosOrdersRequest request,
        RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute(
            _server.Default("/portfolios/orders"),
            [],
            [
                new Param("sort", request.Sort),
                new Param("order", request.Order),
                new Param("offset", request.Offset),
                new Param("limit", request.Limit),
                new Param("start_date", request.StartDate),
                new Param("end_date", request.EndDate),
                new Param("allocation_id", request.AllocationId),
                new Param("account_id", request.AccountId),
            ],
            [new HeaderParam("upvest-api-version", request.UpvestApiVersion)],
            HttpMethod.Get,
            EmptyBody.Instance,
            JsonResponse.Create<PortfoliosOrdersListResponse>(),
            ListPortfoliosOrdersError.Response,
            _auth.OauthClientCredentials.ForScopes("portfolios:read", "portfolios:admin"),
            requestOptions,
            cancellationToken);

    /// <summary>
    /// Retrieve portfolios allocation
    /// </summary>
    /// <param name="request">The operation's inputs</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="PortfoliosAllocation"/> instance.</returns>
    /// <exception cref="ApiException{TError}"> of <see cref="RetrievePortfoliosAllocationError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// Retrieves a portfolio allocation by its ID, including its name, instrument weights, and associated rebalancing strategy IDs.
    /// <para>
    /// See the Portfolios guide (<see href="https://docs.upvest.co/products/tol/guides/portfolios">TOL</see> / <see href="https://docs.upvest.co/products/byol/guides/portfolios">BYOL</see>) for implementation details.
    /// </para>
    /// </remarks>
    public Task<PortfoliosAllocation> RetrievePortfoliosAllocation(RetrievePortfoliosAllocationRequest request,
        RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute(
            _server.Default("/portfolios/allocations/{allocation_id}"),
            [new TemplateParam("allocation_id", request.AllocationId)],
            [],
            [new HeaderParam("upvest-api-version", request.UpvestApiVersion)],
            HttpMethod.Get,
            EmptyBody.Instance,
            JsonResponse.Create<PortfoliosAllocation>(),
            RetrievePortfoliosAllocationError.Response,
            _auth.OauthClientCredentials.ForScopes("portfolios:read", "portfolios:admin"),
            requestOptions,
            cancellationToken);

    /// <summary>
    /// Retrieve portfolios configuration
    /// </summary>
    /// <param name="request">The operation's inputs</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="PortfoliosConfiguration"/> instance.</returns>
    /// <exception cref="ApiException{TError}"> of <see cref="RetrievePortfoliosConfigurationError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// Retrieves a portfolio configuration by its ID, including the linked allocation and any associated rebalancing strategies.
    /// <para>
    /// See the Portfolios guide (<see href="https://docs.upvest.co/products/tol/guides/portfolios">TOL</see> / <see href="https://docs.upvest.co/products/byol/guides/portfolios">BYOL</see>) for implementation details.
    /// </para>
    /// </remarks>
    public Task<PortfoliosConfiguration> RetrievePortfoliosConfiguration(RetrievePortfoliosConfigurationRequest request,
        RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute(
            _server.Default("/portfolios/configurations/{account_id}"),
            [new TemplateParam("account_id", request.AccountId)],
            [],
            [new HeaderParam("upvest-api-version", request.UpvestApiVersion)],
            HttpMethod.Get,
            EmptyBody.Instance,
            JsonResponse.Create<PortfoliosConfiguration>(),
            RetrievePortfoliosConfigurationError.Response,
            _auth.OauthClientCredentials.ForScopes("portfolios:read", "portfolios:admin"),
            requestOptions,
            cancellationToken);

    /// <summary>
    /// Retrieve portfolios order
    /// </summary>
    /// <param name="request">The operation's inputs</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="PortfoliosOrder"/> instance.</returns>
    /// <exception cref="ApiException{TError}"> of <see cref="RetrievePortfoliosOrderError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// Retrieves a portfolio order by its ID, including the status and details of each underlying instrument order.
    /// <para>
    /// See the Portfolios guide (<see href="https://docs.upvest.co/products/tol/guides/portfolios">TOL</see> / <see href="https://docs.upvest.co/products/byol/guides/portfolios">BYOL</see>) for order lifecycle details.
    /// </para>
    /// </remarks>
    public Task<PortfoliosOrder> RetrievePortfoliosOrder(RetrievePortfoliosOrderRequest request,
        RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute(
            _server.Default("/portfolios/orders/{portfolio_order_id}"),
            [new TemplateParam("portfolio_order_id", request.PortfolioOrderId)],
            [],
            [new HeaderParam("upvest-api-version", request.UpvestApiVersion)],
            HttpMethod.Get,
            EmptyBody.Instance,
            JsonResponse.Create<PortfoliosOrder>(),
            RetrievePortfoliosOrderError.Response,
            _auth.OauthClientCredentials.ForScopes("portfolios:read", "portfolios:admin"),
            requestOptions,
            cancellationToken);

    /// <summary>
    /// Update portfolios allocation
    /// </summary>
    /// <param name="request">The operation's inputs</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="PortfoliosAllocation"/> instance.</returns>
    /// <exception cref="ApiException{TError}"> of <see cref="UpdatePortfoliosAllocationError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// Updates the name and/or instrument weights of an existing portfolio allocation.
    /// <para>
    /// Accounts with a portfolio configuration referencing this allocation will use the new weights on their next rebalancing.
    /// </para>
    /// <para>
    /// See the Portfolios guide (<see href="https://docs.upvest.co/products/tol/guides/portfolios">TOL</see> / <see href="https://docs.upvest.co/products/byol/guides/portfolios">BYOL</see>) for implementation details.
    /// </para>
    /// </remarks>
    public Task<PortfoliosAllocation> UpdatePortfoliosAllocation(UpdatePortfoliosAllocationRequest request,
        RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute(
            _server.Default("/portfolios/allocations/{allocation_id}"),
            [new TemplateParam("allocation_id", request.AllocationId)],
            [],
            [
                new HeaderParam("upvest-api-version", request.UpvestApiVersion),
                new HeaderParam("Idempotency-Key", Guid.NewGuid()),
            ],
            HttpMethod.Put,
            JsonRequest.Create(request.Body),
            JsonResponse.Create<PortfoliosAllocation>(),
            UpdatePortfoliosAllocationError.Response,
            _auth.OauthClientCredentials.ForScopes("portfolios:admin"),
            requestOptions,
            cancellationToken);

    /// <summary>
    /// Update portfolios configuration
    /// </summary>
    /// <param name="request">The operation's inputs</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="PortfoliosConfiguration"/> instance.</returns>
    /// <exception cref="ApiException{TError}"> of <see cref="UpdatePortfoliosConfigurationError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// Updates the allocation or rebalancing strategies of an existing portfolio configuration.
    /// <para>
    /// See the Portfolios guide (<see href="https://docs.upvest.co/products/tol/guides/portfolios">TOL</see> / <see href="https://docs.upvest.co/products/byol/guides/portfolios">BYOL</see>) for implementation details.
    /// </para>
    /// </remarks>
    public Task<PortfoliosConfiguration> UpdatePortfoliosConfiguration(UpdatePortfoliosConfigurationRequest request,
        RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute(
            _server.Default("/portfolios/configurations/{account_id}"),
            [new TemplateParam("account_id", request.AccountId)],
            [],
            [
                new HeaderParam("idempotency-key", request.IdempotencyKey),
                new HeaderParam("upvest-api-version", request.UpvestApiVersion),
            ],
            new HttpMethod("PATCH"),
            JsonRequest.Create(request.Body),
            JsonResponse.Create<PortfoliosConfiguration>(),
            UpdatePortfoliosConfigurationError.Response,
            _auth.OauthClientCredentials.ForScopes("portfolios:admin"),
            requestOptions,
            cancellationToken);
}
