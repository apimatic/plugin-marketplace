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
using UpvestInvestmentApi.Requests.Mandates;

namespace UpvestInvestmentApi.Api;

/// <summary>
/// All direct debit mandates related paths
/// </summary>
public sealed class Mandates
{
    private readonly RawClient _rawClient;
    private readonly Server _server;
    private readonly AuthSchemes _auth;

    internal Mandates(RawClient rawClient, Server server, AuthSchemes auth)
    {
        _rawClient = rawClient;
        _server = server;
        _auth = auth;
    }

    /// <summary>
    /// Create a mandate
    /// </summary>
    /// <param name="request">The operation's inputs</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="DirectDebitMandate"/> instance.</returns>
    /// <exception cref="ApiException{TError}"> of <see cref="CreateMandateError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// Create a mandate.
    /// <para>
    /// Supports both user and business accounts. Provide <c>user_id</c> for user flows or <c>business_id</c> for business flows — exactly one must be specified.
    /// </para>
    /// </remarks>
    public Task<DirectDebitMandate> CreateMandate(CreateMandateRequest request,
        RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute(
            _server.Default("/payments/mandates"),
            [],
            [],
            [
                new HeaderParam("idempotency-key", request.IdempotencyKey),
                new HeaderParam("upvest-api-version", request.UpvestApiVersion),
            ],
            HttpMethod.Post,
            JsonRequest.Create(request.Body),
            JsonResponse.Create<DirectDebitMandate>(),
            CreateMandateError.Response,
            _auth.OauthClientCredentials.ForScopes("mandates:admin"),
            requestOptions,
            cancellationToken);

    /// <summary>
    /// Delete mandate
    /// </summary>
    /// <param name="request">The operation's inputs</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>A <see cref="Task"/> instance.</returns>
    /// <exception cref="ApiException{TError}"> of <see cref="DeleteMandateError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// Deletes the direct debit mandate specified by its ID. Deletion permanently removes the mandate; associated direct debits already in progress are not affected.
    /// </remarks>
    public Task DeleteMandate(DeleteMandateRequest request,
        RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute(
            _server.Default("/payments/mandates/{mandate_id}"),
            [new TemplateParam("mandate_id", request.MandateId)],
            [],
            [
                new HeaderParam("upvest-api-version", request.UpvestApiVersion),
                new HeaderParam("Idempotency-Key", Guid.NewGuid()),
            ],
            HttpMethod.Delete,
            EmptyBody.Instance,
            VoidResponse.Instance,
            DeleteMandateError.Response,
            _auth.OauthClientCredentials.ForScopes("mandates:admin"),
            requestOptions,
            cancellationToken);

    /// <summary>
    /// List mandates for a business
    /// </summary>
    /// <param name="request">The operation's inputs</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="MandatesListBusinessResponse"/> instance.</returns>
    /// <exception cref="ApiException{TError}"> of <see cref="ListBusinessMandatesError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// Returns a paginated list of direct debit mandates for the business specified by its ID.
    /// </remarks>
    public Task<MandatesListBusinessResponse> ListBusinessMandates(ListBusinessMandatesRequest request,
        RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute(
            _server.Default("/businesses/{business_id}/payments/mandates"),
            [new TemplateParam("business_id", request.BusinessId)],
            [
                new Param("sort", request.Sort),
                new Param("order", request.Order),
                new Param("limit", request.Limit),
                new Param("offset", request.Offset),
            ],
            [new HeaderParam("upvest-api-version", request.UpvestApiVersion)],
            HttpMethod.Get,
            EmptyBody.Instance,
            JsonResponse.Create<MandatesListBusinessResponse>(),
            ListBusinessMandatesError.Response,
            _auth.OauthClientCredentials.ForScopes("mandates:admin", "mandates:read"),
            requestOptions,
            cancellationToken);

    /// <summary>
    /// List mandates
    /// </summary>
    /// <param name="request">The operation's inputs</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="MandatesListResponse"/> instance.</returns>
    /// <exception cref="ApiException{TError}"> of <see cref="ListMandatesError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// Returns a paginated list of direct debit mandates for the user specified by their ID.
    /// </remarks>
    public Task<MandatesListResponse> ListMandates(ListMandatesRequest request,
        RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute(
            _server.Default("/users/{user_id}/payments/mandates"),
            [new TemplateParam("user_id", request.UserId)],
            [
                new Param("sort", request.Sort),
                new Param("order", request.Order),
                new Param("limit", request.Limit),
                new Param("offset", request.Offset),
            ],
            [new HeaderParam("upvest-api-version", request.UpvestApiVersion)],
            HttpMethod.Get,
            EmptyBody.Instance,
            JsonResponse.Create<MandatesListResponse>(),
            ListMandatesError.Response,
            _auth.OauthClientCredentials.ForScopes("mandates:admin", "mandates:read"),
            requestOptions,
            cancellationToken);

    /// <summary>
    /// Retrieve a direct debit mandate
    /// </summary>
    /// <param name="request">The operation's inputs</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="DirectDebitMandate"/> instance.</returns>
    /// <exception cref="ApiException{TError}"> of <see cref="RetrieveMandateError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// Retrieve a direct debit mandate.
    /// <para>
    /// The response contains either <c>user_id</c> or <c>business_id</c> depending on whether the mandate belongs to a user or business account.
    /// </para>
    /// </remarks>
    public Task<DirectDebitMandate> RetrieveMandate(RetrieveMandateRequest request,
        RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute(
            _server.Default("/payments/mandates/{mandate_id}"),
            [new TemplateParam("mandate_id", request.MandateId)],
            [],
            [new HeaderParam("upvest-api-version", request.UpvestApiVersion)],
            HttpMethod.Get,
            EmptyBody.Instance,
            JsonResponse.Create<DirectDebitMandate>(),
            RetrieveMandateError.Response,
            _auth.OauthClientCredentials.ForScopes("mandates:admin", "mandates:read"),
            requestOptions,
            cancellationToken);
}
