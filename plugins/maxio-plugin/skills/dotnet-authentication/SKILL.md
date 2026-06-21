---
name: dotnet-authentication
description: Configure authentication on an APIMatic-generated C#/.NET API client — each scheme is a nullable credentials property on the options class (set it before constructing the client, or inside the Add{Api}Client DI callback) — Basic (BasicAuthCredentials), Bearer token, API key (header/query/cookie), and OAuth 2.0 (client-credentials, authorization-code+PKCE, password) plus combined AND/OR schemes. Use the moment you set credentials, an API key, a token, or OAuth on any APIMatic .NET SDK, or need to know which schemes its options class exposes — load it even after reading the options class in the source, since the property type doesn't tell you when to set it or that secrets belong in configuration.
---

# Authenticating an APIMatic .NET SDK client

How you authenticate depends on the security scheme(s) the API uses. APIMatic surfaces each scheme as a
**nullable credentials property on the options class**; set the one(s) your API uses, then construct the
client (see `dotnet-client-initialization`).

> Throughout this skill, `{...}` is a placeholder for a name you take from your SDK (e.g. `{RootNamespace}`,
> `{Api}ClientOptions`, `{BasicAuthProperty}`) — replace it with the concrete identifier from the source.

To see which schemes a specific SDK accepts, read the **credentials properties on its `{Api}ClientOptions`
class** — those are the source of truth (read the class in the SDK source, not a decompiled or reflected
view of the installed package). The `{RootNamespace}.Core.Authentication` folder ships *every*
scheme class as shared runtime code regardless of what the API accepts, so rely on the options class rather
than that folder. (An SDK whose API uses only Basic, for instance, exposes a single
`options.{BasicAuthProperty}` of type `BasicAuthCredentials`.)

The credential classes below live under `{RootNamespace}.Core.Authentication.*` and are the **same across
all APIMatic .NET SDKs**; only the **options property names** are generated per-API (hence the
`{...Property}` placeholders).

## Basic auth

```csharp
using {RootNamespace}.Core.Authentication.Basic;

options.{BasicAuthProperty} = new BasicAuthCredentials
{
    Username = "...",
    Password = "..."
};
```

## Bearer token

Set the configured token property on the options class to your access-token string:

```csharp
options.{BearerAuthProperty} = "ACCESS_TOKEN";
```

## API key (header, query, or cookie)

The key is sent as a header, query parameter, or cookie — its placement and name are fixed by the generated
scheme. Set the configured key property to your key string:

```csharp
options.{ApiKeyProperty} = "API_KEY";
```

## OAuth 2.0 — client credentials

```csharp
using {RootNamespace}.Core.Authentication.OAuth2.ClientCredentials;

options.{OAuthProperty} = new OAuth2ClientCredentials
{
    ClientId = "...",
    ClientSecret = "...",
    Scope = "..."            // optional
};
```

The SDK fetches and caches the token, acquiring a fresh one when it expires; on a `401` it invalidates the
cached token and re-acquires.

## More schemes

For OAuth2 **authorization-code (3-legged, with PKCE)**, **resource-owner password**, **multiple/combined**
schemes (AND/OR), and **no-auth**, see [reference.md](reference.md).

## Notes

- A given SDK only exposes the credentials properties for the schemes its API uses; those names are
  generated per-API (hence the `{...Property}` placeholders above).
- Set credentials **before** constructing the client, or inside the `Add{Api}Client(options => ...)`
  callback when registering via DI.
- Keep secrets out of source — load them from configuration (environment variables, a secret store, or any
  other `IConfiguration` source) instead of hardcoding, either inside the `Add{Api}Client(options => ...)`
  callback for the host or via a `ConfigurationBuilder()...Build()` chain for a console app.

