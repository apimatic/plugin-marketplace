<!-- Generated file — do not edit; regenerated with the SDK. -->

# Fees — operations

Accessor: `client.Fees` · Source: `src/UpvestInvestmentApi/Api/Fees.cs` · 3 operations

**Type sources**: the file declaring each type an operation names (`RawError` excluded — see sdk-map.md).

### CreateFeeCollection

- **Auth**: `options.OauthClientCredentials` (scopes: `fees:admin`)
- **Signature**: `CreateFeeCollection(CreateFeeCollectionRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `IdempotencyKey`
- **Returns**: `FeeCollection`
- **Error**: `ApiException<CreateFeeCollectionError>` — **Case A (typed)**
- **Error accessors**: `TryGetNoContent([NotNullWhen(true)] out RawError? value)` [400, 401, 403, 404, 406, 429, 500, 503, 504] · `TryGetRawError([NotNullWhen(true)] out RawError? error)` [fallback]

| Type | Source |
| --- | --- |
| `CreateFeeCollectionRequest` | `src/UpvestInvestmentApi/Requests/Fees/CreateFeeCollectionRequest.cs` |
| `UpvestApiVersion` | `src/UpvestInvestmentApi/Models/Enums/UpvestApiVersion.cs` |
| `FeeCollectionCreateRequest` | `src/UpvestInvestmentApi/Models/FeeCollectionCreateRequest.cs` |
| `FeeCollection` | `src/UpvestInvestmentApi/Models/FeeCollection.cs` |
| `CreateFeeCollectionError` | `src/UpvestInvestmentApi/Errors/CreateFeeCollectionError.cs` |

### ListFeeCollections

- **Auth**: `options.OauthClientCredentials` (scopes: `fees:read`, `fees:admin`)
- **Signature**: `ListFeeCollections(ListFeeCollectionsRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
- **Query params (wire ← C#)**: `account_id` ← `AccountId`, `account_group_id` ← `AccountGroupId`, `sort` ← `Sort`, `order` ← `Order`, `offset` ← `Offset`, `limit` ← `Limit`
- **Returns**: `FeeCollectionListResponse`
- **Error**: `ApiException<ListFeeCollectionsError>` — **Case A (typed)**
- **Error accessors**: `TryGetNoContent([NotNullWhen(true)] out RawError? value)` [400, 401, 403, 406, 429, 500, 503, 504] · `TryGetRawError([NotNullWhen(true)] out RawError? error)` [fallback]

| Type | Source |
| --- | --- |
| `ListFeeCollectionsRequest` | `src/UpvestInvestmentApi/Requests/Fees/ListFeeCollectionsRequest.cs` |
| `Sort1` | `src/UpvestInvestmentApi/Models/Enums/Sort1.cs` |
| `Order` | `src/UpvestInvestmentApi/Models/Enums/Order.cs` |
| `UpvestApiVersion` | `src/UpvestInvestmentApi/Models/Enums/UpvestApiVersion.cs` |
| `FeeCollectionListResponse` | `src/UpvestInvestmentApi/Models/FeeCollectionListResponse.cs` |
| `ListFeeCollectionsError` | `src/UpvestInvestmentApi/Errors/ListFeeCollectionsError.cs` |

### RetrieveFeeCollection

- **Auth**: `options.OauthClientCredentials` (scopes: `fees:read`, `fees:admin`)
- **Signature**: `RetrieveFeeCollection(RetrieveFeeCollectionRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `FeeCollectionId`
- **Returns**: `FeeCollection`
- **Error**: `ApiException<RetrieveFeeCollectionError>` — **Case A (typed)**
- **Error accessors**: `TryGetNoContent([NotNullWhen(true)] out RawError? value)` [401, 403, 404, 406, 429, 500, 503, 504] · `TryGetRawError([NotNullWhen(true)] out RawError? error)` [fallback]

| Type | Source |
| --- | --- |
| `RetrieveFeeCollectionRequest` | `src/UpvestInvestmentApi/Requests/Fees/RetrieveFeeCollectionRequest.cs` |
| `UpvestApiVersion` | `src/UpvestInvestmentApi/Models/Enums/UpvestApiVersion.cs` |
| `FeeCollection` | `src/UpvestInvestmentApi/Models/FeeCollection.cs` |
| `RetrieveFeeCollectionError` | `src/UpvestInvestmentApi/Errors/RetrieveFeeCollectionError.cs` |

