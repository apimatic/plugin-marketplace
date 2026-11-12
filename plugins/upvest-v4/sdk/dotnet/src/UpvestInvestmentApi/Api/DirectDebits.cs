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
using UpvestInvestmentApi.Requests.DirectDebits;

namespace UpvestInvestmentApi.Api;

/// <summary>
/// All direct debits related paths
/// </summary>
public sealed class DirectDebits
{
    private readonly RawClient _rawClient;
    private readonly Server _server;
    private readonly AuthSchemes _auth;

    internal DirectDebits(RawClient rawClient, Server server, AuthSchemes auth)
    {
        _rawClient = rawClient;
        _server = server;
        _auth = auth;
    }

    /// <summary>
    /// Trigger a direct debit
    /// </summary>
    /// <param name="request">The operation's inputs</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="PaymentsDirectDebitsResponse"/> instance.</returns>
    /// <exception cref="ApiException{TError}"> of <see cref="CreateDirectDebitError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// Trigger a direct debit.
    /// <para>
    /// <b>Deprecation notice:</b> The <c>user_id</c> field is deprecated, optional, and will be removed in a future version. For business account direct debits, ownership is determined by the mandate linked to the business.
    /// </para>
    /// </remarks>
    public Task<PaymentsDirectDebitsResponse> CreateDirectDebit(CreateDirectDebitRequest request,
        RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute(
            _server.Default("/payments/direct_debits"),
            [],
            [],
            [
                new HeaderParam("idempotency-key", request.IdempotencyKey),
                new HeaderParam("upvest-api-version", request.UpvestApiVersion),
            ],
            HttpMethod.Post,
            JsonRequest.Create(request.Body),
            JsonResponse.Create<PaymentsDirectDebitsResponse>(),
            CreateDirectDebitError.Response,
            _auth.OauthClientCredentials.ForScopes("payments:admin"),
            requestOptions,
            cancellationToken);

    /// <summary>
    /// List direct debits
    /// </summary>
    /// <param name="request">The operation's inputs</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="PaymentsDirectDebitsListResponse"/> instance.</returns>
    /// <exception cref="ApiException{TError}"> of <see cref="ListDirectDebitsError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// Returns a paginated list of direct debits for the account group specified by its ID.
    /// </remarks>
    public Task<PaymentsDirectDebitsListResponse> ListDirectDebits(ListDirectDebitsRequest request,
        RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute(
            _server.Default("/account_groups/{account_group_id}/payments/direct_debits"),
            [new TemplateParam("account_group_id", request.AccountGroupId)],
            [
                new Param("sort", request.Sort),
                new Param("order", request.Order),
                new Param("limit", request.Limit),
                new Param("offset", request.Offset),
            ],
            [new HeaderParam("upvest-api-version", request.UpvestApiVersion)],
            HttpMethod.Get,
            EmptyBody.Instance,
            JsonResponse.Create<PaymentsDirectDebitsListResponse>(),
            ListDirectDebitsError.Response,
            _auth.OauthClientCredentials.ForScopes("payments:admin", "payments:read"),
            requestOptions,
            cancellationToken);

    /// <summary>
    /// Retrieve a direct debit
    /// </summary>
    /// <param name="request">The operation's inputs</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="PaymentsDirectDebitsResponse"/> instance.</returns>
    /// <exception cref="ApiException{TError}"> of <see cref="RetrieveDirectDebitError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// Returns the direct debit specified by its ID, including its current status, cash amount, mandate reference, and any cancellation reason.
    /// </remarks>
    public Task<PaymentsDirectDebitsResponse> RetrieveDirectDebit(RetrieveDirectDebitRequest request,
        RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute(
            _server.Default("/payments/direct_debits/{direct_debit_id}"),
            [new TemplateParam("direct_debit_id", request.DirectDebitId)],
            [],
            [new HeaderParam("upvest-api-version", request.UpvestApiVersion)],
            HttpMethod.Get,
            EmptyBody.Instance,
            JsonResponse.Create<PaymentsDirectDebitsResponse>(),
            RetrieveDirectDebitError.Response,
            _auth.OauthClientCredentials.ForScopes("payments:admin", "payments:read"),
            requestOptions,
            cancellationToken);
}
