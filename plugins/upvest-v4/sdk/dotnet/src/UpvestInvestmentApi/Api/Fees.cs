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
using UpvestInvestmentApi.Requests.Fees;

namespace UpvestInvestmentApi.Api;

/// <summary>
/// All fees related paths.
/// </summary>
public sealed class Fees
{
    private readonly RawClient _rawClient;
    private readonly Server _server;
    private readonly AuthSchemes _auth;

    internal Fees(RawClient rawClient, Server server, AuthSchemes auth)
    {
        _rawClient = rawClient;
        _server = server;
        _auth = auth;
    }

    /// <summary>
    /// Create a fee collection
    /// </summary>
    /// <param name="request">The operation's inputs</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="FeeCollection"/> instance.</returns>
    /// <exception cref="ApiException{TError}"> of <see cref="CreateFeeCollectionError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// Creates a fee collection for a fee amount you have already calculated.
    /// <para>
    /// The account must not be in <c>PENDING_APPROVAL</c> or <c>CLOSED</c> status; a request against an account in either status is rejected with a <c>400</c> response. Set <c>type</c> to <c>SERVICE_FEE</c> for collections that follow your normal fee cadence.
    /// </para>
    /// <para>
    /// See the Fee collection guide (<see href="https://docs.upvest.co/products/tol/guides/fees/fees_collection">TOL</see> / <see href="https://docs.upvest.co/products/byol/guides/fees/fees_collection">BYOL</see>) for the collection lifecycle and webhook events.
    /// </para>
    /// </remarks>
    public Task<FeeCollection> CreateFeeCollection(CreateFeeCollectionRequest request,
        RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute(
            _server.Default("/fees/collections"),
            [],
            [],
            [
                new HeaderParam("idempotency-key", request.IdempotencyKey),
                new HeaderParam("upvest-api-version", request.UpvestApiVersion),
            ],
            HttpMethod.Post,
            JsonRequest.Create(request.Body),
            JsonResponse.Create<FeeCollection>(),
            CreateFeeCollectionError.Response,
            _auth.OauthClientCredentials.ForScopes("fees:admin"),
            requestOptions,
            cancellationToken);

    /// <summary>
    /// Get fee collections
    /// </summary>
    /// <param name="request">The operation's inputs</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="FeeCollectionListResponse"/> instance.</returns>
    /// <exception cref="ApiException{TError}"> of <see cref="ListFeeCollectionsError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// Returns the list of fee collections.
    /// <para>
    /// Use the <c>offset</c> and <c>limit</c> query parameters to page through results; <c>meta.total_count</c> gives the total number of matching fee collections. Narrow the result set with the <c>account_id</c> and <c>account_group_id</c> query parameters.
    /// </para>
    /// <para>
    /// See the Fee collection guide (<see href="https://docs.upvest.co/products/tol/guides/fees/fees_collection">TOL</see> / <see href="https://docs.upvest.co/products/byol/guides/fees/fees_collection">BYOL</see>) for the collection lifecycle and webhook events.
    /// </para>
    /// </remarks>
    public Task<FeeCollectionListResponse> ListFeeCollections(ListFeeCollectionsRequest request,
        RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute(
            _server.Default("/fees/collections"),
            [],
            [
                new Param("account_id", request.AccountId),
                new Param("account_group_id", request.AccountGroupId),
                new Param("sort", request.Sort),
                new Param("order", request.Order),
                new Param("offset", request.Offset),
                new Param("limit", request.Limit),
            ],
            [new HeaderParam("upvest-api-version", request.UpvestApiVersion)],
            HttpMethod.Get,
            EmptyBody.Instance,
            JsonResponse.Create<FeeCollectionListResponse>(),
            ListFeeCollectionsError.Response,
            _auth.OauthClientCredentials.ForScopes("fees:read", "fees:admin"),
            requestOptions,
            cancellationToken);

    /// <summary>
    /// Get a fee collection by ID
    /// </summary>
    /// <param name="request">The operation's inputs</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="FeeCollection"/> instance.</returns>
    /// <exception cref="ApiException{TError}"> of <see cref="RetrieveFeeCollectionError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// Returns the fee collection identified by <c>fee_collection_id</c>, including its status and the amount processed so far.
    /// <para>
    /// A fee collection moves through <c>PROCESSING</c>, then either <c>FINALISED</c> once the fees have been collected from the account and transferred to you, or <c>CANCELLED</c>.
    /// </para>
    /// <para>
    /// See the Fee collection guide (<see href="https://docs.upvest.co/products/tol/guides/fees/fees_collection">TOL</see> / <see href="https://docs.upvest.co/products/byol/guides/fees/fees_collection">BYOL</see>) for the collection lifecycle and webhook events.
    /// </para>
    /// </remarks>
    public Task<FeeCollection> RetrieveFeeCollection(RetrieveFeeCollectionRequest request,
        RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute(
            _server.Default("/fees/collections/{fee_collection_id}"),
            [new TemplateParam("fee_collection_id", request.FeeCollectionId)],
            [],
            [new HeaderParam("upvest-api-version", request.UpvestApiVersion)],
            HttpMethod.Get,
            EmptyBody.Instance,
            JsonResponse.Create<FeeCollection>(),
            RetrieveFeeCollectionError.Response,
            _auth.OauthClientCredentials.ForScopes("fees:read", "fees:admin"),
            requestOptions,
            cancellationToken);
}
