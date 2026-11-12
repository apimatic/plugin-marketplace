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
using UpvestInvestmentApi.Requests.TransactionFeesConfigurations;

namespace UpvestInvestmentApi.Api;

/// <summary>
/// All transaction fees configurations related paths.
/// </summary>
public sealed class TransactionFeesConfigurations
{
    private readonly RawClient _rawClient;
    private readonly Server _server;
    private readonly AuthSchemes _auth;

    internal TransactionFeesConfigurations(RawClient rawClient, Server server, AuthSchemes auth)
    {
        _rawClient = rawClient;
        _server = server;
        _auth = auth;
    }

    /// <summary>
    /// Create a transaction fee account group configuration
    /// </summary>
    /// <param name="request">The operation's inputs</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="TransactionFeeAccountGroupConfiguration"/> instance.</returns>
    /// <exception cref="ApiException{TError}"> of <see cref="CreateTransactionFeeAccountGroupConfigurationError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// Assigns a transaction fee model to an account group for a transaction category.
    /// </remarks>
    public Task<TransactionFeeAccountGroupConfiguration> CreateTransactionFeeAccountGroupConfiguration(CreateTransactionFeeAccountGroupConfigurationRequest request,
        RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute(
            _server.Default("/transaction_fees/configurations"),
            [],
            [],
            [
                new HeaderParam("upvest-api-version", request.UpvestApiVersion),
                new HeaderParam("Idempotency-Key", Guid.NewGuid()),
            ],
            HttpMethod.Post,
            JsonRequest.Create(request.Body),
            JsonResponse.Create<TransactionFeeAccountGroupConfiguration>(),
            CreateTransactionFeeAccountGroupConfigurationError.Response,
            _auth.OauthClientCredentials.ForScopes("transaction_fees:admin"),
            requestOptions,
            cancellationToken);

    /// <summary>
    /// Delete a transaction fee account group configuration
    /// </summary>
    /// <param name="request">The operation's inputs</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>A <see cref="Task"/> instance.</returns>
    /// <exception cref="ApiException{TError}"> of <see cref="DeleteTransactionFeeAccountGroupConfigurationError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// Removes a transaction fee configuration from an account group. Fee intakes already executed under the deleted configuration are unaffected.
    /// </remarks>
    public Task DeleteTransactionFeeAccountGroupConfiguration(DeleteTransactionFeeAccountGroupConfigurationRequest request,
        RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute(
            _server.Default("/transaction_fees/configurations/{account_group_id}/{id}"),
            [new TemplateParam("account_group_id", request.AccountGroupId), new TemplateParam("id", request.Id)],
            [],
            [
                new HeaderParam("upvest-api-version", request.UpvestApiVersion),
                new HeaderParam("Idempotency-Key", Guid.NewGuid()),
            ],
            HttpMethod.Delete,
            EmptyBody.Instance,
            VoidResponse.Instance,
            DeleteTransactionFeeAccountGroupConfigurationError.Response,
            _auth.OauthClientCredentials.ForScopes("transaction_fees:admin"),
            requestOptions,
            cancellationToken);

    /// <summary>
    /// List transaction fee account group configurations
    /// </summary>
    /// <param name="request">The operation's inputs</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="TransactionFeeAccountGroupConfigurationsListResponse"/> instance.</returns>
    /// <exception cref="ApiException{TError}"> of <see cref="ListTransactionFeeAccountGroupConfigurationsError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// Returns a paginated list of the transaction fee configurations assigned to the account group identified by <c>id</c>, with at most one configuration per <c>transaction_category</c>.
    /// <para>
    /// Returns an empty list if the account group has no configurations, and <c>404</c> if the account group does not exist.
    /// </para>
    /// </remarks>
    public Task<TransactionFeeAccountGroupConfigurationsListResponse> ListTransactionFeeAccountGroupConfigurations(ListTransactionFeeAccountGroupConfigurationsRequest request,
        RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute(
            _server.Default("/transaction_fees/configurations/{id}"),
            [new TemplateParam("id", request.Id)],
            [
                new Param("sort", request.Sort),
                new Param("order", request.Order),
                new Param("offset", request.Offset),
                new Param("limit", request.Limit),
            ],
            [new HeaderParam("upvest-api-version", request.UpvestApiVersion)],
            HttpMethod.Get,
            EmptyBody.Instance,
            JsonResponse.Create<TransactionFeeAccountGroupConfigurationsListResponse>(),
            ListTransactionFeeAccountGroupConfigurationsError.Response,
            _auth.OauthClientCredentials.ForScopes("transaction_fees:admin", "transaction_fees:read"),
            requestOptions,
            cancellationToken);

    /// <summary>
    /// Update transaction fee account group configuration
    /// </summary>
    /// <param name="request">The operation's inputs</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="TransactionFeeAccountGroupConfiguration"/> instance.</returns>
    /// <exception cref="ApiException{TError}"> of <see cref="UpdateTransactionFeeAccountGroupConfigurationError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// Update the fee model assigned by an existing transaction fee account group configuration.
    /// </remarks>
    public Task<TransactionFeeAccountGroupConfiguration> UpdateTransactionFeeAccountGroupConfiguration(UpdateTransactionFeeAccountGroupConfigurationRequest request,
        RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute(
            _server.Default("/transaction_fees/configurations/{id}"),
            [new TemplateParam("id", request.Id)],
            [],
            [
                new HeaderParam("upvest-api-version", request.UpvestApiVersion),
                new HeaderParam("Idempotency-Key", Guid.NewGuid()),
            ],
            new HttpMethod("PATCH"),
            JsonRequest.Create(request.Body),
            JsonResponse.Create<TransactionFeeAccountGroupConfiguration>(),
            UpdateTransactionFeeAccountGroupConfigurationError.Response,
            _auth.OauthClientCredentials.ForScopes("transaction_fees:admin"),
            requestOptions,
            cancellationToken);
}
