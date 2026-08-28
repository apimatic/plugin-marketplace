---
name: dotnet-error-handling
description: Error and exception handling for an APIMatic-generated .NET SDK in C# — load before writing any try/catch around an SDK call, an exception-translation layer, or error middleware. Covers which exception types actually reach your catch blocks, how to read status codes and error bodies safely, and the traps that make an otherwise reasonable catch ladder silently wrong.
---

<!-- core-surface: APIMatic .NET generator 4.0.0 — the client sends `X-APIMatic-Gen-Version: 4.0.0`.
     Confirmed 2026-08-25 against asadali214/checkout-sample-sdk@v1.0.1 (9653d18) and
     context-plugins/twilio-csharp-sdk@main: 122 Core/*.cs, byte-identical modulo the root namespace.
     This surface HAS: LoggingOptions on the options class; RequestOptions on every operation;
     RetryOptions.Disabled(); TimeoutRejectedException inside the retry set; the method filter ANDed above
     BOTH retry arms; Retry-After honoured with a hard 60s delay clamp; a timeout-only (not empty) pipeline
     for retry-ineligible requests.
     verified-this-file: 2026-08-25 — namespace layout and the four Case-A usings, against Errors/*.cs and Core/ErrorResponse. Per-operation accessor claims are NOT covered by this stamp (they are spec-derived, not Core).
     CAUTION - the version string does NOT pin this surface. The generator's own StaticCode/Core template
     (codegen-v2) still stamps 4.0.0 but has moved ahead of the SDKs above: 20 of 121 shared Core files
     differ, it adds Hooks/SdkHook.cs, Models/AdditionalProperties.cs and Extensions/HttpContentExtensions.cs,
     and RequestOptions gains a `Hooks` property (so "its single property is LogLevel?" is already stale
     against the template). Re-verify against the EMITTED Core of the SDK in hand, not against
     X-APIMatic-Gen-Version. Do NOT copy runtime claims across a core-surface boundary - check this stamp in
     both files first. -->

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

Answer this from the contract sheet (grounded from the SDK map/source): the
operation's row names the error case (typed `{Operation}Error` vs `RawError`) and, for Case A, lists the
exact `TryGet…` accessors with the HTTP status each maps to — no need to grep a clone or open the error
class at all.

In the source itself the same fact lives in the method's XML doc `<exception>` line — on hover / in
IntelliSense, and visible when you open the file. Where a doc block is present it always carries exactly one
such line, but **not every generated operation has a doc block at all**, so its absence tells you nothing
about the error case; fall back to the contract sheet:

```csharp
/// <exception cref="SdkException{TResult}"> of <see cref="RawError"/> when the server returns an error response.</exception>
```

`SdkException{TResult}` is boilerplate (identical on every method — `{TResult}` is the doc-comment's generic
placeholder, **not** the type you catch). The type named after **`of <see cref="…"/>`** is the actual
`TError`:

- `… of <see cref="{Operation}Error"/> …` → catch `SdkException<{Operation}Error>` (Case A).
- `… of <see cref="RawError"/> …` → catch `SdkException<RawError>` (Case B).

Equivalently, when grounding from the SDK source (the clone the getting-started skill describes): a
`{Operation}Error` type exists under `Errors/` **only** for Case-A operations; if there is no
`{Operation}Error`, the operation throws `SdkException<RawError>`. Guessing wrong is only *sometimes* a compile-time error, and the direction that looks safe is the
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
   row already lists them (with the HTTP status each maps to); main takes them from the contract sheet.
   They are the `public bool TryGet...(out ...)` methods on the `{Operation}Error` type (the SDK helper
   agent confirms them from the SDK map/source). These accessors are generated per operation — one per response the operation maps —
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
    var response = await client.{ApiGroup}.{Operation}(/* ... */, ct: ct);
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
    var response = await client.{ApiGroup}.{Operation}(/* ... */, ct: ct);
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
members are `StatusCode`, `ReadAsBytes`/`ReadAsString`/`ReadAsJson<T>`; note
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
    await client.{ApiGroup}.{Operation}Result(/* ... */, ct: ct);

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
catch (SdkException<{Operation}Error> ex)        // API error (non-2xx), Case A — 39 of 40 operations
{
    // Carry Name and DebugId. The boundary ladder below is the only place they can be read back,
    // and a Name dropped here cannot be recovered downstream — the typed body is the only thing
    // that carries it, and it does not outlive this catch.
    //
    // Check the accessors in the SAME order as the Case A ladder above: every typed accessor
    // this operation declares, then TryGetRawError LAST. Two accessors are shown; enumerate the
    // class for the real set.
    if (ex.Error.TryGetError(out Error e))
        throw new {ProviderException}(e.Message, e.Name, e.DebugId, ex);

    // Any arm whose out-type is RawError — the `_` fallback here, and on the seven Payments-side
    // operations also their documented-500 `TryGetNoContent`. Those are the branches with a status.
    if (ex.Error.TryGetRawError(out RawError raw))
        throw new {ProviderException}($"HTTP {(int)raw.StatusCode}", name: null, debugId: null, ex);

    throw new {ProviderException}("unrecognised error shape", name: null, debugId: null, ex);
}
catch (Exception ex) when (ex is HttpRequestException or TaskCanceledException)  // connection failure
{
    throw new {ProviderException}("provider unreachable", name: null, debugId: null, ex);
}
```

(`SearchTransactions` is Case B — catch `SdkException<RawError>` there and read
`ex.Error.StatusCode` directly; it has no `Name`.)

**Guard every call site, not just the ones that change data.** It is easy to wrap the calls that
create or modify something and overlook the calls that only read — especially reads that run
automatically on a routine path (loading a screen, a scheduled job, a startup or health check). A
connection failure during a read fails just as hard as one during a write. Wherever the SDK (or
your wrapper) is called, the caller must catch the failure and degrade in a way that fits — a
fallback, a retry, a clear message — rather than letting it escape. A call left unguarded next to
one that is guarded is the one that breaks.

## Presenting failures at your boundary — coherent, distinct, leak-free

The catches above decide what you catch; this decides what the caller (an HTTP response, a UI
layer, another service) sees. Get this wrong and every failure looks the same, or an internal
type name ends up on the wire. Three rules, applied at the one boundary where you convert SDK
failures into your own error type:

**Handle each failure kind the same way everywhere.** Pick one mapping from failure kind →
outcome and apply the identical catch ladder at every call site — same order, same conversion.
When the same kind of failure (a validation rejection, say) becomes a different result on a
different operation, callers can't reason about it. One shared ladder, not per-call improvisation.

**Keep distinct failures distinct — and on this SDK the discriminator is `Name`, not the status.** Your
error type needs to carry something that separates "you sent something invalid" from "the provider is
down". The reflex is to carry the HTTP status. On this SDK you mostly cannot:

- **39 of 40 operations throw a typed `{Operation}Error`,** whose model-returning accessors hand you an
  `Error`, `Error1`, `SubscriptionError` or `DefaultError` — none of which carries an HTTP status.
  `SdkException<TError>` has exactly one member, `Error`, with no `StatusCode` on it.
- **The accessor is named after the payload, not the word "error", and the name differs per operation.**
  Across the 39 classes there are four model accessors in use: `TryGetSubscriptionError` (17 classes),
  `TryGetError` (15), `TryGetError1` (6) and `TryGetDefaultError` (1). `PatchSubscriptionError` maps
  `400/401/403/404/422/500` to one **`TryGetSubscriptionError(out SubscriptionError)`** — writing
  `TryGetError` there is a `CS1061`, not a runtime surprise. Take the name from the operation's own map
  row every time.
- **The typed arm swallows the distinction you wanted.** Each error class routes every *documented*
  status into a single accessor, and **29 of the 39** put 4xx and 5xx through the same one — so
  "caller's fault or provider's" is not answerable from the status even in principle.
- **Seven operations are the exception, and they are the ones that move money.**
  `CaptureAuthorizedPaymentError`, `GetAuthorizedPaymentError`, `GetCapturedPaymentError`,
  `GetRefundError`, `ReauthorizePaymentError`, `RefundCapturedPaymentError` and `VoidPaymentError` each
  declare a **second, status-specific accessor** — `TryGetNoContent(out RawError)` for their documented
  `500` — and `RawError` *does* carry `StatusCode`. So on those seven a documented 500 is distinguishable
  from the 4xx bundle; on the other 32 it is not.
- **`TryGetRawError` is not a general fallback.** It returns `true` only on the `_` arm — statuses the
  spec did *not* document. When a documented status arrives, the arm that fires is the typed one or a
  status-specific one like `TryGetNoContent`, and `TryGetRawError` is `false`.
- **`SearchTransactions` is the one operation with no typed error at all:** it throws
  `SdkException<RawError>`, so `ex.Error.StatusCode` works directly.

**Use what the body gives you — it is better than the status anyway.** Every typed body carries a
`required string Name`, the provider's own error identity, and `Details[].Issue`, a `required string` the
parameter docs call *"the unique, fine-grained application-level error code"*. `INVALID_REQUEST` with
`Issue = "MALFORMED_REQUEST_JSON"` says more than `422` does, and `INTERNAL_SERVER_ERROR` separates a
provider outage from a bad request without a status at all. `DebugId` is `required` too — carry it, it is
what PayPal support asks for first.

```csharp
static (int Status, string Message) Map(Exception ex) => ex switch
{
    // OUR credentials or OUR quota — the caller did nothing wrong and cannot fix it.
    {ProviderException} p when p.Name is "AUTHENTICATION_FAILURE" or "NOT_AUTHORIZED"
                                                              => (502, "Provider unavailable."),
    {ProviderException} p when p.Name is "RATE_LIMIT_REACHED"   => (503, "Temporarily unavailable."),
    {ProviderException} p when p.Name is "INTERNAL_SERVER_ERROR" => (502, "Provider unavailable."),

    // The provider rejected THE CALLER'S request — they can act on it.
    {ProviderException} p when p.Name is "INVALID_REQUEST" or "UNPROCESSABLE_ENTITY"
                                                              => (400, p.Message),
    {ProviderException} p when p.Name is "RESOURCE_NOT_FOUND"   => (404, p.Message),

    // Transport, timeout, or a Name you have not mapped yet — no meaningful caller status.
    {ProviderException} p                                       => (502, p.Message),
    _                                                           => (500, "Unexpected error."),
};
```

**Not every provider failure is the caller's fault.** An authentication or authorization failure means
*your* credentials are wrong, and a rate-limit failure means *your* quota is spent — surfacing either
straight through tells your caller they are unauthenticated or throttled when they are neither. Those
belong in the 5xx bucket, which is why they sit above the 4xx arms in the ladder. Validation, conflict
and not-found are the caller's to fix.

Keep the ladder's default arm mapping to 5xx: a `Name` you have not seen is an unknown, not a caller
error, and PayPal can add one without warning you.

**If you genuinely need the transport status** — for metrics, or a provider-availability SLA — a
`DelegatingHandler` is the only route that works on all 40 operations, because it sees the response
before the SDK maps it. Two caveats before you reach for it: under retry it observes *N* responses for
one logical call, so "the status" means the last attempt's; and it needs an `AsyncLocal` or a scoped
service to reach the catch site, which is ambient state. Do not use it to drive ordinary error mapping —
`Name` is the better key and needs none of that machinery.

**An unreadable body is not one case but two — decide which before you map it.** An unreadable
**success** body is genuinely unknown: 5xx. An unreadable **error** body is not — the provider
rejected the request and only the *detail* was lost, so answering 5xx tells a retrying caller to
keep retrying something that can never succeed. The trap below shows how the second case arises and
what it costs you.

**A success status with a broken body is a third failure kind — catch it and sanitize.** The
server can return a 2xx whose body no longer matches the model, so the SDK throws
`System.Text.Json.JsonException` while deserializing it. This matches **neither** a
`catch (SdkException<...>)` (no error status was returned) **nor** a transport catch — so it
escapes unhandled, and if it reaches a generic handler that writes `exception.Message` the
response leaks `System.Text.Json.*` type and JSON-path detail. Catch it at the same boundary and
convert it to your own error type with a caller-safe message:

    catch (System.Text.Json.JsonException ex)
    {
        throw new {ProviderException}("The provider returned a response that could not be processed.", ex);
    }

**The same exception also arrives from the *error* path, and means the opposite.** `{Operation}Error`
models are generated per operation and can disagree with the body the API really sends on that
status. When they do, the deserialization runs *while the error object is being constructed*, so the
`JsonException` **replaces** the `SdkException` — your typed `catch` never fires, and the HTTP status
is gone with it. Identical exception type, opposite meaning: the 2xx case is "outcome unknown", this
case is "you were rejected and I lost the reason". A single `catch (JsonException)` that maps both to
a 5xx is wrong half the time — see *Keep distinct failures distinct* above. Either treat that
operation's parse failure as the rejection it is, or capture the status before the SDK discards it (a
`DelegatingHandler` sees it, at the cost of carrying HTTP state to your boundary out of band — and
across a retry pipeline, of being ambiguous about *which* attempt you recorded).

**Never map a parse failure onto a domain *absence*.** "I could not read the answer" is not "the
provider said no." It is tempting on a lookup — an unreadable body and a genuine miss both leave you
without a record — but they are different facts and only one of them is a *fact*. Where a lookup
gates a create, that conversion turns a corrupt response into a spurious create; more generally it
produces a confident wrong answer, which is worse than an error. If the operation's miss really is
signalled by an empty body, match on *empty*, not on *unparseable*.

The rule generalizes: whatever converts SDK failures into your own type must carry only a
caller-safe message — never surface `ex.ToString()` or `exception.Message` from an SDK or
framework exception on the wire (the same leak the `ApiError.ToString()` bare-type-name trap
above produces).

## Notes

- On an SDK with **multiple/composite auth schemes**, a call can also throw `AuthSchemeException`
  (under `{RootNamespace}.Core.Exceptions`) — an auth *application* failure, not an API error — when the
  configured schemes can't be satisfied; it carries `IReadOnlyList<Exception> SchemeFailures` and is **not**
  an `SdkException<T>`, so a `catch (SdkException<...>)` won't match it — catch it separately. (An SDK
  whose API declares a single scheme never hits this.)
- Retries happen automatically before an exception is thrown, and `HttpMethodsToRetry`
  (`GET/HEAD/PUT/OPTIONS` by default) gates **every** trigger — status, transport fault, and the SDK's own
  per-attempt timeout alike. So an error on a `POST`/`PATCH`/`DELETE` surfaces on the first attempt, with no
  resend. That is not the same as "the write did not happen": a transport failure may have been thrown after
  the bytes reached the provider, so the outcome is *unknown* and the caller needs to be told that rather
  than "it failed". See **dotnet-configuration-resilience**.
