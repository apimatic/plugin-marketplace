<!-- Generated file — do not edit; regenerated with the SDK. -->

# UserIdentifiers — operations

Accessor: `client.UserIdentifiers` · Source: `src/UpvestInvestmentApi/Api/UserIdentifiers.cs` · 4 operations

**Type sources**: the file declaring each type an operation names (`RawError` excluded — see sdk-map.md).

### CreateIdentifier

- **Auth**: `options.OauthClientCredentials` (scopes: `users:admin`)
- **Signature**: `CreateIdentifier(CreateIdentifierRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `UserId`
- **Returns**: `Identifier`
- **Error**: `ApiException<CreateIdentifierError>` — **Case A (typed)**
- **Error accessors**: `TryGetNoContent([NotNullWhen(true)] out RawError? value)` [400, 401, 403, 404, 406, 429, 500, 503, 504] · `TryGetRawError([NotNullWhen(true)] out RawError? error)` [fallback]

| Type | Source |
| --- | --- |
| `CreateIdentifierRequest` | `src/UpvestInvestmentApi/Requests/UserIdentifiers/CreateIdentifierRequest.cs` |
| `UpvestApiVersion` | `src/UpvestInvestmentApi/Models/Enums/UpvestApiVersion.cs` |
| `IdentifierCreateRequest` | `src/UpvestInvestmentApi/Models/IdentifierCreateRequest.cs` |
| `Identifier` | `src/UpvestInvestmentApi/Models/Identifier.cs` |
| `CreateIdentifierError` | `src/UpvestInvestmentApi/Errors/CreateIdentifierError.cs` |

### ListUserIdentifiers

- **Auth**: `options.OauthClientCredentials` (scopes: `users:read`, `users:admin`)
- **Signature**: `ListUserIdentifiers(ListUserIdentifiersRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `UserId`
- **Returns**: `IdentifiersListResponse`
- **Error**: `ApiException<ListUserIdentifiersError>` — **Case A (typed)**
- **Error accessors**: `TryGetNoContent([NotNullWhen(true)] out RawError? value)` [401, 403, 404, 406, 429, 500, 503, 504] · `TryGetRawError([NotNullWhen(true)] out RawError? error)` [fallback]

| Type | Source |
| --- | --- |
| `ListUserIdentifiersRequest` | `src/UpvestInvestmentApi/Requests/UserIdentifiers/ListUserIdentifiersRequest.cs` |
| `UpvestApiVersion` | `src/UpvestInvestmentApi/Models/Enums/UpvestApiVersion.cs` |
| `IdentifiersListResponse` | `src/UpvestInvestmentApi/Models/IdentifiersListResponse.cs` |
| `ListUserIdentifiersError` | `src/UpvestInvestmentApi/Errors/ListUserIdentifiersError.cs` |

### RetrieveIdentifier

- **Auth**: `options.OauthClientCredentials` (scopes: `users:read`, `users:admin`)
- **Signature**: `RetrieveIdentifier(RetrieveIdentifierRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `UserId`, `IdentifierId`
- **Returns**: `Identifier`
- **Error**: `ApiException<RetrieveIdentifierError>` — **Case A (typed)**
- **Error accessors**: `TryGetNoContent([NotNullWhen(true)] out RawError? value)` [401, 403, 404, 406, 429, 500, 503, 504] · `TryGetRawError([NotNullWhen(true)] out RawError? error)` [fallback]

| Type | Source |
| --- | --- |
| `RetrieveIdentifierRequest` | `src/UpvestInvestmentApi/Requests/UserIdentifiers/RetrieveIdentifierRequest.cs` |
| `UpvestApiVersion` | `src/UpvestInvestmentApi/Models/Enums/UpvestApiVersion.cs` |
| `Identifier` | `src/UpvestInvestmentApi/Models/Identifier.cs` |
| `RetrieveIdentifierError` | `src/UpvestInvestmentApi/Errors/RetrieveIdentifierError.cs` |

### UpdateIdentifier

- **Auth**: `options.OauthClientCredentials` (scopes: `users:admin`)
- **Signature**: `UpdateIdentifier(UpdateIdentifierRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `UserId`, `IdentifierId`
- **Returns**: `Identifier`
- **Error**: `ApiException<UpdateIdentifierError>` — **Case A (typed)**
- **Error accessors**: `TryGetNoContent([NotNullWhen(true)] out RawError? value)` [400, 401, 403, 404, 406, 429, 500, 503, 504] · `TryGetRawError([NotNullWhen(true)] out RawError? error)` [fallback]

| Type | Source |
| --- | --- |
| `UpdateIdentifierRequest` | `src/UpvestInvestmentApi/Requests/UserIdentifiers/UpdateIdentifierRequest.cs` |
| `UpvestApiVersion` | `src/UpvestInvestmentApi/Models/Enums/UpvestApiVersion.cs` |
| `IdentifierUpdateRequest` | `src/UpvestInvestmentApi/Models/IdentifierUpdateRequest.cs` |
| `Identifier` | `src/UpvestInvestmentApi/Models/Identifier.cs` |
| `UpdateIdentifierError` | `src/UpvestInvestmentApi/Errors/UpdateIdentifierError.cs` |

