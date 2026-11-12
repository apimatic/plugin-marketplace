<!-- Generated file — do not edit; regenerated with the SDK. -->

# Roles — operations

Accessor: `client.Roles` · Source: `src/UpvestInvestmentApi/Api/Roles.cs` · 4 operations

**Type sources**: the file declaring each type an operation names (`RawError` excluded — see sdk-map.md).

### CreateRole

- **Auth**: `options.OauthClientCredentials` (scopes: `roles:admin`)
- **Signature**: `CreateRole(CreateRoleRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `IdempotencyKey`
- **Returns**: `RoleCreateResponse`
- **Error**: `ApiException<CreateRoleError>` — **Case A (typed)**
- **Error accessors**: `TryGetNoContent([NotNullWhen(true)] out RawError? value)` [400, 401, 403, 406, 429, 500, 503, 504] · `TryGetRawError([NotNullWhen(true)] out RawError? error)` [fallback]

| Type | Source |
| --- | --- |
| `CreateRoleRequest` | `src/UpvestInvestmentApi/Requests/Roles/CreateRoleRequest.cs` |
| `UpvestApiVersion` | `src/UpvestInvestmentApi/Models/Enums/UpvestApiVersion.cs` |
| `RoleCreateRequest` | `src/UpvestInvestmentApi/Models/AnyOf/RoleCreateRequest.cs` |
| `RoleCreateResponse` | `src/UpvestInvestmentApi/Models/AnyOf/RoleCreateResponse.cs` |
| `CreateRoleError` | `src/UpvestInvestmentApi/Errors/CreateRoleError.cs` |

### ListRoles

- **Auth**: `options.OauthClientCredentials` (scopes: `roles:read`, `roles:admin`)
- **Signature**: `ListRoles(ListRolesRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `UserIdTemplate`
- **Query params (wire ← C#)**: `sort` ← `Sort`, `user_id` ← `UserId`, `entity_id` ← `EntityId`, `order` ← `Order`, `offset` ← `Offset`, `limit` ← `Limit`
- **Returns**: `RolesListResponse`
- **Error**: `ApiException<ListRolesError>` — **Case A (typed)**
- **Error accessors**: `TryGetNoContent([NotNullWhen(true)] out RawError? value)` [400, 401, 403, 406, 429, 500, 503, 504] · `TryGetRawError([NotNullWhen(true)] out RawError? error)` [fallback]

| Type | Source |
| --- | --- |
| `ListRolesRequest` | `src/UpvestInvestmentApi/Requests/Roles/ListRolesRequest.cs` |
| `Sort1` | `src/UpvestInvestmentApi/Models/Enums/Sort1.cs` |
| `Order` | `src/UpvestInvestmentApi/Models/Enums/Order.cs` |
| `UpvestApiVersion` | `src/UpvestInvestmentApi/Models/Enums/UpvestApiVersion.cs` |
| `RolesListResponse` | `src/UpvestInvestmentApi/Models/RolesListResponse.cs` |
| `ListRolesError` | `src/UpvestInvestmentApi/Errors/ListRolesError.cs` |

### RetrieveRole

- **Auth**: `options.OauthClientCredentials` (scopes: `roles:read`, `roles:admin`)
- **Signature**: `RetrieveRole(RetrieveRoleRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `RoleId`
- **Returns**: `RoleRetrieveResponse`
- **Error**: `ApiException<RetrieveRoleError>` — **Case A (typed)**
- **Error accessors**: `TryGetNoContent([NotNullWhen(true)] out RawError? value)` [401, 403, 404, 406, 429, 500, 503, 504] · `TryGetRawError([NotNullWhen(true)] out RawError? error)` [fallback]

| Type | Source |
| --- | --- |
| `RetrieveRoleRequest` | `src/UpvestInvestmentApi/Requests/Roles/RetrieveRoleRequest.cs` |
| `UpvestApiVersion` | `src/UpvestInvestmentApi/Models/Enums/UpvestApiVersion.cs` |
| `RoleRetrieveResponse` | `src/UpvestInvestmentApi/Models/AnyOf/RoleRetrieveResponse.cs` |
| `RetrieveRoleError` | `src/UpvestInvestmentApi/Errors/RetrieveRoleError.cs` |

### RoleDeactivation

- **Auth**: `options.OauthClientCredentials` (scopes: `roles:admin`)
- **Signature**: `RoleDeactivation(RoleDeactivationRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `RoleId`
- **Returns**: `void` (Task)
- **Error**: `ApiException<RoleDeactivationError>` — **Case A (typed)**
- **Error accessors**: `TryGetNoContent([NotNullWhen(true)] out RawError? value)` [401, 403, 404, 406, 429, 500, 503, 504] · `TryGetRawError([NotNullWhen(true)] out RawError? error)` [fallback]

| Type | Source |
| --- | --- |
| `RoleDeactivationRequest` | `src/UpvestInvestmentApi/Requests/Roles/RoleDeactivationRequest.cs` |
| `UpvestApiVersion` | `src/UpvestInvestmentApi/Models/Enums/UpvestApiVersion.cs` |
| `RoleDeactivationError` | `src/UpvestInvestmentApi/Errors/RoleDeactivationError.cs` |

