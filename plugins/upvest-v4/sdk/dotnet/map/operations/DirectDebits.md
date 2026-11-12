<!-- Generated file — do not edit; regenerated with the SDK. -->

# DirectDebits — operations

Accessor: `client.DirectDebits` · Source: `src/UpvestInvestmentApi/Api/DirectDebits.cs` · 3 operations

**Type sources**: the file declaring each type an operation names (`RawError` excluded — see sdk-map.md).

### CreateDirectDebit

- **Auth**: `options.OauthClientCredentials` (scopes: `payments:admin`)
- **Signature**: `CreateDirectDebit(CreateDirectDebitRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `IdempotencyKey`
- **Returns**: `PaymentsDirectDebitsResponse`
- **Error**: `ApiException<CreateDirectDebitError>` — **Case A (typed)**
- **Error accessors**: `TryGetNoContent([NotNullWhen(true)] out RawError? value)` [400, 401, 403, 404, 406, 429, 500, 503, 504] · `TryGetRawError([NotNullWhen(true)] out RawError? error)` [fallback]

| Type | Source |
| --- | --- |
| `CreateDirectDebitRequest` | `src/UpvestInvestmentApi/Requests/DirectDebits/CreateDirectDebitRequest.cs` |
| `UpvestApiVersion` | `src/UpvestInvestmentApi/Models/Enums/UpvestApiVersion.cs` |
| `PaymentsDirectDebitCreateRequest` | `src/UpvestInvestmentApi/Models/PaymentsDirectDebitCreateRequest.cs` |
| `PaymentsDirectDebitsResponse` | `src/UpvestInvestmentApi/Models/PaymentsDirectDebitsResponse.cs` |
| `CreateDirectDebitError` | `src/UpvestInvestmentApi/Errors/CreateDirectDebitError.cs` |

### ListDirectDebits

- **Auth**: `options.OauthClientCredentials` (scopes: `payments:admin`, `payments:read`)
- **Signature**: `ListDirectDebits(ListDirectDebitsRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `AccountGroupId`
- **Query params (wire ← C#)**: `sort` ← `Sort`, `order` ← `Order`, `limit` ← `Limit`, `offset` ← `Offset`
- **Returns**: `PaymentsDirectDebitsListResponse`
- **Error**: `ApiException<ListDirectDebitsError>` — **Case A (typed)**
- **Error accessors**: `TryGetNoContent([NotNullWhen(true)] out RawError? value)` [400, 401, 403, 404, 406, 429, 500, 503, 504] · `TryGetRawError([NotNullWhen(true)] out RawError? error)` [fallback]

| Type | Source |
| --- | --- |
| `ListDirectDebitsRequest` | `src/UpvestInvestmentApi/Requests/DirectDebits/ListDirectDebitsRequest.cs` |
| `Sort4` | `src/UpvestInvestmentApi/Models/Enums/Sort4.cs` |
| `Order` | `src/UpvestInvestmentApi/Models/Enums/Order.cs` |
| `UpvestApiVersion` | `src/UpvestInvestmentApi/Models/Enums/UpvestApiVersion.cs` |
| `PaymentsDirectDebitsListResponse` | `src/UpvestInvestmentApi/Models/PaymentsDirectDebitsListResponse.cs` |
| `ListDirectDebitsError` | `src/UpvestInvestmentApi/Errors/ListDirectDebitsError.cs` |

### RetrieveDirectDebit

- **Auth**: `options.OauthClientCredentials` (scopes: `payments:admin`, `payments:read`)
- **Signature**: `RetrieveDirectDebit(RetrieveDirectDebitRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `DirectDebitId`
- **Returns**: `PaymentsDirectDebitsResponse`
- **Error**: `ApiException<RetrieveDirectDebitError>` — **Case A (typed)**
- **Error accessors**: `TryGetNoContent([NotNullWhen(true)] out RawError? value)` [401, 403, 404, 406, 429, 500, 503, 504] · `TryGetRawError([NotNullWhen(true)] out RawError? error)` [fallback]

| Type | Source |
| --- | --- |
| `RetrieveDirectDebitRequest` | `src/UpvestInvestmentApi/Requests/DirectDebits/RetrieveDirectDebitRequest.cs` |
| `UpvestApiVersion` | `src/UpvestInvestmentApi/Models/Enums/UpvestApiVersion.cs` |
| `PaymentsDirectDebitsResponse` | `src/UpvestInvestmentApi/Models/PaymentsDirectDebitsResponse.cs` |
| `RetrieveDirectDebitError` | `src/UpvestInvestmentApi/Errors/RetrieveDirectDebitError.cs` |

