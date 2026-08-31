---
name: dotnet-authentication
description: Authentication for the CyberSourceMergedSpec .NET SDK (Visa/CyberSource) in C# — this SDK declares no security scheme and its options class carries no credentials property, so every call is authenticated by an opt-in HTTP Signature SdkHook configured from environment variables. Load before wiring authentication, before the first call to any endpoint, or when a call returns 401/403 despite the signature looking correct.
---

# Authenticating the CyberSourceMergedSpec .NET SDK client

**This SDK has no generated authentication.** The merged spec declares no security scheme, so APIMatic
generated no credentials property: `CyberSourceMergedSpecClientOptions` exposes only `Environment`,
`Retry`, `Logging`, `Server` and `Hooks`. There is nothing to set on the options class, and no
`IAuthScheme` is wired into the request pipeline.

That does **not** make the API unauthenticated. Every request must carry a **Visa/CyberSource HTTP
Signature**, and this SDK produces it with a self-contained **`SdkHook`** added to the client at
construction when its environment variables resolve. That hook is the only authentication route this SDK
has — there is no options-class alternative to fall back on.

> **This skill names concrete types on purpose and is NOT portable.** Unlike the other `dotnet-*` skills
> in this plugin, it describes one SDK. Do not copy it into another APIMatic .NET plugin: in an SDK whose
> spec *does* declare security schemes, authentication is a credentials property on the options class and
> none of the mechanism below applies.

`CyberSourceMergedSpec.Core.Authentication` ships every scheme class (Basic, Bearer, API key, OAuth 2.0,
composite) as shared runtime code in **every** APIMatic .NET SDK, whatever its API accepts. Its presence
here is not evidence that any of those schemes work against this API — nothing is generated to use them.
Read the options class, not that folder.

## Enabling it

Four environment variables. The first three names below are the terms CyberSource's EBC portal
(Merchant Configuration → Key Management → HTTP Signature) uses:

| EBC portal term | Environment variable | Notes |
| --- | --- | --- |
| Org ID | `VISA_MERCHANT_ID` | The merchant ID |
| Key | `VISA_KEY_ID` | The `keyid` sent in the `signature` header |
| Shared Secret Key | `VISA_SECRET_KEY` | **Base64** string, exactly as the portal shows it — decoded before use as the HMAC key |
| *(none — internal switch)* | `APIMATIC_EXPERIMENTAL_VISA_HTTP_SIGNATURE` | Must be the literal string `"true"` to activate anything below |

```
APIMATIC_EXPERIMENTAL_VISA_HTTP_SIGNATURE=true
VISA_MERCHANT_ID=your-org-id
VISA_KEY_ID=your-key-id
VISA_SECRET_KEY=your-shared-secret-key-base64
```

Resolution happens **once, synchronously, inside the `CyberSourceMergedSpecClient` constructor**
(`VisaHttpSignatureConfigResolver.Resolve()`), reading `Environment.GetEnvironmentVariable` directly. Set
these **before** constructing the client — setting them afterwards has no effect on a client that already
exists.

Two outcomes, and the difference matters:

- Switch unset, or anything other than exactly `"true"` → `Resolve()` returns `null`, **the hook is never
  added, and every request goes out unsigned.** Calls do not fail locally; they reach CyberSource without
  a signature and are rejected there.
- Switch set to `"true"` but any of `VISA_MERCHANT_ID` / `VISA_KEY_ID` / `VISA_SECRET_KEY` missing or
  blank → `Resolve()` **throws `VisaHttpSignatureConfigurationError` at client construction**, naming the
  missing variable(s). It does not fail later, on a call.

## Where it lives

`Core/Experimental/VisaHttpSignature/`:

| File | Role |
| --- | --- |
| `VisaHttpSignatureConfig.cs` | `MerchantId` / `KeyId` / `SecretKey`, plus an optional `Func<DateTimeOffset>? Now` clock override; also declares `VisaHttpSignatureConfigurationError` and `VisaHttpSignatureRequestError`. |
| `VisaHttpSignatureConfigResolver.cs` | The environment-variable reader described above. |
| `VisaHttpSignatureHook.cs` | The signer — an `SdkHook` subclass. |

The constructor appends it to whatever hooks were supplied:

```csharp
var visaHttpSignatureConfig = VisaHttpSignatureConfigResolver.Resolve();
IReadOnlyList<SdkHook> hooks = options.Hooks;
if (visaHttpSignatureConfig is not null)
    hooks = [.. hooks, new VisaHttpSignatureHook(visaHttpSignatureConfig)];
```

Hooks passed via `CyberSourceMergedSpecClientOptions.Hooks` still run; this one is appended after them,
only when the variables resolve.

## What it signs

The hook runs in `RawClient`'s `BeforeRequest` pipeline — after the body and headers are finalized,
immediately before the message is sent — and mutates the `HttpRequestMessage` by adding headers. Hooks
re-run on **every retry attempt** (`RawClient` builds a fresh `HttpRequestMessage` per attempt), so the
date and signature are always freshly computed and never go stale across a retry.

For each request it:

1. Computes `date` as `DateTimeOffset.UtcNow` (or `VisaHttpSignatureConfig.Now()` when set), formatted
   RFC-1123 (`"R"`, e.g. `Fri, 28 Aug 2026 12:00:00 GMT`).
2. For `POST` / `PUT` / `PATCH` **only**, reads the body (empty string when there is none),
   SHA-256-hashes it, and builds `digest: SHA-256=<base64>`. `GET` / `DELETE` and the rest get **no
   digest line at all** — not an empty one.
3. Builds the validation string (no trailing newline on the last line):
   ```
   host: <request URI authority, host[:port]>
   date: <the RFC-1123 date from step 1>
   request-target: <lowercased method> <path + query>
   digest: <from step 2, only when applicable>
   v-c-merchant-id: <VISA_MERCHANT_ID>
   ```
4. HMAC-SHA256-signs that string with the **base64-decoded** `VISA_SECRET_KEY` as the key,
   base64-encodes the result, and sets:
   - `Date` and `v-c-date` — both the same formatted date
   - `v-c-merchant-id` — the merchant ID
   - `digest` — only when step 2 produced one
   - `signature` — `keyid="...", algorithm="HmacSHA256", headers="...", signature="..."`, where
     `headers` is `"host date request-target digest v-c-merchant-id"` (POST/PUT/PATCH) or
     `"host date request-target v-c-merchant-id"` (everything else)

**`host` comes from the request URI, so overriding the base URL changes what is signed.** The hook reads
the authority off the outgoing message rather than from any configured constant, so pointing
`options.Server.Default.Production.BaseUrl` at a different address signs that address automatically.
Never hard-code a host into a signature or rebuild the signing string yourself from a configured value —
the signed host and the host actually called must agree, and letting the hook derive it is what keeps
them in agreement.

**JSON bodies only.** For POST/PUT/PATCH, if the request has a body whose `Content-Type` is set and does
not contain `"json"`, the hook throws `VisaHttpSignatureRequestError` rather than sign content it cannot
safely re-serialize as text.

## ⚠ Missing credentials must stop the app from starting

Everything above covers supplying the credentials. This covers their **absence** — the case a
configuration-driven app hits in the real world.

**A missing credential is a deployment fault, not a request fault.** The resolver already enforces that:
with the switch on and a variable blank it throws at **client construction**. Your job is not to add the
check — it is to **not defeat it**:

- **Do not catch `VisaHttpSignatureConfigurationError` and continue.** Construction is where the fault is
  cheap and unambiguous. Swallowing it produces a client that sends unsigned requests, and an operator
  then sees a provider outage rather than an unset variable.
- **Do not leave the switch off to "degrade gracefully".** Unset means unsigned, and unsigned means every
  call is rejected at CyberSource. There is no working unauthenticated mode to fall back to.
- **Construct the client during startup, not lazily on first request.** Registering it through DI with
  `AddCyberSourceMergedSpecClient(...)` and resolving it once at startup surfaces the fault before the app
  serves anything. If you bind the values into an options object first, validate that too:

```csharp
builder.Services
    .AddOptions<VisaSettings>()
    .Bind(builder.Configuration.GetSection("Visa"))
    .ValidateDataAnnotations()      // [Required] on each credential property
    .ValidateOnStart();             // throws during startup, not on first request
```

`ValidateOnStart()` is the load-bearing call — without it `IOptions<T>` validation is lazy and fires on
first resolution, which is a request, which is the late failure you are avoiding.

Three rules for whatever message the failure surfaces:

- **Name the missing variable**, so an operator knows what to set — not `"authentication failed"`.
- **Never echo the value**, present or absent — no length, no prefix, no masked form. A
  `"configured: RR3l…"` line is a secret in a log.
- **Do not fall back to a default, a placeholder, or an unsigned client.**

## Testing / overriding the clock

Construct `VisaHttpSignatureConfig` directly, bypassing the environment resolver, with `Now` set to a
fixed function, and hand it to `new VisaHttpSignatureHook(config)` for a deterministic signature in a unit
test — there is no need to mock `Environment.GetEnvironmentVariable`. See `dotnet-testing` for injecting
the resulting client.

## Known gap: the only environment is named "Production" but defaults to the sandbox

`ServerEnvironment` has exactly one member, `Production`, and its default `BaseUrl` is CyberSource's
**sandbox** host (`https://apitest.cybersource.com/`). That is a naming trap in the generated server
config, not something to "fix". To reach real CyberSource production, override it explicitly:

```csharp
options.Server.Default.Production.BaseUrl = "https://api.cybersource.com/";
```

A signature is computed for whichever host the request goes to, so this override and the signature stay
consistent on their own — see the `host` note above.

## Example

```csharp
using CyberSourceMergedSpec;
using CyberSourceMergedSpec.Models;

// Set before constructing the client. In an application these come from configuration
// or the environment, never from source.
Environment.SetEnvironmentVariable("APIMATIC_EXPERIMENTAL_VISA_HTTP_SIGNATURE", "true");
Environment.SetEnvironmentVariable("VISA_MERCHANT_ID", "...");
Environment.SetEnvironmentVariable("VISA_KEY_ID", "...");
Environment.SetEnvironmentVariable("VISA_SECRET_KEY", "...");

using var httpClient = new HttpClient();
var client = new CyberSourceMergedSpecClient(httpClient, new CyberSourceMergedSpecClientOptions());
// Defaults to https://apitest.cybersource.com/ — see the naming trap above.

var response = await client.Invoices.CreateInvoice(new CreateInvoiceRequest
{
    CustomerInformation = new CustomerInformation { Name = "...", Email = "..." },
    InvoiceInformation = new InvoiceInformation
    {
        Description = "...",
        DueDate = new DateTimeOffset(2026, 8, 12, 0, 0, 0, TimeSpan.Zero),
    },
    OrderInformation = new OrderInformation60
    {
        AmountDetails = new AmountDetails60 { TotalAmount = "120", Currency = "USD" },
    },
});
```

No other code signs this call — the hook attaches itself purely from the environment variables being set
before the client is constructed.

## Notes

- There is no credentials property to set on `CyberSourceMergedSpecClientOptions`, and no
  `AddCyberSourceMergedSpecClient(options => ...)` line for credentials. The environment variables are the
  whole configuration surface.
- Keep the secret out of source. Load it from configuration (environment variables, a secret store, or any
  other `IConfiguration` source) and set the environment variable from there before constructing the
  client.
- A 401/403 with a signature that "looks right" is most often one of: the switch not set to exactly
  `"true"` (so nothing was signed at all), `VISA_SECRET_KEY` used raw instead of base64-decoded, a digest
  line present on a `GET`, or a digest computed over a body that changed after signing.
