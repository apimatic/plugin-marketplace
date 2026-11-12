using UpvestInvestmentApi.Core;
using UpvestInvestmentApi.Core.Authentication;
using UpvestInvestmentApi.Core.Authentication.OAuth2;
using UpvestInvestmentApi.Core.Authentication.OAuth2.ClientCredentials;

namespace UpvestInvestmentApi;

internal sealed class AuthSchemes
{
    public IAuthScheme OauthClientCredentials { get; }

    public AuthSchemes(UpvestInvestmentApiClientOptions options, Server server, RawClient rawClient)
    {
        OauthClientCredentials =
            OAuth2Scheme<OAuth2ClientCredentials>.Create(
                "OauthClientCredentials",
                options.OauthClientCredentials.WithEnvironmentDefaults(
                    "UPVEST_INVESTMENT_API_OAUTH_CLIENT_CREDENTIALS_CLIENT_ID",
                    "UPVEST_INVESTMENT_API_OAUTH_CLIENT_CREDENTIALS_CLIENT_SECRET",
                    "UPVEST_INVESTMENT_API_OAUTH_CLIENT_CREDENTIALS_SCOPE"),
                // Custom code: Upvest reads client_id/client_secret from the form body, not Basic auth (live 400 otherwise).
                OAuth2ClientCredentialsStrategy.ForFormBodyRequest(server.Default("/auth/token"), rawClient),
                options.TimeProvider);
    }
}
