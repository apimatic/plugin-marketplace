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
using UpvestInvestmentApi.Requests.Users;

namespace UpvestInvestmentApi.Api;

/// <summary>
/// All user related paths.
/// </summary>
public sealed class Users
{
    private readonly RawClient _rawClient;
    private readonly Server _server;
    private readonly AuthSchemes _auth;

    internal Users(RawClient rawClient, Server server, AuthSchemes auth)
    {
        _rawClient = rawClient;
        _server = server;
        _auth = auth;
    }

    /// <summary>
    /// Create a user
    /// </summary>
    /// <param name="request">The operation's inputs</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="UserCreateRequest1"/> instance.</returns>
    /// <exception cref="ApiException{TError}"> of <see cref="CreateUserError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// Creates a user.
    /// <para>
    /// The user must complete identity checks and provide any required identifiers before their role for an account group or business becomes active.
    /// </para>
    /// <para>
    /// See the Creating a user guide (<see href="https://docs.upvest.co/products/tol/guides/users/users_onboarding_create">TOL</see> / <see href="https://docs.upvest.co/products/byol/guides/users/users_onboarding_create">BYOL</see>) for the full onboarding flow.
    /// </para>
    /// </remarks>
    public Task<UserCreateRequest1> CreateUser(CreateUserRequest request,
        RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute(
            _server.Default("/users"),
            [],
            [],
            [
                new HeaderParam("idempotency-key", request.IdempotencyKey),
                new HeaderParam("upvest-api-version", request.UpvestApiVersion),
            ],
            HttpMethod.Post,
            JsonRequest.Create(request.Body),
            JsonResponse.Create<UserCreateRequest1>(),
            CreateUserError.Response,
            _auth.OauthClientCredentials.ForScopes("users:admin"),
            requestOptions,
            cancellationToken);

    /// <summary>
    /// Get all users
    /// </summary>
    /// <param name="request">The operation's inputs</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="UsersListResponse"/> instance.</returns>
    /// <exception cref="ApiException{TError}"> of <see cref="ListUsersError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// Returns a paginated list of users.
    /// <para>
    /// Use the <c>offset</c> and <c>limit</c> query parameters to page through results; <c>meta.total_count</c> gives the total number of matching users. Use <c>sort</c>/<c>order</c> to control ordering by <c>created_at</c> or <c>updated_at</c>.
    /// </para>
    /// <para>
    /// See the User onboarding guide (<see href="https://docs.upvest.co/products/tol/guides/users/users_onboarding_overview">TOL</see> / <see href="https://docs.upvest.co/products/byol/guides/users/users_onboarding_overview">BYOL</see>) for the user lifecycle.
    /// </para>
    /// </remarks>
    public Task<UsersListResponse> ListUsers(ListUsersRequest request,
        RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute(
            _server.Default("/users"),
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
            JsonResponse.Create<UsersListResponse>(),
            ListUsersError.Response,
            _auth.OauthClientCredentials.ForScopes("users:read", "users:admin"),
            requestOptions,
            cancellationToken);

    /// <summary>
    /// Offboard a user
    /// </summary>
    /// <param name="request">The operation's inputs</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>A <see cref="Task"/> instance.</returns>
    /// <exception cref="ApiException{TError}"> of <see cref="OffboardUserError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// Starts the user offboarding process in the background.
    /// </remarks>
    public Task OffboardUser(OffboardUserRequest request,
        RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute(
            _server.Default("/users/{user_id}"),
            [new TemplateParam("user_id", request.UserId)],
            [],
            [
                new HeaderParam("upvest-api-version", request.UpvestApiVersion),
                new HeaderParam("Idempotency-Key", Guid.NewGuid()),
            ],
            HttpMethod.Delete,
            EmptyBody.Instance,
            VoidResponse.Instance,
            OffboardUserError.Response,
            _auth.OauthClientCredentials.ForScopes("users:admin"),
            requestOptions,
            cancellationToken);

    /// <summary>
    /// Get a user by ID
    /// </summary>
    /// <param name="request">The operation's inputs</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="UserGetResponse"/> instance.</returns>
    /// <exception cref="ApiException{TError}"> of <see cref="RetrieveUserError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// Returns the user identified by <c>user_id</c>, including profile and status details
    /// </remarks>
    public Task<UserGetResponse> RetrieveUser(RetrieveUserRequest request,
        RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute(
            _server.Default("/users/{user_id}"),
            [new TemplateParam("user_id", request.UserId)],
            [],
            [new HeaderParam("upvest-api-version", request.UpvestApiVersion)],
            HttpMethod.Get,
            EmptyBody.Instance,
            JsonResponse.Create<UserGetResponse>(),
            RetrieveUserError.Response,
            _auth.OauthClientCredentials.ForScopes("users:read", "users:admin"),
            requestOptions,
            cancellationToken);

    /// <summary>
    /// Change user data
    /// </summary>
    /// <param name="request">The operation's inputs</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>A <see cref="Task"/> instance.</returns>
    /// <exception cref="ApiException{TError}"> of <see cref="UserDataChangeError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// Requests a data change for a user specified by ID.
    /// </remarks>
    public Task UserDataChange(UserDataChangeOperationRequest request,
        RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute(
            _server.Default("/users/{user_id}/data_change_requests"),
            [new TemplateParam("user_id", request.UserId)],
            [],
            [
                new HeaderParam("upvest-api-version", request.UpvestApiVersion),
                new HeaderParam("Idempotency-Key", Guid.NewGuid()),
            ],
            HttpMethod.Post,
            JsonRequest.Create(request.Body),
            VoidResponse.Instance,
            UserDataChangeError.Response,
            _auth.OauthClientCredentials.ForScopes("users:admin"),
            requestOptions,
            cancellationToken);
}
