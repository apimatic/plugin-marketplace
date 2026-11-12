<!-- Generated file — do not edit; regenerated with the SDK. -->

# AccountGroups — operations

Accessor: `client.AccountGroups` · Source: `src/UpvestInvestmentApi/Api/AccountGroups.cs` · 6 operations

**Type sources**: the file declaring each type an operation names (`RawError` excluded — see sdk-map.md).

### AccountGroupClosure

- **Auth**: `options.OauthClientCredentials` (scopes: `accounts:admin`)
- **Signature**: `AccountGroupClosure(AccountGroupClosureRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `AccountGroupId`
- **Query params (wire ← C#)**: `closure_reason` ← `ClosureReason`, `notification_only` ← `NotificationOnly`
- **Returns**: `void` (Task)
- **Error**: `ApiException<AccountGroupClosureError>` — **Case A (typed)**
- **Error accessors**: `TryGetNoContent([NotNullWhen(true)] out RawError? value)` [400, 401, 403, 404, 406, 409, 429, 500, 503, 504] · `TryGetRawError([NotNullWhen(true)] out RawError? error)` [fallback]

| Type | Source |
| --- | --- |
| `AccountGroupClosureRequest` | `src/UpvestInvestmentApi/Requests/AccountGroups/AccountGroupClosureRequest.cs` |
| `ClosureReason` | `src/UpvestInvestmentApi/Models/Enums/ClosureReason.cs` |
| `UpvestApiVersion` | `src/UpvestInvestmentApi/Models/Enums/UpvestApiVersion.cs` |
| `AccountGroupClosureError` | `src/UpvestInvestmentApi/Errors/AccountGroupClosureError.cs` |

### CreateAccountGroup

- **Auth**: `options.OauthClientCredentials` (scopes: `accounts:admin`)
- **Signature**: `CreateAccountGroup(CreateAccountGroupRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `IdempotencyKey`
- **Returns**: `AccountGroupCreateResponse`
- **Error**: `ApiException<CreateAccountGroupError>` — **Case A (typed)**
- **Error accessors**: `TryGetNoContent([NotNullWhen(true)] out RawError? value)` [400, 401, 403, 404, 406, 429, 500, 503, 504] · `TryGetRawError([NotNullWhen(true)] out RawError? error)` [fallback]

| Type | Source |
| --- | --- |
| `CreateAccountGroupRequest` | `src/UpvestInvestmentApi/Requests/AccountGroups/CreateAccountGroupRequest.cs` |
| `UpvestApiVersion` | `src/UpvestInvestmentApi/Models/Enums/UpvestApiVersion.cs` |
| `AccountGroupCreateRequest` | `src/UpvestInvestmentApi/Models/AnyOf/AccountGroupCreateRequest.cs` |
| `AccountGroupCreateResponse` | `src/UpvestInvestmentApi/Models/AnyOf/AccountGroupCreateResponse.cs` |
| `CreateAccountGroupError` | `src/UpvestInvestmentApi/Errors/CreateAccountGroupError.cs` |

### ListAccountGroups

- **Auth**: `options.OauthClientCredentials` (scopes: `accounts:read`, `accounts:admin`)
- **Signature**: `ListAccountGroups(ListAccountGroupsRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
- **Query params (wire ← C#)**: `sort` ← `Sort`, `order` ← `Order`, `offset` ← `Offset`, `limit` ← `Limit`
- **Returns**: `AccountGroupsListResponse1`
- **Error**: `ApiException<ListAccountGroupsError>` — **Case A (typed)**
- **Error accessors**: `TryGetNoContent([NotNullWhen(true)] out RawError? value)` [400, 401, 403, 406, 429, 500, 503, 504] · `TryGetRawError([NotNullWhen(true)] out RawError? error)` [fallback]

| Type | Source |
| --- | --- |
| `ListAccountGroupsRequest` | `src/UpvestInvestmentApi/Requests/AccountGroups/ListAccountGroupsRequest.cs` |
| `Sort1` | `src/UpvestInvestmentApi/Models/Enums/Sort1.cs` |
| `Order` | `src/UpvestInvestmentApi/Models/Enums/Order.cs` |
| `UpvestApiVersion` | `src/UpvestInvestmentApi/Models/Enums/UpvestApiVersion.cs` |
| `AccountGroupsListResponse1` | `src/UpvestInvestmentApi/Models/AccountGroupsListResponse1.cs` |
| `ListAccountGroupsError` | `src/UpvestInvestmentApi/Errors/ListAccountGroupsError.cs` |

### ListBusinessAccountGroups

- **Auth**: `options.OauthClientCredentials` (scopes: `accounts:read`, `accounts:admin`)
- **Signature**: `ListBusinessAccountGroups(ListBusinessAccountGroupsRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `BusinessId`
- **Query params (wire ← C#)**: `sort` ← `Sort`, `order` ← `Order`, `offset` ← `Offset`, `limit` ← `Limit`
- **Returns**: `AccountGroupsListResponse2`
- **Error**: `ApiException<ListBusinessAccountGroupsError>` — **Case A (typed)**
- **Error accessors**: `TryGetNoContent([NotNullWhen(true)] out RawError? value)` [400, 401, 403, 404, 406, 429, 500, 503, 504] · `TryGetRawError([NotNullWhen(true)] out RawError? error)` [fallback]

| Type | Source |
| --- | --- |
| `ListBusinessAccountGroupsRequest` | `src/UpvestInvestmentApi/Requests/AccountGroups/ListBusinessAccountGroupsRequest.cs` |
| `Sort1` | `src/UpvestInvestmentApi/Models/Enums/Sort1.cs` |
| `Order` | `src/UpvestInvestmentApi/Models/Enums/Order.cs` |
| `UpvestApiVersion` | `src/UpvestInvestmentApi/Models/Enums/UpvestApiVersion.cs` |
| `AccountGroupsListResponse2` | `src/UpvestInvestmentApi/Models/AccountGroupsListResponse2.cs` |
| `ListBusinessAccountGroupsError` | `src/UpvestInvestmentApi/Errors/ListBusinessAccountGroupsError.cs` |

### ListUserAccountGroups

- **Auth**: `options.OauthClientCredentials` (scopes: `accounts:read`, `accounts:admin`)
- **Signature**: `ListUserAccountGroups(ListUserAccountGroupsRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `UserId`
- **Query params (wire ← C#)**: `sort` ← `Sort`, `order` ← `Order`, `offset` ← `Offset`, `limit` ← `Limit`
- **Returns**: `AccountGroupsListResponse`
- **Error**: `ApiException<ListUserAccountGroupsError>` — **Case A (typed)**
- **Error accessors**: `TryGetNoContent([NotNullWhen(true)] out RawError? value)` [400, 401, 403, 404, 406, 429, 500, 503, 504] · `TryGetRawError([NotNullWhen(true)] out RawError? error)` [fallback]

| Type | Source |
| --- | --- |
| `ListUserAccountGroupsRequest` | `src/UpvestInvestmentApi/Requests/AccountGroups/ListUserAccountGroupsRequest.cs` |
| `Sort1` | `src/UpvestInvestmentApi/Models/Enums/Sort1.cs` |
| `Order` | `src/UpvestInvestmentApi/Models/Enums/Order.cs` |
| `UpvestApiVersion` | `src/UpvestInvestmentApi/Models/Enums/UpvestApiVersion.cs` |
| `AccountGroupsListResponse` | `src/UpvestInvestmentApi/Models/AccountGroupsListResponse.cs` |
| `ListUserAccountGroupsError` | `src/UpvestInvestmentApi/Errors/ListUserAccountGroupsError.cs` |

### RetrieveAccountGroup

- **Auth**: `options.OauthClientCredentials` (scopes: `accounts:read`, `accounts:admin`)
- **Signature**: `RetrieveAccountGroup(RetrieveAccountGroupRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `AccountGroupId`
- **Returns**: `AccountGroupRetrieveResponse`
- **Error**: `ApiException<RetrieveAccountGroupError>` — **Case A (typed)**
- **Error accessors**: `TryGetNoContent([NotNullWhen(true)] out RawError? value)` [401, 403, 404, 406, 429, 500, 503, 504] · `TryGetRawError([NotNullWhen(true)] out RawError? error)` [fallback]

| Type | Source |
| --- | --- |
| `RetrieveAccountGroupRequest` | `src/UpvestInvestmentApi/Requests/AccountGroups/RetrieveAccountGroupRequest.cs` |
| `UpvestApiVersion` | `src/UpvestInvestmentApi/Models/Enums/UpvestApiVersion.cs` |
| `AccountGroupRetrieveResponse` | `src/UpvestInvestmentApi/Models/AnyOf/AccountGroupRetrieveResponse.cs` |
| `RetrieveAccountGroupError` | `src/UpvestInvestmentApi/Errors/RetrieveAccountGroupError.cs` |

