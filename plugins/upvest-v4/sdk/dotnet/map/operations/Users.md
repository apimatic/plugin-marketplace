<!-- Generated file — do not edit; regenerated with the SDK. -->

# Users — operations

Accessor: `client.Users` · Source: `src/UpvestInvestmentApi/Api/Users.cs` · 5 operations

**Type sources**: the file declaring each type an operation names (`RawError` excluded — see sdk-map.md).

### CreateUser

- **Auth**: `options.OauthClientCredentials` (scopes: `users:admin`)
- **Signature**: `CreateUser(CreateUserRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `IdempotencyKey`
- **Returns**: `UserCreateRequest1`
- **Error**: `ApiException<CreateUserError>` — **Case A (typed)**
- **Error accessors**: `TryGetNoContent([NotNullWhen(true)] out RawError? value)` [400, 401, 403, 406, 429, 500, 503, 504] · `TryGetRawError([NotNullWhen(true)] out RawError? error)` [fallback]

| Type | Source |
| --- | --- |
| `CreateUserRequest` | `src/UpvestInvestmentApi/Requests/Users/CreateUserRequest.cs` |
| `UpvestApiVersion` | `src/UpvestInvestmentApi/Models/Enums/UpvestApiVersion.cs` |
| `UserCreateRequest` | `src/UpvestInvestmentApi/Models/AnyOf/UserCreateRequest.cs` |
| `UserCreateRequest1` | `src/UpvestInvestmentApi/Models/AnyOf/UserCreateRequest1.cs` |
| `CreateUserError` | `src/UpvestInvestmentApi/Errors/CreateUserError.cs` |

### ListUsers

- **Auth**: `options.OauthClientCredentials` (scopes: `users:read`, `users:admin`)
- **Signature**: `ListUsers(ListUsersRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
- **Query params (wire ← C#)**: `sort` ← `Sort`, `order` ← `Order`, `offset` ← `Offset`, `limit` ← `Limit`
- **Returns**: `UsersListResponse`
- **Error**: `ApiException<ListUsersError>` — **Case A (typed)**
- **Error accessors**: `TryGetNoContent([NotNullWhen(true)] out RawError? value)` [400, 401, 403, 406, 429, 500, 503, 504] · `TryGetRawError([NotNullWhen(true)] out RawError? error)` [fallback]

| Type | Source |
| --- | --- |
| `ListUsersRequest` | `src/UpvestInvestmentApi/Requests/Users/ListUsersRequest.cs` |
| `Sort1` | `src/UpvestInvestmentApi/Models/Enums/Sort1.cs` |
| `Order` | `src/UpvestInvestmentApi/Models/Enums/Order.cs` |
| `UpvestApiVersion` | `src/UpvestInvestmentApi/Models/Enums/UpvestApiVersion.cs` |
| `UsersListResponse` | `src/UpvestInvestmentApi/Models/UsersListResponse.cs` |
| `ListUsersError` | `src/UpvestInvestmentApi/Errors/ListUsersError.cs` |

### OffboardUser

- **Auth**: `options.OauthClientCredentials` (scopes: `users:admin`)
- **Signature**: `OffboardUser(OffboardUserRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `UserId`
- **Returns**: `void` (Task)
- **Error**: `ApiException<OffboardUserError>` — **Case A (typed)**
- **Error accessors**: `TryGetNoContent([NotNullWhen(true)] out RawError? value)` [401, 403, 404, 406, 429, 500, 503, 504] · `TryGetRawError([NotNullWhen(true)] out RawError? error)` [fallback]

| Type | Source |
| --- | --- |
| `OffboardUserRequest` | `src/UpvestInvestmentApi/Requests/Users/OffboardUserRequest.cs` |
| `UpvestApiVersion` | `src/UpvestInvestmentApi/Models/Enums/UpvestApiVersion.cs` |
| `OffboardUserError` | `src/UpvestInvestmentApi/Errors/OffboardUserError.cs` |

### RetrieveUser

- **Auth**: `options.OauthClientCredentials` (scopes: `users:read`, `users:admin`)
- **Signature**: `RetrieveUser(RetrieveUserRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `UserId`
- **Returns**: `UserGetResponse`
- **Error**: `ApiException<RetrieveUserError>` — **Case A (typed)**
- **Error accessors**: `TryGetNoContent([NotNullWhen(true)] out RawError? value)` [401, 403, 404, 406, 429, 500, 503, 504] · `TryGetRawError([NotNullWhen(true)] out RawError? error)` [fallback]

| Type | Source |
| --- | --- |
| `RetrieveUserRequest` | `src/UpvestInvestmentApi/Requests/Users/RetrieveUserRequest.cs` |
| `UpvestApiVersion` | `src/UpvestInvestmentApi/Models/Enums/UpvestApiVersion.cs` |
| `UserGetResponse` | `src/UpvestInvestmentApi/Models/AnyOf/UserGetResponse.cs` |
| `RetrieveUserError` | `src/UpvestInvestmentApi/Errors/RetrieveUserError.cs` |

### UserDataChange

- **Auth**: `options.OauthClientCredentials` (scopes: `users:admin`)
- **Signature**: `UserDataChange(UserDataChangeOperationRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `UserId`
- **Returns**: `void` (Task)
- **Error**: `ApiException<UserDataChangeError>` — **Case A (typed)**
- **Error accessors**: `TryGetNoContent([NotNullWhen(true)] out RawError? value)` [400, 401, 403, 404, 406, 429, 500, 503, 504] · `TryGetRawError([NotNullWhen(true)] out RawError? error)` [fallback]

| Type | Source |
| --- | --- |
| `UserDataChangeOperationRequest` | `src/UpvestInvestmentApi/Requests/Users/UserDataChangeOperationRequest.cs` |
| `UpvestApiVersion` | `src/UpvestInvestmentApi/Models/Enums/UpvestApiVersion.cs` |
| `UserDataChangeRequest` | `src/UpvestInvestmentApi/Models/AnyOf/UserDataChangeRequest.cs` |
| `UserDataChangeError` | `src/UpvestInvestmentApi/Errors/UserDataChangeError.cs` |

