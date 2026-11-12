// Custom code (APIMatic, 2026-11-13): Upvest's signing rules on top of HttpMessageSigner.
// Ported from the v3 SDK's UpvestHttpMessageSigner (apimatic/uv-poc-v2).
using System;
using System.Collections.Generic;
using System.Linq;

namespace UpvestInvestmentApi.Signing;

/// <summary>
/// Adds the headers Upvest requires (accept, upvest-api-version, upvest-client-id), covers the
/// request's own headers, and signs per HTTP message signatures draft 15 with a DER ECDSA
/// signature. Returns every header to add, ending with <c>upvest-signature-version: 15</c>.
/// </summary>
internal sealed class UpvestHttpMessageSigner
{
    public const string SignatureVersion = "15";
    public const string ApiVersion = "1";

    private static readonly string[] AcceptableAcceptValues = ["application/json", "application/pdf"];

    // Headers a proxy or the transport may add or rewrite, so they are never covered.
    private static readonly string[] IgnorableHeaderPrefixes =
    [
        "cf-", "cdn-", "cookie", "x-", "priority", "upvest-signature", "sec-", "user-agent",
        "accept-encoding", "connection", "host", "expect", "te", "transfer-encoding"
    ];

    private readonly HttpMessageSigner _signer;
    private readonly string _clientId;

    public UpvestHttpMessageSigner(HttpMessageSigner signer, string clientId)
    {
        _signer = signer;
        _clientId = clientId;
    }

    public static bool IsIgnorable(string name)
    {
        if (string.IsNullOrEmpty(name)) return true;
        var lower = name.ToLowerInvariant();
        return IgnorableHeaderPrefixes.Any(p => lower.StartsWith(p, StringComparison.Ordinal));
    }

    public List<KeyValuePair<string, string>> Sign(string method, Uri url,
        IEnumerable<KeyValuePair<string, string>> headers, byte[]? body)
    {
        var existing = new List<KeyValuePair<string, string>>();
        var names = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
        foreach (var header in headers)
        {
            if (IsIgnorable(header.Key)) continue;
            existing.Add(new(header.Key.ToLowerInvariant(), header.Value));
            names.Add(header.Key);
        }

        var upvestHeaders = new List<KeyValuePair<string, string>>();
        var accept = existing.Where(h => h.Key == "accept").Select(h => h.Value).FirstOrDefault();
        if (accept is null || !AcceptableAcceptValues.Contains(accept))
            upvestHeaders.Add(new("accept", "application/json"));
        if (!names.Contains("upvest-api-version"))
            upvestHeaders.Add(new("upvest-api-version", ApiVersion));
        if (!names.Contains("upvest-client-id"))
            upvestHeaders.Add(new("upvest-client-id", _clientId));

        var toCover = new List<KeyValuePair<string, string>>(existing);
        foreach (var header in upvestHeaders)
        {
            var index = toCover.FindIndex(h => h.Key == header.Key);
            if (index >= 0) toCover[index] = header;
            else toCover.Add(header);
        }

        var signed = _signer.Sign(method, url, toCover, body, DateTimeOffset.UtcNow);

        var result = new List<KeyValuePair<string, string>>(upvestHeaders);
        result.AddRange(signed.Headers);
        // The version marker is never covered by the signature, so it goes on last.
        result.Add(new("upvest-signature-version", SignatureVersion));
        return result;
    }
}
