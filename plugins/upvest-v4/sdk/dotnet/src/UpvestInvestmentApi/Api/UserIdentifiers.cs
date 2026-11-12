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
using UpvestInvestmentApi.Requests.UserIdentifiers;

namespace UpvestInvestmentApi.Api;

/// <summary>
/// All user identifiers related paths.
/// </summary>
public sealed class UserIdentifiers
{
    private readonly RawClient _rawClient;
    private readonly Server _server;
    private readonly AuthSchemes _auth;

    internal UserIdentifiers(RawClient rawClient, Server server, AuthSchemes auth)
    {
        _rawClient = rawClient;
        _server = server;
        _auth = auth;
    }

    /// <summary>
    /// Create a user identifier
    /// </summary>
    /// <param name="request">The operation's inputs</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="Identifier"/> instance.</returns>
    /// <exception cref="ApiException{TError}"> of <see cref="CreateIdentifierError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// Creates a new identifier for a user that will be used for transaction reporting obligations. This identifier is required before the user's <c>OWNER</c> role can become active if the user's nationalities do not allow reporting using the CONCAT format.
    /// <para>
    /// See the User identifiers guide (<see href="https://docs.upvest.co/products/tol/guides/users/users_identifiers">TOL</see> / <see href="https://docs.upvest.co/products/byol/guides/users/users_identifiers">BYOL</see>) for details.
    /// </para>
    /// </remarks>
    public Task<Identifier> CreateIdentifier(CreateIdentifierRequest request,
        RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute(
            _server.Default("/users/{user_id}/identifiers"),
            [new TemplateParam("user_id", request.UserId)],
            [],
            [
                new HeaderParam("upvest-api-version", request.UpvestApiVersion),
                new HeaderParam("Idempotency-Key", Guid.NewGuid()),
            ],
            HttpMethod.Post,
            JsonRequest.Create(request.Body),
            JsonResponse.Create<Identifier>(),
            CreateIdentifierError.Response,
            _auth.OauthClientCredentials.ForScopes("users:admin"),
            requestOptions,
            cancellationToken);

    /// <summary>
    /// Get user identifiers
    /// </summary>
    /// <param name="request">The operation's inputs</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="IdentifiersListResponse"/> instance.</returns>
    /// <exception cref="ApiException{TError}"> of <see cref="ListUserIdentifiersError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// Lists all existing identifiers of a user used for transaction reporting.
    /// </remarks>
    public Task<IdentifiersListResponse> ListUserIdentifiers(ListUserIdentifiersRequest request,
        RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute(
            _server.Default("/users/{user_id}/identifiers"),
            [new TemplateParam("user_id", request.UserId)],
            [],
            [new HeaderParam("upvest-api-version", request.UpvestApiVersion)],
            HttpMethod.Get,
            EmptyBody.Instance,
            JsonResponse.Create<IdentifiersListResponse>(),
            ListUserIdentifiersError.Response,
            _auth.OauthClientCredentials.ForScopes("users:read", "users:admin"),
            requestOptions,
            cancellationToken);

    /// <summary>
    /// Get a user identifier by ID
    /// </summary>
    /// <param name="request">The operation's inputs</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="Identifier"/> instance.</returns>
    /// <exception cref="ApiException{TError}"> of <see cref="RetrieveIdentifierError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// Returns an existing identifier of a given user used for transaction reporting.
    /// </remarks>
    public Task<Identifier> RetrieveIdentifier(RetrieveIdentifierRequest request,
        RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute(
            _server.Default("/users/{user_id}/identifiers/{identifier_id}"),
            [new TemplateParam("user_id", request.UserId), new TemplateParam("identifier_id", request.IdentifierId)],
            [],
            [new HeaderParam("upvest-api-version", request.UpvestApiVersion)],
            HttpMethod.Get,
            EmptyBody.Instance,
            JsonResponse.Create<Identifier>(),
            RetrieveIdentifierError.Response,
            _auth.OauthClientCredentials.ForScopes("users:read", "users:admin"),
            requestOptions,
            cancellationToken);

    /// <summary>
    /// Update a user identifier by ID
    /// </summary>
    /// <param name="request">The operation's inputs</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="Identifier"/> instance.</returns>
    /// <exception cref="ApiException{TError}"> of <see cref="UpdateIdentifierError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// Updates an existing identifier of a given user used for transaction reporting.
    /// </remarks>
    public Task<Identifier> UpdateIdentifier(UpdateIdentifierRequest request,
        RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute(
            _server.Default("/users/{user_id}/identifiers/{identifier_id}"),
            [new TemplateParam("user_id", request.UserId), new TemplateParam("identifier_id", request.IdentifierId)],
            [],
            [
                new HeaderParam("upvest-api-version", request.UpvestApiVersion),
                new HeaderParam("Idempotency-Key", Guid.NewGuid()),
            ],
            new HttpMethod("PATCH"),
            JsonRequest.Create(request.Body),
            JsonResponse.Create<Identifier>(),
            UpdateIdentifierError.Response,
            _auth.OauthClientCredentials.ForScopes("users:admin"),
            requestOptions,
            cancellationToken);
}
