---
name: dotnet-error-handling
description: Handle errors from an APIMatic-generated C#/.NET SDK — calls throw the generic SdkException<TError>, where TError is either a typed per-operation {Operation}Error or RawError directly (RawError — common for read/list/find/delete ops — has no TryGet accessors; read status/body straight off it), or use the optional non-throwing ApiResult variant to get the status code and response headers without catching. Use the moment you write a try/catch around a call, handle a non-2xx/error response, read a status code or rate-limit/Link headers, or want a no-throw result-style call on any APIMatic .NET SDK (e.g. Maxio Advanced Billing) — load it even after reading the thrown type in the source, since the type alone won't warn you about the RawError/TryGetRawError traps that make catch blocks subtly wrong.
---

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

`SdkException<T>`, `ApiError`, and `RawError` live under `{RootNamespace}.Core.*`; the per-operation
`{Operation}Error` model types (e.g. `CreateWidgetError`) live under `{RootNamespace}.Errors` — so
catching a typed (Case A) exception needs **both** a `Core.*` and an `.Errors` using. (Case B needs only the
`Core.*` usings.) These types are identical in shape across APIMatic .NET SDKs.

## Which `TError` does an endpoint throw?

Check the method's XML `<exception>` doc — it shows in IntelliSense / on hover:

- `… <exception cref="SdkException{TResult}"> of <see cref="{Operation}Error"/> …` → catch
  `SdkException<{Operation}Error>` (Case A).
- `… <exception cref="SdkException{TResult}"> of <see cref="RawError"/> …` → catch
  `SdkException<RawError>` (Case B).

Equivalently, read the source — open the `.cs` files rather than decompiling or reflecting over the installed
package: a `{Operation}Error` type exists under `Errors/` **only** for Case-A
operations; if there is no `{Operation}Error`, the operation throws `SdkException<RawError>`. Guessing wrong
is a **compile-time** error (`SdkException<ListWidgetsError>` won't compile — no such type), not a silent
bug — so the compiler keeps you honest.

## Catch the exception

`SdkException<TError>` exposes a single property — `public required TError Error { get; init; }`, the parsed
error model. What `Error` *is* depends on the case (above).

### Case A — operation has a typed `{Operation}Error` model

```csharp
using {RootNamespace}.Core.Exceptions;     // SdkException<TError>
using {RootNamespace}.Core.ErrorResponse;  // RawError
using {RootNamespace}.Errors;              // {Operation}Error types, e.g. CreateWidgetError

try
{
    var response = await client.{ApiGroup}.{Operation}(/* ... */, ct);
    // use response
}
catch (SdkException<{Operation}Error> ex)
{
    // ex.Error is the typed ApiError. Try the typed body first: the accessor's name embeds the body
    // type (TryGetValidationErrors, TryGetProblemDetails, …; a typed body may be a model OR a scalar
    // such as TryGetString/TryGetLong) — open the {Operation}Error under Errors/ for the exact name(s).
    if (ex.Error.TryGetSomeTypedBody(out var typed))
    {
        // inspect 'typed' (e.g. validation messages)
    }
    // Fall back to the raw response — but see the note below: TryGetRawError is NOT a catch-all.
    else if (ex.Error.TryGetRawError(out RawError raw))
    {
        Console.Error.WriteLine($"HTTP {(int)raw.StatusCode}: {raw.ReadAsString()}");
    }
}
```

**`TryGetRawError` is not a universal fallback.** It returns a raw body **only** for statuses that have no
typed accessor on this `{Operation}Error`; a status that has a typed accessor (e.g. a `422` validation
payload) lands in the typed slot and leaves `TryGetRawError` **false**. Some `{Operation}Error`s also
expose status-specific `RawError` accessors (e.g. `TryGetNoContent(out RawError)`) that `TryGetRawError`
won't surface either. So **always try
the operation's typed accessors before `TryGetRawError`**, or a typed `422` body is silently dropped — open
the `{Operation}Error` under `Errors/` for its exact accessor names.

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

## Notes

- Network/transport failures surface as the usual `HttpRequestException` / `TaskCanceledException`
  (e.g. timeout or cancellation) — handle those separately from `SdkException<TError>`.
- On an SDK with **multiple/composite auth schemes**, a call can also throw `AuthSchemeException`
  (under `{RootNamespace}.Core.Exceptions`) — an auth *application* failure, not an API error — when the
  configured schemes can't be satisfied; it carries `IReadOnlyList<Exception> SchemeFailures` and is **not**
  an `SdkException<T>`, so a `catch (SdkException<...>)` won't match it — catch it separately. (A
  single-scheme SDK like Maxio's Basic-only client won't hit this.)
- Retries for transient statuses happen automatically before an exception is thrown — but only for
  idempotent methods (`GET/HEAD/PUT/OPTIONS`) by default, so `POST`/`PATCH`/`DELETE` errors surface without
  retry. See **dotnet-configuration-resilience**.
