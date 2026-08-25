---
name: dotnet-client-initialization
description: Initialize an APIMatic-generated C#/.NET API client — you construct it from an HttpClient you supply (the SDK doesn't own it; reuse one long-lived instance or an IHttpClientFactory, not one per request) plus an options object, choose a server environment/base URL, and DI-register via the generated Add{Api}Client extension. Use the moment you write `new {Api}Client(...)`, build its options, pick an environment, set up the HttpClient/client lifetime, or register the client in dependency injection — load it even after reading the constructor in the SDK source, since the signature shows the arguments but not the lifetime/reuse rules or DI wiring.
---

<!-- core-surface: APIMatic .NET generator pre-4.0.0 — the client sends no `X-APIMatic-Gen-Version` header.
     Confirmed 2026-08-25 against asadali214/advanced-billing-sample-sdk@v1.0.2: 88 Core/*.cs.
     This surface has NO LoggingOptions, NO RequestOptions, NO RetryOptions.Disabled(). Its retry predicate
     is `.Handle<HttpRequestException>()` OR `.HandleResult(status AND method)` — so transport faults retry
     on EVERY verb and only the status arm is method-gated; MaxRetries = 0 throws in Polly (the floor is 1);
     a retry-ineligible request runs on an EMPTY pipeline and so loses the per-attempt timeout; there is no
     Retry-After handling and no delay clamp.
     verified-this-file: not yet audited against this surface.
     Sampled from one pre-4.0.0 SDK only; another pre-4.0.0 SDK may differ, so re-check before relying on
     this. The paypal-sdk / twilio-sdk copies of this file describe generator 4.0.0 — correct there, wrong
     here. Do NOT copy runtime claims across a core-surface boundary. -->

# Initializing an APIMatic .NET SDK client

This applies to **any** APIMatic-generated .NET SDK. Replace placeholders with the real names from the
SDK you are using:

- `{Api}Client` — the single public client class (e.g. `FooClient`).
- `{Api}ClientOptions` — its options class.
- `{RootNamespace}` — the SDK's root namespace, used in `using` directives. This can differ from the NuGet
  package id (you install by the package id but `using` the namespace).

## Shape of the client

APIMatic .NET SDKs expose **one public client class** constructed from an `HttpClient` and an options
object:

```csharp
public {Api}Client(HttpClient httpClient, {Api}ClientOptions options)
```

Operations are exposed on the client. Most are grouped under **controller properties** (one per API resource
group) and called `client.{ApiGroup}.{Operation}(...)` — for example, a `Widgets` controller's
`ListWidgets` operation is `client.Widgets.ListWidgets(...)`. An operation that belongs to no group sits
**directly on the client**, called `client.{Operation}(...)`. Open the client class **in the SDK source**
(not a decompiled or reflected view of the installed package) to see the available controller properties
(and any direct operations). See `dotnet-calling-endpoints`.

The options class always carries these knobs (auth properties vary per API — see
`dotnet-authentication`):

```csharp
public class {Api}ClientOptions
{
    public ServerEnvironment Environment { get; set; } = ServerEnvironment.Default();
    public RetryOptions Retry { get; set; } = RetryOptions.Default();
    public ServerOptions Server { get; set; } = new();
    // + one nullable credentials property per auth scheme the API declares
}
```

Tuning these knobs — `Retry` (retries, backoff, per-attempt timeout) and `Server` / `Environment` (server
selection and **overriding the base URL**), plus pagination and logging — is covered in
**dotnet-configuration-resilience**.

## Direct instantiation

```csharp
using {RootNamespace};
using {RootNamespace}.Servers;

var options = new {Api}ClientOptions
{
    Environment = ServerEnvironment.Default(),   // pick the environment your API exposes
    // ...set the auth credentials property your API uses (see dotnet-authentication)
};

var httpClient = new HttpClient();               // reuse a single long-lived instance
var client = new {Api}Client(httpClient, options);
```

### HttpClient lifetime

The SDK does **not** own the `HttpClient` — you provide it. Reuse one instance for the app's lifetime
(or use `IHttpClientFactory`); do not create one per request. Attach custom `HttpMessageHandler`s here for
logging, proxies, or custom TLS (see `dotnet-configuration-resilience`).

The client itself is also meant to be **long-lived** — construct it once and reuse it for the app's
lifetime (it's just lightweight controller wrappers over the shared HTTP pipeline). Don't build a new
client per request or per call.

## Choosing the server / base URL

Environments are modeled as a `ServerEnvironment` string-enum with one constant per environment the API
defines (e.g. `ServerEnvironment.Production`, or region constants). Select one on `options.Environment`.
Overriding a templated parameter or the base URL is nested **per server AND per environment** —
`options.Server.{ServerName}.{Environment}.BaseUrl` (with any templated params at the same level), NOT
directly on `ServerOptions`. **dotnet-configuration-resilience** documents this in full and owns
server / base-URL configuration. Inspect `Servers/ServerEnvironment.cs` and `Servers/{ServerName}Options.cs`
for the exact constants and template parameters of your API.

## Dependency injection (ASP.NET Core / generic host)

Every APIMatic .NET SDK ships a `ServiceCollection` extension named `Add{Api}Client`, which registers the
client (transient — fine, because the expensive `HttpClient`/handler pipeline it wraps stays long-lived
and shared via the factory) and wires an `IHttpClientFactory`-managed `HttpClient` (it resolves the **default,
unnamed** factory client, and the `options` you configure are captured once at registration):

```csharp
using {RootNamespace};

builder.Services.Add{Api}Client(options =>
{
    options.Environment = ServerEnvironment.Default();
    // options.{Scheme} = new {Scheme}Credentials { ... };
});
```

To attach custom `DelegatingHandler`s (logging, proxies, custom TLS) under this DI registration, configure
the **default, unnamed** factory client it resolves — e.g.
`services.AddHttpClient(Options.DefaultName).AddHttpMessageHandler(() => new MyHandler());`. See
**dotnet-configuration-resilience**.

Then inject it:

```csharp
public sealed class MyService({Api}Client client)
{
    public Task DoWork() => client.{ApiGroup}.{Operation}(/* ... */);
}
```

## Next

- Configure authentication → **dotnet-authentication**
- Make your first call → **dotnet-calling-endpoints**
- Tune retries/timeouts/logging → **dotnet-configuration-resilience**
