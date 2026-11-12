// Custom code (APIMatic, 2026-11-13): sign by default, the way OAuth credentials default from the environment.
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using UpvestInvestmentApi.Core.Hooks;

namespace UpvestInvestmentApi.Signing;

/// <summary>
/// Called once by the client constructor. Upvest rejects unsigned requests, so the client always signs:
/// <list type="bullet">
/// <item>if <c>options.Hooks</c> already holds an <see cref="UpvestSigningHook"/>, it is used as given;</item>
/// <item>else, if the signing environment variables are set (see <see cref="UpvestHttpSignatureCredentials.FromEnvironment"/>),
/// a hook built from them is appended, last, so it signs the final request;</item>
/// <item>else a hook is appended that fails every call before it is sent, naming what to configure.</item>
/// </list>
/// </summary>
internal static class UpvestSigningDefaults
{
    public static IReadOnlyList<SdkHook> WithSigning(IReadOnlyList<SdkHook> hooks)
    {
        if (hooks.Any(h => h is UpvestSigningHook)) return hooks;
        var credentials = UpvestHttpSignatureCredentials.FromEnvironment();
        SdkHook signing = credentials is not null ? new UpvestSigningHook(credentials) : new SigningNotConfiguredHook();
        return [.. hooks, signing];
    }

    private sealed class SigningNotConfiguredHook : SdkHook
    {
        public override ValueTask BeforeRequest(HttpRequestMessage request, HookContext context, CancellationToken cancellationToken) =>
            throw new InvalidOperationException(
                $"{context.Method} {context.Uri} was not sent: Upvest requires every request, including the token request, " +
                "to carry an HTTP message signature, and request signing is not configured. Either add " +
                "UpvestInvestmentApi.Signing.UpvestSigningHook to UpvestInvestmentApiClientOptions.Hooks, or set the environment " +
                "variables UPVEST_API_KEY_ID, one of UPVEST_API_HTTP_SIGN_PRIVATE_KEY_FILENAME / UPVEST_API_HTTP_SIGN_PRIVATE_KEY / " +
                "UPVEST_API_HTTP_SIGN_PRIVATE_KEY_BASE64 (plus UPVEST_API_HTTP_SIGN_PRIVATE_KEY_PASSPHRASE if the key is encrypted), " +
                "and UPVEST_API_CLIENT_ID or UPVEST_INVESTMENT_API_OAUTH_CLIENT_CREDENTIALS_CLIENT_ID, before the client is constructed.");
    }
}
