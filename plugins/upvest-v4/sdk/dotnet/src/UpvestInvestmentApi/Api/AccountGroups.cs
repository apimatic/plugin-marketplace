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
using UpvestInvestmentApi.Requests.AccountGroups;

namespace UpvestInvestmentApi.Api;

/// <summary>
/// All account groups related paths
/// </summary>
public sealed class AccountGroups
{
    private readonly RawClient _rawClient;
    private readonly Server _server;
    private readonly AuthSchemes _auth;

    internal AccountGroups(RawClient rawClient, Server server, AuthSchemes auth)
    {
        _rawClient = rawClient;
        _server = server;
        _auth = auth;
    }

    /// <summary>
    /// Close an account group by ID
    /// </summary>
    /// <param name="request">The operation's inputs</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>A <see cref="Task"/> instance.</returns>
    /// <exception cref="ApiException{TError}"> of <see cref="AccountGroupClosureError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// Initiates the closure of the account group specified by its ID.
    /// <para>
    /// Closure is a two-step process: the account group status changes to <c>CLOSING</c>, and once all preconditions are met it transitions to <c>CLOSED</c>. Subscribe to the <c>ACCOUNT_GROUP.CLOSING_INITIATED</c> and <c>ACCOUNT_GROUP.CLOSED</c> webhook events to track progress.
    /// </para>
    /// <para>
    /// See the Closing accounts guide (<see href="https://docs.upvest.co/products/tol/guides/accounts/accounts_close_accounts">TOL</see> / <see href="https://docs.upvest.co/products/byol/guides/accounts/accounts_close_accounts">BYOL</see>) for preconditions and implementation details.
    /// </para>
    /// </remarks>
    public Task AccountGroupClosure(AccountGroupClosureRequest request,
        RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute(
            _server.Default("/account_groups/{account_group_id}"),
            [new TemplateParam("account_group_id", request.AccountGroupId)],
            [
                new Param("closure_reason", request.ClosureReason),
                new Param("notification_only", request.NotificationOnly),
            ],
            [
                new HeaderParam("upvest-api-version", request.UpvestApiVersion),
                new HeaderParam("Idempotency-Key", Guid.NewGuid()),
            ],
            HttpMethod.Delete,
            EmptyBody.Instance,
            VoidResponse.Instance,
            AccountGroupClosureError.Response,
            _auth.OauthClientCredentials.ForScopes("accounts:admin"),
            requestOptions,
            cancellationToken);

    /// <summary>
    /// Create an account group
    /// </summary>
    /// <param name="request">The operation's inputs</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="AccountGroupCreateResponse"/> instance.</returns>
    /// <exception cref="ApiException{TError}"> of <see cref="CreateAccountGroupError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// Creates an account group for a user or a business.
    /// <para>
    /// An account group aggregates the accounts within it for tax calculation and regulatory reporting purposes and holds positions in the form of cash; the official securities account number is assigned at account group level. The account group is created with status <c>PENDING_APPROVAL</c> and switches to <c>ACTIVE</c> once onboarding is complete.
    /// </para>
    /// <para>
    /// See the Creating account groups guide (<see href="https://docs.upvest.co/products/tol/guides/accounts/accounts_create_account_groups">TOL</see> / <see href="https://docs.upvest.co/products/byol/guides/accounts/accounts_create_account_groups">BYOL</see>) for implementation details.
    /// </para>
    /// </remarks>
    public Task<AccountGroupCreateResponse> CreateAccountGroup(CreateAccountGroupRequest request,
        RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute(
            _server.Default("/account_groups"),
            [],
            [],
            [
                new HeaderParam("idempotency-key", request.IdempotencyKey),
                new HeaderParam("upvest-api-version", request.UpvestApiVersion),
            ],
            HttpMethod.Post,
            JsonRequest.Create(request.Body),
            JsonResponse.Create<AccountGroupCreateResponse>(),
            CreateAccountGroupError.Response,
            _auth.OauthClientCredentials.ForScopes("accounts:admin"),
            requestOptions,
            cancellationToken);

    /// <summary>
    /// Get account groups
    /// </summary>
    /// <param name="request">The operation's inputs</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="AccountGroupsListResponse1"/> instance.</returns>
    /// <exception cref="ApiException{TError}"> of <see cref="ListAccountGroupsError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// Returns a paginated list of account groups.
    /// <para>
    /// Use the <c>offset</c> and <c>limit</c> query parameters to page through results; <c>meta.total_count</c> gives the total number of matching account groups. Both user and business account groups are returned.
    /// </para>
    /// <para>
    /// See the Accounts overview (<see href="https://docs.upvest.co/products/tol/guides/accounts/accounts_overview">TOL</see> / <see href="https://docs.upvest.co/products/byol/guides/accounts/accounts_overview">BYOL</see> / <see href="https://docs.upvest.co/products/omnibus/guides/accounts/accounts_overview">Omnibus</see>) for account group types and the account hierarchy.
    /// </para>
    /// </remarks>
    public Task<AccountGroupsListResponse1> ListAccountGroups(ListAccountGroupsRequest request,
        RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute(
            _server.Default("/account_groups"),
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
            JsonResponse.Create<AccountGroupsListResponse1>(),
            ListAccountGroupsError.Response,
            _auth.OauthClientCredentials.ForScopes("accounts:read", "accounts:admin"),
            requestOptions,
            cancellationToken);

    /// <summary>
    /// Get business account groups
    /// </summary>
    /// <param name="request">The operation's inputs</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="AccountGroupsListResponse2"/> instance.</returns>
    /// <exception cref="ApiException{TError}"> of <see cref="ListBusinessAccountGroupsError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// Lists the account groups of a business specified by ID.
    /// </remarks>
    public Task<AccountGroupsListResponse2> ListBusinessAccountGroups(ListBusinessAccountGroupsRequest request,
        RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute(
            _server.Default("/businesses/{business_id}/account_groups"),
            [new TemplateParam("business_id", request.BusinessId)],
            [
                new Param("sort", request.Sort),
                new Param("order", request.Order),
                new Param("offset", request.Offset),
                new Param("limit", request.Limit),
            ],
            [new HeaderParam("upvest-api-version", request.UpvestApiVersion)],
            HttpMethod.Get,
            EmptyBody.Instance,
            JsonResponse.Create<AccountGroupsListResponse2>(),
            ListBusinessAccountGroupsError.Response,
            _auth.OauthClientCredentials.ForScopes("accounts:read", "accounts:admin"),
            requestOptions,
            cancellationToken);

    /// <summary>
    /// Get user account groups
    /// </summary>
    /// <param name="request">The operation's inputs</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="AccountGroupsListResponse"/> instance.</returns>
    /// <exception cref="ApiException{TError}"> of <see cref="ListUserAccountGroupsError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// Lists the account groups of a user specified by ID.
    /// </remarks>
    public Task<AccountGroupsListResponse> ListUserAccountGroups(ListUserAccountGroupsRequest request,
        RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute(
            _server.Default("/users/{user_id}/account_groups"),
            [new TemplateParam("user_id", request.UserId)],
            [
                new Param("sort", request.Sort),
                new Param("order", request.Order),
                new Param("offset", request.Offset),
                new Param("limit", request.Limit),
            ],
            [new HeaderParam("upvest-api-version", request.UpvestApiVersion)],
            HttpMethod.Get,
            EmptyBody.Instance,
            JsonResponse.Create<AccountGroupsListResponse>(),
            ListUserAccountGroupsError.Response,
            _auth.OauthClientCredentials.ForScopes("accounts:read", "accounts:admin"),
            requestOptions,
            cancellationToken);

    /// <summary>
    /// Get an account group by ID
    /// </summary>
    /// <param name="request">The operation's inputs</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="AccountGroupRetrieveResponse"/> instance.</returns>
    /// <exception cref="ApiException{TError}"> of <see cref="RetrieveAccountGroupError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// Returns the account group specified by its ID, including its type, status, and securities account number.
    /// </remarks>
    public Task<AccountGroupRetrieveResponse> RetrieveAccountGroup(RetrieveAccountGroupRequest request,
        RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute(
            _server.Default("/account_groups/{account_group_id}"),
            [new TemplateParam("account_group_id", request.AccountGroupId)],
            [],
            [new HeaderParam("upvest-api-version", request.UpvestApiVersion)],
            HttpMethod.Get,
            EmptyBody.Instance,
            JsonResponse.Create<AccountGroupRetrieveResponse>(),
            RetrieveAccountGroupError.Response,
            _auth.OauthClientCredentials.ForScopes("accounts:read", "accounts:admin"),
            requestOptions,
            cancellationToken);
}
