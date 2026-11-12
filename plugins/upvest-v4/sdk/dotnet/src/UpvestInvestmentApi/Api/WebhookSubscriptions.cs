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
using UpvestInvestmentApi.Requests.WebhookSubscriptions;

namespace UpvestInvestmentApi.Api;

/// <summary>
/// All webhook subscriptions related paths.
/// </summary>
public sealed class WebhookSubscriptions
{
    private readonly RawClient _rawClient;
    private readonly Server _server;
    private readonly AuthSchemes _auth;

    internal WebhookSubscriptions(RawClient rawClient, Server server, AuthSchemes auth)
    {
        _rawClient = rawClient;
        _server = server;
        _auth = auth;
    }

    /// <summary>
    /// Create a webhook subscription
    /// </summary>
    /// <param name="request">The operation's inputs</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="Webhook"/> instance.</returns>
    /// <exception cref="ApiException{TError}"> of <see cref="CreateWebhookError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// Creates a webhook subscription, registering a URL that the Investment API calls when the events you select occur.
    /// <para>
    /// The URL must use HTTPS, resolve to a DNS name rather than an IP address, serve TLS 1.2 or higher, and must not respond with a redirect. Set <c>type</c> to <c>ALL</c> to receive every event, optionally narrowing it with <c>exclude_type</c>, or list only the subscription types you want. Events are batched by size or by delay according to <c>config</c>.
    /// </para>
    /// <para>
    /// See the implementing webhooks guide (<see href="https://docs.upvest.co/products/tol/getting_started/implementing_webhooks">TOL</see> / <see href="https://docs.upvest.co/products/byol/getting_started/implementing_webhooks">BYOL</see> / <see href="https://docs.upvest.co/products/omnibus/getting_started/implementing_webhooks">Omnibus</see>) for handler requirements, subscription types, and batching.
    /// </para>
    /// </remarks>
    public Task<Webhook> CreateWebhook(CreateWebhookRequest request,
        RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute(
            _server.Default("/webhooks"),
            [],
            [],
            [
                new HeaderParam("upvest-api-version", request.UpvestApiVersion),
                new HeaderParam("Idempotency-Key", Guid.NewGuid()),
            ],
            HttpMethod.Post,
            JsonRequest.Create(request.Body),
            JsonResponse.Create<Webhook>(),
            CreateWebhookError.Response,
            _auth.OauthClientCredentials.ForScopes("webhooks:admin"),
            requestOptions,
            cancellationToken);

    /// <summary>
    /// Delete a webhook subscription
    /// </summary>
    /// <param name="request">The operation's inputs</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>A <see cref="Task"/> instance.</returns>
    /// <exception cref="ApiException{TError}"> of <see cref="DeleteWebhookError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// Deletes the webhook subscription identified by <c>webhook_id</c>, stopping all further deliveries to its URL.
    /// <para>
    /// See the implementing webhooks guide (<see href="https://docs.upvest.co/products/tol/getting_started/implementing_webhooks">TOL</see> / <see href="https://docs.upvest.co/products/byol/getting_started/implementing_webhooks">BYOL</see> / <see href="https://docs.upvest.co/products/omnibus/getting_started/implementing_webhooks">Omnibus</see>) for handler requirements, subscription types, and batching.
    /// </para>
    /// </remarks>
    public Task DeleteWebhook(DeleteWebhookRequest request,
        RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute(
            _server.Default("/webhooks/{webhook_id}"),
            [new TemplateParam("webhook_id", request.WebhookId)],
            [],
            [
                new HeaderParam("upvest-api-version", request.UpvestApiVersion),
                new HeaderParam("Idempotency-Key", Guid.NewGuid()),
            ],
            HttpMethod.Delete,
            EmptyBody.Instance,
            VoidResponse.Instance,
            DeleteWebhookError.Response,
            _auth.OauthClientCredentials.ForScopes("webhooks:admin"),
            requestOptions,
            cancellationToken);

    /// <summary>
    /// Get signing keys
    /// </summary>
    /// <param name="request">The operation's inputs</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="AuthVerificationKeys"/> instance.</returns>
    /// <exception cref="ApiException{TError}"> of <see cref="GetJwksError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// Returns the set of public keys used to verify the signatures on webhook payloads, as a JSON Web Key Set.
    /// <para>
    /// Verify the signature of every webhook you receive against these keys before acting on it. Keys rotate, so fetch the current set rather than hard-coding a key.
    /// </para>
    /// <para>
    /// See the implementing webhooks guide (<see href="https://docs.upvest.co/products/tol/getting_started/implementing_webhooks">TOL</see> / <see href="https://docs.upvest.co/products/byol/getting_started/implementing_webhooks">BYOL</see> / <see href="https://docs.upvest.co/products/omnibus/getting_started/implementing_webhooks">Omnibus</see>) for handler requirements, subscription types, and batching.
    /// </para>
    /// </remarks>
    public Task<AuthVerificationKeys> GetJwks(GetJwksRequest request,
        RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute(
            _server.Default("/auth/verify_keys"),
            [],
            [],
            [new HeaderParam("upvest-api-version", request.UpvestApiVersion)],
            HttpMethod.Get,
            EmptyBody.Instance,
            JsonResponse.Create<AuthVerificationKeys>(),
            GetJwksError.Response,
            _auth.OauthClientCredentials.ForScopes("webhooks:read", "webhooks:admin"),
            requestOptions,
            cancellationToken);

    /// <summary>
    /// List all webhook subscriptions
    /// </summary>
    /// <param name="request">The operation's inputs</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="WebhooksListResponse"/> instance.</returns>
    /// <exception cref="ApiException{TError}"> of <see cref="ListWebhooksError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// Returns the list of webhook subscriptions.
    /// <para>
    /// Use the <c>offset</c> and <c>limit</c> query parameters to page through results; <c>meta.total_count</c> gives the total number of matching subscriptions.
    /// </para>
    /// <para>
    /// See the implementing webhooks guide (<see href="https://docs.upvest.co/products/tol/getting_started/implementing_webhooks">TOL</see> / <see href="https://docs.upvest.co/products/byol/getting_started/implementing_webhooks">BYOL</see> / <see href="https://docs.upvest.co/products/omnibus/getting_started/implementing_webhooks">Omnibus</see>) for handler requirements, subscription types, and batching.
    /// </para>
    /// </remarks>
    public Task<WebhooksListResponse> ListWebhooks(ListWebhooksRequest request,
        RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute(
            _server.Default("/webhooks"),
            [],
            [
                new Param("sort", request.Sort),
                new Param("order", request.Order),
                new Param("offset", request.Offset),
                new Param("limit", request.Limit),
            ],
            [new HeaderParam("upvest-api-version", request.UpvestApiVersion)],
            HttpMethod.Get,
            EmptyBody.Instance,
            JsonResponse.Create<WebhooksListResponse>(),
            ListWebhooksError.Response,
            _auth.OauthClientCredentials.ForScopes("webhooks:read", "webhooks:admin"),
            requestOptions,
            cancellationToken);

    /// <summary>
    /// Retrieve a webhook subscription
    /// </summary>
    /// <param name="request">The operation's inputs</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="Webhook"/> instance.</returns>
    /// <exception cref="ApiException{TError}"> of <see cref="RetrieveWebhookError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// Returns the webhook subscription identified by <c>webhook_id</c>, including the URL it calls, the subscription types it covers, and whether it is enabled.
    /// <para>
    /// See the implementing webhooks guide (<see href="https://docs.upvest.co/products/tol/getting_started/implementing_webhooks">TOL</see> / <see href="https://docs.upvest.co/products/byol/getting_started/implementing_webhooks">BYOL</see> / <see href="https://docs.upvest.co/products/omnibus/getting_started/implementing_webhooks">Omnibus</see>) for handler requirements, subscription types, and batching.
    /// </para>
    /// </remarks>
    public Task<Webhook> RetrieveWebhook(RetrieveWebhookRequest request,
        RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute(
            _server.Default("/webhooks/{webhook_id}"),
            [new TemplateParam("webhook_id", request.WebhookId)],
            [],
            [new HeaderParam("upvest-api-version", request.UpvestApiVersion)],
            HttpMethod.Get,
            EmptyBody.Instance,
            JsonResponse.Create<Webhook>(),
            RetrieveWebhookError.Response,
            _auth.OauthClientCredentials.ForScopes("webhooks:read", "webhooks:admin"),
            requestOptions,
            cancellationToken);

    /// <summary>
    /// Test a webhook subscription
    /// </summary>
    /// <param name="request">The operation's inputs</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="WebhooksTestResponse"/> instance.</returns>
    /// <exception cref="ApiException{TError}"> of <see cref="TestWebhookError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// Sends test event data to the URL of the webhook subscription identified by <c>webhook_id</c>, so you can confirm your handler is reachable and responding correctly.
    /// <para>
    /// The response reports what your endpoint returned: its HTTP status, response headers, and body. Use it to verify a new subscription before relying on live events.
    /// </para>
    /// <para>
    /// See the implementing webhooks guide (<see href="https://docs.upvest.co/products/tol/getting_started/implementing_webhooks">TOL</see> / <see href="https://docs.upvest.co/products/byol/getting_started/implementing_webhooks">BYOL</see> / <see href="https://docs.upvest.co/products/omnibus/getting_started/implementing_webhooks">Omnibus</see>) for handler requirements, subscription types, and batching.
    /// </para>
    /// </remarks>
    public Task<WebhooksTestResponse> TestWebhook(TestWebhookRequest request,
        RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute(
            _server.Default("/webhooks/{webhook_id}/test"),
            [new TemplateParam("webhook_id", request.WebhookId)],
            [],
            [
                new HeaderParam("upvest-api-version", request.UpvestApiVersion),
                new HeaderParam("Idempotency-Key", Guid.NewGuid()),
            ],
            HttpMethod.Post,
            EmptyBody.Instance,
            JsonResponse.Create<WebhooksTestResponse>(),
            TestWebhookError.Response,
            _auth.OauthClientCredentials.ForScopes("webhooks:admin"),
            requestOptions,
            cancellationToken);

    /// <summary>
    /// Update a webhook subscription
    /// </summary>
    /// <param name="request">The operation's inputs</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="Webhook"/> instance.</returns>
    /// <exception cref="ApiException{TError}"> of <see cref="UpdateWebhookError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// Updates the webhook subscription identified by <c>webhook_id</c>.
    /// <para>
    /// Use this to change the callback URL, adjust which subscription types are delivered, or enable and disable delivery without deleting the subscription.
    /// </para>
    /// <para>
    /// See the implementing webhooks guide (<see href="https://docs.upvest.co/products/tol/getting_started/implementing_webhooks">TOL</see> / <see href="https://docs.upvest.co/products/byol/getting_started/implementing_webhooks">BYOL</see> / <see href="https://docs.upvest.co/products/omnibus/getting_started/implementing_webhooks">Omnibus</see>) for handler requirements, subscription types, and batching.
    /// </para>
    /// </remarks>
    public Task<Webhook> UpdateWebhook(UpdateWebhookRequest request,
        RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute(
            _server.Default("/webhooks/{webhook_id}"),
            [new TemplateParam("webhook_id", request.WebhookId)],
            [],
            [
                new HeaderParam("upvest-api-version", request.UpvestApiVersion),
                new HeaderParam("Idempotency-Key", Guid.NewGuid()),
            ],
            new HttpMethod("PATCH"),
            JsonRequest.Create(request.Body),
            JsonResponse.Create<Webhook>(),
            UpdateWebhookError.Response,
            _auth.OauthClientCredentials.ForScopes("webhooks:admin"),
            requestOptions,
            cancellationToken);
}
