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
using UpvestInvestmentApi.Requests.Files;

namespace UpvestInvestmentApi.Api;

/// <summary>
/// All files API related paths.
/// </summary>
public sealed class Files
{
    private readonly RawClient _rawClient;
    private readonly Server _server;
    private readonly AuthSchemes _auth;

    internal Files(RawClient rawClient, Server server, AuthSchemes auth)
    {
        _rawClient = rawClient;
        _server = server;
        _auth = auth;
    }

    /// <summary>
    /// Retrieve a file metadata
    /// </summary>
    /// <param name="request">The operation's inputs</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="FilesMetadata"/> instance.</returns>
    /// <exception cref="ApiException{TError}"> of <see cref="FetchingFileMetadataError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// Returns the metadata of the file identified by <c>folder</c> and <c>file_name</c>, together with a signed URL for downloading it.
    /// <para>
    /// Downloading a file is a two-step process: request the metadata here, then fetch the file from the returned <c>signed_url</c>. The signed URL is a one-time link that expires after 15 minutes, so download the file shortly after requesting it. Set <c>redirect=1</c> to have the API respond with an HTTP redirect to the download location instead of returning the URL in the body.
    /// </para>
    /// <para>
    /// See the file retrieval guide (<see href="https://docs.upvest.co/products/tol/guides/files/retrieving_data">TOL</see> / <see href="https://docs.upvest.co/products/byol/guides/files/retrieving_data">BYOL</see> / <see href="https://docs.upvest.co/products/omnibus/guides/files/retrieving_data">Omnibus</see>) for the download process.
    /// </para>
    /// </remarks>
    public Task<FilesMetadata> FetchingFileMetadata(FetchingFileMetadataRequest request,
        RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute(
            _server.Default("/files/{folder}/{file_name}"),
            [new TemplateParam("folder", request.Folder), new TemplateParam("file_name", request.FileName)],
            [new Param("redirect", request.Redirect)],
            [new HeaderParam("upvest-api-version", request.UpvestApiVersion)],
            HttpMethod.Get,
            EmptyBody.Instance,
            JsonResponse.Create<FilesMetadata>(),
            FetchingFileMetadataError.Response,
            _auth.OauthClientCredentials.ForScopes("files:read"),
            requestOptions,
            cancellationToken);
}
