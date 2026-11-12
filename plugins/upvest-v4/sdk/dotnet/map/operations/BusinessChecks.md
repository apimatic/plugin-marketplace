<!-- Generated file — do not edit; regenerated with the SDK. -->

# BusinessChecks — operations

Accessor: `client.BusinessChecks` · Source: `src/UpvestInvestmentApi/Api/BusinessChecks.cs` · 3 operations

**Type sources**: the file declaring each type an operation names (`RawError` excluded — see sdk-map.md).

### CreateBusinessCheck

- **Auth**: `options.OauthClientCredentials` (scopes: `checks:admin`)
- **Signature**: `CreateBusinessCheck(CreateBusinessCheckRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `BusinessId`
- **Returns**: `BusinessCheckCreateResponse`
- **Error**: `ApiException<CreateBusinessCheckError>` — **Case A (typed)**
- **Error accessors**: `TryGetNoContent([NotNullWhen(true)] out RawError? value)` [400, 401, 403, 404, 406, 429, 500, 503, 504] · `TryGetRawError([NotNullWhen(true)] out RawError? error)` [fallback]

| Type | Source |
| --- | --- |
| `CreateBusinessCheckRequest` | `src/UpvestInvestmentApi/Requests/BusinessChecks/CreateBusinessCheckRequest.cs` |
| `UpvestApiVersion` | `src/UpvestInvestmentApi/Models/Enums/UpvestApiVersion.cs` |
| `BusinessCheckCreateRequest` | `src/UpvestInvestmentApi/Models/AnyOf/BusinessCheckCreateRequest.cs` |
| `BusinessCheckCreateResponse` | `src/UpvestInvestmentApi/Models/BusinessCheckCreateResponse.cs` |
| `CreateBusinessCheckError` | `src/UpvestInvestmentApi/Errors/CreateBusinessCheckError.cs` |

### ListBusinessChecks

- **Auth**: `options.OauthClientCredentials` (scopes: `checks:read`, `checks:admin`)
- **Signature**: `ListBusinessChecks(ListBusinessChecksRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `BusinessId`
- **Returns**: `BusinessCheckListResponse`
- **Error**: `ApiException<ListBusinessChecksError>` — **Case A (typed)**
- **Error accessors**: `TryGetNoContent([NotNullWhen(true)] out RawError? value)` [401, 403, 404, 406, 429, 500, 503, 504] · `TryGetRawError([NotNullWhen(true)] out RawError? error)` [fallback]

| Type | Source |
| --- | --- |
| `ListBusinessChecksRequest` | `src/UpvestInvestmentApi/Requests/BusinessChecks/ListBusinessChecksRequest.cs` |
| `UpvestApiVersion` | `src/UpvestInvestmentApi/Models/Enums/UpvestApiVersion.cs` |
| `BusinessCheckListResponse` | `src/UpvestInvestmentApi/Models/BusinessCheckListResponse.cs` |
| `ListBusinessChecksError` | `src/UpvestInvestmentApi/Errors/ListBusinessChecksError.cs` |

### RetrieveBusinessCheck

- **Auth**: `options.OauthClientCredentials` (scopes: `checks:read`, `checks:admin`)
- **Signature**: `RetrieveBusinessCheck(RetrieveBusinessCheckRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `BusinessId`, `CheckId`
- **Returns**: `BusinessCheck`
- **Error**: `ApiException<RetrieveBusinessCheckError>` — **Case A (typed)**
- **Error accessors**: `TryGetNoContent([NotNullWhen(true)] out RawError? value)` [401, 403, 404, 406, 429, 500, 503, 504] · `TryGetRawError([NotNullWhen(true)] out RawError? error)` [fallback]

| Type | Source |
| --- | --- |
| `RetrieveBusinessCheckRequest` | `src/UpvestInvestmentApi/Requests/BusinessChecks/RetrieveBusinessCheckRequest.cs` |
| `UpvestApiVersion` | `src/UpvestInvestmentApi/Models/Enums/UpvestApiVersion.cs` |
| `BusinessCheck` | `src/UpvestInvestmentApi/Models/AnyOf/BusinessCheck.cs` |
| `RetrieveBusinessCheckError` | `src/UpvestInvestmentApi/Errors/RetrieveBusinessCheckError.cs` |

