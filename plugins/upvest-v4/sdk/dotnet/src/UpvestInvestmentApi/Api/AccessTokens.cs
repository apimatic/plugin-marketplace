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
using UpvestInvestmentApi.Requests.AccessTokens;

namespace UpvestInvestmentApi.Api;

/// <summary>
/// All authentication related paths.
/// </summary>
public sealed class AccessTokens
{
    private readonly RawClient _rawClient;
    private readonly Server _server;

    internal AccessTokens(RawClient rawClient, Server server)
    {
        _rawClient = rawClient;
        _server = server;
    }

    /// <summary>
    /// Get an access token for requested scopes
    /// </summary>
    /// <param name="request">The operation's inputs</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="AuthAccessToken"/> instance.</returns>
    /// <exception cref="ApiException{TError}"> of <see cref="IssueTokenError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// Get an access token to use with the API with specified scopes.
    /// <para>
    /// You should _always_ scope your access tokens. You get one for read-access and separate ones for updating, creating or deleting resources.
    /// </para>
    /// </remarks>
    public Task<AuthAccessToken> IssueToken(IssueTokenRequest request,
        RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute(
            _server.Default("/auth/token"),
            [],
            [],
            [
                new HeaderParam("upvest-api-version", request.UpvestApiVersion),
                new HeaderParam("Idempotency-Key", Guid.NewGuid()),
            ],
            HttpMethod.Post,
            FormUrlEncodedRequest.Create(
                new Param("client_id", request.ClientId),
                new Param("client_secret", request.ClientSecret),
                new Param("grant_type", request.GrantType),
                new Param("scope", request.Scope)),
            JsonResponse.Create<AuthAccessToken>(),
            IssueTokenError.Response,
            AuthScheme.None,
            requestOptions,
            cancellationToken);
}
