---
name: advanced-billing-sdk-usage
description: >-
  Call endpoints and handle results with an APIMatic-generated C# (.NET) v4 SDK —
  controller groups on the client, async method signatures, request/response
  models, optional & nullable parameters, cancellation tokens, typed error
  handling via SdkException<TError> (TryGet... pattern) with the RawError
  fallback, and manual page/per_page pagination. Use when writing code that
  invokes operations on any such SDK. Assumes the client is already initialized.
---

# Using an APIMatic-generated C# v4 SDK

This covers making calls once you have a configured `<Sdk>Client` (see the
**advanced-billing-sdk-initialization** skill to create one). The Maxio SDK
(`MaxioAdvancedBillingClient`) is used as the concrete example; the patterns are
identical across every v4 SDK.

## 1. Operations are grouped into controllers on the client

The client exposes one property per API controller (resource group). Each property is
a controller object whose methods are the operations.

```csharp
client.Customers.CreateCustomer(...)
client.Subscriptions.ReadSubscription(...)
client.Invoices.ListInvoices(...)
```

To discover what's available: the client class (`<Sdk>Client.cs`) lists every
controller property; each controller file under `Api/` lists its methods; or read
`api-reference.md` at the SDK root, which documents every operation with a ready-to-paste
usage snippet, parameter table, and the success/error response types.

## 2. Method signatures and calling convention

Every operation is `async` and follows the same shape:

```
Task<TResponse> OperationName(<required params>, <optional params = default>, CancellationToken ct = default)
```

- Returns `Task<TResponse>` for operations with a body, or a bare `Task` for
  no-content operations (e.g. deletes). Always `await`.
- **Required** parameters (path params, required bodies) come first and have no default.
- **Optional** parameters (most query params, optional bodies) are nullable with
  defaults and can be omitted or passed by name.
- The final `CancellationToken ct = default` is always present — pass one to support
  cancellation/timeouts.

```csharp
// minimal — only required args
var customer = await client.Customers.ReadCustomer(123);

// with optional query params, passed by name, plus a cancellation token
var customers = await client.Customers.ListCustomers(
    direction: SortingDirection.Desc,
    dateField: null,
    startDate: "2026-01-01",
    endDate: null,
    startDatetime: null,
    endDatetime: null,
    q: "acme@example.com",
    page: 1,
    perPage: 50,
    ct: cancellationToken);
```

> Some optional parameters have **no default** in the signature (they're nullable but
> required positionally). When in doubt, pass `null` explicitly for the ones you don't
> need, or use named arguments — the `api-reference.md` snippet for each operation shows
> the minimal correct call.

## 3. Request and response models

- **Request bodies** are typed model classes (e.g. `CreateCustomerRequest`) built with
  object initializers. A nullable body parameter (`CreateCustomerRequest? body`) may
  accept `null` when the API allows an empty body.
- **Responses** are typed models (`CustomerResponse`), collections
  (`IReadOnlyList<SubscriptionResponse>`), or nothing (bare `Task`).
- Optional/nullable model fields use C# nullable types; check for `null` before use.

```csharp
var response = await client.Customers.CreateCustomer(new CreateCustomerRequest
{
    Customer = new CreateCustomer
    {
        FirstName = "Ada",
        LastName  = "Lovelace",
        Email     = "ada@example.com",
    },
});
// response is CustomerResponse
```

Enum-valued parameters/fields use generated enum types (often `StringEnum` records);
use the provided static members (e.g. `SortingDirection.Desc`).

## 4. Error handling — the core pattern

A non-success HTTP response throws **`SdkException<TError>`** (from
`Core/Exceptions`). The generic argument is the operation-specific error type. Each
operation's `api-reference.md` entry names its exact `TError`.

There are two flavors of `TError`:

### a) Operations with a typed (structured) error

The error type derives from `ApiError` and exposes `TryGet...` accessors for each
documented error shape, plus a `TryGetRawError` fallback for undocumented statuses.

```csharp
try
{
    var customer = await client.Customers.CreateCustomer(body, ct);
    // use customer
}
catch (SdkException<CreateCustomerError> ex)
{
    // try each documented error shape (one TryGet per HTTP status the API documents)
    if (ex.Error.TryGetCustomerErrorResponse1(out var validation))
    {
        // handle the typed 422 validation error
    }
    else if (ex.Error.TryGetRawError(out var raw))
    {
        // undocumented status — inspect raw.StatusCode / raw.ReadAsString()
    }
}
```

The exact `TryGetXxx` method names come from the error class under `Errors/<Operation>Error.cs`.
The generated **usage snippet** in `api-reference.md` shows the canonical handler.

### b) Operations whose error is only `RawError`

When an operation has no documented error schema, `TError` is `RawError` directly:

```csharp
try
{
    await client.Customers.DeleteCustomer(123, ct);
}
catch (SdkException<RawError> ex)
{
    var status = ex.Error.StatusCode;        // HttpStatusCode
    var bodyText = ex.Error.ReadAsString();  // raw response body
    var typed = ex.Error.ReadAsJson<MyShape>(); // or deserialize yourself
}
```

`RawError` gives you `StatusCode`, `ReadAsBytes()`, `ReadAsString()`, and
`ReadAsJson<T>()`.

### Other exceptions worth catching

- `AuthSchemeException` — thrown when all alternative auth schemes fail to apply
  (exposes `SchemeFailures`); usually a configuration problem.
- `OperationCanceledException` / `TaskCanceledException` — from a cancelled
  `CancellationToken` or the per-request `Retry.Timeout`.
- For streaming (SSE) endpoints, the SDK may throw `SseException`,
  `SseTimeoutException`, or `SseDeserializationException`.

> Retries for transient failures (`408/429/5xx` on idempotent methods) happen
> automatically per `RetryOptions`. By the time an `SdkException` surfaces, retries are
> already exhausted — don't add your own retry loop around the call.

## 5. Pagination

These SDKs paginate **manually** via parameters — there is no auto-paging iterator.
List operations expose `page` and `perPage` parameters (names may vary, e.g.
`cursor`/`limit`); the response is the page's items as an `IReadOnlyList<T>`. Loop until
a short/empty page comes back:

```csharp
var all = new List<CustomerResponse>();
double page = 1, perPage = 200;
while (true)
{
    var batch = await client.Customers.ListCustomers(
        direction: null, dateField: null, startDate: null, endDate: null,
        startDatetime: null, endDatetime: null, q: null,
        page: page, perPage: perPage, ct: ct);

    if (batch.Count == 0) break;
    all.AddRange(batch);
    if (batch.Count < perPage) break; // last (partial) page
    page++;
}
```

Respect each API's documented max `perPage` (Maxio's customers list caps at 200).

## 6. Cancellation and timeouts

Pass a `CancellationToken` to every call you want to be cancellable. The token is
honored across retries, and a request also stops at `RetryOptions.Timeout`.

```csharp
using var cts = new CancellationTokenSource(TimeSpan.FromSeconds(10));
var result = await client.Subscriptions.ReadSubscription(id, cts.Token);
```

## 7. Quick workflow for an unfamiliar operation

1. Open `api-reference.md`, find the controller and operation.
2. Copy its **Usage** snippet — it has the correct minimal call and the matching
   `catch (SdkException<...>)` handler.
3. Fill required parameters; add optional ones by name as needed.
4. Replace the `// TODO` comments with handling of the success response type and each
   documented error shape (`TryGet...`), keeping `TryGetRawError` as the fallback.
5. Pass a `CancellationToken` from the caller.

## Common pitfalls

- **Forgetting `await`** — every method returns a `Task`; nothing executes until awaited.
- **Wrong `TError`** — the generic must match the operation; copy it from `api-reference.md`.
- **Skipping the `RawError` fallback** — always handle it, or undocumented statuses
  surface as an unhandled exception.
- **Re-creating the client per call** — reuse one instance (see the initialization skill).
- **Hand-rolling retries** — already built in; layering more causes duplicate requests.
