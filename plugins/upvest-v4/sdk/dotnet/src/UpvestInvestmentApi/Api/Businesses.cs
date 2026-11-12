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
using UpvestInvestmentApi.Requests.Businesses;

namespace UpvestInvestmentApi.Api;

/// <summary>
/// All Businesses related paths.
/// </summary>
public sealed class Businesses
{
    private readonly RawClient _rawClient;
    private readonly Server _server;
    private readonly AuthSchemes _auth;

    internal Businesses(RawClient rawClient, Server server, AuthSchemes auth)
    {
        _rawClient = rawClient;
        _server = server;
        _auth = auth;
    }

    /// <summary>
    /// Change business data
    /// </summary>
    /// <param name="request">The operation's inputs</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>A <see cref="Task"/> instance.</returns>
    /// <exception cref="ApiException{TError}"> of <see cref="BusinessDataChangeError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// Requests a data change for a business specified by ID.
    /// </remarks>
    public Task BusinessDataChange(BusinessDataChangeRequest request,
        RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute(
            _server.Default("/businesses/{business_id}/data_change_requests"),
            [new TemplateParam("business_id", request.BusinessId)],
            [],
            [
                new HeaderParam("upvest-api-version", request.UpvestApiVersion),
                new HeaderParam("Idempotency-Key", Guid.NewGuid()),
            ],
            HttpMethod.Post,
            JsonRequest.Create(request.Body),
            VoidResponse.Instance,
            BusinessDataChangeError.Response,
            _auth.OauthClientCredentials.ForScopes("businesses:admin"),
            requestOptions,
            cancellationToken);

    /// <summary>
    /// Create a business
    /// </summary>
    /// <param name="request">The operation's inputs</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="BusinessCreateRequest1"/> instance.</returns>
    /// <exception cref="ApiException{TError}"> of <see cref="CreateBusinessError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// Creates a business.
    /// <para>
    /// Supports both corporate and sole trader business types, each with a different set of required fields.
    /// </para>
    /// <para>
    /// See the Business accounts guide (<see href="https://docs.upvest.co/products/tol/guides/accounts/businesses_overview">TOL</see> / <see href="https://docs.upvest.co/products/byol/guides/accounts/businesses_overview">BYOL</see>) for implementation details.
    /// </para>
    /// </remarks>
    public Task<BusinessCreateRequest1> CreateBusiness(CreateBusinessRequest request,
        RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute(
            _server.Default("/businesses"),
            [],
            [],
            [
                new HeaderParam("idempotency-key", request.IdempotencyKey),
                new HeaderParam("upvest-api-version", request.UpvestApiVersion),
            ],
            HttpMethod.Post,
            JsonRequest.Create(request.Body),
            JsonResponse.Create<BusinessCreateRequest1>(),
            CreateBusinessError.Response,
            _auth.OauthClientCredentials.ForScopes("businesses:admin"),
            requestOptions,
            cancellationToken);

    /// <summary>
    /// Get all businesses
    /// </summary>
    /// <param name="request">The operation's inputs</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="BusinessesListResponse"/> instance.</returns>
    /// <exception cref="ApiException{TError}"> of <see cref="ListBusinessesError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// Returns a paginated list of all businesses.
    /// <para>
    /// Use <c>offset</c> and <c>limit</c> to paginate through results, and <c>sort</c>/<c>order</c> to control the ordering by <c>created_at</c> or <c>updated_at</c>.
    /// </para>
    /// <para>
    /// See the Business accounts guide (<see href="https://docs.upvest.co/products/tol/guides/accounts/businesses_overview">TOL</see> / <see href="https://docs.upvest.co/products/byol/guides/accounts/businesses_overview">BYOL</see>) for business account types.
    /// </para>
    /// </remarks>
    public Task<BusinessesListResponse> ListBusinesses(ListBusinessesRequest request,
        RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute(
            _server.Default("/businesses"),
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
            JsonResponse.Create<BusinessesListResponse>(),
            ListBusinessesError.Response,
            _auth.OauthClientCredentials.ForScopes("businesses:read", "businesses:admin"),
            requestOptions,
            cancellationToken);

    /// <summary>
    /// Get a business by ID
    /// </summary>
    /// <param name="request">The operation's inputs</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="BusinessesResponse2"/> instance.</returns>
    /// <exception cref="ApiException{TError}"> of <see cref="RetrieveBusinessError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// Returns the business identified by <c>business_id</c>, including profile and status details
    /// </remarks>
    public Task<BusinessesResponse2> RetrieveBusiness(RetrieveBusinessRequest request,
        RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute(
            _server.Default("/businesses/{business_id}"),
            [new TemplateParam("business_id", request.BusinessId)],
            [],
            [new HeaderParam("upvest-api-version", request.UpvestApiVersion)],
            HttpMethod.Get,
            EmptyBody.Instance,
            JsonResponse.Create<BusinessesResponse2>(),
            RetrieveBusinessError.Response,
            _auth.OauthClientCredentials.ForScopes("businesses:read", "businesses:admin"),
            requestOptions,
            cancellationToken);
}
