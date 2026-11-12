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
using UpvestInvestmentApi.Requests.FeesConfigurations;

namespace UpvestInvestmentApi.Api;

/// <summary>
/// All fees configurations related paths.
/// </summary>
public sealed class FeesConfigurations
{
    private readonly RawClient _rawClient;
    private readonly Server _server;
    private readonly AuthSchemes _auth;

    internal FeesConfigurations(RawClient rawClient, Server server, AuthSchemes auth)
    {
        _rawClient = rawClient;
        _server = server;
        _auth = auth;
    }

    /// <summary>
    /// Create a fee configuration
    /// </summary>
    /// <param name="request">The operation's inputs</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="FeeConfiguration3"/> instance.</returns>
    /// <exception cref="ApiException{TError}"> of <see cref="CreateFeeConfigurationError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// Assigns a fee model to an account so that fees are calculated for that account.
    /// <para>
    /// Fee models are set up by Upvest from your requirements and identified by the <c>fee_model_id</c> Upvest provides. Every account that is to pay fees needs a fee configuration.
    /// </para>
    /// <para>
    /// See the Fee model and configuration guide (<see href="https://docs.upvest.co/products/tol/guides/fees/fees_model_configuration">TOL</see> / <see href="https://docs.upvest.co/products/byol/guides/fees/fees_model_configuration">BYOL</see>) for implementation details.
    /// </para>
    /// </remarks>
    public Task<FeeConfiguration3> CreateFeeConfiguration(CreateFeeConfigurationRequest request,
        RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute(
            _server.Default("/fees/configurations"),
            [],
            [],
            [
                new HeaderParam("upvest-api-version", request.UpvestApiVersion),
                new HeaderParam("Idempotency-Key", Guid.NewGuid()),
            ],
            HttpMethod.Post,
            JsonRequest.Create(request.Body),
            JsonResponse.Create<FeeConfiguration3>(),
            CreateFeeConfigurationError.Response,
            _auth.OauthClientCredentials.ForScopes("fees:admin"),
            requestOptions,
            cancellationToken);

    /// <summary>
    /// Get fee configuration
    /// </summary>
    /// <param name="request">The operation's inputs</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="FeeConfiguration3"/> instance.</returns>
    /// <exception cref="ApiException{TError}"> of <see cref="RetrieveFeeConfigurationsError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// Returns the fee configuration of the account identified by <c>account_id</c>.
    /// <para>
    /// See the Fee model and configuration guide (<see href="https://docs.upvest.co/products/tol/guides/fees/fees_model_configuration">TOL</see> / <see href="https://docs.upvest.co/products/byol/guides/fees/fees_model_configuration">BYOL</see>) for implementation details.
    /// </para>
    /// </remarks>
    public Task<FeeConfiguration3> RetrieveFeeConfigurations(RetrieveFeeConfigurationsRequest request,
        RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute(
            _server.Default("/fees/configurations/{account_id}"),
            [new TemplateParam("account_id", request.AccountId)],
            [],
            [new HeaderParam("upvest-api-version", request.UpvestApiVersion)],
            HttpMethod.Get,
            EmptyBody.Instance,
            JsonResponse.Create<FeeConfiguration3>(),
            RetrieveFeeConfigurationsError.Response,
            _auth.OauthClientCredentials.ForScopes("fees:read", "fees:admin"),
            requestOptions,
            cancellationToken);

    /// <summary>
    /// Update fee configuration
    /// </summary>
    /// <param name="request">The operation's inputs</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="FeeConfiguration3"/> instance.</returns>
    /// <exception cref="ApiException{TError}"> of <see cref="UpdateFeeConfigurationError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// Updates the fee configuration of the account identified by <c>account_id</c>.
    /// <para>
    /// Only the last fee configuration submitted on a given day is used to calculate that day's fees.
    /// </para>
    /// <para>
    /// See the Fee model and configuration guide (<see href="https://docs.upvest.co/products/tol/guides/fees/fees_model_configuration">TOL</see> / <see href="https://docs.upvest.co/products/byol/guides/fees/fees_model_configuration">BYOL</see>) for implementation details.
    /// </para>
    /// </remarks>
    public Task<FeeConfiguration3> UpdateFeeConfiguration(UpdateFeeConfigurationRequest request,
        RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute(
            _server.Default("/fees/configurations/{account_id}"),
            [new TemplateParam("account_id", request.AccountId)],
            [],
            [
                new HeaderParam("upvest-api-version", request.UpvestApiVersion),
                new HeaderParam("Idempotency-Key", Guid.NewGuid()),
            ],
            new HttpMethod("PATCH"),
            JsonRequest.Create(request.Body),
            JsonResponse.Create<FeeConfiguration3>(),
            UpdateFeeConfigurationError.Response,
            _auth.OauthClientCredentials.ForScopes("fees:admin"),
            requestOptions,
            cancellationToken);
}
