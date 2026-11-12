<!-- Generated file — do not edit; regenerated with the SDK. -->

# Businesses — operations

Accessor: `client.Businesses` · Source: `src/UpvestInvestmentApi/Api/Businesses.cs` · 4 operations

**Type sources**: the file declaring each type an operation names (`RawError` excluded — see sdk-map.md).

### BusinessDataChange

- **Auth**: `options.OauthClientCredentials` (scopes: `businesses:admin`)
- **Signature**: `BusinessDataChange(BusinessDataChangeRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `BusinessId`
- **Returns**: `void` (Task)
- **Error**: `ApiException<BusinessDataChangeError>` — **Case A (typed)**
- **Error accessors**: `TryGetNoContent([NotNullWhen(true)] out RawError? value)` [400, 401, 403, 404, 406, 429, 500, 503, 504] · `TryGetRawError([NotNullWhen(true)] out RawError? error)` [fallback]

| Type | Source |
| --- | --- |
| `BusinessDataChangeRequest` | `src/UpvestInvestmentApi/Requests/Businesses/BusinessDataChangeRequest.cs` |
| `UpvestApiVersion` | `src/UpvestInvestmentApi/Models/Enums/UpvestApiVersion.cs` |
| `BusinessCompanyUpdateRequest` | `src/UpvestInvestmentApi/Models/BusinessCompanyUpdateRequest.cs` |
| `BusinessDataChangeError` | `src/UpvestInvestmentApi/Errors/BusinessDataChangeError.cs` |

### CreateBusiness

- **Auth**: `options.OauthClientCredentials` (scopes: `businesses:admin`)
- **Signature**: `CreateBusiness(CreateBusinessRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `IdempotencyKey`
- **Returns**: `BusinessCreateRequest1`
- **Error**: `ApiException<CreateBusinessError>` — **Case A (typed)**
- **Error accessors**: `TryGetNoContent([NotNullWhen(true)] out RawError? value)` [400, 401, 403, 406, 429, 500, 503, 504] · `TryGetRawError([NotNullWhen(true)] out RawError? error)` [fallback]

| Type | Source |
| --- | --- |
| `CreateBusinessRequest` | `src/UpvestInvestmentApi/Requests/Businesses/CreateBusinessRequest.cs` |
| `UpvestApiVersion` | `src/UpvestInvestmentApi/Models/Enums/UpvestApiVersion.cs` |
| `BusinessCreateRequest` | `src/UpvestInvestmentApi/Models/AnyOf/BusinessCreateRequest.cs` |
| `BusinessCreateRequest1` | `src/UpvestInvestmentApi/Models/AnyOf/BusinessCreateRequest1.cs` |
| `CreateBusinessError` | `src/UpvestInvestmentApi/Errors/CreateBusinessError.cs` |

### ListBusinesses

- **Auth**: `options.OauthClientCredentials` (scopes: `businesses:read`, `businesses:admin`)
- **Signature**: `ListBusinesses(ListBusinessesRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
- **Query params (wire ← C#)**: `sort` ← `Sort`, `order` ← `Order`, `offset` ← `Offset`, `limit` ← `Limit`
- **Returns**: `BusinessesListResponse`
- **Error**: `ApiException<ListBusinessesError>` — **Case A (typed)**
- **Error accessors**: `TryGetNoContent([NotNullWhen(true)] out RawError? value)` [400, 401, 403, 406, 429, 500, 503, 504] · `TryGetRawError([NotNullWhen(true)] out RawError? error)` [fallback]

| Type | Source |
| --- | --- |
| `ListBusinessesRequest` | `src/UpvestInvestmentApi/Requests/Businesses/ListBusinessesRequest.cs` |
| `Sort1` | `src/UpvestInvestmentApi/Models/Enums/Sort1.cs` |
| `Order` | `src/UpvestInvestmentApi/Models/Enums/Order.cs` |
| `UpvestApiVersion` | `src/UpvestInvestmentApi/Models/Enums/UpvestApiVersion.cs` |
| `BusinessesListResponse` | `src/UpvestInvestmentApi/Models/BusinessesListResponse.cs` |
| `ListBusinessesError` | `src/UpvestInvestmentApi/Errors/ListBusinessesError.cs` |

### RetrieveBusiness

- **Auth**: `options.OauthClientCredentials` (scopes: `businesses:read`, `businesses:admin`)
- **Signature**: `RetrieveBusiness(RetrieveBusinessRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `BusinessId`
- **Returns**: `BusinessesResponse2`
- **Error**: `ApiException<RetrieveBusinessError>` — **Case A (typed)**
- **Error accessors**: `TryGetNoContent([NotNullWhen(true)] out RawError? value)` [401, 403, 404, 406, 429, 500, 503, 504] · `TryGetRawError([NotNullWhen(true)] out RawError? error)` [fallback]

| Type | Source |
| --- | --- |
| `RetrieveBusinessRequest` | `src/UpvestInvestmentApi/Requests/Businesses/RetrieveBusinessRequest.cs` |
| `UpvestApiVersion` | `src/UpvestInvestmentApi/Models/Enums/UpvestApiVersion.cs` |
| `BusinessesResponse2` | `src/UpvestInvestmentApi/Models/AnyOf/BusinessesResponse2.cs` |
| `RetrieveBusinessError` | `src/UpvestInvestmentApi/Errors/RetrieveBusinessError.cs` |

