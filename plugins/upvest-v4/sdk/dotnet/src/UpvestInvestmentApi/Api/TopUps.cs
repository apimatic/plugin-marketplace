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
using UpvestInvestmentApi.Requests.TopUps;

namespace UpvestInvestmentApi.Api;

/// <summary>
/// All top-ups related paths
/// </summary>
public sealed class TopUps
{
    private readonly RawClient _rawClient;
    private readonly Server _server;
    private readonly AuthSchemes _auth;

    internal TopUps(RawClient rawClient, Server server, AuthSchemes auth)
    {
        _rawClient = rawClient;
        _server = server;
        _auth = auth;
    }

    /// <summary>
    /// Cancel a top-up by ID
    /// </summary>
    /// <param name="request">The operation's inputs</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>A <see cref="Task"/> instance.</returns>
    /// <exception cref="ApiException{TError}"> of <see cref="CancelTopupError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// Cancels a top-up specified by its ID. It is only possible to cancel a top-up if it has the status <c>CONFIRMED</c>.
    /// </remarks>
    public Task CancelTopup(CancelTopupRequest request,
        RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute(
            _server.Default("/payments/topups/{topup_id}"),
            [new TemplateParam("topup_id", request.TopupId)],
            [],
            [
                new HeaderParam("upvest-api-version", request.UpvestApiVersion),
                new HeaderParam("Idempotency-Key", Guid.NewGuid()),
            ],
            HttpMethod.Delete,
            EmptyBody.Instance,
            VoidResponse.Instance,
            CancelTopupError.Response,
            _auth.OauthClientCredentials.ForScopes("topups:admin"),
            requestOptions,
            cancellationToken);

    /// <summary>
    /// Trigger a top-up
    /// </summary>
    /// <param name="request">The operation's inputs</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="PaymentsTopupsResponse"/> instance.</returns>
    /// <exception cref="ApiException{TError}"> of <see cref="CreateTopupError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// Creates a top-up request for an account group and returns a <c>settlement_reference</c>. The end user must then send a SEPA Credit Transfer including that reference to complete the funding.
    /// </remarks>
    public Task<PaymentsTopupsResponse> CreateTopup(CreateTopupRequest request,
        RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute(
            _server.Default("/payments/topups"),
            [],
            [],
            [
                new HeaderParam("idempotency-key", request.IdempotencyKey),
                new HeaderParam("upvest-api-version", request.UpvestApiVersion),
            ],
            HttpMethod.Post,
            JsonRequest.Create(request.Body),
            JsonResponse.Create<PaymentsTopupsResponse>(),
            CreateTopupError.Response,
            _auth.OauthClientCredentials.ForScopes("topups:admin"),
            requestOptions,
            cancellationToken);

    /// <summary>
    /// List top-ups
    /// </summary>
    /// <param name="request">The operation's inputs</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="PaymentsTopUpsListResponse"/> instance.</returns>
    /// <exception cref="ApiException{TError}"> of <see cref="ListTopupsError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// Returns a list of top-ups.
    /// </remarks>
    public Task<PaymentsTopUpsListResponse> ListTopups(ListTopupsRequest request,
        RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute(
            _server.Default("/account_groups/{account_group_id}/payments/topups"),
            [new TemplateParam("account_group_id", request.AccountGroupId)],
            [
                new Param("sort", request.Sort),
                new Param("order", request.Order),
                new Param("limit", request.Limit),
                new Param("offset", request.Offset),
            ],
            [new HeaderParam("upvest-api-version", request.UpvestApiVersion)],
            HttpMethod.Get,
            EmptyBody.Instance,
            JsonResponse.Create<PaymentsTopUpsListResponse>(),
            ListTopupsError.Response,
            _auth.OauthClientCredentials.ForScopes("topups:admin", "topups:read"),
            requestOptions,
            cancellationToken);

    /// <summary>
    /// Retrieve a top-up by ID
    /// </summary>
    /// <param name="request">The operation's inputs</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="PaymentsTopupsResponse"/> instance.</returns>
    /// <exception cref="ApiException{TError}"> of <see cref="RetrieveTopupError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// Returns a top-up specified by its ID.
    /// </remarks>
    public Task<PaymentsTopupsResponse> RetrieveTopup(RetrieveTopupRequest request,
        RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute(
            _server.Default("/payments/topups/{topup_id}"),
            [new TemplateParam("topup_id", request.TopupId)],
            [],
            [new HeaderParam("upvest-api-version", request.UpvestApiVersion)],
            HttpMethod.Get,
            EmptyBody.Instance,
            JsonResponse.Create<PaymentsTopupsResponse>(),
            RetrieveTopupError.Response,
            _auth.OauthClientCredentials.ForScopes("topups:admin", "topups:read"),
            requestOptions,
            cancellationToken);
}
