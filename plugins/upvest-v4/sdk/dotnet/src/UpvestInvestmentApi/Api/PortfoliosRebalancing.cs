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
using UpvestInvestmentApi.Requests.PortfoliosRebalancing;

namespace UpvestInvestmentApi.Api;

/// <summary>
/// All portfolios rebalancing related paths.
/// </summary>
public sealed class PortfoliosRebalancing
{
    private readonly RawClient _rawClient;
    private readonly Server _server;
    private readonly AuthSchemes _auth;

    internal PortfoliosRebalancing(RawClient rawClient, Server server, AuthSchemes auth)
    {
        _rawClient = rawClient;
        _server = server;
        _auth = auth;
    }

    /// <summary>
    /// List portfolio rebalancing execution orders
    /// </summary>
    /// <param name="request">The operation's inputs</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="PortfoliosRebalancingExecutionOrderListResponse"/> instance.</returns>
    /// <exception cref="ApiException{TError}"> of <see cref="ListPortfolioRebalancingExecutionOrdersError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// List portfolio rebalancing execution orders
    /// </remarks>
    public Task<PortfoliosRebalancingExecutionOrderListResponse> ListPortfolioRebalancingExecutionOrders(ListPortfolioRebalancingExecutionOrdersRequest request,
        RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute(
            _server.Default("/portfolios/rebalancings/executions/{execution_id}/orders"),
            [new TemplateParam("execution_id", request.ExecutionId)],
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
            JsonResponse.Create<PortfoliosRebalancingExecutionOrderListResponse>(),
            ListPortfolioRebalancingExecutionOrdersError.Response,
            _auth.OauthClientCredentials.ForScopes("portfolios:read", "portfolios:admin"),
            requestOptions,
            cancellationToken);

    /// <summary>
    /// Retrieve portfolios rebalancing execution
    /// </summary>
    /// <param name="request">The operation's inputs</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="PortfoliosRebalancingExecution"/> instance.</returns>
    /// <exception cref="ApiException{TError}"> of <see cref="RetrievePortfoliosRebalancingExecutionError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// Retrieve portfolios rebalancing execution
    /// </remarks>
    public Task<PortfoliosRebalancingExecution> RetrievePortfoliosRebalancingExecution(RetrievePortfoliosRebalancingExecutionRequest request,
        RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute(
            _server.Default("/portfolios/rebalancings/executions/{execution_id}"),
            [new TemplateParam("execution_id", request.ExecutionId)],
            [],
            [new HeaderParam("upvest-api-version", request.UpvestApiVersion)],
            HttpMethod.Get,
            EmptyBody.Instance,
            JsonResponse.Create<PortfoliosRebalancingExecution>(),
            RetrievePortfoliosRebalancingExecutionError.Response,
            _auth.OauthClientCredentials.ForScopes("portfolios:read", "portfolios:admin"),
            requestOptions,
            cancellationToken);

    /// <summary>
    /// Trigger portfolio rebalancing
    /// </summary>
    /// <param name="request">The operation's inputs</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="TriggerPortfolioRebalancingResponse"/> instance.</returns>
    /// <exception cref="ApiException{TError}"> of <see cref="TriggerPortfolioRebalancingError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// Triggers an immediate rebalancing execution for all accounts linked to the specified allocation.
    /// <para>
    /// The rebalancing adjusts each account's positions to match the current target allocation weights. In rare situations, individual orders within the rebalancing may not be cancellable once submitted.
    /// </para>
    /// <para>
    /// See the Portfolios rebalancing guide (<see href="https://docs.upvest.co/products/tol/guides/portfolios/rebalancing/rebalancing">TOL</see> / <see href="https://docs.upvest.co/products/byol/guides/portfolios/rebalancing/rebalancing">BYOL</see>) for implementation details.
    /// </para>
    /// </remarks>
    public Task<TriggerPortfolioRebalancingResponse> TriggerPortfolioRebalancing(TriggerPortfolioRebalancingOperationRequest request,
        RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute(
            _server.Default("/portfolios/rebalancings/executions"),
            [],
            [],
            [
                new HeaderParam("idempotency-key", request.IdempotencyKey),
                new HeaderParam("upvest-api-version", request.UpvestApiVersion),
            ],
            HttpMethod.Post,
            JsonRequest.Create(request.Body),
            JsonResponse.Create<TriggerPortfolioRebalancingResponse>(),
            TriggerPortfolioRebalancingError.Response,
            _auth.OauthClientCredentials.ForScopes("portfolios:admin"),
            requestOptions,
            cancellationToken);
}
