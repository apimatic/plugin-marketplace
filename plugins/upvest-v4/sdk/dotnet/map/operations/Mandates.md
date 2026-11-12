<!-- Generated file — do not edit; regenerated with the SDK. -->

# Mandates — operations

Accessor: `client.Mandates` · Source: `src/UpvestInvestmentApi/Api/Mandates.cs` · 5 operations

**Type sources**: the file declaring each type an operation names (`RawError` excluded — see sdk-map.md).

### CreateMandate

- **Auth**: `options.OauthClientCredentials` (scopes: `mandates:admin`)
- **Signature**: `CreateMandate(CreateMandateRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `IdempotencyKey`
- **Returns**: `DirectDebitMandate`
- **Error**: `ApiException<CreateMandateError>` — **Case A (typed)**
- **Error accessors**: `TryGetNoContent([NotNullWhen(true)] out RawError? value)` [400, 401, 403, 404, 406, 429, 500, 503, 504] · `TryGetRawError([NotNullWhen(true)] out RawError? error)` [fallback]

| Type | Source |
| --- | --- |
| `CreateMandateRequest` | `src/UpvestInvestmentApi/Requests/Mandates/CreateMandateRequest.cs` |
| `UpvestApiVersion` | `src/UpvestInvestmentApi/Models/Enums/UpvestApiVersion.cs` |
| `MandateCreateRequest` | `src/UpvestInvestmentApi/Models/MandateCreateRequest.cs` |
| `DirectDebitMandate` | `src/UpvestInvestmentApi/Models/DirectDebitMandate.cs` |
| `CreateMandateError` | `src/UpvestInvestmentApi/Errors/CreateMandateError.cs` |

### DeleteMandate

- **Auth**: `options.OauthClientCredentials` (scopes: `mandates:admin`)
- **Signature**: `DeleteMandate(DeleteMandateRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `MandateId`
- **Returns**: `void` (Task)
- **Error**: `ApiException<DeleteMandateError>` — **Case A (typed)**
- **Error accessors**: `TryGetNoContent([NotNullWhen(true)] out RawError? value)` [401, 403, 404, 429, 500, 503, 504] · `TryGetRawError([NotNullWhen(true)] out RawError? error)` [fallback]

| Type | Source |
| --- | --- |
| `DeleteMandateRequest` | `src/UpvestInvestmentApi/Requests/Mandates/DeleteMandateRequest.cs` |
| `UpvestApiVersion` | `src/UpvestInvestmentApi/Models/Enums/UpvestApiVersion.cs` |
| `DeleteMandateError` | `src/UpvestInvestmentApi/Errors/DeleteMandateError.cs` |

### ListBusinessMandates

- **Auth**: `options.OauthClientCredentials` (scopes: `mandates:admin`, `mandates:read`)
- **Signature**: `ListBusinessMandates(ListBusinessMandatesRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `BusinessId`
- **Query params (wire ← C#)**: `sort` ← `Sort`, `order` ← `Order`, `limit` ← `Limit`, `offset` ← `Offset`
- **Returns**: `MandatesListBusinessResponse`
- **Error**: `ApiException<ListBusinessMandatesError>` — **Case A (typed)**
- **Error accessors**: `TryGetNoContent([NotNullWhen(true)] out RawError? value)` [400, 401, 403, 404, 406, 429, 500, 503, 504] · `TryGetRawError([NotNullWhen(true)] out RawError? error)` [fallback]

| Type | Source |
| --- | --- |
| `ListBusinessMandatesRequest` | `src/UpvestInvestmentApi/Requests/Mandates/ListBusinessMandatesRequest.cs` |
| `Sort4` | `src/UpvestInvestmentApi/Models/Enums/Sort4.cs` |
| `Order` | `src/UpvestInvestmentApi/Models/Enums/Order.cs` |
| `UpvestApiVersion` | `src/UpvestInvestmentApi/Models/Enums/UpvestApiVersion.cs` |
| `MandatesListBusinessResponse` | `src/UpvestInvestmentApi/Models/MandatesListBusinessResponse.cs` |
| `ListBusinessMandatesError` | `src/UpvestInvestmentApi/Errors/ListBusinessMandatesError.cs` |

### ListMandates

- **Auth**: `options.OauthClientCredentials` (scopes: `mandates:admin`, `mandates:read`)
- **Signature**: `ListMandates(ListMandatesRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `UserId`
- **Query params (wire ← C#)**: `sort` ← `Sort`, `order` ← `Order`, `limit` ← `Limit`, `offset` ← `Offset`
- **Returns**: `MandatesListResponse`
- **Error**: `ApiException<ListMandatesError>` — **Case A (typed)**
- **Error accessors**: `TryGetNoContent([NotNullWhen(true)] out RawError? value)` [400, 401, 403, 404, 406, 429, 500, 503, 504] · `TryGetRawError([NotNullWhen(true)] out RawError? error)` [fallback]

| Type | Source |
| --- | --- |
| `ListMandatesRequest` | `src/UpvestInvestmentApi/Requests/Mandates/ListMandatesRequest.cs` |
| `Sort4` | `src/UpvestInvestmentApi/Models/Enums/Sort4.cs` |
| `Order` | `src/UpvestInvestmentApi/Models/Enums/Order.cs` |
| `UpvestApiVersion` | `src/UpvestInvestmentApi/Models/Enums/UpvestApiVersion.cs` |
| `MandatesListResponse` | `src/UpvestInvestmentApi/Models/MandatesListResponse.cs` |
| `ListMandatesError` | `src/UpvestInvestmentApi/Errors/ListMandatesError.cs` |

### RetrieveMandate

- **Auth**: `options.OauthClientCredentials` (scopes: `mandates:admin`, `mandates:read`)
- **Signature**: `RetrieveMandate(RetrieveMandateRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `MandateId`
- **Returns**: `DirectDebitMandate`
- **Error**: `ApiException<RetrieveMandateError>` — **Case A (typed)**
- **Error accessors**: `TryGetNoContent([NotNullWhen(true)] out RawError? value)` [401, 403, 404, 406, 429, 500, 503, 504] · `TryGetRawError([NotNullWhen(true)] out RawError? error)` [fallback]

| Type | Source |
| --- | --- |
| `RetrieveMandateRequest` | `src/UpvestInvestmentApi/Requests/Mandates/RetrieveMandateRequest.cs` |
| `UpvestApiVersion` | `src/UpvestInvestmentApi/Models/Enums/UpvestApiVersion.cs` |
| `DirectDebitMandate` | `src/UpvestInvestmentApi/Models/DirectDebitMandate.cs` |
| `RetrieveMandateError` | `src/UpvestInvestmentApi/Errors/RetrieveMandateError.cs` |

