<!-- Generated file — do not edit; regenerated with the SDK. -->

# UserChecks — operations

Accessor: `client.UserChecks` · Source: `src/UpvestInvestmentApi/Api/UserChecks.cs` · 3 operations

**Type sources**: the file declaring each type an operation names (`RawError` excluded — see sdk-map.md).

### CreateUserCheck

- **Auth**: `options.OauthClientCredentials` (scopes: `checks:admin`)
- **Signature**: `CreateUserCheck(CreateUserCheckRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `UserId`
- **Returns**: `UserCheckCreateResponse`
- **Error**: `ApiException<CreateUserCheckError>` — **Case A (typed)**
- **Error accessors**: `TryGetNoContent([NotNullWhen(true)] out RawError? value)` [400, 401, 403, 404, 406, 429, 500, 503, 504] · `TryGetRawError([NotNullWhen(true)] out RawError? error)` [fallback]

| Type | Source |
| --- | --- |
| `CreateUserCheckRequest` | `src/UpvestInvestmentApi/Requests/UserChecks/CreateUserCheckRequest.cs` |
| `UpvestApiVersion` | `src/UpvestInvestmentApi/Models/Enums/UpvestApiVersion.cs` |
| `UserCheckCreateRequest` | `src/UpvestInvestmentApi/Models/AnyOf/UserCheckCreateRequest.cs` |
| `UserCheckCreateResponse` | `src/UpvestInvestmentApi/Models/UserCheckCreateResponse.cs` |
| `CreateUserCheckError` | `src/UpvestInvestmentApi/Errors/CreateUserCheckError.cs` |

### ListUserChecks

- **Auth**: `options.OauthClientCredentials` (scopes: `checks:read`, `checks:admin`)
- **Signature**: `ListUserChecks(ListUserChecksRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `UserId`
- **Query params (wire ← C#)**: `list_history` ← `ListHistory`, `type` ← `Type`
- **Returns**: `UserCheckListResponse`
- **Error**: `ApiException<ListUserChecksError>` — **Case A (typed)**
- **Error accessors**: `TryGetNoContent([NotNullWhen(true)] out RawError? value)` [400, 401, 403, 404, 406, 429, 500, 503, 504] · `TryGetRawError([NotNullWhen(true)] out RawError? error)` [fallback]

| Type | Source |
| --- | --- |
| `ListUserChecksRequest` | `src/UpvestInvestmentApi/Requests/UserChecks/ListUserChecksRequest.cs` |
| `Type6` | `src/UpvestInvestmentApi/Models/Enums/Type6.cs` |
| `UpvestApiVersion` | `src/UpvestInvestmentApi/Models/Enums/UpvestApiVersion.cs` |
| `UserCheckListResponse` | `src/UpvestInvestmentApi/Models/UserCheckListResponse.cs` |
| `ListUserChecksError` | `src/UpvestInvestmentApi/Errors/ListUserChecksError.cs` |

### RetrieveUserCheck

- **Auth**: `options.OauthClientCredentials` (scopes: `checks:read`, `checks:admin`)
- **Signature**: `RetrieveUserCheck(RetrieveUserCheckRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `UserId`, `CheckId`
- **Returns**: `UserCheck`
- **Error**: `ApiException<RetrieveUserCheckError>` — **Case A (typed)**
- **Error accessors**: `TryGetNoContent([NotNullWhen(true)] out RawError? value)` [401, 403, 404, 406, 429, 500, 503, 504] · `TryGetRawError([NotNullWhen(true)] out RawError? error)` [fallback]

| Type | Source |
| --- | --- |
| `RetrieveUserCheckRequest` | `src/UpvestInvestmentApi/Requests/UserChecks/RetrieveUserCheckRequest.cs` |
| `UpvestApiVersion` | `src/UpvestInvestmentApi/Models/Enums/UpvestApiVersion.cs` |
| `UserCheck` | `src/UpvestInvestmentApi/Models/AnyOf/UserCheck.cs` |
| `RetrieveUserCheckError` | `src/UpvestInvestmentApi/Errors/RetrieveUserCheckError.cs` |

