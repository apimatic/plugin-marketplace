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
using UpvestInvestmentApi.Models.AnyOf;
using UpvestInvestmentApi.Requests.SavingsPlans;

namespace UpvestInvestmentApi.Api;

/// <summary>
/// All savings plans related paths.
/// </summary>
public sealed class SavingsPlans
{
    private readonly RawClient _rawClient;
    private readonly Server _server;
    private readonly AuthSchemes _auth;

    internal SavingsPlans(RawClient rawClient, Server server, AuthSchemes auth)
    {
        _rawClient = rawClient;
        _server = server;
        _auth = auth;
    }

    /// <summary>
    /// Create savings plan
    /// </summary>
    /// <param name="request">The operation's inputs</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="SavingsPlanInstrument"/> instance.</returns>
    /// <exception cref="ApiException{TError}"> of <see cref="CreateSavingsPlanError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// Creates a recurring savings plan that automatically invests a fixed cash amount at a defined frequency.
    /// <para>
    /// Set <c>type</c> to <c>INSTRUMENT</c> to invest in a single instrument, or <c>PORTFOLIO</c> to distribute the investment across the account's portfolio allocation.
    /// </para>
    /// </remarks>
    public Task<SavingsPlanInstrument> CreateSavingsPlan(CreateSavingsPlanRequest request,
        RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute(
            _server.Default("/savings_plans"),
            [],
            [],
            [
                new HeaderParam("idempotency-key", request.IdempotencyKey),
                new HeaderParam("upvest-api-version", request.UpvestApiVersion),
            ],
            HttpMethod.Post,
            JsonRequest.Create(request.Body),
            JsonResponse.Create<SavingsPlanInstrument>(),
            CreateSavingsPlanError.Response,
            _auth.OauthClientCredentials.ForScopes("savings_plans:admin"),
            requestOptions,
            cancellationToken);

    /// <summary>
    /// Delete a savings plan
    /// </summary>
    /// <param name="request">The operation's inputs</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>A <see cref="Task"/> instance.</returns>
    /// <exception cref="ApiException{TError}"> of <see cref="DeleteSavingsPlanError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// Delete a savings plan specified by its ID.
    /// </remarks>
    public Task DeleteSavingsPlan(DeleteSavingsPlanRequest request,
        RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute(
            _server.Default("/savings_plans/{savings_plan_id}"),
            [new TemplateParam("savings_plan_id", request.SavingsPlanId)],
            [],
            [
                new HeaderParam("upvest-api-version", request.UpvestApiVersion),
                new HeaderParam("Idempotency-Key", Guid.NewGuid()),
            ],
            HttpMethod.Delete,
            EmptyBody.Instance,
            VoidResponse.Instance,
            DeleteSavingsPlanError.Response,
            _auth.OauthClientCredentials.ForScopes("savings_plans:admin"),
            requestOptions,
            cancellationToken);

    /// <summary>
    /// Delete savings plan execution
    /// </summary>
    /// <param name="request">The operation's inputs</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>A <see cref="Task"/> instance.</returns>
    /// <exception cref="ApiException{TError}"> of <see cref="DeleteSavingsPlanExecutionError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// Deletes a scheduled savings plan execution before it has been processed. Only executions in the <c>NEW</c> status can be deleted.
    /// </remarks>
    public Task DeleteSavingsPlanExecution(DeleteSavingsPlanExecutionRequest request,
        RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute(
            _server.Default("/savings_plans/{savings_plan_id}/executions/{savings_plan_execution_id}"),
            [
                new TemplateParam("savings_plan_id", request.SavingsPlanId),
                new TemplateParam("savings_plan_execution_id", request.SavingsPlanExecutionId),
            ],
            [],
            [
                new HeaderParam("upvest-api-version", request.UpvestApiVersion),
                new HeaderParam("Idempotency-Key", Guid.NewGuid()),
            ],
            HttpMethod.Delete,
            EmptyBody.Instance,
            VoidResponse.Instance,
            DeleteSavingsPlanExecutionError.Response,
            _auth.OauthClientCredentials.ForScopes("savings_plans:admin"),
            requestOptions,
            cancellationToken);

    /// <summary>
    /// List savings plan executions
    /// </summary>
    /// <param name="request">The operation's inputs</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="SavingsPlanExecutionListResponse"/> instance.</returns>
    /// <exception cref="ApiException{TError}"> of <see cref="ListSavingsPlanExecutionsError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// List savings plan executions for a saving plan specified by its ID.
    /// </remarks>
    public Task<SavingsPlanExecutionListResponse> ListSavingsPlanExecutions(ListSavingsPlanExecutionsRequest request,
        RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute(
            _server.Default("/savings_plans/{savings_plan_id}/executions"),
            [new TemplateParam("savings_plan_id", request.SavingsPlanId)],
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
            JsonResponse.Create<SavingsPlanExecutionListResponse>(),
            ListSavingsPlanExecutionsError.Response,
            _auth.OauthClientCredentials.ForScopes("savings_plans:read", "savings_plans:admin"),
            requestOptions,
            cancellationToken);

    /// <summary>
    /// List savings plans
    /// </summary>
    /// <param name="request">The operation's inputs</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="SavingsPlanListResponse"/> instance.</returns>
    /// <exception cref="ApiException{TError}"> of <see cref="ListSavingsPlansError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// Returns a paginated list of savings plans for the authenticated client.
    /// <para>
    /// Savings plans can be of type <c>INSTRUMENT</c> (recurring buy of a single instrument) or <c>PORTFOLIO</c> (recurring investment distributed across the account's portfolio allocation).
    /// </para>
    /// </remarks>
    public Task<SavingsPlanListResponse> ListSavingsPlans(ListSavingsPlansRequest request,
        RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute(
            _server.Default("/savings_plans"),
            [],
            [
                new Param("account_id", request.AccountId),
                new Param("user_id", request.UserId),
                new Param("instrument_id", request.InstrumentId),
                new Param("sort", request.Sort),
                new Param("order", request.Order),
                new Param("offset", request.Offset),
                new Param("limit", request.Limit),
            ],
            [new HeaderParam("upvest-api-version", request.UpvestApiVersion)],
            HttpMethod.Get,
            EmptyBody.Instance,
            JsonResponse.Create<SavingsPlanListResponse>(),
            ListSavingsPlansError.Response,
            _auth.OauthClientCredentials.ForScopes("savings_plans:read", "savings_plans:admin"),
            requestOptions,
            cancellationToken);

    /// <summary>
    /// Retrieve a savings plan
    /// </summary>
    /// <param name="request">The operation's inputs</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="SavingsPlanInstrument"/> instance.</returns>
    /// <exception cref="ApiException{TError}"> of <see cref="RetrieveSavingsPlanError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// Retrieve a savings plan specified by its ID.
    /// </remarks>
    public Task<SavingsPlanInstrument> RetrieveSavingsPlan(RetrieveSavingsPlanRequest request,
        RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute(
            _server.Default("/savings_plans/{savings_plan_id}"),
            [new TemplateParam("savings_plan_id", request.SavingsPlanId)],
            [],
            [new HeaderParam("upvest-api-version", request.UpvestApiVersion)],
            HttpMethod.Get,
            EmptyBody.Instance,
            JsonResponse.Create<SavingsPlanInstrument>(),
            RetrieveSavingsPlanError.Response,
            _auth.OauthClientCredentials.ForScopes("savings_plans:read", "savings_plans:admin"),
            requestOptions,
            cancellationToken);

    /// <summary>
    /// Retrieve savings plan execution
    /// </summary>
    /// <param name="request">The operation's inputs</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="SavingsPlanExecution"/> instance.</returns>
    /// <exception cref="ApiException{TError}"> of <see cref="RetrieveSavingsPlanExecutionError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// Retrieves a single execution of a savings plan by its ID, including the order placed and its current status.
    /// </remarks>
    public Task<SavingsPlanExecution> RetrieveSavingsPlanExecution(RetrieveSavingsPlanExecutionRequest request,
        RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute(
            _server.Default("/savings_plans/{savings_plan_id}/executions/{savings_plan_execution_id}"),
            [
                new TemplateParam("savings_plan_id", request.SavingsPlanId),
                new TemplateParam("savings_plan_execution_id", request.SavingsPlanExecutionId),
            ],
            [],
            [new HeaderParam("upvest-api-version", request.UpvestApiVersion)],
            HttpMethod.Get,
            EmptyBody.Instance,
            JsonResponse.Create<SavingsPlanExecution>(),
            RetrieveSavingsPlanExecutionError.Response,
            _auth.OauthClientCredentials.ForScopes("savings_plans:read", "savings_plans:admin"),
            requestOptions,
            cancellationToken);

    /// <summary>
    /// Update a savings plan
    /// </summary>
    /// <param name="request">The operation's inputs</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="SavingsPlanInstrument"/> instance.</returns>
    /// <exception cref="ApiException{TError}"> of <see cref="UpdateSavingsPlanError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// Updates the funding configuration of the savings plan specified by its ID.
    /// </remarks>
    public Task<SavingsPlanInstrument> UpdateSavingsPlan(UpdateSavingsPlanRequest request,
        RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute(
            _server.Default("/savings_plans/{savings_plan_id}"),
            [new TemplateParam("savings_plan_id", request.SavingsPlanId)],
            [],
            [
                new HeaderParam("upvest-api-version", request.UpvestApiVersion),
                new HeaderParam("Idempotency-Key", Guid.NewGuid()),
            ],
            new HttpMethod("PATCH"),
            JsonRequest.Create(request.Body),
            JsonResponse.Create<SavingsPlanInstrument>(),
            UpdateSavingsPlanError.Response,
            _auth.OauthClientCredentials.ForScopes("savings_plans:admin"),
            requestOptions,
            cancellationToken);
}
