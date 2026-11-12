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
using UpvestInvestmentApi.Requests.AccountsApi;

namespace UpvestInvestmentApi.Api;

/// <summary>
/// All accounts related paths
/// </summary>
public sealed class AccountsApi
{
    private readonly RawClient _rawClient;
    private readonly Server _server;
    private readonly AuthSchemes _auth;

    internal AccountsApi(RawClient rawClient, Server server, AuthSchemes auth)
    {
        _rawClient = rawClient;
        _server = server;
        _auth = auth;
    }

    /// <summary>
    /// Close account by ID
    /// </summary>
    /// <param name="request">The operation's inputs</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>A <see cref="Task"/> instance.</returns>
    /// <exception cref="ApiException{TError}"> of <see cref="AccountClosureError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// Initiates the closure of the account specified by its ID.
    /// <para>
    /// Closure is a two-step process: the account status changes to <c>CLOSING</c>, and once all preconditions are met the account transitions to <c>CLOSED</c>. While in <c>CLOSING</c>, only sell orders and transfers of positions out of the account are permitted. Subscribe to the <c>ACCOUNT.CLOSING_INITIATED</c> and <c>ACCOUNT.CLOSED</c> webhook events to track progress.
    /// </para>
    /// <para>
    /// See the Closing accounts guide (<see href="https://docs.upvest.co/products/tol/guides/accounts/accounts_close_accounts">TOL</see> / <see href="https://docs.upvest.co/products/byol/guides/accounts/accounts_close_accounts">BYOL</see>) for preconditions and implementation details.
    /// </para>
    /// </remarks>
    public Task AccountClosure(AccountClosureRequest request,
        RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute(
            _server.Default("/accounts/{account_id}"),
            [new TemplateParam("account_id", request.AccountId)],
            [],
            [
                new HeaderParam("upvest-api-version", request.UpvestApiVersion),
                new HeaderParam("Idempotency-Key", Guid.NewGuid()),
            ],
            HttpMethod.Delete,
            EmptyBody.Instance,
            VoidResponse.Instance,
            AccountClosureError.Response,
            _auth.OauthClientCredentials.ForScopes("accounts:admin"),
            requestOptions,
            cancellationToken);

    /// <summary>
    /// Create an account
    /// </summary>
    /// <param name="request">The operation's inputs</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="AccountCreateResponse"/> instance.</returns>
    /// <exception cref="ApiException{TError}"> of <see cref="CreateAccountError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// Creates an account for a user or a business within an existing account group.
    /// <para>
    /// The account is created with status <c>PENDING_APPROVAL</c> and switches to <c>ACTIVE</c> once the owner's onboarding is complete; subscribe to the <c>ACCOUNT.ACTIVATED</c> webhook event to be notified. An account cannot exist without an account group and holds positions in the form of units.
    /// </para>
    /// <para>
    /// For a <c>JOINT</c> account group, <c>user_id</c> must be one of its 2 owners; either owner can be used. The account is shared by both owners and its <c>users</c> list both of them with type <c>OWNER</c>. A second owner whose <c>OWNER</c> role is still <c>PENDING</c> is not yet a member of the account group, and the request returns <c>404</c>.
    /// </para>
    /// <para>
    /// See the Creating accounts guide (<see href="https://docs.upvest.co/products/tol/guides/accounts/accounts_create_accounts">TOL</see> / <see href="https://docs.upvest.co/products/byol/guides/accounts/accounts_create_accounts">BYOL</see>) for implementation details.
    /// </para>
    /// </remarks>
    public Task<AccountCreateResponse> CreateAccount(CreateAccountRequest request,
        RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute(
            _server.Default("/accounts"),
            [],
            [],
            [
                new HeaderParam("idempotency-key", request.IdempotencyKey),
                new HeaderParam("upvest-api-version", request.UpvestApiVersion),
            ],
            HttpMethod.Post,
            JsonRequest.Create(request.Body),
            JsonResponse.Create<AccountCreateResponse>(),
            CreateAccountError.Response,
            _auth.OauthClientCredentials.ForScopes("accounts:admin"),
            requestOptions,
            cancellationToken);

    /// <summary>
    /// Get accounts
    /// </summary>
    /// <param name="request">The operation's inputs</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="AccountsListResponse1"/> instance.</returns>
    /// <exception cref="ApiException{TError}"> of <see cref="ListAccountsError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// Returns a paginated list of accounts.
    /// <para>
    /// Use the <c>offset</c> and <c>limit</c> query parameters to page through results; <c>meta.total_count</c> gives the total number of matching accounts. Both user and business accounts are returned.
    /// </para>
    /// <para>
    /// See the Accounts overview (<see href="https://docs.upvest.co/products/tol/guides/accounts/accounts_overview">TOL</see> / <see href="https://docs.upvest.co/products/byol/guides/accounts/accounts_overview">BYOL</see> / <see href="https://docs.upvest.co/products/omnibus/guides/accounts/accounts_overview">Omnibus</see>) for account types and the account hierarchy.
    /// </para>
    /// </remarks>
    public Task<AccountsListResponse1> ListAccounts(ListAccountsRequest request,
        RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute(
            _server.Default("/accounts"),
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
            JsonResponse.Create<AccountsListResponse1>(),
            ListAccountsError.Response,
            _auth.OauthClientCredentials.ForScopes("accounts:read", "accounts:admin"),
            requestOptions,
            cancellationToken);

    /// <summary>
    /// Get business accounts
    /// </summary>
    /// <param name="request">The operation's inputs</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="AccountsListResponse2"/> instance.</returns>
    /// <exception cref="ApiException{TError}"> of <see cref="ListBusinessAccountsError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// Lists the accounts of a business specified by ID.
    /// </remarks>
    public Task<AccountsListResponse2> ListBusinessAccounts(ListBusinessAccountsRequest request,
        RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute(
            _server.Default("/businesses/{business_id}/accounts"),
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
            JsonResponse.Create<AccountsListResponse2>(),
            ListBusinessAccountsError.Response,
            _auth.OauthClientCredentials.ForScopes("accounts:read", "accounts:admin"),
            requestOptions,
            cancellationToken);

    /// <summary>
    /// Get user accounts
    /// </summary>
    /// <param name="request">The operation's inputs</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="AccountsListResponse"/> instance.</returns>
    /// <exception cref="ApiException{TError}"> of <see cref="ListUserAccountsError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// Lists the accounts of a user specified by ID.
    /// </remarks>
    public Task<AccountsListResponse> ListUserAccounts(ListUserAccountsRequest request,
        RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute(
            _server.Default("/users/{user_id}/accounts"),
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
            JsonResponse.Create<AccountsListResponse>(),
            ListUserAccountsError.Response,
            _auth.OauthClientCredentials.ForScopes("accounts:read", "accounts:admin"),
            requestOptions,
            cancellationToken);

    /// <summary>
    /// Get account by ID
    /// </summary>
    /// <param name="request">The operation's inputs</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="AccountRetrieveResponse"/> instance.</returns>
    /// <exception cref="ApiException{TError}"> of <see cref="RetrieveAccountError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// Returns the account specified by its ID, including its type, status, and the account group it belongs to.
    /// </remarks>
    public Task<AccountRetrieveResponse> RetrieveAccount(RetrieveAccountRequest request,
        RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute(
            _server.Default("/accounts/{account_id}"),
            [new TemplateParam("account_id", request.AccountId)],
            [],
            [new HeaderParam("upvest-api-version", request.UpvestApiVersion)],
            HttpMethod.Get,
            EmptyBody.Instance,
            JsonResponse.Create<AccountRetrieveResponse>(),
            RetrieveAccountError.Response,
            _auth.OauthClientCredentials.ForScopes("accounts:read", "accounts:admin"),
            requestOptions,
            cancellationToken);

    /// <summary>
    /// Update account by ID
    /// </summary>
    /// <param name="request">The operation's inputs</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="AccountUpdateResponse"/> instance.</returns>
    /// <exception cref="ApiException{TError}"> of <see cref="UpdateAccountError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// Updates the account specified by its ID.
    /// <para>
    /// Only the account <c>name</c> can be updated. Returns the full updated account object.
    /// </para>
    /// </remarks>
    public Task<AccountUpdateResponse> UpdateAccount(UpdateAccountRequest request,
        RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute(
            _server.Default("/accounts/{account_id}"),
            [new TemplateParam("account_id", request.AccountId)],
            [],
            [
                new HeaderParam("upvest-api-version", request.UpvestApiVersion),
                new HeaderParam("Idempotency-Key", Guid.NewGuid()),
            ],
            new HttpMethod("PATCH"),
            JsonRequest.Create(request.Body),
            JsonResponse.Create<AccountUpdateResponse>(),
            UpdateAccountError.Response,
            _auth.OauthClientCredentials.ForScopes("accounts:admin"),
            requestOptions,
            cancellationToken);
}
