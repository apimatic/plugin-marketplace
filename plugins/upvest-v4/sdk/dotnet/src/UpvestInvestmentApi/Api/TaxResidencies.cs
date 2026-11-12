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
using UpvestInvestmentApi.Requests.TaxResidencies;

namespace UpvestInvestmentApi.Api;

/// <summary>
/// All tax residencies related paths.
/// </summary>
public sealed class TaxResidencies
{
    private readonly RawClient _rawClient;
    private readonly Server _server;
    private readonly AuthSchemes _auth;

    internal TaxResidencies(RawClient rawClient, Server server, AuthSchemes auth)
    {
        _rawClient = rawClient;
        _server = server;
        _auth = auth;
    }

    /// <summary>
    /// Retrieve tax residencies
    /// </summary>
    /// <param name="request">The operation's inputs</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="TaxResidencyRecord"/> instance.</returns>
    /// <exception cref="ApiException{TError}"> of <see cref="RetrieveTaxResidenciesError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// Returns the tax residencies currently on file for the user identified by <c>user_id</c>.
    /// <para>
    /// See the User tax onboarding guide (<see href="https://docs.upvest.co/products/tol/guides/users/users_tax_onboarding">TOL</see> / <see href="https://docs.upvest.co/products/byol/guides/users/users_tax_onboarding">BYOL</see>) for tax residency requirements.
    /// </para>
    /// </remarks>
    public Task<TaxResidencyRecord> RetrieveTaxResidencies(RetrieveTaxResidenciesRequest request,
        RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute(
            _server.Default("/users/{user_id}/tax_residencies"),
            [new TemplateParam("user_id", request.UserId)],
            [],
            [new HeaderParam("upvest-api-version", request.UpvestApiVersion)],
            HttpMethod.Get,
            EmptyBody.Instance,
            JsonResponse.Create<TaxResidencyRecord>(),
            RetrieveTaxResidenciesError.Response,
            _auth.OauthClientCredentials.ForScopes("taxes:read", "taxes:admin"),
            requestOptions,
            cancellationToken);

    /// <summary>
    /// Update tax residencies
    /// </summary>
    /// <param name="request">The operation's inputs</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="TaxResidencyRecord"/> instance.</returns>
    /// <exception cref="ApiException{TError}"> of <see cref="SetTaxResidenciesError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// Records the tax residencies for the user identified by <c>user_id</c>, replacing any previously submitted set.
    /// <para>
    /// See the User tax onboarding guide (<see href="https://docs.upvest.co/products/tol/guides/users/users_tax_onboarding">TOL</see> / <see href="https://docs.upvest.co/products/byol/guides/users/users_tax_onboarding">BYOL</see>) for tax residency requirements.
    /// </para>
    /// </remarks>
    public Task<TaxResidencyRecord> SetTaxResidencies(SetTaxResidenciesRequest request,
        RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute(
            _server.Default("/users/{user_id}/tax_residencies"),
            [new TemplateParam("user_id", request.UserId)],
            [],
            [
                new HeaderParam("idempotency-key", request.IdempotencyKey),
                new HeaderParam("upvest-api-version", request.UpvestApiVersion),
            ],
            HttpMethod.Post,
            JsonRequest.Create(request.Body),
            JsonResponse.Create<TaxResidencyRecord>(),
            SetTaxResidenciesError.Response,
            _auth.OauthClientCredentials.ForScopes("taxes:admin"),
            requestOptions,
            cancellationToken);
}
