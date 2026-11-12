using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using UpvestInvestmentApi.Core;
using UpvestInvestmentApi.Core.Authentication;
using UpvestInvestmentApi.Core.Exceptions;
using UpvestInvestmentApi.Core.Extensions;
using UpvestInvestmentApi.Core.Models;
using UpvestInvestmentApi.Core.Request;
using UpvestInvestmentApi.Core.Response;
using UpvestInvestmentApi.Errors;
using UpvestInvestmentApi.Models;
using UpvestInvestmentApi.Requests.PriceData;

namespace UpvestInvestmentApi.Api;

/// <summary>
/// All price data related paths.
/// </summary>
public sealed class PriceData
{
    private readonly RawClient _rawClient;
    private readonly Server _server;
    private readonly AuthSchemes _auth;

    internal PriceData(RawClient rawClient, Server server, AuthSchemes auth)
    {
        _rawClient = rawClient;
        _server = server;
        _auth = auth;
    }

    /// <summary>
    /// Get instrument latest price
    /// </summary>
    /// <param name="request">The operation's inputs</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="InstrumentsVenuesPricesLatestResponse"/> instance.</returns>
    /// <exception cref="ApiException{TError}"> of <see cref="RetrieveInstrumentLatestPriceError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// Returns the instrument's latest price as available at the specified venue.
    /// <para>
    /// <b>NOTE</b>: Please note that in live mode we provide the latest prices that we receive from our data provider. However, it is to be expected that such updates will only take place on trading days.
    /// </para>
    /// </remarks>
    public Task<InstrumentsVenuesPricesLatestResponse> RetrieveInstrumentLatestPrice(RetrieveInstrumentLatestPriceRequest request,
        RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute(
            _server.Default("/instruments/{instrument_id}/venues/{venue_id}/prices/latest"),
            [new TemplateParam("instrument_id", request.InstrumentId), new TemplateParam("venue_id", request.VenueId)],
            [new Param("price_quality", request.PriceQuality)],
            [new HeaderParam("upvest-api-version", request.UpvestApiVersion)],
            HttpMethod.Get,
            EmptyBody.Instance,
            JsonResponse.Create<InstrumentsVenuesPricesLatestResponse>(),
            RetrieveInstrumentLatestPriceError.Response,
            _auth.OauthClientCredentials.ForScopes("prices:read"),
            requestOptions,
            cancellationToken);

    /// <summary>
    /// Get instrument OHLC prices
    /// </summary>
    /// <param name="request">The operation's inputs</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="InstrumentsVenuesPricesOhlcResponse"/> instance.</returns>
    /// <exception cref="ApiException{TError}"> of <see cref="RetrieveInstrumentPricesOhlcError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// Returns OHLC prices for the instrument at the specified venue for the chosen time period.
    /// <para>
    /// If requested interval is <c>1d</c>, then the response also includes days with 0 volume. In these cases <c>open</c>, <c>high</c>, <c>low</c> are empty (<c>""</c>), but <c>close</c> is provided. If requested interval is smaller than <c>1d</c>, then the intervals with 0 volume are omitted from the response.
    /// </para>
    /// <para>
    /// <b>NOTE</b>: Please note that in live mode we provide the latest prices that we receive from our data provider. However, it is to be expected that such updates will only take place on trading days.
    /// </para>
    /// </remarks>
    public Task<InstrumentsVenuesPricesOhlcResponse> RetrieveInstrumentPricesOhlc(RetrieveInstrumentPricesOhlcRequest request,
        RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute(
            _server.Default("/instruments/{instrument_id}/venues/{venue_id}/prices/ohlc"),
            [new TemplateParam("instrument_id", request.InstrumentId), new TemplateParam("venue_id", request.VenueId)],
            [
                new Param("start_date", request.StartDate?.ToDate()),
                new Param("end_date", request.EndDate?.ToDate()),
                new Param("adjusted_for", request.AdjustedFor),
                new Param("interval", request.Interval),
            ],
            [new HeaderParam("upvest-api-version", request.UpvestApiVersion)],
            HttpMethod.Get,
            EmptyBody.Instance,
            JsonResponse.Create<InstrumentsVenuesPricesOhlcResponse>(),
            RetrieveInstrumentPricesOhlcError.Response,
            _auth.OauthClientCredentials.ForScopes("prices:read"),
            requestOptions,
            cancellationToken);

    /// <summary>
    /// Get instrument venues
    /// </summary>
    /// <param name="request">The operation's inputs</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="InstrumentsVenuesResponse"/> instance.</returns>
    /// <exception cref="ApiException{TError}"> of <see cref="RetrieveInstrumentVenuesError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// The venues where the instrument is traded and for which the price data is available.
    /// </remarks>
    public Task<InstrumentsVenuesResponse> RetrieveInstrumentVenues(RetrieveInstrumentVenuesRequest request,
        RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute(
            _server.Default("/instruments/{instrument_id}/venues"),
            [new TemplateParam("instrument_id", request.InstrumentId)],
            [],
            [new HeaderParam("upvest-api-version", request.UpvestApiVersion)],
            HttpMethod.Get,
            EmptyBody.Instance,
            JsonResponse.Create<InstrumentsVenuesResponse>(),
            RetrieveInstrumentVenuesError.Response,
            _auth.OauthClientCredentials.ForScopes("prices:read"),
            requestOptions,
            cancellationToken);
}
