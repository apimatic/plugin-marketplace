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
using UpvestInvestmentApi.Requests.Isa;

namespace UpvestInvestmentApi.Api;

/// <summary>
/// ISA tax wrapper and transfer related paths.
/// </summary>
public sealed class Isa
{
    private readonly RawClient _rawClient;
    private readonly Server _server;
    private readonly AuthSchemes _auth;

    internal Isa(RawClient rawClient, Server server, AuthSchemes auth)
    {
        _rawClient = rawClient;
        _server = server;
        _auth = auth;
    }

    /// <summary>
    /// Create ISA transfer
    /// </summary>
    /// <param name="request">The operation's inputs</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="IsaTransfersResponse"/> instance.</returns>
    /// <exception cref="ApiException{TError}"> of <see cref="CreateIsaTransferError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// Creates an ISA transfer, moving all or part of an end user's existing ISA into an Upvest Stocks and Shares ISA while preserving their current-year allowance.
    /// <para>
    /// See the ISA transfers implementation guide (<see href="https://docs.upvest.co/products/tol/guides/tax_wrappers/tax_wrappers_isa_transfers_implementation">TOL</see> / <see href="https://docs.upvest.co/products/byol/guides/tax_wrappers/tax_wrappers_isa_transfers_implementation">BYOL</see>) for the required fields per transfer type.
    /// </para>
    /// </remarks>
    public Task<IsaTransfersResponse> CreateIsaTransfer(CreateIsaTransferRequest request,
        RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute(
            _server.Default("/isa/transfers"),
            [],
            [],
            [
                new HeaderParam("idempotency-key", request.IdempotencyKey),
                new HeaderParam("upvest-api-version", request.UpvestApiVersion),
            ],
            HttpMethod.Post,
            JsonRequest.Create(request.Body),
            JsonResponse.Create<IsaTransfersResponse>(),
            CreateIsaTransferError.Response,
            _auth.OauthClientCredentials.ForScopes("isa:admin"),
            requestOptions,
            cancellationToken);

    /// <summary>
    /// Create a tax wrapper for ISA account
    /// </summary>
    /// <param name="request">The operation's inputs</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="TaxWrappersIsaIsaWrapper"/> instance.</returns>
    /// <exception cref="ApiException{TError}"> of <see cref="CreateIsaWrapperError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// Creates an ISA tax wrapper for an account group, holding the business rules that apply to the tax-wrapped product.
    /// <para>
    /// The account group must have been created with <c>type</c> set to <c>ISA</c>. For a <c>STOCKS_AND_SHARES_ISA</c>, set <c>is_flexible</c> to indicate whether the end user may replace withdrawals within the same tax year without using up their annual allowance. A tax wrapper stays inactive until the end user's tax residency has been confirmed, and the ISA account group cannot become <c>ACTIVE</c> until the tax wrapper does.
    /// </para>
    /// <para>
    /// See the ISA tax wrapper integration guide (<see href="https://docs.upvest.co/products/tol/guides/tax_wrappers/pension_de/tax_wrappers/pension_de_isa_integration">TOL</see> / <see href="https://docs.upvest.co/products/byol/guides/tax_wrappers/pension_de/tax_wrappers/pension_de_isa_integration">BYOL</see>) for the onboarding and activation sequence.
    /// </para>
    /// </remarks>
    public Task<TaxWrappersIsaIsaWrapper> CreateIsaWrapper(CreateIsaWrapperRequest request,
        RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute(
            _server.Default("/isa/wrappers"),
            [],
            [],
            [
                new HeaderParam("idempotency-key", request.IdempotencyKey),
                new HeaderParam("upvest-api-version", request.UpvestApiVersion),
            ],
            HttpMethod.Post,
            JsonRequest.Create(request.Body),
            JsonResponse.Create<TaxWrappersIsaIsaWrapper>(),
            CreateIsaWrapperError.Response,
            _auth.OauthClientCredentials.ForScopes("taxes:admin", "isa:admin"),
            requestOptions,
            cancellationToken);

    /// <summary>
    /// Retrieve ISA allowances
    /// </summary>
    /// <param name="request">The operation's inputs</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="TaxWrappersIsaRetrieveIsaAllowancesResponse"/> instance.</returns>
    /// <exception cref="ApiException{TError}"> of <see cref="RetrieveIsaAllowancesError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// Returns the ISA allowances of the tax wrapper identified by <c>tax_wrapper_id</c>.
    /// <para>
    /// An <c>ANNUAL</c> allowance covers one UK tax year, which runs from 6 April to 5 April and is identified in <c>yyyy/yyyy</c> form. Allowances expire at <c>valid_to</c> and do not roll over; a new allowance is created at the start of each tax year.
    /// </para>
    /// <para>
    /// See the ISA tax wrapper integration guide (<see href="https://docs.upvest.co/products/tol/guides/tax_wrappers/pension_de/tax_wrappers/pension_de_isa_integration">TOL</see> / <see href="https://docs.upvest.co/products/byol/guides/tax_wrappers/pension_de/tax_wrappers/pension_de_isa_integration">BYOL</see>) for the onboarding and activation sequence.
    /// </para>
    /// </remarks>
    public Task<TaxWrappersIsaRetrieveIsaAllowancesResponse> RetrieveIsaAllowances(RetrieveIsaAllowancesRequest request,
        RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute(
            _server.Default("/isa/wrappers/{tax_wrapper_id}/allowances"),
            [new TemplateParam("tax_wrapper_id", request.TaxWrapperId)],
            [
                new Param("tax_year", request.TaxYear),
                new Param("sort", request.Sort),
                new Param("order", request.Order),
                new Param("offset", request.Offset),
                new Param("limit", request.Limit),
            ],
            [new HeaderParam("upvest-api-version", request.UpvestApiVersion)],
            HttpMethod.Get,
            EmptyBody.Instance,
            JsonResponse.Create<TaxWrappersIsaRetrieveIsaAllowancesResponse>(),
            RetrieveIsaAllowancesError.Response,
            _auth.OauthClientCredentials.ForScopes("taxes:admin", "isa:admin"),
            requestOptions,
            cancellationToken);
}
