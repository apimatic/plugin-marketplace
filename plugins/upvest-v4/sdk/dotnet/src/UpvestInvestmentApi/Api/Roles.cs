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
using UpvestInvestmentApi.Requests.Roles;

namespace UpvestInvestmentApi.Api;

/// <summary>
/// All Roles related paths.
/// </summary>
public sealed class Roles
{
    private readonly RawClient _rawClient;
    private readonly Server _server;
    private readonly AuthSchemes _auth;

    internal Roles(RawClient rawClient, Server server, AuthSchemes auth)
    {
        _rawClient = rawClient;
        _server = server;
        _auth = auth;
    }

    /// <summary>
    /// Create a role
    /// </summary>
    /// <param name="request">The operation's inputs</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="RoleCreateResponse"/> instance.</returns>
    /// <exception cref="ApiException{TError}"> of <see cref="CreateRoleError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// Creates a role, assigning a user to an account group or business entity.
    /// <para>
    /// The <c>entity_type</c> parameter determines whether <c>entity_id</c> refers to an account group or a business, and constrains which <c>role_type</c> values are valid.
    /// </para>
    /// <para>
    /// See the User roles guide (<see href="https://docs.upvest.co/products/tol/guides/users/users_onboarding_roles">TOL</see> / <see href="https://docs.upvest.co/products/byol/guides/users/users_onboarding_roles">BYOL</see>) for role types and assignment rules.
    /// </para>
    /// </remarks>
    public Task<RoleCreateResponse> CreateRole(CreateRoleRequest request,
        RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute(
            _server.Default("/roles"),
            [],
            [],
            [
                new HeaderParam("idempotency-key", request.IdempotencyKey),
                new HeaderParam("upvest-api-version", request.UpvestApiVersion),
            ],
            HttpMethod.Post,
            JsonRequest.Create(request.Body),
            JsonResponse.Create<RoleCreateResponse>(),
            CreateRoleError.Response,
            _auth.OauthClientCredentials.ForScopes("roles:admin"),
            requestOptions,
            cancellationToken);

    /// <summary>
    /// Get all roles
    /// </summary>
    /// <param name="request">The operation's inputs</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="RolesListResponse"/> instance.</returns>
    /// <exception cref="ApiException{TError}"> of <see cref="ListRolesError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// Returns a paginated list of roles.
    /// <para>
    /// Use the <c>offset</c> and <c>limit</c> query parameters to page through results; <c>meta.total_count</c> gives the total number of matching roles. Use <c>user_id</c> to filter by a specific user, <c>entity_id</c> to filter by account group or business, and <c>sort</c>/<c>order</c> to control the ordering by <c>created_at</c> or <c>updated_at</c>.
    /// </para>
    /// <para>
    /// See the User roles guide (<see href="https://docs.upvest.co/products/tol/guides/users/users_onboarding_roles">TOL</see> / <see href="https://docs.upvest.co/products/byol/guides/users/users_onboarding_roles">BYOL</see>) for role types and assignment rules.
    /// </para>
    /// </remarks>
    public Task<RolesListResponse> ListRoles(ListRolesRequest request,
        RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute(
            _server.Default("/roles"),
            [new TemplateParam("user_id", request.UserIdTemplate)],
            [
                new Param("sort", request.Sort),
                new Param("user_id", request.UserId),
                new Param("entity_id", request.EntityId),
                new Param("order", request.Order),
                new Param("offset", request.Offset),
                new Param("limit", request.Limit),
            ],
            [new HeaderParam("upvest-api-version", request.UpvestApiVersion)],
            HttpMethod.Get,
            EmptyBody.Instance,
            JsonResponse.Create<RolesListResponse>(),
            ListRolesError.Response,
            _auth.OauthClientCredentials.ForScopes("roles:read", "roles:admin"),
            requestOptions,
            cancellationToken);

    /// <summary>
    /// Get a role by ID
    /// </summary>
    /// <param name="request">The operation's inputs</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="RoleRetrieveResponse"/> instance.</returns>
    /// <exception cref="ApiException{TError}"> of <see cref="RetrieveRoleError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// Returns the role identified by <c>role_id</c>, including its status and entity assignment.
    /// </remarks>
    public Task<RoleRetrieveResponse> RetrieveRole(RetrieveRoleRequest request,
        RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute(
            _server.Default("/roles/{role_id}"),
            [new TemplateParam("role_id", request.RoleId)],
            [],
            [new HeaderParam("upvest-api-version", request.UpvestApiVersion)],
            HttpMethod.Get,
            EmptyBody.Instance,
            JsonResponse.Create<RoleRetrieveResponse>(),
            RetrieveRoleError.Response,
            _auth.OauthClientCredentials.ForScopes("roles:read", "roles:admin"),
            requestOptions,
            cancellationToken);

    /// <summary>
    /// Deactivate a role by ID
    /// </summary>
    /// <param name="request">The operation's inputs</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>A <see cref="Task"/> instance.</returns>
    /// <exception cref="ApiException{TError}"> of <see cref="RoleDeactivationError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// Deactivates the role specified by its ID. The role remains queryable with status <c>DEACTIVATED</c>.
    /// Only roles whose <c>entity_type</c> is <c>BUSINESS</c> may be deactivated via this endpoint; account-group roles are rejected with <c>403 Forbidden</c>.
    /// Deactivation is a terminal state; once deactivated, a role cannot be reactivated.
    /// Deactivation is idempotent: calling this endpoint on an already-deactivated role returns <c>202 Accepted</c> without side effects.
    /// A <c>ROLE.DEACTIVATED</c> webhook event is emitted on the first successful deactivation.
    /// </remarks>
    public Task RoleDeactivation(RoleDeactivationRequest request,
        RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute(
            _server.Default("/roles/{role_id}"),
            [new TemplateParam("role_id", request.RoleId)],
            [],
            [
                new HeaderParam("upvest-api-version", request.UpvestApiVersion),
                new HeaderParam("Idempotency-Key", Guid.NewGuid()),
            ],
            HttpMethod.Delete,
            EmptyBody.Instance,
            VoidResponse.Instance,
            RoleDeactivationError.Response,
            _auth.OauthClientCredentials.ForScopes("roles:admin"),
            requestOptions,
            cancellationToken);
}
