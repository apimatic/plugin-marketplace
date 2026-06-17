---
name: advanced-billing-sdk-initialization
description: >-
  Install, instantiate, and configure an APIMatic-generated C# (.NET) v4 SDK
  client — dependency injection vs. direct instantiation, server/environment
  selection, every authentication scheme (Basic, Bearer, API key, OAuth 2.0),
  retry/timeout tuning, and client-lifetime best practices. Use when setting up,
  wiring, authenticating, or configuring any such SDK in a .NET app.
---

# Initializing an APIMatic-generated C# v4 SDK

APIMatic v4 SDKs for .NET all follow the same shape. Once you know the conventions
below, every SDK initializes the same way — only the names change.

## 1. Identify the SDK's naming conventions

Everything is derived from the SDK's **PascalCase product name** (call it `<Sdk>`).
For the Maxio example, `<Sdk>` = `MaxioAdvancedBilling`.

| Concept | Convention | Maxio example |
|---|---|---|
| Root namespace | `<Sdk>` | `MaxioAdvancedBilling` |
| Client class | `<Sdk>Client` | `MaxioAdvancedBillingClient` |
| Options class | `<Sdk>ClientOptions` | `MaxioAdvancedBillingClientOptions` |
| DI extension method | `Add<Sdk>Client` | `AddMaxioAdvancedBillingClient` |
| `.csproj` to reference | `<Sdk>.csproj` | `MaxioAdvancedBilling.csproj` |

To discover the exact names in an unfamiliar SDK, read these three files at the SDK root:
`<Sdk>Client.cs`, `<Sdk>ClientOptions.cs`, and `ServiceCollectionExtensions.cs`.
The options class is the single source of truth for **what can be configured**
(environment, retry, server, and which auth credential properties exist).

## 2. Install / reference the SDK

These SDKs target `netstandard2.0` (LangVersion 14), so they consume from any modern
.NET project. Add a project reference:

```bash
dotnet add reference <path-to-sdk>/<Sdk>.csproj
```

If distributed as a NuGet package instead, `dotnet add package <PackageId>`.
Transitive dependencies (`Microsoft.Extensions.Http`, `Polly`, `System.Net.Http.Json`)
are pulled in automatically.

## 3. Choose an instantiation path

### Option A — Dependency injection (recommended for ASP.NET Core / hosted apps)

Register once at startup; the SDK wires up `IHttpClientFactory` for you so the
underlying `HttpClient` is pooled correctly.

```csharp
services.AddMaxioAdvancedBillingClient(options =>
{
    options.BasicAuth = new BasicAuthCredentials
    {
        Username = "YOUR_USERNAME",
        Password = "YOUR_PASSWORD",
    };
    options.Environment = ServerEnvironment.Us;
    // configure retry, server, etc. here
});
```

Then inject the client wherever you need it:

```csharp
public class BillingService(MaxioAdvancedBillingClient client)
{
    // use `client`
}
```

> The generated client is registered as **transient**, but it is cheap to construct
> and shares the factory-managed `HttpClient`, so this is safe and idiomatic.

### Option B — Direct instantiation

You own and manage the `HttpClient`. Use this for console apps, tests, or when you
already have a configured `HttpClient`.

```csharp
var httpClient = new HttpClient();
var options = new MaxioAdvancedBillingClientOptions
{
    BasicAuth = new BasicAuthCredentials
    {
        Username = "YOUR_USERNAME",
        Password = "YOUR_PASSWORD",
    },
    Environment = ServerEnvironment.Us,
};
var client = new MaxioAdvancedBillingClient(httpClient, options);
```

## 4. Select the server environment

Every SDK ships a `ServerEnvironment` (a `StringEnum`) exposing the API's named
environments as static fields, plus a `Default()`. Read `Servers/ServerEnvironment.cs`
to see the available values.

```csharp
options.Environment = ServerEnvironment.Us;   // Maxio: Us | Eu, Default() => Us
```

Per-environment base URLs / template parameters (subdomains, ports, etc.) live in
`options.Server` (`ServerOptions`), with one nested options object per server group
(e.g. `options.Server.Production`, `options.Server.Ebb`). Override these only when you
need a non-standard host (sandbox, self-hosted, regional override):

```csharp
options.Server.Production = new ProductionOptions { /* subdomain, etc. */ };
```

## 5. Configure authentication

The auth properties on the options object tell you which schemes the API supports.
Set whichever the SDK exposes. Common shapes:

**Basic** (Maxio uses this — note Maxio's quirk: username = API key, password = `x`):
```csharp
options.BasicAuth = new BasicAuthCredentials { Username = "API_KEY", Password = "x" };
```

**Bearer token:**
```csharp
options.BearerAuth = "YOUR_ACCESS_TOKEN"; // or a credentials object, per the options class
```

**API key** (header / query / cookie — the options property name indicates which):
```csharp
options.ApiKey = "YOUR_API_KEY";
```

**OAuth 2.0** — the SDK generates a credentials type per grant it supports
(`OAuth2ClientCredentials`, `OAuth2AuthorizationCodeCredentials`,
`OAuth2PasswordCredentials`):
```csharp
options.OAuth = new OAuth2ClientCredentials
{
    ClientId = "...",
    ClientSecret = "...",
    Scope = "...", // optional
};
```
OAuth schemes fetch/refresh tokens automatically via the SDK's token strategy; you
do not manage the token lifecycle yourself.

**Multiple schemes:** when an endpoint accepts several, the SDK combines them with
AND (all must apply) or OR (first success wins) logic internally — you just populate
every credential the options object exposes.

> Never hard-code secrets. Pull credentials from configuration / environment
> variables / a secrets manager (`IConfiguration`, `Environment.GetEnvironmentVariable`).

## 6. Tune retries and timeout (optional)

`options.Retry` is a `RetryOptions` record with sensible defaults (`RetryOptions.Default()`):
3 retries, exponential backoff (factor 2) from a 1s delay, up to 500ms jitter, a 100s
per-request timeout, retrying `408/429/500/502/503/504` on idempotent methods
(`GET/HEAD/PUT/OPTIONS`).

Override by assigning a new record (all members are `required`, so start from `Default()`
and `with`-copy what you change):

```csharp
options.Retry = RetryOptions.Default() with
{
    MaxRetries = 5,
    Timeout = TimeSpan.FromSeconds(30),
    OnRetry = attempt => logger.LogWarning(
        "Retry #{N} after {Delay} ({Reason})",
        attempt.AttemptNumber, attempt.Delay, attempt.Reason),
};
```

`OnRetry` receives a `RetryAttempt` whose `Reason` is either
`RetryReason.Status(HttpStatusCode)` or `RetryReason.Failure(Exception)` — useful for
observability.

## 7. Client lifetime — the one rule that matters

**Create a single client instance and reuse it for the application's lifetime.**
Constructing a new client per request can exhaust the connection pool. With DI this is
handled for you (the `HttpClient` is factory-managed); with direct instantiation, hold
the client (and its `HttpClient`) in a long-lived singleton/static field.

## Verification checklist

- [ ] Project references `<Sdk>.csproj` (or the NuGet package).
- [ ] Exactly one client instance lives for the app's lifetime.
- [ ] The auth property matching the API's scheme is populated from secure config.
- [ ] `Environment` (and `Server` overrides, if any) point at the intended host.
- [ ] Secrets are not hard-coded.

After this, see the **advanced-billing-sdk-usage** skill for calling endpoints and handling
responses and errors.
