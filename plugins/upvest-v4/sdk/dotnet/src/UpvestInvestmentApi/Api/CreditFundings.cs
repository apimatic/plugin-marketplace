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
using UpvestInvestmentApi.Requests.CreditFundings;

namespace UpvestInvestmentApi.Api;

/// <summary>
/// All credit fundings related paths
/// </summary>
public sealed class CreditFundings
{
    private readonly RawClient _rawClient;
    private readonly Server _server;
    private readonly AuthSchemes _auth;

    internal CreditFundings(RawClient rawClient, Server server, AuthSchemes auth)
    {
        _rawClient = rawClient;
        _server = server;
        _auth = auth;
    }

    /// <summary>
    /// List credit fundings
    /// </summary>
    /// <param name="request">The operation's inputs</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="PaymentsCreditFundingsListResponse"/> instance.</returns>
    /// <exception cref="ApiException{TError}"> of <see cref="ListCreditFundingsError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// Returns a paginated list of credit fundings for the account group specified by its ID. A credit funding represents an incoming SEPA Credit Transfer that has been received and applied to the account group.
    /// </remarks>
    public Task<PaymentsCreditFundingsListResponse> ListCreditFundings(ListCreditFundingsRequest request,
        RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute(
            _server.Default("/account_groups/{account_group_id}/payments/credit_fundings"),
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
            JsonResponse.Create<PaymentsCreditFundingsListResponse>(),
            ListCreditFundingsError.Response,
            _auth.OauthClientCredentials.ForScopes("credit_fundings:read", "payments:admin", "payments:read"),
            requestOptions,
            cancellationToken);

    /// <summary>
    /// Retrieve a credit funding
    /// </summary>
    /// <param name="request">The operation's inputs</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="PaymentsCreditFundingsResponse"/> instance.</returns>
    /// <exception cref="ApiException{TError}"> of <see cref="RetrieveCreditFundingError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// Returns the credit funding specified by its ID, including its status, cash amount, and counterparty details.
    /// </remarks>
    public Task<PaymentsCreditFundingsResponse> RetrieveCreditFunding(RetrieveCreditFundingRequest request,
        RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute(
            _server.Default("/payments/credit_fundings/{credit_funding_id}"),
            [new TemplateParam("credit_funding_id", request.CreditFundingId)],
            [],
            [new HeaderParam("upvest-api-version", request.UpvestApiVersion)],
            HttpMethod.Get,
            EmptyBody.Instance,
            JsonResponse.Create<PaymentsCreditFundingsResponse>(),
            RetrieveCreditFundingError.Response,
            _auth.OauthClientCredentials.ForScopes("credit_fundings:read", "payments:admin", "payments:read"),
            requestOptions,
            cancellationToken);

    /// <summary>
    /// Retrieve funding details
    /// </summary>
    /// <param name="request">The operation's inputs</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="AccountGroupsPaymentsCreditFundingDetailsResponse"/> instance.</returns>
    /// <exception cref="ApiException{TError}"> of <see cref="RetrieveFundingDetailsError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// Returns the virtual bank account details needed to fund an account group via SEPA Credit Transfer. Clients should present these details to end users so they can initiate the bank transfer.
    /// </remarks>
    public Task<AccountGroupsPaymentsCreditFundingDetailsResponse> RetrieveFundingDetails(RetrieveFundingDetailsRequest request,
        RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute(
            _server.Default("/account_groups/{account_group_id}/payments/credit_funding_details"),
            [new TemplateParam("account_group_id", request.AccountGroupId)],
            [new Param("limit", request.Limit), new Param("offset", request.Offset)],
            [new HeaderParam("upvest-api-version", request.UpvestApiVersion)],
            HttpMethod.Get,
            EmptyBody.Instance,
            JsonResponse.Create<AccountGroupsPaymentsCreditFundingDetailsResponse>(),
            RetrieveFundingDetailsError.Response,
            _auth.OauthClientCredentials.ForScopes("payments:admin", "payments:read"),
            requestOptions,
            cancellationToken);
}
