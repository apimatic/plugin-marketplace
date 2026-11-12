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
using UpvestInvestmentApi.Requests.TransactionFeesModels;

namespace UpvestInvestmentApi.Api;

/// <summary>
/// All transaction fees models related paths.
/// </summary>
public sealed class TransactionFeesModels
{
    private readonly RawClient _rawClient;
    private readonly Server _server;
    private readonly AuthSchemes _auth;

    internal TransactionFeesModels(RawClient rawClient, Server server, AuthSchemes auth)
    {
        _rawClient = rawClient;
        _server = server;
        _auth = auth;
    }

    /// <summary>
    /// Create a transaction fee model
    /// </summary>
    /// <param name="request">The operation's inputs</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="FeeConfiguration"/> instance.</returns>
    /// <exception cref="ApiException{TError}"> of <see cref="CreateTransactionFeeModelError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// Creates a transaction fee model that defines how per-order transaction fees are calculated — either as fixed cash amounts (<c>ABSOLUTE</c>) or in basis points of the order value (<c>RELATIVE</c>), with one or more tiers based on the order's cash amount.
    /// <para>
    /// Fee models are immutable once created; to change a fee structure, create a new model. Apply a model to an order by referencing its ID in the <c>fee_configuration</c> object of the order request.
    /// </para>
    /// <para>
    /// See the Building transaction fees guide (<see href="https://docs.upvest.co/products/tol/guides/fees/fees_transaction_fees_building">TOL</see> / <see href="https://docs.upvest.co/products/byol/guides/fees/fees_transaction_fees_building">BYOL</see>) for implementation details.
    /// </para>
    /// </remarks>
    public Task<FeeConfiguration> CreateTransactionFeeModel(CreateTransactionFeeModelRequest request,
        RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute(
            _server.Default("/transaction_fees/models"),
            [],
            [],
            [
                new HeaderParam("upvest-api-version", request.UpvestApiVersion),
                new HeaderParam("Idempotency-Key", Guid.NewGuid()),
            ],
            HttpMethod.Post,
            JsonRequest.Create(request.Body),
            JsonResponse.Create<FeeConfiguration>(),
            CreateTransactionFeeModelError.Response,
            _auth.OauthClientCredentials.ForScopes("transaction_fees:admin"),
            requestOptions,
            cancellationToken);

    /// <summary>
    /// List transaction fee models
    /// </summary>
    /// <param name="request">The operation's inputs</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="TransactionFeeModelsListResponse"/> instance.</returns>
    /// <exception cref="ApiException{TError}"> of <see cref="ListTransactionFeeModelsError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// Returns a paginated list of the transaction fee models created for your client account.
    /// <para>
    /// Use the <c>offset</c> and <c>limit</c> query parameters to page through results; <c>meta.total_count</c> gives the total number of matching fee models.
    /// </para>
    /// <para>
    /// See the Transaction fees guide (<see href="https://docs.upvest.co/products/tol/guides/fees/fees_transaction_fees_overview">TOL</see> / <see href="https://docs.upvest.co/products/byol/guides/fees/fees_transaction_fees_overview">BYOL</see>) for fee model concepts.
    /// </para>
    /// </remarks>
    public Task<TransactionFeeModelsListResponse> ListTransactionFeeModels(ListTransactionFeeModelsRequest request,
        RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute(
            _server.Default("/transaction_fees/models"),
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
            JsonResponse.Create<TransactionFeeModelsListResponse>(),
            ListTransactionFeeModelsError.Response,
            _auth.OauthClientCredentials.ForScopes("transaction_fees:admin", "transaction_fees:read"),
            requestOptions,
            cancellationToken);

    /// <summary>
    /// Get transaction fee model
    /// </summary>
    /// <param name="request">The operation's inputs</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="FeeConfiguration"/> instance.</returns>
    /// <exception cref="ApiException{TError}"> of <see cref="RetrieveTransactionFeeModelError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// Returns the transaction fee model with the given ID, including its currency, charge method, value type, and tier structure.
    /// <para>
    /// See the Transaction fees guide (<see href="https://docs.upvest.co/products/tol/guides/fees/fees_transaction_fees_overview">TOL</see> / <see href="https://docs.upvest.co/products/byol/guides/fees/fees_transaction_fees_overview">BYOL</see>) for fee model concepts.
    /// </para>
    /// </remarks>
    public Task<FeeConfiguration> RetrieveTransactionFeeModel(RetrieveTransactionFeeModelRequest request,
        RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute(
            _server.Default("/transaction_fees/models/{transaction_fee_model_id}"),
            [new TemplateParam("transaction_fee_model_id", request.TransactionFeeModelId)],
            [],
            [new HeaderParam("upvest-api-version", request.UpvestApiVersion)],
            HttpMethod.Get,
            EmptyBody.Instance,
            JsonResponse.Create<FeeConfiguration>(),
            RetrieveTransactionFeeModelError.Response,
            _auth.OauthClientCredentials.ForScopes("transaction_fees:admin", "transaction_fees:read"),
            requestOptions,
            cancellationToken);
}
