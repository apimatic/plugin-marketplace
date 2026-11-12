---
name: "dotnet-authentication"
description: "Load before wiring credentials into the Upvest Investment API .NET SDK client in C#, or when a call throws AuthSchemeException or comes back 401/403. Covers OAuth 2.0 client credentials and the HTTP message signing every Upvest request needs: the credential each scheme takes, the UpvestInvestmentApiClientOptions property it goes on, the environment variable that fills it when unset, and a startup check that fails fast on a missing secret."
---

# Authenticating the Upvest Investment API .NET SDK client

This API authenticates with OAuth 2.0 client credentials. Each scheme is a **nullable credentials property** on `UpvestInvestmentApiClientOptions`; set the ones below, then construct the client (see `dotnet-client-initialization`).

| Scheme | Property on `UpvestInvestmentApiClientOptions` | Credential |
| --- | --- | --- |
| OAuth 2.0 client credentials | `OauthClientCredentials` | `OAuth2ClientCredentials?` |

**That table, the environment variables below and request signing (next section) are the entire authentication surface of this SDK.** `UpvestInvestmentApi.Core.Authentication` also holds scheme classes this API does not use, so read what is configurable off the properties above rather than off that folder.

## Request signing — required on every call, in addition to OAuth

Upvest rejects any request without an HTTP message signature, including the token request. The client always signs. It uses an `UpvestSigningHook` (namespace `UpvestInvestmentApi.Signing`) if you put one in `options.Hooks`. Otherwise it builds one from the signing environment variables (`UPVEST_API_KEY_ID`, a private key variable, and the client ID). If neither is configured, every call fails before it is sent, with an `InvalidOperationException` naming what to set. Signatures, constructors and the full variable list are in the SDK map, under **Request signing — required on every call** in `sdk-map.md`. Ground them there before writing the code.

## OAuth 2.0 — client credentials (machine-to-machine)

```csharp
using UpvestInvestmentApi.Core.Authentication.OAuth2.ClientCredentials;

options.OauthClientCredentials = new OAuth2ClientCredentials
{
    ClientId = "...",
    ClientSecret = "...",
    Scope = "..."            // optional
};
```

The SDK fetches the token from `https://sandbox.upvest.co/auth/token` and caches it, acquiring a fresh one when it expires; on a `401` it drops the cached token, acquires a new one and re-sends the call once (the upload exception is under **Token caching & refresh**). The token request carries the client id and secret as HTTP Basic credentials, so `ClientSecret` is required.

## Token caching & refresh

- Tokens are cached in-memory, **per client instance**, and reused until **30s** before expiry.
- **`options.OauthClientCredentials` mints one token per scope set.** An operation that declares scopes gets a token requested with exactly those scopes (the SDK map's **Auth** bullet lists them); operations that declare none share one token requested without a scope.
- **Nothing here refreshes**: when a token expires the whole grant re-runs, and a `refresh_token` in the response is ignored — do not infer refresh behaviour from what the provider returns.
- On `401`, the rejected token is dropped, a new one is obtained and the failing request is **re-sent once** — under every retry setting, including `RetryOptions.Disabled()`; a second `401` is returned to you. A request whose body cannot be re-sent (a binary or file upload) is not re-sent, but its `401` still drops the cached token, so the next call recovers.
- After a `401` clears the cache, a token fetch already in flight can still re-populate it, so the next call is not guaranteed a newly fetched token.

Setting `Scope` on the credentials replaces the per-scheme behaviour above with one token requested with that value; an empty `Scope` requests none.

⚠ **If the token response omits `expires_in`, the SDK treats the token as never expiring**: it is cached for the client's lifetime and replaced only after a `401`, so a token revoked server-side keeps being sent until a request fails with it — a failure the one re-send above recovers, at the cost of a round trip.

## Operations that need no credentials

Some operations on this API are public: they send no credential, whatever you set on `UpvestInvestmentApiClientOptions`. You still construct the same client — there is no separate unauthenticated client — and the credentials you configured are simply not applied to those calls.

## Environment variables

A credentials property left `null` is read from an environment variable when the client is constructed — the SDK name in upper snake case, the property name in upper snake case, and for a multi-member credential the member:

| Property on `UpvestInvestmentApiClientOptions` | Environment variables |
| --- | --- |
| `OauthClientCredentials` | `UPVEST_INVESTMENT_API_OAUTH_CLIENT_CREDENTIALS_CLIENT_ID`, `UPVEST_INVESTMENT_API_OAUTH_CLIENT_CREDENTIALS_CLIENT_SECRET`, `UPVEST_INVESTMENT_API_OAUTH_CLIENT_CREDENTIALS_SCOPE` (optional) |

- A value set in code always wins over the environment.
- A variable that is unset, empty or whitespace counts as not configured.
- A multi-member credential is used only when every required variable is set. If some are missing the property stays `null`; constructing the client never throws, and a call that requires that credential fails before anything is sent.
- Variables are read once, when the client is constructed. Changing them afterwards has no effect on an existing client.

Binding `UpvestInvestmentApiClientOptions` from `IConfiguration` keeps both paths: a property the binding leaves `null` still falls back to its variable. The README's **Credentials from environment variables** section shows the binding.

## ⚠ Missing credentials must stop the app from starting

⚠ **Configure nothing and the first call that needs the credential throws.** A credentials property on `UpvestInvestmentApiClientOptions` that nothing fills — code or an environment variable — fails the call with `AuthSchemeException` before anything is sent, naming the scheme. That is a request-time failure for a deployment fault: catch it at startup instead.

**Validate at startup and refuse to boot.** Bind the credentials into your own options type and make the host check it before the app serves anything:

```csharp
builder.Services
    .AddOptions<UpvestInvestmentApiClientSettings>()
    .Bind(builder.Configuration.GetSection("UpvestInvestmentApiClient"))
    .ValidateDataAnnotations()      // [Required] on each credential property
    .ValidateOnStart();             // throws during startup, not on first request
```

`ValidateOnStart()` is the load-bearing call — without it, `IOptions<T>` validation is lazy and fires on first resolution, which is a request, which is exactly the late failure you are trying to avoid. For a console app, an explicit guard is equally acceptable as long as it runs **before** the app is ready:

```csharp
if (string.IsNullOrWhiteSpace(settings.ClientId))
    throw new InvalidOperationException(
        "UpvestInvestmentApiClient:ClientId is not configured. Set it via environment variable, " +
        "user-secrets, or your secret store before starting the app.");
```

**If the SDK's environment variables supply the credential**, `ValidateOnStart()` sees nothing: the SDK reads the variable itself, and a settings type bound from `IConfiguration` would refuse to boot a host the SDK authenticates. Check the variable instead, with the same guard before the host is ready — the **Or environment variable** column below names it.

Three rules for the message it fails with:

- **Name the missing config key or variable**, so the operator knows what to set — `"UpvestInvestmentApiClient:ClientId is not configured"`, not `"authentication failed"`.
- **Never echo the value**, present or absent — no length, no prefix, no masked form. A "configured: AC1234…" line is a secret in a log.
- **Do not fall back to a default, a placeholder, or an unauthenticated client.** Booting degraded hides the fault and pushes it to the first caller.

Check every value the schemes actually need. For this SDK that is:

| Value to validate | Feeds `UpvestInvestmentApiClientOptions` property | Or environment variable |
| --- | --- | --- |
| `ClientId` | `OauthClientCredentials` | `UPVEST_INVESTMENT_API_OAUTH_CLIENT_CREDENTIALS_CLIENT_ID` |
| `ClientSecret` | `OauthClientCredentials` | `UPVEST_INVESTMENT_API_OAUTH_CLIENT_CREDENTIALS_CLIENT_SECRET` |

## Notes

- Set credentials **before** constructing the client, or inside the `AddUpvestInvestmentApiClient(options => ...)` callback when registering via DI. `UpvestInvestmentApiClientOptions` is read at construction; mutating it afterwards does not re-wire an existing client.
- Keep secrets out of source — load them from configuration (environment variables, a secret store, or any other `IConfiguration` source) instead of hardcoding, either inside the `AddUpvestInvestmentApiClient(options => ...)` callback for a host or via a `ConfigurationBuilder()...Build()` chain for a console app — or leave the property unset and let the SDK read its environment variable (see **Environment variables**).

