<!-- Generated file — do not edit; regenerated with the SDK. -->

# ReferenceAccounts — operations

Accessor: `client.ReferenceAccounts` · Source: `src/UpvestInvestmentApi/Api/ReferenceAccounts.cs` · 5 operations

**Type sources**: the file declaring each type an operation names (`RawError` excluded — see sdk-map.md).

### CreateReferenceAccount

- **Auth**: `options.OauthClientCredentials` (scopes: `reference_accounts:admin`)
- **Signature**: `CreateReferenceAccount(CreateReferenceAccountRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `IdempotencyKey`
- **Returns**: `ReferenceAccount`
- **Error**: `ApiException<CreateReferenceAccountError>` — **Case A (typed)**
- **Error accessors**: `TryGetNoContent([NotNullWhen(true)] out RawError? value)` [400, 401, 403, 404, 406, 429, 500, 503, 504] · `TryGetRawError([NotNullWhen(true)] out RawError? error)` [fallback]

| Type | Source |
| --- | --- |
| `CreateReferenceAccountRequest` | `src/UpvestInvestmentApi/Requests/ReferenceAccounts/CreateReferenceAccountRequest.cs` |
| `UpvestApiVersion` | `src/UpvestInvestmentApi/Models/Enums/UpvestApiVersion.cs` |
| `ReferenceAccountCreateRequest` | `src/UpvestInvestmentApi/Models/ReferenceAccountCreateRequest.cs` |
| `ReferenceAccount` | `src/UpvestInvestmentApi/Models/ReferenceAccount.cs` |
| `CreateReferenceAccountError` | `src/UpvestInvestmentApi/Errors/CreateReferenceAccountError.cs` |

### DeleteReferenceAccount

- **Auth**: `options.OauthClientCredentials` (scopes: `reference_accounts:admin`)
- **Signature**: `DeleteReferenceAccount(DeleteReferenceAccountRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `ReferenceAccountId`
- **Returns**: `void` (Task)
- **Error**: `ApiException<DeleteReferenceAccountError>` — **Case A (typed)**
- **Error accessors**: `TryGetNoContent([NotNullWhen(true)] out RawError? value)` [401, 403, 404, 429, 500, 503, 504] · `TryGetRawError([NotNullWhen(true)] out RawError? error)` [fallback]

| Type | Source |
| --- | --- |
| `DeleteReferenceAccountRequest` | `src/UpvestInvestmentApi/Requests/ReferenceAccounts/DeleteReferenceAccountRequest.cs` |
| `UpvestApiVersion` | `src/UpvestInvestmentApi/Models/Enums/UpvestApiVersion.cs` |
| `DeleteReferenceAccountError` | `src/UpvestInvestmentApi/Errors/DeleteReferenceAccountError.cs` |

### ListBusinessReferenceAccounts

- **Auth**: `options.OauthClientCredentials` (scopes: `reference_accounts:admin`, `reference_accounts:read`)
- **Signature**: `ListBusinessReferenceAccounts(ListBusinessReferenceAccountsRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `BusinessId`
- **Query params (wire ← C#)**: `sort` ← `Sort`, `order` ← `Order`, `offset` ← `Offset`, `limit` ← `Limit`
- **Returns**: `BusinessReferenceAccountsListResponse`
- **Error**: `ApiException<ListBusinessReferenceAccountsError>` — **Case A (typed)**
- **Error accessors**: `TryGetNoContent([NotNullWhen(true)] out RawError? value)` [400, 401, 403, 404, 406, 429, 500, 503, 504] · `TryGetRawError([NotNullWhen(true)] out RawError? error)` [fallback]

| Type | Source |
| --- | --- |
| `ListBusinessReferenceAccountsRequest` | `src/UpvestInvestmentApi/Requests/ReferenceAccounts/ListBusinessReferenceAccountsRequest.cs` |
| `Sort4` | `src/UpvestInvestmentApi/Models/Enums/Sort4.cs` |
| `Order` | `src/UpvestInvestmentApi/Models/Enums/Order.cs` |
| `UpvestApiVersion` | `src/UpvestInvestmentApi/Models/Enums/UpvestApiVersion.cs` |
| `BusinessReferenceAccountsListResponse` | `src/UpvestInvestmentApi/Models/BusinessReferenceAccountsListResponse.cs` |
| `ListBusinessReferenceAccountsError` | `src/UpvestInvestmentApi/Errors/ListBusinessReferenceAccountsError.cs` |

### ListReferenceAccounts

- **Auth**: `options.OauthClientCredentials` (scopes: `reference_accounts:admin`, `reference_accounts:read`)
- **Signature**: `ListReferenceAccounts(ListReferenceAccountsRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `UserId`
- **Query params (wire ← C#)**: `sort` ← `Sort`, `order` ← `Order`, `offset` ← `Offset`, `limit` ← `Limit`
- **Returns**: `UsersListResponse1`
- **Error**: `ApiException<ListReferenceAccountsError>` — **Case A (typed)**
- **Error accessors**: `TryGetNoContent([NotNullWhen(true)] out RawError? value)` [400, 401, 403, 404, 406, 429, 500, 503, 504] · `TryGetRawError([NotNullWhen(true)] out RawError? error)` [fallback]

| Type | Source |
| --- | --- |
| `ListReferenceAccountsRequest` | `src/UpvestInvestmentApi/Requests/ReferenceAccounts/ListReferenceAccountsRequest.cs` |
| `Sort4` | `src/UpvestInvestmentApi/Models/Enums/Sort4.cs` |
| `Order` | `src/UpvestInvestmentApi/Models/Enums/Order.cs` |
| `UpvestApiVersion` | `src/UpvestInvestmentApi/Models/Enums/UpvestApiVersion.cs` |
| `UsersListResponse1` | `src/UpvestInvestmentApi/Models/UsersListResponse1.cs` |
| `ListReferenceAccountsError` | `src/UpvestInvestmentApi/Errors/ListReferenceAccountsError.cs` |

### RetrieveReferenceAccount

- **Auth**: `options.OauthClientCredentials` (scopes: `reference_accounts:admin`, `reference_accounts:read`)
- **Signature**: `RetrieveReferenceAccount(RetrieveReferenceAccountRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `ReferenceAccountId`
- **Returns**: `ReferenceAccount`
- **Error**: `ApiException<RetrieveReferenceAccountError>` — **Case A (typed)**
- **Error accessors**: `TryGetNoContent([NotNullWhen(true)] out RawError? value)` [401, 403, 404, 406, 429, 500, 503, 504] · `TryGetRawError([NotNullWhen(true)] out RawError? error)` [fallback]

| Type | Source |
| --- | --- |
| `RetrieveReferenceAccountRequest` | `src/UpvestInvestmentApi/Requests/ReferenceAccounts/RetrieveReferenceAccountRequest.cs` |
| `UpvestApiVersion` | `src/UpvestInvestmentApi/Models/Enums/UpvestApiVersion.cs` |
| `ReferenceAccount` | `src/UpvestInvestmentApi/Models/ReferenceAccount.cs` |
| `RetrieveReferenceAccountError` | `src/UpvestInvestmentApi/Errors/RetrieveReferenceAccountError.cs` |

