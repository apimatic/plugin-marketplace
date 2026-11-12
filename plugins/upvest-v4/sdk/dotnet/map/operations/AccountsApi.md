<!-- Generated file — do not edit; regenerated with the SDK. -->

# AccountsApi — operations

Accessor: `client.AccountsApi` · Source: `src/UpvestInvestmentApi/Api/AccountsApi.cs` · 7 operations

**Type sources**: the file declaring each type an operation names (`RawError` excluded — see sdk-map.md).

### AccountClosure

- **Auth**: `options.OauthClientCredentials` (scopes: `accounts:admin`)
- **Signature**: `AccountClosure(AccountClosureRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `AccountId`
- **Returns**: `void` (Task)
- **Error**: `ApiException<AccountClosureError>` — **Case A (typed)**
- **Error accessors**: `TryGetNoContent([NotNullWhen(true)] out RawError? value)` [401, 403, 404, 406, 409, 429, 500, 503, 504] · `TryGetRawError([NotNullWhen(true)] out RawError? error)` [fallback]

| Type | Source |
| --- | --- |
| `AccountClosureRequest` | `src/UpvestInvestmentApi/Requests/AccountsApi/AccountClosureRequest.cs` |
| `UpvestApiVersion` | `src/UpvestInvestmentApi/Models/Enums/UpvestApiVersion.cs` |
| `AccountClosureError` | `src/UpvestInvestmentApi/Errors/AccountClosureError.cs` |

### CreateAccount

- **Auth**: `options.OauthClientCredentials` (scopes: `accounts:admin`)
- **Signature**: `CreateAccount(CreateAccountRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `IdempotencyKey`
- **Returns**: `AccountCreateResponse`
- **Error**: `ApiException<CreateAccountError>` — **Case A (typed)**
- **Error accessors**: `TryGetNoContent([NotNullWhen(true)] out RawError? value)` [400, 401, 403, 404, 406, 429, 500, 503, 504] · `TryGetRawError([NotNullWhen(true)] out RawError? error)` [fallback]

| Type | Source |
| --- | --- |
| `CreateAccountRequest` | `src/UpvestInvestmentApi/Requests/AccountsApi/CreateAccountRequest.cs` |
| `UpvestApiVersion` | `src/UpvestInvestmentApi/Models/Enums/UpvestApiVersion.cs` |
| `AccountCreateRequest` | `src/UpvestInvestmentApi/Models/AnyOf/AccountCreateRequest.cs` |
| `AccountCreateResponse` | `src/UpvestInvestmentApi/Models/AnyOf/AccountCreateResponse.cs` |
| `CreateAccountError` | `src/UpvestInvestmentApi/Errors/CreateAccountError.cs` |

### ListAccounts

- **Auth**: `options.OauthClientCredentials` (scopes: `accounts:read`, `accounts:admin`)
- **Signature**: `ListAccounts(ListAccountsRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
- **Query params (wire ← C#)**: `sort` ← `Sort`, `order` ← `Order`, `offset` ← `Offset`, `limit` ← `Limit`
- **Returns**: `AccountsListResponse1`
- **Error**: `ApiException<ListAccountsError>` — **Case A (typed)**
- **Error accessors**: `TryGetNoContent([NotNullWhen(true)] out RawError? value)` [400, 401, 403, 406, 429, 500, 503, 504] · `TryGetRawError([NotNullWhen(true)] out RawError? error)` [fallback]

| Type | Source |
| --- | --- |
| `ListAccountsRequest` | `src/UpvestInvestmentApi/Requests/AccountsApi/ListAccountsRequest.cs` |
| `Sort1` | `src/UpvestInvestmentApi/Models/Enums/Sort1.cs` |
| `Order` | `src/UpvestInvestmentApi/Models/Enums/Order.cs` |
| `UpvestApiVersion` | `src/UpvestInvestmentApi/Models/Enums/UpvestApiVersion.cs` |
| `AccountsListResponse1` | `src/UpvestInvestmentApi/Models/AccountsListResponse1.cs` |
| `ListAccountsError` | `src/UpvestInvestmentApi/Errors/ListAccountsError.cs` |

### ListBusinessAccounts

- **Auth**: `options.OauthClientCredentials` (scopes: `accounts:read`, `accounts:admin`)
- **Signature**: `ListBusinessAccounts(ListBusinessAccountsRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `BusinessId`
- **Query params (wire ← C#)**: `sort` ← `Sort`, `order` ← `Order`, `offset` ← `Offset`, `limit` ← `Limit`
- **Returns**: `AccountsListResponse2`
- **Error**: `ApiException<ListBusinessAccountsError>` — **Case A (typed)**
- **Error accessors**: `TryGetNoContent([NotNullWhen(true)] out RawError? value)` [400, 401, 403, 404, 406, 429, 500, 503, 504] · `TryGetRawError([NotNullWhen(true)] out RawError? error)` [fallback]

| Type | Source |
| --- | --- |
| `ListBusinessAccountsRequest` | `src/UpvestInvestmentApi/Requests/AccountsApi/ListBusinessAccountsRequest.cs` |
| `Sort1` | `src/UpvestInvestmentApi/Models/Enums/Sort1.cs` |
| `Order` | `src/UpvestInvestmentApi/Models/Enums/Order.cs` |
| `UpvestApiVersion` | `src/UpvestInvestmentApi/Models/Enums/UpvestApiVersion.cs` |
| `AccountsListResponse2` | `src/UpvestInvestmentApi/Models/AccountsListResponse2.cs` |
| `ListBusinessAccountsError` | `src/UpvestInvestmentApi/Errors/ListBusinessAccountsError.cs` |

### ListUserAccounts

- **Auth**: `options.OauthClientCredentials` (scopes: `accounts:read`, `accounts:admin`)
- **Signature**: `ListUserAccounts(ListUserAccountsRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `UserId`
- **Query params (wire ← C#)**: `sort` ← `Sort`, `order` ← `Order`, `offset` ← `Offset`, `limit` ← `Limit`
- **Returns**: `AccountsListResponse`
- **Error**: `ApiException<ListUserAccountsError>` — **Case A (typed)**
- **Error accessors**: `TryGetNoContent([NotNullWhen(true)] out RawError? value)` [400, 401, 403, 404, 406, 429, 500, 503, 504] · `TryGetRawError([NotNullWhen(true)] out RawError? error)` [fallback]

| Type | Source |
| --- | --- |
| `ListUserAccountsRequest` | `src/UpvestInvestmentApi/Requests/AccountsApi/ListUserAccountsRequest.cs` |
| `Sort1` | `src/UpvestInvestmentApi/Models/Enums/Sort1.cs` |
| `Order` | `src/UpvestInvestmentApi/Models/Enums/Order.cs` |
| `UpvestApiVersion` | `src/UpvestInvestmentApi/Models/Enums/UpvestApiVersion.cs` |
| `AccountsListResponse` | `src/UpvestInvestmentApi/Models/AccountsListResponse.cs` |
| `ListUserAccountsError` | `src/UpvestInvestmentApi/Errors/ListUserAccountsError.cs` |

### RetrieveAccount

- **Auth**: `options.OauthClientCredentials` (scopes: `accounts:read`, `accounts:admin`)
- **Signature**: `RetrieveAccount(RetrieveAccountRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `AccountId`
- **Returns**: `AccountRetrieveResponse`
- **Error**: `ApiException<RetrieveAccountError>` — **Case A (typed)**
- **Error accessors**: `TryGetNoContent([NotNullWhen(true)] out RawError? value)` [401, 403, 404, 406, 429, 500, 503, 504] · `TryGetRawError([NotNullWhen(true)] out RawError? error)` [fallback]

| Type | Source |
| --- | --- |
| `RetrieveAccountRequest` | `src/UpvestInvestmentApi/Requests/AccountsApi/RetrieveAccountRequest.cs` |
| `UpvestApiVersion` | `src/UpvestInvestmentApi/Models/Enums/UpvestApiVersion.cs` |
| `AccountRetrieveResponse` | `src/UpvestInvestmentApi/Models/AnyOf/AccountRetrieveResponse.cs` |
| `RetrieveAccountError` | `src/UpvestInvestmentApi/Errors/RetrieveAccountError.cs` |

### UpdateAccount

- **Auth**: `options.OauthClientCredentials` (scopes: `accounts:admin`)
- **Signature**: `UpdateAccount(UpdateAccountRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `AccountId`
- **Returns**: `AccountUpdateResponse`
- **Error**: `ApiException<UpdateAccountError>` — **Case A (typed)**
- **Error accessors**: `TryGetNoContent([NotNullWhen(true)] out RawError? value)` [400, 401, 403, 404, 406, 429, 500, 503, 504] · `TryGetRawError([NotNullWhen(true)] out RawError? error)` [fallback]

| Type | Source |
| --- | --- |
| `UpdateAccountRequest` | `src/UpvestInvestmentApi/Requests/AccountsApi/UpdateAccountRequest.cs` |
| `UpvestApiVersion` | `src/UpvestInvestmentApi/Models/Enums/UpvestApiVersion.cs` |
| `AccountUpdateRequest` | `src/UpvestInvestmentApi/Models/AccountUpdateRequest.cs` |
| `AccountUpdateResponse` | `src/UpvestInvestmentApi/Models/AnyOf/AccountUpdateResponse.cs` |
| `UpdateAccountError` | `src/UpvestInvestmentApi/Errors/UpdateAccountError.cs` |

