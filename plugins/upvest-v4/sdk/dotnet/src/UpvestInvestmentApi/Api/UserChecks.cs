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
using UpvestInvestmentApi.Requests.UserChecks;

namespace UpvestInvestmentApi.Api;

/// <summary>
/// All user checks related paths.
/// </summary>
public sealed class UserChecks
{
    private readonly RawClient _rawClient;
    private readonly Server _server;
    private readonly AuthSchemes _auth;

    internal UserChecks(RawClient rawClient, Server server, AuthSchemes auth)
    {
        _rawClient = rawClient;
        _server = server;
        _auth = auth;
    }

    /// <summary>
    /// Create a new check for a user
    /// </summary>
    /// <param name="request">The operation's inputs</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="UserCheckCreateResponse"/> instance.</returns>
    /// <exception cref="ApiException{TError}"> of <see cref="CreateUserCheckError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// Creates a new check for a user specified by ID.
    /// </remarks>
    public Task<UserCheckCreateResponse> CreateUserCheck(CreateUserCheckRequest request,
        RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute(
            _server.Default("/users/{user_id}/checks"),
            [new TemplateParam("user_id", request.UserId)],
            [],
            [
                new HeaderParam("upvest-api-version", request.UpvestApiVersion),
                new HeaderParam("Idempotency-Key", Guid.NewGuid()),
            ],
            HttpMethod.Post,
            JsonRequest.Create(request.Body),
            JsonResponse.Create<UserCheckCreateResponse>(),
            CreateUserCheckError.Response,
            _auth.OauthClientCredentials.ForScopes("checks:admin"),
            requestOptions,
            cancellationToken);

    /// <summary>
    /// Get checks for a user
    /// </summary>
    /// <param name="request">The operation's inputs</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="UserCheckListResponse"/> instance.</returns>
    /// <exception cref="ApiException{TError}"> of <see cref="ListUserChecksError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// Lists all checks for a user specified by ID.
    /// </remarks>
    public Task<UserCheckListResponse> ListUserChecks(ListUserChecksRequest request,
        RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute(
            _server.Default("/users/{user_id}/checks"),
            [new TemplateParam("user_id", request.UserId)],
            [new Param("list_history", request.ListHistory), new Param("type", request.Type)],
            [new HeaderParam("upvest-api-version", request.UpvestApiVersion)],
            HttpMethod.Get,
            EmptyBody.Instance,
            JsonResponse.Create<UserCheckListResponse>(),
            ListUserChecksError.Response,
            _auth.OauthClientCredentials.ForScopes("checks:read", "checks:admin"),
            requestOptions,
            cancellationToken);

    /// <summary>
    /// Get a user check by ID
    /// </summary>
    /// <param name="request">The operation's inputs</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="UserCheck"/> instance.</returns>
    /// <exception cref="ApiException{TError}"> of <see cref="RetrieveUserCheckError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// Retrieves a check for a user specified by its ID.
    /// </remarks>
    public Task<UserCheck> RetrieveUserCheck(RetrieveUserCheckRequest request,
        RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute(
            _server.Default("/users/{user_id}/checks/{check_id}"),
            [new TemplateParam("user_id", request.UserId), new TemplateParam("check_id", request.CheckId)],
            [],
            [new HeaderParam("upvest-api-version", request.UpvestApiVersion)],
            HttpMethod.Get,
            EmptyBody.Instance,
            JsonResponse.Create<UserCheck>(),
            RetrieveUserCheckError.Response,
            _auth.OauthClientCredentials.ForScopes("checks:read", "checks:admin"),
            requestOptions,
            cancellationToken);
}
