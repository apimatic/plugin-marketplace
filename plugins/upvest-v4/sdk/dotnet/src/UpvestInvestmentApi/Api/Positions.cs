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
using UpvestInvestmentApi.Requests.Positions;

namespace UpvestInvestmentApi.Api;

/// <summary>
/// All positions related paths.
/// </summary>
public sealed class Positions
{
    private readonly RawClient _rawClient;
    private readonly Server _server;
    private readonly AuthSchemes _auth;

    internal Positions(RawClient rawClient, Server server, AuthSchemes auth)
    {
        _rawClient = rawClient;
        _server = server;
        _auth = auth;
    }

    /// <summary>
    /// List positions
    /// </summary>
    /// <param name="request">The operation's inputs</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="PositionsListResponse"/> instance.</returns>
    /// <exception cref="ApiException{TError}"> of <see cref="ListPositionsError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// Returns the list of positions held by the account.
    /// <para>
    /// Use the <c>offset</c> and <c>limit</c> query parameters to page through results; <c>meta.total_count</c> gives the total number of matching positions.
    /// </para>
    /// <para>
    /// See the Positions guide (<see href="https://docs.upvest.co/products/tol/guides/positions/retrieving_positions">TOL</see> / <see href="https://docs.upvest.co/products/byol/guides/positions/retrieving_positions">BYOL</see>) for how to interpret the <c>quantity</c>, <c>locked_for_trading</c>, <c>pending_settlement</c>, <c>available_for_trading</c>, <c>available_for_instruction</c>, and <c>settled_quantity</c> fields.
    /// </para>
    /// </remarks>
    public Task<PositionsListResponse> ListPositions(ListPositionsRequest request,
        RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute(
            _server.Default("/accounts/{account_id}/positions"),
            [new TemplateParam("account_id", request.AccountId)],
            [new Param("offset", request.Offset), new Param("limit", request.Limit)],
            [new HeaderParam("upvest-api-version", request.UpvestApiVersion)],
            HttpMethod.Get,
            EmptyBody.Instance,
            JsonResponse.Create<PositionsListResponse>(),
            ListPositionsError.Response,
            _auth.OauthClientCredentials.ForScopes("positions:read"),
            requestOptions,
            cancellationToken);

    /// <summary>
    /// Retrieve position
    /// </summary>
    /// <param name="request">The operation's inputs</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="AccountsPositionsResponse"/> instance.</returns>
    /// <exception cref="ApiException{TError}"> of <see cref="RetrievePositionError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// Returns the account's position in the given instrument.
    /// <para>
    /// See the Positions guide (<see href="https://docs.upvest.co/products/tol/guides/positions/interpreting_positions">TOL</see> / <see href="https://docs.upvest.co/products/byol/guides/positions/interpreting_positions">BYOL</see>) for how to interpret the <c>quantity</c>, <c>locked_for_trading</c>, <c>pending_settlement</c>, <c>available_for_trading</c>, <c>available_for_instruction</c>, and <c>settled_quantity</c> fields.
    /// </para>
    /// </remarks>
    public Task<AccountsPositionsResponse> RetrievePosition(RetrievePositionRequest request,
        RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute(
            _server.Default("/accounts/{account_id}/positions/{instrument_id}"),
            [
                new TemplateParam("instrument_id", request.InstrumentId),
                new TemplateParam("account_id", request.AccountId),
            ],
            [],
            [new HeaderParam("upvest-api-version", request.UpvestApiVersion)],
            HttpMethod.Get,
            EmptyBody.Instance,
            JsonResponse.Create<AccountsPositionsResponse>(),
            RetrievePositionError.Response,
            _auth.OauthClientCredentials.ForScopes("positions:read"),
            requestOptions,
            cancellationToken);
}
