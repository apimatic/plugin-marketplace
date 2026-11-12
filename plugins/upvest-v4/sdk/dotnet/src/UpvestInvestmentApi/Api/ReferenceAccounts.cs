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
using UpvestInvestmentApi.Requests.ReferenceAccounts;

namespace UpvestInvestmentApi.Api;

/// <summary>
/// All reference account related paths
/// </summary>
public sealed class ReferenceAccounts
{
    private readonly RawClient _rawClient;
    private readonly Server _server;
    private readonly AuthSchemes _auth;

    internal ReferenceAccounts(RawClient rawClient, Server server, AuthSchemes auth)
    {
        _rawClient = rawClient;
        _server = server;
        _auth = auth;
    }

    /// <summary>
    /// Create a reference account
    /// </summary>
    /// <param name="request">The operation's inputs</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="ReferenceAccount"/> instance.</returns>
    /// <exception cref="ApiException{TError}"> of <see cref="CreateReferenceAccountError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// Creates a new reference account for a user or business specified by ID.
    /// </remarks>
    public Task<ReferenceAccount> CreateReferenceAccount(CreateReferenceAccountRequest request,
        RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute(
            _server.Default("/payments/reference_accounts"),
            [],
            [],
            [
                new HeaderParam("idempotency-key", request.IdempotencyKey),
                new HeaderParam("upvest-api-version", request.UpvestApiVersion),
            ],
            HttpMethod.Post,
            JsonRequest.Create(request.Body),
            JsonResponse.Create<ReferenceAccount>(),
            CreateReferenceAccountError.Response,
            _auth.OauthClientCredentials.ForScopes("reference_accounts:admin"),
            requestOptions,
            cancellationToken);

    /// <summary>
    /// Delete a reference account by ID
    /// </summary>
    /// <param name="request">The operation's inputs</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>A <see cref="Task"/> instance.</returns>
    /// <exception cref="ApiException{TError}"> of <see cref="DeleteReferenceAccountError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// Deletes the reference account specified by its ID.
    /// </remarks>
    public Task DeleteReferenceAccount(DeleteReferenceAccountRequest request,
        RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute(
            _server.Default("/payments/reference_accounts/{reference_account_id}"),
            [new TemplateParam("reference_account_id", request.ReferenceAccountId)],
            [],
            [
                new HeaderParam("upvest-api-version", request.UpvestApiVersion),
                new HeaderParam("Idempotency-Key", Guid.NewGuid()),
            ],
            HttpMethod.Delete,
            EmptyBody.Instance,
            VoidResponse.Instance,
            DeleteReferenceAccountError.Response,
            _auth.OauthClientCredentials.ForScopes("reference_accounts:admin"),
            requestOptions,
            cancellationToken);

    /// <summary>
    /// Get reference accounts of a business
    /// </summary>
    /// <param name="request">The operation's inputs</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="BusinessReferenceAccountsListResponse"/> instance.</returns>
    /// <exception cref="ApiException{TError}"> of <see cref="ListBusinessReferenceAccountsError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// Returns the list of reference accounts for a business specified by ID.
    /// </remarks>
    public Task<BusinessReferenceAccountsListResponse> ListBusinessReferenceAccounts(ListBusinessReferenceAccountsRequest request,
        RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute(
            _server.Default("/businesses/{business_id}/payments/reference_accounts"),
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
            JsonResponse.Create<BusinessReferenceAccountsListResponse>(),
            ListBusinessReferenceAccountsError.Response,
            _auth.OauthClientCredentials.ForScopes("reference_accounts:admin", "reference_accounts:read"),
            requestOptions,
            cancellationToken);

    /// <summary>
    /// Get reference accounts of a user
    /// </summary>
    /// <param name="request">The operation's inputs</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="UsersListResponse1"/> instance.</returns>
    /// <exception cref="ApiException{TError}"> of <see cref="ListReferenceAccountsError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// Returns the list of reference accounts of a user specified by ID.
    /// </remarks>
    public Task<UsersListResponse1> ListReferenceAccounts(ListReferenceAccountsRequest request,
        RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute(
            _server.Default("/users/{user_id}/payments/reference_accounts"),
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
            JsonResponse.Create<UsersListResponse1>(),
            ListReferenceAccountsError.Response,
            _auth.OauthClientCredentials.ForScopes("reference_accounts:admin", "reference_accounts:read"),
            requestOptions,
            cancellationToken);

    /// <summary>
    /// Get a reference account by ID
    /// </summary>
    /// <param name="request">The operation's inputs</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="ReferenceAccount"/> instance.</returns>
    /// <exception cref="ApiException{TError}"> of <see cref="RetrieveReferenceAccountError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// Retrieves the reference account specified by its ID.
    /// </remarks>
    public Task<ReferenceAccount> RetrieveReferenceAccount(RetrieveReferenceAccountRequest request,
        RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute(
            _server.Default("/payments/reference_accounts/{reference_account_id}"),
            [new TemplateParam("reference_account_id", request.ReferenceAccountId)],
            [],
            [new HeaderParam("upvest-api-version", request.UpvestApiVersion)],
            HttpMethod.Get,
            EmptyBody.Instance,
            JsonResponse.Create<ReferenceAccount>(),
            RetrieveReferenceAccountError.Response,
            _auth.OauthClientCredentials.ForScopes("reference_accounts:admin", "reference_accounts:read"),
            requestOptions,
            cancellationToken);
}
