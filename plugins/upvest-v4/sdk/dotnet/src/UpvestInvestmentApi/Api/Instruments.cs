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
using UpvestInvestmentApi.Requests.Instruments;

namespace UpvestInvestmentApi.Api;

/// <summary>
/// All instrument related paths.
/// </summary>
public sealed class Instruments
{
    private readonly RawClient _rawClient;
    private readonly Server _server;
    private readonly AuthSchemes _auth;

    internal Instruments(RawClient rawClient, Server server, AuthSchemes auth)
    {
        _rawClient = rawClient;
        _server = server;
        _auth = auth;
    }

    /// <summary>
    /// List instruments
    /// </summary>
    /// <param name="request">The operation's inputs</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="InstrumentsListResponse"/> instance.</returns>
    /// <exception cref="ApiException{TError}"> of <see cref="ListInstrumentsError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// Returns the list of instruments available on the Upvest platform.
    /// <para>
    /// Narrow the list with the <c>trading_status</c> query parameter, and page through results with <c>offset</c> and <c>limit</c>; <c>meta.total_count</c> gives the total number of matching instruments. The instrument universe reflects onboarding, delisting, and trading bans as they occur.
    /// </para>
    /// <para>
    /// See the instruments guide (<see href="https://docs.upvest.co/products/tol/guides/instruments/implementing_instruments">TOL</see> / <see href="https://docs.upvest.co/products/byol/guides/instruments/implementing_instruments">BYOL</see> / <see href="https://docs.upvest.co/products/omnibus/guides/instruments/implementing_instruments">Omnibus</see>) for instrument onboarding, delisting, and trading bans.
    /// </para>
    /// </remarks>
    public Task<InstrumentsListResponse> ListInstruments(ListInstrumentsRequest request,
        RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute(
            _server.Default("/instruments"),
            [],
            [
                new Param("trading_status", request.TradingStatus),
                new Param("sort", request.Sort),
                new Param("order", request.Order),
                new Param("offset", request.Offset),
                new Param("limit", request.Limit),
            ],
            [new HeaderParam("upvest-api-version", request.UpvestApiVersion)],
            HttpMethod.Get,
            EmptyBody.Instance,
            JsonResponse.Create<InstrumentsListResponse>(),
            ListInstrumentsError.Response,
            _auth.OauthClientCredentials.ForScopes("instruments:read"),
            requestOptions,
            cancellationToken);

    /// <summary>
    /// Get instrument
    /// </summary>
    /// <param name="request">The operation's inputs</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="InstrumentsResponse"/> instance.</returns>
    /// <exception cref="ApiException{TError}"> of <see cref="RetrieveInstrumentError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// Returns the instrument identified by <c>instrument_id</c>, including its identifiers, name, trading status, and whether it supports fractional investing.
    /// <para>
    /// See the instruments guide (<see href="https://docs.upvest.co/products/tol/guides/instruments/implementing_instruments">TOL</see> / <see href="https://docs.upvest.co/products/byol/guides/instruments/implementing_instruments">BYOL</see> / <see href="https://docs.upvest.co/products/omnibus/guides/instruments/implementing_instruments">Omnibus</see>) for instrument onboarding, delisting, and trading bans.
    /// </para>
    /// </remarks>
    public Task<InstrumentsResponse> RetrieveInstrument(RetrieveInstrumentRequest request,
        RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute(
            _server.Default("/instruments/{instrument_id}"),
            [new TemplateParam("instrument_id", request.InstrumentId)],
            [],
            [new HeaderParam("upvest-api-version", request.UpvestApiVersion)],
            HttpMethod.Get,
            EmptyBody.Instance,
            JsonResponse.Create<InstrumentsResponse>(),
            RetrieveInstrumentError.Response,
            _auth.OauthClientCredentials.ForScopes("instruments:read"),
            requestOptions,
            cancellationToken);
}
