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
using UpvestInvestmentApi.Requests.BusinessChecks;

namespace UpvestInvestmentApi.Api;

/// <summary>
/// All Business Checks related paths.
/// </summary>
public sealed class BusinessChecks
{
    private readonly RawClient _rawClient;
    private readonly Server _server;
    private readonly AuthSchemes _auth;

    internal BusinessChecks(RawClient rawClient, Server server, AuthSchemes auth)
    {
        _rawClient = rawClient;
        _server = server;
        _auth = auth;
    }

    /// <summary>
    /// Create a new check for a business
    /// </summary>
    /// <param name="request">The operation's inputs</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="BusinessCheckCreateResponse"/> instance.</returns>
    /// <exception cref="ApiException{TError}"> of <see cref="CreateBusinessCheckError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// Creates a new check for a business specified by ID.
    /// </remarks>
    public Task<BusinessCheckCreateResponse> CreateBusinessCheck(CreateBusinessCheckRequest request,
        RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute(
            _server.Default("/businesses/{business_id}/checks"),
            [new TemplateParam("business_id", request.BusinessId)],
            [],
            [
                new HeaderParam("upvest-api-version", request.UpvestApiVersion),
                new HeaderParam("Idempotency-Key", Guid.NewGuid()),
            ],
            HttpMethod.Post,
            JsonRequest.Create(request.Body),
            JsonResponse.Create<BusinessCheckCreateResponse>(),
            CreateBusinessCheckError.Response,
            _auth.OauthClientCredentials.ForScopes("checks:admin"),
            requestOptions,
            cancellationToken);

    /// <summary>
    /// List checks for a business
    /// </summary>
    /// <param name="request">The operation's inputs</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="BusinessCheckListResponse"/> instance.</returns>
    /// <exception cref="ApiException{TError}"> of <see cref="ListBusinessChecksError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// Lists all checks for a business specified by ID.
    /// </remarks>
    public Task<BusinessCheckListResponse> ListBusinessChecks(ListBusinessChecksRequest request,
        RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute(
            _server.Default("/businesses/{business_id}/checks"),
            [new TemplateParam("business_id", request.BusinessId)],
            [],
            [new HeaderParam("upvest-api-version", request.UpvestApiVersion)],
            HttpMethod.Get,
            EmptyBody.Instance,
            JsonResponse.Create<BusinessCheckListResponse>(),
            ListBusinessChecksError.Response,
            _auth.OauthClientCredentials.ForScopes("checks:read", "checks:admin"),
            requestOptions,
            cancellationToken);

    /// <summary>
    /// Get a business check by ID
    /// </summary>
    /// <param name="request">The operation's inputs</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="BusinessCheck"/> instance.</returns>
    /// <exception cref="ApiException{TError}"> of <see cref="RetrieveBusinessCheckError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// Retrieves a check for a business specified by its ID.
    /// </remarks>
    public Task<BusinessCheck> RetrieveBusinessCheck(RetrieveBusinessCheckRequest request,
        RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute(
            _server.Default("/businesses/{business_id}/checks/{check_id}"),
            [new TemplateParam("business_id", request.BusinessId), new TemplateParam("check_id", request.CheckId)],
            [],
            [new HeaderParam("upvest-api-version", request.UpvestApiVersion)],
            HttpMethod.Get,
            EmptyBody.Instance,
            JsonResponse.Create<BusinessCheck>(),
            RetrieveBusinessCheckError.Response,
            _auth.OauthClientCredentials.ForScopes("checks:read", "checks:admin"),
            requestOptions,
            cancellationToken);
}
