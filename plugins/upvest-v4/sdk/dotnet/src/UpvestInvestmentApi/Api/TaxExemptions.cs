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
using UpvestInvestmentApi.Requests.TaxExemptions;

namespace UpvestInvestmentApi.Api;

/// <summary>
/// All tax exemptions related paths
/// </summary>
public sealed class TaxExemptions
{
    private readonly RawClient _rawClient;
    private readonly Server _server;
    private readonly AuthSchemes _auth;

    internal TaxExemptions(RawClient rawClient, Server server, AuthSchemes auth)
    {
        _rawClient = rawClient;
        _server = server;
        _auth = auth;
    }

    /// <summary>
    /// Create a tax exemption
    /// </summary>
    /// <param name="request">The operation's inputs</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="WebhookTaxExemptionCreatedTaxExemption"/> instance.</returns>
    /// <exception cref="ApiException{TError}"> of <see cref="CreateTaxExemptionError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// Creates a tax exemption order for end users who are resident in Germany for tax purposes.
    /// <para>
    /// Upvest must hold the end user's Tax Identification Number before an exemption can be created. The request is processed asynchronously: the exemption is created with status <c>NEW</c> and moves to <c>ACTIVE</c>, which is signalled by a <c>TAX_EXEMPTION</c> webhook event. A single exemption covers exactly one <c>user_ids</c> entry and an allowance of up to €1,000 per tax year; a joint exemption requires exactly two entries and covers up to €2,000.
    /// </para>
    /// <para>
    /// See the <see href="https://docs.upvest.co/products/tol/guides/taxes/tax_exemptions_creating">Creating a tax exemption order guide</see> for implementation details.
    /// </para>
    /// </remarks>
    public Task<WebhookTaxExemptionCreatedTaxExemption> CreateTaxExemption(CreateTaxExemptionRequest request,
        RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute(
            _server.Default("/tax_exemptions"),
            [],
            [],
            [
                new HeaderParam("idempotency-key", request.IdempotencyKey),
                new HeaderParam("upvest-api-version", request.UpvestApiVersion),
            ],
            HttpMethod.Post,
            JsonRequest.Create(request.Body),
            JsonResponse.Create<WebhookTaxExemptionCreatedTaxExemption>(),
            CreateTaxExemptionError.Response,
            _auth.OauthClientCredentials.ForScopes("taxes:admin"),
            requestOptions,
            cancellationToken);

    /// <summary>
    /// Delete a tax exemption
    /// </summary>
    /// <param name="request">The operation's inputs</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>A <see cref="Task"/> instance.</returns>
    /// <exception cref="ApiException{TError}"> of <see cref="DeleteTaxExemptionError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// Deletes the tax exemption order identified by <c>tax_exemption_id</c> and stops it renewing in subsequent tax years.
    /// <para>
    /// Deletion succeeds only while none of the associated end users have claimed an exemption amount in the current tax year. If any amount has already been used, the exemption remains active and the request fails.
    /// </para>
    /// <para>
    /// See the <see href="https://docs.upvest.co/products/tol/guides/taxes/tax_exemptions_deleting">Deleting a tax exemption order guide</see> for implementation details.
    /// </para>
    /// </remarks>
    public Task DeleteTaxExemption(DeleteTaxExemptionRequest request,
        RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute(
            _server.Default("/tax_exemptions/{tax_exemption_id}"),
            [new TemplateParam("tax_exemption_id", request.TaxExemptionId)],
            [],
            [
                new HeaderParam("upvest-api-version", request.UpvestApiVersion),
                new HeaderParam("Idempotency-Key", Guid.NewGuid()),
            ],
            HttpMethod.Delete,
            EmptyBody.Instance,
            VoidResponse.Instance,
            DeleteTaxExemptionError.Response,
            _auth.OauthClientCredentials.ForScopes("taxes:admin"),
            requestOptions,
            cancellationToken);

    /// <summary>
    /// Get a tax exemption by ID
    /// </summary>
    /// <param name="request">The operation's inputs</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="WebhookTaxExemptionCreatedTaxExemption"/> instance.</returns>
    /// <exception cref="ApiException{TError}"> of <see cref="RetrieveTaxExemptionByIdError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// Returns the tax exemption order identified by <c>tax_exemption_id</c>, including its status and the allowance used and remaining for the tax year.
    /// <para>
    /// See the <see href="https://docs.upvest.co/products/tol/guides/taxes/tax_exemptions_get">Retrieving tax exemption orders guide</see> for implementation details.
    /// </para>
    /// </remarks>
    public Task<WebhookTaxExemptionCreatedTaxExemption> RetrieveTaxExemptionById(RetrieveTaxExemptionByIdRequest request,
        RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute(
            _server.Default("/tax_exemptions/{tax_exemption_id}"),
            [new TemplateParam("tax_exemption_id", request.TaxExemptionId)],
            [],
            [new HeaderParam("upvest-api-version", request.UpvestApiVersion)],
            HttpMethod.Get,
            EmptyBody.Instance,
            JsonResponse.Create<WebhookTaxExemptionCreatedTaxExemption>(),
            RetrieveTaxExemptionByIdError.Response,
            _auth.OauthClientCredentials.ForScopes("taxes:admin"),
            requestOptions,
            cancellationToken);

    /// <summary>
    /// List tax exemptions for a user
    /// </summary>
    /// <param name="request">The operation's inputs</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="TaxExemptionRetrieveForUserResponse"/> instance.</returns>
    /// <exception cref="ApiException{TError}"> of <see cref="RetrieveTaxExemptionsForUserError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// Returns the tax exemption orders of the end user identified by <c>user_id</c>.
    /// <para>
    /// Use the <c>offset</c> and <c>limit</c> query parameters to page through results; <c>meta.total_count</c> gives the total number of matching tax exemptions.
    /// </para>
    /// <para>
    /// See the <see href="https://docs.upvest.co/products/tol/guides/taxes/tax_exemptions_get">Retrieving tax exemption orders guide</see> for implementation details.
    /// </para>
    /// </remarks>
    public Task<TaxExemptionRetrieveForUserResponse> RetrieveTaxExemptionsForUser(RetrieveTaxExemptionsForUserRequest request,
        RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute(
            _server.Default("/users/{user_id}/tax_exemptions"),
            [new TemplateParam("user_id", request.UserId)],
            [
                new Param("sort", request.Sort),
                new Param("order", request.Order),
                new Param("offset", request.Offset),
                new Param("limit", request.Limit),
            ],
            [new HeaderParam("upvest-api-version", request.UpvestApiVersion)],
            HttpMethod.Get,
            EmptyBody.Instance,
            JsonResponse.Create<TaxExemptionRetrieveForUserResponse>(),
            RetrieveTaxExemptionsForUserError.Response,
            _auth.OauthClientCredentials.ForScopes("taxes:admin"),
            requestOptions,
            cancellationToken);

    /// <summary>
    /// Update a tax exemption
    /// </summary>
    /// <param name="request">The operation's inputs</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="WebhookTaxExemptionCreatedTaxExemption"/> instance.</returns>
    /// <exception cref="ApiException{TError}"> of <see cref="UpdateTaxExemptionError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// Updates the tax exemption order identified by <c>tax_exemption_id</c>.
    /// <para>
    /// See the <see href="https://docs.upvest.co/products/tol/guides/taxes/tax_exemptions_update">Updating a tax exemption guide</see> for the rules governing reduction, increase, and cancellation of an exemption.
    /// </para>
    /// </remarks>
    public Task<WebhookTaxExemptionCreatedTaxExemption> UpdateTaxExemption(UpdateTaxExemptionRequest request,
        RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute(
            _server.Default("/tax_exemptions/{tax_exemption_id}"),
            [new TemplateParam("tax_exemption_id", request.TaxExemptionId)],
            [],
            [
                new HeaderParam("upvest-api-version", request.UpvestApiVersion),
                new HeaderParam("Idempotency-Key", Guid.NewGuid()),
            ],
            HttpMethod.Put,
            JsonRequest.Create(request.Body),
            JsonResponse.Create<WebhookTaxExemptionCreatedTaxExemption>(),
            UpdateTaxExemptionError.Response,
            _auth.OauthClientCredentials.ForScopes("taxes:admin"),
            requestOptions,
            cancellationToken);
}
