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
using UpvestInvestmentApi.Requests.SecuritiesTransfers;

namespace UpvestInvestmentApi.Api;

/// <summary>
/// All Securities Transfers related paths.
/// </summary>
public sealed class SecuritiesTransfers
{
    private readonly RawClient _rawClient;
    private readonly Server _server;
    private readonly AuthSchemes _auth;

    internal SecuritiesTransfers(RawClient rawClient, Server server, AuthSchemes auth)
    {
        _rawClient = rawClient;
        _server = server;
        _auth = auth;
    }

    /// <summary>
    /// Create securities transfer
    /// </summary>
    /// <param name="request">The operation's inputs</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="SecuritiesTransfersResponse"/> instance.</returns>
    /// <exception cref="ApiException{TError}"> of <see cref="CreateSecuritiesTransferError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// Creates a securities transfer, moving a position in a single instrument between an Upvest account and an external custodian.
    /// <para>
    /// Set <c>direction</c> to <c>INCOMING</c> to move securities into an Upvest account, or <c>OUTGOING</c> to move them out to an external custodian. Only full units can be transferred — fractional quantities are not supported by the SWIFT messaging used for settlement. Unfulfilled incoming transfer requests are cancelled automatically after 30 days.
    /// </para>
    /// <para>
    /// See the securities transfers guide (<see href="https://docs.upvest.co/products/tol/guides/transfers/securities_transfers_overview">TOL</see> / <see href="https://docs.upvest.co/products/byol/guides/transfers/securities_transfers_overview">BYOL</see> / <see href="https://docs.upvest.co/products/omnibus/guides/transfers/securities_transfers_overview">Omnibus</see>) for the transfer stages and settlement details.
    /// </para>
    /// </remarks>
    public Task<SecuritiesTransfersResponse> CreateSecuritiesTransfer(CreateSecuritiesTransferRequest request,
        RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute(
            _server.Default("/securities_transfers"),
            [],
            [],
            [
                new HeaderParam("idempotency-key", request.IdempotencyKey),
                new HeaderParam("upvest-api-version", request.UpvestApiVersion),
            ],
            HttpMethod.Post,
            JsonRequest.Create(request.Body),
            JsonResponse.Create<SecuritiesTransfersResponse>(),
            CreateSecuritiesTransferError.Response,
            _auth.OauthClientCredentials.ForScopes("securities_transfers:admin"),
            requestOptions,
            cancellationToken);

    /// <summary>
    /// List securities transfers
    /// </summary>
    /// <param name="request">The operation's inputs</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="SecurityTransfersListResponse"/> instance.</returns>
    /// <exception cref="ApiException{TError}"> of <see cref="ListSecuritiesTransfersError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// Returns the list of securities transfers.
    /// <para>
    /// Restrict the list to one direction with the <c>direction</c> query parameter, and page through results with the <c>offset</c> and <c>limit</c> query parameters; <c>meta.total_count</c> gives the total number of matching transfers.
    /// </para>
    /// <para>
    /// See the securities transfers guide (<see href="https://docs.upvest.co/products/tol/guides/transfers/securities_transfers_overview">TOL</see> / <see href="https://docs.upvest.co/products/byol/guides/transfers/securities_transfers_overview">BYOL</see> / <see href="https://docs.upvest.co/products/omnibus/guides/transfers/securities_transfers_overview">Omnibus</see>) for the transfer stages and settlement details.
    /// </para>
    /// </remarks>
    public Task<SecurityTransfersListResponse> ListSecuritiesTransfers(ListSecuritiesTransfersRequest request,
        RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute(
            _server.Default("/securities_transfers"),
            [],
            [
                new Param("direction", request.Direction),
                new Param("sort", request.Sort),
                new Param("order", request.Order),
                new Param("offset", request.Offset),
                new Param("limit", request.Limit),
                new Param("user_id", request.UserId),
                new Param("account_id", request.AccountId),
                new Param("account_group_id", request.AccountGroupId),
                new Param("status", request.Status),
            ],
            [new HeaderParam("upvest-api-version", request.UpvestApiVersion)],
            HttpMethod.Get,
            EmptyBody.Instance,
            JsonResponse.Create<SecurityTransfersListResponse>(),
            ListSecuritiesTransfersError.Response,
            _auth.OauthClientCredentials.ForScopes("securities_transfers:admin", "securities_transfers:read"),
            requestOptions,
            cancellationToken);
}
