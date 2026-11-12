# Upvest Investment API

[![Built with APIMatic][apimatic-badge]][apimatic-url] [![License: MIT][license-badge]][license-url]

The Upvest Investment API SDK for .NET provides access to the Upvest Investment API REST APIs from .NET applications.

> [!TIP]
> **Looking for a specific signature, model, enum, or error type?** This SDK ships a generated,
> machine-readable **[SDK map](sdk-map.md)** — a lookup index of the SDK's entire C# surface. Consult it
> **before** grepping or scanning the source tree; it answers most contract questions directly and,
> when a source file is genuinely needed, names the exact one to open. Details under [SDK map](#sdk-map).

Upvest Investment API.

---

## Installation

Add the .NET SDK as a project reference into your solution:

```bash
dotnet add reference <path-to-sdk>/src/UpvestInvestmentApi/UpvestInvestmentApi.csproj
```

The project takes its build settings from the files around it, so reference it in place. Building from source needs the .NET 10 SDK (C# 14); the package itself targets netstandard2.0.

The assembly embeds its PDB, so stack traces carry SDK file and line numbers.

---

## Building from source

```bash
dotnet pack src/UpvestInvestmentApi/UpvestInvestmentApi.csproj -c Release
```

Release packs come from CI, where `CI=true` makes the build deterministic; to reproduce that locally add `-p:ContinuousIntegrationBuild=true`.

The generator never emits `Directory.Build.targets`, so a customer-owned one at the repo root is MSBuild's auto-imported customization seam. It imports after the props and the project body into every project under the root, so put SDK-only settings under `<PropertyGroup Condition="'$(MSBuildProjectName)' == 'UpvestInvestmentApi'">`.

It overrides every property the SDK reads when targets run (package metadata, `Version`, `AssemblyVersion`, compiler warnings, package references, which under central package management use `VersionOverride`). It cannot change values the SDK derives earlier: `TargetFramework(s)`, `AssemblyName` and output paths stay generator settings; turning off `GenerateDocumentationFile` also needs `<DocumentationFile />`; a `ContinuousIntegrationBuild` set there also needs `<DeterministicSourcePaths>true</DeterministicSourcePaths>`.

The SDK's props files are a boundary: a parent repository's `Directory.Build.props` does not apply, while a parent `Directory.Build.targets` does.

APIMatic's delivery tools do not yet preserve `Directory.Build.targets` across regeneration — list it in `.codegenignore` when publishing to GitHub.

---

## Quick Start

### Dependency Injection

Register the client with `IServiceCollection` and resolve it from the container. The `HttpClient` is managed by `IHttpClientFactory`. Configure the client's behavior through [UpvestInvestmentApiClientOptions](src/UpvestInvestmentApi/UpvestInvestmentApiClientOptions.cs).

```csharp
services.AddUpvestInvestmentApiClient(options =>
{
    options.OauthClientCredentials =
        new OAuth2ClientCredentials { ClientId = "YOUR_CLIENT_ID", ClientSecret = "YOUR_CLIENT_SECRET" };
    options.Environment = ServerEnvironment.Production;
    // TODO: configure more client options here
});
```

### Direct Instantiation

Create the client by passing an `HttpClient` you manage yourself. Configure the client's behavior through [UpvestInvestmentApiClientOptions](src/UpvestInvestmentApi/UpvestInvestmentApiClientOptions.cs).

```csharp
var httpClient = new HttpClient();
// TODO: configure more client options here
var options = new UpvestInvestmentApiClientOptions
{
    OauthClientCredentials = new OAuth2ClientCredentials
    {
        ClientId = "YOUR_CLIENT_ID",
        ClientSecret = "YOUR_CLIENT_SECRET",
    },
    Environment = ServerEnvironment.Production,
};
var client = new UpvestInvestmentApiClient(httpClient, options);
```

### Credentials, tokens and 401s

Every credential is an option on `UpvestInvestmentApiClientOptions`.

OAuth2 credentials (`OAuth2ClientCredentials`) are exchanged for a token the SDK caches and renews before it expires. With client credentials, an operation that declares scopes gets its own token per scope set, requested with exactly those scopes; operations that declare none share one token requested without a scope. Setting `Scope` on the credentials replaces that with one token requested with that value, and an empty `Scope` requests none.

When a server answers `401 Unauthorized`:

- An OAuth2-authenticated call drops the rejected token, obtains a new one and is sent again, once, under every retry setting including `RetryOptions.Disabled()`. The retry is logged as `attempt 1/1: 401 Unauthorized`; `RetryOptions.OnRetry` is not called for it. A second `401` is returned to you.

A request whose body cannot be re-sent (a stream upload) is never retried either, but its `401` still drops the cached token, so the next call recovers. A hook that replaces the `Authorization` header makes the token comparison miss; the one retry still happens.

### Required and optional auth

An operation sends only the credentials its API declares. If a required credential is not configured, the call fails before anything is sent with an `AuthSchemeException` that names the scheme (`… requires the OauthClientCredentials scheme, which is not configured.`). A credential that is set but blank is treated as configured and sent as-is: the SDK checks presence, never content.

### Credentials from environment variables

Any credential option left `null` is read from an environment variable when the client is constructed. The variable name is the SDK name and the option's name, each in upper snake case, plus the member name for multi-member credentials:

| Option | Environment variables |
| --- | --- |
| `OauthClientCredentials` | `UPVEST_INVESTMENT_API_OAUTH_CLIENT_CREDENTIALS_CLIENT_ID`, `UPVEST_INVESTMENT_API_OAUTH_CLIENT_CREDENTIALS_CLIENT_SECRET`, `UPVEST_INVESTMENT_API_OAUTH_CLIENT_CREDENTIALS_SCOPE` (optional) |
| logging | `UPVEST_INVESTMENT_API_LOG` = `info`, `debug` or `trace` (read only when no `ILoggerFactory` is set; `AddUpvestInvestmentApiClient` always supplies the container's) |

Rules:

- A value set in code always wins over the environment, including the placeholder assignments in the Quick Start samples; delete the line for any credential you supply through an environment variable.
- A variable that is unset, empty or whitespace counts as not configured.
- A multi-member credential is used only when every required variable is set. If some are missing the option stays `null`; constructing the client never throws, and a call that requires that credential fails before anything is sent (see "Required and optional auth").
- Variables are read once, when the client is constructed. Changing them afterwards has no effect on an existing client.

Hosted applications that already use the .NET options pattern can bind the whole options object from `IConfiguration` instead, which picks up environment variables through the configuration provider (`UpvestInvestmentApi__OauthClientCredentials__ClientId`, and so on):

```csharp
services.AddUpvestInvestmentApiClient(options => configuration.GetSection("UpvestInvestmentApi").Bind(options));
```

Both paths coexist: a slot the bound configuration leaves `null` still falls back to its environment variable.

### Request signing (required by Upvest)

Upvest refuses every request that is not signed with an HTTP message signature, including the token request: an unsigned call fails with `401` ("No "Signature-Input" header found…"). The SDK signs for you. You either add `UpvestSigningHook` (namespace `UpvestInvestmentApi.Signing`) to `Hooks`, or set the signing environment variables below, and the client then adds the hook itself. If neither is configured, every call fails before it is sent, with an `InvalidOperationException` that says what to set. The hook signs every request after the token is applied, following Upvest's profile (draft 15, ECDSA with SHA-512, DER-encoded signature, `content-digest: sha-512=:…:`). It adds `upvest-client-id`, `upvest-api-version` and `upvest-signature-version: 15`. You never set `signature`, `signature-input`, `authorization` or `upvest-client-id` yourself; no operation takes them.

```csharp
using UpvestInvestmentApi.Signing;

var signing = UpvestHttpSignatureCredentials.FromFile(
    keyId: "YOUR_SIGNING_KEY_ID",                // the key ID Upvest registered your public key under
    privateKeyPath: "upvest-signing-key.pem",    // EC P-256/384/521: SEC1, legacy-encrypted SEC1 or PKCS#8
    upvestClientId: "YOUR_CLIENT_ID",            // the upvest-client-id header: your OAuth client ID
    privateKeyPassphrase: null);                 // set when the PEM is encrypted

services.AddUpvestInvestmentApiClient(options =>
{
    options.OauthClientCredentials =
        new OAuth2ClientCredentials { ClientId = "YOUR_CLIENT_ID", ClientSecret = "YOUR_CLIENT_SECRET" };
    options.Environment = ServerEnvironment.Production; // https://sandbox.upvest.co (see note below)
    options.Hooks = [new UpvestSigningHook(signing)];
});
```

`UpvestSigningHook.FromEnvironment()` builds the hook from environment variables instead. It reads `UPVEST_API_KEY_ID`, then one of `UPVEST_API_HTTP_SIGN_PRIVATE_KEY_FILENAME`, `UPVEST_API_HTTP_SIGN_PRIVATE_KEY` or `UPVEST_API_HTTP_SIGN_PRIVATE_KEY_BASE64`, and optionally `UPVEST_API_HTTP_SIGN_PRIVATE_KEY_PASSPHRASE`. The client ID comes from `UPVEST_API_CLIENT_ID`, or else `UPVEST_INVESTMENT_API_OAUTH_CLIENT_CREDENTIALS_CLIENT_ID`. It throws if any of these is missing. `UpvestHttpSignatureCredentials` also has a constructor that takes the PEM text, and `FromEnvironment()` (which returns `null` when unset).

Notes:

- **Environments:** `ServerEnvironment.Production` is `https://sandbox.upvest.co` (the first server in Upvest's API description); `https://api.upvest.co` is the live host. You can also override the base URL through `options.Server`.
- **Token request:** the SDK sends `client_id` and `client_secret` in the form body of `POST /auth/token`, which is what Upvest reads, and the request is signed like any other.
- **Scopes:** each operation requests a token with the scopes its API declares (see "Credentials, tokens and 401s"). Your Upvest client must be granted them, otherwise the token request fails with `401 "This client is not authorised to use these scopes"`.
- **JSON bodies** are sent as `Content-Type: application/json` without a charset parameter, because Upvest answers `400 "unexpected request Content-Type"` to `application/json; charset=utf-8`.
- **Dates:** properties that Upvest defines as dates (`birth_date`, `document_expiration_date`, `issuance_date`, …) are `DateTimeOffset` in C# and are sent as `YYYY-MM-DD`.

---

## Usage

For code examples and error responses, see [API Reference](api-reference.md).

## Enums

Every enum the spec declares is a sealed record with one `public static readonly` member per value (`UpvestApiVersion._1`), a JSON converter, and a `Match` that makes handling exhaustive: one `on{Member}` arm per known value, then `otherwise`, which receives the raw wire value the server sent when it is one this SDK does not declare.

```csharp
var label = received.Match(on_1: () => "_1", otherwise: raw => $"undeclared ({raw})");
```

Prefer named arguments as above. The arms are positional, in the order the spec lists its values, and a regenerated SDK that adds or moves a value changes the `Match` signature: a positional call site compiled against the old shape either stops compiling or, if the assembly is not rebuilt, throws `MissingMethodException` at the first call, and a reordered value can rebind a positional argument to a different member without any diagnostic. Treat an added or moved enum value as a breaking change of that enum. Code that must survive regeneration untouched compares instead of matching: `received == UpvestApiVersion._1` or `received.Is(rawValue)` against a raw wire value; neither reopens construction.

A value the SDK does not declare still round-trips: `IsKnownValue()` tells you whether it is one of the generated members, and sending the instance back echoes the server's own casing. You cannot construct an undeclared value yourself — there is no public factory — so a typo cannot compile; resolve a raw value with `UpvestApiVersion.TryGetKnownValue("1", out var known)`.

A spec value whose name would collide with the enum's own name, with a member every enum inherits or generates (such as `Value`, `Match` or `IsKnownValue`), or with a member of `object` takes a `Member` suffix — a value `value` becomes `ValueMember` — and the other members keep their plain names.

## SDK map

This SDK ships a generated **SDK map** — [`sdk-map.md`](sdk-map.md) plus the [`map/`](map/) pages — a deterministic, lookup-oriented table of contents of the SDK's C# surface, generated by APIMatic alongside this SDK.

**Read it before scanning the source.** Whether you are an AI coding assistant or searching by hand, the map answers "what is the exact …" by lookup for every call-level contract, and for anything it does not carry it names the one file that does — so you never have to search the source tree:

- **[`sdk-map.md`](sdk-map.md)** — the index: client construction, servers/auth, the options/retry reference, the SDK-wide defaults the operation rows rely on, and link tables into [`map/`](map/).
- **[`map/operations/`](map/operations/)** — one page per controller: the exact C# signature, the return type, the error type with its typed `TryGet…` accessors, and pagination — plus, per operation, a **Type sources** table naming the file that declares every type that operation mentions.

Model shapes — record fields with their JSON wire names, enum member names and wire values, `OneOf`/`AnyOf` union variants — are **not** duplicated in the map. Take the path from the operation's Type sources table and read the declaring file; it is the single source of truth and cannot go stale against the code.

**Each operation row states what is specific to that operation.** The SDK-wide defaults are stated once in [`sdk-map.md`](sdk-map.md) — throw-only (no `Result`-style no-throw variants), no pagination, the four fixed `RawError` accessors, the `Default` server group — and a row appears only where its operation departs from one. A row silent on pagination is telling you that operation has none.

The **HTTP verb and route**, and the endpoint's **behavioural prose**, live on the operation itself, in the source file named at the top of its operations page. Read them there when something needs them — wiring a mock, reading a provider log, or settling a rule about what you must pass.

**Workflow:** look the fact up in the map → where the map leaves something ambiguous, open the **one** source file the row names → the compiler is the backstop (a name that isn't in the map won't build). Don't scan or grep the tree to find things — the map is the locator.

### Which one to reach for

The map and the [API Reference](api-reference.md) answer different questions, and the map is generated from this SDK's source so it stays in lockstep with the code it describes.

| Use | For |
| --- | --- |
| **[`sdk-map.md`](sdk-map.md) + [`map/`](map/)** | Traversing the SDK and working out its surface — locating the operation you need (this SDK exposes **160 operations**), its exact signature and request record, the shape and JSON wire names of the models it takes and returns, which error type it throws and how to read it, and the source file behind any of it. This is the index to consume the SDK from, and the one to reach for first. |
| **[`api-reference.md`](api-reference.md)** | Usage guidance for a single operation once you know which one you want — a runnable code sample, a link to its request record, and the error responses it can return. |

## Error Handling

Operations throw when the server answers with an error status. `TError` is the operation's error type from the spec — `RawError` (the status code plus the raw body) when the spec declares none.

```csharp
using UpvestInvestmentApi.Core.Exceptions;         // the exception family
using UpvestInvestmentApi.Errors;                  // generated error types such as IssueTokenError
using UpvestInvestmentApi.Requests.AccessTokens;   // request records such as IssueTokenRequest
using UpvestInvestmentApi.Models.Enums;            // models such as UpvestApiVersion

try
{
    var response = await client.AccessTokens.IssueToken(new IssueTokenRequest
    {
        UpvestApiVersion = UpvestApiVersion._1,
        ClientId = Guid.Parse("363f3305-7ab0-4e82-a158-f9d382ad08b6"),
        ClientSecret = "WHIW1yic-ouct3sceh",
        GrantType = "client_credentials",
        Scope = "users:read",
    });
}
catch (ApiException<IssueTokenError> ex)
{
    // "POST <server>/auth/token returned 400 (BadRequest)."
    Console.Error.WriteLine(ex.Message);
    if (ex.Error.TryGetNoContent(out var noContent))
    {
        // TODO: handle 'noContent' of type RawError
    }
}
```

`Match` on an error type is exhaustive: one `on{Arm}` arm per body the operation declares, each receiving the parsed body, and a last `otherwise` arm that receives the `RawError` (status code plus raw body) of a status the operation does not declare, such as a gateway's 502. An arm is a body, not a status: statuses that share a body share an arm, and the status itself is on `result.StatusCode` or `ex.StatusCode`. `TryGet{Arm}` reads one arm when that is all you need, as in the `catch` above; `TryGetRawError` is the accessor behind `otherwise`.

Prefer named arguments, as with enums and unions: the arms are positional, in the order of their names, and a regenerated SDK whose operation gains or loses an error body changes the `Match` signature — a positional call site stops compiling or, if the assembly is not rebuilt, throws `MissingMethodException` at the first call. Treat an added or removed error body as a breaking change of that error type. A status added for a body the operation already declares changes nothing. Code that must survive regeneration untouched uses the `TryGet{Arm}` accessors instead.

Everything the SDK raises for a call derives from `SdkException`, which carries the failed call's `Method` and `RequestUri`. Every message starts with that call, and the underlying cause is always `InnerException`.

| Exception | When | Extra members |
| --- | --- | --- |
| `ApiException<TError>` | The server answered with an error status | `Error`, plus `StatusCode`, `Headers` and `ContentType` from `ApiException` |
| `ResponseDeserializationException` | A response body did not match the type the spec declares | `TargetType`, plus the `ApiException` members |
| `SdkConnectionException` | The request could not be sent, or the response body could not be read |  |
| `SdkTimeoutException` | An attempt, the transport, or a Server-Sent Events stream went silent (derives from `SdkConnectionException`) | `Timeout` |
| `AuthSchemeException` | A required credential is not configured, or could not be applied — for example the OAuth2 token endpoint refused it | `SchemeFailures` |

Catch from specific to general: `ApiException` means the server answered, `SdkConnectionException` means it did not, and `SdkException` is everything the SDK raises. Your own cancellation surfaces as the usual `OperationCanceledException`, never wrapped.

---

## Best Practices

> [!TIP]
> Use a **single `UpvestInvestmentApiClient` instance** for the lifetime of your application and
> reuse it across all requests. Creating a new instance per request might exhaust the
> connection pool.

> [!TIP]
> Let the SDK own timeouts. `RetryOptions.Timeout` bounds **each attempt** (default 100 s)
> and a timed-out attempt is retried under the configured retry policy before it surfaces as
> `SdkTimeoutException`; `Retry-After` response headers are honored when the server sends them.
> Set `HttpClient.Timeout` to `Timeout.InfiniteTimeSpan` (or comfortably above
> `RetryOptions.Timeout`) so the transport does not race the SDK — a transport-level timeout
> surfaces as the same `SdkTimeoutException` but cannot be retried.

> [!TIP]
> The SDK reads time only through `UpvestInvestmentApiClientOptions.TimeProvider` (default
> `TimeProvider.System`): retry backoff, `Retry-After`, the SSE idle timeout, OAuth2 token
> expiry and the logged request durations all follow it. Under `AddUpvestInvestmentApiClient` a
> `TimeProvider` registered in the container is picked up automatically, and setting the
> option explicitly wins. To fake time in your own tests use a provider that implements
> timers, such as `FakeTimeProvider` from `Microsoft.Extensions.TimeProvider.Testing`, so
> retries and idle timeouts advance with it.

## License

This SDK is distributed under the [MIT License](https://licenses.nuget.org/MIT).

---

## Support

Refer to the [API reference](api-reference.md) for detailed information on available operations with code samples.

For further assistance, please contact support at api@upvest.co.

---

[license-url]: https://licenses.nuget.org/MIT
[license-badge]: https://img.shields.io/badge/License-MIT-blue.svg
[apimatic-url]: https://www.apimatic.io
[apimatic-badge]: https://img.shields.io/badge/Built%20with-APIMatic-blue.svg
