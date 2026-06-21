---
name: paypal-getting-started
description: Identify and orient in the PayPal Server SDK (Orders, Payments, Subscriptions, Vault, Transaction Search) .NET SDK — its NuGet package id and root namespace, the namespace layout, the Sandbox environment and the OAuth 2.0 client-credentials pattern, and how to clone and navigate the SDK source for reference. Use when installing, setting up, or first working with the PayPal SDK in a C#/.NET project. It also routes you to the companion dotnet-* skills (client-setup, auth, calling endpoints, models, error handling, configuration/resilience, testing) and gates loading each at its step — load them even after you've read the SDK source, since the source shows signatures but not the usage gotchas these skills carry.
---

# Getting started with the PayPal Server SDK for .NET

This is the **SDK-specific** entry point. For general patterns that apply to any APIMatic-generated
.NET SDK (auth, calling endpoints, models, error handling, retries, testing), see the companion
API-agnostic skills: `dotnet-client-initialization`, `dotnet-authentication`, `dotnet-calling-endpoints`,
`dotnet-models`, `dotnet-error-handling`, `dotnet-configuration-resilience`, `dotnet-testing`.

**The source and these companion skills are complementary — load both.** The cloned source is authoritative
for the SDK's *surface* (signatures, model shapes, enums, which error type an operation throws); the companion
skills are the *usage layer* on top — the best-practice way to call each piece and the gotchas a signature
can't show. Reading the source doesn't remove the need to load the skill for that step, so at each step below,
load the companion *and* confirm names against the source.

> **Before writing any integration code, clone the SDK source** (one command, in the *SDK source* section
> below) and read it to confirm every signature, model, enum, and error type as you go. Do **not** decompile
> or reflect over the installed package, and do **not** fetch GitHub files ad hoc — clone once, then grep the
> local copy. It's a throwaway reference: delete it when the integration is done.

## SDK identity

| | |
| --- | --- |
| API | PayPal Server SDK (Orders v2, Payments v2, Subscriptions v1, Vault/Payment Method Tokens v3, Transaction Search v1) |
| NuGet package | `AsadAli.Checkout.Sdk` |
| Root namespace | `PayPalServerSdk` (the `using` namespace — note it differs from the package id) |
| Client class | `PayPalServerSdkClient` |
| Options class | `PayPalServerSdkClientOptions` |
| Auth | OAuth 2.0 **client credentials** — `ClientId` + `ClientSecret` (optional `Scope`); the SDK fetches and refreshes the bearer token from `/v1/oauth2/token` for you |
| Environments | `ServerEnvironment.Sandbox` (default) → `https://api-m.sandbox.paypal.com` |
| Target framework | `netstandard2.0` (works on .NET Framework 4.6.1+, .NET Core 2.0+, .NET 5–10+) |

The table above is **orientation, not a copy-paste recipe** — it gives you the names and facts (package id,
namespaces, the auth *pattern*, the environments), while the actual integration code comes from the companion
skills. Load each one as you reach its step (see **Integration workflow** below) and confirm its types
against the cloned source: the client construction and DI from `dotnet-client-initialization`, the exact
auth-credentials property name from `dotnet-authentication`, each call from `dotnet-calling-endpoints`, and so
on.

## Namespaces (using-directives)

The SDK splits its public types across **separate child namespaces**. C# does **not** import child
namespaces transitively, so `using PayPalServerSdk.Models;` alone does **not** make enums, union
types, or error types visible — you get `CS0103`/`CS0246` ("name/type does not exist") on build. Add a
separate `using` for each kind of type you reference — when a name won't resolve, open its file in the
cloned source and copy the `namespace` declaration at its top.

## Install — always via NuGet

Add the published NuGet package to your project. **Do not** add a project reference to the SDK's `.csproj`
or copy/clone its source into your solution — depend on the package only. (For *reading* the SDK source while
you code, clone it separately as a read-only reference — see the **SDK source** section below.)

```bash
dotnet add package AsadAli.Checkout.Sdk
```

> The NuGet **package id** (`AsadAli.Checkout.Sdk`) differs from the **root namespace** you import
> (`PayPalServerSdk`): install by the package id, but write `using PayPalServerSdk;` in code.
> Package: <https://www.nuget.org/packages/AsadAli.Checkout.Sdk/>. Runtime dependencies are pulled
> in transitively: `Polly`, `Microsoft.Extensions.Http`, `System.Net.Http.Json`,
> `System.Net.ServerSentEvents`.

## SDK source — clone it first; don't reflect or fetch files

You will constantly need to confirm real method signatures, model shapes, enums, and error types, and the
**only reliable way** is to read the SDK source. So **clone it once, up front — before writing integration
code** — into your **system temp directory** (outside your solution), then read and grep the local copy.
It is a read-only, throwaway reference, **not** a build dependency (never add a project reference to it), and
the OS reaps it — but delete it yourself once the integration is done:

```bash
# Linux:
git clone --depth 1 https://github.com/asadali214/checkout-sample-sdk /tmp/paypal-sdk-src
# macOS:
git clone --depth 1 https://github.com/asadali214/checkout-sample-sdk "$TMPDIR/paypal-sdk-src"
```

```powershell
# Windows (PowerShell):
git clone --depth 1 https://github.com/asadali214/checkout-sample-sdk "$env:TEMP\paypal-sdk-src"
```

Then confirm the SDK shape **only** from that local clone — not by either of these:

- **Don't decompile or run reflection over the installed package.** A compiled assembly drops what the source
  carries and the other skills rely on: the XML `<exception>`/parameter doc-comments, the exact parameter
  names and order, and each method's internal `new Param("snake_case", …)` request-builder list.
- **Don't fetch GitHub files one at a time** as your way in — `…/blob/…` pages return HTML (not source) and
  guessed paths fail, which is exactly how ad-hoc fetching breaks. Clone once and read locally instead. Only
  if you truly cannot clone (`git` is unavailable) fetch a **raw** URL of the form
  `https://raw.githubusercontent.com/asadali214/checkout-sample-sdk/main/…` (never a `…/blob/…`
  page) — e.g. `…/main/api-reference.md` or `…/main/Api/Orders.cs`.

Layout — grep the clone here first:

- `Api/` — one file per controller/group (`Orders`, `Payments`, `Subscriptions`, `TransactionSearch`,
  `Vault`); **this is where the operation methods and their signatures live** (each carries XML-doc comments
  for the params, the endpoint path, and the thrown error type).
- `Models/` (+ `Models/Enums/`) — request/response records, enums, and any union types.
- `Errors/` — per-operation `{Operation}Error` types.
- `Core/` — HTTP infrastructure (`SdkException<T>`, `RawError`, `ApiResult<T>`, auth, retries).
- `Servers/`, `PayPalServerSdkClient.cs`, `ServiceCollectionExtensions.cs` — environments, the client, DI.
- `api-reference.md` — a generated index of **every** endpoint with its signature, the thrown
  `SdkException<{Operation}Error>` type, and a usage snippet; grep it for an operation or resource name to
  find the right call fast, then open that method in `Api/` for the full signature.

If the source has drifted from your installed package version, check out the tag/release matching
`AsadAli.Checkout.Sdk`'s version before relying on it.

**Clean up when the integration is done.** The clone is a throwaway reference with nothing of yours in it, so
once your code builds and the calls work, delete it:

```bash
rm -rf /tmp/paypal-sdk-src        # Linux
rm -rf "$TMPDIR/paypal-sdk-src"   # macOS
```

```powershell
# Windows (PowerShell):
Remove-Item -Recurse -Force "$env:TEMP\paypal-sdk-src"
```

## Integration workflow — load the companion skill at each step

Before you write the code for each step, load the named companion skill — even if you've already read the
relevant source. Each step calls out the trap the signature hides (in *parens*). A typical integration reaches
them in this order:

1. **Client & DI setup** — load **dotnet-client-initialization** before you write
   `new PayPalServerSdkClient(...)`, build its options, or DI-register via
   `AddPayPalServerSdkClient`. (*The signature won't tell you:* the `HttpClient` and client must be
   long-lived and reused, not created per request.)
2. **Authentication** — load **dotnet-authentication** before you set credentials. PayPal is OAuth 2.0
   client credentials — set `Oauth2 = new OAuth2ClientCredentials { ClientId = …, ClientSecret = … }`; the
   SDK obtains and refreshes the bearer token automatically. (*The signature won't tell you:* set credentials
   before constructing the client or in the DI callback, and load the client id/secret from configuration
   rather than hardcoding.)
3. **Calling an endpoint / building a request body** — load **dotnet-calling-endpoints** before the first
   `client.{ApiGroup}.{Operation}(...)` call. (*The signature won't tell you:* call list/search ops with
   named arguments — many optional params have no C# default and mis-bind in a positional call.)
4. **Models** — load **dotnet-models** the moment a request/response field isn't a plain string or number.
   (*The signature won't tell you:* unions are built with factory methods and read via `TryGet…` (no `new`),
   enums are `StringEnum<T>` not C# enums, and unmodeled JSON fields are dropped on deserialize.)
5. **Error handling** — load **dotnet-error-handling** before you write any `try/catch`. (*The signature won't
   tell you:* list/find/delete ops throw `SdkException<RawError>` with no typed accessors, and `TryGetRawError`
   is not a catch-all on the typed `{Operation}Error`s.)
6. **Configuration & resilience** — load **dotnet-configuration-resilience** when you tune retries, timeouts,
   the base URL, pagination, or logging. (*The signature won't tell you:* retries cover idempotent verbs only —
   `POST`/`DELETE` aren't retried — `Timeout` is per-attempt not total, and there's no built-in logging hook.)
7. **Testing** — load **dotnet-testing** before you stub the SDK. (*The signature won't tell you:* the
   `HttpClient` constructor argument is the test seam; match the project's existing framework and assertion
   style.)
