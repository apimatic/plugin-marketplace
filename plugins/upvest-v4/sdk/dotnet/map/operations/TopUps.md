<!-- Generated file — do not edit; regenerated with the SDK. -->

# TopUps — operations

Accessor: `client.TopUps` · Source: `src/UpvestInvestmentApi/Api/TopUps.cs` · 4 operations

**Type sources**: the file declaring each type an operation names (`RawError` excluded — see sdk-map.md).

### CancelTopup

- **Auth**: `options.OauthClientCredentials` (scopes: `topups:admin`)
- **Signature**: `CancelTopup(CancelTopupRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `TopupId`
- **Returns**: `void` (Task)
- **Error**: `ApiException<CancelTopupError>` — **Case A (typed)**
- **Error accessors**: `TryGetNoContent([NotNullWhen(true)] out RawError? value)` [401, 403, 404, 422, 429, 500, 503, 504] · `TryGetRawError([NotNullWhen(true)] out RawError? error)` [fallback]

| Type | Source |
| --- | --- |
| `CancelTopupRequest` | `src/UpvestInvestmentApi/Requests/TopUps/CancelTopupRequest.cs` |
| `UpvestApiVersion` | `src/UpvestInvestmentApi/Models/Enums/UpvestApiVersion.cs` |
| `CancelTopupError` | `src/UpvestInvestmentApi/Errors/CancelTopupError.cs` |

### CreateTopup

- **Auth**: `options.OauthClientCredentials` (scopes: `topups:admin`)
- **Signature**: `CreateTopup(CreateTopupRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `IdempotencyKey`
- **Returns**: `PaymentsTopupsResponse`
- **Error**: `ApiException<CreateTopupError>` — **Case A (typed)**
- **Error accessors**: `TryGetNoContent([NotNullWhen(true)] out RawError? value)` [400, 401, 403, 404, 406, 429, 500, 503, 504] · `TryGetRawError([NotNullWhen(true)] out RawError? error)` [fallback]

| Type | Source |
| --- | --- |
| `CreateTopupRequest` | `src/UpvestInvestmentApi/Requests/TopUps/CreateTopupRequest.cs` |
| `UpvestApiVersion` | `src/UpvestInvestmentApi/Models/Enums/UpvestApiVersion.cs` |
| `PaymentsTopUpCreateRequest` | `src/UpvestInvestmentApi/Models/PaymentsTopUpCreateRequest.cs` |
| `PaymentsTopupsResponse` | `src/UpvestInvestmentApi/Models/PaymentsTopupsResponse.cs` |
| `CreateTopupError` | `src/UpvestInvestmentApi/Errors/CreateTopupError.cs` |

### ListTopups

- **Auth**: `options.OauthClientCredentials` (scopes: `topups:admin`, `topups:read`)
- **Signature**: `ListTopups(ListTopupsRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `AccountGroupId`
- **Query params (wire ← C#)**: `sort` ← `Sort`, `order` ← `Order`, `limit` ← `Limit`, `offset` ← `Offset`
- **Returns**: `PaymentsTopUpsListResponse`
- **Error**: `ApiException<ListTopupsError>` — **Case A (typed)**
- **Error accessors**: `TryGetNoContent([NotNullWhen(true)] out RawError? value)` [400, 401, 403, 404, 406, 429, 500, 503, 504] · `TryGetRawError([NotNullWhen(true)] out RawError? error)` [fallback]

| Type | Source |
| --- | --- |
| `ListTopupsRequest` | `src/UpvestInvestmentApi/Requests/TopUps/ListTopupsRequest.cs` |
| `Sort4` | `src/UpvestInvestmentApi/Models/Enums/Sort4.cs` |
| `Order` | `src/UpvestInvestmentApi/Models/Enums/Order.cs` |
| `UpvestApiVersion` | `src/UpvestInvestmentApi/Models/Enums/UpvestApiVersion.cs` |
| `PaymentsTopUpsListResponse` | `src/UpvestInvestmentApi/Models/PaymentsTopUpsListResponse.cs` |
| `ListTopupsError` | `src/UpvestInvestmentApi/Errors/ListTopupsError.cs` |

### RetrieveTopup

- **Auth**: `options.OauthClientCredentials` (scopes: `topups:admin`, `topups:read`)
- **Signature**: `RetrieveTopup(RetrieveTopupRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `TopupId`
- **Returns**: `PaymentsTopupsResponse`
- **Error**: `ApiException<RetrieveTopupError>` — **Case A (typed)**
- **Error accessors**: `TryGetNoContent([NotNullWhen(true)] out RawError? value)` [401, 403, 404, 406, 429, 500, 503, 504] · `TryGetRawError([NotNullWhen(true)] out RawError? error)` [fallback]

| Type | Source |
| --- | --- |
| `RetrieveTopupRequest` | `src/UpvestInvestmentApi/Requests/TopUps/RetrieveTopupRequest.cs` |
| `UpvestApiVersion` | `src/UpvestInvestmentApi/Models/Enums/UpvestApiVersion.cs` |
| `PaymentsTopupsResponse` | `src/UpvestInvestmentApi/Models/PaymentsTopupsResponse.cs` |
| `RetrieveTopupError` | `src/UpvestInvestmentApi/Errors/RetrieveTopupError.cs` |

