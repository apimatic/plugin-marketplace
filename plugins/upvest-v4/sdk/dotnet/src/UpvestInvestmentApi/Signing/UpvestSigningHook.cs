// Custom code (APIMatic, 2026-11-13): signs every outgoing request through the v4 SDK's hook point.
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;
using UpvestInvestmentApi.Core.Hooks;

namespace UpvestInvestmentApi.Signing;

/// <summary>
/// Signs every request the SDK sends — including the OAuth token request it makes for you —
/// with Upvest HTTP message signatures (draft 15, ECDSA, SHA-512, DER), and adds the
/// <c>upvest-client-id</c>, <c>upvest-api-version</c> and <c>upvest-signature-version</c> headers.
/// Upvest rejects any unsigned request with 401.
/// <code>
/// var options = new UpvestInvestmentApiClientOptions
/// {
///     OauthClientCredentials = new OAuth2ClientCredentials { ClientId = id, ClientSecret = secret, Scope = "users:admin accounts:read" },
///     Hooks = [new UpvestSigningHook(UpvestHttpSignatureCredentials.FromFile(keyId, "key.pem", upvestClientId: id, passphrase))],
/// };
/// </code>
/// Runs after authentication is applied, so the bearer token is covered by the signature.
/// </summary>
public sealed class UpvestSigningHook : SdkHook
{
    private readonly UpvestHttpMessageSigner _signer;

    public UpvestSigningHook(UpvestHttpSignatureCredentials credentials)
    {
        if (credentials is null) throw new ArgumentNullException(nameof(credentials));
        _signer = credentials.CreateSigner();
    }

    /// <summary>A hook from <see cref="UpvestHttpSignatureCredentials.FromEnvironment"/>, or an exception naming what is missing.</summary>
    public static UpvestSigningHook FromEnvironment() =>
        new(UpvestHttpSignatureCredentials.FromEnvironment()
            ?? throw new InvalidOperationException(
                "Upvest request signing is not configured: set UPVEST_API_KEY_ID, a private key " +
                "(UPVEST_API_HTTP_SIGN_PRIVATE_KEY_FILENAME, _PRIVATE_KEY or _PRIVATE_KEY_BASE64) and the client ID."));

    public override async ValueTask BeforeRequest(HttpRequestMessage request, HookContext context,
        CancellationToken cancellationToken)
    {
        byte[]? body = null;
        if (request.Content is { } content)
        {
            body = await content.ReadAsByteArrayAsync().ConfigureAwait(false);
            // Replace the content with a buffered copy so the bytes sent are exactly the bytes signed.
            var buffered = new ByteArrayContent(body);
            foreach (var h in content.Headers)
                if (!string.Equals(h.Key, "Content-Length", StringComparison.OrdinalIgnoreCase))
                    buffered.Headers.TryAddWithoutValidation(h.Key, h.Value);
            // Upvest answers 400 "unexpected request Content-Type" to "application/json; charset=utf-8"
            // (verified live 2026-11-13), so a JSON body is sent as bare "application/json".
            if (buffered.Headers.ContentType is { MediaType: "application/json", CharSet: not null })
                buffered.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            content.Dispose();
            request.Content = buffered;
        }

        var headers = new List<KeyValuePair<string, string>>();
        foreach (var h in request.Headers) headers.Add(new(h.Key, string.Join(", ", h.Value)));
        if (request.Content is not null)
            foreach (var h in request.Content.Headers)
                if (!string.Equals(h.Key, "Content-Length", StringComparison.OrdinalIgnoreCase))
                    headers.Add(new(h.Key, string.Join(", ", h.Value)));

        var toAdd = _signer.Sign(request.Method.Method, request.RequestUri ?? context.Uri, headers, body);

        foreach (var (name, value) in toAdd.Select(kv => (kv.Key, kv.Value)))
        {
            if (name == "content-length") continue; // set by ByteArrayContent itself
            if (IsContentHeader(name))
            {
                request.Content ??= new ByteArrayContent([]);
                request.Content.Headers.Remove(name);
                request.Content.Headers.TryAddWithoutValidation(name, value);
            }
            else
            {
                request.Headers.Remove(name);
                request.Headers.TryAddWithoutValidation(name, value);
            }
        }
    }

    private static bool IsContentHeader(string name) =>
        name.StartsWith("content-", StringComparison.OrdinalIgnoreCase) && name != "content-digest"
        || name == "expires" || name == "last-modified" || name == "allow";
}
