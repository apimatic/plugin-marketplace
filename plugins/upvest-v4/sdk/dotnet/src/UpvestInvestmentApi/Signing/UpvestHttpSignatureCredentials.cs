// Custom code (APIMatic, 2026-11-13): Upvest HTTP message signing for the v4 SDK.
// Ported from the v3 SDK's HttpSignatureCredentials (apimatic/uv-poc-v2).
using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace UpvestInvestmentApi.Signing;

/// <summary>
/// The key material used to sign every request to the Upvest Investment API.
/// Pass it to <see cref="UpvestSigningHook"/>, and put that hook in
/// <c>UpvestInvestmentApiClientOptions.Hooks</c>.
/// </summary>
public sealed class UpvestHttpSignatureCredentials : IDisposable
{
    private readonly ECDsa _privateKey;
    private bool _disposed;

    /// <param name="keyId">The key ID Upvest registered the matching public key under.</param>
    /// <param name="privateKeyPem">The EC private key (P-256/384/521) in PEM: SEC1, legacy-encrypted SEC1, or PKCS#8.</param>
    /// <param name="upvestClientId">The <c>upvest-client-id</c> header value: your OAuth client ID.</param>
    /// <param name="privateKeyPassphrase">The passphrase, when the PEM is encrypted.</param>
    public UpvestHttpSignatureCredentials(string keyId, string privateKeyPem, string upvestClientId,
        string? privateKeyPassphrase = null)
    {
        if (string.IsNullOrEmpty(keyId)) throw new ArgumentException("A key ID is required.", nameof(keyId));
        if (string.IsNullOrWhiteSpace(privateKeyPem)) throw new ArgumentException("A private key is required.", nameof(privateKeyPem));
        if (string.IsNullOrEmpty(upvestClientId)) throw new ArgumentException("The upvest-client-id is required.", nameof(upvestClientId));
        KeyId = keyId;
        UpvestClientId = upvestClientId;
        _privateKey = PemKeyReader.ReadEcPrivateKey(privateKeyPem, privateKeyPassphrase);
    }

    /// <summary>The key ID sent as the <c>keyid</c> signature parameter.</summary>
    public string KeyId { get; }

    /// <summary>The value sent in the <c>upvest-client-id</c> header.</summary>
    public string UpvestClientId { get; }

    /// <summary>Loads the private key from a PEM file.</summary>
    public static UpvestHttpSignatureCredentials FromFile(string keyId, string privateKeyPath, string upvestClientId,
        string? privateKeyPassphrase = null) =>
        new(keyId, File.ReadAllText(privateKeyPath), upvestClientId, privateKeyPassphrase);

    /// <summary>
    /// Reads <c>UPVEST_API_KEY_ID</c>, one of <c>UPVEST_API_HTTP_SIGN_PRIVATE_KEY_FILENAME</c>,
    /// <c>UPVEST_API_HTTP_SIGN_PRIVATE_KEY</c> or <c>UPVEST_API_HTTP_SIGN_PRIVATE_KEY_BASE64</c>,
    /// optionally <c>UPVEST_API_HTTP_SIGN_PRIVATE_KEY_PASSPHRASE</c>, and the client ID from
    /// <c>UPVEST_API_CLIENT_ID</c>, else <c>UPVEST_INVESTMENT_API_OAUTH_CLIENT_CREDENTIALS_CLIENT_ID</c>.
    /// Returns null when the key ID, the key or the client ID is missing.
    /// </summary>
    public static UpvestHttpSignatureCredentials? FromEnvironment()
    {
        var keyId = Read("UPVEST_API_KEY_ID");
        var pem = ReadPem();
        var clientId = Read("UPVEST_API_CLIENT_ID") ?? Read("UPVEST_INVESTMENT_API_OAUTH_CLIENT_CREDENTIALS_CLIENT_ID");
        if (keyId is null || pem is null || clientId is null) return null;
        return new UpvestHttpSignatureCredentials(keyId, pem, clientId, Read("UPVEST_API_HTTP_SIGN_PRIVATE_KEY_PASSPHRASE"));
    }

    internal UpvestHttpMessageSigner CreateSigner() =>
        new(new HttpMessageSigner(_privateKey, KeyId), UpvestClientId);

    public void Dispose()
    {
        if (_disposed) return;
        _disposed = true;
        _privateKey.Dispose();
    }

    private static string? ReadPem()
    {
        if (Read("UPVEST_API_HTTP_SIGN_PRIVATE_KEY_FILENAME") is { } path) return File.ReadAllText(path);
        if (Read("UPVEST_API_HTTP_SIGN_PRIVATE_KEY") is { } pem) return pem;
        if (Read("UPVEST_API_HTTP_SIGN_PRIVATE_KEY_BASE64") is { } b64) return Encoding.UTF8.GetString(Convert.FromBase64String(b64));
        return null;
    }

    private static string? Read(string name)
    {
        var value = System.Environment.GetEnvironmentVariable(name);
        return string.IsNullOrWhiteSpace(value) ? null : value;
    }
}
