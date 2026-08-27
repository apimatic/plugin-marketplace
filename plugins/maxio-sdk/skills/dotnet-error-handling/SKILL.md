---
name: dotnet-error-handling
description: Handle errors from an APIMatic-generated C#/.NET SDK — calls throw the generic SdkException<TError>, where TError is either a typed per-operation {Operation}Error or RawError directly (RawError — common for read/list/find/delete ops — has no TryGet accessors; read status/body straight off it), or use the optional non-throwing ApiResult variant to get the status code and response headers without catching. Use the moment you write a try/catch around a call, handle a non-2xx/error response, read a status code or rate-limit/Link headers, or want a no-throw result-style call on any APIMatic .NET SDK (e.g. Maxio Advanced Billing) — load it even after reading the thrown type in the source, since the type alone won't warn you about the RawError/TryGetRawError traps that make catch blocks subtly wrong.
---

<!-- core-surface: APIMatic .NET generator pre-4.0.0 — the client sends no `X-APIMatic-Gen-Version` header.
     Confirmed 2026-08-25 against asadali214/advanced-billing-sample-sdk@v1.0.2: 88 Core/*.cs.
     This surface has NO LoggingOptions, NO RequestOptions, NO RetryOptions.Disabled(). Its retry predicate
     is `.Handle<HttpRequestException>()` OR `.HandleResult(status AND method)` — so transport faults retry
     on EVERY verb and only the status arm is method-gated; MaxRetries = 0 throws in Polly (the floor is 1);
     a retry-ineligible request runs on an EMPTY pipeline and so loses the per-attempt timeout; there is no
     Retry-After handling and no delay clamp.
     verified-this-file: 2026-08-25 — namespace layout and the four Case-A usings, against Errors/*.cs and Core/ErrorResponse.
     Sampled from one pre-4.0.0 SDK only; another pre-4.0.0 SDK may differ, so re-check before relying on
     this. The paypal-sdk / twilio-sdk copies of this file describe generator 4.0.0 — correct there, wrong
     here. Do NOT copy runtime claims across a core-surface boundary. -->

# Error handling for an APIMatic .NET SDK

> Throughout this skill, `{...}` is a placeholder for a name you take from your SDK (e.g. `{Operation}`,
> `{ApiGroup}`, `{RootNamespace}`) — replace it with the concrete identifier from the source.

Endpoint methods **throw on non-success responses** by default (for a non-throwing alternative, see the
**`ApiResult`** section below). The thrown type is always the generic `SdkException<TError>` — but `TError`
comes in **two shapes**, depending on the operation:

- **Typed model (Case A)** — a per-operation `{Operation}Error` (subclass of `ApiError`) exists under
  `Errors/` for the operation; `TError` is that type and you read it with typed `TryGet*` accessors.
- **`RawError` (Case B)** — when the operation has no `{Operation}Error` type, `TError` is `RawError`
  *directly*. `RawError` is **not** an `ApiError` and has **no** `TryGet*` / `TryGetRawError` accessors; you
  read the status and body straight off `ex.Error`. This is common — many operations have no typed error
  model and so throw `SdkException<RawError>`.

`SdkException<TError>` is declared `public sealed class SdkException<TError> : Exception` with **no**
`where TError : ApiError` constraint — which is exactly why `TError` can be either an `ApiError` model or a
`RawError`.

These types live in **distinct** namespaces — `Core.*` is **not** a single namespace, so don't assume
`ApiError` sits with `SdkException` under `Core.Exceptions`:

- `SdkException<T>` → `{RootNamespace}.Core.Exceptions`
- `ApiError` **and** `RawError` → `{RootNamespace}.Core.ErrorResponse`
- the per-operation `{Operation}Error` models (e.g. `CreateWidgetError`) → `{RootNamespace}.Errors`

So a typed (Case A) catch needs up to **four** namespaces, not three — how many depends on whether you
spell the `out` types out or use `out var`:

| namespace | what you need from it |
| --- | --- |
| `{RootNamespace}.Core.Exceptions` | `SdkException<TError>` — the exception itself |
| `{RootNamespace}.Errors` | the `{Operation}Error` you name in the `catch` |
| `{RootNamespace}.Core.ErrorResponse` | `RawError`, which the inherited `TryGetRawError` hands back |
| *depends on the body* | the **typed body** a `TryGet…` yields — see below |

**The fourth is not a fixed namespace.** A typed body is whatever the API definition declared, so where
its type lives follows the body's schema kind — a model in `{RootNamespace}.Models`, a union in
`.Models.OneOf` / `.Models.AnyOf`, an enum in `.Models.Enums`, a binary body in `.Core.Models`
(`ErrorByteContent`), and a map or dynamic body in no SDK namespace at all
(`IReadOnlyDictionary<string, JsonElement>` needs `System.Collections.Generic` and `System.Text.Json`). A
scalar body — `TryGetString`, `TryGetLong` — needs nothing. Read the accessor's `out` type and import what
*it* names; do not assume `.Models`.

The last two rows only bite when you write the `out` type out. `out var` needs neither, which is why the
template below imports three namespaces and not four — it uses `out var` for the typed bodies and names
`RawError` explicitly. A Case B catch needs only
`Core.Exceptions` and `Core.ErrorResponse`. This namespace layout is identical across the APIMatic .NET SDKs
checked.

## Catch the exception

`SdkException<TError>` exposes a single property — `public required TError Error { get; init; }`, the parsed
error model. What `Error` *is* depends on the case (below).

**Read the error directly off the strongly-typed `SdkException<TError>` — never use reflection.** The
concrete `TError` is known right there at the `catch` (Case A: the typed `{Operation}Error`; Case B:
`RawError`), so `ex.Error` and the accessors on it are reachable directly. Do **not** dig the body out via
reflection (`ex.GetType().GetProperty("Error")`, then discovering and `Invoke`-ing the `TryGet*` methods):
it compiles, but it is brittle glue that reinvents what a per-operation typed `catch` gives you for free —
the concrete type is already known, so no runtime discovery is needed. Catch the concrete
`SdkException<{Operation}Error>` (or `SdkException<RawError>`) and read `ex.Error` straight off it.

### Which `TError` does an endpoint throw?

Answer this from the SDK map by lookup: each operation row names the error case (typed `{Operation}Error`
vs `RawError`) and, for Case A, lists the exact `TryGet…` accessors with the HTTP status each maps to — no
need to grep the clone or open the error class at all.

In the source itself the same fact lives in the method's XML doc `<exception>` line — on hover / in
IntelliSense, and visible when you open the file:

```csharp
/// <exception cref="SdkException{TResult}"> of <see cref="RawError"/> when the server returns an error response.</exception>
```

`SdkException{TResult}` is boilerplate (identical on every method — `{TResult}` is the doc-comment's generic
placeholder, **not** the type you catch). The type named after **`of <see cref="…"/>`** is the actual
`TError`:

- `… of <see cref="{Operation}Error"/> …` → catch `SdkException<{Operation}Error>` (Case A).
- `… of <see cref="RawError"/> …` → catch `SdkException<RawError>` (Case B).

Equivalently, read the source — open the `.cs` files rather than decompiling or reflecting over the installed
package: a `{Operation}Error` type exists under `Errors/` **only** for Case-A
operations; if there is no `{Operation}Error`, the operation throws `SdkException<RawError>`. Guessing wrong is only *sometimes* a compile-time error, and the direction that looks safe is the
dangerous one. `SdkException<ListWidgetsError>` fails to compile when no such type exists — that guess the
compiler does catch. But every `{Operation}Error` in the SDK *is* a real type, so naming the **wrong one**
— a neighbouring operation's error type — compiles cleanly and then **never matches at runtime**, because
`SdkException<A>` and `SdkException<B>` are unrelated closed generics. The exception sails past your
`catch` and surfaces somewhere else, or not at all until it is an unhandled failure. Take the case from the
contract sheet; the compiler is not a check on this.

### Case A — operation has a typed `{Operation}Error` model

Handling a Case-A error is a **two-step, source-driven** process — you cannot write the `catch` block from
memory:

1. **List *every* `TryGet...` accessor the operation's `{Operation}Error` declares.** The operation's map
   row already lists them (with the HTTP status each maps to) — take them from there; they are the
   `public bool TryGet...(out ...)` methods on the `{Operation}Error` type under `Errors/` if you open the
   source to confirm. These accessors are generated per operation — one per response the operation maps —
   and their names embed the body type. Expect a mix of:
   - **typed-body accessors** named after a model or scalar — `TryGetValidationErrors`, `TryGetProblemDetails`,
     `TryGetString`, `TryGetLong`, …;
   - **status-specific `RawError` accessors** — e.g. `TryGetNotFound(out RawError)`, `TryGetNoContent(out RawError)`;
   - the inherited **`TryGetRawError(out RawError)`**, which every `{Operation}Error` exposes.
2. **Write one `if` / `else if` branch per `TryGet*` method — cover them all, and put `TryGetRawError`
   *last*.** Each public `TryGet*` corresponds to a status/body the operation can return; skip one and you
   silently drop that response. `TryGetRawError` must be the final branch because it is **not** a catch-all
   (see below) — it only fires for statuses that have no more-specific accessor.

```csharp
using {RootNamespace}.Core.Exceptions;     // SdkException<TError>
using {RootNamespace}.Core.ErrorResponse;  // ApiError, RawError
using {RootNamespace}.Errors;              // {Operation}Error types, e.g. CreateWidgetError

try
{
    var response = await client.{ApiGroup}.{Operation}(/* ... */, ct);
    // use response
}
catch (SdkException<{Operation}Error> ex)
{
    // ONE branch per public TryGet* declared on {Operation}Error — copy the exact names from the class
    // under Errors/. The TryGet{...} names below are PLACEHOLDERS; yours are named after this operation's
    // responses (a typed body may be a model OR a scalar such as TryGetString/TryGetLong).
    if (ex.Error.TryGet{TypedBody1}(out var body1))            // e.g. TryGetValidationErrors — a typed body
    {
        // inspect body1
    }
    else if (ex.Error.TryGet{TypedBody2}(out var body2))       // e.g. TryGetProblemDetails — another typed body
    {
        // inspect body2
    }
    else if (ex.Error.TryGet{Status}(out RawError statusRaw))  // e.g. TryGetNoContent(out RawError) — status-specific
    {
        Console.Error.WriteLine($"HTTP {(int)statusRaw.StatusCode}");
    }
    // ... KEEP GOING: one else-if for EVERY remaining TryGet* the class declares — do not stop early ...
    else if (ex.Error.TryGetRawError(out RawError raw))        // ALWAYS LAST: fallback for untyped statuses only
    {
        Console.Error.WriteLine($"HTTP {(int)raw.StatusCode}: {raw.ReadAsString()}");
    }
}
```

**Why `TryGetRawError` goes last — it is not a universal fallback.** It returns a raw body **only** for
statuses that have no more-specific accessor on this `{Operation}Error`; a status that has a typed accessor
(e.g. a `422` validation payload) lands in that typed slot and leaves `TryGetRawError` **false**. The
status-specific `RawError` accessors (e.g. `TryGetNoContent(out RawError)`) are likewise **not** surfaced by
`TryGetRawError`. So if you check `TryGetRawError` first — or omit any of the more-specific accessors — those
typed and status-specific bodies are silently dropped. Enumerate the class and handle every accessor
explicitly.

**Don't factor error-reading into a shared helper typed as `ApiError`.** The typed `TryGet*` accessors live
on the concrete `{Operation}Error`, *not* on the `ApiError` base — which exposes only `TryGetRawError`. A
helper like `string Describe(ApiError e)` can therefore reach **only** `TryGetRawError`, so for any status
that has a typed body it finds nothing and falls back to `e.ToString()` — a bare type name
(`{RootNamespace}.Errors.{Operation}Error`), not the actual message. Read the typed accessors **inside the
per-operation `catch` block**, where the concrete `{Operation}Error` type is known; reserve shared code for
the `RawError`/transport fallback only.

### Case B — operation throws `SdkException<RawError>`

For operations with no `{Operation}Error` type (none under `Errors/`), `ex.Error` **is** a `RawError` —
there are no `TryGet*` accessors and no `TryGetRawError`; read the status and body straight off it:

```csharp
using {RootNamespace}.Core.Exceptions;     // SdkException<TError>
using {RootNamespace}.Core.ErrorResponse;  // RawError

try
{
    var response = await client.{ApiGroup}.{Operation}(/* ... */, ct);
    // use response
}
catch (SdkException<RawError> ex)
{
    RawError raw = ex.Error;                          // the error model IS RawError here
    Console.Error.WriteLine($"HTTP {(int)raw.StatusCode}");
    Console.Error.WriteLine(raw.ReadAsString());      // or raw.ReadAsJson<MyDto>()
}
```

Case B needs no `.Errors` using — `RawError` lives under `{RootNamespace}.Core.ErrorResponse`. Its public
members (`StatusCode`, `ReadAsBytes`/`ReadAsString`/`ReadAsJson<T>`) are visible in the SDK source; note
`ReadAsJson<T>()` **throws `JsonException`** when the body isn't valid JSON — and a `RawError` body often
isn't (this is the no-typed-error-model case), so prefer `ReadAsString()` unless you know it's JSON.

## Result-style alternative — `ApiResult<TResponse, TError>` (no throwing)

The generator can **optionally** emit a result-style variant of an operation — so it's not guaranteed to
exist. When enabled, it appears as a **sibling method** named `{Operation}Result` (next to the throwing
`{Operation}`), returning `Task<ApiResult<TResponse, {TError}>>` and **does not throw** on a non-success
status — the error is carried in the returned value instead. (`{TError}` is the same two-case shape as
above: a typed `{Operation}Error`, or `RawError`.) `ApiResult<TResponse, TError>` is a public
`readonly struct` under `{RootNamespace}.Core.Models`. If the controller has no `{Operation}Result`
overload, this variant wasn't generated — use the throwing method with `try/catch` instead.

Unlike the throwing path, `ApiResult` exposes the HTTP **`StatusCode`** and **`Headers`** on *both* success
and failure — so this is the variant to use when you need the status code, rate-limit headers, or pagination
`Link` headers.

```csharp
using {RootNamespace}.Core.Models;        // ApiResult<TResponse, TError>
using {RootNamespace}.Core.ErrorResponse; // RawError
using {RootNamespace}.Errors;             // {Operation}Error (Case A only)

// No try/catch — the *Result variant returns the outcome instead of throwing.
ApiResult<{ReturnType}, {Operation}Error> result =
    await client.{ApiGroup}.{Operation}Result(/* ... */, ct);

if (result.TryGetResponse(out var response))        // success
{
    Console.WriteLine($"OK {(int)result.StatusCode}");   // status + result.Headers available here
    // use response
}
else if (result.TryGetError(out var error))         // failure
{
    // 'error' is the same TError as the throwing path:
    //   Case A → typed {Operation}Error (use its TryGet* accessors, then TryGetRawError)
    //   Case B → RawError (read error.StatusCode / error.ReadAsString())
    Console.Error.WriteLine($"HTTP {(int)result.StatusCode}");
}
```

Other ways to consume it:

```csharp
// Pattern-match to a value (Action overload also exists):
var summary = result.Match(onSuccess: r => "ok", onFailure: e => "failed");

// Tuple deconstruction:
var (isSuccess, response, error) = result;

// Bridge back to the throwing behavior (returns the response or throws SdkException<{TError}>):
{ReturnType} value = result.GetResponseOrThrow();
```

## Connection failures, and guarding every call

The exception types above cover API errors (the server replied with a non-2xx status). They do
**not** cover connection failures — host unreachable, DNS failure, dropped connection, or timeout.
Those come through as `HttpRequestException` / `TaskCanceledException`, which a
`catch (SdkException<...>)` will not match. If that catch is your only guard, a connection failure
escapes and takes down whatever was running the call.

**Convert connection failures to your own error type in one place.** If you wrap the SDK behind
your own abstraction (a client interface, a service, a repository), catch connection failures at
that boundary and rethrow the same error type you already use for API errors — so the rest of the
code has a single failure type to handle instead of two unrelated ones:

```csharp
catch (SdkException<RawError> ex)                // API error (non-2xx)
{
    throw new {ProviderException}("...", ex);
}
catch (Exception ex) when (ex is HttpRequestException or TaskCanceledException)  // connection failure
{
    throw new {ProviderException}("provider unreachable", ex);
}
```

**Guard every call site, not just the ones that change data.** It is easy to wrap the calls that
create or modify something and overlook the calls that only read — especially reads that run
automatically on a routine path (loading a screen, a scheduled job, a startup or health check). A
connection failure during a read fails just as hard as one during a write. Wherever the SDK (or
your wrapper) is called, the caller must catch the failure and degrade in a way that fits — a
fallback, a retry, a clear message — rather than letting it escape. A call left unguarded next to
one that is guarded is the one that breaks.

## Notes

- On an SDK with **multiple/composite auth schemes**, a call can also throw `AuthSchemeException`
  (under `{RootNamespace}.Core.Exceptions`) — an auth *application* failure, not an API error — when the
  configured schemes can't be satisfied; it carries `IReadOnlyList<Exception> SchemeFailures` and is **not**
  an `SdkException<T>`, so a `catch (SdkException<...>)` won't match it — catch it separately. (A
  single-scheme SDK like Maxio's Basic-only client won't hit this.)
- Retries for transient statuses happen automatically before an exception is thrown — but only for
  idempotent methods (`GET/HEAD/PUT/OPTIONS`) by default, so `POST`/`PATCH`/`DELETE` errors surface without
  retry. See **dotnet-configuration-resilience**.
