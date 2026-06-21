# Authentication reference (APIMatic .NET)

Full matrix of auth schemes the APIMatic .NET generator supports. Credential classes live under
`{RootNamespace}.Core.Authentication.*` and are identical across SDKs; only the **options property names**
are generated per-API.

## Basic

```csharp
using {RootNamespace}.Core.Authentication.Basic;

options.{BasicAuthProperty} = new BasicAuthCredentials { Username = "...", Password = "..." };
```
Sends `Authorization: Basic base64(username:password)`.

## Bearer

```csharp
options.{BearerAuthProperty} = "ACCESS_TOKEN";
```
Sends `Authorization: Bearer ACCESS_TOKEN`.

## API key — header / query / cookie

A single key string; its placement (header name, query param, or cookie) is fixed by the generated scheme.

```csharp
options.{ApiKeyProperty} = "API_KEY";
```

## OAuth 2.0 — client credentials (machine-to-machine)

```csharp
using {RootNamespace}.Core.Authentication.OAuth2.ClientCredentials;

options.{OAuthProperty} = new OAuth2ClientCredentials
{
    ClientId = "...",
    ClientSecret = "...",
    Scope = "..."           // optional
};
```

## OAuth 2.0 — authorization code (3-legged, with PKCE)

```csharp
using {RootNamespace}.Core.Authentication.OAuth2.AuthorizationCode;

options.{OAuthProperty} = new OAuth2AuthorizationCodeCredentials
{
    ClientId = "...",
    ClientSecret = "...",                       // optional; needed only when PKCE is disabled (Pkce = null)
    RedirectUri = "https://app.example.com/callback",
    Scope = "...",                              // optional
    State = "...",                              // optional CSRF token
    Pkce = PkceMethod.S256,                     // default; RFC 7636
    PromptForAuthorizationCode = async (authorizationUrl, ct) =>
    {
        // Open/redirect the browser to authorizationUrl, then return the
        // authorization code your redirect endpoint received.
        return await GetCodeFromUserAsync(authorizationUrl, ct);
    }
};
```
The SDK exchanges the code for a token and refreshes it when it expires; if the refresh fails, it invokes
`PromptForAuthorizationCode` again to re-authorize.

## OAuth 2.0 — resource owner password

```csharp
using {RootNamespace}.Core.Authentication.OAuth2.Password;

options.{OAuthProperty} = new OAuth2PasswordCredentials
{
    ClientId = "...",
    ClientSecret = "...",   // optional
    Username = "...",
    Password = "...",
    Scope = "..."           // optional
};
```

## Token caching & refresh (all OAuth2 grants)

- Tokens are cached in-memory and reused until ~30s before expiry.
- Refreshable grants (those that return a refresh token) refresh automatically; otherwise a new token is
  acquired.
- On `401`, the cached token is invalidated and re-acquired on the next call.

## Combined / multiple schemes

When an operation (or the whole API) requires more than one scheme, APIMatic composes them:

- **AND** — all schemes are applied to every request (`AuthSchemeAll`).
- **OR** — the first scheme that succeeds is used; if all fail, an `AuthSchemeException` is thrown
  (`AuthSchemeAny`).

You configure this by setting the relevant credentials properties on the options class; the generated
client wires the AND/OR composition for you.

## No auth

Some endpoints/APIs need no credentials (`NoneAuthScheme`) — leave the credentials properties unset.

## Discovering what a specific SDK uses

1. Open `{Api}ClientOptions` and list its nullable credentials properties — this is the **source of truth**
   for what the SDK accepts.
2. The `{RootNamespace}.Core.Authentication/` folder ships every scheme as shared runtime code, so it lists
   schemes the API may not accept — rely on the options class instead.
