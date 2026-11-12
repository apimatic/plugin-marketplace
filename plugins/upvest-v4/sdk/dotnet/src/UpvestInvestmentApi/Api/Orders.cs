using System;
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
using UpvestInvestmentApi.Requests.Orders;

namespace UpvestInvestmentApi.Api;

/// <summary>
/// All order related paths.
/// </summary>
public sealed class Orders
{
    private readonly RawClient _rawClient;
    private readonly Server _server;
    private readonly AuthSchemes _auth;

    internal Orders(RawClient rawClient, Server server, AuthSchemes auth)
    {
        _rawClient = rawClient;
        _server = server;
        _auth = auth;
    }

    /// <summary>
    /// Cancel an order by ID
    /// </summary>
    /// <param name="request">The operation's inputs</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="OrderCancelResponse"/> instance.</returns>
    /// <exception cref="ApiException{TError}"> of <see cref="CancelOrderError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// Cancels an order specified by its ID. It is possible to cancel an order in the <c>NEW</c> or <c>PROCESSING</c> status. Once a cancellation has been accepted, the further processing steps take place asynchronously and depending on the respective order status.
    /// </remarks>
    public Task<OrderCancelResponse> CancelOrder(CancelOrderRequest request,
        RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute(
            _server.Default("/orders/{order_id}"),
            [new TemplateParam("order_id", request.OrderId)],
            [],
            [
                new HeaderParam("upvest-api-version", request.UpvestApiVersion),
                new HeaderParam("Idempotency-Key", Guid.NewGuid()),
            ],
            HttpMethod.Delete,
            EmptyBody.Instance,
            JsonResponse.Create<OrderCancelResponse>(),
            CancelOrderError.Response,
            _auth.OauthClientCredentials.ForScopes("orders:admin"),
            requestOptions,
            cancellationToken);

    /// <summary>
    /// Get orders for an account by ID
    /// </summary>
    /// <param name="request">The operation's inputs</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="OrdersListResponse"/> instance.</returns>
    /// <exception cref="ApiException{TError}"> of <see cref="ListAccountOrdersError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// Returns a paginated list of orders for the account specified by its ID, including their statuses, executions, and fee configurations.
    /// <para>
    /// See the Orders guide (<see href="https://docs.upvest.co/products/tol/guides/orders">TOL</see> / <see href="https://docs.upvest.co/products/byol/guides/orders">BYOL</see> / <see href="https://docs.upvest.co/products/omnibus/guides/orders">Omnibus</see>) for order lifecycle details.
    /// </para>
    /// </remarks>
    public Task<OrdersListResponse> ListAccountOrders(ListAccountOrdersRequest request,
        RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute(
            _server.Default("/accounts/{account_id}/orders"),
            [new TemplateParam("account_id", request.AccountId)],
            [
                new Param("order", request.Order),
                new Param("account_group_id", request.AccountGroupId),
                new Param("user_id", request.UserId),
                new Param("status", request.Status),
                new Param("date_created_from", request.DateCreatedFrom?.ToIso8601()),
                new Param("date_created_to", request.DateCreatedTo?.ToIso8601()),
                new Param("offset", request.Offset),
                new Param("limit", request.Limit),
            ],
            [new HeaderParam("upvest-api-version", request.UpvestApiVersion)],
            HttpMethod.Get,
            EmptyBody.Instance,
            JsonResponse.Create<OrdersListResponse>(),
            ListAccountOrdersError.Response,
            _auth.OauthClientCredentials.ForScopes("orders:read", "orders:admin"),
            requestOptions,
            cancellationToken);

    /// <summary>
    /// Place an order
    /// </summary>
    /// <param name="request">The operation's inputs</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="Order39"/> instance.</returns>
    /// <exception cref="ApiException{TError}"> of <see cref="PlaceOrderError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// Places a new order for an instrument. After the request is accepted, the order is processed asynchronously — use the returned <c>id</c> to poll for status or subscribe to order webhook events.
    /// <para>
    /// See the Orders guide (<see href="https://docs.upvest.co/products/tol/guides/orders">TOL</see> / <see href="https://docs.upvest.co/products/byol/guides/orders">BYOL</see> / <see href="https://docs.upvest.co/products/omnibus/guides/orders">Omnibus</see>) for order lifecycle details.
    /// </para>
    /// </remarks>
    public Task<Order39> PlaceOrder(PlaceOrderRequest request,
        RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute(
            _server.Default("/orders"),
            [],
            [],
            [
                new HeaderParam("idempotency-key", request.IdempotencyKey),
                new HeaderParam("upvest-api-version", request.UpvestApiVersion),
            ],
            HttpMethod.Post,
            JsonRequest.Create(request.Body),
            JsonResponse.Create<Order39>(),
            PlaceOrderError.Response,
            _auth.OauthClientCredentials.ForScopes("orders:admin"),
            requestOptions,
            cancellationToken);

    /// <summary>
    /// Get an order by ID
    /// </summary>
    /// <param name="request">The operation's inputs</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="Order39"/> instance.</returns>
    /// <exception cref="ApiException{TError}"> of <see cref="RetrieveOrderError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// Returns the order specified by its ID, including its current status, executions, fee configuration, and any cancellation reason.
    /// <para>
    /// See the Orders guide (<see href="https://docs.upvest.co/products/tol/guides/orders">TOL</see> / <see href="https://docs.upvest.co/products/byol/guides/orders">BYOL</see> / <see href="https://docs.upvest.co/products/omnibus/guides/orders">Omnibus</see>) for order lifecycle details.
    /// </para>
    /// </remarks>
    public Task<Order39> RetrieveOrder(RetrieveOrderRequest request,
        RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute(
            _server.Default("/orders/{order_id}"),
            [new TemplateParam("order_id", request.OrderId)],
            [],
            [new HeaderParam("upvest-api-version", request.UpvestApiVersion)],
            HttpMethod.Get,
            EmptyBody.Instance,
            JsonResponse.Create<Order39>(),
            RetrieveOrderError.Response,
            _auth.OauthClientCredentials.ForScopes("orders:read", "orders:admin"),
            requestOptions,
            cancellationToken);

    /// <summary>
    /// Get an order execution by ID
    /// </summary>
    /// <param name="request">The operation's inputs</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="OrderExecution"/> instance.</returns>
    /// <exception cref="ApiException{TError}"> of <see cref="RetrieveOrderExecutionError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// Returns the order execution specified by its ID. An execution represents a single trade fill within an order; an order may have multiple executions if it is partially filled across several trades.
    /// <para>
    /// See the Orders guide (<see href="https://docs.upvest.co/products/tol/guides/orders">TOL</see> / <see href="https://docs.upvest.co/products/byol/guides/orders">BYOL</see> / <see href="https://docs.upvest.co/products/omnibus/guides/orders">Omnibus</see>) for execution lifecycle details.
    /// </para>
    /// </remarks>
    public Task<OrderExecution> RetrieveOrderExecution(RetrieveOrderExecutionRequest request,
        RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute(
            _server.Default("/orders/{order_id}/executions/{execution_id}"),
            [new TemplateParam("execution_id", request.ExecutionId), new TemplateParam("order_id", request.OrderId)],
            [],
            [new HeaderParam("upvest-api-version", request.UpvestApiVersion)],
            HttpMethod.Get,
            EmptyBody.Instance,
            JsonResponse.Create<OrderExecution>(),
            RetrieveOrderExecutionError.Response,
            _auth.OauthClientCredentials.ForScopes("orders:read", "orders:admin"),
            requestOptions,
            cancellationToken);
}
