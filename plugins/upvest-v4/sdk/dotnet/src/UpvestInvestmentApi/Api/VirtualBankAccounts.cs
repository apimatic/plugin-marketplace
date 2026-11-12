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
using UpvestInvestmentApi.Requests.VirtualBankAccounts;

namespace UpvestInvestmentApi.Api;

/// <summary>
/// All virtual bank accounts related paths
/// </summary>
public sealed class VirtualBankAccounts
{
    private readonly RawClient _rawClient;
    private readonly Server _server;
    private readonly AuthSchemes _auth;

    internal VirtualBankAccounts(RawClient rawClient, Server server, AuthSchemes auth)
    {
        _rawClient = rawClient;
        _server = server;
        _auth = auth;
    }

    /// <summary>
    /// Create a virtual bank account
    /// </summary>
    /// <param name="request">The operation's inputs</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="PaymentsVirtualBankAccountsResponse"/> instance.</returns>
    /// <exception cref="ApiException{TError}"> of <see cref="CreateVirtualBankAccountError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// Creates a virtual bank account for an account group. The virtual bank account provides an IBAN and BIC that end users can use to send SEPA Credit Transfers directly to their investment account.
    /// </remarks>
    public Task<PaymentsVirtualBankAccountsResponse> CreateVirtualBankAccount(CreateVirtualBankAccountRequest request,
        RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute(
            _server.Default("/payments/virtual_bank_accounts"),
            [],
            [],
            [
                new HeaderParam("idempotency-key", request.IdempotencyKey),
                new HeaderParam("upvest-api-version", request.UpvestApiVersion),
            ],
            HttpMethod.Post,
            JsonRequest.Create(request.Body),
            JsonResponse.Create<PaymentsVirtualBankAccountsResponse>(),
            CreateVirtualBankAccountError.Response,
            _auth.OauthClientCredentials.ForScopes("payments:admin"),
            requestOptions,
            cancellationToken);

    /// <summary>
    /// List virtual bank accounts
    /// </summary>
    /// <param name="request">The operation's inputs</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="PaymentsVirtualBankAccountsListResponse"/> instance.</returns>
    /// <exception cref="ApiException{TError}"> of <see cref="ListVirtualBankAccountsError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// Returns a list of virtual bank accounts.
    /// </remarks>
    public Task<PaymentsVirtualBankAccountsListResponse> ListVirtualBankAccounts(ListVirtualBankAccountsRequest request,
        RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute(
            _server.Default("/account_groups/{account_group_id}/payments/virtual_bank_accounts"),
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
            JsonResponse.Create<PaymentsVirtualBankAccountsListResponse>(),
            ListVirtualBankAccountsError.Response,
            _auth.OauthClientCredentials.ForScopes("payments:admin", "payments:read"),
            requestOptions,
            cancellationToken);

    /// <summary>
    /// Retrieve a virtual bank account by ID
    /// </summary>
    /// <param name="request">The operation's inputs</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="PaymentsVirtualBankAccountsResponse"/> instance.</returns>
    /// <exception cref="ApiException{TError}"> of <see cref="RetrieveVirtualBankAccountError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// Returns a virtual bank account specified by its ID.
    /// </remarks>
    public Task<PaymentsVirtualBankAccountsResponse> RetrieveVirtualBankAccount(RetrieveVirtualBankAccountRequest request,
        RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute(
            _server.Default("/payments/virtual_bank_accounts/{virtual_bank_account_id}"),
            [new TemplateParam("virtual_bank_account_id", request.VirtualBankAccountId)],
            [],
            [new HeaderParam("upvest-api-version", request.UpvestApiVersion)],
            HttpMethod.Get,
            EmptyBody.Instance,
            JsonResponse.Create<PaymentsVirtualBankAccountsResponse>(),
            RetrieveVirtualBankAccountError.Response,
            _auth.OauthClientCredentials.ForScopes("payments:admin", "payments:read"),
            requestOptions,
            cancellationToken);
}
